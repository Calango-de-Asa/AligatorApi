﻿using System;
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
    public class HousesController : ControllerBase
    {
        private readonly UnitOfWork _uow;

        public HousesController(UnitOfWork context)
        {
            _uow = context;
        }

        // GET: api/Houses
        [HttpGet]
        public  ActionResult<IEnumerable<House>> GetHouse()
        {
            return  _uow.RepositoryHouse.Get().ToList();
        }

        // GET: api/Houses/5
        [HttpGet("{id}")]
        public  ActionResult<House> GetHouse(int id)
        {
            var house =  _uow.RepositoryHouse.GetById(h => h.Id == id);

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
        public  IActionResult PutHouse(int id, House house)
        {
            if (id != house.Id)
            {
                return BadRequest();
            }

            _uow.RepositoryHouse.Update(house);

            try
            {
                _uow.Commit();
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
        public  ActionResult<House> PostHouse(House house)
        {
            _uow.RepositoryHouse.Add(house);
             _uow.Commit();

            return CreatedAtAction("GetHouse", new { id = house.Id }, house);
        }

        // DELETE: api/Houses/5
        [HttpDelete("{id}")]
        public  ActionResult<House> DeleteHouse(int id)
        {
            var house =  _uow.RepositoryHouse.GetById(h => h.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            _uow.RepositoryHouse.Delete(house);
             _uow.Commit();

            return house;
        }

        private bool HouseExists(int id)
        {
            return _uow.RepositoryHouse.GetById(e => e.Id == id) != null;
        }
    }
}
