using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieApi.Controller;
using NUnit.Framework;
using RazorPagesMovie.Repositories;

namespace movie.test.Unit
{

    [TestFixture]
    public class MovieControllerTest
    {

        [Test]
        public async Task Test_GetItems()
        {

            var data = new List<RazorPagesMovie.Models.Movie>
            {
                new RazorPagesMovie.Models.Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R"
                }
            };


            var repository = new Mock<IMovieRepository>();
            repository.Setup(
                r => r.ToListAsync()
            )
            .ReturnsAsync(data);


            var controller = new MovieController(repository.Object);

            var result = await controller.GetItems();
            var k = result.Result as OkObjectResult;
            Assert.AreEqual(data, k.Value);
        }

        [Test]
        public async Task Test_GetById()
        {
            var data = new RazorPagesMovie.Models.Movie
            {

                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-2-12"),
                Genre = "Romantic Comedy",
                Price = 7.99M,
                Rating = "R"
            }
            ;

            var repository = new Mock<IMovieRepository>();
            repository.Setup(
                r => r.FindAsync(228)
            )
            .ReturnsAsync(data);

            var controller = new MovieController(repository.Object);

            var result = await controller.GetById(228);
            var k = result.Result as OkObjectResult;
            Assert.AreEqual(data, k.Value);
        }

        [Test]
        public async Task Test_GetById_Not_Found()
        {
            var repository = new Mock<IMovieRepository>();
            repository.Setup(
                r => r.FindAsync(228)
            )
            .Returns(Task.FromResult<RazorPagesMovie.Models.Movie >(null));

            var controller = new MovieController(repository.Object);
            
            var result = await controller.GetById(228);
            Assert.IsInstanceOf(typeof(NotFoundResult), result.Result);
        }
    }
}