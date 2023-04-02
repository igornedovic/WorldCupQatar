import { Component, Input, OnInit } from '@angular/core';
import { MatchInterface } from 'src/app/models/match.model';

@Component({
  selector: 'app-match-preview',
  templateUrl: './match-preview.component.html',
  styleUrls: ['./match-preview.component.css']
})
export class MatchPreviewComponent implements OnInit {
  @Input() match!: MatchInterface;

  constructor() { }

  ngOnInit(): void {
  }

}
