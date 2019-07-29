import { Component, OnInit, Input } from '@angular/core';
import { items } from '../items'
import { CartService } from '../cart.service';
import { Item } from '../item.model';
import { CatalogService } from '../catalog.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {
  @Input() items;
  constructor(private cartService: CartService, private catalogService: CatalogService) {
    this.items=this.catalogService.getItems();
   }
  addToCart(item: Item) {
    let addedItem = new Item(item.name, item.price, item.request, item.imagePath);
    if (item.stock >= item.request) {
      this.cartService.addItem(addedItem);
      window.alert('Your product has been added to cart!');
    } else {
      window.alert('Your request is bigger than the available amount');
    }
  }
  ngOnInit() {
  }

}
