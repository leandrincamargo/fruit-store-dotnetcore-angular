import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

import { ApiService } from './api.service';
import { Fruit, Pagination } from '../models';

@Injectable()
export class FruitsService {
  constructor(private apiService: ApiService) {}

  getAll(pageNumber: number = 1, pageSize: number = 10): Promise<Pagination<Fruit>> {
    return this.apiService
      .get(`/fruits?pageNumber=${pageNumber}&pageSize=${pageSize}`)
      .pipe(map((data) => data))
      .toPromise();
  }

  addToCart(id: string): Promise<any> {
    return this.apiService.patch(`/fruits/${id}/addToCart`, null).toPromise();
  }

  removeFromCart(id: string): Promise<any> {
    return this.apiService.patch(`/fruits/${id}/removeFromCart`, null).toPromise();
  }

  removeAllFromCart(id: string, count: Number): Promise<any> {
    return this.apiService.patch(`/fruits/${id}/addItemsToAmount?count=${count}`, null).toPromise();
  }
}
