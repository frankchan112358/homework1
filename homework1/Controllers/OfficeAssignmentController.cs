using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework1.Models;
using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class OfficeAssignmentController : ControllerBase {
        private readonly ContosouniversityContext db;
        public OfficeAssignmentController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/officeassignment
        [HttpGet ("")]
        public ActionResult<IEnumerable<OfficeAssignment>> GetOfficeAssignments () {
            return db.OfficeAssignment.ToList();
        }

        // GET api/officeassignment/5
        [HttpGet ("{id}")]
        public ActionResult<OfficeAssignment> GetOfficeAssignmentById (int id) {
            return db.OfficeAssignment.Find(id);
        }

        // POST api/officeassignment
        [HttpPost ("")]
        public void PostOfficeAssignment (OfficeAssignment value) {
            db.OfficeAssignment.Add(value);
            db.SaveChanges();
         }

        // PUT api/officeassignment/5
        [HttpPut ("{id}")]
        public void PutOfficeAssignment (int id, OfficeAssignment value) {
            db.OfficeAssignment.Update(value);
            db.SaveChanges();
         }

        // DELETE api/officeassignment/5
        [HttpDelete ("{id}")]
        public void DeleteOfficeAssignmentById (int id) {
            var value = db.OfficeAssignment.Find(id);
            db.OfficeAssignment.Remove(value);
            db.SaveChanges();
         }
    }
}