using Microsoft.AspNetCore.Mvc;
using SalaryPaymentServices.Data;
using SalaryPaymentServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalaryPaymentServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryPaymentController : ControllerBase
    {
        private readonly SalaryPaymentDbContext _db;

        public SalaryPaymentController(SalaryPaymentDbContext db)
        {
            _db = db;
        }
        // GET: api/<SalaryPaymentController>
        [HttpGet]
        public IEnumerable<SalaryPayment> Get()
        {
            return _db.SalaryPayments.ToList();
        }

        // GET api/<SalaryPaymentController>/5
        [HttpGet("month/{month}")]
        public IEnumerable<SalaryPayment> GetbyMonth(int month)
        {
            return _db.SalaryPayments.Where(sp => sp.Month == month).ToList();
        }

        [HttpGet("empid/{eid}")]
        public IEnumerable<SalaryPayment> GetbyEmp(int eid)
        {
            return _db.SalaryPayments.Where(sp => sp.EmpId == eid).ToList();
        }

        [HttpGet("{eid}/{month}")]
        public SalaryPayment GetbySP(int eid, int month)
        {
            return _db.SalaryPayments.Where(sp => sp.EmpId == eid && sp.Month == month).FirstOrDefault();
        }

        //You Need Too Recreate it to Calculate NetSalary, The Equation in a Comment in Method Below.
        // POST api/<SalaryPaymentController>
        [HttpPost]
        public IActionResult Post([FromBody] SalaryPayment salaryPayment)
        {
            try
            {
                //NetSalary = ((Salary/30)*Attendace Days per Month (D/M)) + IncentiveAmount - Tax - InsuranceTax - Factor
                _db.SalaryPayments.Add(salaryPayment);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, salaryPayment);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<SalaryPaymentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SalaryPayment salaryPayment)
        {
            SalaryPayment sP = _db.SalaryPayments.Find(id);

            try
            {
                sP.EmpId = salaryPayment.EmpId;
                sP.Description = salaryPayment.Description;
                sP.IncentiveAmount = salaryPayment.IncentiveAmount;
                sP.NetSalary = salaryPayment.NetSalary;
                sP.Tax = salaryPayment.Tax;
                sP.SalaryPayment_DT = salaryPayment.SalaryPayment_DT;
                sP.Month = salaryPayment.Month;

                _db.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, salaryPayment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<SalaryPaymentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            SalaryPayment sP = _db.SalaryPayments.Find(id);
            try
            {
                _db.SalaryPayments.Remove(sP);

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
