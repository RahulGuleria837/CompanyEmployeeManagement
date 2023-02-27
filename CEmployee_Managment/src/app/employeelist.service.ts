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
}
