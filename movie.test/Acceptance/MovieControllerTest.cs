using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using RazorPagesMovie.Models;

namespace movie.test.Acceptance
{
    [TestFixture]
    public class MovieControllerTest
    {
        private WebApplicationFactory<RazorPagesMovie.Startup> _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void SetUp()
        {
            _factory = new WebApplicationFactory<RazorPagesMovie.Startup>();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task GET_GetItems()
        {
            var response = await _client.GetAsync("/api/movie");

            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var stringResult = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(stringResult).ToList();
            Assert.That(movies, Has.Count.EqualTo(4));

            var firstMovie = movies.First();
            Assert.AreEqual(firstMovie.Id, 1);
        }
        
        [Test]
        public async Task GET_GetItemById()
        {
            var response = await _client.GetAsync("/api/movie/1");

            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var stringResult = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<Movie>(stringResult);

            Assert.AreEqual(movies.Id, 1);
            Assert.AreEqual(movies.Genre, "Romantic Comedy");
            Assert.AreEqual(movies.Price, new decimal(7.99));
            Assert.AreEqual(movies.Rating, "R");
            Assert.AreEqual(movies.ReleaseDate, new DateTime(1989,2,12));
            Assert.AreEqual(movies.Title, "When Harry Met Sally");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}