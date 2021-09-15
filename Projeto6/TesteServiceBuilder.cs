using System.Threading.Tasks;

namespace Projeto6
{
    public class TesteServiceBuilder
    {
        private readonly Connection _connection;

        public TesteServiceBuilder(Connection connection)
        {
            _connection = connection;
        }

        public static async Task<TesteServiceBuilder> CriarConnectionAsync(ConnectionFactory connectionFactory)
        {
            return new TesteServiceBuilder(await connectionFactory.CriarConnectionAsync());
        }
    }
}
