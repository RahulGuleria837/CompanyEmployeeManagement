import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RefreshTokenService {

  constructor(private httpClient:HttpClient) { }
  refreshToken(data:any):Observable<any>
  {
    return this.httpClient.post<any>
    ("https://localhost:7129/api/UserAuthentication/RefreshToken",data);
  }
}
