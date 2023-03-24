import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { StadiumInterface } from '../models/stadium.model';

import { WorldCupInterface } from '../models/worldcup.model';
import { WorldcupService } from '../services/worldcup.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit, OnDestroy {
  worldCup!: WorldCupInterface;
  firstRowStadiums!: StadiumInterface[];
  secondRowStadiums!: StadiumInterface[];
  private worldCupSub!: Subscription;

  constructor(private worldCupService: WorldcupService) {}

  ngOnInit() {
    this.worldCupService.getWorldCup().subscribe(() => {});

    this.worldCupSub = this.worldCupService.worldCup.subscribe((worldCup) => {
      this.worldCup = worldCup;
      const halfLength = Math.ceil(this.worldCup.stadiums.length / 2);
      this.firstRowStadiums = this.worldCup.stadiums.slice(0, halfLength);
      this.secondRowStadiums = this.worldCup.stadiums.slice(halfLength);
    });
  }

  ngOnDestroy() {
    if (this.worldCupSub) {
      this.worldCupSub.unsubscribe();
    }
  }
}
