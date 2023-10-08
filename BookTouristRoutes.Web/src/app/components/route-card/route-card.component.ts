import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { WorldPart } from 'src/app/enums/world-parts';
import { RouteService } from 'src/app/services/route/route.service';

@Component({
  selector: 'app-route-card',
  templateUrl: './route-card.component.html',
  styleUrls: ['./route-card.component.css']
})
export class RouteCardComponent implements OnInit, OnDestroy {
  @Input() title: string;
  @Input() description: string;
  @Input() worldPart: WorldPart;
  @Input() photos: [{ url: '', alt: '' }]

  public currentPhoto: any;
  public photos1 = [
    { url: 'https://i.imgur.com/qNjwamd.jpeg', alt: 'Photo 1' },
    { url: 'https://i.imgur.com/4dX9ryU.png', alt: 'Photo 2' },
    { url: 'https://i.imgur.com/KzBNroU.jpeg', alt: 'Photo 3' }
  ];

  constructor(routeService: RouteService) {
  }

  public ngOnDestroy(): void {
  }

  public ngOnInit(): void {
    this.nextPhoto()
  }

  public getPopularRoutes(worldPart: WorldPart) {

  }

  public prevPhoto() {
    const currentIndex = this.photos.indexOf(this.currentPhoto);
    const prevIndex = currentIndex === 0 ? this.photos.length - 1 : currentIndex - 1;
    this.currentPhoto = this.photos[prevIndex];
  }

  public nextPhoto() {
    const currentIndex = this.photos.indexOf(this.currentPhoto);
    const nextIndex = currentIndex === this.photos.length - 1 ? 0 : currentIndex + 1;
    this.currentPhoto = this.photos[nextIndex];
  }
}
