import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpResponse } from '@angular/common/http';

@Injectable()
export class ItemsService {

  constructor(private http: HttpClient) { }

  getAllItems(): Observable<String[]> {
    return this.http.get<String[]>('http://localhost:5000/api/values');
  }
}
