import { JsonPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'CEmployee_Managment';
  logoutuser:boolean=true;
  constructor(public loginService:LoginService) {}
  ngOnInit(){
    var currentUser= JSON.parse(localStorage.getItem("currentUser")?? "");
    if(currentUser!=""){
      this.logoutuser=false;
    }
  }
  
  LogoutClick(){


    this.loginService.LogOut();
}

}
