namespace Aleaciones.App
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imgLogin = new System.Windows.Forms.PictureBox();
            this.L_Usuario = new System.Windows.Forms.Label();
            this.IngresaUsuario = new System.Windows.Forms.TextBox();
            this.L_Contraseña = new System.Windows.Forms.Label();
            this.IngresaContraseña = new System.Windows.Forms.TextBox();
            this.buttonEntrar = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLogin
            // 
            this.imgLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgLogin.Image = ((System.Drawing.Image)(resources.GetObject("imgLogin.Image")));
            this.imgLogin.Location = new System.Drawing.Point(602, 237);
            this.imgLogin.Name = "imgLogin";
            this.imgLogin.Size = new System.Drawing.Size(153, 137);
            this.imgLogin.TabIndex = 0;
            this.imgLogin.TabStop = false;
            // 
            // L_Usuario
            // 
            this.L_Usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L_Usuario.AutoSize = true;
            this.L_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Usuario.Location = new System.Drawing.Point(598, 384);
            this.L_Usuario.Name = "L_Usuario";
            this.L_Usuario.Size = new System.Drawing.Size(79, 24);
            this.L_Usuario.TabIndex = 1;
            this.L_Usuario.Text = "Usuario:";
            // 
            // IngresaUsuario
            // 
            this.IngresaUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IngresaUsuario.Location = new System.Drawing.Point(602, 411);
            this.IngresaUsuario.Name = "IngresaUsuario";
            this.IngresaUsuario.Size = new System.Drawing.Size(168, 20);
            this.IngresaUsuario.TabIndex = 2;
            // 
            // L_Contraseña
            // 
            this.L_Contraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L_Contraseña.AutoSize = true;
            this.L_Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Contraseña.Location = new System.Drawing.Point(598, 446);
            this.L_Contraseña.Name = "L_Contraseña";
            this.L_Contraseña.Size = new System.Drawing.Size(111, 24);
            this.L_Contraseña.TabIndex = 3;
            this.L_Contraseña.Text = "Contraseña:";
            // 
            // IngresaContraseña
            // 
            this.IngresaContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IngresaContraseña.Location = new System.Drawing.Point(602, 473);
            this.IngresaContraseña.Name = "IngresaContraseña";
            this.IngresaContraseña.Size = new System.Drawing.Size(168, 20);
            this.IngresaContraseña.TabIndex = 4;
            // 
            // buttonEntrar
            // 
            this.buttonEntrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonEntrar.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonEntrar.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonEntrar.ForeColor = System.Drawing.Color.White;
            this.buttonEntrar.Location = new System.Drawing.Point(602, 523);
            this.buttonEntrar.Name = "buttonEntrar";
            this.buttonEntrar.Size = new System.Drawing.Size(86, 36);
            this.buttonEntrar.TabIndex = 5;
            this.buttonEntrar.Text = "Entrar";
            this.buttonEntrar.UseVisualStyleBackColor = false;
            this.buttonEntrar.Click += new System.EventHandler(this.buttonEntrar_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCerrar.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonCerrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrar.ForeColor = System.Drawing.Color.White;
            this.buttonCerrar.Location = new System.Drawing.Point(694, 523);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(76, 36);
            this.buttonCerrar.TabIndex = 6;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = false;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1410, 802);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonEntrar);
            this.Controls.Add(this.IngresaContraseña);
            this.Controls.Add(this.L_Contraseña);
            this.Controls.Add(this.IngresaUsuario);
            this.Controls.Add(this.L_Usuario);
            this.Controls.Add(this.imgLogin);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Plan de Producción";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLogin;
        private System.Windows.Forms.Label L_Usuario;
        private System.Windows.Forms.TextBox IngresaUsuario;
        private System.Windows.Forms.Label L_Contraseña;
        private System.Windows.Forms.TextBox IngresaContraseña;
        private System.Windows.Forms.Button buttonEntrar;
        private System.Windows.Forms.Button buttonCerrar;
    }
}

