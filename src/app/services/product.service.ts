import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestOptionsArgs } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class ProductService {

  private apiPath:string = 'http://localhost:5000';

  constructor(private http: Http) { }

  getProductList(): Observable<Array<any>> {
    //let currentUser = localStorage.getItem('currentUser').toString()
    let currentPath = this.apiPath + "/api/product";
    //let headerParams = new Headers({});
    //headerParams.set('customerId', currentUser)

    let requestOptions: RequestOptionsArgs = {
      method: 'GET',
      //headers: headerParams
    };

    return this.http.get(currentPath, requestOptions).map((res: Response) => res.json())
      .catch(error => Observable.throw(error.message || error));
  }

}
