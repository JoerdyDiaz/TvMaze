using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Json;
using System.Text;


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
        public async Task JobPeopleSuccessStatusCode()
        {
            var requestUrl = "/api/JobPeople";
            _client.DefaultRequestHeaders.Add("x-api-key", "TvMaze*!$");
            var response = await _client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("Job ejecutado correctamente.", responseString);
        }



        [TestMethod]
        public async Task JobTvShowsSuccessStatusCode()
        {
            var requestUrl = "/api/JobTvShow";
            _client.DefaultRequestHeaders.Add("x-api-key", "TvMaze*!$");
            var response = await _client.GetAsync(requestUrl);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("Job ejecutado correctamente.", responseString);
        }

        [TestMethod]
        public async Task JobPeopleNoAutorizado()
        {

            var requestUrl = "/api/JobPeople";
            _client.DefaultRequestHeaders.Add("x-api-key", "TvMaze*!$$%#$%"); // API KEY erroneo

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            HttpResponseMessage response = await _client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public async Task JobTvShowNoAutorizado()
        {

            var requestUrl = "/api/JobTvShow";
            _client.DefaultRequestHeaders.Add("x-api-key", "TvMaze*!$$%#$%"); // API KEY erroneo

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            HttpResponseMessage response = await _client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
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
        public void GetApiPeopleSuccess()
        {
            var requestUrl = "/api/People";
            var response = _client.GetAsync(requestUrl).Result;
            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(responseString);
        }


        [TestMethod]
        public void GetApiPeopleByIdSuccess()
        {
            var requestUrl = "/api/People/1";
            var response = _client.GetAsync(requestUrl).Result;
            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(responseString);
        }

        [TestMethod]
        public void GetApiTvShowIdSuccess()
        {
            var requestUrl = "/api/Show/1";
            var response = _client.GetAsync(requestUrl).Result;
            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(responseString);
        }


    }
}