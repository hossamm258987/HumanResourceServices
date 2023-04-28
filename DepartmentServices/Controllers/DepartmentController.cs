using DepartmentServices.Data;
using DepartmentServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DepartmentServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DeptDbContext _db;
        public DepartmentController(DeptDbContext db)
        {
            _db = db;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _db.Departments.ToList();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return _db.Departments.Find(id);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public IActionResult Post([FromBody] Department dept)
        {
            try
            {
                _db.Departments.Add(dept);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, dept);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Department dept)
        {
            Department newDept = Get(id);
            try
            {
                newDept.Name = dept.Name;
                newDept.Description = dept.Description;
                newDept.ManagerId = dept.ManagerId;
                newDept.IsActive = dept.IsActive;
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status202Accepted, newDept);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.Departments.Remove(Get(id));
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
