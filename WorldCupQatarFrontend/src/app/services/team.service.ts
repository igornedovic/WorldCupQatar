import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { TeamInterface } from '../models/team.model';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTeams() {
    return this.http.get<{ id: number; name: string; groupId: number; }[]>(this.apiUrl + `teams`).pipe(
      map((response) => {
        const teams: TeamInterface[] = [];

        response.forEach((t) => {
          teams.push({
            id: t.id,
            name: t.name,
            groupId: t.groupId
          });
        });

        return teams;
      })
    );
  }
}
