import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ItemsService {

  url: string
  constructor(private http: HttpClient) { 
    this.url = 'https://onlineshopapi.azurewebsites.net/api/product'
  }

  GetAllItems() {
    return this.http.get(this.url);
  }

}
