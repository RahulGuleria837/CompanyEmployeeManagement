import { Employee } from './employee';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpclient:HttpClient) { }
  getAllEmployee():Observable<any>
  {return this.httpclient.get<any>
    ("https://localhost:7129/api/Employee")
  }

  saveEmployee(newEmployee:Employee):Observable<Employee>
  {debugger
    console.log(newEmployee)
    return this.httpclient.post<Employee>("https://localhost:7129/api/Employee",newEmployee)
}
updateEmployee(editEmployee:Employee):Observable<Employee>
{return this.httpclient.put<Employee>
("https://localhost:7129/api/Employee",editEmployee);}

deleteEmployee(id:Number):Observable<any>
{return this.httpclient.delete<any>
("https://localhost:7129/api/Employee" + id);}

}