import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { GroupInterface } from '../models/group.model';
import { StadiumInterface } from '../models/stadium.model';

import { WorldCupInterface } from '../models/worldcup.model';
import { GroupService } from '../services/group.service';
import { WorldcupService } from '../services/worldcup.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit, OnDestroy {
  worldCup!: WorldCupInterface | null;
  firstRowStadiums!: StadiumInterface[];
  secondRowStadiums!: StadiumInterface[];
  groups!: GroupInterface[];
  private worldCupSub!: Subscription;
  private groupsSub!: Subscription;

  isCollapsed = false;

  constructor(private worldCupService: WorldcupService, private groupService: GroupService) {}

  ngOnInit() {
    this.worldCupService.getWorldCup().subscribe(() => {});
    this.groupService.getGroups().subscribe(() => {});

    this.worldCupSub = this.worldCupService.worldCup.subscribe((worldCup) => {
      this.worldCup = worldCup;
      const halfLength = Math.ceil(this.worldCup.stadiums.length / 2);
      this.firstRowStadiums = this.worldCup.stadiums.slice(0, halfLength);
      this.secondRowStadiums = this.worldCup.stadiums.slice(halfLength);
    });

    this.groupsSub = this.groupService.groups.subscribe(groups => {
      this.groups = groups;
    })
  }

  ngOnDestroy() {
    if (this.worldCupSub) {
      this.worldCupSub.unsubscribe();
    }

    if (this.groupsSub) {
      this.groupsSub.unsubscribe();
    }
  }
}
