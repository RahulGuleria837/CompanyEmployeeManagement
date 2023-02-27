import { EmployeelistService } from './../employeelist.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrls: ['./employeelist.component.scss']
})
export class EmployeelistComponent implements OnInit {
EmployeeList:any []=[]

  constructor(private employeelistService:EmployeelistService){}
ngOnInit(): void {
  this.EmployeeList = history.state.data;
  console.log(this.EmployeeList);
}

  }


