import { EmployeelistService } from './../employeelist.service';
import { Component, OnInit } from '@angular/core';
import { Employeelist } from './../employeelist';



@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrls: ['./employeelist.component.scss']
})
export class EmployeelistComponent implements OnInit {
EmployeeList:any []=[];
employeeList:any[]=[];
newEmployee:Employeelist= new Employeelist();
Role:any=['Employee','Company']


 
  constructor(private employeelistService:EmployeelistService){}
ngOnInit(): void {
  this.EmployeeList = history.state.data;
  console.log(this.EmployeeList);
}

saveClick(){
  debugger
  alert(this.newEmployee.employeeName)
  debugger
  console.log("This is new Employee",this.newEmployee)
  this.newEmployee.employeeId=0;
  this.employeelistService.saveEmployee(this.newEmployee).subscribe(
    (response)=>{
      alert('data Saved');
      
      this.newEmployee.employeeName=""
      this.newEmployee.employeeAddress=""
      this.newEmployee.employee_Pancard_Number=""
      this.newEmployee.employeeAccount_Number=""
      this.newEmployee.employeePF_Number=""
      this.newEmployee.companyId=0 
      this.newEmployee.role=""
    },
    (error)=>{
      console.log("Coming Into Error")
      console.log(error)
    }
  )
}


  }


