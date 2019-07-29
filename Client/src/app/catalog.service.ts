import { Injectable } from '@angular/core';
import { Item } from './item.model'
import { items } from './items';
@Injectable({
  providedIn: 'root'
})
export class CatalogService {
  items:Item[]=items;
  constructor() { }
  getItems(){
    return items;
  }
  submitChanges(){
    items.forEach(element => { element.stock-= +element.request;
    });
    this.clearRequests();
  }
  clearRequests(){
    items.forEach(item=>{
      item.request=0;
    });
  }
}
