using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Examen_IIParcial_Ticket
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (UsuariotextBox.Text == string.Empty)
            {
                errorProvider1.SetError(UsuariotextBox, "Ingrese un usuario");
                UsuariotextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(ContrasenatextBox.Text))
            {
                errorProvider1.SetError(ContrasenatextBox, "Ingrese una contraseña");
                ContrasenatextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            //Validar en la base de datos

            Login login = new Login(UsuariotextBox.Text, ContrasenatextBox.Text);
            Usuario usuario = new Usuario();
            UsuarioDB usuarioDB = new UsuarioDB();

            usuario = usuarioDB.Autenticar(login);

            if (usuario != null)
            {
                if (usuario.EstaActivo)
                {
                    System.Security.Principal.GenericIdentity identidad = new System.Security.Principal.GenericIdentity(usuario.CodigoUsuario);
                    System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identidad, new string[] { usuario.Rol });
                    System.Threading.Thread.CurrentPrincipal = principal;


                    //Montramos el Menu
                    Menu menuFormulario = new Menu();
                    this.Hide();

                    menuFormulario.Show();
                }
                else
                {
                    MessageBox.Show("El usuario no esta activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarContrasenabutton_Click(object sender, EventArgs e)
        {
            if (ContrasenatextBox.PasswordChar == '*')
            {
                ContrasenatextBox.PasswordChar = '\0';
            }
            else
            {
                ContrasenatextBox.PasswordChar = '*';
            }
        }
    }
}
