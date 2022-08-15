using Exercise.Data;
using Exercise.Models;
using Exercise.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext appDbContext;

        public EmployeesController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

         var employees =  await appDbContext.Employees.ToListAsync();
            if (employees != null)
            {
                return View(employees);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                BirthDay = addEmployeeRequest.BirthDay,
                Department = addEmployeeRequest.Department
               
            };
          await appDbContext.Employees.AddAsync(employee);
          await appDbContext.SaveChangesAsync();
           return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task< IActionResult> View(Guid id)
        {
          
       var employee = await appDbContext.Employees
                .FirstOrDefaultAsync(x => x.Id == id);
           if(employee != null)
            {
                var ViewModel = new UpdateViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    BirthDay = employee.BirthDay,
                    Department = employee.Department

                };
                return await Task.Run(() => View("View",ViewModel));
            }
            return RedirectToAction("Index");
        }

       [HttpPost]
        public async Task<IActionResult> View(UpdateViewModel model)
        {
            var employee = await appDbContext.Employees.FindAsync(model.Id);

            if(employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.Department = model.Department;
                await appDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        } 

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateViewModel model)
        {
            var employee = await appDbContext.Employees.FindAsync(model.Id);
            if(employee != null)
            {
                appDbContext.Employees.Remove(employee);
                await appDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
