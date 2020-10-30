using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MyFitnessManager.Db;

namespace MyFitnessManager.Tests
{
    public class BaseApiTest
    {
        protected readonly HttpClient _client;
        protected readonly FitnessDbContext _context;

        protected static Random Random = new Random();

        public BaseApiTest()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseSetting("DbConnectionString",
                    @"Data Source=DESKTOP-A4P69B9\\SQLEXPRESS;Initial Catalog=FitnessDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .UseStartup<Startup>();


            var server = new TestServer(webHostBuilder);
            _context = server.Services.GetService<FitnessDbContext>();
            _client = server.CreateClient();

        }

        protected static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcefghijklmnopqrstuvmxyz";
            return new string(
                Enumerable
                    .Repeat(chars, length)
                    .Select(s => s[Random.Next(s.Length)])
                    .ToArray());
        }
    }
}
