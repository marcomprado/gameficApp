using System;
using System.Windows.Forms;
using GamificacaoApp.Models;
using GamificacaoApp.Services;

namespace GamificacaoApp.Forms
{
    public partial class CadastroFuncionarioForm : Form
    {
        private FuncionarioService funcionarioService = new FuncionarioService();

        private TextBox txtNome;
        private DateTimePicker dtpDataAdmissao;
        private DateTimePicker dtpDataNascimento;
        private TextBox txtSetor;
        private Button btnSalvar;

        public CadastroFuncionarioForm()
        {

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            this.Text = "Cadastro de Funcionário";
            this.Width = 400;
            this.Height = 300;

            Label lblNome = new Label() { Text = "Nome Completo:", Top = 20, Left = 20, Width = 120 };
            txtNome = new TextBox() { Top = 20, Left = 150, Width = 200 };

            Label lblDataAdmissao = new Label() { Text = "Data de Admissão:", Top = 60, Left = 20, Width = 120 };
            dtpDataAdmissao = new DateTimePicker() { Top = 60, Left = 150, Width = 200, Format = DateTimePickerFormat.Short };

            Label lblDataNascimento = new Label() { Text = "Data de Nascimento:", Top = 100, Left = 20, Width = 120 };
            dtpDataNascimento = new DateTimePicker() { Top = 100, Left = 150, Width = 200, Format = DateTimePickerFormat.Short };

            Label lblSetor = new Label() { Text = "Setor:", Top = 140, Left = 20, Width = 120 };
            txtSetor = new TextBox() { Top = 140, Left = 150, Width = 200 };

            btnSalvar = new Button() { Text = "Salvar", Top = 190, Left = 150, Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;

            this.Controls.Add(lblNome);
            this.Controls.Add(txtNome);
            this.Controls.Add(lblDataAdmissao);
            this.Controls.Add(dtpDataAdmissao);
            this.Controls.Add(lblDataNascimento);
            this.Controls.Add(dtpDataNascimento);
            this.Controls.Add(lblSetor);
            this.Controls.Add(txtSetor);
            this.Controls.Add(btnSalvar);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtSetor.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            var funcionario = new Funcionario
            {
                Nome = txtNome.Text.Trim(),
                DataAdmissao = dtpDataAdmissao.Value.Date,
                DataNascimento = dtpDataNascimento.Value.Date,
                Setor = txtSetor.Text.Trim()
            };

            try
            {
                funcionarioService.Cadastrar(funcionario);
                MessageBox.Show("Funcionário cadastrado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionário: " + ex.Message);
            }
        }
    }
}
