import { Component, OnInit } from '@angular/core';
import {Http} from '@angular/http';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit {

  urls = ["http://placehold.it/900x300","http://placehold.it/900x300"];
  constructor() { }

  ngOnInit() {
  }
  
  startCarousel(urls: string[]) {
    this.urls = urls;     
  }

  isActive(url: string) {
      return url === this.urls[0];
  }
}
