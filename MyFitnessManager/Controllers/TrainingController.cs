﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFitnessManager.Db.Entities;
using MyFitnessManager.Db.Repositories;
using MyFitnessManager.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFitnessManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository _repository;
        private readonly ICoachRepository _coachRepository;
        private readonly IHallRepository _hallRepository;

        public TrainingController(
            ITrainingRepository repository,
            ICoachRepository coachRepository,
            IHallRepository hallRepository)
        {
            _repository = repository;
            _coachRepository = coachRepository;
            _hallRepository = hallRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TrainingAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coach = await _coachRepository.GetAsync(model.CoachId);
            if (coach == null)
            {
                return BadRequest($"No coach was found with Id:{model.CoachId}");
            }

            var hall = await _hallRepository.GetAsync(model.HallId);
            if (hall == null)
            {
                return BadRequest($"No hall was found with Id:{model.HallId}");
            }

            var dateFrom = model.StartTime.AddHours(-1);
            var dateTo = model.StartTime.AddHours(1);

            var conflictingTraining = _repository
                .GetForRange(dateFrom, dateTo)
                .Where(t => t.CoachId == model.CoachId 
                                 || t.HallId == model.HallId);

            if (conflictingTraining.Any())
            {
                return BadRequest($"Cannot add training for this time" +
                                  $" (Coach or hall busy for this time)");
            }

            var entity = new Training()
            {
                Title = model.Title,
                TrainingType = model.TrainingType,
                CoachId = model.CoachId,
                HallId = model.HallId,
                StartTime = model.StartTime
            };
           // try
          //  {
                _repository.Create(entity);
                await _repository.SaveChangesAsync();
         //   }
        //    catch (Exception e)
         //   {
         //       return BadRequest();
        //    }
          
            return Created(string.Empty, entity);

        }
    }

 
}
