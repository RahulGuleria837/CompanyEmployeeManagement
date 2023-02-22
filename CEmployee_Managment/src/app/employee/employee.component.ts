import { EmployeeService } from './../employee.service';
import { Employee } from './../employee';
import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent {
  employeeList:any[]=[];
  newEmployee:Employee= new Employee();
  editEmployee:Employee= new Employee();



  constructor(private employeeService:EmployeeService){}

  ngOnInit():void{
    this.getAll();
  }
  getAll(){
    this.employeeService.getAllEmployee().subscribe(
      (response)=>{
        this.employeeList=response;
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
      );  
  }
saveClick(){
  this.newEmployee.EmployeeId=0;
  this.employeeService.saveEmployee(this.newEmployee).subscribe(
    (response)=>{
      alert('data Saved');
      this.getAll();
      this.newEmployee.EmployeeId="";
      this.newEmployee.EmployeeName="";
      this.newEmployee.PanCardNo="";
      this.newEmployee.EmployeeAddress="";
      this.newEmployee.AccountNo="";
      this.newEmployee.PFNo="";
    },
    (error)=>{
      console.log(error);
    }
  )
}


}