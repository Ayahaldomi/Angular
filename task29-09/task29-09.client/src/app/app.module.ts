import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, NgForm } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './ayah/nav-bar/nav-bar.component';
import { HomeComponent } from './ayah/home/home.component';
import { ServiceComponent } from './ayah/service/service.component';
import { RouterModule } from '@angular/router';
import { SubServiceComponent } from './ayah/sub-service/sub-service.component';
import { SubscribrionComponent } from './ayah/subscribrion/subscribrion.component';
import { SubservicedetailsComponent } from './ayah/subservicedetails/subservicedetails.component';
import { LectureComponent } from './ayah/lecture/lecture.component';
import { RegistrationComponent } from './ayah/registration/registration.component';
import { LogInComponent } from './ayah/log-in/log-in.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    ServiceComponent,
    SubServiceComponent,
    SubscribrionComponent,
    SubservicedetailsComponent,
    LectureComponent,
    RegistrationComponent,
    LogInComponent
  ],
  imports: [
    FormsModule,
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "service", component: ServiceComponent },
      { path: "subService/:id", component: SubServiceComponent },
      { path: "lecture", component: LectureComponent },
      { path: "subscribtion", component: SubscribrionComponent },
      { path: "details/:id", component: SubservicedetailsComponent },
      { path: "Registration", component: RegistrationComponent },
      { path: "LogIn", component: LogInComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
