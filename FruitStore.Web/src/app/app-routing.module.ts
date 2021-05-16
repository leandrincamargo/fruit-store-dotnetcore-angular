import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './areas/cart/cart.component';

import { FruitListComponent } from './areas/fruit-list/fruit-list.component';

const routes: Routes = [
  { path: '', component: FruitListComponent },
  { path: 'cart', component: CartComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
