import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { ManageGroupsTeamsComponent } from './manage-groups-teams/manage-groups-teams.component';
import { ManageMatchesComponent } from './manage-matches/manage-matches.component';
import { StadiumComponent } from './home/stadium/stadium.component';
import { GroupComponent } from './home/group/group.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TeamComponent } from './home/team/team.component';
import { TeamsTableComponent } from './manage-groups-teams/teams-table/teams-table.component';
import { ErrorInterceptor } from './interceptor/error.interceptor';
import { MatchPreviewComponent } from './manage-matches/match-preview/match-preview.component';
import { NewMatchComponent } from './manage-matches/new-match/new-match.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    ManageGroupsTeamsComponent,
    ManageMatchesComponent,
    StadiumComponent,
    GroupComponent,
    TeamComponent,
    TeamsTableComponent,
    MatchPreviewComponent,
    NewMatchComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-top-right',
    }),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TooltipModule.forRoot(),
    CollapseModule.forRoot(),
    AccordionModule.forRoot(),
    ModalModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
