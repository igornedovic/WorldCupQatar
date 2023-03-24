import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject } from 'rxjs';
import { tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { WorldCupInterface } from '../models/worldcup.model';

@Injectable({
  providedIn: 'root'
})
export class WorldcupService {
  apiUrl = environment.apiUrl;
  private _worldCup = new ReplaySubject<WorldCupInterface>(1);

  constructor(private http: HttpClient) { }

  get worldCup()
  {
    return this._worldCup.asObservable();
  }

  getWorldCup() {
    return this.http.get<WorldCupInterface>(this.apiUrl + 'worldcups/1').pipe(
      tap(worldCup => {
        this._worldCup.next(worldCup);
      })
    );
  }
}


