using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TvMazeApi;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Hosting;


namespace TestUnitProyect
{
    [TestClass]
    public class ApiTest
    {

        private readonly HttpClient _client;

        private readonly WebApplicationFactory<Program> _factory;

        public ApiTest()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestMethod]
        public void GetApiShowSuccess()
        {

            var requestUrl = "/api/Show";

            var response = _client.GetAsync(requestUrl).Result;

            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(responseString);
        }

        [TestMethod]
        public void GetApiPeopleSucces()
        {

            var requestUrl = "/api/People";

            var response = _client.GetAsync(requestUrl).Result;

            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(responseString);
        }
    }
}