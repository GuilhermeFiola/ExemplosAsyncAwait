using System;

namespace Projeto4
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new TesteService();

            // Esse tipo de chamada pode causar deadlocks
            // Por outro lado .NET Core ajusta isso por não possuir um contexto de sincronização
            // Mesmo assim vai funcionar
            // Vale para .Result ou .Wait
            // Porém, o maior problema é gastar 2 threads do pool
            // No final acaba tendo um gasto maior de recursos
            var numero = service.GetValorAsync().Result;
            service.GetValorAsync().Wait();

            // No final, sempre prefira utilizar await na chamada dos métodos assíncronos
            //var numero = await service.GetValorAsync();

            Console.WriteLine($"Resultado: {numero}");
        }
    }
}
