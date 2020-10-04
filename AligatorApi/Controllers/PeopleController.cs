using AligatorApi.Models;
using AligatorApi.Pagination;
using AligatorApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        // GET: api/People?PageNumber=x&PageSize=y
        [HttpGet]
        public  ActionResult<IEnumerable<Person>> GetPeople([FromQuery] PaginationParameters paginationParameters)
        {
            var values = _uow.RepositoryPerson.Get(paginationParameters);

            Response.Headers.Add(
                "X-Pagination",
                JsonConvert.SerializeObject(PagedList<Person>.GenPaginationMetadata(values)));

            return values;
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
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _uow.RepositoryPerson.Update(person);

            try
            {
                await _uow.Commit();
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
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _uow.RepositoryPerson.Add(person);
            await _uow.Commit();

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
            await _uow.Commit();

            return person;
        }

        private bool PersonExists(int id)
        {
            return _uow.RepositoryPerson.GetById(e => e.Id == id) != null;
        }
    }
}
