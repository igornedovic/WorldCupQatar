import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';

import { TeamInterface } from '../models/team.model';
import { GroupService } from '../services/group.service';

@Component({
  selector: 'app-manage-groups-teams',
  templateUrl: './manage-groups-teams.component.html',
  styleUrls: ['./manage-groups-teams.component.css'],
})
export class ManageGroupsTeamsComponent implements OnInit {
  groupTeamsForm!: FormGroup;
  addedTeams: TeamInterface[] = [];
  uploadImageUrl!: string;
  pickedFile!: File;
  isTeamAdded = false;
  private groupSub!: Subscription;

  constructor(
    private groupService: GroupService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.groupTeamsForm = new FormGroup({
      groupName: new FormControl('', Validators.required),
      worldCupId: new FormControl(1, Validators.required),
      teams: new FormGroup({
        name: new FormControl('', Validators.required),
        iconUrl: new FormControl('', Validators.required),
      }),
    });
  }

  onFileChosen(event: Event) {
    this.pickedFile = (event?.target as HTMLInputElement)?.files![0];
  }

  onAddNewTeam() {
    if (
      !this.groupTeamsForm?.get('team')?.get('name')?.value ||
      !this.pickedFile
    ) {
      return;
    }

    this.groupService
      .uploadCountryFlag(this.pickedFile)
      .subscribe((uploadResponse) => {
        this.uploadImageUrl = uploadResponse.url;

        this.addedTeams.push({
          name: this.groupTeamsForm?.get('team')?.get('name')?.value,
          iconUrl: this.uploadImageUrl,
        });

        this.groupTeamsForm.get('team')?.get('name')?.setValue('');
        this.groupTeamsForm.get('team')?.get('iconUrl')?.setValue('');

        this.uploadImageUrl = '';
        this.isTeamAdded = true;
      });
  }

  onSaveGroupWithTeams() {
    this.groupSub = this.groupService
      .addNewGroupWithTeams(this.groupTeamsForm.value, this.addedTeams)
      .subscribe((response) => {
        this.toastrService.success('Successful!');
      }, error => {
        console.log(error);
      });
  }
}
