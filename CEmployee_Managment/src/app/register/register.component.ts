import { Register } from './../register';
import { first } from 'rxjs';
import { FormControl, FormGroup, Validators,  AbstractControl } from '@angular/forms';
import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  RegisterForm = new FormGroup({
    userName:new FormControl('',[Validators.required ,Validators.minLength(3)]),
    password:new FormControl('',[Validators.required, Validators.pattern('[a-zA-Z]+$')]),
    confirmPassword:new FormControl('',[Validators.required]),
    role:new FormControl('',[Validators.required,Validators.minLength(3)])
  });

  

RegisterUser()
{
  console.warn(this.RegisterForm.value)
}
get userName()
{
  return this.RegisterForm.get('userName')
}

get password()
{
  return this.RegisterForm.get('password')
}
get confirmPassword()
{
  return this.RegisterForm.get('confirmPassword')
}
get role()
{
  return this.RegisterForm.get('role')
}


 }
 //AbstractControl will provide all control  value and all child class control value
 function matchPassword(control:AbstractControl) {
return control.get('password')?.value === control.get('confirmPassword')?.value?null:{'mismatch':true};
 }
  


