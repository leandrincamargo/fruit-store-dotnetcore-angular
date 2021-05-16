import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApiService, CartService, FruitsService } from './services';

@NgModule({
  imports: [CommonModule],
  providers: [ApiService, FruitsService, CartService],
  declarations: [],
})
export class CoreModule {}
