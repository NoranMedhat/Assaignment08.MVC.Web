using Assignment.Service.Interfaces.Department;
using Assignment.Service.Interfaces.Department.Dto;
using Assignment.Service.Interfaces.Employee;
using Assignment.Service.Interfaces.Employee.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment05.MVC.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeServices employeeServices,IDepartmentService departmentService)
        {
            _employeeServices = employeeServices;
            _departmentService = departmentService;
        }
        
        public IActionResult Index(string SearchInp)
        {
            IEnumerable<EmployeeDto> employees=new List<EmployeeDto>();
            if (string.IsNullOrEmpty(SearchInp))
                 employees = _employeeServices.GetAll();
           
            else 
                 employees=_employeeServices.GetEmployeeByName(SearchInp);
           
            return View(employees);

        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }
        


        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeServices.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Employee Error", ex.Message);
                return View(employee);
            }
        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            var employee = _employeeServices.GetById(id);
            if (employee is null)
                return NotFound();
            return View(viewName, employee);


        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            return Details(id, "Update");

        }
        [HttpPost]
        public IActionResult Update(int?id,EmployeeDto employeeDto)
        {
            if (employeeDto.Id != id.Value)
                return NotFound();
            _employeeServices.Update(employeeDto);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {

            var employee = _employeeServices.GetById(id);
            if (employee is null)
                return NotFound();
            _employeeServices.Delete(employee);
            return RedirectToAction(nameof(Index));



        }
    }
}
