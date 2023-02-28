import { Company } from './company';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private httpClient:HttpClient) {}

  getAllCompany():Observable<any>
  {return this.httpClient.get<any>
  ("https://localhost:7129/api/Company");}

  saveCompany(newCompany:Company):Observable<Company>
  {return this.httpClient.post<Company>
  ("https://localhost:7129/api/Company",newCompany)}

  updateCompany(editCompany:Company):Observable<Company>
  {return this.httpClient.put<Company>
  ("https://localhost:7129/api/Company",editCompany);}

  deleteCompany(id:number):Observable<any>
  {debugger; return this.httpClient.delete<Company>
  ("https://localhost:7129/api/Company/"+ id);}

  getCompanyEmployee(companyId:any):Observable<any>{
    return this.httpClient.get<any>
    (`https://localhost:7129/api/Company/EmployeesInTheCompany?companyId=${companyId}`)

  }

  

}

