namespace LevGPT
{
    partial class VentanaInicioSesion
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
            labelTitulo = new Label();
            label1 = new Label();
            label2 = new Label();
            textBoxUsuario = new TextBox();
            label3 = new Label();
            textBoxPassword = new TextBox();
            labelCrearUsuario = new Label();
            buttonEnviar = new Button();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(99, 26);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(191, 62);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "LevGPT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 105);
            label1.Name = "label1";
            label1.Size = new Size(136, 28);
            label1.TabIndex = 1;
            label1.Text = "Iniciar sesión";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 187);
            label2.Name = "label2";
            label2.Size = new Size(274, 20);
            label2.TabIndex = 2;
            label2.Text = "Nombre de usuario / Correo electrónico";
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.Location = new Point(12, 210);
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.Size = new Size(367, 27);
            textBoxUsuario.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 261);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 4;
            label3.Text = "Contraseña";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(12, 284);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(367, 27);
            textBoxPassword.TabIndex = 5;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelCrearUsuario
            // 
            labelCrearUsuario.AutoSize = true;
            labelCrearUsuario.Cursor = Cursors.Hand;
            labelCrearUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            labelCrearUsuario.ForeColor = SystemColors.Highlight;
            labelCrearUsuario.Location = new Point(12, 144);
            labelCrearUsuario.Name = "labelCrearUsuario";
            labelCrearUsuario.Size = new Size(288, 20);
            labelCrearUsuario.TabIndex = 6;
            labelCrearUsuario.Text = "¿No cuentas con un usuario? Crear usuario";
            labelCrearUsuario.Click += labelCrearUsuario_Click;
            // 
            // buttonEnviar
            // 
            buttonEnviar.BackColor = SystemColors.ControlLight;
            buttonEnviar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEnviar.Location = new Point(12, 346);
            buttonEnviar.Name = "buttonEnviar";
            buttonEnviar.Size = new Size(367, 29);
            buttonEnviar.TabIndex = 7;
            buttonEnviar.Text = "Enviar";
            buttonEnviar.UseVisualStyleBackColor = false;
            buttonEnviar.Click += buttonEnviar_Click;
            // 
            // VentanaInicioSesion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(391, 395);
            Controls.Add(buttonEnviar);
            Controls.Add(labelCrearUsuario);
            Controls.Add(textBoxPassword);
            Controls.Add(label3);
            Controls.Add(textBoxUsuario);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "VentanaInicioSesion";
            Text = "Inicio de Sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private Label label1;
        private Label label2;
        private TextBox textBoxUsuario;
        private Label label3;
        private TextBox textBoxPassword;
        private Label labelCrearUsuario;
        private Button buttonEnviar;
    }
}
