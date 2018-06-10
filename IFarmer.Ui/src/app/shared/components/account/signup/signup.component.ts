import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { NgxPermissionsService } from 'ngx-permissions';

import { Credentials } from '../../../../shared/models/credentials.interface';
import { UserService } from '../../../../shared/services/user.service';

@Component({
    selector: 'app-signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;
    credentials: Credentials = { email: '', password: '' };

    constructor(private userService: UserService, private router: Router, 
        private activatedRoute: ActivatedRoute, private permissionsService: NgxPermissionsService) { }

    ngOnInit() { }

    login({ value, valid }: { value: Credentials, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';
        if (valid) {
            this.userService.login(value.email, value.password)
                .finally(() => this.isRequesting = false)
                .subscribe(
                    result => {
                        if (result) {
                            this.router.navigate(['/admin']);
                        }
                    },
                    error => {
                        this.errors = error;
                        // https://github.com/systemjs/systemjs/issues/1675
                        // known issue for observable 
                        if (error.name == 'TypeError') {
                            this.router.navigate(['/admin']);
                        }

                        const perm = ["admin"];
                        this.permissionsService.loadPermissions(perm);
                    });
        }
    }

}
