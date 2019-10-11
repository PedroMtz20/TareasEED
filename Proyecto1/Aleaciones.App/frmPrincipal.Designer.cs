namespace Aleaciones.App
{
    partial class frmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pantallasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.análisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mensualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semanalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargaArchivoStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pantallasToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.catalogosToolStripMenuItem,
            this.sistemaToolStripMenuItem,
            this.cargaArchivoStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pantallasToolStripMenuItem
            // 
            this.pantallasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.análisisToolStripMenuItem});
            this.pantallasToolStripMenuItem.Name = "pantallasToolStripMenuItem";
            this.pantallasToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pantallasToolStripMenuItem.Text = "Pantalla";
            // 
            // análisisToolStripMenuItem
            // 
            this.análisisToolStripMenuItem.Name = "análisisToolStripMenuItem";
            this.análisisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.análisisToolStripMenuItem.Text = "Análisis";
            this.análisisToolStripMenuItem.Click += new System.EventHandler(this.análisisToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mensualToolStripMenuItem,
            this.semanalToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // mensualToolStripMenuItem
            // 
            this.mensualToolStripMenuItem.Name = "mensualToolStripMenuItem";
            this.mensualToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mensualToolStripMenuItem.Text = "Crudo";
            this.mensualToolStripMenuItem.Click += new System.EventHandler(this.mensualToolStripMenuItem_Click);
            // 
            // semanalToolStripMenuItem
            // 
            this.semanalToolStripMenuItem.Name = "semanalToolStripMenuItem";
            this.semanalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.semanalToolStripMenuItem.Text = "Semanal";
            this.semanalToolStripMenuItem.Click += new System.EventHandler(this.semanalToolStripMenuItem_Click);
            // 
            // catalogosToolStripMenuItem
            // 
            this.catalogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem});
            this.catalogosToolStripMenuItem.Name = "catalogosToolStripMenuItem";
            this.catalogosToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.catalogosToolStripMenuItem.Text = "Catalogos";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metasToolStripMenuItem,
            this.diferenciaToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // metasToolStripMenuItem
            // 
            this.metasToolStripMenuItem.Name = "metasToolStripMenuItem";
            this.metasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.metasToolStripMenuItem.Text = "Metas";
            this.metasToolStripMenuItem.Click += new System.EventHandler(this.metasToolStripMenuItem_Click);
            // 
            // diferenciaToolStripMenuItem
            // 
            this.diferenciaToolStripMenuItem.Name = "diferenciaToolStripMenuItem";
            this.diferenciaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.diferenciaToolStripMenuItem.Text = "Limite de Tiempo";
            this.diferenciaToolStripMenuItem.Click += new System.EventHandler(this.diferenciaToolStripMenuItem_Click);
            // 
            // cargaArchivoStripMenuItem
            // 
            this.cargaArchivoStripMenuItem.Name = "cargaArchivoStripMenuItem";
            this.cargaArchivoStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.cargaArchivoStripMenuItem.Text = "Carga Archivo";
            this.cargaArchivoStripMenuItem.Click += new System.EventHandler(this.importarToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Sistema de Plan de Producción";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pantallasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem análisisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mensualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semanalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargaArchivoStripMenuItem;
    }
}