import { Employeelist } from './../employeelist';
import { CompanyService } from './../company.service';
import { Company } from './../company';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss']
})
export class CompanyComponent {
  companyList:any[]=[];
  newCompany:Company= new Company();
  companyEmployeeList:any[]=[];
  editCompany:Company=new Company();

  


  constructor(private companyService:CompanyService,private router:Router){}
  

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
  saveClick(){
    debugger
    this.newCompany.companyId=0
    this.companyService.saveCompany(this.newCompany).subscribe(
      (response)=>{
        this.getAll();
      }
    )

  }
  editClick(e:any,i:number){
    //alert('hit it')
    debugger
    this.editCompany.companyId=this.companyList[i].companyId;
    this.editCompany.company_Name=this.companyList[i].company_Name;
    this.editCompany.company_Address=this.companyList[i].company_Address;
    this.editCompany.company_GST=this.companyList[i].company_GST;
  }
  updateCompany(){
    this.companyService.updateCompany(this.editCompany).subscribe(
      (response)=>{
        this.getAll();
      },
      (error)=>{
        console.log(error);
      }
    )
  }
  EmployeeList(id:any) {
    alert("hello")
    console.log(id);
    this.companyService.getCompanyEmployee(id).subscribe((data)=>{
      console.log(data);
       this.router.navigate(['/employeelist'],{state:{data:data.employeeInDb,cmpId:id}})

    },(err)=>{
       console.log(err);
    })
  }
  deleteClick(e:any,i:number){
    debugger
   
let ans= confirm('Delete company Data')
if(!ans) return;

 let id =this.companyList[i].companyId;
 console.log('id')
this.companyService.deleteCompany(id).subscribe(
  (response)=>{
    alert("company has been deleted");
    this.getAll();
  },
  (error)=>{
    console.log(error);
  }
  
)
  }
  }
 


