import { Injectable, HttpClient } from '@angular/core';
import{Observable}from 'rxjs'
import { HttpClient } from '@angular/common/http';
import { Register } from './register';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor( private HttpClient:HttpClient) { }

  SaveUser(newUser:Register):Observable<Register>
  {
    return this.HttpClient.post<Register>
    ("https://localhost:44361/api/Employee",newUser)
  }
  Savepassword(savepassword:Register):Observable<Register>
  {
    return this.HttpClient.post<Register>
    ("",savepassword)
  }
     SaveRole(saveRoles:Register):Observable<Register>
     {
      return this.HttpClient.post<Register>
      ("",saveRoles)
     }
}
