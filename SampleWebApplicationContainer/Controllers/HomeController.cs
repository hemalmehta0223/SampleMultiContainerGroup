using System.Diagnostics;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebApplicationContainer.Models;

namespace SampleWebApplicationContainer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var apiUrl = _configuration.GetValue<string>("apiUrl");
            var weatherForecastList = await apiUrl.GetJsonAsync<List<WeatherForecast>>(cancellationToken: cancellationToken);

            return View(weatherForecastList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
