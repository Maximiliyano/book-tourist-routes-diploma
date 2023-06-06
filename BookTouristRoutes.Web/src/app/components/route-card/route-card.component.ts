import { Component, Input } from '@angular/core';
import { Route } from 'src/app/models/route';

@Component({
  selector: 'app-route-card',
  templateUrl: './route-card.component.html',
  styleUrls: ['./route-card.component.css']
})
export class RouteCardComponent {
  @Input() route: Route;
}
