import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { map, switchMap, take, tap } from 'rxjs/operators';

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

  getMatches() {
    return this.http.get<MatchInterface[]>(this.apiUrl + 'matches').pipe(
      map((response) => {
        const matches: MatchInterface[] = [];

        response.forEach((m) => {
          matches.push({
            id: m.id,
            matchDateTime: m.matchDateTime,
            status: m.status,
            team1Id: m.team1Id,
            team1Name: m.team1Name,
            team1IconUrl: m.team1IconUrl,
            team1Goals: m?.team1Goals ?? '-',
            team2Id: m.team2Id,
            team2Name: m.team2Name,
            team2IconUrl: m.team2IconUrl,
            team2Goals: m?.team2Goals ?? '-',
            stadiumName: m.stadiumName
          });
        });

        return matches;
      }),
      tap((matches) => {
        this._matches.next(matches);
      })
    );
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
