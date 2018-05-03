import { Component, OnInit } from '@angular/core';
import { Item } from './item';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})


export class ItemsComponent implements OnInit {

  items: Item[] = [{ id: 11, name: 'Mr. Nice' }, { id: 11, name: 'Mr. Great' }];

  public selectedItem: Item;

  constructor(private itemService: ItemsService) {
    itemService.GetAllItems().subscribe(result => {

      console.log(result);
      for (let entry of <string>result) {
        let serviceItem = { id: 11, name: entry };
        this.items.push(<Item>serviceItem);
      }
    }
    );
  }

  ngOnInit() {
  }

  onSelect(_item: Item): void {
    this.selectedItem = _item;
  }

}
