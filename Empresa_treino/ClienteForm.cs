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
            PreenchimentoPanel.Visible = false;
            DataGridPanel.Dock = DockStyle.Fill;
            IncluirButton.Visible = true;
            Alterar_Button.Visible = true;
            ExcluirButton.Visible = true;
            SairButton.Visible = true;
            ConfirmarIncluirButton.Visible = false;
            ConfirmarAlterarButton.Visible = false;
            ConfirmarExcluirButton.Visible = false;
            VoltarButton.Visible = false;

            var db = new ClienteDb(); 

            ClientesDataGridView.DataSource = db.Listar();
            ClientesDataGridView.ReadOnly = true;
            ClientesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ClientesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ClientesDataGridView.RowHeadersVisible = false;
            ClientesDataGridView.Columns["Id"].Width = 40;


        }

    }
}
