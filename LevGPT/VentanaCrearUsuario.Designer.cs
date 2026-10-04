namespace LevGPT
{
    partial class VentanaCrearUsuario
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
            textBoxNombre = new TextBox();
            label3 = new Label();
            textBoxUsername = new TextBox();
            labelIniciarSesion = new Label();
            buttonEnviar = new Button();
            textBoxEmail = new TextBox();
            label5 = new Label();
            textBoxPassword = new TextBox();
            label6 = new Label();
            textBoxPasswordConfirm = new TextBox();
            label7 = new Label();
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
            label1.Size = new Size(199, 28);
            label1.TabIndex = 1;
            label1.Text = "Creación de usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 187);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(12, 210);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(367, 27);
            textBoxNombre.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 261);
            label3.Name = "label3";
            label3.Size = new Size(137, 20);
            label3.TabIndex = 4;
            label3.Text = "Nombre de usuario";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(12, 284);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(367, 27);
            textBoxUsername.TabIndex = 5;
            // 
            // labelIniciarSesion
            // 
            labelIniciarSesion.AutoSize = true;
            labelIniciarSesion.Cursor = Cursors.Hand;
            labelIniciarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            labelIniciarSesion.ForeColor = SystemColors.Highlight;
            labelIniciarSesion.Location = new Point(12, 144);
            labelIniciarSesion.Name = "labelIniciarSesion";
            labelIniciarSesion.Size = new Size(281, 20);
            labelIniciarSesion.TabIndex = 6;
            labelIniciarSesion.Text = "¿Ya cuentas con un usuario? Iniciar sesión";
            labelIniciarSesion.Click += labelIniciarSesion_Click;
            // 
            // buttonEnviar
            // 
            buttonEnviar.BackColor = SystemColors.ControlLight;
            buttonEnviar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEnviar.Location = new Point(12, 568);
            buttonEnviar.Name = "buttonEnviar";
            buttonEnviar.Size = new Size(367, 29);
            buttonEnviar.TabIndex = 7;
            buttonEnviar.Text = "Enviar";
            buttonEnviar.UseVisualStyleBackColor = false;
            buttonEnviar.Click += buttonEnviar_Click;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(12, 358);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(367, 27);
            textBoxEmail.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 335);
            label5.Name = "label5";
            label5.Size = new Size(132, 20);
            label5.TabIndex = 8;
            label5.Text = "Correo electrónico";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(12, 432);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(367, 27);
            textBoxPassword.TabIndex = 11;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 409);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 10;
            label6.Text = "Contraseña";
            // 
            // textBoxPasswordConfirm
            // 
            textBoxPasswordConfirm.Location = new Point(12, 506);
            textBoxPasswordConfirm.Name = "textBoxPasswordConfirm";
            textBoxPasswordConfirm.Size = new Size(367, 27);
            textBoxPasswordConfirm.TabIndex = 13;
            textBoxPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 483);
            label7.Name = "label7";
            label7.Size = new Size(151, 20);
            label7.TabIndex = 12;
            label7.Text = "Confirmar contraseña";
            // 
            // VentanaCrearUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(391, 614);
            Controls.Add(textBoxPasswordConfirm);
            Controls.Add(label7);
            Controls.Add(textBoxPassword);
            Controls.Add(label6);
            Controls.Add(textBoxEmail);
            Controls.Add(label5);
            Controls.Add(buttonEnviar);
            Controls.Add(labelIniciarSesion);
            Controls.Add(textBoxUsername);
            Controls.Add(label3);
            Controls.Add(textBoxNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "VentanaCrearUsuario";
            Text = "lniciar Sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private Label label1;
        private Label label2;
        private TextBox textBoxNombre;
        private Label label3;
        private TextBox textBoxUsername;
        private Label labelIniciarSesion;
        private Button buttonEnviar;
        private TextBox textBoxEmail;
        private Label label5;
        private TextBox textBoxPassword;
        private Label label6;
        private TextBox textBoxPasswordConfirm;
        private Label label7;
    }
}
