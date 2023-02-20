import { Injectable, } from '@angular/core';
import{Observable}from 'rxjs'
import { HttpClient } from '@angular/common/http';
import { Register } from './register';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor( private httpClient:HttpClient) { }

  SaveUser(newUser:Register):Observable<Register>
  {
    return this.httpClient.post<Register>
    ("https://localhost:7129/api/UserAuthentication/Register",newUser);
  }
}
