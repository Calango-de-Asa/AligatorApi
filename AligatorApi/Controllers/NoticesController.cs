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
    public class NoticesController : ControllerBase
    {
        private readonly UnitOfWork _uow;

        public NoticesController(UnitOfWork context)
        {
            _uow = context;
        }

        // GET: api/Notices
        [HttpGet]
        public  ActionResult<IEnumerable<Notice>> GetNotices()
        {
            return  _uow.RepositoryNotice.Get().ToList();
        }

        // GET: api/Notices/5
        [HttpGet("{id}")]
        public  ActionResult<Notice> GetNotice(int id)
        {
            var notice =  _uow.RepositoryNotice.GetById(n => n.Id == id);

            if (notice == null)
            {
                return NotFound();
            }

            return notice;
        }

        // PUT: api/Notices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public  IActionResult PutNotice(int id, Notice notice)
        {
            if (id != notice.Id)
            {
                return BadRequest();
            }

            _uow.RepositoryNotice.Update(notice);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeExists(id))
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

        // POST: api/Notices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult<Notice> PostNotice(Notice notice)
        {
            _uow.RepositoryNotice.Add(notice);
             _uow.Commit();

            return CreatedAtAction("GetNotice", new { id = notice.Id }, notice);
        }

        // DELETE: api/Notices/5
        [HttpDelete("{id}")]
        public  ActionResult<Notice> DeleteNotice(int id)
        {
            var notice =  _uow.RepositoryNotice.GetById(r => r.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            _uow.RepositoryNotice.Delete(notice);
             _uow.Commit();

            return notice;
        }

        private bool NoticeExists(int id)
        {
            return _uow.RepositoryNotice.GetById(e => e.Id == id) != null;
        }
    }
}
