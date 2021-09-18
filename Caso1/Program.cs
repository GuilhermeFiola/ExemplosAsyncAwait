using System;
using System.Threading.Tasks;

namespace Projeto1
{
    // Uma vez async, sempre async
    class Program
    {
        // Código com chamada síncrona/assíncrona
        static void Main(string[] args)
        {
            var repository = new ExemploRepository();
            var num = repository.GetValorAsync().Result; // Sincronização da chamada
            Console.WriteLine($"O valor do número é {num}");
        }

        //// Código com chamada assíncrona
        //static async Task Main(string[] args) // Com Controller é usado o IAsyncResult
        //{
        //    var repository = new ExemploRepository();
        //    var num = await repository.GetValorAsync();
        //    Console.WriteLine($"O valor do número é {num}");
        //}
    }
}
