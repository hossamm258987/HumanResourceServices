using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AttendaceServices.Data;
using AttendaceServices.Models;

namespace AttendaceServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendacesController : ControllerBase
    {
        private readonly AttendaceDbContext _db;

        public AttendacesController(AttendaceDbContext db)
        {
            _db = db;
        }

        // GET: api/Attendaces
        [HttpGet]
        public IEnumerable<Attendace> GetAttendaces()
        {
            return _db.Attendaces.ToList();
        }

        // GET: api/Attendaces/5
        [HttpGet("{id}")]
        public IEnumerable<Attendace> GetAttendace(int id)
        {
            var attendace = _db.Attendaces.Where(e => e.EmpId == id).ToList();

            return attendace;
        }

        [HttpGet("{id}/{year}/{month}")]
        public IEnumerable<Attendace> GetAttendacesPerMonth(int id, int year, int month)
        {
            var attendace = _db.Attendaces.Where(e => e.EmpId == id && e.Attendace_DT.Year == year &&
                e.Attendace_DT.Month == month).ToList();

            return attendace;
        }

        [HttpGet("{id}/{year}/{month}/{day}")]
        public Attendace GetAttendaceSp(int id, int year, int month, int day)
        {

            var attendace = _db.Attendaces.Where(e => e.EmpId == id && e.Attendace_DT.Year == year &&
                e.Attendace_DT.Month == month && e.Attendace_DT.Day == day).FirstOrDefault();

            return attendace;
        }

        // PUT: api/Attendaces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutAttendace(int id, Attendace attendace)
        {
            Attendace atd = new Attendace();
            try
            {
                atd = _db.Attendaces.Find(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            atd.EmpId = attendace.EmpId;
            atd.Attendace_DT = attendace.Attendace_DT;;
            atd.IsPresent = attendace.IsPresent;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Attendaces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostAttendace(Attendace attendace)
        {
            try
            {
                _db.Attendaces.Add(attendace);
                _db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, attendace);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
          
        }

        // DELETE: api/Attendaces/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAttendace(int id)
        {
            try
            {
                var attendace = _db.Attendaces.Find(id);

                _db.Attendaces.Remove(attendace);
                _db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }           
        }

        private bool AttendaceExists(int id)
        {
            return (_db.Attendaces?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
