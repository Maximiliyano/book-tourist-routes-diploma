import { Injectable } from '@angular/core';
import { HttpInternalService } from '../http-internal/http-internal.service';
import { WorldPart } from 'src/app/enums/world-parts';

@Injectable({
  providedIn: 'root'
})
export class RouteService {
  public routePrefix = '/api/route';

  constructor(private httpService: HttpInternalService) { }

  public getPopularRoutes(worldPart: WorldPart | null) {
    const queryParams = worldPart ? { worldPart: worldPart } : null;
    return this.httpService.getFullRequest(`${this.routePrefix}/popular-routes`, { params: queryParams });
  }
}
