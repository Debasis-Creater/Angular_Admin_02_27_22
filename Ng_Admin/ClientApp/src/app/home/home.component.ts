import { Component, OnInit } from '@angular/core';
import { AuthModel } from '../NgCore/Models/authModel.Model';
import { AuthService } from '../NgCore/Services/AppServices/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  auth:AuthModel=new AuthModel();
  constructor(private authService:AuthService) { }
  ngOnInit(): void {
    this.initLogin();

  }

  initLogin(){

    this.auth.Email="dbs@email.com";
    this.auth.UserPassword="dbs@123";
    this.authService.login(this.auth);
  }
}
