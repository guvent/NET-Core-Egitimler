import { RegisterUser } from './../Models/RegisterUser';
import { AlertService } from "./Alert.service";
import { LoginUser } from "./../Models/LoginUser";
import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  constructor(
    private http: HttpClient,
    private router: Router,
    private alert: AlertService
  ) {}
  TOKEN_KEY:string = "token";
  path: string = "https://localhost:44340/api/auth/";
  userToken: any;
  decodedToken: any;
  // jwtHelper: JwtHelper = new JwtHelper();

  login(loginUser: LoginUser) {
    let headers = new HttpHeaders();
    headers.append("Content-Type", "application/json");
    this.http
      .post(this.path + "login", loginUser, { headers: headers })
      .subscribe((data) => {
        this.saveToken(data["tokenString"]);
        this.userToken = data["tokenString"];
        //  this.decodedToken = this.jwtHelper.decodeToken(data["tokenString"]);
        this.alert.success("Kullanıcı giriş yaptı!  " + data["tokenString"]);
        this.router.navigateByUrl("/city");
      });
  }

  register(registerUser:RegisterUser){
    let headers = new HttpHeaders();
    headers.append("Content-Type", "application/json");
    this.http.post(this.path+"register",registerUser, {headers:headers}).subscribe(data=>{});
  }

  saveToken(token) {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  logOut() {
    localStorage.removeItem(this.TOKEN_KEY);
  }

  loggedIn() {
    //return tokenNotExpired(this.TOKEN_KEY);
  }

  getCurrentUser(){
   // return this.jwtHelper.decodeToken(this.token).nameid;
  }
  get token() {
    return localStorage.getItem(this.TOKEN_KEY);
  }
}
