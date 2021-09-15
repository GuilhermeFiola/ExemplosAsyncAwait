using System;

namespace Projeto3
{
    class Program
    {
        // Maneiras mais eficientes de retornar a Task
        async static void Main(string[] args)
        {
            var service = new TesteService();
            var numero = await service.MultiplicaValorAsync(10);

            Console.WriteLine($"Resultado: {numero}");
        }
    }
}
