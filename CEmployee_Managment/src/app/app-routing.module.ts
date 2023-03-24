import { EmployeelistComponent } from './employeelist/employeelist.component';
import { EmployeeComponent } from './employee/employee.component';
import { CompanyComponent } from './company/company.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from 'src/activegaurd/activegaurd.service';

const routes: Routes = [
  {path:"",redirectTo:"company",pathMatch:"full"},
  {path:"home", component:HomeComponent},
  {path:"login", component:LoginComponent},
  {path:"register", component:RegisterComponent},
  {path:"company",component:CompanyComponent,canActivate:[AuthGuardService]},
  {path:"employee",component:EmployeeComponent},
  {path:"employeelist",component:EmployeelistComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
