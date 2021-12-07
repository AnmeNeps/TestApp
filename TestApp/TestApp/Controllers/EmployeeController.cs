using Microsoft.AspNetCore.Mvc;
using TestApp.Core;
using TestApp.Core.EmployeeService;
using TestApp.Core.EmployeeService.Dto;

namespace TestApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _empService;

        public EmployeeController(IEmployeeService empService)
        {
            _empService = empService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            DataResult<EmployeeDto> result = await _empService.Get(id);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(EmployeeQueryParam param)
        {
            DataResult<IEnumerable<EmployeeDto>> result = await _empService.GetAll(param);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto input)
        {
            DataResult result = await _empService.Create(input);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeDto input)
        {
            DataResult result = await _empService.Update(input);
            return Json(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            DataResult result = await _empService.Delete(id);
            return Json(result);
        }
    }
}
