import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';

import { MatchInterface, MatchStatus } from 'src/app/models/match.model';

@Component({
  selector: 'app-match-preview',
  templateUrl: './match-preview.component.html',
  styleUrls: ['./match-preview.component.css']
})
export class MatchPreviewComponent implements OnInit, AfterViewInit {
  @Input() match!: MatchInterface;
  public matchStatuses = Object.values(MatchStatus);
  @ViewChild('selectedStatus') selectedStatusRef!: ElementRef;
  @ViewChild('changeStatusCheckbox') changeStatusCheckboxRef!: ElementRef;
  @ViewChild('saveButton') saveButton!: ElementRef;

  constructor() { }

  ngOnInit() {}

  ngAfterViewInit() {
    this.selectedStatusRef.nativeElement.disabled = true;
    this.saveButton.nativeElement.disabled = true;
  }

  onStatusChange() {
    if (this.selectedStatusRef.nativeElement.value == MatchStatus.NotStarted)
    {
      this.saveButton.nativeElement.disabled = true;
      return;
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

}
