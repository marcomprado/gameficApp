using System;
using System.Windows.Forms;
using GamificacaoApp.Forms;
using GamificacaoApp.Services;

namespace GamificacaoApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            this.Text = "Sistema de Gamificação";
            this.Width = 400;
            this.Height = 350;

            // Botão Cadastro Funcionário
            Button btnCadastroFuncionario = new Button();
            btnCadastroFuncionario.Text = "Cadastro Funcionário";
            btnCadastroFuncionario.Width = 200;
            btnCadastroFuncionario.Height = 40;
            btnCadastroFuncionario.Top = 20;
            btnCadastroFuncionario.Left = 100;
            btnCadastroFuncionario.Click += BtnCadastroFuncionario_Click;
            this.Controls.Add(btnCadastroFuncionario);

            // Botão Cadastro Projeto
            Button btnCadastroProjeto = new Button();
            btnCadastroProjeto.Text = "Cadastro Projeto";
            btnCadastroProjeto.Width = 200;
            btnCadastroProjeto.Height = 40;
            btnCadastroProjeto.Top = 70;
            btnCadastroProjeto.Left = 100;
            btnCadastroProjeto.Click += BtnCadastroProjeto_Click;
            this.Controls.Add(btnCadastroProjeto);

            // Botão Cadastro Pontuação
            Button btnCadastroPontuacao = new Button();
            btnCadastroPontuacao.Text = "Cadastro Pontuação";
            btnCadastroPontuacao.Width = 200;
            btnCadastroPontuacao.Height = 40;
            btnCadastroPontuacao.Top = 120;
            btnCadastroPontuacao.Left = 100;
            btnCadastroPontuacao.Click += BtnCadastroPontuacao_Click;
            this.Controls.Add(btnCadastroPontuacao);

            // Botão Realizar Gamificação
            Button btnRealizarGameficacao = new Button();
            btnRealizarGameficacao.Text = "Realizar Gamificação";
            btnRealizarGameficacao.Width = 200;
            btnRealizarGameficacao.Height = 40;
            btnRealizarGameficacao.Top = 170;
            btnRealizarGameficacao.Left = 100;
            btnRealizarGameficacao.Click += BtnRealizarGameficacao_Click;
            this.Controls.Add(btnRealizarGameficacao);

            // Botão Gerar Relatório
            Button btnGerarRelatorio = new Button();
            btnGerarRelatorio.Text = "Gerar Relatório";
            btnGerarRelatorio.Width = 200;
            btnGerarRelatorio.Height = 40;
            btnGerarRelatorio.Top = 220;
            btnGerarRelatorio.Left = 100;
            btnGerarRelatorio.Click += BtnGerarRelatorio_Click;
            this.Controls.Add(btnGerarRelatorio);
        }

        private void BtnCadastroFuncionario_Click(object sender, EventArgs e)
        {
            using (var form = new CadastroFuncionarioForm())
            {
                form.ShowDialog();
            }
        }

        private void BtnCadastroProjeto_Click(object sender, EventArgs e)
        {
            using (var form = new CadastroProjetoForm())
            {
                form.ShowDialog();
            }
        }

        private void BtnCadastroPontuacao_Click(object sender, EventArgs e)
        {
            using (var form = new CadastroPontuacaoForm())
            {
                form.ShowDialog();
            }
        }

        private void BtnRealizarGameficacao_Click(object sender, EventArgs e)
        {
            using (var form = new RealizarGameficacaoForm())
            {
                form.ShowDialog();
            }
        }

        private void BtnGerarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                var gameficacaoService = new GameficacaoService();
                var funcionarioService = new FuncionarioService();
                var relatorioService = new RelatorioService();

                var dados = gameficacaoService.ListarTodos();
                var funcionarios = funcionarioService.ListarTodos();

                string caminho = "relatorio_gamificacao.xlsx";

                relatorioService.ExportarRelatorio(dados, funcionarios, caminho);

                MessageBox.Show($"Relatório gerado com sucesso em:\n{caminho}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message);
            }
        }
    }
}

