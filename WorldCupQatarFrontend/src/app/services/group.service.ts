import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map, switchMap, take, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { GroupInterface } from '../models/group.model';
import { TeamInterface } from '../models/team.model';

@Injectable({
  providedIn: 'root',
})
export class GroupService {
  apiUrl = environment.apiUrl;
  private _groups = new ReplaySubject<GroupInterface[]>(1);

  constructor(private http: HttpClient) {}

  get groups() {
    return this._groups.asObservable();
  }

  getGroups() {
    return this.http.get<GroupInterface[]>(this.apiUrl + 'groups').pipe(
      map((response) => {
        const groups: GroupInterface[] = [];

        response.forEach((g) => {
          groups.push({
            id: g.id,
            groupName: g.groupName,
          });
        });

        return groups;
      }),
      tap((groups) => {
        this._groups.next(groups);
      })
    );
  }

  getGroupTeams(id: number) {
    return this.http.get<TeamInterface[]>(this.apiUrl + `groups/${id}/teams`).pipe(
      map((response) => {
        const teams: TeamInterface[] = [];

        response.forEach((t) => {
          teams.push({
            id: t.id,
            name: t.name,
            iconUrl: t.iconUrl,
            matchesPlayed: t.matchesPlayed,
            wins: t.wins,
            draws: t.draws,
            losses: t.losses,
            goalsScored: t.goalsScored,
            goalsConceded: t.goalsConceded,
            points: t.points
          });
        });

        return teams;
      })
    );
  }

  uploadCountryFlag(imageFile: File) {
    const formData = new FormData();
    formData.append('file', imageFile);
    formData.append('upload_preset', 'tnzfsbju');

    return this.http.post<{ url: string }>(
      'https://api.cloudinary.com/v1_1/dosbawfen/image/upload',
      formData
    );
  }

  addNewGroupWithTeams(groupForm: GroupInterface, addedTeams: TeamInterface[]) {
    let newGroup: GroupInterface;

    return this.http.post<GroupInterface>(this.apiUrl + 'groups', {
      name: groupForm.groupName,
      worldCupId: groupForm.worldCupId,
      teams: addedTeams.map(t => {
        return {
          name: t.name,
          iconUrl: t.iconUrl
        }
      })
    }).pipe(
      switchMap(response => {
        newGroup = { id: response.id, groupName: response.groupName };

        return this.groups;
      }),
      take(1),
      tap(groups => {
        const newGroups = groups.concat(newGroup);
        this._groups.next(newGroups);
      })
    )
  }
}
