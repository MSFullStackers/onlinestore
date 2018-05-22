import { Component, OnInit } from '@angular/core';
import { Item } from './item';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html'
})


export class ItemsComponent implements OnInit {

  items:any

  public selectedItem: Item;

  constructor(private itemService: ItemsService) {
    itemService.GetAllItems().subscribe(result => {
      this.items = result;
    }
    );
  }

  ngOnInit() {
  }

  onSelect(_item: Item): void {
    this.selectedItem = _item;
  }

}
