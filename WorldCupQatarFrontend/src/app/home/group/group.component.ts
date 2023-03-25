import { Component, Input, OnInit } from '@angular/core';
import { GroupInterface } from 'src/app/models/group.model';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit {
  @Input() group!: GroupInterface;

  isCollapsed = false;

  constructor() { }

  ngOnInit(): void {
  }

}
