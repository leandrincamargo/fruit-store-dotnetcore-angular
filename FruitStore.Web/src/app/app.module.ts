import { NgModule, LOCALE_ID, DEFAULT_CURRENCY_CODE } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';

import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core';

import { AppComponent } from './app.component';
import { FruitListComponent, CartComponent } from './areas';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { getPortuguesPaginatorIntl } from './portugues-paginator-intl';

registerLocaleData(localePt);

@NgModule({
  imports: [BrowserModule, CoreModule, SharedModule, AppRoutingModule, BrowserAnimationsModule],
  declarations: [AppComponent, FruitListComponent, CartComponent],
  providers: [
    { provide: LOCALE_ID, useValue: 'pt-BR' },
    { provide: DEFAULT_CURRENCY_CODE, useValue: 'BRL' },
    { provide: MatPaginatorIntl, useValue: getPortuguesPaginatorIntl() },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
