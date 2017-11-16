import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from '../../services/login.service';
import { Login } from '../../api/models/login';
import { FormControl, Validators } from '@angular/forms';
import { Message } from 'primeng/primeng';
import { debug } from 'util';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class LoginComponent implements OnInit {

  model: Login = new Login();
  loading = false;
  returnUrl: string;
  msgs: Message[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private loginService: LoginService) { }

  ngOnInit() {
    // reset login status
    this.loginService.logout();

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  login() {
    const _self = this;
    _self.loading = true;
    _self.loginService.login(this.model.UserName, this.model.Password)
      .subscribe(
      data => {
        this.loginService.toggle(data);
        this.router.navigate([this.returnUrl]);
      },
      error => {
        _self.showError('Username or password is incorrect');
        _self.loading = false;
      });
  }

  getErrorMessage(field: string) {
    if (field === 'username') {
      return this.model.UserName && this.model.UserName.trim().length < 1 ? 'You must enter username' : '';
    }
    if (field === 'password') {
      return this.model.Password && this.model.Password.trim().length < 1 ? 'You must enter password' : '';
    }
    return 'Unknown error ...';
  }

  showError(message: string) {
    this.msgs = [];
    this.msgs.push({ severity: 'error', summary: 'Error Message', detail: message });
  }

}
