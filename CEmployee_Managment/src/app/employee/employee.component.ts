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
  //alert(this.newEmployee.employeeName)
  debugger
  console.log("This is new Employee",this.newEmployee)
  this.newEmployee.employeeId=0;
  this.employeeService.saveEmployee(this.newEmployee).subscribe(
    (response)=>{
      alert('data Saved');
      this.getAll()
      this.newEmployee.employeeName=""
      this.newEmployee.employeeAddress=""
      this.newEmployee.employee_Pancard_Number=""
      this.newEmployee.employeeAccount_Number=""
      this.newEmployee.employeePF_Number=""
      this.newEmployee.companyId=0 
    },
    (error)=>{
      console.log("Coming Into Error")
      console.log(error)
    }
  )
}


editClick(e:any,i:number){
  //alert('hit it')
  debugger
  this.editEmployee.employeeId=this.employeeList[i].employeeId;
  this.editEmployee.employeeName=this.employeeList[i].employeeName;
  this.editEmployee.employee_Pancard_Number=this.employeeList[i].employee_Pancard_Number;
  this.editEmployee.employeeAddress=this.employeeList[i].employeeAddress;
  this.editEmployee.employeeAccount_Number=this.employeeList[i].employeeAccount_Number;
  this.editEmployee.employeePF_Number=this.employeeList[i].employeePF_Number;
  this.editEmployee.companyId=this.employeeList[i].companyId;

  
}
updateClick(){
  this.employeeService.updateEmployee(this.editEmployee).subscribe(
    (response)=>{
      this.getAll();
    },
    (error)=>{
      console.log(error);
    }
    );
}

deleteClick(e:any,i:number){
  debugger
let ans = confirm('want to delete data')
if(!ans) return;
let id = this.employeeList[i].employeeId;
console.log('id')
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