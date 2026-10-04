using Microsoft.Data.SqlClient;
using System.Data;

namespace LevGPT.Models
{
    internal class StoredProcedures
    {
        // El objeto Commands es utilizado para hacer contactos con las cadenas y
        // funciones relacionadas a la base de datos.
        private SQLCommands Commands { get; set; }

        // Constructor:
        // Los procedimientos almacenados utilizan un objeto de la clase local SqlCommands
        // para conseguir el string de conexión a la base de datos.
        public StoredProcedures ()
        {
            Commands = new SQLCommands();
        }

        /// <summary>
        /// El método <c>stpAgregarUsuario</c> llama el procedimiento almacenado de nombre homónimo de la base de datos.
        /// </summary>
        /// <param name="nombre">Nombre del usuario por crear.</param>
        /// <param name="username">Nombre de usuario del usuario por crear (único).</param>
        /// <param name="email">Correo electrónico del usuario por crear (único).</param>
        /// <param name="password">Contraseña del usuario por crear. Esta será encriptada por el procedimiento.</param>
        /// <returns>Tupla con dos <c>SqlParameter</c>, los que almacenan las variables de salida del procedimiento 
        /// (ID del usuario creado y el mensaje de éxito o de error).</returns>
        public async Task<(SqlParameter,SqlParameter)> stpAgregarUsuario(string nombre, string username, string email, string password)
        {
            string procedimiento = "dbo.stpAgregarUsuario";
            Dictionary<string, object> parametrosIN = new Dictionary<string, object>
            {
                ["@Nombre"] = nombre,
                ["@Username"] = username,
                ["@Email"] = email,
                ["@Password"] = password
            };
            using (var connection = new SqlConnection(Commands.STRING_CONEXION))
            {
                List<SqlParameter> parametrosReturn = new List<SqlParameter>();
                using var command = new SqlCommand(procedimiento, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var param in parametrosIN)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
                }
                SqlParameter paramIDUsuarioOUT = new SqlParameter("@IDUsuario", SqlDbType.Int);
                paramIDUsuarioOUT.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramIDUsuarioOUT);
                SqlParameter paramMensajeOUT = new SqlParameter("@Mensaje", SqlDbType.NVarChar,500);
                paramMensajeOUT.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramMensajeOUT);
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    return (paramIDUsuarioOUT, paramMensajeOUT);
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

        /// <summary>
        /// El método <c>stpAgregarConversacion</c> llama el procedimiento almacenado de nombre homónimo de la base de datos.
        /// </summary>
        /// <param name="idUsuario">ID del usuario al que pertenece la conversación.</param>
        /// <param name="titulo">Nombre que resume el tema principal de la conversación.</param>
        /// <returns>int con el valor de la ID de conversación recien creada.</returns>
        public async Task<int> stpAgregarConversacion(int idUsuario, string titulo)
        {
            string procedimiento = "dbo.stpAgregarConversacion";
            Dictionary<string, object> parametrosIN = new Dictionary<string, object>
            {
                ["@IDUsuario"] = idUsuario,
                ["@Titulo"] = titulo,
            };
            using (var connection = new SqlConnection(Commands.STRING_CONEXION))
            {
                List<SqlParameter> parametrosReturn = new List<SqlParameter>();
                using var command = new SqlCommand(procedimiento, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var param in parametrosIN)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
                }
                SqlParameter paramIDConversacionOUT = new SqlParameter("@IDConversacion", SqlDbType.Int);
                paramIDConversacionOUT.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramIDConversacionOUT);
                SqlParameter paramMensajeOUT = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 500);
                paramMensajeOUT.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramMensajeOUT);
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    return int.Parse(paramIDConversacionOUT.Value.ToString());
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

        /// <summary>
        /// El método <c>stpAgregarMensaje</c> llama el procedimiento almacenado de nombre homónimo de la base de datos.
        /// </summary>
        /// <param name="idConversacion">ID de la conversación a la que pertenece el mensaje.</param>
        /// <param name="contenido">Texto con el contenido del mensaje.</param>
        /// <param name="deUsuario">Valor booleano que almacena si el mensaje fue enviado por el usuario o no.</param>
        /// <returns>int con el valor de la ID del mensaje recién creado.</returns>
        public async Task<int> stpAgregarMensaje(int idConversacion, string contenido, bool deUsuario)
        {
            string procedimiento = "dbo.stpAgregarMensaje";
            Dictionary<string, object> parametrosIN = new Dictionary<string, object>
            {
                ["@IDConversacion"] = idConversacion,
                ["@Contenido"] = contenido,
                ["@DeUsuario"] = deUsuario
            };
            using (var connection = new SqlConnection(Commands.STRING_CONEXION))
            {
                List<SqlParameter> parametrosReturn = new List<SqlParameter>();
                using var command = new SqlCommand(procedimiento, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var param in parametrosIN)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
                }
                SqlParameter paramIDMensajeOUT = new SqlParameter("@IDMensaje", SqlDbType.Int);
                paramIDMensajeOUT.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramIDMensajeOUT);
                SqlParameter paramMensajeOUT = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 500);
                paramMensajeOUT.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramMensajeOUT);
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    return int.Parse(paramIDMensajeOUT.Value.ToString());
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

        /// <summary>
        /// El método <c>stpActualizarNombre</c> llama el procedimiento almacenado de nombre homónimo de la base de datos.
        /// </summary>
        /// <param name="idUsuario">ID del usuario cuyo nombre se actualizará.</param>
        /// <param name="nombre">Texto con el nuevo nombre que se le asignará al usuario.</param>
        public async Task stpActualizarNombre(int idUsuario, string nombre)
        {
            string procedimiento = "dbo.stpActualizarNombre";
            Dictionary<string, object> parametrosIN = new Dictionary<string, object>
            {
                ["@IDUsuario"] = idUsuario,
                ["@Nombre"] = nombre
            };
            using (var connection = new SqlConnection(Commands.STRING_CONEXION))
            {
                using var command = new SqlCommand(procedimiento, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var param in parametrosIN)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
                }
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    return;
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

        /// <summary>
        /// El método <c>stpEliminarHistorialConversaciones</c> llama el procedimiento almacenado de nombre homónimo de la base de datos.
        /// </summary>
        /// <param name="idUsuario">ID del usuario cuyo historial completo de conversaciones se eliminará.</param>
        public async Task stpEliminarHistorialConversaciones(int idUsuario)
        {
            string procedimiento = "dbo.stpEliminarHistorialConversaciones";
            Dictionary<string, object> parametrosIN = new Dictionary<string, object>
            {
                ["@IDUsuario"] = idUsuario
            };
            using (var connection = new SqlConnection(Commands.STRING_CONEXION))
            {
                using var command = new SqlCommand(procedimiento, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var param in parametrosIN)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
                }
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    return;
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

        /// <summary>
        /// El método <c>stpEliminarUsuario</c> llama el procedimiento almacenado de nombre homónimo de la base de datos.
        /// </summary>
        /// <param name="idUsuario">ID del usuario por eliminar.</param>
        public async Task stpEliminarUsuario(int idUsuario)
        {
            string procedimiento = "dbo.stpEliminarUsuario";
            Dictionary<string, object> parametrosIN = new Dictionary<string, object>
            {
                ["@IDUsuario"] = idUsuario
            };
            using (var connection = new SqlConnection(Commands.STRING_CONEXION))
            {
                using var command = new SqlCommand(procedimiento, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var param in parametrosIN)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
                }
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    return;
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

        /// <summary>
        /// El método <c>stpEliminarConversacion</c> llama el procedimiento almacenado de nombre homónimo de la base de datos.
        /// </summary>
        /// <param name="idConversacion">ID de la conversación singular por eliminar.</param>
        public async Task stpEliminarConversacion(int idConversacion)
        {
            string procedimiento = "dbo.stpEliminarConversacion";
            Dictionary<string, object> parametrosIN = new Dictionary<string, object>
            {
                ["@IDConversacion"] = idConversacion
            };
            using (var connection = new SqlConnection(Commands.STRING_CONEXION))
            {
                List<SqlParameter> parametrosReturn = new List<SqlParameter>();
                using var command = new SqlCommand(procedimiento, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var param in parametrosIN)
                {
                    command.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
                }
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    return;
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

        /// <summary>
        /// El método <c>stpObtenerConversaciones</c> llama el procedimiento almacenado de nombre homónimo de la base de datos.
        /// </summary>
        /// <param name="idUsuario">ID del usuario cuyas conversaciones se obtendrán.</param>
        /// <returns>DataTable con las conversaciones pertenecientes al usuario. Utilizado para el DGV de conversaciones.</returns>
        public async Task<DataTable> stpObtenerConversaciones(int idUsuario)
        {
            DataTable tablaResultante = new DataTable();
            string procedimiento = "dbo.stpObtenerConversaciones";
            SqlParameter parametro = new SqlParameter("@IDUsuario", idUsuario);
            using (var connection = new SqlConnection(Commands.STRING_CONEXION))
            {
                using var command = new SqlCommand(procedimiento, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(parametro);
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(tablaResultante);
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
                return tablaResultante;
            }
        }

        /// <summary>
        /// El método <c>ufnVerificarPassword</c> llama la función de nombre homónimo de la base de datos.
        /// </summary>
        /// <param name="usernameOrEmail">Nombre de usuario o correo electrónico del usuario.</param>
        /// <param name="password">Contraseña introducida por el usuario. Se verificará con un algoritmo de hashing</param>
        /// <returns>int con la ID del usuario obtenida, o, en caso de fallar en verificar la contraseña o encontrar al usuario, -1</returns>
        public async Task<int> ufnVerificarPassword(string usernameOrEmail, string password)
        {
            int salida = -1;
            using (var connection = new SqlConnection(Commands.STRING_CONEXION))
            {
                SqlCommand command = new SqlCommand(
                    "SELECT dbo.ufnVerificarPassword(@UsernameOrEmail, @Password)",
                    connection);
                command.CommandType = CommandType.Text;

                command.Parameters.Add("@UsernameOrEmail", SqlDbType.NVarChar, 255).Value = usernameOrEmail;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object result = await command.ExecuteScalarAsync().ConfigureAwait(false);

                    if (result != null && result != DBNull.Value)
                    {
                        salida = Convert.ToInt32(result);
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
            return salida;
        }
    }
}