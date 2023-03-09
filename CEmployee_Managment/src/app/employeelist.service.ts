import { Employeelist } from './employeelist';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeelistService {

  constructor(private httpClient:HttpClient) { }

  getCompanyEmployee(companyId:any):Observable<any>{
    return this.httpClient.get<any>
    (`https://localhost:7129/api/Company/EmployeesInTheCompany?companyId=${companyId}`)

  }

  saveEmployee(newEmployee:Employeelist):Observable<Employeelist>
  {
    debugger
    return this.httpClient.post<Employeelist>("https://localhost:7129/api/Employee",newEmployee)

  }

  saveDesignation(newDesignation:Employeelist){
    return this.httpClient.post<Employeelist>("https://localhost:7129/api/Designation/AddDesignation",newDesignation)
  }

  giveDesignation(assignDesignation:Employeelist){
    return this.httpClient.post<Employeelist>("https://localhost:7129/api/Designation/AddEmployeeDesignation",assignDesignation)

  }

  GetDesignationList(companyId:any):Observable<any>{
    debugger
    return this.httpClient.get<any>(`https://localhost:7129/api/Designation/${companyId}`)
  }
}
