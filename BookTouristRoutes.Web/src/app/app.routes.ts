import { Routes } from "@angular/router";
import { MainPageComponent } from "./components/main-page/main-page.component";
import { AuthGuard } from "./services/auth/auth.guard";
import { UserProfileComponent } from "./components/user-profile/user-profile.component";

export const AppRoutes: Routes = [
  { path: 'profile', component: UserProfileComponent, pathMatch: 'full', canActivate: [AuthGuard] },
  { path: '', component: MainPageComponent, pathMatch: 'full' },
  { path: '**', redirectTo: '' }
];
