import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { environment } from 'src/environments/environment';

import { catchError } from 'rxjs/operators';

@Injectable()
export class ApiService {
  constructor(private http: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  private formatErrors(error: any) {
    return throwError(error.error);
  }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http
      .get(`${environment.api_url}${path}`, { params })
      .pipe(catchError(this.formatErrors));
  }

  post(path: string, body: Object = {}): Observable<any> {
    return this.http
      .post(`${environment.api_url}${path}`, JSON.stringify(body), this.httpOptions)
      .pipe(catchError(this.formatErrors));
  }

  patch(path: string, body: Object = {}): Observable<any> {
    return this.http
      .patch(`${environment.api_url}${path}`, JSON.stringify(body), this.httpOptions)
      .pipe(catchError(this.formatErrors));
  }
}
