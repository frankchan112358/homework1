using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework1.Models;
using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase {
        private readonly ContosouniversityContext db;
        public EnrollmentController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/enrollment
        [HttpGet ("")]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollments () {
            return db.Enrollment.ToList();
        }

        // GET api/enrollment/5
        [HttpGet ("{id}")]
        public ActionResult<Enrollment> GetEnrollmentById (int id) {
            return db.Enrollment.Find(id);
        }

        // POST api/enrollment
        [HttpPost ("")]
        public void PostEnrollment (Enrollment value) { 
            db.Enrollment.Add(value);
            db.SaveChanges();
        }

        // PUT api/enrollment/5
        [HttpPut ("{id}")]
        public void PutEnrollment (int id, Enrollment value) {
            db.Enrollment.Update(value);
            db.SaveChanges();
         }

        // DELETE api/enrollment/5
        [HttpDelete ("{id}")]
        public void DeleteEnrollmentById (int id) {
            var vlaue = db.Enrollment.Find(id);
            db.Enrollment.Remove(vlaue);
            db.SaveChanges();
         }
    }
}