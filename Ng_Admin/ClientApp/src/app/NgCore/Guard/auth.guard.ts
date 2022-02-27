import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import {JwtHelperService} from '@auth0/angular-jwt';
import { CookieService } from '../Services/AppCookie/cookie.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private cookieService:CookieService){}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let cookiedata = this.cookieService.getCookie("currentUser");
    let parseData = JSON.parse(cookiedata);
    let token = parseData["token"];
    if (token != null) {
      let helper = new JwtHelperService();
      let decoded = helper.decodeToken(token);
      if (decoded["UserId"] != null) {
        if (decoded["UserId"] > 0) {
          return true;
        } else {
          return false;
        }
      } else {
        return false;
      }
    }
    return true;
  }
  
}
