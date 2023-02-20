import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component } from '@angular/core';

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

  }

  

