import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthModel } from '../../Models/authModel.Model';
import { CookieService } from '../AppCookie/cookie.service';
import { tap, catchError } from "rxjs/operators";
@Injectable({
  providedIn: 'root'
})
export class AuthService {
baseUrl:string="http://localhost:26747/webapi";
  constructor(private http:HttpClient,private cookieService:CookieService) { }

  login(cred:AuthModel){
    this.http
    .post<any>(`${this.baseUrl}/Auth/login`, cred).subscribe(res=>{
      if(res.isSuccess){
        this.cookieService.setCookie("currentUser",JSON.stringify(res),1); 
      }
    })
  }
}
