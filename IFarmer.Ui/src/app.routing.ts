import { Routes, RouterModule } from "@angular/router";
import { SignupComponent } from "./app/signup/signup.component";
import { ModuleWithProviders } from "@angular/core";
import { AppComponent } from "./app/app.component";
import { ItemsComponent } from "./app/items/items.component";

export const AppRoutes: Routes = [
    { path: '', component: ItemsComponent },
    { path: 'signup', component: SignupComponent }
];

export const ROUTING: ModuleWithProviders = RouterModule.forRoot(AppRoutes);