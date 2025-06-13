using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GamificacaoApp.Models;
using GamificacaoApp.Services;

namespace GamificacaoApp.Forms
{
    public partial class CadastroPontuacaoForm : Form
    {
        private PontuacaoService pontuacaoService = new PontuacaoService();
        private ProjetoService projetoService = new ProjetoService();

        private ComboBox cbProjetos;
        private ComboBox cbFase;
        private NumericUpDown nudPontos;
        private Button btnSalvar;

        private List<Projeto> projetos;

        public CadastroPontuacaoForm()
        {
            InicializarComponentes();
            CarregarProjetos();
        }

        private void InicializarComponentes()
        {
            this.Text = "Cadastro de Pontuação";
            this.Width = 400;
            this.Height = 250;

            Label lblProjeto = new Label() { Text = "Projeto:", Top = 20, Left = 20, Width = 120 };
            cbProjetos = new ComboBox() { Top = 20, Left = 150, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblFase = new Label() { Text = "Fase:", Top = 60, Left = 20, Width = 120 };
            cbFase = new ComboBox() { Top = 60, Left = 150, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cbFase.Items.AddRange(new string[] { "3D conceito", "3D final", "Recognition", "Detalhamento" });

            Label lblPontos = new Label() { Text = "Pontos:", Top = 100, Left = 20, Width = 120 };
            nudPontos = new NumericUpDown() { Top = 100, Left = 150, Width = 200, Minimum = 0, Maximum = 1000 };

            btnSalvar = new Button() { Text = "Salvar", Top = 150, Left = 150, Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;

            this.Controls.Add(lblProjeto);
            this.Controls.Add(cbProjetos);
            this.Controls.Add(lblFase);
            this.Controls.Add(cbFase);
            this.Controls.Add(lblPontos);
            this.Controls.Add(nudPontos);
            this.Controls.Add(btnSalvar);
        }

        private void CarregarProjetos()
        {
            projetos = projetoService.ListarTodos();
            cbProjetos.DataSource = projetos;
            cbProjetos.DisplayMember = "Nome";
            cbProjetos.ValueMember = "Id";
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (cbProjetos.SelectedItem == null || cbFase.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione o projeto e a fase.");
                return;
            }

            var pontuacao = new Pontuacao
            {
                ProjetoId = ((Projeto)cbProjetos.SelectedItem).Id,
                Fase = cbFase.SelectedItem.ToString(),
                Pontos = (int)nudPontos.Value
            };

            try
            {
                pontuacaoService.Cadastrar(pontuacao);
                MessageBox.Show("Pontuação cadastrada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar pontuação: " + ex.Message);
            }
        }
    }
}
