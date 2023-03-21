using DCT1205.Models;
using DCT1205.Services;
using Microsoft.AspNetCore.Mvc;

namespace DCT1205.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var model = _employeeService.GetAll().Select(employee => new IndexEmployeeViewModel
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                DOB = employee.DOB,
                ImageUrl = employee.ImageUrl,
                Gender = employee.Gender,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                City = employee.City,                
            }).ToList();
            return View(model);
        }
    }
}
