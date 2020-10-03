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
    public class BillsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public BillsController(IUnitOfWork context)
        {
            _uow = context;
        }

        // GET: api/Bills
        [HttpGet]
        public ActionResult<IEnumerable<Bill>> GetBills()
        {
            return _uow.RepositoryBill.Get().ToList();
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(int id)
        {
            var bill = await _uow.RepositoryBill.GetById(p => p.Id == id);

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }

        // PUT: api/Bills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutBill(int id, Bill bill)
        {
            if (id != bill.Id)
            {
                return BadRequest();
            }

            _uow.RepositoryBill.Update(bill);

            try
            {
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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

        // POST: api/Bills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Bill> PostBill(Bill bill)
        {
            _uow.RepositoryBill.Add(bill);
            _uow.Commit();

            return CreatedAtAction("GetBill", new { id = bill.Id }, bill);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bill>> DeleteBill(int id)
        {
            var bill = await _uow.RepositoryBill.GetById(p => p.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            _uow.RepositoryBill.Delete(bill);
            _uow.Commit();

            return bill;
        }

        private bool BillExists(int id)
        {
            return _uow.RepositoryBill.GetById(e => e.Id == id) != null;
        }
    }
}
