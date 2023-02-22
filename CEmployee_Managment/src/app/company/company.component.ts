import { CompanyService } from './../company.service';
import { Company } from './../company';
import { Component } from '@angular/core';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss']
})
export class CompanyComponent {
  companyList:any[]=[];
  


  constructor(private companyService:CompanyService){}

ngOnInit():void{
  this.getAll();
}
  getAll(){
    this.companyService.getAllCompany().subscribe(
      (response)=>{
        this.companyList=response;
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )

  }
}

