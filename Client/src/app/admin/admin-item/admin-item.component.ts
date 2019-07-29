import { Component, OnInit, Input } from '@angular/core';
import { items } from 'src/app/items';
import { Item } from 'src/app/item.model';
import { AdminService } from 'src/app/admin.service';

@Component({
  selector: 'app-admin-item',
  templateUrl: './admin-item.component.html',
  styleUrls: ['./admin-item.component.css']
})
export class AdminItemComponent implements OnInit {

  @Input() item:Item;
  @Input() name: string;
  @Input() amount: number;
  @Input() price: number;
  @Input() imagePath: string;
  update: Boolean= false;
  constructor(private admin: AdminService) { }

  ngOnInit() {
    this.name=this.item.name;
    this.amount=this.item.stock;
    this.price=this.item.price;
    this.imagePath=this.item.imagePath;
  }
  onDelete(id){
      this.admin.deleteItem(id);
     
  }
  onUpdate(){
    this.update= !this.update;
  }

  onSubmitUpdate(id){
    this.admin.updateItem(id,this.name,this.price,this.amount,this.imagePath);
  }

}
