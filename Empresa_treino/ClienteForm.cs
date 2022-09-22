using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Empresa.Db;
using Empresa.Models;

namespace Empresa_treino
{
    public partial class ClienteForm : Form
    {
        public ClienteForm()
        {
            InitializeComponent();
        }

        private void ClienteForm_Load(object sender, EventArgs e)
        {
            ExibirGrid();
        }

        private void ExibirGrid()
        {
            LimparCampos();

            var db = new ClienteDb();
            ClientesDataGridView.DataSource = db.Listar();

            PreenchimentoPanel.Visible = false;
            DataGridPanel.Visible = true;
            DataGridPanel.Dock = DockStyle.Fill;

            ClientesDataGridView.ReadOnly = true;
            ClientesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ClientesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ClientesDataGridView.RowHeadersVisible = false;
            ClientesDataGridView.Columns["Id"].Width = 40;

            IncluirButton.Visible = true;
            Alterar_Button.Visible = true;
            ExcluirButton.Visible = true;
            SairButton.Visible = true;
            ConfirmarIncluirButton.Visible = false;
            ConfirmarAlterarButton.Visible = false;
            ConfirmarExcluirButton.Visible = false;
            CancelarButton.Visible = false;

        }

        private void LimparCampos()
        {
            IdTextBox.Clear();
            NomeTextBox.Clear();
            EmailTextBox.Clear();
            TelefoneTextBox.Clear();
        }

        private void IncluirButton_Click(object sender, EventArgs e)
        {

            HabilitarTxt();

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

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            ExibirGrid();
        }

        private void ConfirmarIncluirButton_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente();
            var db = new ClienteDb();

            cliente.Id = Convert.ToInt32(IdTextBox.Text);
            cliente.Nome = NomeTextBox.Text;
            cliente.Email = EmailTextBox.Text;
            cliente.Telefone = TelefoneTextBox.Text;

            db.Incluir(cliente);
            MessageBox.Show("Cliente cadastrado com sucesso!");

            ExibirGrid();
        }

        private void Alterar_Button_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)ClientesDataGridView.CurrentRow.DataBoundItem;

            HabilitarTxt();
            IdTextBox.Enabled = false;

            IdTextBox.Text = cliente.Id.ToString();
            NomeTextBox.Text = cliente.Nome;
            EmailTextBox.Text = cliente.Email;
            TelefoneTextBox.Text = cliente.Telefone;

            DataGridPanel.Visible = false;
            PreenchimentoPanel.Visible = true;
            PreenchimentoPanel.Dock = DockStyle.Fill;
                      
            IncluirButton.Visible = false;
            Alterar_Button.Visible = false;
            ExcluirButton.Visible = false;
            SairButton.Visible = false;
            ConfirmarIncluirButton.Visible = false;
            ConfirmarAlterarButton.Visible = true;
            ConfirmarExcluirButton.Visible = false;
            CancelarButton.Visible = true;
        }

        private void ConfirmarAlterarButton_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente();
            var db = new ClienteDb();

            cliente.Id = Convert.ToInt32(IdTextBox.Text);
            cliente.Nome = NomeTextBox.Text;
            cliente.Email = EmailTextBox.Text;
            cliente.Telefone = TelefoneTextBox.Text;

            db.Alterar(cliente);
            MessageBox.Show("Alteração realizada com sucesso.");

            ExibirGrid();
        }

        private void ExcluirButton_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)ClientesDataGridView.CurrentRow.DataBoundItem;

            DesabilitarTxt();

            IdTextBox.Text = cliente.Id.ToString();
            NomeTextBox.Text = cliente.Nome;
            EmailTextBox.Text = cliente.Email;
            TelefoneTextBox.Text = cliente.Telefone;

            DataGridPanel.Visible = false;
            PreenchimentoPanel.Visible = true;
            PreenchimentoPanel.Dock = DockStyle.Fill;

            IncluirButton.Visible = false;
            Alterar_Button.Visible = false;
            ExcluirButton.Visible = false;
            SairButton.Visible = false;
            ConfirmarIncluirButton.Visible = false;
            ConfirmarAlterarButton.Visible = false;
            ConfirmarExcluirButton.Visible = true;
            CancelarButton.Visible = true;
        }

        private void ConfirmarExcluirButton_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente();

            cliente.Id = Convert.ToInt32(IdTextBox.Text);

            var db = new ClienteDb();

            db.Excluir(cliente.Id);
            MessageBox.Show("Registro excluído com sucesso!");

            ExibirGrid();

        }

        private void SairButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DesabilitarTxt()
        {
            IdTextBox.Enabled = false;
            NomeTextBox.Enabled = false;
            EmailTextBox.Enabled = false;
            TelefoneTextBox.Enabled = false;
        }

        private void HabilitarTxt()
        {
            IdTextBox.Enabled = true;
            NomeTextBox.Enabled = true;
            EmailTextBox.Enabled = true;
            TelefoneTextBox.Enabled = true;
        }
    }
}
