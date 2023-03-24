import { RefreshTokenService } from './refresh-token.service';
import { Router } from '@angular/router';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JwtInterceptorService implements HttpInterceptor {

  constructor(private refreshTokenService:RefreshTokenService,private router:Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var currentUser = {token:""};
    var getcurrentUser = localStorage.getItem('data');
    if(getcurrentUser !=null){
      currentUser.token = JSON.parse(getcurrentUser).token;
      
    }
    req = req.clone({
      setHeaders:{

        Authorization:"Bearer "+currentUser.token
      }
    
    });
    

   debugger

    return next.handle(req).pipe( tap(() => {},
      (err: any) => {
      if(err.status === 401 || err.statusText === "Unauthorized"){
        // here we will call the refresh token and update the token value
        if(localStorage.getItem('data') == null){
          localStorage.removeItem('data');
          this.router.navigateByUrl("/login");

        }
        const dataInUserPc = JSON.parse(localStorage.getItem('currentUser')??"");
        this.refreshTokenService.refreshToken({Token:dataInUserPc.token,RefreshToken:dataInUserPc.refreshToken}).subscribe((data:any)=>{
          dataInUserPc.token = data.token;
          dataInUserPc.refreshToken = data.refreshToken;
          localStorage.setItem('data',JSON.stringify(dataInUserPc));
          console.log(req);
          location.reload();
          return;
        },(err:any)=>{
          if(err.status == 401){
            localStorage.removeItem('data');
            this.router.navigateByUrl("/login");
          }
      })
      }
    }));

    

  }
}