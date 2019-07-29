export class Item{
    public name:string;
    public price: number;
    public stock: number;
    public imagePath: string;
    public request: number=0;
    public id;
    
    constructor(name:string, price:number, stock: number, imagePath:string, id=0){
        this.name=name;
        this.price=price;
        this.stock=stock;
        this.imagePath=imagePath;
        this.id=id;
    }
}