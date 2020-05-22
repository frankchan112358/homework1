using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework1.Models;
using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase {
        private readonly ContosouniversityContext db;
        public CourseController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/Course/CourseStudents
        [HttpGet("CourseStudents")]
        public ActionResult<IEnumerable<VwCourseStudents>> GetCourseStudents() {
            return db.VwCourseStudents.ToList();
        }

        // GET api/Course/CourseStudentCount
        [HttpGet("CourseStudentCount")]
        public ActionResult<IEnumerable<VwCourseStudentCount>> GetCourseStudentCount() {
            return db.VwCourseStudentCount.ToList();
        }


        // GET api/Course
        [HttpGet ("")]
        public ActionResult<IEnumerable<Course>> GetCourses () {
            return db.Course.ToList();
        }

        // GET api/Course/5
        [HttpGet ("{id}")]
        public ActionResult<Course> GetCourseById (int id) {
            return db.Course.Find(id);
        }

        // POST api/Course
        [HttpPost ("")]
        public void PostCourse (Course value) {
            db.Course.Add(value);
            value.DateModified = DateTime.Now;
            db.SaveChanges();
         }

        // PUT api/Course/5
        [HttpPut ("{id}")]
        public void PutCourse (int id, Course value) {
            db.Course.Update(value);
            value.DateModified = DateTime.Now;
            db.SaveChanges();
         }

        // DELETE api/Course/5
        [HttpDelete ("{id}")]
        public void DeleteCourseById (int id) {
            var value = db.Course.Find(id);
            db.Course.Remove(value);
            db.SaveChanges();
         }
    }
}