using BusinessAccessLayer.Abstract;
using Data.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _Employee;
		private readonly ApplicationDbContext _context;

		public EmployeeController(IEmployeeService employee, ApplicationDbContext context)
        {
			_context = context;
			_Employee = employee;
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _Employee.AddEmployee(model);
					TempData["SuccessMessage"] = "Employee Added Successfully";
					return RedirectToAction("GetEmployees");
                }
                else
                {
                    TempData["errorMessage"] = "Field is Empty";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var result = await _Employee.GetEmployee();
                return View(result);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> EditEmployee(int id)
        {
            try
            {
                var edit = await _Employee.GetById(id);
                return View(edit);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool edit = _Employee.UpdateEmployee(model);
                    if (edit)
                    {
                        TempData["EditMessage"] = "Employee Edited Successfully";
                        return RedirectToAction("GetEmployees");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                bool result = _Employee.DeleteEmployee(id);
                if (result) {
                    TempData["DeleteMessage"] = "Employee Deleted Successfully";
                    return RedirectToAction("GetEmployees");
                }                   
                else
                    return View();
            }
            catch (Exception)
            {
                throw;
            }
		}
    }
}
