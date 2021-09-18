using System.Threading.Tasks;

namespace Projeto1
{
    internal class ExemploRepository
    {
        public ExemploRepository()
        {
        }

        public async Task<int> GetValorAsync()
        {
            return await Task.FromResult(10);
        }
    }
}