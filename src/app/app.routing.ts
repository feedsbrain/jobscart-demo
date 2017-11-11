import { Routes } from "@angular/router";
import { AuthGuard } from "./guards/auth.guard";
import { ListingComponent } from "./components/listing/listing.component";
import { LoginComponent } from "./components/login/login.component";
import { ConfirmComponent } from "./components/confirm/confirm.component";

export const AppRoutes: Routes = [
    { path: '', component: ListingComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'confirm', component: ConfirmComponent },
    { path: 'HOME', redirectTo: '' }
];