import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-teams-table',
  templateUrl: './teams-table.component.html',
  styleUrls: ['./teams-table.component.css']
})
export class TeamsTableComponent implements OnInit {
  @Input() isTeamAdded! : Boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
