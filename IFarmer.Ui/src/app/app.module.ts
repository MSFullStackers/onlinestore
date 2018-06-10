import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { MenubarComponent } from './shared/components/menubar/menubar.component';
import { CartComponent } from './shared/components/cart/cart.component';
import { SignupComponent } from './shared/components/account/signup/signup.component'; 

import { ItemsService } from './shared/services/items.service';
import { UserService } from './shared/services/user.service'
import { ConfigService } from './shared/utils/config.service';

import { ROUTING } from '../app.routing';
import { DashboardComponent } from './public/dashboard/dashboard.component';
import { PageNotfoundComponent } from './core/page-notfound/page-notfound.component';
import { ItemsComponent } from './shared/components/items/items.component';
import { NgxPermissionsModule } from 'ngx-permissions';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    ItemsComponent,
    MenubarComponent,
    SignupComponent,
    CartComponent,
    DashboardComponent,
    PageNotfoundComponent,
    AdminDashboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    NgbModule.forRoot(),
    NgxPermissionsModule.forRoot(),
    ROUTING
  ],
  providers: [ItemsService, UserService, ConfigService],
  bootstrap: [AppComponent]
}) 
export class AppModule { 

}
