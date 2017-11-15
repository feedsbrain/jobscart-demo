import { Injectable } from '@angular/core';
import { Customer } from '../api/models/customer';
import { Http, Headers, Response } from '@angular/http';
import { AppConfig } from '../../app.config';
// tslint:disable-next-line:import-blacklist
import { Subject } from 'rxjs';

@Injectable()
export class LoginService {

  private _toggle = new Subject();
  toggle$ = this._toggle.asObservable();

  toggle(login) {
    this._toggle.next(login);
  }

  constructor(private http: Http, private config: AppConfig) { }

  login(username: string, password: string) {
    return this.http.post(this.config.apiUrl + '/api/login/authenticate', { username: username, password: password })
      .map((response: Response) => {
        // login successful if there's a jwt token in the response
        const responseObject = response.json();
        const customer = new Customer();
        customer.Id = responseObject.id;
        customer.UserName = responseObject.userName;
        customer.Token = responseObject.token;
        if (customer && customer.Token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(customer));
        }
      });
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }

}
