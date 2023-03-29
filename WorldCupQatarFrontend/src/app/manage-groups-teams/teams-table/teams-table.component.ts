import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { TeamInterface } from 'src/app/models/team.model';

@Component({
  selector: 'app-teams-table',
  templateUrl: './teams-table.component.html',
  styleUrls: ['./teams-table.component.css']
})
export class TeamsTableComponent implements OnInit {
  @Input() addedTeams : TeamInterface[] = [];
  @Output() updatedTeamsEvent = new EventEmitter<TeamInterface[]>();
  @Input() isTeamAdded = false;

  constructor() { }

  ngOnInit(): void {
  }

  onRemoveTeam(name: string) {
    this.updatedTeamsEvent.emit(this.addedTeams.filter(t => t.name != name));
  }

}
