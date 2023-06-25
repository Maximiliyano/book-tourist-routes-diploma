import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth/auth.service';
import { EventService } from 'src/app/services/event/event.service';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';
import { AuthDialogService } from 'src/app/services/auth/auth.dialog.service';
import { DialogType } from 'src/app/enums/auth-dialog-type';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
  public dialogType = DialogType;
  public authorizedUser: User | undefined;
  public avatarUser: string;

  private unsubscribe$ = new Subject<void>();

  constructor(
    private authDialogService: AuthDialogService,
    private authService: AuthService,
    private eventService: EventService,
    private userService: UserService,
    private router: Router) { }

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

  public logout() {
    this.authService.logout();
    this.authorizedUser = undefined;
    this.router.navigate(['/']);
  }

  public openAuthDialog(type: DialogType) {
    this.authDialogService.openAuthDialog(type);
  }

  public setUserAvatar() {
    return this.authorizedUser?.avatar ?? "https://i.imgur.com/neN4yfP.png";
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

