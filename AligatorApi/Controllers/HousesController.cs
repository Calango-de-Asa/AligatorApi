﻿using AligatorApi.Models;
using AligatorApi.Pagination;
using AligatorApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AligatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public HousesController(IUnitOfWork context)
        {
            _uow = context;
        }

        // GET: api/Houses
        [HttpGet]
        public  ActionResult<IEnumerable<House>> GetHouse([FromQuery] PaginationParameters paginationParameters)
        {
            var values = _uow.RepositoryHouse.Get(paginationParameters);

            Response.Headers.Add(
                   "X-Pagination",
                   JsonConvert.SerializeObject(PagedList<House>.GenPaginationMetadata(values)));

            return values;
        }

        // GET: api/Houses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(int id)
        {
            var house =  await _uow.RepositoryHouse.GetById(h => h.Id == id);

            if (house == null)
            {
                return NotFound();
            }

            return house;
        }

        // PUT: api/Houses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(int id, House house)
        {
            if (id != house.Id)
            {
                return BadRequest();
            }

            _uow.RepositoryHouse.Update(house);

            try
            {
                await _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
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

        // POST: api/Houses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<House>> PostHouse(House house)
        {
            _uow.RepositoryHouse.Add(house);
            await _uow.Commit();

            return CreatedAtAction("GetHouse", new { id = house.Id }, house);
        }

        // DELETE: api/Houses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<House>> DeleteHouse(int id)
        {
            var house =  await _uow.RepositoryHouse.GetById(h => h.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            _uow.RepositoryHouse.Delete(house);
            await _uow.Commit();

            return house;
        }

        private bool HouseExists(int id)
        {
            return _uow.RepositoryHouse.GetById(e => e.Id == id) != null;
        }
    }
}
