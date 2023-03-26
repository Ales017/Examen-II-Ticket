using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Examen_IIParcial_Ticket
{
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
        }
        Cliente miCliente = null;
        ClienteDB clienteDB = new ClienteDB();
        Servicio miServicio = null;
        ServicioDB servicioDB = new ServicioDB();
        List<DetalleTicket> listaDetalles = new List<DetalleTicket>();
        TicketDB ticketDB = new TicketDB();
        decimal subTotal = 0;
        decimal isv = 0;
        decimal totalAPagar = 0;
        decimal descuento = 0;


        private void buscarclientebutton_Click(object sender, EventArgs e)
        {
            BuscarClienteForm form = new BuscarClienteForm();
            form.ShowDialog();
            miCliente = new Cliente();
            miCliente = form.cliente;
            IdentidadtextBox.Text = miCliente.Identidad;
            NombreClientetextBox.Text = miCliente.Nombre;
        }

        private void CodigoServicioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(CodigoServicioTextBox.Text))
            {
                miServicio = new Servicio();
                miServicio = servicioDB.DevolverServicioPorCodigo(CodigoServicioTextBox.Text);
                DescripcionServicioTextBox.Text = miServicio.Descripcion;

            }
            else
            {
                miServicio = null;
                DescripcionServicioTextBox.Clear();

            }
        }

        private void BuscarServicioButton_Click_1(object sender, EventArgs e)
        {
            BuscarServicioForm form = new BuscarServicioForm();
            form.ShowDialog();
            miServicio = new Servicio();
            miServicio = form.servicio;
            CodigoServicioTextBox.Text = miServicio.Codigo;
            DescripcionServicioTextBox.Text = miServicio.Descripcion;
        }

        private void cantidadtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(cantidadtextBox.Text))
            {
                DetalleTicket detalle = new DetalleTicket();
                detalle.CodigoServicio = miServicio.Codigo;
                detalle.cantidad = Convert.ToInt32(cantidadtextBox.Text);
                detalle.Precio = Convert.ToDecimal(miServicio.Precio);
                detalle.Total = Convert.ToInt32(cantidadtextBox.Text) * miServicio.Precio;
                detalle.Descripcion = miServicio.Descripcion;

                subTotal += detalle.Total;
                isv = subTotal * 0.15M;
                totalAPagar = subTotal + isv;

                listaDetalles.Add(detalle);
                ServiciodataGridView.DataSource = null;
                ServiciodataGridView.DataSource = listaDetalles;

                SubTotaltextBox.Text = subTotal.ToString("N2");
                ISVtextBox.Text = isv.ToString("N2");
                TotaltextBox.Text = totalAPagar.ToString("N2");

                miServicio = null;
                CodigoServicioTextBox.Clear();
                DescripcionServicioTextBox.Clear();

                cantidadtextBox.Clear();
                CodigoServicioTextBox.Focus();



            }
        }
        private void GuardarButton_Click_1(object sender, EventArgs e)
        {
            Ticket1 miticket = new Ticket1();
            miticket.Fecha = FechadateTimePicker.Value;
            miticket.CodigoUsuario = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            miticket.IdentidadCliente = miCliente.Identidad;
            miticket.SubTotal = subTotal;
            miticket.ISV = isv;
            miticket.Descuento = descuento;
            miticket.Total = totalAPagar;

            bool inserto = ticketDB.Guardar(miticket, listaDetalles);

            if (inserto)
            {
                IdentidadtextBox.Focus();
                MessageBox.Show("Factura Registrada correctamente");
                LimpiarControles();
            }
            else
                MessageBox.Show("No se pudo registrar la factura");
        }
        private void LimpiarControles()
        {
            miCliente = null;
            miServicio = null;
            listaDetalles = null;
            FechadateTimePicker.Value = DateTime.Now;
            IdentidadtextBox.Clear();
            NombreClientetextBox.Clear();
            CodigoServicioTextBox.Clear();
            DescripcionServicioTextBox.Clear();
            ServiciodataGridView.DataSource = null;
            subTotal = 0;
            SubTotaltextBox.Clear();
            isv = 0;
            ISVtextBox.Clear();
            descuento = 0;
            DescuentotextBox.Clear();
            totalAPagar = 0;
            TotaltextBox.Clear();
        }

        private void Ticket_Load_1(object sender, EventArgs e)
        {
            usuariotextBox.Text = System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }

        private void IdentidadtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(IdentidadtextBox.Text))
            {
                miCliente = new Cliente();
                miCliente = clienteDB.DevolverClientePorIdentidad(IdentidadtextBox.Text);
                NombreClientetextBox.Text = miCliente.Nombre;
            }
            else
            {
                miCliente = null;
                NombreClientetextBox.Clear();
            }
        }

        private void CodigoServicioTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(CodigoServicioTextBox.Text))
            {
                miServicio = new Servicio();
                miServicio = servicioDB.DevolverServicioPorCodigo(CodigoServicioTextBox.Text);
                DescripcionServicioTextBox.Text = miServicio.Descripcion;

            }
            else
            {
                miServicio = null;
                DescripcionServicioTextBox.Clear();

            }
        }

        private void DescuentotextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(DescuentotextBox.Text))
            {
                descuento = Convert.ToDecimal(DescuentotextBox.Text);
                totalAPagar = (totalAPagar - descuento);
                TotaltextBox.Text = totalAPagar.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
