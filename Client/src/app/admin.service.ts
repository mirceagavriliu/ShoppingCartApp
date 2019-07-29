import { Injectable } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Item } from './item.model';
import { map } from 'rxjs/operators';
import { items } from './items';
import { ServerService } from './server.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
 // public itemsFromServer: Item[];
  constructor(private http: HttpClient, private data: ServerService) { }

  createAndStoreItem(name: string, price: number, stock: number, imagePath: string) {

    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
    var body = JSON.stringify({ Name: name, Price: price, Stock: stock, ImagePath: imagePath });
    this.http.post('https://localhost:44397/api/cars', body, { headers }).subscribe(( )=> { 
      this.gettingResources().subscribe(()=>{
      
      });
    });
  }

  gettingResources() {
    var obs=this.http.get<Item[]>('https://localhost:44397/api/cars');
    obs.subscribe(cars => {
      //this.itemsFromServer=cars;
      this.data.items=cars;
    })
    return obs;

  }
  getItems() {
    return this.data.items;
  }
  deleteItem(id) {
    var obs=this.http.delete(`https://localhost:44397/api/cars/${id}`).subscribe(()=>{this.gettingResources().subscribe(()=>{
      
    });});
    
    
  }

  updateItem(id,name: string, price: number, stock: number, imagePath: string){
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
    var body = JSON.stringify({ Name: name, Price: price, Stock: stock, ImagePath: imagePath });
    console.log(body);
    var obs = this.http.put(`https://localhost:44397/api/cars/${id}`,body, {headers}).subscribe(()=> this.gettingResources().subscribe(()=>{}));

  }
}
