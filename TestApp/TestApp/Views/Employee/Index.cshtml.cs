using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApp.Core;
using TestApp.Core.EmployeeService;
using TestApp.Core.EmployeeService.Dto;

namespace TestApp.Views
{
    public class IndexModel : PageModel
    {
        private IEmployeeService _employeeService;
        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [BindProperty]
        public DataResult<IEnumerable<EmployeeDto?>> Employees { get; set; }
        [TempData]
        public string Message { get; set; }

        public string PageTitle { get; set; }
        public async void OnGet()
        {
            PageTitle = "Employee List";
            Employees = await _employeeService.GetAll();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            DataResult result = await _employeeService.Delete(id);
            if(result.ResultType == ResultType.Sucess)
            {
                Message = result.Message;
                return RedirectToAction("Index");
            }
            return Page();
        }
    }
}
