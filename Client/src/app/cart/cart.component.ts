import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service';
import { CatalogService } from '../catalog.service';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  items;
  
  constructor(private cartService: CartService, private catalogService: CatalogService) { 
    this.items=cartService.getItems();
  }

  ngOnInit() {
  }

  onClear(){
    this.items=this.cartService.clearCart();
    this.catalogService.clearRequests();
  }
  onCheckOut(){
    this.catalogService.submitChanges();
    this.items=this.cartService.clearCart();
  }

}
