import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Route } from 'src/app/models/route';

@Component({
  selector: 'app-route-card',
  templateUrl: './route-card.component.html',
  styleUrls: ['./route-card.component.css']
})
export class RouteCardComponent implements OnInit, OnDestroy {
  @Input() route: Route;

  public currentPhoto: any;
  public photos = [
    { url: 'https://i.imgur.com/qNjwamd.jpeg', alt: 'Photo 1' },
    { url: 'https://i.imgur.com/4dX9ryU.png', alt: 'Photo 2' },
    { url: 'https://i.imgur.com/KzBNroU.jpeg', alt: 'Photo 3' }
  ];

  private interval: any;

  constructor() {
  }

  public ngOnDestroy(): void {
    this.stopSlideshow();
  }

  public ngOnInit(): void {
    this.startSlideshow();
  }

  public startSlideshow() {
    let index = 0;
    this.currentPhoto = this.photos[index];
    index++;

    this.interval = setInterval(() => {
      if (index === this.photos.length) {
        index = 0;
      }
      this.currentPhoto = this.photos[index];
      index++;
    }, 4000);
  }

  public stopSlideshow() {
    clearInterval(this.interval);
  }

  prevPhoto() {
    const currentIndex = this.photos.indexOf(this.currentPhoto);
    const prevIndex = currentIndex === 0 ? this.photos.length - 1 : currentIndex - 1;
    this.currentPhoto = this.photos[prevIndex];
  }

  nextPhoto() {
    const currentIndex = this.photos.indexOf(this.currentPhoto);
    const nextIndex = currentIndex === this.photos.length - 1 ? 0 : currentIndex + 1;
    this.currentPhoto = this.photos[nextIndex];
  }
}
