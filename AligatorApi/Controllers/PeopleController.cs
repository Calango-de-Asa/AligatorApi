using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AligatorApi.Context;
using AligatorApi.Models;
using AligatorApi.Repository;

namespace AligatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public PeopleController(IUnitOfWork context)
        {
            _uow = context;
        }

        // GET: api/People
        [HttpGet]
        public  ActionResult<IEnumerable<Person>> GetPeople()
        {
            return  _uow.RepositoryPerson.Get()
                .Include(p => p.Notices)
                .Include(p => p.PersonBills)
                .Include(p => p.PersonTasks).ToList();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _uow.RepositoryPerson.GetById(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public  IActionResult PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _uow.RepositoryPerson.Update(person);

            try
            {
                 _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult<Person> PostPerson(Person person)
        {
            _uow.RepositoryPerson.Add(person);
            _uow.Commit();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await _uow.RepositoryPerson.GetById(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            _uow.RepositoryPerson.Delete(person);
             _uow.Commit();

            return person;
        }

        private bool PersonExists(int id)
        {
            return _uow.RepositoryPerson.GetById(e => e.Id == id) != null;
        }
    }
}
