using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.EmployeeService.Dto;

namespace TestApp.Core.EmployeeService
{
    public interface IEmployeeService
    {
        Task<DataResult> Create(EmployeeDto param);
        Task<DataResult> Update(EmployeeDto param);
        Task<DataResult> Delete(int id);
        Task<DataResult<EmployeeDto>> Get(int id);
        Task<DataResult<IEnumerable<EmployeeDto?>>> GetAll();
        Task<DataResult<IEnumerable<EmployeeDto>>> GetAll(EmployeeQueryParam queryParam);
    }
}
