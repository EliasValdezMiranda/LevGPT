using LevGPT.Models;
using LevGPT.Models.BaseDeDatos;
using Markdig;
using System.Data;

namespace LevGPT

{
    public partial class VentanaMenuPrincipal : Form
    {
        // El objeto usuario es utilizado para monitorear la ID, los nombres
        // y el correo del usuario.
        private Usuario Usuario;
        // El objeto StoredProcedures es utilizado para llamar los procedimientos
        // almacenados de la base de datos.
        private StoredProcedures StoredProcedures = new StoredProcedures();
        // formCargado es una variable de control que indica si la ventana actual
        // se ha terminado de cargar.
        private bool formCargado = false;
        // nuevaConversacion es una variable de control que indica si el usuario se
        // encuentra en una conversación existente o no
        private bool nuevaConversacion = true;
        private int idConversacionActual = -1;
        // idConversacionACtual almacena la ID de la conversación vista actualmente.
        // Si una conversación no se encuentra abierta, almacena el valor por defecto -1.

        // El constructor toma un objeto de Usuario, lo asigna al objeto local e inicializa los
        // componentes.
        public VentanaMenuPrincipal(Usuario usuario)
        {
            this.Usuario = usuario;
            InitializeComponent();
            // Se actualiza el listado de conversaciones del usuario.
            actualizarConversaciones();
            // Se inicia la vista utilizada para las conversaciones.
            wvContenido.EnsureCoreWebView2Async();
            // Se da un click al botón de agregar conversación.
            btnAgregar.PerformClick();
            //icono de la aplicación
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        // La función carga un controlador WevView2 para mostrar el
        // archivo Markdown generado con la conversación almacenada en la base de datos.
        private async Task CargarMarkDownAsync(string filePath)
        {
            if (filePath == null)
            {
                wvContenido.Refresh();
                return;
            }
            try
            {
                string markdown = File.ReadAllText(filePath);

                string html = Markdown.ToHtml(markdown);

                string fullHtml = $@"
                    <!DOCTYPE html>
                    <html>
                    <head>
                    <meta charset='UTF-8'>
                    <style>
                        body {{
                            font-family: Segoe UI, sans-serif;
                            margin: 20px;
                            background: #ffffff;
                            color: #000000;
                        }}
                        pre {{
                            background: #ffffff;
                            padding: 10px;
                            border-radius: 6px;
                            overflow-x: auto;
                        }}
                        code {{
                            font-family: Consolas, monospace;
                        }}
                        h1, h2, h3 {{
                            margin-top: 24px;
                        }}
                    </style>
                    </head>
                    <body>
                    {html}
                    </body>
                    </html>";

                await wvContenido.EnsureCoreWebView2Async();
                wvContenido.NavigateToString(fullHtml);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                MessageBox.Show($"{ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento de Click para el botón eliminar:
        // Si una conversación se selecciona, se le pregunta al usuario si desea eliminar la conversación.
        // Si el usuario acepta, se llama un procedimiento almacenado para eliminar la conversación y se le
        // notifica al usuario.
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DGVChats.SelectedRows != null && DGVChats.SelectedRows.Count == 1)
            {

                DialogResult Resultado = MessageBox.Show($"¿Desea eliminar la conversación seleccionada?",
                        "Eliminar conversación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Resultado == DialogResult.Yes)
                {
                    await StoredProcedures.stpEliminarConversacion(idConversacionActual);
                    MessageBox.Show("Conversación eliminada", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizarConversaciones();
                    btnAgregar.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una conversación para eliminar", "Eliminar conversación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // El método actualizarConversaciones se utiliza para actualizar el DataGridView con el listado
        // de conversaciones del usuario. Se llama comúnmente al agregar un mensaje, una conversación o
        // eliminar una conversación.
        private async void actualizarConversaciones()
        {
            DataTable dt = await StoredProcedures.stpObtenerConversaciones(Usuario.IdUsuario);
            DGVChats.DataSource = dt;

            // Se esconden las columnas para poder utilizarlas sin que bloqueen la vista principal.
            DGVChats.Columns["IDConversacion"].Visible = false;
            DGVChats.Columns["IDUsuario"].Visible = false;
            DGVChats.Columns["FechaCreacion"].Visible = false;
            DGVChats.Columns["UltimaActualizacion"].Visible = false;

            DGVChats.Columns["Titulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        // Evento de Click para el botón agregar:
        // El botón de agregar limpia la vista del WevView2, marca la variable de control 
        // "nuevaConversacion" como verdadera y reinicia la id de la conversación actual a su
        // valor por defecto.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DGVChats.ClearSelection();
            nuevaConversacion = true;
            idConversacionActual = -1;
            wvContenido.NavigateToString("");
        }

        // Evento de Click para el botón enviar:
        // El evento principal de comunicación con la API de Gemini.
        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            // Se desactivan los controles para evitar comportamientos inesperados durante la llamada
            // a la API.
            btnEnviar.Enabled = false;
            btnAgregar.Enabled = false;
            btnConfiguracion.Enabled = false;
            btnCerrarSesion.Enabled = false;
            btnEliminar.Enabled = false;
            txtMensaje.Enabled = false;
            DGVChats.Enabled = false;

            // Se almacena el resultado devuelto por la API en un string de resultado.
            string? resultado = await Gemini.enviarMensaje(txtMensaje.Text);
            // Si el string de resultado devuelto es nulo, se le informa al usuario y se detiene el evento.
            if (resultado == null)
            {
                MessageBox.Show("No se pudo obtener una respuesta exitosamente. Intenta de nuevo",
                            "Respusta nula",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return;
            }
            // Si se está trabajando con una conversación nueva, se hace una consulta adicional para generar
            // un título y crear una conversación nueva.
            if (nuevaConversacion)
            {
                string? titulo = await Gemini.generarTitulo(txtMensaje.Text);
                // Si se obtuvo una respuesta, se agrega la conversación y el mensaje a la base de datos.
                if (titulo != null)
                {
                    int IDConversacion = await StoredProcedures.stpAgregarConversacion(Usuario.IdUsuario, titulo);
                    if (IDConversacion != -1)
                    {
                        int IDMensaje = await StoredProcedures.stpAgregarMensaje(IDConversacion, txtMensaje.Text, true);
                        int IDMensaje2 = await StoredProcedures.stpAgregarMensaje(IDConversacion, resultado, false);
                        idConversacionActual = IDConversacion;
                        // Se actualiza el listado de conversaciones del usuario.
                        actualizarConversaciones();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo obtener una respuesta exitosamente. Intenta de nuevo",
                            "Respusta nula",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    return;
                }
            }
            // Si no se trabaja con una nueva conversación, se omite la consulta adicional y se agregan los mensajes
            // a la base de datos..
            else
            {
                int IDMensaje = await StoredProcedures.stpAgregarMensaje(idConversacionActual, txtMensaje.Text, true);
                int IDMensaje2 = await StoredProcedures.stpAgregarMensaje(idConversacionActual, resultado, false);
            }
            // Al cargar la nueva conversación, se trabaja con esta y se cambia la variable "nuevaConversacion"
            // a false
            nuevaConversacion = false;
            // Se carga la conversación actual-
            MarkDown md = new MarkDown("", idConversacionActual);
            await CargarMarkDownAsync(md.Ruta);

            // Se reactivan los contrroles al haber terminado y se limpia el campo de texto.
            btnEnviar.Enabled = true;
            btnAgregar.Enabled = true;
            btnConfiguracion.Enabled = true;
            btnCerrarSesion.Enabled = true;
            btnEliminar.Enabled = true;
            txtMensaje.Enabled = true;
            DGVChats.Enabled = true;
            txtMensaje.Clear();
        }

        // Evento Load:
        // Cuando se carga la ventana, se limpia la selección del dataGridView de conversaciones
        // (selecciona filas por defecto) y se marca la ventana como cargada con la variable
        // "formCargado".
        private void VentanaMenuPrincipal_Load(object sender, EventArgs e)
        {
            DGVChats.ClearSelection();
            formCargado = true;
        }

        // Evento CellClick
        // Cuando se hace click en una celda del DataGridView de conversaciones, se asegura que se tenga
        // solo una celda seleccionada y que el form este cargado. Si se cumplen las condiciones, se
        // carga la conversación seleccionada en la vista de WevView2 despues de configurar ciertas
        // variables de control.
        private async void DGVChats_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (formCargado && DGVChats.SelectedRows.Count == 1)
            {
                nuevaConversacion = false;
                idConversacionActual = int.Parse(DGVChats.SelectedRows[0].Cells["IDConversacion"].Value.ToString());
                MarkDown md = new MarkDown("", idConversacionActual);
                await CargarMarkDownAsync(md.Ruta);
            }
        }

        // Evento MouseClick
        // Si se hace click a un área fuera de las celdas, se cancela la selección de fila.
        private void DGVChats_MouseClick(object sender, MouseEventArgs e)
        {
            var hitTestInfo = DGVChats.HitTest(e.X, e.Y);
            if (hitTestInfo.Type == DataGridViewHitTestType.None)
            {
                DGVChats.ClearSelection();
            }
        }


        // Evento de Click para el botón Cerrar sesión:
        // Pregunta al usuario si desea cerrar sesión, y, en caso de aceptar, cierra la ventana actual,
        // regresando al usuario a la ventana de inicio de sesión.
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show($"¿Deseas cerrar la sesión actual?", "Cierre de sesión",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                this.Hide();
                VentanaInicioSesion ventana = new VentanaInicioSesion();
                ventana.FormClosed += (s, args) => this.Close();
                ventana.Show();
            }
        }

        // Evento de Click para el botón Configuración:
        // Se abre una ventana de configuración, y, si se actualiza la ID de usuario
        // al valor de defecto -1, se asume que se eliminó el usuario y se cierra la sesión.
        // De no haber eliminado el usuario, se actualiza el listado de conversaciones (en
        // caso de haber eliminado todas las conversaciones) y se empieza una nueva conversación.
        private void buttonConfiguracion_Click(object sender, EventArgs e)
        {
            VentanaConfiguracion ventana = new VentanaConfiguracion(Usuario);
            ventana.ShowDialog();
            if (Usuario.IdUsuario == -1)
            {
                this.Hide();
                VentanaInicioSesion login = new VentanaInicioSesion();
                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }
            actualizarConversaciones();
            btnAgregar.PerformClick();
        }
    }
}

