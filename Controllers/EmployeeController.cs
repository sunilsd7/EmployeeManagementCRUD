using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projectdemo1.Data;
using Projectdemo1.Models;
using Projectdemo1.Models.Entities;

namespace Projectdemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeBYID(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();

            }
            return Ok(employee);
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees= dbContext.Employees.ToList();
            return Ok(allEmployees);
            
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployee addEmployee)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployee.Name,
                Address = addEmployee.Address,
                Phone = addEmployee.Phone,
                Salary = addEmployee.Salary

            };
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
               
        }
        [HttpPut]
        [Route("{id:guid}")]

         public IActionResult UpdateEmployee(Guid id,UpdateEmployee updateEmployee)
        {
            var employee= dbContext.Employees.Find(id); 
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployee.Name;
            employee.Address = updateEmployee.Address; 
            employee.Phone=updateEmployee.Phone;
            employee.Salary = updateEmployee.Salary;

            dbContext.SaveChanges();
            return Ok(employee);

        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteEmployee(Guid id) 
        {
            var employee=dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok(employee);
        }
    }
}
