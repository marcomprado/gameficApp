using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GamificacaoApp.Models;
using GamificacaoApp.Services;

namespace GamificacaoApp.Forms
{
    public partial class RealizarGameficacaoForm : Form
    {
        private GameficacaoService gameficacaoService = new GameficacaoService();
        private FuncionarioService funcionarioService = new FuncionarioService();
        private ProjetoService projetoService = new ProjetoService();
        private PontuacaoService pontuacaoService = new PontuacaoService();

        private ComboBox cbFuncionarios;
        private ComboBox cbProjetos;
        private ComboBox cbFase;
        private DateTimePicker dtpData;
        private Button btnSalvar;

        private List<Funcionario> funcionarios;
        private List<Projeto> projetos;

        public RealizarGameficacaoForm()
        {
            InicializarComponentes();
            CarregarFuncionarios();
            CarregarProjetos();
            CarregarFases();
        }

        private void InicializarComponentes()
        {
            this.Text = "Realizar Gamificação";
            this.Width = 400;
            this.Height = 300;

            Label lblFuncionario = new Label() { Text = "Funcionário:", Top = 20, Left = 20, Width = 120 };
            cbFuncionarios = new ComboBox() { Top = 20, Left = 150, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblProjeto = new Label() { Text = "Projeto:", Top = 60, Left = 20, Width = 120 };
            cbProjetos = new ComboBox() { Top = 60, Left = 150, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblFase = new Label() { Text = "Fase:", Top = 100, Left = 20, Width = 120 };
            cbFase = new ComboBox() { Top = 100, Left = 150, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblData = new Label() { Text = "Data:", Top = 140, Left = 20, Width = 120 };
            dtpData = new DateTimePicker() { Top = 140, Left = 150, Width = 200, Format = DateTimePickerFormat.Short };

            btnSalvar = new Button() { Text = "Registrar", Top = 190, Left = 150, Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;

            this.Controls.Add(lblFuncionario);
            this.Controls.Add(cbFuncionarios);
            this.Controls.Add(lblProjeto);
            this.Controls.Add(cbProjetos);
            this.Controls.Add(lblFase);
            this.Controls.Add(cbFase);
            this.Controls.Add(lblData);
            this.Controls.Add(dtpData);
            this.Controls.Add(btnSalvar);
        }

        private void CarregarFuncionarios()
        {
            funcionarios = funcionarioService.ListarTodos();
            cbFuncionarios.DataSource = funcionarios;
            cbFuncionarios.DisplayMember = "Nome";
            cbFuncionarios.ValueMember = "Id";
        }

        private void CarregarProjetos()
        {
            projetos = projetoService.ListarTodos();
            cbProjetos.DataSource = projetos;
            cbProjetos.DisplayMember = "Nome";
            cbProjetos.ValueMember = "Id";
        }

        private void CarregarFases()
        {
            cbFase.Items.Clear();
            cbFase.Items.AddRange(new string[] { "3D conceito", "3D final", "Recognition", "Detalhamento" });
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (cbFuncionarios.SelectedItem == null || cbProjetos.SelectedItem == null || cbFase.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione funcionário, projeto e fase.");
                return;
            }

            int funcionarioId = ((Funcionario)cbFuncionarios.SelectedItem).Id;
            int projetoId = ((Projeto)cbProjetos.SelectedItem).Id;
            string fase = cbFase.SelectedItem.ToString();
            DateTime data = dtpData.Value.Date;

            // Buscar pontuação da fase no projeto
            var pontuacoes = pontuacaoService.ListarPorProjeto(projetoId);
            var pontuacaoFase = pontuacoes.Find(p => p.Fase == fase);

            if (pontuacaoFase == null)
            {
                MessageBox.Show("Pontuação para essa fase no projeto não cadastrada.");
                return;
            }

            var gameficacao = new Gameficacao
            {
                FuncionarioId = funcionarioId,
                ProjetoId = projetoId,
                Fase = fase,
                Data = data,
                Pontos = pontuacaoFase.Pontos
            };

            try
            {
                gameficacaoService.Registrar(gameficacao);
                MessageBox.Show("Gamificação registrada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar gamificação: " + ex.Message);
            }
        }
    }
}
