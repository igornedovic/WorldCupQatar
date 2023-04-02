import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { switchMap, take, tap } from 'rxjs/operators';

import { MatchInterface } from '../models/match.model';

@Injectable({
  providedIn: 'root'
})
export class MatchService {
  apiUrl = environment.apiUrl;
  private _matches = new BehaviorSubject<MatchInterface[]>([]);

  constructor(private http: HttpClient) { }

  get matches() {
    return this._matches.asObservable();
  }

  addNewMatch(matchForm: MatchInterface) {
    let newMatch: MatchInterface;

    return this.http.post<MatchInterface>(this.apiUrl + 'matches', matchForm).pipe(
      switchMap(response => {
        newMatch = {
          id: response.id,
          matchDateTime: response.matchDateTime,
          status: response.status,
          team1Name: response.team1Name,
          team2Name: response.team2Name,
          stadiumName: response.stadiumName
        }

        return this.matches;
      }),
      take(1),
      tap(matches => {
        const newMatches = matches.concat(newMatch);
        this._matches.next(newMatches);
      })
    )
  }
}
