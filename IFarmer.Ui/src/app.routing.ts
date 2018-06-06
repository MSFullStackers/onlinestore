import { Routes, RouterModule } from "@angular/router";
import { SignupComponent } from "./app/signup/signup.component";
import { ModuleWithProviders } from "@angular/core";
import { AppComponent } from "./app/app.component";
import { ItemsComponent } from "./app/items/items.component";
import { CartComponent } from "./app/cart/cart.component";

export const AppRoutes: Routes = [
    { path: '', component: ItemsComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'cart', component: CartComponent }
];

export const ROUTING: ModuleWithProviders = RouterModule.forRoot(AppRoutes);