import { Data } from "@angular/router";

export interface Route {
  id: number,
  createdAt: Data;
  updatedAt: Data;
  name: string;
  description: string;
  startData: Data;
  endData: Data;
  seats: number;
  bookedSeats: number;
  price: number;
  destination: string
};
