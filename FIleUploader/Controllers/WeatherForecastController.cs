using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace FIleUploader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        ///     Uploads a file
        /// </summary>
        [HttpPost]
        [Route("/api/files")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<StorageObject>> CreateFile()
        {
            using (Stream body = HttpContext.Request.Body)
            {
                if (body.CanRead)
                {
                    var fileStream = System.IO.File.Create("C:\\Users\\FlorinDraghici\\source\\repos\\FIleUploader\\Upload\\myUpload.txt");
                    await body.CopyToAsync(fileStream);
                    fileStream.Close();
                }
            }
            ActionResult<StorageObject> actionResult = new ActionResult<StorageObject>(new StorageObject("10", "", "", "", DateTimeOffset.Now, "", DateTimeOffset.Now, ""));
            return actionResult;
        }
    }
}