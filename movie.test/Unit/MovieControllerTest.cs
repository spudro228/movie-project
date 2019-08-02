

using MovieApi.Controller;
using NUnit.Framework;
using RazorPagesMovie.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System;

namespace UnitTest.Movie{

    [TestFixture]
    public class MovieControllerTest{
        
        [Test]
        public void Test1(){

            var data = new List<RazorPagesMovie.Models.Movie>();
            data.Add(
                new RazorPagesMovie.Models.Movie {
                
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R"
                }
            );

            var  dbContext = new Mock<DbContextOptions>();

            // var mockContext  =  new Mock<RazorPagesMovieContext>();
            // mockContext.Setup(
            //     context => context.Movie.ToListAsync()
            // ).ReturnsAsync(data);

            // var controller =  new MovieController(mockContext.Object);
            // Assert.AreEqual(1,1);
        }
    }
}