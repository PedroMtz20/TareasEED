using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Globalization;
using Aleaciones.BL.Utilities;
using Aleaciones.BL;

namespace Aleaciones.App
{
    public partial class frmFileUpload : Form
    {
        private Boolean flagError = false;

        public frmFileUpload()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void principalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPrincipal _frmPrincipal = new frmPrincipal();
            this.Hide();
            _frmPrincipal.ShowDialog();
            this.Close();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.ShowDialog();
                fileDialog.Filter = "allfiles|*.xlsx";
                txtPathFile.Text = fileDialog.FileName;

                DataTable dtExcel = new DataTable();

                ExcelFunctions ExcelToTable = new ExcelFunctions();
                lblTitleProgress.Visible = true;
                lblProgress.Visible = true;
                lblProgress.Text = "Procesando Archivo";
                dtExcel = ExcelToTable.getExcelFile(fileDialog.FileName);

                dataGridView1.DataSource = dtExcel;

                if (dtExcel != null)
                {
                    //Se arma clase para log del archivo
                  //  eHistoryFile log = new eHistoryFile();
                  //  log.idUser = 1;
                  //  log.namFile = fileDialog.SafeFileName.ToString();
                  //  log.descFilePath = fileDialog.FileName.ToString();
                  //  log.fileDate = DateTime.Now;
                  //  log.createdBy = 1;

                    // Se buscan nuevos elementos en las diferentes columnas
                  //  CheckNewProducts(dtExcel);
                   // CheckNewModels(dtExcel);
                    //CheckCalendar(dtExcel);

                    // Se da forma al tabla que servira de pivote
                   // dtPreparedTable.Clear();
                   // PrepareTable(dtExcel);

                   // CheckNewLines(dtPreparedTable);

                   // LoadWeekProgram(dtPreparedTable, log);
                   

                    lblTitleProgress.Visible = false;
                    lblProgress.Visible = false;
                    txtPathFile.Text = "";

                    if (flagError == false)
                        MessageBox.Show("El archivo fue cargado con éxito.", "Proceso Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblTitleProgress.Visible = false;
                    lblProgress.Visible = false;
                    txtPathFile.Text = "";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sorry, we couldn't find . Is it possible it was moved, renamed or deleted?")
                {
                    lblTitleProgress.Visible = false;
                    lblProgress.Visible = false;
                    txtPathFile.Text = "";
                  //  MessageBox.Show(csConstants.NoFileMessage, "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void analisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnalisis _frmAnalisis = new frmAnalisis();
            this.Hide();
            _frmAnalisis.ShowDialog();
            this.Close();
        }

        private void crudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteCrudo _frmReporteCrudo = new frmReporteCrudo();
            this.Hide();
            _frmReporteCrudo.ShowDialog();
            this.Close();
        }

        private void semanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteSemanal _frmReporteSemanal = new frmReporteSemanal();
            this.Hide();
            _frmReporteSemanal.ShowDialog();
            this.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.CatalogoUsuarios _catalogoUsuarios = new Catalogos.CatalogoUsuarios();
            this.Hide();
            _catalogoUsuarios.ShowDialog();
            this.Close();
        }

        private void metasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmMeta _Metas = new Catalogos.frmMeta();
            this.Hide();
            _Metas.ShowDialog();
            this.Close();
        }

        private void limiteDeTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmLimite _Limite = new Catalogos.frmLimite();
            this.Hide();
            _Limite.ShowDialog();
            this.Close();
        }
    }
}
