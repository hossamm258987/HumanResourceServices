using EmployeeServices.Data;
using EmployeeServices.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _db.Employies.ToList();
        }

        [HttpGet("order")]
        public IEnumerable<Employee> order(string order)
        {
            IQueryable<Employee> emps = _db.Employies;
            IEnumerable<Employee> e = emps;

            switch (order)
            {
                case "Name_asc":
                    e = emps.OrderBy(emps => emps.Name).ToList();
                    break;
                case "Name_desc":
                    e = emps.OrderByDescending(emps => emps.Name).ToList();
                    break;
                case "Country_asc":
                    e = emps.OrderBy(emps => emps.Country).ToList();
                    break;
                case "Country_desc":
                    e = emps.OrderByDescending(emps => emps.Country).ToList();
                    break;
                case "City_asc":
                    e = emps.OrderBy(emps => emps.City).ToList();
                    break;
                case "City_desc":
                    e = emps.OrderByDescending(emps => emps.City).ToList();
                    break;
                case "Dept_desc":
                    e = emps.OrderByDescending(emps => emps.DepartmentId).ToList();
                    break;
            }
            return e;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var emp = _db.Employies.Find(id);
            return emp;
        }

        [HttpGet("search")]
        public IActionResult Search(string title)
        {
            IQueryable<Employee> emps = _db.Employies;
            if(!string.IsNullOrEmpty(title))
            {
                emps = emps.Where(e => e.Name.Contains(title) 
                    || e.NationalNumber.Contains(title)
                    || e.SNN.Contains(title)
                    || e.HireDate.ToString().Contains(title)
                    || e.Gender.ToString().Contains(title)
                    || e.City.Contains(title)
                    || e.DepartmentId.ToString().Contains(title));

                return StatusCode(StatusCodes.Status302Found, emps);
            }

            return StatusCode(StatusCodes.Status404NotFound, "This Employee Not Found");
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            try
            {
                _db.Employies.Add(employee);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {

            Employee newEmployee = Get(id);

            try
            {
                newEmployee.Name = employee.Name;
                newEmployee.Gender = employee.Gender;
                newEmployee.DoB = employee.DoB;
                newEmployee.NationalNumber = employee.NationalNumber;
                newEmployee.SNN = employee.SNN;
                newEmployee.Country = employee.Country;
                newEmployee.City = employee.City;
                newEmployee.Street = employee.Street;
                newEmployee.PostalCode = employee.PostalCode;
                newEmployee.Phone = employee.Phone;
                newEmployee.Email = employee.Email;
                newEmployee.DepartmentId = employee.DepartmentId;
                newEmployee.Salary = employee.Salary;
                newEmployee.Factor = employee.Factor;
                newEmployee.InsuranceTax = employee.InsuranceTax;
                newEmployee.Certificates = employee.Certificates;
                newEmployee.YearsofExperience = employee.YearsofExperience;
                newEmployee.IsActive = employee.IsActive;

                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.Employies.Remove(Get(id));
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
