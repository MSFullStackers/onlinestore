import { Component, OnInit } from '@angular/core';
import { Item } from './item';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})


export class ItemsComponent implements OnInit {

  items: Item[] = [
    { id: 11, name: 'Mr. Nice' },
    { id: 12, name: 'Narco' },
    { id: 13, name: 'Bombasto' },
    { id: 14, name: 'Celeritas' },
    { id: 15, name: 'Magneta' },
    { id: 16, name: 'RubberMan' }
  ];
 
  public selectedItem : Item;

  // constructor(private itemService: ItemsService) { 
  //   itemService.getAllItems().subscribe( res => { 
  //     for (let entry of res) {
  //         let serviceItem  = { id: 11, name: entry };          
  //         this.items.push( <Item> serviceItem );
  //     }}
  //   );  
  // }

  constructor(){

  }

  ngOnInit() { 
  }
  
  onSelect(_item: Item): void {
    this.selectedItem = _item;
  }
  
}
 