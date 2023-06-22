import { Injectable } from '@angular/core';
import { Route } from '../../models/route';

@Injectable({
  providedIn: 'root'
})
export class RouteService {

  constructor() { }

  public getPopularRoutes() {
    return new Route();
  }
}
