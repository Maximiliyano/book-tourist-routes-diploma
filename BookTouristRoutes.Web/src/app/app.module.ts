import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutes } from './app.routes';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MaterialComponentsModule } from './components/common/material-components.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MainPageComponent } from './components/main-page/main-page.component';
import { RouteCardComponent } from './components/route-card/route-card.component';
import { AuthComponent } from './components/auth/auth.component';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { RouteListComponent } from './components/route-list/route-list.component';
import { ContinentsCardComponent } from './components/continents-card/continents-card.component';
import { MapRoutesComponent } from './components/map-routes/map-routes.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MainPageComponent,
    RouteCardComponent,
    AuthComponent,
    UserProfileComponent,
    RouteListComponent,
    ContinentsCardComponent,
    MapRoutesComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialComponentsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(AppRoutes),
    MatButtonModule,
    MatSlideToggleModule
  ],
  exports: [
    MaterialComponentsModule,
    MainPageComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
