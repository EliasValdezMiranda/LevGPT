using LevGPT.Models;
using LevGPT.Models.BaseDeDatos;

namespace LevGPT
{
    public partial class VentanaInicioSesion : Form
    {
        // El objeto StoredProcedures es utilizado para llamar los procedimientos
        // almacenados de la base de datos.
        StoredProcedures storedProcedures = new StoredProcedures();

        // Constructor
        public VentanaInicioSesion()
        {
            InitializeComponent();
            //icono de la aplicación
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        // Evento de Click para el label CrearUsuario:
        // Se crea una nueva ventana para la creación de un usuario.
        private void labelCrearUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaCrearUsuario ventana = new VentanaCrearUsuario();
            ventana.FormClosed += (s, args) => this.Close();
            ventana.Show();
        }

        // Evento de Click para el botón enviar:
        // Despues de validar los datos introducidos, se utiliza una función para evaluar las credenciales
        // utilizadas en la base de datos.
        // Si las credenciales son apropiadas, se obtiene la ID del usuario y se abre el menú principal.
        // De lo contrario, se obtiene -1 y se niega el inicio de sesión.
        private async void buttonEnviar_Click(object sender, EventArgs e)
        {
            if (!ValidationFunctions.validarTextBox(textBoxUsuario, 255))
            {
                MessageBox.Show("Favor de introducir un nombre de usuario o correo apropiado",
                                "Nombre inapropiado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            else if (!ValidationFunctions.validarTextBox(textBoxPassword, 100))
            {
                MessageBox.Show("Favor de introducir una contraseña apropiada",
                                "Contraseña inapropiada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            buttonEnviar.Enabled = false;
            int resultado = await storedProcedures.ufnVerificarPassword(textBoxUsuario.Text, textBoxPassword.Text);
            if (resultado != -1)
            {
                Usuario usuario = new Usuario(resultado);
                this.Hide();
                VentanaMenuPrincipal ventana = new VentanaMenuPrincipal(usuario);
                ventana.FormClosed += (s, args) => this.Close();
                ventana.Show();
            }
            else
            {
                MessageBox.Show($"Nombre de usuario, correo o contraseña no válidos",
                                "Inicio de sesión",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            buttonEnviar.Enabled = true;
        }
    }
}
