import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

import { CartService, Fruit, FruitsService, Pagination } from 'src/app/core';

@Component({
  selector: 'app-fruit-list',
  templateUrl: './fruit-list.component.html',
  styleUrls: ['./fruit-list.component.scss'],
})
export class FruitListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  fruitList: Pagination<Fruit> = null;

  constructor(private fruitsService: FruitsService, private cartService: CartService) {}

  async ngOnInit() {
    this.fruitList = await this.fruitsService.getAll();
  }

  async getFruits(event: PageEvent) {
    this.fruitList = await this.fruitsService.getAll(event.pageIndex + 1, event.pageSize);
  }

  async addToCart(id: string) {
    const fruit = this.fruitList.items.find((x) => x.id === id);
    await this.cartService.addToCart(fruit);
    alert('Fruta adicionada ao carrinho');
  }
}
