import { AuthService } from './../services/Auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  providers: [AuthService]
})
export class NavComponent implements OnInit {

  loginUser: any = {}
  constructor(
    private auth:AuthService
  ) { }

  ngOnInit() {
  }

  login() {
    this.auth.login(this.loginUser);
  }

  logout() {
    this.auth.logOut();
  }

  get isAuth() {
    return this.auth.loggedIn();
  }

}
