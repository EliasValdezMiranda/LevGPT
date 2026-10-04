using LevGPT.Models;
using LevGPT.Models.BaseDeDatos;

namespace LevGPT
{
    public partial class VentanaConfiguracion : Form
    {
        // El objeto de usuario es utilizado para almacenar y extraer la información
        // del usuario actual.
        Usuario Usuario;
        // El objeto StoredProcedures es utilizado para llamar los procedimientos
        // almacenados de la base de datos.
        StoredProcedures StoredProcedures = new StoredProcedures();

        // El constructor inicializa los campos de texto con la información del usuario.
        public VentanaConfiguracion(Usuario usuario)
        {
            InitializeComponent();
            this.Usuario = usuario;
            textBoxNombre.Text = usuario.Nombre;
            textBoxUsername.Text = usuario.Username;
            textBoxEmail.Text = usuario.Email;
            //icono de la aplicación
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
        // Evento TextChanged:
        // Cuando se cambia el texto en el campo de texto de nombre, se actualiza el valor
        // en la base de datos.
        private async void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            if (!ValidationFunctions.validarTextBox(textBoxNombre, 100))
            {
                MessageBox.Show("Favor de introducir un nombre apropiado",
                                "Nombre inapropiado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                textBoxNombre.Text = Usuario.Nombre;
                return;
            }
            if (textBoxNombre.Text != Usuario.Nombre)
            {
                await StoredProcedures.stpActualizarNombre(Usuario.IdUsuario, textBoxNombre.Text);
                Usuario.Nombre = textBoxNombre.Text;
            }
        }

        // Evento de Click para el botón EliminarConversaciones:
        // Al hacer click en este botón, se le pregunta al usuario por una confirmación, y, de confirmar la
        // acción, se llama un procedimiento almacenado que elimine todas las conversaciones de un usuario.
        private async void btnEliminarConversaciones_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show($"¿Deseas eliminar todas las conversaciones?\n UNA VEZ ELIMINADAS NO SE PODRÁN RECUPERAR", "Eliminación de conversaciones",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Resultado == DialogResult.Yes)
            {
                await StoredProcedures.stpEliminarHistorialConversaciones(Usuario.IdUsuario);
                MessageBox.Show("Conversaciones exitosamente eliminadas",
                            "Eliminación de conversaciones",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            }
        }

        // Evento de Click para el botón EliminarUsuario:
        // Al hacer click en este botón, se le pregunta al usuario por una confirmación, y, de confirmar la
        // acción, se llama un procedimiento almacenado que elimine al usuario. Al eliminar al usuario, se cierra
        // la sesión y se devuelve a la ventana de iniciar sesión.
        private async void buttonEliminarUsuario_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show($"¿Deseas eliminar su usuario?\n UNA VEZ ELIMINADO NO SE PODRÁ RECUPERAR", "Eliminación de usuario",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Resultado == DialogResult.Yes)
            {
                await StoredProcedures.stpEliminarUsuario(Usuario.IdUsuario);
                MessageBox.Show("Usuario eliminado exitosamente. La sesión se cerrará",
                            "Eliminación de usuario",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                Usuario.IdUsuario = -1;
                this.Close();
            }
            
        }
    }
}
