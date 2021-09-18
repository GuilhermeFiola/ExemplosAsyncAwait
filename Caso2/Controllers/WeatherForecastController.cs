using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ExemploRepository _repository;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            ExemploRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            // Pense no método como um envio de mensagem ou e-mail

            // Chamada do processo
            //ProcessoRodandoEmBackground();

            // Chamada do processo com Task.Run
            Task.Run(ProcessoRodandoEmBackground);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //// Método async sem retorno(void)
        //private async void ProcessoRodandoEmBackground()
        //{
        //    var resultado = await _repository.GetValorAsync();
        //    await Task.Delay(2000);
        //    throw new Exception("Erro no envio de e-mail!!!");
        //    Console.WriteLine($"Resultado: {resultado}");
        //}

        // Método async com retorno(Task)
        private async Task ProcessoRodandoEmBackground()
        {
            //Pode envolver no try/catch para pegar a exception
            //try
            //{
                var resultado = await _repository.GetValorAsync();
                await Task.Delay(2000);
                throw new Exception("Erro no envio de e-mail!!!");
                Console.WriteLine($"Resultado: {resultado}");
            //}
            //catch(Exception ex) 
            //{
            //    Console.WriteLine(ex);
            //    throw;
            //}
        }
    }
}
