import { Company } from './../company';
import { Router } from '@angular/router';
import { LoginService } from './../login.service';
import { Login } from './../login';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component } from '@angular/core';
import {  NavigationEnd } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  LoginForm = new FormGroup({
    userName : new FormControl('',[Validators.required,Validators.minLength(3)]),
    password : new FormControl('',[Validators.required])

    
  });

  LoginUser()
  
    {
      console.warn(this.LoginForm.value)
    }
    get userName()
    {
      return this.LoginForm.get('userName')
    }

    get password()
    {
      return this.LoginForm.get('password')
    }
    login:Login=new Login();
  loginErrorMessage:String=""
  constructor(private loginService:LoginService, private router:Router){}
    
    ngOnIt():void{}
    LoginClick(){
      this.loginService.CheckUser(this.login).subscribe(
        (response)=>{
          this.router.events.subscribe(event => {
            if (event instanceof NavigationEnd) {
              window.location.reload();
            }
          });

          var currentUser = JSON.parse(localStorage.getItem("currentUser")??"");
          console.log(currentUser.token)
          if(currentUser.accessToken== undefined){
            alert("wrong User Name or Password")
            return;
          }
          if(currentUser!=""){
      if(currentUser.role=="Admin"||currentUser.role=="Company" ){
        this.router.navigateByUrl("/company");
      }
      if(currentUser.role=="Employee"){
        this.router.navigateByUrl("/employee");
      }
      
          }
          
        
        },
        (error)=>{
          console.log(error);
          this.loginErrorMessage="log in Failed"
        }
        )
      
    }

  }

  

