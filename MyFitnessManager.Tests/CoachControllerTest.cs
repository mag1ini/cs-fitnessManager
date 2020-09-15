using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MyFitnessManager.Db.Entities;
using Newtonsoft.Json;
using Xunit;

namespace MyFitnessManager.Tests
{
    public class CoachControllerTest : BaseApiTest
    {
        private static Coach GetRandomCoach()
        {
            return new Coach
            {
                Firstname = GenerateRandomString(7),
                Lastname = GenerateRandomString(14),
                Speciality = (TrainingType)
                    Random.Next(1, Enum.GetNames(typeof(TrainingType)).Length)
            };
        }
        [Fact]
        public async Task GetAll_Returns_List_Of_Coaches()
        {
            var coach1 = GetRandomCoach();
            var coach2 = GetRandomCoach();
       
           await _context.Coaches.AddRangeAsync(coach1,coach2);

           await _context.SaveChangesAsync();

           var coachesJson = await _client.GetStringAsync("/api/coach");
           var coaches = JsonConvert.DeserializeObject<List<Coach>>(coachesJson);

           Assert.Contains(coaches,c =>
                c.Firstname == coach1.Firstname
                && c.Lastname == coach1.Lastname
                && c.Speciality == coach1.Speciality);

           Assert.Contains(coaches, c =>
               c.Firstname == coach2.Firstname
               && c.Lastname == coach2.Lastname
               && c.Speciality == coach2.Speciality);
        }
    }
}
