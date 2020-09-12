using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFitnessManager.Db;
using MyFitnessManager.Db.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFitnessManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly FitnessDbContext _context;

        public CoachController(FitnessDbContext context)
        {
            _context = context;
        }

        // GET: api/<CoachController>
        [HttpGet]
        public ActionResult<IEnumerable<Coach>> Get()
        {
            return _context.Coaches.ToList();
        }

        // GET api/<CoachController>/5
        [HttpGet("{id}")]
        public ActionResult<Coach> Get(int id)
        {
            return _context.Coaches.FirstOrDefault(c => c.Id == id);
        }

        // POST api/<CoachController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CoachController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoachController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
