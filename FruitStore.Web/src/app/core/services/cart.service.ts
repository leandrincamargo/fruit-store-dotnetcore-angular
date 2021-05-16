import { Injectable } from '@angular/core';

import { CartItem, Fruit } from '../models';
import { FruitsService } from './fruits.service';

@Injectable()
export class CartService {
  private items: CartItem[] = [];

  constructor(private fruitsService: FruitsService) {}

  getAll(): CartItem[] {
    return this.items;
  }

  async addToCart(fruit: Fruit): Promise<void> {
    await this.fruitsService.addToCart(fruit.id);

    let itemCart = this.items.find((x) => x.id === fruit.id);
    if (itemCart) {
      itemCart.qty++;
      return;
    }

    const item = this.mountCartItem(fruit);
    this.items.push(item);
  }

  async increaseQty(id: string): Promise<void> {
    await this.fruitsService.addToCart(id);

    const item = this.items.find((x) => x.id === id);
    item.qty++;
  }

  async decreaseQty(id: string): Promise<void> {
    await this.fruitsService.removeFromCart(id);

    const item = this.items.find((x) => x.id === id);
    item.qty--;
  }

  async removeAllFromCart(id: string, count: Number): Promise<void> {
    await this.fruitsService.removeAllFromCart(id, count);

    this.items = this.items.filter((x) => x.id !== id);
  }

  async clearCart() {
    while (this.items.length > 0) {
      const item = this.items[0];
      await this.removeAllFromCart(item.id, item.qty);
    }
  }

  private mountCartItem(fruit: Fruit): CartItem {
    return {
      id: fruit.id,
      name: fruit.name,
      qty: 1,
      unitPrice: fruit.price,
    };
  }
}
