using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework1.Models;
using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class CourseInstructorController : ControllerBase {
        private readonly ContosouniversityContext db;
        public CourseInstructorController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/CourseInstructor
        [HttpGet ("")]
        public ActionResult<IEnumerable<CourseInstructor>> GetCourseInstructor () {
            return db.CourseInstructor.ToList();
        }

        // GET api/CourseInstructor/5
        [HttpGet ("{id}")]
        public ActionResult<CourseInstructor> GetCourseInstructorById (int id) {
            return db.CourseInstructor.Find(id);
        }

        // POST api/CourseInstructor
        [HttpPost ("")]
        public void PostCourseInstructor (CourseInstructor value) {
            db.CourseInstructor.Add(value);
            db.SaveChanges();
         }

        // PUT api/CourseInstructor/5
        [HttpPut ("{id}")]
        public void PutCourseInstructor (int id, CourseInstructor value) {
            db.CourseInstructor.Update(value);
            db.SaveChanges();
         }

        // DELETE api/CourseInstructor/5
        [HttpDelete ("{id}")]
        public void DeleteCourseInstructorById (int id) {
            var value = db.CourseInstructor.Find(id);
            db.CourseInstructor.Remove(value);
            db.SaveChanges();
         }
    }
}