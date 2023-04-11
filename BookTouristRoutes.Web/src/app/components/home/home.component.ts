import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, of, takeUntil } from 'rxjs';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
  public userData: User | null;

  private unsubscribe$ = new Subject<void>();

  constructor(
    private userService: UserService,
    private router: Router) {
  }

  public ngOnInit() {
    this.getUser();
  }

  public ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public logout() {
    this.router.navigate(['/']);
  }

  public getUser() { // TODO change hardcode
    this.userService
      .getUserById(6)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (resp) => {
          this.userData = resp.body;
        },
        (error) => (console.log(error))
      );
  }
}
