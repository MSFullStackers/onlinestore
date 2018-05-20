import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ItemsComponent } from './items/items.component';
import { MenubarComponent } from './menubar/menubar.component';
import { MarkettingComponent } from './marketting/marketting.component'; 

import { ItemsService } from './items.service';


@NgModule({
  declarations: [
    AppComponent,
    ItemsComponent,
    MenubarComponent,
    MarkettingComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    NgbModule.forRoot()
  ],
  providers: [ItemsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
