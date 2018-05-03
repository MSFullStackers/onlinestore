import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';


import { AppComponent } from './app.component';
import { ItemsComponent } from './items/items.component';
import { MenubarComponent } from './menubar/menubar.component';
import { CarouselComponent } from './carousel/carousel.component';
import { HttpModule } from '@angular/http';
import { ItemsService } from './items.service'; 


@NgModule({
  declarations: [
    AppComponent,
    ItemsComponent,
    MenubarComponent,
    CarouselComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    NgbModule.forRoot()
  ],
  providers: [ItemsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
