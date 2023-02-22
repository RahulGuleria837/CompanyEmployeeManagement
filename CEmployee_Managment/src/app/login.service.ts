import { Login } from './login';
import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { MapType } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  currentUsername:any="";

  constructor(private httpClient:HttpClient,private router:Router) { }
  
  CheckUser(login:Login):Observable<any>{
    return this.httpClient.post<any>("https://localhost:7129/api/UserAuthentication/Login",login).pipe(map(u=>{
      if(u){
        this.currentUsername=u.username;
        sessionStorage["currentUser"]=JSON.stringify(u);
      }
      else{
        return u;
      }
    }))

  }
  LogOut()
  {
    this.currentUsername="";
    sessionStorage.removeItem("currentUser");
    this.router.navigateByUrl("/login")
  }
}
