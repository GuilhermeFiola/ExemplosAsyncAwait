using System;
using System.Threading.Tasks;

namespace Projeto3
{
    internal class TesteService
    {
        public TesteService()
        {
        }

        public async Task<int> MultiplicaValorAsync(int valor)
        {
            // Task.Run gasta uma thread do pool sem fazer algo com isso
            // Está relacionada a um gasto de recursos
            //return await Task.Run(() => valor * 2);

            // Usar Task.FromResult não gasta uma thread do pool
            // Método mais eficiente
            return await Task.FromResult(valor * 2);
        }

        // Outra maneira de retornar de maneira mais eficiente ainda é utilizando ValueTask
        // ValueTask é uma struct e melhor eficiente em alocação de memória
        // Está disponível a partir do C# 7.0
        //public async ValueTask<int> MultiplicaValorAsync(int valor)
        //{
            
        //    return await new ValueTask<int>(valor * 2);
        //}
    }
}