import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestOptionsArgs } from '@angular/http';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs/Rx';
import { AppConfig } from '../../app.config';
import { Customer } from '../api/models/customer';

@Injectable()
export class ProductService {

  constructor(private http: Http, private appConfig: AppConfig) { }

  getProductList(): Observable<Array<any>> {
    const currentPath = this.appConfig.apiUrl + '/api/product';

    const requestOptions: RequestOptionsArgs = {
      method: 'GET',
      headers: this.getAuthHeaders()
    };

    return this.http.get(currentPath, requestOptions).map((res: Response) => res.json())
      .catch(error => Observable.throw(error.message || error));
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
