import { Component } from '@angular/core';
import { LoginService } from './login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'CEmployee_Managment';
  constructor(public loginService:LoginService){}
  LogoutClick(){
    this.loginService.LogOut();
}
}
