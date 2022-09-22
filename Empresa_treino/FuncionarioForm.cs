using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Empresa.Models;
using Empresa.Db;

namespace Empresa_treino
{
    public partial class FuncionarioForm : Form
    {
        public FuncionarioForm()
        {
            InitializeComponent();
        }

        private void FuncionarioForm_Load(object sender, EventArgs e)
        {
            ExibirGrid();
        }

        private void ExibirGrid()
        {
            PreenchimentoPanel.Visible = false;
            DataGridPanel.Visible = true;
            DataGridPanel.Dock = DockStyle.Fill;

            IncluirButton.Visible = true;
            Alterar_Button.Visible = true;
            ExcluirButton.Visible = true;
            SairButton.Visible = true;
            ConfirmarIncluirButton.Visible = false;
            ConfirmarAlterarButton.Visible = false;
            ConfirmarExcluirButton.Visible = false;
            CancelarButton.Visible = false;

        }

        private void IncluirButton_Click(object sender, EventArgs e)
        {
            DataGridPanel.Visible = false;
            PreenchimentoPanel.Visible = true;
            PreenchimentoPanel.Dock = DockStyle.Fill;

            IncluirButton.Visible = false;
            Alterar_Button.Visible = false;
            ExcluirButton.Visible = false;
            SairButton.Visible = false;
            ConfirmarIncluirButton.Visible = true;
            ConfirmarAlterarButton.Visible = false;
            ConfirmarExcluirButton.Visible = false;
            CancelarButton.Visible = true;

        }

        private void ConfirmarIncluirButton_Click(object sender, EventArgs e)
        {
            var funcionario = new Funcionario();
            var db = new FuncionarioDb();

            funcionario.Nome = NomeTextBox.Text;
            funcionario.Cpf = CpfTextBox.Text;
            funcionario.Cargo = CargoTextBox.Text;
            funcionario.Salario = Convert.ToDouble(SalarioTextBox.Text);
            funcionario.DataAdmissao = Convert.ToDateTime(AdmissaoTextBox.Text);
            funcionario.Email = EmailTextBox.Text;
            funcionario.Telefone = TelefoneTextBox.Text;

            db.Incluir(funcionario);
            MessageBox.Show("Funcionário cadastrado com sucesso!");

            
        }
    }
}
