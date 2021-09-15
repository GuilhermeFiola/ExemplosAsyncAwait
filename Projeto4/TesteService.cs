using System;
using System.Threading.Tasks;

namespace Projeto4
{
    internal class TesteService
    {
        public TesteService()
        {
        }

        public async Task<int> GetValorAsync()
        {
            return await Task.FromResult(10);
        }
    }
}