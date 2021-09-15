using System.Threading.Tasks;

namespace Projeto2
{
    public class ExemploRepository
    {
        public async Task<int> GetValorAsync()
        {
            return await Task.FromResult(10);
        }
    }
}
