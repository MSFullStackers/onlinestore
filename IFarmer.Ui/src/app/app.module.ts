import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ItemsComponent } from './items/items.component';
import { MenubarComponent } from './menubar/menubar.component';
import { MarkettingComponent } from './marketting/marketting.component'; 
import { CartComponent } from './cart/cart.component';
import { SignupComponent } from './signup/signup.component';
import { MarkettingFeatureComponent } from './marketting-feature/marketting-feature.component';

import { ItemsService } from './items.service';
import { UserService } from './shared/services/user.service'
import { ConfigService } from './shared/utils/config.service';

import { ROUTING } from '../app.routing';


@NgModule({
  declarations: [
    AppComponent,
    ItemsComponent,
    MenubarComponent,
    MarkettingComponent,
    SignupComponent,
    MarkettingFeatureComponent,
    CartComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    NgbModule.forRoot(),
    ROUTING
  ],
  providers: [ItemsService, UserService, ConfigService],
  bootstrap: [AppComponent]
}) 
export class AppModule { 

}
