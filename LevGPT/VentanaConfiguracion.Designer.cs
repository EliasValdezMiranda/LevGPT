namespace LevGPT
{
    partial class VentanaConfiguracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelConfiguracion = new Label();
            labelNombre = new Label();
            textBoxNombre = new TextBox();
            textBoxUsername = new TextBox();
            labelUsername = new Label();
            textBoxEmail = new TextBox();
            labelEmail = new Label();
            btnEliminarConversaciones = new Button();
            buttonEliminarUsuario = new Button();
            SuspendLayout();
            // 
            // labelConfiguracion
            // 
            labelConfiguracion.AutoSize = true;
            labelConfiguracion.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelConfiguracion.Location = new Point(12, 9);
            labelConfiguracion.Name = "labelConfiguracion";
            labelConfiguracion.Size = new Size(269, 50);
            labelConfiguracion.TabIndex = 0;
            labelConfiguracion.Text = "Configuración";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(12, 95);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(67, 20);
            labelNombre.TabIndex = 1;
            labelNombre.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(113, 92);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(325, 27);
            textBoxNombre.TabIndex = 2;
            textBoxNombre.TextChanged += textBoxNombre_TextChanged;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Enabled = false;
            textBoxUsername.Location = new Point(113, 165);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.ReadOnly = true;
            textBoxUsername.Size = new Size(325, 27);
            textBoxUsername.TabIndex = 4;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(12, 159);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(85, 40);
            labelUsername.TabIndex = 3;
            labelUsername.Text = "Nombre de\r\nusuario:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Enabled = false;
            textBoxEmail.Location = new Point(113, 238);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.ReadOnly = true;
            textBoxEmail.Size = new Size(325, 27);
            textBoxEmail.TabIndex = 6;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(12, 231);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(86, 40);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "Correo\r\nelectrónico:";
            // 
            // btnEliminarConversaciones
            // 
            btnEliminarConversaciones.Location = new Point(12, 303);
            btnEliminarConversaciones.Name = "btnEliminarConversaciones";
            btnEliminarConversaciones.Size = new Size(426, 29);
            btnEliminarConversaciones.TabIndex = 7;
            btnEliminarConversaciones.Text = "Eliminar todas las conversaciones";
            btnEliminarConversaciones.UseVisualStyleBackColor = true;
            btnEliminarConversaciones.Click += btnEliminarConversaciones_Click;
            // 
            // buttonEliminarUsuario
            // 
            buttonEliminarUsuario.Location = new Point(12, 354);
            buttonEliminarUsuario.Name = "buttonEliminarUsuario";
            buttonEliminarUsuario.Size = new Size(426, 29);
            buttonEliminarUsuario.TabIndex = 8;
            buttonEliminarUsuario.Text = "Eliminar usuario";
            buttonEliminarUsuario.UseVisualStyleBackColor = true;
            buttonEliminarUsuario.Click += buttonEliminarUsuario_Click;
            // 
            // VentanaConfiguracion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 406);
            Controls.Add(buttonEliminarUsuario);
            Controls.Add(btnEliminarConversaciones);
            Controls.Add(textBoxEmail);
            Controls.Add(labelEmail);
            Controls.Add(textBoxUsername);
            Controls.Add(labelUsername);
            Controls.Add(textBoxNombre);
            Controls.Add(labelNombre);
            Controls.Add(labelConfiguracion);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "VentanaConfiguracion";
            Text = "VentanaConfiguracion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelConfiguracion;
        private Label labelNombre;
        private TextBox textBoxNombre;
        private TextBox textBoxUsername;
        private Label labelUsername;
        private TextBox textBoxEmail;
        private Label labelEmail;
        private Button btnEliminarConversaciones;
        private Button buttonEliminarUsuario;
    }
}