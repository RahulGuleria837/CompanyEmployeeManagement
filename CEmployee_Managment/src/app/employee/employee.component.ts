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
  debugger
  console.log(this.newEmployee)
  this.employeeService.saveEmployee(this.newEmployee).subscribe(
    (response)=>{
      alert('data Saved');
      this.getAll();
      this.newEmployee.employeeName="";
      this.newEmployee.employeeAddress="";
      this.newEmployee.employee_Pancard_Number="";
      this.newEmployee.employeeAccount_Number="";
      this.newEmployee.employeePF_Number="";
      this.newEmployee.companyId=0;
    },
    (error)=>{
      console.log(error);
    }
  )
}

editClick(data:number){
  this.editEmployee.employeeName=this.employeeList[data].employeeName;
  this.editEmployee.employee_Pancard_Number=this.employeeList[data].employee_Pancard_Number;
  this.editEmployee.employeeAddress=this.employeeList[data].employeeAddress;
  this.editEmployee.employeeAccount_Number=this.employeeList[data].employeeAccount_Number;
  this.editEmployee.employeePF_Number=this.employeeList[data].employeePF_Number;
}
updateClick(){
  this.employeeService.updateEmployee(this.editEmployee).subscribe(
    (response)=>{
      alert('Data Updated successfully')
      this.getAll;
    },
    (error)=>{
      console.log(error)
    }
    );
}

deleteClick(i:number){
let ans = confirm('want to delete data')
if(!ans) return;
let id = this.employeeList[i].EmployeeId;
this.employeeService.deleteEmployee(id).subscribe(
  (response)=>{
    alert('Data Deleted Successfully')
    this.getAll();
  },
  (error)=>{
    console.log(error)
  }
)
}

}