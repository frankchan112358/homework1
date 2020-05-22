using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework1.Models;
using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase {
        private readonly ContosouniversityContext db;
        public PersonController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/person
        [HttpGet ("")]
        public ActionResult<IEnumerable<Person>> GetPersons () {
            return db.Person.Where(p => p.IsDeleted == false).ToList();
        }

        // GET api/person/5
        [HttpGet ("{id}")]
        public ActionResult<Person> GetPersonById (int id) {
            var value = db.Person.Find(id);
            if (value.IsDeleted == true)
            {
                return NotFound();
            }
            return value;
        }

        // POST api/person
        [HttpPost ("")]
        public void PostPerson (Person value) {
            db.Person.Add(value);
            value.DateModified = DateTime.Now;
            db.SaveChanges();
         }

        // PUT api/person/5
        [HttpPut ("{id}")]
        public void PutPerson (int id, Person value) {
            db.Person.Update(value);
            value.DateModified = DateTime.Now;
            db.SaveChanges();
         }

        // DELETE api/person/5
        [HttpDelete ("{id}")]
        public void DeletePersonById (int id) {
            var value = db.Person.Find(id);
            db.Person.Update(value);
            value.DateModified = DateTime.Now;
            value.IsDeleted = true;
            db.SaveChanges();
         }
    }
}