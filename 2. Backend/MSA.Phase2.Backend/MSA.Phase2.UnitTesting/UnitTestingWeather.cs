using MSA.Phase2.Backend.Services;
using MSA.Phase2.Backend.Models;
using NSubstitute;
using Microsoft.Extensions.Configuration;
using MSA.Phase2.Backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MSA.Phase2.UnitTesting
{
    public class TestWeather
    {
        private WeatherController controller;

        [SetUp]
        public void Setup()
        {
            var clientFactory = Substitute.For<IHttpClientFactory>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org/data/3.0/onecall");
            clientFactory.CreateClient("weather").Returns(client);

            var config = Substitute.For<IConfiguration>();
            config["WEATHER_API_KEY"].Returns("key");
            config["Units"].Returns("standard");

            controller = new WeatherController(clientFactory, config);
        }

        [Test]
        public async Task TestGetAllWeather()
        {
            OkObjectResult res = (OkObjectResult)await controller.GetAllWeather();
            if (res.Value == null)
            {
                Assert.Fail();
            }
            Dictionary<string, string>? result = res.Value as Dictionary<string, string>;
            Assert.That(result?.Count, Is.EqualTo(2));
            Assert.That(result?.ContainsKey("Hamilton") ?? false);
        }
    }
}