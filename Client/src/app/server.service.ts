import { Injectable } from '@angular/core';
import { Item } from './item.model';

@Injectable({
  providedIn: 'root'
})
export class ServerService {
  items: Item[];
  constructor() { }
}
