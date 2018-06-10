import { Routes, RouterModule } from "@angular/router";
import { ModuleWithProviders } from "@angular/core";
import { AppComponent } from "./app/app.component";
import { ItemsComponent } from "./app/shared/components/items/items.component";
import { CartComponent } from "./app/shared/components/cart/cart.component";
import { DashboardComponent } from "./app/public/dashboard/dashboard.component";
import { SignupComponent } from "./app/shared/components/account/signup/signup.component";
import { AdminDashboardComponent } from "./app/admin/admin-dashboard/admin-dashboard.component";

export const AppRoutes: Routes = [
    { path: '', component: DashboardComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'cart', component: CartComponent },
    { path: 'admin', component: AdminDashboardComponent }

];

export const ROUTING: ModuleWithProviders = RouterModule.forRoot(AppRoutes);