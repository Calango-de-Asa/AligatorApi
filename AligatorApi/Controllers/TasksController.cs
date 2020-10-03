﻿using AligatorApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ThreadingTask = System.Threading.Tasks;
using Task = AligatorApi.Models.Task;

namespace AligatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public TasksController(IUnitOfWork context)
        {
            _uow = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async ThreadingTask.Task<ActionResult<IEnumerable<Task>>> GetTasks()
        {
            return await _uow.RepositoryTask.Get().ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async ThreadingTask.Task<ActionResult<Task>> GetTask(int id)
        {
            var task = await _uow.RepositoryTask.GetById(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public  IActionResult PutTask(int id, Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _uow.RepositoryTask.Update(task);

            try
            {
                 _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/Tasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult<Task> PostTask(Task task)
        {
            _uow.RepositoryTask.Add(task);
             _uow.Commit();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async ThreadingTask.Task<ActionResult<Task>> DeleteTask(int id)
        {
            var task = await _uow.RepositoryTask.GetById(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            _uow.RepositoryTask.Delete(task);
            await _uow.Commit();

            return task;
        }

        private bool TaskExists(int id)
        {
            return _uow.RepositoryTask.GetById(e => e.Id == id) != null;
        }
    }
}
