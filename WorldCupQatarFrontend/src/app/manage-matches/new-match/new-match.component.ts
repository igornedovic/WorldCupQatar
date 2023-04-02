import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';

import { GroupInterface } from 'src/app/models/group.model';
import { StadiumInterface } from 'src/app/models/stadium.model';
import { TeamInterface } from 'src/app/models/team.model';
import { GroupService } from 'src/app/services/group.service';
import { MatchService } from 'src/app/services/match.service';
import { StadiumService } from 'src/app/services/stadium.service';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-new-match',
  templateUrl: './new-match.component.html',
  styleUrls: ['./new-match.component.css'],
})
export class NewMatchComponent implements OnInit, OnDestroy {
  title?: string;
  closeBtnName?: string;
  newMatchForm!: FormGroup;
  groups: GroupInterface[] = [];
  groupsSub!: Subscription;
  stadiums: StadiumInterface[] = [];
  allTeams: TeamInterface[] = [];
  groupTeams: TeamInterface[] = [];
  team1Choices: TeamInterface[] = [];
  team2Choices: TeamInterface[] = [];

  constructor(public bsModalRef: BsModalRef, 
              private groupService: GroupService,
              private stadiumService: StadiumService,
              private teamService: TeamService,
              private matchService: MatchService,
              private toastrService: ToastrService) {}

  ngOnInit() {
    this.newMatchForm = new FormGroup({
      team1Id: new FormControl('', Validators.required),
      team2Id: new FormControl('', Validators.required),
      matchDateTime: new FormControl('', Validators.required),
      stadiumId: new FormControl('', Validators.required)
    })

    this.groupsSub = this.groupService.groups.subscribe(groups => {
      this.groups = groups;
    })

    this.stadiumService.getStadiums().subscribe(stadiums => {
      this.stadiums = stadiums;
    })

    this.teamService.getTeams().subscribe(allTeams => {
      this.allTeams = allTeams;
    })
  }

  onGroupChange(group: HTMLSelectElement) {
    this.groupTeams = this.allTeams.filter(gt => gt.groupId === +group.value);
    this.newMatchForm.get('team1Id')?.setValue('');
    this.newMatchForm.get('team2Id')?.setValue('');
    this.team1Choices = this.groupTeams.slice();
    this.team2Choices = this.groupTeams.slice();
  }

  onTeamChange(team: HTMLSelectElement) {
    if (team.id === 'team1') {
      this.team2Choices = this.groupTeams.filter(t => t.id !== +team.value); 
    } else {
      this.team1Choices = this.groupTeams.filter(t => t.id !== +team.value);
    }
  }

  onMatchDateTimeChange(matchDateTime: HTMLInputElement) {
    this.newMatchForm.get('matchDateTime')?.setValue(matchDateTime.value.replace('T', ' '));
  }

  onAddMatch() {
    this.matchService.addNewMatch(this.newMatchForm.value).subscribe(success => {
      this.toastrService.success("Successfully scheduled new match!");
      this.bsModalRef.hide();
    })
  }

  ngOnDestroy() {
    if (this.groupsSub) {
      this.groupsSub.unsubscribe();
    }
  }
}
