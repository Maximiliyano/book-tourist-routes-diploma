import { Injectable } from '@angular/core';
import { Route } from '../../models/route';
import { HttpInternalService } from '../http-internal/http-internal.service';

@Injectable({
  providedIn: 'root'
})
export class RouteService {
  public routePrefix = '/api/route';

  constructor(private httpService: HttpInternalService) { }

  public getPopularRoutes() {
    return this.httpService.getFullRequest(`${this.routePrefix}/all`);
  }
}
