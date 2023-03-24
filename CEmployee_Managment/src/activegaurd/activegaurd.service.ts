import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router, UrlTree } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {
  constructor(private router:Router) { }
canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
  

           // here we will check only if user is not login then we will return the user to the login page.  
           var data = JSON.parse(localStorage.getItem('currentUser')??"");
           if((! localStorage.getItem('currentUser')===null) && data.accessToken  === ''){
                     this.router.navigateByUrl("/login");
                     return false;
             }
              console.log(typeof(data.role));
             console.log(data.role);

              if (data.role === "Admin" || data.role === "Company")
              {
            return true
          }
          return true; 
            
}



}
