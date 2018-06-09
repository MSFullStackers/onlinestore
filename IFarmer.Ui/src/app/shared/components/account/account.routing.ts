import { ModuleWithProviders } from '@angular/core';
import { RouterModule }        from '@angular/router';

import { RegistrationFormComponent }    from './registration-form/registration-form.component';
import { FacebookLoginComponent }    from './facebook-login/facebook-login.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
  { path: 'register', component: RegistrationFormComponent},
  { path: 'facebook-login', component: FacebookLoginComponent}
]);