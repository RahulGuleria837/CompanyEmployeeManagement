﻿using AutoMapper;
using Company_Employee_AuthenticationSystem.DTO;
using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_Employee_AuthenticationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

 
    public class CompanyController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper= mapper;
            _unitOfWork= unitOfWork;

        }
        [HttpGet]

        public IActionResult GetCompany()
        {
           var companyList = _unitOfWork.CompanyRepository.GetAll();
            if(companyList ==null) 
               return NotFound(new {Message="No data avilable"});
            return Ok(companyList);
        }
        [HttpPost]

        public IActionResult SaveCompany([FromBody]CompanyDTO companyDTO)
        {
            if(companyDTO == null && (!ModelState.IsValid))return BadRequest();
            var companyData = _mapper.Map<Company>(companyDTO);
            _unitOfWork.CompanyRepository.Add(companyData);
            return Ok(new {Message="New Employee Added to Table"});
        }
        [HttpPut]

        public IActionResult UpdateCompany([FromBody]CompanyDTO companyDTO)
        { 
            if (companyDTO == null ) return BadRequest();
            var updateCompany = _mapper.Map<Company>(companyDTO);
            _unitOfWork.CompanyRepository.Update(updateCompany);
            return Ok(new {Message="Employee Details Updated"});
        
        }

        [HttpDelete]
        public IActionResult DeleteCompany(int id) 
        {
            _unitOfWork.CompanyRepository.Remove(id);
            return Ok(new {Message="Employee has been Deleted"});
        
        }
    }
}