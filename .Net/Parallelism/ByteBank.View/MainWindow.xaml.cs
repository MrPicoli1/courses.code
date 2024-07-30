using ByteBank.Core.Model;
using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;
        private CancellationTokenSource _cts;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private async void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnCancelar.IsEnabled = true;
            BtnProcessar.IsEnabled = false;

            _cts = new CancellationTokenSource();

            var contas = r_Repositorio.GetContaClientes();

            PgsProgresso.Maximum = contas.Count();

            LimparView();

            var inicio = DateTime.Now;
           
           

            var resultado = await ConsolidarContas(contas, _cts.Token);
            var final = DateTime.Now;

            AtualizarView(resultado, final - inicio);

            BtnProcessar.IsEnabled = true;
            BtnCancelar.IsEnabled = false;
           
        }


        private void LimparView()
        {
            LstResultados.ItemsSource = null;
            TxtTempo.Text = null;
            PgsProgresso.Value = 0;
        }

        private async Task<string[]> ConsolidarContas(IEnumerable<ContaCliente> contas, CancellationToken ct)
        {
            
           var tasks = contas.Select(conta =>Task.Factory.StartNew(() => 
           {
               ct.ThrowIfCancellationRequested();
               var consolidacao = r_Servico.ConsolidarMovimentacao(conta);
               PgsProgresso.Dispatcher.Invoke(() => PgsProgresso.Value++);
               ct.ThrowIfCancellationRequested();
               return consolidacao;
               
           })
            );

            return await Task.WhenAll(tasks);

            
        }

        private void AtualizarView(IEnumerable<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count()} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            BtnCancelar.IsEnabled = false;
            _cts.Cancel();

        }

    }
}
