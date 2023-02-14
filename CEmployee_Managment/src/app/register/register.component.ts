import { first } from 'rxjs';
import { FormControl, FormGroup, Validators,  AbstractControl } from '@angular/forms';
import { Component } from '@angular/core';
//'[a-zA-Z@]')

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  loginForm = new FormGroup({
    userName:new FormControl('',[Validators.required ,Validators.minLength(3)]),
    password:new FormControl('',[Validators.required, Validators.pattern('[a-zA-z]+$')]),
    confirmPassword:new FormControl('',[Validators.required]),
    role:new FormControl('',[Validators.required,Validators.minLength(3)])
  },);

  

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
get confirmPassword()
{
  return this.loginForm.get('confirmPassword')
}
get role()
{
  return this.loginForm.get('role')
}


 }
 //AbstractControl will provide all control  value and all child class control value
 function matchPassword(control:AbstractControl) {
return control.get('password')?.value === control.get('confirmPassword')?.value?null:{'mismatch':true};
 }
  


