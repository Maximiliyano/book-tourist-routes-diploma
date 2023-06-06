import { Injectable, OnDestroy } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { Subject } from "rxjs/internal/Subject";
import { AuthComponent } from "src/app/components/auth/auth.component";
import { DialogType } from "src/app/enums/auth-dialog-type";
import { User } from "src/app/models/user";
import { AuthService } from "./auth.service";
import { takeUntil } from "rxjs/internal/operators/takeUntil";
import { SnackBarService } from "./snack-bar.service";


@Injectable({ providedIn: 'root' })
export class AuthDialogService implements OnDestroy {
  private unsubscribe$ = new Subject<void>();

  public constructor(
    private dialog: MatDialog,
    private authService: AuthService,
    private snackBarService: SnackBarService) { }

  public openAuthDialog(type: DialogType) {
    const dialog = this.dialog.open(AuthComponent, {
      data: { dialogType: type },
      minWidth: 300,
      autoFocus: true,
      backdropClass: 'dialog-backdrop'
    });

    dialog
      .afterClosed()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((result: User) => {
        if (result) {
          this.authService.setUser(result);
          this.snackBarService.showUsualMessage('You successful logged!');
        }
      });
  }

  public ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}

