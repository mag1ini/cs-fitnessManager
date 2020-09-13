using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFitnessManager.Db;
using MyFitnessManager.Db.Entities;
using MyFitnessManager.Db.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFitnessManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachRepository _repository;


        public CoachController(ICoachRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CoachController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> Get()
        {
            return Ok(await _repository.GetAsync());
        }

        // GET api/<CoachController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coach>> Get(int id)
        {
            return Ok(await _repository.GetAsync(id));
        }

        // POST api/<CoachController>
        [HttpPost]
        public async Task<ActionResult<Coach>> Post([FromBody] Coach coach)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.Create(coach);
            await _repository.SaveChangesAsync();

            return coach;
        }
        /*
        // PUT api/<CoachController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Coach>> Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<CoachController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        { 
            var toDelete = await _repository.GetAsync(id);
             _repository.Delete(toDelete);
            await _repository.SaveChangesAsync();
        }
    }
}
