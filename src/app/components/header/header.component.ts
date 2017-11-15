import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Customer } from '../../api/models/customer';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class HeaderComponent implements OnInit {

  localStorage: any;
  customer: Customer;
  loginSubscriber: any;

  constructor(private loginService: LoginService) {
    this.localStorage = localStorage;
    this.customer = JSON.parse(localStorage.getItem('currentUser'));
    this.loginSubscriber = loginService.toggle$.subscribe(data => {
      this.customer = JSON.parse(localStorage.getItem('currentUser'));
    });
  }

  ngOnInit() {
  }

  logout() {
    this.customer = null;
    localStorage.removeItem('currentUser');
  }

}
