import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { GroupInterface } from '../models/group.model';

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
            name: g.name,
          });
        });

        return groups;
      }),
      tap((groups) => {
        this._groups.next(groups);
      })
    );
  }
}
