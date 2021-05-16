import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatPaginatorModule } from '@angular/material/paginator';

import { NgModule } from '@angular/core';

@NgModule({
  imports: [MatButtonModule, MatIconModule, MatToolbarModule, MatCardModule, MatPaginatorModule],
  exports: [MatButtonModule, MatIconModule, MatToolbarModule, MatCardModule, MatPaginatorModule],
})
export class MaterialModule {}
