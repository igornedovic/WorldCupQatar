import { Component, Input, OnInit } from '@angular/core';
import { StadiumInterface } from 'src/app/models/stadium.model';

@Component({
  selector: 'app-stadium',
  templateUrl: './stadium.component.html',
  styleUrls: ['./stadium.component.css']
})
export class StadiumComponent implements OnInit {
  @Input() stadium!: StadiumInterface;

  constructor() { }

  ngOnInit(): void {
  }

}
