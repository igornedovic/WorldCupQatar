import { Component, Input, OnInit } from '@angular/core';
import { TeamInterface } from 'src/app/models/team.model';

@Component({
  selector: 'app-teams-table',
  templateUrl: './teams-table.component.html',
  styleUrls: ['./teams-table.component.css']
})
export class TeamsTableComponent implements OnInit {
  @Input() addedTeams : TeamInterface[] = [];
  @Input() isTeamAdded! : Boolean;

  constructor() { }

  ngOnInit(): void {
  }

  onRemoveTeam(name: string) {
    this.addedTeams = this.addedTeams.filter(t => t.name != name);
  }

}
