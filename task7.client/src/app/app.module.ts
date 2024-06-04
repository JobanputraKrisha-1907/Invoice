import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Client/Pages/login.component';
import { Router, RouterLink, RouterModule } from '@angular/router';
import { ClientComponent } from './Client/client.component';
import { FormsModule } from '@angular/forms';
import { DashboardComponent } from './Client/Pages/dashboard.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { InvoiceComponent } from './Client/Pages/invoice.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientComponent,
    LoginComponent,
    DashboardComponent,
    InvoiceComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, RouterModule, FormsModule, NgbModule, CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
