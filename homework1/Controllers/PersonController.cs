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
            return db.Person.ToList();
        }

        // GET api/person/5
        [HttpGet ("{id}")]
        public ActionResult<Person> GetPersonById (int id) {
            return db.Person.Find(id);
        }

        // POST api/person
        [HttpPost ("")]
        public void PostPerson (Person value) {
            db.Person.Add(value);
            db.SaveChanges();
         }

        // PUT api/person/5
        [HttpPut ("{id}")]
        public void PutPerson (int id, Person value) {
            db.Person.Update(value);
            db.SaveChanges();
         }

        // DELETE api/person/5
        [HttpDelete ("{id}")]
        public void DeletePersonById (int id) {
            var value = db.Person.Find(id);
            db.Person.Remove(value);
            db.SaveChanges();
         }
    }
}