using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using movie.test.Utils;
using NUnit.Framework;

namespace movie.test.Acceptance
{

    [TestFixture]
    public class MovieControllerTest
    {
        private WebApplicationFactory<RazorPagesMovie.Startup> _factory;

        [OneTimeSetUp]
        public void SetUp()
        {
            _factory = new ApiWebApplicationFactory();
        }

        [Test]
        public async Task GET_GetItems()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/movie");

            response.EnsureSuccessStatusCode();

//            var t = response.Content.ToString();
        }

    }
}
