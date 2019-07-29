import { Component, OnInit, Input } from '@angular/core';
import { AdminService } from '../admin.service';
import { Item } from '../item.model';
import { ServerService } from '../server.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {


  @Input() name: string;
  @Input() amount: number;
  @Input() price: number;
  @Input() imagePath: string;

  existingItems: Item[] = [];

  constructor(private admin: AdminService, private data: ServerService) { }
  onClick() {

    this.admin.createAndStoreItem(this.name, this.price, this.amount, this.imagePath);
    this.name = "";
    this.price = 0;
    this.amount = 0;
    this.imagePath = "";
    this.admin.gettingResources();
    //this.existingItems = this.admin.itemsFromServer;
    this.admin.gettingResources().subscribe(
      (_) => {
     //   this.existingItems = this.admin.itemsFromServer;
      }
    );
  
    
    
  }
  ngOnInit() {
    this.admin.gettingResources().subscribe(
      (_) => {
      //  this.existingItems = this.admin.itemsFromServer;
        }
    );
    
  }

}
