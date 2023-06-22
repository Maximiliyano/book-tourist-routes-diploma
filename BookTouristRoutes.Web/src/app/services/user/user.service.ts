import { Injectable } from '@angular/core';
import { HttpInternalService } from '../http-internal/http-internal.service';
import { User } from '../../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public routePrefix = '/api/user';

  constructor(private httpService: HttpInternalService) { }

  public getUserFromToken() {
    return this.httpService.getFullRequest<User>(`${this.routePrefix}/fromToken`);
  }

  public copyUser({ email, name, id, avatar, password, avatarId, role, salt, createdAt, updatedAt }: User) {
    return {
      email,
      name,
      id,
      avatar,
      password,
      avatarId,
      role,
      salt,
      createdAt,
      updatedAt
    };
  }
}
