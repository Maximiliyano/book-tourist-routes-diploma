import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot } from "@angular/router";
import { AuthService } from "./auth.service";

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivateChild, CanActivate {
  constructor(private router: Router, private authService: AuthService) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.checkForActivation(state);
  }

  public canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.checkForActivation(state);
  }

  private checkForActivation(state: RouterStateSnapshot) {
    if (this.authService.areTokensExist()) {
      return true;
    }

    this.router.navigate(['/']);

    return false;
  }
}
