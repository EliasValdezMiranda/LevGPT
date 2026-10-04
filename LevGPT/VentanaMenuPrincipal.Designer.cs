namespace LevGPT
{
    partial class VentanaMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnAgregar = new Button();
            btnEliminar = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            txtMensaje = new TextBox();
            btnEnviar = new Button();
            DGVChats = new DataGridView();
            tableLayoutPanel4 = new TableLayoutPanel();
            wvContenido = new Microsoft.Web.WebView2.WinForms.WebView2();
            tableLayoutPanel5 = new TableLayoutPanel();
            btnCerrarSesion = new Button();
            btnConfiguracion = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVChats).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvContenido).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.3767128F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.62329F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel1.Controls.Add(DGVChats, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.8504639F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1495323F));
            tableLayoutPanel1.Size = new Size(839, 748);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnAgregar, 0, 0);
            tableLayoutPanel2.Controls.Add(btnEliminar, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 661);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(164, 83);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Dock = DockStyle.Fill;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(3, 4);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(158, 33);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.Location = new Point(3, 45);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(158, 34);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.05665F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.9433556F));
            tableLayoutPanel3.Controls.Add(txtMensaje, 0, 0);
            tableLayoutPanel3.Controls.Add(btnEnviar, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(173, 661);
            tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(663, 83);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // txtMensaje
            // 
            txtMensaje.Dock = DockStyle.Fill;
            txtMensaje.Location = new Point(3, 4);
            txtMensaje.Margin = new Padding(3, 4, 3, 4);
            txtMensaje.Multiline = true;
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(564, 75);
            txtMensaje.TabIndex = 1;
            // 
            // btnEnviar
            // 
            btnEnviar.Dock = DockStyle.Fill;
            btnEnviar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEnviar.Location = new Point(573, 4);
            btnEnviar.Margin = new Padding(3, 4, 3, 4);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(87, 75);
            btnEnviar.TabIndex = 0;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // DGVChats
            // 
            DGVChats.AllowUserToAddRows = false;
            DGVChats.AllowUserToDeleteRows = false;
            DGVChats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVChats.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGVChats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVChats.Dock = DockStyle.Fill;
            DGVChats.Location = new Point(3, 4);
            DGVChats.Margin = new Padding(3, 4, 3, 4);
            DGVChats.MultiSelect = false;
            DGVChats.Name = "DGVChats";
            DGVChats.ReadOnly = true;
            DGVChats.RowHeadersWidth = 51;
            DGVChats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVChats.Size = new Size(164, 649);
            DGVChats.TabIndex = 2;
            DGVChats.CellClick += DGVChats_CellClick;
            DGVChats.MouseClick += DGVChats_MouseClick;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(wvContenido, 0, 1);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(173, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(663, 651);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // wvContenido
            // 
            wvContenido.AllowExternalDrop = true;
            wvContenido.CreationProperties = null;
            wvContenido.DefaultBackgroundColor = Color.White;
            wvContenido.Dock = DockStyle.Fill;
            wvContenido.Location = new Point(3, 44);
            wvContenido.Margin = new Padding(3, 4, 3, 4);
            wvContenido.Name = "wvContenido";
            wvContenido.Size = new Size(657, 603);
            wvContenido.TabIndex = 5;
            wvContenido.ZoomFactor = 1D;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tableLayoutPanel5.Controls.Add(btnCerrarSesion, 2, 0);
            tableLayoutPanel5.Controls.Add(btnConfiguracion, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(657, 34);
            tableLayoutPanel5.TabIndex = 6;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Dock = DockStyle.Fill;
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarSesion.Location = new Point(480, 3);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(174, 28);
            btnCerrarSesion.TabIndex = 3;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.Dock = DockStyle.Fill;
            btnConfiguracion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfiguracion.Location = new Point(3, 3);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Size = new Size(174, 28);
            btnConfiguracion.TabIndex = 4;
            btnConfiguracion.Text = "Configuración";
            btnConfiguracion.UseVisualStyleBackColor = true;
            btnConfiguracion.Click += buttonConfiguracion_Click;
            // 
            // VentanaMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(839, 748);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "VentanaMenuPrincipal";
            Text = "LevGPT - Menú Principal";
            Load += VentanaMenuPrincipal_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVChats).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wvContenido).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView DGVChats;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnEnviar;
        private TextBox txtMensaje;
        private TableLayoutPanel tableLayoutPanel4;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvContenido;
        private TableLayoutPanel tableLayoutPanel5;
        private Button btnCerrarSesion;
        private Button btnConfiguracion;
    }
}
