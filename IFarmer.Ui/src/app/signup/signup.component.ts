import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs';
import { Credentials } from '../shared/models/credentials.interface';
import { UserService } from '../shared/services/user.service';

@Component({
    selector: 'app-signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

    private subscription: Subscription;

    brandNew: boolean;
    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;
    credentials: Credentials = { email: '', password: '' };

    constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) { }
    
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
                            this.router.navigate(['/cart']);
                        }
                    },
                    error => this.errors = error);
        }
    }

}
