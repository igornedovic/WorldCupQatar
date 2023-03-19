import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ManageGroupsTeamsComponent } from './manage-groups-teams/manage-groups-teams.component';
import { ManageMatchesComponent } from './manage-matches/manage-matches.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'groups-teams',
    component: ManageGroupsTeamsComponent,
  },
  {
    path: 'matches',
    component: ManageMatchesComponent,
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  {
    path: '**',
    redirectTo: 'home',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
