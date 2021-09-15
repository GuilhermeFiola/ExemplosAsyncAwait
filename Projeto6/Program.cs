using System;
using System.Threading.Tasks;

namespace Projeto6
{
    class Program
    {
        static async Task Main(string[] args)
        // static void Main(string[] args)
        {
            
            var connectionFactory = new ConnectionFactory();

            // Utilização de criação de conexão pelo construtor de maneira assíncrona
            //var service = new TesteServiceConstrutor(connectionFactory);

            // Utilização de criação de método builder pelo construtor de maneira assíncrona
            var service = await TesteServiceBuilder.CriarConnectionAsync(connectionFactory);
        }
    }
}
