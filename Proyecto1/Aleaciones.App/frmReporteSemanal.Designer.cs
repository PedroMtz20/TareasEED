namespace Aleaciones.App
{
    partial class frmReporteSemanal
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.LFin = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LInicio = new System.Windows.Forms.Label();
            this.LReporte = new System.Windows.Forms.Label();
            this.dtLineaLingotes = new System.Windows.Forms.DataGridView();
            this.l_muestreo = new System.Windows.Forms.Label();
            this.l_lingotes = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chLingotes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chMuestreo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.TablaLineas = new System.Windows.Forms.TableLayoutPanel();
            this.dtLineaMuestreo = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pantallaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.principalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limiteDeTiempoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLineaLingotes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chLingotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chMuestreo)).BeginInit();
            this.TablaLineas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtLineaMuestreo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 329);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(286, 26);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.TabStop = false;
            this.dateTimePicker1.Value = new System.DateTime(2019, 6, 21, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker2.CustomFormat = "";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePicker2.Location = new System.Drawing.Point(12, 414);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(286, 26);
            this.dateTimePicker2.TabIndex = 7;
            this.dateTimePicker2.TabStop = false;
            // 
            // LFin
            // 
            this.LFin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LFin.AutoSize = true;
            this.LFin.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFin.Location = new System.Drawing.Point(20, 382);
            this.LFin.Name = "LFin";
            this.LFin.Size = new System.Drawing.Size(126, 29);
            this.LFin.TabIndex = 11;
            this.LFin.Text = "Fecha Fin";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(197, 577);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 83);
            this.button1.TabIndex = 15;
            this.button1.Text = "Buscar....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(-307, -141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 170);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // LInicio
            // 
            this.LInicio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LInicio.AutoSize = true;
            this.LInicio.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInicio.Location = new System.Drawing.Point(20, 297);
            this.LInicio.Name = "LInicio";
            this.LInicio.Size = new System.Drawing.Size(153, 29);
            this.LInicio.TabIndex = 10;
            this.LInicio.Text = "Fecha Inicio";
            // 
            // LReporte
            // 
            this.LReporte.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LReporte.AutoSize = true;
            this.LReporte.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LReporte.Location = new System.Drawing.Point(20, 115);
            this.LReporte.Name = "LReporte";
            this.LReporte.Size = new System.Drawing.Size(103, 29);
            this.LReporte.TabIndex = 12;
            this.LReporte.Text = "Reporte";
            // 
            // dtLineaLingotes
            // 
            this.dtLineaLingotes.AllowUserToAddRows = false;
            this.dtLineaLingotes.AllowUserToDeleteRows = false;
            this.dtLineaLingotes.AllowUserToResizeColumns = false;
            this.dtLineaLingotes.AllowUserToResizeRows = false;
            this.dtLineaLingotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtLineaLingotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtLineaLingotes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtLineaLingotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtLineaLingotes.Location = new System.Drawing.Point(436, 30);
            this.dtLineaLingotes.Name = "dtLineaLingotes";
            this.dtLineaLingotes.RowHeadersVisible = false;
            this.dtLineaLingotes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dtLineaLingotes.Size = new System.Drawing.Size(433, 263);
            this.dtLineaLingotes.TabIndex = 1;
            // 
            // l_muestreo
            // 
            this.l_muestreo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l_muestreo.AutoSize = true;
            this.l_muestreo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_muestreo.Location = new System.Drawing.Point(164, 1);
            this.l_muestreo.Name = "l_muestreo";
            this.l_muestreo.Size = new System.Drawing.Size(104, 24);
            this.l_muestreo.TabIndex = 2;
            this.l_muestreo.Text = "Muestreo";
            // 
            // l_lingotes
            // 
            this.l_lingotes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l_lingotes.AutoSize = true;
            this.l_lingotes.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_lingotes.Location = new System.Drawing.Point(560, 1);
            this.l_lingotes.Name = "l_lingotes";
            this.l_lingotes.Size = new System.Drawing.Size(185, 24);
            this.l_lingotes.TabIndex = 3;
            this.l_lingotes.Text = "Agregar Lingotes";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TablaLineas);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(311, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 637);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(813, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 23;
            this.btnExport.Text = "Exportar";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.51381F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.48619F));
            this.tableLayoutPanel2.Controls.Add(this.chLingotes, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chMuestreo, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 57);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(905, 275);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // chLingotes
            // 
            this.chLingotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chLingotes.ChartAreas.Add(chartArea1);
            this.chLingotes.Location = new System.Drawing.Point(432, 3);
            this.chLingotes.Name = "chLingotes";
            this.chLingotes.Size = new System.Drawing.Size(470, 269);
            this.chLingotes.TabIndex = 9;
            // 
            // chMuestreo
            // 
            this.chMuestreo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chMuestreo.ChartAreas.Add(chartArea2);
            this.chMuestreo.Location = new System.Drawing.Point(3, 3);
            this.chMuestreo.Name = "chMuestreo";
            this.chMuestreo.Size = new System.Drawing.Size(423, 269);
            this.chMuestreo.TabIndex = 8;
            this.chMuestreo.Click += new System.EventHandler(this.chMuestreo_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "Colección de Aleaciones";
            // 
            // TablaLineas
            // 
            this.TablaLineas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablaLineas.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TablaLineas.ColumnCount = 2;
            this.TablaLineas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.61637F));
            this.TablaLineas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.38363F));
            this.TablaLineas.Controls.Add(this.dtLineaMuestreo, 0, 1);
            this.TablaLineas.Controls.Add(this.l_lingotes, 1, 0);
            this.TablaLineas.Controls.Add(this.l_muestreo, 0, 0);
            this.TablaLineas.Controls.Add(this.dtLineaLingotes, 1, 1);
            this.TablaLineas.Location = new System.Drawing.Point(19, 338);
            this.TablaLineas.Name = "TablaLineas";
            this.TablaLineas.RowCount = 2;
            this.TablaLineas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TablaLineas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TablaLineas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TablaLineas.Size = new System.Drawing.Size(873, 293);
            this.TablaLineas.TabIndex = 7;
            this.TablaLineas.Visible = false;
            // 
            // dtLineaMuestreo
            // 
            this.dtLineaMuestreo.AllowUserToAddRows = false;
            this.dtLineaMuestreo.AllowUserToDeleteRows = false;
            this.dtLineaMuestreo.AllowUserToResizeColumns = false;
            this.dtLineaMuestreo.AllowUserToResizeRows = false;
            this.dtLineaMuestreo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtLineaMuestreo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtLineaMuestreo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtLineaMuestreo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtLineaMuestreo.Location = new System.Drawing.Point(4, 30);
            this.dtLineaMuestreo.Name = "dtLineaMuestreo";
            this.dtLineaMuestreo.RowHeadersVisible = false;
            this.dtLineaMuestreo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dtLineaMuestreo.Size = new System.Drawing.Size(425, 263);
            this.dtLineaMuestreo.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Reporte Crudo"});
            this.comboBox1.Location = new System.Drawing.Point(12, 168);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(286, 37);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.TabStop = false;
            this.comboBox1.Text = "Reporte Semanal";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.Location = new System.Drawing.Point(12, 577);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 83);
            this.button2.TabIndex = 16;
            this.button2.Text = "Buscar por Equipo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pantallaToolStripMenuItem,
            this.catalogoToolStripMenuItem,
            this.sistemasToolStripMenuItem,
            this.importarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pantallaToolStripMenuItem
            // 
            this.pantallaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.principalToolStripMenuItem,
            this.analisisToolStripMenuItem});
            this.pantallaToolStripMenuItem.Name = "pantallaToolStripMenuItem";
            this.pantallaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pantallaToolStripMenuItem.Text = "Pantalla";
            // 
            // principalToolStripMenuItem
            // 
            this.principalToolStripMenuItem.Name = "principalToolStripMenuItem";
            this.principalToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.principalToolStripMenuItem.Text = "Principal";
            this.principalToolStripMenuItem.Click += new System.EventHandler(this.principalToolStripMenuItem_Click_1);
            // 
            // analisisToolStripMenuItem
            // 
            this.analisisToolStripMenuItem.Name = "analisisToolStripMenuItem";
            this.analisisToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.analisisToolStripMenuItem.Text = "Analisis";
            this.analisisToolStripMenuItem.Click += new System.EventHandler(this.analisisToolStripMenuItem_Click);
            // 
            // catalogoToolStripMenuItem
            // 
            this.catalogoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem});
            this.catalogoToolStripMenuItem.Name = "catalogoToolStripMenuItem";
            this.catalogoToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.catalogoToolStripMenuItem.Text = "Catalogo";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // sistemasToolStripMenuItem
            // 
            this.sistemasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metasToolStripMenuItem,
            this.limiteDeTiempoToolStripMenuItem});
            this.sistemasToolStripMenuItem.Name = "sistemasToolStripMenuItem";
            this.sistemasToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.sistemasToolStripMenuItem.Text = "Sistemas";
            // 
            // metasToolStripMenuItem
            // 
            this.metasToolStripMenuItem.Name = "metasToolStripMenuItem";
            this.metasToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.metasToolStripMenuItem.Text = "Metas";
            this.metasToolStripMenuItem.Click += new System.EventHandler(this.metasToolStripMenuItem_Click);
            // 
            // limiteDeTiempoToolStripMenuItem
            // 
            this.limiteDeTiempoToolStripMenuItem.Name = "limiteDeTiempoToolStripMenuItem";
            this.limiteDeTiempoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.limiteDeTiempoToolStripMenuItem.Text = "Limite de Tiempo";
            this.limiteDeTiempoToolStripMenuItem.Click += new System.EventHandler(this.limiteDeTiempoToolStripMenuItem_Click);
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.importarToolStripMenuItem.Text = "Importar";
            this.importarToolStripMenuItem.Click += new System.EventHandler(this.importarToolStripMenuItem_Click);
            // 
            // frmReporteSemanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1264, 701);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LReporte);
            this.Controls.Add(this.LFin);
            this.Controls.Add(this.LInicio);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmReporteSemanal";
            this.Text = "ReporteSemanal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLineaLingotes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chLingotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chMuestreo)).EndInit();
            this.TablaLineas.ResumeLayout(false);
            this.TablaLineas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtLineaMuestreo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label LFin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LInicio;
        private System.Windows.Forms.Label LReporte;
        private System.Windows.Forms.DataGridView dtLineaLingotes;
        private System.Windows.Forms.Label l_muestreo;
        private System.Windows.Forms.Label l_lingotes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel TablaLineas;
        private System.Windows.Forms.DataGridView dtLineaMuestreo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chMuestreo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chLingotes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pantallaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem principalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analisisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limiteDeTiempoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.Button btnExport;
    }
}