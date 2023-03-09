import { Router } from '@angular/router';
import { EmployeelistService } from './../employeelist.service';
import { Component, OnInit } from '@angular/core';
import { Employeelist } from './../employeelist';
import { HttpClient} from '@angular/common/http';


@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrls: ['./employeelist.component.scss']
})
export class EmployeelistComponent implements OnInit {
EmployeeList:any []=[];
newEmployee:Employeelist= new Employeelist();
newDesignation:Employeelist=new Employeelist();
assignDesignation:Employeelist=new Employeelist();
DesignationList:any []=[];


Role=["Company","Employee"];



onclick(){

}

 
  constructor(private employeelistService:EmployeelistService,private http: HttpClient){}
ngOnInit(): void {
  this.EmployeeList = history.state.data;
  console.log(this.EmployeeList);
}

saveClick(){
  debugger
  console.log(this.newEmployee.role);
  alert(this.newEmployee.employeeName)
  debugger
  console.log("This is new Employee",this.newEmployee)
  this.newEmployee.employeeId=0;
  this.employeelistService.saveEmployee(this.newEmployee).subscribe(
    (response)=>{
      alert('data Saved');
  
    },
    (error)=>{
      console.log("Coming Into Error")
      console.log(error)
    }
  )
}
getValue(event:any){
  this.newEmployee.role = event.target.value;
}

saveDesignation(){
  this.newDesignation.designationId=0;
  this.employeelistService.saveDesignation(this.newDesignation).subscribe(
    (response)=>{
      alert("Designation added")
    }
  )
}
employeeDesignation(){
  alert("ok")
  this.assignDesignation.EmployeeDesignationId=0;
  this.assignDesignation.designationId=0;
  this.employeelistService.giveDesignation(this.assignDesignation).subscribe(
    (response)=>{
      alert("Designation assigned to employee")
    }
  )
}

getDesignation(id:any) {
  alert("Designation List ready")
  console.log(id);
  debugger
  id = this.EmployeeList[0].companyId;
  this.employeelistService.GetDesignationList(id).subscribe((data)=>{
    this.DesignationList=data;
    console.log(this.DesignationList)
    },
    (err)=>{
     console.log(err);
  })
  }

}
