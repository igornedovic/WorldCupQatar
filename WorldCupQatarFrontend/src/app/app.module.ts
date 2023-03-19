import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { ManageGroupsTeamsComponent } from './manage-groups-teams/manage-groups-teams.component';
import { ManageMatchesComponent } from './manage-matches/manage-matches.component';

@NgModule({
  declarations: [AppComponent, HeaderComponent, HomeComponent, ManageGroupsTeamsComponent, ManageMatchesComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-top-right',
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
