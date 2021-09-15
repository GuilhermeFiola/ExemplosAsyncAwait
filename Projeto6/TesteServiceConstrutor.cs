using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto6
{
    public class TesteServiceConstrutor
    {
        private readonly Connection _connection;

        public TesteServiceConstrutor(ConnectionFactory connectionFactory)
        {
            // Essa chamada sincroniza a call, é uma má prática utilizar dessa maneira
            // O mesmo caso que foi mostrado anteriormente no Projeto4
            // Pode se imaginar o problema em chamadas Scoped ou Transient de um método
            _connection = connectionFactory.CriarConnectionAsync().Result;
        }
    }
}
