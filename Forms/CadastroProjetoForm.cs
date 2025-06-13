using System;
using System.Windows.Forms;
using GamificacaoApp.Models;
using GamificacaoApp.Services;

namespace GamificacaoApp.Forms
{
    public partial class CadastroProjetoForm : Form
    {
        private ProjetoService projetoService = new ProjetoService();

        private TextBox txtNome;
        private DateTimePicker dtpDataInicio;
        private TextBox txtCliente;
        private Button btnSalvar;

        public CadastroProjetoForm()
        {
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            this.Text = "Cadastro de Projeto";
            this.Width = 400;
            this.Height = 250;

            Label lblNome = new Label() { Text = "Nome do Projeto:", Top = 20, Left = 20, Width = 120 };
            txtNome = new TextBox() { Top = 20, Left = 150, Width = 200 };

            Label lblDataInicio = new Label() { Text = "Data de Início:", Top = 60, Left = 20, Width = 120 };
            dtpDataInicio = new DateTimePicker() { Top = 60, Left = 150, Width = 200, Format = DateTimePickerFormat.Short };

            Label lblCliente = new Label() { Text = "Cliente:", Top = 100, Left = 20, Width = 120 };
            txtCliente = new TextBox() { Top = 100, Left = 150, Width = 200 };

            btnSalvar = new Button() { Text = "Salvar", Top = 150, Left = 150, Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;

            this.Controls.Add(lblNome);
            this.Controls.Add(txtNome);
            this.Controls.Add(lblDataInicio);
            this.Controls.Add(dtpDataInicio);
            this.Controls.Add(lblCliente);
            this.Controls.Add(txtCliente);
            this.Controls.Add(btnSalvar);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            var projeto = new Projeto
            {
                Nome = txtNome.Text.Trim(),
                DataInicio = dtpDataInicio.Value.Date,
                Cliente = txtCliente.Text.Trim()
            };

            try
            {
                projetoService.Cadastrar(projeto);
                MessageBox.Show("Projeto cadastrado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar projeto: " + ex.Message);
            }
        }
    }
}
