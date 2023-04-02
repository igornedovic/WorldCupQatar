import { Component, OnDestroy, OnInit } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';

import { NewMatchComponent } from './new-match/new-match.component';
import { MatchService } from '../services/match.service';
import { MatchInterface } from '../models/match.model';

@Component({
  selector: 'app-manage-matches',
  templateUrl: './manage-matches.component.html',
  styleUrls: ['./manage-matches.component.css']
})
export class ManageMatchesComponent implements OnInit, OnDestroy {
  bsModalRef?: BsModalRef;
  matches: MatchInterface[] = [];
  private matchSub!: Subscription;

  constructor(private modalService: BsModalService, private matchesService: MatchService) { }

  ngOnInit() {
    this.matchesService.getMatches().subscribe(() => {});

    this.matchSub = this.matchesService.matches.subscribe(matches => {
      this.matches = matches;
    })
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

  ngOnDestroy() {
    if (this.matchSub) {
      this.matchSub.unsubscribe();
    }
  }

}
