import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs/internal/Subject';
import { takeUntil } from 'rxjs/internal/operators/takeUntil';
import { Destination } from 'src/app/models/destination';
import { Route } from 'src/app/models/route';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth/auth.service';
import { BookingService } from 'src/app/services/booking/booking.service';
import { EventService } from 'src/app/services/event/event.service';
import { RouteService } from 'src/app/services/route/route.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit, OnDestroy {
  public currentUser: User | unknown;
  public userRole: string;
  public popularRoutes: Route[];
  public featuredDestinations: Destination[];

  private unsubscribe$ = new Subject<void>();

  constructor(
    private userService: UserService,
    private routeService: RouteService,
    private bookingService: BookingService,
    private eventService: EventService,
    private authService: AuthService) { }

  public ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public ngOnInit() {
    this.getUser();

    this.eventService.userChangedEvent$.pipe(takeUntil(this.unsubscribe$)).subscribe((user) => {
      this.currentUser = user;
    });
  }

  private getUser() {
    this.authService
      .getUser()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((user) => (this.currentUser = user));
  }
}
