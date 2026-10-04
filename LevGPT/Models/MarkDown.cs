using Microsoft.Data.SqlClient;
using System.Text;

namespace LevGPT.Models
{
    public class MarkDown : IDisposable
    {
        // La propiedad Ruta es utilizada para acceder a la ubicación del archivo temporal .md generado.
        public string Ruta { get; set; }

        /// <summary>
        /// El constructor <c>MarkDown</c> carga un archivo temporal tipo MarkDown, el que, utilizando la ID
        /// de conversación provista, presentará la conversación de la base de datos en un formato apropiado.
        /// </summary>
        /// <param name="ruta">string correspondiente a la ruta del archivo Markdown almacenado.</param>
        /// <param name="IDConversacion">ID de la conversación en la base de datos que se mostrará en la aplicación.</param>
        public MarkDown(string ruta, int IDConversacion)
        {
            // Si no se provee una ruta, se creará un archivo temporal para mostrar la conversación.
            // De lo contrario, se utilizará la ruta provista.
            if (string.IsNullOrEmpty(ruta))
            {
                string nombreArchivo = $"Conversacion_{IDConversacion}_" +
                $"{DateTime.Now:yyyyMMdd_HHmmss}.md";
                Ruta = Path.Combine(Path.GetTempPath(), nombreArchivo);
                // return;
            }
            else
            {
                Ruta = ruta;
            }
            // Si el archivo de la ruta provista no existe, se toma su directorio, y,
            // si no existe, se crea.
            if (!File.Exists(Ruta))
            {
                string directorio = Path.GetDirectoryName(Ruta);
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }
            }
            // Se carga la conversación en base a la ID provista.
            CargarConvesacion(IDConversacion);
        }

        /// <summary>
        /// El método <c>CargarConvesacion</c> carga los mensajes de la base de datos
        /// en el archivo definido en la propiedad de Ruta.
        /// </summary>
        /// <param name="IDConversacion">ID de la conversación en la base de datos que se mostrará en la aplicación.</param>
        private void CargarConvesacion(int IDConversacion)
        {
            // Se utiliza una instancia de SQLCommands para hacer una consulta a la base de datos.
            SQLCommands sqlCommands = new SQLCommands();

            string query = "SELECT [IDConversacion],[Contenido],[DeUsuario],[OrdenMensaje],[Nombre] " +
                "FROM [dbo].[View_HistorialMensajes] " +
                $"WHERE IDConversacion = {IDConversacion} " +
                $"ORDER BY OrdenMensaje ASC;";

            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@IDConversacion"] = IDConversacion
                };
                // Se utiliza el SqlDataReader devuelto de la consulta para escribir los mensajes
                // al archivo.
                using (SqlDataReader rd = sqlCommands.ObtenerDataReader(query, parametros))
                {
                    while (rd.Read())
                    {
                        // Se toman las celdas de las columnas relevantes de la base de datos.
                        string usuario = rd["Nombre"].ToString();
                        string contenido = rd["Contenido"].ToString();
                        bool deUsuario = Convert.ToBoolean(rd["DeUsuario"]);
                        // Si el mensaje no es del usuario, se agrega el mensaje con formato de
                        // inteligencia artificial. De lo contrario, se agrega con formato de
                        // usuario.
                        if (!deUsuario)
                        {
                            agregarMensaje(contenido);
                        }
                        else
                        {
                            agregarMensaje(usuario, contenido);
                        }
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el chat: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// El método sobrecargado <c>agregarMensaje</c> agrega un mensaje del usuario al
        /// archivo Markdown
        /// </summary>
        /// <param name="usuario">Nombre del usuario por mostrar.</param>
        /// <param name="contenido">Contenido del mensaje actual del usuario.</param>
        public void agregarMensaje(string usuario, string contenido)
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine($"👤 {usuario}");
            mensaje.AppendLine();
            mensaje.AppendLine(contenido);
            mensaje.AppendLine();
            mensaje.AppendLine("- - -");
            mensaje.AppendLine();
            File.AppendAllText(Ruta, mensaje.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// El método sobrecargado <c>agregarMensaje</c> agrega un mensaje de la inteligencia artificial al
        /// archivo Markdown
        /// </summary>
        /// <param name="contenido">Contenido del mensaje actual de la inteligencia artificial.</param>
        public void agregarMensaje(string contenido)
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine($"🤖 LevGPT");
            mensaje.AppendLine();
            mensaje.AppendLine(contenido);
            mensaje.AppendLine();
            mensaje.AppendLine("- - -");
            mensaje.AppendLine();
            File.AppendAllText(Ruta, mensaje.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// El método <c>Eliminar</c> maneja las instrucciones para eliminar el archivo
        /// temporal de Markdown
        /// </summary>
        public void Eliminar()
        {
            try
            {
                if (File.Exists(Ruta))
                {
                    File.Delete(Ruta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el archivo: {ex.Message}");
            }
        }

        /// <summary>
        /// El método <c>Dispose</c> ofrece un atajo para la eliminación del archivo
        /// (requerido por la interfaz <c>IDisposable</c>).
        /// </summary>
        public void Dispose()
        {
            Eliminar();
        }
    }
}
