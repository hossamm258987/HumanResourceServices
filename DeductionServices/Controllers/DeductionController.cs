using DeductionServices.Data;
using DeductionServices.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeductionServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeductionController : ControllerBase
    {
        private readonly DeductionDbContext _db;
        public DeductionController(DeductionDbContext db)
        {
            _db = db;
        }
        // GET: api/<DeductionController>
        [HttpGet]
        public IEnumerable<Deduction> Get()
        {
            return _db.Deductions.ToList();
        }

        // GET api/<DeductionController>/5
        [HttpGet("{id}")]
        public IEnumerable<Deduction> GetAttendace(int id)
        {
            var attendace = _db.Deductions.Where(e => e.EmpId == id).ToList();

            return attendace;
        }

        [HttpGet("{id}/{year}/{month}")]
        public IEnumerable<Deduction> GetAttendacesPerMonth(int id, int year, int month)
        {
            var attendace = _db.Deductions.Where(e => e.EmpId == id && e.Deduction_DT.Year == year &&
                e.Deduction_DT.Month == month).ToList();

            return attendace;
        }

        [HttpGet("{id}/{year}/{month}/{day}")]
        public Deduction GetAttendaceSp(int id, int year, int month, int day)
        {

            var attendace = _db.Deductions.Where(e => e.EmpId == id && e.Deduction_DT.Year == year &&
                e.Deduction_DT.Month == month && e.Deduction_DT.Day == day).FirstOrDefault();

            return attendace;
        }

        // POST api/<DeductionController>
        [HttpPost]
        public IActionResult Post([FromBody] Deduction deduction)
        {
            try
            {
                _db.Deductions.Add(deduction);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, deduction);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<DeductionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Deduction deduction)
        {
            Deduction d = new Deduction();
            try
            {
                d = _db.Deductions.Find(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            d.EmpId = deduction.EmpId;
            d.Deduction_DT = deduction.Deduction_DT; ;
            d.Name = deduction.Name;
            d.Description = deduction.Description;
            d.Amount = deduction.Amount;
            d.IsActive = deduction.IsActive;

            _db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, d);
        }

        // DELETE api/<DeductionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deduction = _db.Deductions.Find(id);

                _db.Deductions.Remove(deduction);
                _db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
