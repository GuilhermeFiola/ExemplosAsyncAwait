using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto5.Controllers
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

        // Task criada sem o CancellationToken
        // Verificar que ao cancelar a request a operação irá continuar
        // Problemas de desempenho especialmente quando possui outras comunicações. Ex: Banco de dados
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();

            return await Task.Run(async () =>
            {
                await Task.Delay(5000);
                Console.WriteLine("Espera de 5 segundos...");

                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                });
            });
        }

        // Usando o CancellationToken a requisição é interrompida e é possível tratar a exception
        [HttpGet("cancellation")]
        public async Task<IEnumerable<WeatherForecast>> Get(CancellationToken cancellationToken)
        {
            var rng = new Random();

            try
            {
                return await Task.Run(async () =>
                {
                    await Task.Delay(5000, cancellationToken);
                    Console.WriteLine("Espera de 5 segundos...");

                    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    });
                }, cancellationToken);
            }
            catch(TaskCanceledException)
            {
                return Enumerable.Empty<WeatherForecast>();
            }
        }
    }
}
