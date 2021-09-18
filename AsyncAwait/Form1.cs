using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var retorno = await RetornaRequestAsync();
            //var retorno = RetornaRequest();
            richTextBox1.Text = retorno;
        }

        private async Task<string> RetornaRequestAsync()
        {
            var httpClient = new HttpClient();

            var tarefa = httpClient.GetAsync("http://google.com.br");

            var dataHoraConsulta = DateTime.Now;

            await Task.Delay(5000);

            var request = await tarefa;

            return string.Join(" - ", request, dataHoraConsulta);
        }

        private string RetornaRequest()
        {
            var httpClient = new HttpClient();

            var request = httpClient.GetAsync("http://google.com.br").Result;

            Thread.Sleep(5000);

            var dataHoraConsulta = DateTime.Now;

            return string.Join(" - ", request, dataHoraConsulta);
        }
    }
}
