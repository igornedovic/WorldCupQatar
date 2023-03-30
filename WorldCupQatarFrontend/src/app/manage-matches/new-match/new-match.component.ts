import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-new-match',
  templateUrl: './new-match.component.html',
  styleUrls: ['./new-match.component.css'],
})
export class NewMatchComponent implements OnInit {
  title?: string;
  closeBtnName?: string;

  constructor(public bsModalRef: BsModalRef) {}

  ngOnInit(): void {}
}
