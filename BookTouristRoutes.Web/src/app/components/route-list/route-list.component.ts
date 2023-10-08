import { Component } from '@angular/core';
import { RouteService } from 'src/app/services/route/route.service';

@Component({
  selector: 'app-route-list',
  templateUrl: './route-list.component.html',
  styleUrls: ['./route-list.component.css']
})
export class RouteListComponent {

  constructor(routeService: RouteService) {
  }
}
