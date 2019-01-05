
import { throwError as observableThrowError, Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestOptionsArgs } from '@angular/http';
import { AppConfig } from '../../app.config';
import { Customer } from '../api/models/customer';
import { map } from 'rxjs/operators';

@Injectable()
export class ProductService {

  constructor(private http: Http, private appConfig: AppConfig) { }

  getProductList(): Observable<Array<any>> {
    const currentPath = this.appConfig.apiUrl + '/api/product';

    const requestOptions: RequestOptionsArgs = {
      method: 'GET',
      headers: this.getAuthHeaders()
    };

    return this.http.get(currentPath, requestOptions)
      .pipe(map((response: Response) => {
        return response.json();
      }));
  }

  // private helper methods
  private getAuthHeaders() {
    // create authorization header with jwt token
    const currentUser: Customer = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser && currentUser.Token) {
      const headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.Token });
      return headers;
    }
  }
}
