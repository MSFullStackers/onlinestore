import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ItemsService {

  url: string
  constructor(private http: HttpClient) { 
    this.url = 'http://localhost:5000/api/values'
  }

  GetAllItems() {
    return this.http.get(this.url);
  }

}
