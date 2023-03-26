using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Examen_IIParcial_Ticket
{
    public partial class BuscarServicioForm : Form
    {
        public BuscarServicioForm()
        {
            InitializeComponent();

        }
        ServicioDB servicioDB = new ServicioDB();
        public Servicio servicio = new Servicio();

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (ServicioDataGridView.RowCount > 0)
            {
                if (ServicioDataGridView.SelectedRows.Count > 0)
                {
                    servicio.Codigo = ServicioDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                    servicio.Descripcion = ServicioDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                    servicio.Precio = Convert.ToDecimal(ServicioDataGridView.CurrentRow.Cells["Precio"].Value);
                    Close();
                }
            }
        }

        private void DescripcionTextBox_TextChanged(object sender, EventArgs e)
        {
            ServicioDataGridView.DataSource = servicioDB.DevolverServicioPorDescripcion(DescripcionTextBox.Text);
        }

        private void CancelarButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BuscarServicioForm_Load(object sender, EventArgs e)
        {
            ServicioDataGridView.DataSource = servicioDB.DevolverServicio();
        }
    }
}
