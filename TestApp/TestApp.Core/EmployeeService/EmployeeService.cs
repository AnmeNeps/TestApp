using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.EmployeeService.Dto;
using TestApp.Data;
using TestApp.Data.Models;

namespace TestApp.Core.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<DataResult> Create(EmployeeDto param)
        {
            DataResult result = new DataResult();
            try
            {
                if(param == null)
                {
                    result.Message = "No Data Found !!";
                    result.ResultType = ResultType.Failed;
                    return result;
                }
                //Add validation above before mapping data here
                Employee emp = new Employee
                {
                    Id = param.Id,
                    FullName = param.FullName,
                    Gender = param.Gender,
                    DateOfBirth = param.DateOfBirth,
                    Salary = param.Salary,
                    Designation = param.Designation,
                };
                await _applicationDbContext.Employees.AddAsync(emp);
                await _applicationDbContext.SaveChangesAsync();
                result.Message = "Employee Created Sucessfully !!";
                result.ResultType = ResultType.Sucess;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.ResultType = ResultType.Exception;
                return result;
            }
        }

        public async Task<DataResult> Delete(int id)
        {
            DataResult result = new DataResult();
            try
            {
                Employee? emp = await _applicationDbContext.Employees.FindAsync(id);
                if (emp == null)
                {
                    result.Message = "No Data Found !!";
                    result.ResultType = ResultType.Failed;
                    return result;
                }
                //Add validation above before deleting data here
                _applicationDbContext.Remove(emp);
                result.Message = "Employee Deleted Sucessfully !!";
                result.ResultType = ResultType.Sucess;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.ResultType = ResultType.Exception;
                return result;
            }
        }

        public async Task<DataResult<EmployeeDto>> Get(int id)
        {
            DataResult<EmployeeDto> result = new DataResult<EmployeeDto>();
            try
            {
                Employee? emp = await _applicationDbContext.Employees.FindAsync(id);
                if (emp == null)
                {
                    result.Message = "No Data Found !!";
                    result.ResultType = ResultType.Failed;
                    return result;
                }
                result.Data = new EmployeeDto
                {
                    Id = emp.Id,
                    FullName = emp.FullName,
                    Gender = emp.Gender,
                    DateOfBirth = emp.DateOfBirth,
                    Salary = emp.Salary,
                    Designation = emp.Designation,
                };
                result.Message = "Get Data Sucessful";
                result.ResultType = ResultType.Sucess;
                return result;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.ResultType = ResultType.Exception;
                return result;
            }
        }

        public async Task<DataResult<IEnumerable<EmployeeDto?>>> GetAll()
        {
            DataResult<IEnumerable<EmployeeDto?>> result = new DataResult<IEnumerable<EmployeeDto>>();
            try
            {
                result.Data = await _applicationDbContext.Employees.Select(s => new EmployeeDto
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Gender = s.Gender,
                    DateOfBirth = s.DateOfBirth,
                    Salary = s.Salary,
                    Designation = s.Designation,
                }).ToListAsync();
                
                result.Message = "Get All Data Sucessful";
                result.ResultType = ResultType.Sucess;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.ResultType = ResultType.Exception;
                return result;
            }
        }

        public async Task<DataResult<IEnumerable<EmployeeDto>>> GetAll(EmployeeQueryParam queryParam)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult> Update(EmployeeDto param)
        {
            DataResult result = new DataResult();
            try
            {
                Employee? emp = await _applicationDbContext.Employees.FindAsync(param.Id);
                if (emp == null)
                {
                    result.Message = "No Data Found !!";
                    result.ResultType = ResultType.Failed;
                    return result;
                }
                //Add validation above before mapping data here
                emp = new Employee
                {
                    Id = param.Id,
                    FullName = param.FullName,
                    Gender = param.Gender,
                    DateOfBirth = param.DateOfBirth,
                    Salary = param.Salary,
                    Designation = param.Designation,
                };
                _applicationDbContext.Entry(emp).State = EntityState.Modified;
                await _applicationDbContext.SaveChangesAsync();
                result.Message = "Employee Updated Sucessfully !!";
                result.ResultType = ResultType.Sucess;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.ResultType = ResultType.Exception;
                return result;
            }
        }
    }
}
