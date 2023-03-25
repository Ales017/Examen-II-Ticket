using System;
using System.Windows.Forms;

namespace Examen_IIParcial_Ticket
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Expandir_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Expandir.Visible = false;
            // Expandir.Visible = true;
        }

        private void Ajustar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            // Ajustar.Visible = false;
            // Ajustar.Visible = true;
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Serviciosbutton_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
        private void Androidbutton_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;

            abrirformhija(new Android());
        }

        private void Applebutton_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            abrirformhija(new Apple());
        }

        private void Laptopbutton_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            abrirformhija(new Laptop());
        }

        public void abrirformhija(object abrirform)
        {
            if (this.panelcontenedor.Controls.Count > 0)
                this.panelcontenedor.Controls.RemoveAt(0);
            Form fh = abrirform as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelcontenedor.Controls.Add(fh);
            this.panelcontenedor.Tag = fh;
            fh.Show();

        }

        private void Principalbutton_Click(object sender, EventArgs e)
        {
            abrirformhija(new Principal());
        }

    }
}
