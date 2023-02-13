import { first } from 'rxjs';
import { FormControl, FormGroup, Validators,  } from '@angular/forms';
import { Component } from '@angular/core';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  loginForm = new FormGroup({
    userName:new FormControl('',[Validators.required ,Validators.minLength(3)]),
    password: new FormControl('',[Validators.required, Validators.pattern('[a-zA-Z]')]),
    confirmPassword: new FormControl(['',Validators.required]),
    role: new FormControl('')
  })


  
loginUser()
{
  console.warn(this.loginForm.value)
}
get userName()
{
  return this.loginForm.get('userName')
}

get password()
{
  return this.loginForm.get('password')
}
get ConfirmPassword()
{
  return this.loginForm.get('confirmPassword')
}
 }


