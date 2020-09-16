using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFitnessManager.Db.Entities;
using MyFitnessManager.Db.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFitnessManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly IHallRepository _repository;

        public HallController(IHallRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<HallController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hall>>> Get()
        {
            return Ok(await _repository.GetAsync());
        }


        [HttpPost]
        public async Task<ActionResult<Hall>> Post([FromBody] Hall hall)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.Create(hall);

                await _repository.SaveChangesAsync();

                return Ok(hall);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var toDelete = await _repository.GetAsync(id);

            if (toDelete == null)
                return BadRequest($"coach with {id} wasn't found");

            _repository.Delete(toDelete);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
