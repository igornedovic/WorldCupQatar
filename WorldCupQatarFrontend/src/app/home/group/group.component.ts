import { Component, Input, OnInit } from '@angular/core';
import { GroupInterface } from 'src/app/models/group.model';
import { TeamInterface } from 'src/app/models/team.model';
import { GroupService } from 'src/app/services/group.service';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit {
  @Input() group!: GroupInterface;
  teams: TeamInterface[] = [];

  isCollapsed = false;

  constructor(private groupService: GroupService) { }

  ngOnInit(): void {
  }

  onGroupClick(id: number) {
    this.isCollapsed = !this.isCollapsed;
    
    if (this.isCollapsed) {
      this.groupService.getGroupTeams(id).subscribe(teams => {
        this.teams = teams;
      })
    }
  }

}
