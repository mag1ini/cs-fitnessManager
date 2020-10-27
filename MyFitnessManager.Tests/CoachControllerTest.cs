using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MyFitnessManager.Db.Entities;
using Newtonsoft.Json;
using Xunit;

namespace MyFitnessManager.Tests
{
    public class CoachControllerTest : BaseApiTest
    {
        
        private string ApiUrl = "/api/coach";

        [Fact]
        public async Task GetAll_Returns_List_Of_Coaches()
        {
            var generatedCoaches =
                Enumerable
                    .Range(0, 2)
                    .Select(_ => GetRandomCoach())
                    .ToList();

            await _context.Coaches.AddRangeAsync(generatedCoaches);

            await _context.SaveChangesAsync();

            var coachesJson = await _client.GetStringAsync(ApiUrl);
            var coaches = JsonConvert.DeserializeObject<List<Coach>>(coachesJson);

            foreach (var genereatedCoach in generatedCoaches)
            {
                Assert.Contains(coaches, c =>
                    c.Firstname == genereatedCoach.Firstname
                    && c.Lastname == genereatedCoach.Lastname
                    && c.Speciality == genereatedCoach.Speciality);
            }

            _context.Coaches.RemoveRange(generatedCoaches);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task Get_Return_Coach()
        {
            var generatedCoach = GetRandomCoach();

            await _context.Coaches.AddAsync(generatedCoach);
            await _context.SaveChangesAsync();

            var responseCoachJson = await
                _client.GetStringAsync(ApiUrl + $"/{generatedCoach.Id}");

            var coach = JsonConvert.DeserializeObject<Coach>(responseCoachJson);

            var actual = generatedCoach.Id == coach.Id
                         && generatedCoach.Firstname == coach.Firstname
                         && generatedCoach.Lastname == coach.Lastname;

            Assert.Equal(true, actual);

            _context.Coaches.Remove(generatedCoach);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task Post_Valid_Data_Returns_OK()
        {
            var generatedValidCoach = GetRandomCoach();

            var content = new StringContent(
                JsonConvert.SerializeObject(generatedValidCoach),
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync(ApiUrl, content);

            await _context.SaveChangesAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            #region REMOVE Coach using GetAll and Delete Methods
            var coachesJson = await _client.GetStringAsync(ApiUrl);
            var coaches = JsonConvert.DeserializeObject<List<Coach>>(coachesJson);

            var idToDelete =
                coaches
                    .Where(c =>
                        c.Firstname == generatedValidCoach.Firstname
                        && c.Lastname == generatedValidCoach.Lastname)
                    .Select(c => c.Id)
                    .FirstOrDefault();

            await _client.DeleteAsync(ApiUrl + $"/{idToDelete}");
            #endregion
        }

        [Fact]
        public async Task Post_Invalid_Data_Returns_BadRequest()
        {
            var invalidCoach = new Coach();

            var content = new StringContent(
                JsonConvert.SerializeObject(invalidCoach),
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync(ApiUrl, content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Delete_Returns_NoContent()
        {
            var generatedCoach = GetRandomCoach();

            await _context.Coaches.AddAsync(generatedCoach);
            await _context.SaveChangesAsync();

            var response = await _client.DeleteAsync(ApiUrl + $"/{generatedCoach.Id}");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        }

        private static Coach GetRandomCoach()
        {
            return new Coach
            {
                Firstname = GenerateRandomString(10),
                Lastname = GenerateRandomString(10),
                Speciality = (TrainingType)
                    Random.Next(1, Enum.GetNames(typeof(TrainingType)).Length)
            };
        }

    }
}
