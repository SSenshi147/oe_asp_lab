import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { HttpClient } from '@angular/common/http';
import { LoginResponse } from '../login-response';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private _http: HttpClient;
  private _router: Router;

  constructor(http: HttpClient, router: Router) {
    this._http = http;
    this._router = router;
    sessionStorage.clear();
  }

  login(username: HTMLInputElement, password: HTMLInputElement) {
    const actualuser = new User();
    actualuser.username = username.value;
    actualuser.password = password.value;
    this._http.post<LoginResponse>('https://localhost:44398/api/user/login', actualuser).subscribe(response => {
      const token = response.token;
      if (token != null && token.toString().length > 3) {
        sessionStorage.setItem('token', token);
        this._router.navigate(['/tickets']);
      }
    }, error => {
      if (error.status.toString() === '401') {
        window.alert("Invalid credentials!");
      }
      else {
        window.alert("Error!");
      }
    });
  }

  ngOnInit(): void {
  }

}
