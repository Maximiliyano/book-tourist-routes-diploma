import { Injectable } from '@angular/core';
import { HttpInternalService } from '../http-internal/http-internal.service';
import { LoginUser } from 'src/app/models/login-user';
import { User } from 'src/app/models/user';
import { EventService } from '../event/event.service';
import { AccessTokenDto } from 'src/app/interfaces/access-token-dto';
import { map } from 'rxjs/internal/operators/map';
import { HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { LoginUserCredentials } from 'src/app/models/logged-user';
import { UserService } from '../user/user.service';
import { of } from 'rxjs/internal/observable/of';
import { RegisterUser } from 'src/app/models/register-user';

@Injectable({ providedIn: 'root' })
export class AuthService {
  public routePrefix = '/api/authorization';
  public user: User | null;

  constructor(
    private httpService: HttpInternalService,
    private eventService: EventService,
    private userService: UserService) { }

  public login(model: LoginUser) {
    return this._handleAuthResponse(this.httpService.postFullRequest(`${this.routePrefix}/login`, model));
  }

  public register(model: RegisterUser) {
    return this._handleAuthResponse(this.httpService.postFullRequest(`/api/register/new`, model));
  }

  public getUser() {
    return this.user
      ? of(this.user)
      : this.userService.getUserFromToken().pipe(
        map((resp) => {
          this.user = resp.body;
          if (this.user != null) {
            this.eventService.userChanged(this.user);
          }
          return this.user;
        })
      );
  }

  public setUser(user: User) {
    this.user = user;
    this.eventService.userChanged(user);
  }

  public logout() {
    this.revokeRefreshToken();
    this.removeTokensFromStorage();
    this.user = null;
    this.eventService.userChanged(this.user!);
  }

  public areTokensExist() {
    return localStorage.getItem('accessToken') && localStorage.getItem('refreshToken');
  }

  public revokeRefreshToken() {
    return this.httpService.postFullRequest<AccessTokenDto>(`${this.routePrefix}/token/revoke`, {
      refreshToken: localStorage.getItem('refreshToken')
    });
  }

  public removeTokensFromStorage() {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
  }

  public refreshTokens() {
    const accessToken = localStorage.getItem('accessToken') || '';
    const refreshToken = localStorage.getItem('refreshToken') || '';

    return this.httpService
      .postFullRequest<AccessTokenDto>(`${this.routePrefix}/token/refresh`, {
        accessToken,
        refreshToken
      })
      .pipe(
        map((resp) => {
          if (resp.body != null) {
            this._setTokens(resp.body);
          }
          return resp.body;
        })
      );
  }


  private _handleAuthResponse(observable: Observable<HttpResponse<LoginUserCredentials>>) {
    return observable.pipe(
      map((resp) => {
        this._setTokens(resp.body!.token);
        this.user = resp.body!.user;
        this.eventService.userChanged(resp.body!.user);
        return resp.body!.user;
      })
    );
  }

  private _setTokens(tokens: AccessTokenDto) {
    if (tokens && tokens.accessToken && tokens.refreshToken) {
      localStorage.setItem('accessToken', JSON.stringify(tokens.accessToken.token));
      localStorage.setItem('refreshToken', JSON.stringify(tokens.refreshToken));
      this.getUser();
    }
  }
}
