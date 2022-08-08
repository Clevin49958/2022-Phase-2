using MSA.Phase2.Backend.Services;
using MSA.Phase2.Backend.Models;
using NSubstitute;
using Microsoft.Extensions.Configuration;
using MSA.Phase2.Backend.Controllers;

namespace MSA.Phase2.UnitTesting
{
    public class TestWeather
    {
        private WeatherController controller;
        [SetUp]
        public void Setup()
        {
            var clientFactory = Substitute.For<IHttpClientFactory>();
            var client = Substitute.For<HttpClient>();
            // client.GetAsync($"/data/2.5/weather?lat=-36.8&lon=174.7&appid=key&units=unit").retur
            var httpResponse = Substitute.For<HttpResponseMessage>();
            httpResponse.Content.ReadAsStreamAsync().Returns(new Task(() => "response"));

            client.GetAsync(Arg.Any<string>()).ReturnsForAnyArgs(httpResponse);
            clientFactory.CreateClient("weather").Returns(client);

            var config = Substitute.For<IConfiguration>();
            config["WEATHER_API_KEY"].Returns("key");
            config["Units"].Returns("unit");

            controller = new WeatherController(clientFactory, config);
        }

        [Test]
        public async Task TestGetAllWeather()
        {
            var res = await controller.GetAllWeather();
            Assert.That(res, Is.Null);
        }
    }
}