import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { TeamInterface } from '../models/team.model';
import { GroupService } from '../services/group.service';

@Component({
  selector: 'app-manage-groups-teams',
  templateUrl: './manage-groups-teams.component.html',
  styleUrls: ['./manage-groups-teams.component.css'],
})
export class ManageGroupsTeamsComponent implements OnInit {
  groupTeamsForm!: FormGroup;
  teams: TeamInterface[] = [];
  uploadImageUrl!: string;

  isTeamAdded = false;

  constructor(private groupService: GroupService) {}

  ngOnInit(): void {
    this.groupTeamsForm = new FormGroup({
      name: new FormControl('', Validators.required),
      worldCupId: new FormControl(1, Validators.required),
      team: new FormGroup(
        {
          name: new FormControl('', Validators.required),
          iconUrl: new FormControl('', Validators.required),
        })
    });
  }

  onFileChosen(event: Event) {
    const pickedFile = (event?.target as HTMLInputElement)?.files![0];
    if (!pickedFile) {
      return;
    }
    
    this.groupService.uploadCountryFlag(pickedFile)
                     .subscribe(uploadResponse => {
                      this.uploadImageUrl = uploadResponse.url;
                      console.log(this.uploadImageUrl);
                     })
  }

  onAddNewTeam() {
    this.groupTeamsForm.get("team")?.get("name")?.setValue("");
    this.groupTeamsForm.get("team")?.get("iconUrl")?.setValue("");
    this.isTeamAdded = true;
  }

  onSaveGroupWithTeams() {
    console.log(this.groupTeamsForm.value)
  }
}
