import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-manage-groups-teams',
  templateUrl: './manage-groups-teams.component.html',
  styleUrls: ['./manage-groups-teams.component.css'],
})
export class ManageGroupsTeamsComponent implements OnInit {
  groupTeamsForm!: FormGroup;
  team!: FormGroup;

  constructor() {}

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

  onAddNewTeam() {
    this.groupTeamsForm.get("team")?.get("name")?.setValue("");
    this.groupTeamsForm.get("team")?.get("iconUrl")?.setValue("");
  }

  onSaveGroupWithTeams() {
    console.log(this.groupTeamsForm.value)
  }
}
