import { Injectable } from '@angular/core';
import { HttpInternalService } from './http-internal.service';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public routePrefix = '/api/user';

  constructor(private httpService: HttpInternalService) { }

  public getUserById(id: number) {
    return this.httpService.getFullRequest<User>(`${this.routePrefix}/details/${id}`);
  }
}
