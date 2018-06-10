import { Component } from '@angular/core';
import { NgxPermissionsService } from 'ngx-permissions';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  isCollapsed = false;

  // TODO : POC move to shared also call actual service
  constructor(private permissionsService: NgxPermissionsService,
    private http: HttpClient) {

  }

  ngOnInit(): void {
    // TODO get from API -> Default is public
    const perm = ["public"];
    this.permissionsService.loadPermissions(perm);

  }

}
