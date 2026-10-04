using Microsoft.Data.SqlClient;
using System.Data;

namespace LevGPT.Models.BaseDeDatos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        // Constructor
        public Usuario(int idUsuario)
        {
            this.IdUsuario = idUsuario;
            llenarPropiedades();
        }

        /// <summary>
        /// El método <c>llenarPropiedades</c> ejecuta una consulta a la base de datos, obteniendo
        /// información relevante del usuario para su uso en el programa.
        /// </summary>
        private void llenarPropiedades()
        {
            SQLCommands sqlCommands = new SQLCommands();

            using (SqlConnection connection = new SqlConnection(sqlCommands.STRING_CONEXION))
            {
                string query = @"
                SELECT IDUsuario, Nombre, Username, Email 
                FROM Usuarios 
                WHERE IDUsuario = @IDUsuario";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDUsuario", IdUsuario);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            if (reader.Read())
                            {
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                                Username = reader.GetString(reader.GetOrdinal("Username"));
                                Email = reader.GetString(reader.GetOrdinal("Email"));
                            }
                            else
                            {
                                MessageBox.Show($"No se encontró al usuario con la ID {IdUsuario}",
                                                "Usuario no encontrado",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                                throw new Exception($"Usuario con la ID {IdUsuario} no encontrado.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }
    }
}
