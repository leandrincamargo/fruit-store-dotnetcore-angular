import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MaterialModule } from './material.module';

import { ToolbarComponent } from './layout';
import { CapitalizeFirstPipe } from './pipes';

@NgModule({
  imports: [CommonModule, MaterialModule, HttpClientModule, RouterModule],
  declarations: [ToolbarComponent, CapitalizeFirstPipe],
  exports: [
    CommonModule,
    MaterialModule,
    HttpClientModule,
    RouterModule,
    ToolbarComponent,
    CapitalizeFirstPipe,
  ],
})
export class SharedModule {}
