import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestOptionsArgs } from '@angular/http';
import { Order } from '../api/models/order';
import { AppConfig } from '../../app.config';
import { Customer } from '../api/models/customer';
import { Checkout } from '../api/models/checkout';
import { map } from 'rxjs/operators';

@Injectable()
export class OrderService {

  constructor(private http: Http, private appConfig: AppConfig) { }

  checkout(order: Order) {
    const currentPath = this.appConfig.apiUrl + '/api/order/checkout';

    const payload: any = {};
    payload.orderDetails = [];
    order.OrderDetails.forEach(o => {
      // tslint:disable-next-line:no-shadowed-variable
      const order: any = {};
      order.productId = o.Product.Id;
      order.quantity = o.Quantity;
      payload.orderDetails.push(order);
    });

    const requestOptions: RequestOptionsArgs = {
      method: 'POST',
      headers: this.getAuthHeaders()
    };
    return this.http.post(currentPath, JSON.stringify(payload), requestOptions)
      .pipe(map((response: Response) => {
        const checkout: Checkout = response.json();
        return checkout;
      }));
  }

  // private helper methods
  private getAuthHeaders() {
    // create authorization header with jwt token
    const currentUser: Customer = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser && currentUser.Token) {
      const headers = new Headers(
        {
          'Authorization': 'Bearer ' + currentUser.Token,
          'Content-Type': 'application/json'
        }
      );
      return headers;
    }
  }

}
