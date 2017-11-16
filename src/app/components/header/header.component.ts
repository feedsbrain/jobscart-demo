import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Customer } from '../../api/models/customer';
import { LoginService } from '../../services/login.service';
import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class HeaderComponent implements OnInit, OnDestroy {

  localStorage: any;
  customer: Customer;
  loginSubscriber: any;

  constructor(private loginService: LoginService) {
    this.localStorage = localStorage;
    this.loginSubscriber = loginService.toggle$.subscribe(data => {
      this.customer = JSON.parse(localStorage.getItem('currentUser'));
    });
  }

  ngOnInit() {
    this.customer = JSON.parse(localStorage.getItem('currentUser'));
  }

  ngOnDestroy(): void {
    if (this.loginSubscriber && this.loginSubscriber != null) {
      this.loginSubscriber.unsubscribe();
    }
  }

  logout() {
    this.customer = null;
    localStorage.removeItem('currentUser');
  }

}
