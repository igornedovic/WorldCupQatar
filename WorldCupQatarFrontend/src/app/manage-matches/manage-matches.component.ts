import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { NewMatchComponent } from './new-match/new-match.component';

@Component({
  selector: 'app-manage-matches',
  templateUrl: './manage-matches.component.html',
  styleUrls: ['./manage-matches.component.css']
})
export class ManageMatchesComponent implements OnInit {
  bsModalRef?: BsModalRef;

  constructor(private modalService: BsModalService) { }

  ngOnInit(): void {
  }

  openNewMatchModal() {
    const initialState: ModalOptions = {
      initialState: {
        title: 'Add new match',
        
      }
    };
    this.bsModalRef = this.modalService.show(NewMatchComponent, initialState);
    this.bsModalRef.content.closeBtnName = 'Close';
    this.bsModalRef.setClass('modal-lg');
  }

}
