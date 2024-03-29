﻿using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository.IRepository;

namespace Company_Employee_AuthenticationSystem.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
       public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CompanyRepository = new CompanyRepository(_context);
            EmployeeRepository = new EmployeeRepository(_context);
            DesignationRepository= new DesignationRepository(_context);
            EmployeeDesignationRepository= new EmployeeDesignationRepository(_context);
            LeaveRepository=new LeaveRepository(_context);

        }

      

        public ICompanyRepository CompanyRepository { get; private set; }

        public IEmployeeRepository EmployeeRepository { get; private set; }

        public IDesignationRepository DesignationRepository { get; private set; }

        public IEmployeeDesignationRepository EmployeeDesignationRepository { get; private set; }

        public ILeaveRepository LeaveRepository { get; private set; }
    }
}