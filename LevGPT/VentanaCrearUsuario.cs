using LevGPT.Models;
using Microsoft.Data.SqlClient;

namespace LevGPT
{
    public partial class VentanaCrearUsuario : Form
    {
        // El objeto StoredProcedures es utilizado para llamar los procedimientos
        // almacenados de la base de datos.
        StoredProcedures storedProcedures = new StoredProcedures();   

        // Constructor
        public VentanaCrearUsuario()
        {
            InitializeComponent();
            //icono de la aplicación
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        // Evento de Click para el label IniciarSesion:
        // Se crea una nueva ventana para el inicio de sesión.
        private void labelIniciarSesion_Click(object? sender, EventArgs? e)
        {
            this.Hide();
            VentanaInicioSesion ventana = new VentanaInicioSesion();
            ventana.FormClosed += (s, args) => this.Close();
            ventana.Show();
        }

        // Evento de Click para el botón enviar:
        // Despues de validar los datos introducidos, se utiliza una función para intentar crear un usuario
        // en la base de datos.
        // Si el usuario se puede crear sin conflicto (nombre de usuario o correo electrónico repetido), se
        // le informa al usuario y se regresa a la pantalla de inicio de sesión. De lo contrario, se le informa
        // al usuario y se permanece en la ventana actual.
        private async void buttonEnviar_Click(object sender, EventArgs e)
        {
            if (!ValidationFunctions.validarTextBox(textBoxNombre, 100))
            {
                MessageBox.Show("Favor de introducir un nombre apropiado",
                                "Nombre inapropiado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            else if (!ValidationFunctions.validarTextBox(textBoxUsername, 50))
            {
                MessageBox.Show("Favor de introducir un nombre de usuario apropiado",
                                "Nombre de usuario inapropiado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            else if (!ValidationFunctions.validarTextBox(textBoxEmail, 50))
            {
                MessageBox.Show("Favor de introducir un correo electrónico apropiado",
                                "Correo electrónico inapropiado",
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
            else if (textBoxPassword.Text != textBoxPasswordConfirm.Text)
            {
                MessageBox.Show("Las contraseñas introducidas no coinciden",
                                "Contraseña incorrecta",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    buttonEnviar.Enabled = false;
                    (SqlParameter, SqlParameter) resultado = await storedProcedures.stpAgregarUsuario(
                            textBoxNombre.Text,
                            textBoxUsername.Text,
                            textBoxEmail.Text,
                            textBoxPassword.Text);
                    if (int.Parse(resultado.Item1.Value.ToString()) != -1)
                    {
                        MessageBox.Show($"{resultado.Item2.Value}", "", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        labelIniciarSesion_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show($"{resultado.Item2.Value}", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    MessageBox.Show($"{ex.Message}", "", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    buttonEnviar.Enabled = true;
                }
            }
        }
    }
}
