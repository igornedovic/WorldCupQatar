import { Component, Input, OnInit } from '@angular/core';
import { TeamInterface } from 'src/app/models/team.model';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {
  @Input() teams: TeamInterface[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
