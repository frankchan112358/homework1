using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace homework1.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase {
        private readonly ContosouniversityContext db;
        public DepartmentController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/department/DepartmentCourseCount
        [HttpGet("DepartmentCourseCount")]
        public ActionResult<IEnumerable<VwDepartmentCourseCount>> GetDepartmentCourseCount() {
            return db.VwDepartmentCourseCount.FromSqlRaw(@"
                    SELECT [DepartmentID]
                          ,[Name]
                          ,[CourseCount]
                      FROM [vwDepartmentCourseCount]").ToList();
        }


        // GET api/department
        [HttpGet ("")]
        public ActionResult<IEnumerable<Department>> GetDepartments () {
            return db.Department.ToList();
        }

        // GET api/department/5
        [HttpGet ("{id}")]
        public ActionResult<Department> GetDepartmentById (int id) {
            return db.Department.Find(id);
        }

        // POST api/department
        [HttpPost ("")]
        public void PostDepartment (Department value) {
            // db.Department.Add(value);
            // db.SaveChanges();
            var name = new SqlParameter("@Name", value.Name);
            var budget = new SqlParameter("@Budget", value.Budget);
            var startDate = new SqlParameter("@StartDate", value.StartDate);
            var instructorID = new SqlParameter("@InstructorID", value.InstructorId);
            db.Database.ExecuteSqlRaw("EXECUTE Department_Insert @Name,@Budget,@StartDate,@InstructorID", name, budget, startDate, instructorID);
         }

        // PUT api/department/5
        [HttpPut ("{id}")]
        public void PutDepartment (int id, Department value) {
            // db.Department.Update(value);
            // db.SaveChanges();
            var departmentID = new SqlParameter("@DepartmentID", value.DepartmentId);
            var name = new SqlParameter("@Name", value.Name);
            var budget = new SqlParameter("@Budget", value.Budget);
            var startDate = new SqlParameter("@StartDate", value.StartDate);
            var instructorID = new SqlParameter("@InstructorID", value.InstructorId);
            var rowVersion = new SqlParameter("@RowVersion_Original", db.Department.Find(id).RowVersion);
            db.Database.ExecuteSqlRaw("execute Department_Update @DepartmentID,@Name,@Budget,@StartDate,@InstructorID,@RowVersion_Original", departmentID, name, budget, startDate, instructorID, rowVersion);
         }

        // DELETE api/department/5
        [HttpDelete ("{id}")]
        public void DeleteDepartmentById (int id) {
            var value = db.Department.Find(id);
            // db.Department.Remove(value);
            // db.SaveChanges();
            var departmentID = new SqlParameter("@DepartmentID", value.DepartmentId);
            var rowVersion = new SqlParameter("@RowVersion_Original", value.RowVersion);
            db.Database.ExecuteSqlRaw("EXECUTE Department_Delete @DepartmentID,@RowVersion_Original", departmentID, rowVersion);
         }
    }
}