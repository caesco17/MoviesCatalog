using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MoviesCatalog.Web.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace MoviesCatalog.Test
{
    [TestClass]
    public class APITest
    {
        private HttpClient _httpClient;
        private HttpRequestMessage requestMessage;

        public APITest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();

            var client = webAppFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.RemoveAll(typeof(IHostedService));
                    services.AddAuthentication(o =>
                    {
                        o.DefaultAuthenticateScheme = TestAuthHandler.DefaultScheme;
                        o.DefaultChallengeScheme = TestAuthHandler.DefaultScheme;
                    }).AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", _ => { });
                });
            }).CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
            
            _httpClient = client;
        }

 
        [TestMethod]
        public async Task DefaultUser_Auth()
        {
            LoginView user_cred = new LoginView() { Email= "admin@gmail.com", Password="password" };

            var json = JsonConvert.SerializeObject(user_cred);
            var stringContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            requestMessage = new HttpRequestMessage(HttpMethod.Post, ("Account/Authenticate"));
            requestMessage.Content = stringContent;

            var postResponse = await _httpClient.SendAsync(requestMessage);
            var content = postResponse.Content.ReadAsStringAsync().Result;

            Response<string> res = JsonConvert.DeserializeObject<Response<string>>(content);
            Console.WriteLine(res.Data);

            Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);
        }

        [TestMethod]
        public async Task GetUser_Roles()
        {
            requestMessage = new HttpRequestMessage(HttpMethod.Get, "Account/Roles");
            var response = await _httpClient.SendAsync(requestMessage);

            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetCategories()
        {
            requestMessage = new HttpRequestMessage(HttpMethod.Get, "Movies/Categories");
            var response = await _httpClient.SendAsync(requestMessage);

            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        public async Task GetMovie()
        {
            requestMessage = new HttpRequestMessage(HttpMethod.Get, "Movies?PageNumber=1&PageSize=2&OrderBy=Name&filter.ReleaseYear=2006");
            var response = await _httpClient.SendAsync(requestMessage);

            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetRatings()
        {
            requestMessage = new HttpRequestMessage(HttpMethod.Get, "/Ratings");
            var response = await _httpClient.SendAsync(requestMessage);

            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}