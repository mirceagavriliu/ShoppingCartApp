import { Injectable } from '@angular/core';
import { Item } from './item.model';
import { ThrowStmt } from '@angular/compiler';
@Injectable({
  providedIn: 'root'
})
export class CartService {
  items: Item[]=[];
  public totalItems: number=0;
  public totalSum: number=0;
  constructor() { }
  addItem(item:Item){
    this.items.push(item);
    this.totalItems+= +item.stock;
    this.totalSum+= +item.stock*item.price;
  }
  clearCart(){
    this.items=[];
    this.totalItems=0;
    this.totalSum=0;
    return this.items;
  }
  getItems(){
    return this.items;
  }
}
