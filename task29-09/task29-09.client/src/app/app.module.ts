import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './ayah/nav-bar/nav-bar.component';
import { HomeComponent } from './ayah/home/home.component';
import { ServiceComponent } from './ayah/service/service.component';
import { RouterModule } from '@angular/router';
import { SubServiceComponent } from './ayah/sub-service/sub-service.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    ServiceComponent,
    SubServiceComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "service", component: ServiceComponent },
      { path: "subService/:id", component: SubServiceComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
