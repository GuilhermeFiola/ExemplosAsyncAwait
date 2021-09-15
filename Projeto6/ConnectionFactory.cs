using System.Threading.Tasks;

namespace Projeto6
{
    public class ConnectionFactory
    {
        public async Task<Connection> CriarConnectionAsync()
        {
            return await Task.FromResult(new Connection() { ConnectionString = "TESTE" });
        }
    }

    public class Connection
    {
        public string ConnectionString { get; set; }
    }
}
