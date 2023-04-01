import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

import { StadiumInterface } from '../models/stadium.model';

@Injectable({
  providedIn: 'root'
})
export class StadiumService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getStadiums() {
    return this.http.get<{ id: number; name: string; }[]>(this.apiUrl + `stadiums`).pipe(
      map((response) => {
        const stadiums: StadiumInterface[] = [];

        response.forEach((s) => {
          stadiums.push({
            id: s.id,
            name: s.name
          });
        });

        return stadiums;
      })
    );
  }
}
