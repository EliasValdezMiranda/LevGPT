using Microsoft.Data.SqlClient;
using System.Data;

namespace LevGPT.Models
{
    public class SQLCommands
    {
        // Las siguientes variables de control son utilizadas para la conexión y el manejo más fácil de las consultas de base de datos.
        private string SERVER = "localhost\\SQLExpress";
        private string DATABASE = "DS3_ProyectoFinal";
        public string STRING_CONEXION;
        /// <summary>
        /// El constructor crea un string de conexión con los valores presentes en el archivo.
        /// </summary>
        public SQLCommands()
        {
            STRING_CONEXION = crearStringConexion();
        }

        /// <summary>
        /// El constructor sobrecargado con argumentos permite sobreescribir los valores presentes en el archivo.
        /// </summary>
        /// <param name="server">string correspondiente a la dirección del servidor por acceder</param>
        /// <param name="database">string correspondiente al nombre de la base de datos por acceder</param>
        public SQLCommands(string server, string database)
        {
            SERVER = server;
            DATABASE = database;
            STRING_CONEXION = crearStringConexion();
        }

        /// <summary>
        /// El método <c>crearStringConexion</c> crea el string de conexión a la base de datos de acuerdo a 
        /// los valores del servidor y la base de datos en el archivo.
        /// </summary>
        /// <returns>string de conexión a la base de datos.</returns> 
        private string crearStringConexion()
        {
            return $"Server={SERVER};Database={DATABASE};Integrated Security=true;TrustServerCertificate=true;";
        }

        /// <summary>
        /// El método <c>ObtenerDataReader</c> crea un SqlDataReader en base a una consulta para su uso en 
        /// la escritura de los archivos Markdown.
        /// </summary>
        /// <param name="query">string correspondiente a la consulta utilizada para la obtención de los mensajes.</param>
        /// <param name="parametros">Diccionario con los parámetros correspondientes a la consulta entregada. Por defecto es null.</param>
        /// <returns>SqlDataReader con la información devuelta por la consulta.</returns> 
        public SqlDataReader ObtenerDataReader(string query, Dictionary<string, object> parametros = null)
        {
            SqlConnection connection = new SqlConnection(STRING_CONEXION);
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
    }
}
