import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { GroupService } from 'src/app/services/group.service';

@Component({
  selector: 'app-new-match',
  templateUrl: './new-match.component.html',
  styleUrls: ['./new-match.component.css'],
})
export class NewMatchComponent implements OnInit {
  title?: string;
  closeBtnName?: string;

  constructor(public bsModalRef: BsModalRef, private groupService: GroupService) {}

  ngOnInit() {
    
  }
}
