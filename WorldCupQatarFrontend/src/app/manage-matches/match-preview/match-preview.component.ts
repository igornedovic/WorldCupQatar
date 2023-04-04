import {
  AfterViewInit,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { MatchInterface, MatchStatus } from 'src/app/models/match.model';
import { MatchService } from 'src/app/services/match.service';

@Component({
  selector: 'app-match-preview',
  templateUrl: './match-preview.component.html',
  styleUrls: ['./match-preview.component.css'],
})
export class MatchPreviewComponent implements OnInit, AfterViewInit {
  @Input() match!: MatchInterface;
  public matchStatuses = Object.values(MatchStatus);
  minGoals = 0;
  maxGoals = 15;
  @ViewChild('selectedStatus') selectedStatusRef!: ElementRef;
  @ViewChild('changeStatusCheckbox') changeStatusCheckboxRef!: ElementRef;
  @ViewChild('saveButton') saveButton!: ElementRef;
  @ViewChild('team1Goals') team1Goals!: ElementRef;
  @ViewChild('team2Goals') team2Goals!: ElementRef;

  constructor(private matchService: MatchService,
              private toastrService: ToastrService) {}

  ngOnInit() {}

  ngAfterViewInit() {
    this.selectedStatusRef.nativeElement.disabled = true;
    this.saveButton.nativeElement.disabled = true;
    this.team1Goals.nativeElement.disabled = true;
    this.team2Goals.nativeElement.disabled = true;
  }

  onStatusChange() {
    if (this.selectedStatusRef.nativeElement.value == MatchStatus.NotStarted) {
      this.saveButton.nativeElement.disabled = true;
      return;
    }

    if (this.selectedStatusRef.nativeElement.value == MatchStatus.Finished) {
      this.team1Goals.nativeElement.value = '';
      this.team2Goals.nativeElement.value = '';
      this.team1Goals.nativeElement.disabled = false;
      this.team2Goals.nativeElement.disabled = false;
    } else {
      this.team1Goals.nativeElement.disabled = true;
      this.team2Goals.nativeElement.disabled = true;
    }

    if (this.selectedStatusRef.nativeElement.value == MatchStatus.Team1Forfeit) {
      this.team1Goals.nativeElement.value = 0;
      this.team2Goals.nativeElement.value = 3;
    } 

    if (this.selectedStatusRef.nativeElement.value == MatchStatus.Team2Forfeit) {
      this.team1Goals.nativeElement.value = 3;
      this.team2Goals.nativeElement.value = 0;
    }

    this.saveButton.nativeElement.disabled = false;
  }

  onChangeCheckbox(changeStatusCheckbox: HTMLInputElement) {
    if (changeStatusCheckbox.checked) {
      this.selectedStatusRef.nativeElement.disabled = false;
    } else {
      this.selectedStatusRef.nativeElement.disabled = true;
    }
  }

  onUpdateMatchStatusAndResult(id: number | undefined) {
    const newStatus  = this.selectedStatusRef.nativeElement.value as MatchStatus;
    const team1Goals = +this.team1Goals.nativeElement.value;
    const team2Goals = +this.team2Goals.nativeElement.value;
    
    if (team1Goals < this.minGoals || 
        team1Goals > this.maxGoals || team2Goals < this.minGoals || team2Goals > this.maxGoals) {
          this.toastrService.error("Invalid goal number input!");
          return;
    }

    if (typeof id === "undefined") {
      return;
    }

    this.matchService.updateMatchStatusAndResult(id, newStatus, team1Goals, team2Goals).subscribe(
      response => {
        this.toastrService.success(response);
      }
    )
  }
}
