import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { UserRoles } from 'src/app/enums/user-roles';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth/auth.service';
import { EventService } from 'src/app/services/event/event.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit, OnDestroy {
  public user: User;
  public authorizedUser: User | undefined;
  public newUserData: User | undefined;
  public checkUserRole: boolean;
  public editingProfile: boolean;

  private unsubscribe$ = new Subject<void>();

  constructor(
    private userService: UserService,
    private authService: AuthService,
    private eventService: EventService
  ) { }

  public ngOnInit() {
    this.getUser();

    this.eventService.userChangedEvent$
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((user) => (this.authorizedUser = user ? this.userService.copyUser(user) : undefined));
  }

  public ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public setUserAvatar() {
    return this.authorizedUser?.avatar ?? "https://i.imgur.com/neN4yfP.png";
  }

  public setUserRole() {
    if (this.authorizedUser == undefined) {
      return;
    }

    return UserRoles[this.authorizedUser.role];
  }

  public switchEditingProfile() {
    this.editingProfile = !this.editingProfile;
  }

  public isDataChanged(): boolean {
    return false;
  }

  public saveData() {

  }

  private getUser() {
    if (!this.authService.areTokensExist()) {
      return;
    }

    this.authService
      .getUser()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((user) => (this.authorizedUser = this.userService.copyUser(user!)));
  }
}
