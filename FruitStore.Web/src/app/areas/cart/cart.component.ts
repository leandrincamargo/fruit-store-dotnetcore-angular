import { Component, OnInit } from '@angular/core';
import { CartItem, CartService } from 'src/app/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent implements OnInit {
  items = this.cartService.getAll();

  constructor(private cartService: CartService) {}

  ngOnInit(): void {}

  async increaseQty(id: string) {
    try {
      await this.cartService.increaseQty(id);
      this.items = this.cartService.getAll();
    } catch (error) {
      alert(error);
    }
  }

  async decreaseQty(id: string) {
    const item = this.items.find((x) => x.id === id);

    if (item.qty === 1) await this.removeAllFromCart(item);
    else await this.cartService.decreaseQty(id);

    this.items = this.cartService.getAll();
  }

  async removeAllFromCart(item: CartItem) {
    await this.cartService.removeAllFromCart(item.id, item.qty);
    alert('Produto removido');
    this.items = this.cartService.getAll();
  }

  async clearCart() {
    await this.cartService.clearCart();
    alert('Carrinho limpo');
    this.items = this.cartService.getAll();
  }

  totalCart(): number {
    return this.items.map((item) => item.unitPrice * item.qty).reduce((prev, next) => prev + next);
  }
}
