import { Component, Input } from '@angular/core';
import { Destination } from 'src/app/models/destination';

@Component({
  selector: 'app-destination-card',
  templateUrl: './destination-card.component.html',
  styleUrls: ['./destination-card.component.css']
})
export class DestinationCardComponent {
  @Input() destination: Destination;
}
