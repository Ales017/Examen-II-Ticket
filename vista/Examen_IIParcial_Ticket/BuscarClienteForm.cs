using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Examen_IIParcial_Ticket
{
    public partial class BuscarClienteForm : Form
    {
        public BuscarClienteForm()
        {
            InitializeComponent();
        }
        ClienteDB clienteDB = new ClienteDB();
        public Cliente cliente = new Cliente();

        private void BuscarClienteForm_Load(object sender, EventArgs e)
        {
            ClientesDataGridView.DataSource = clienteDB.DevolverClientes();
        }
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (ClientesDataGridView.SelectedRows.Count > 0)
            {
                cliente.Identidad = ClientesDataGridView.CurrentRow.Cells["Identidad"].Value.ToString();
                cliente.Nombre = ClientesDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                cliente.Telefono = ClientesDataGridView.CurrentRow.Cells["Telefono"].Value.ToString();
                cliente.Correo = ClientesDataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                cliente.Direccion = ClientesDataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
                this.Close();
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarClienteForm_Load_1(object sender, EventArgs e)
        {
            ClientesDataGridView.DataSource = clienteDB.DevolverClientesPorNombre(NombreTextBox.Text);
        }
    }
}
