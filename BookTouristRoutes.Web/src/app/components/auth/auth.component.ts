import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { takeUntil } from 'rxjs';
import { Subject } from 'rxjs/internal/Subject';
import { DialogType } from 'src/app/enums/auth-dialog-type';
import { UserRoles } from 'src/app/enums/user-roles';
import { AuthService } from 'src/app/services/auth/auth.service';
import { SnackBarService } from 'src/app/services/auth/snack-bar.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit, OnDestroy {
  public loginError: string;
  public userData: any;
  public dialogType = DialogType;

  public userName: string;
  public password: string;
  public email: string;

  public hidePass = true;
  public title: string;

  private unsubscribe$ = new Subject<void>();

  constructor(
    private dialogRef: MatDialogRef<AuthComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private authService: AuthService,
    private snackBarService: SnackBarService
  ) { }

  public ngOnInit() {
    this.title = this.data.dialogType === DialogType.SignIn ? 'Sign In' : 'Sign Up';
  }

  public ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public close() {
    this.dialogRef.close(false);
  }

  public login() {
    this.authService
      .login({
        email: this.email,
        password: this.password
      })
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((response) => this.dialogRef.close(response), (error) => this.snackBarService.showErrorMessage(error));
  }

  public register() {
    this.authService
      .register({
        name: this.userName,
        avatar: null,
        email: this.email,
        role: UserRoles.User,
        password: this.password
      })
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((response) => this.dialogRef.close(response), (error) => this.snackBarService.showErrorMessage(error));
  }
}
