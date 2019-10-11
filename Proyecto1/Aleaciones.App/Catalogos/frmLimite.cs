using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Aleaciones.BL;
using Aleaciones.Entities;

namespace Aleaciones.App.Catalogos
{
    public partial class frmLimite : Form
    {
        public frmLimite()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        protected void GetLimite()
        {
            try
            {
                LimiteBL _LimiteBL = new LimiteBL();
                List<eLimite> listlimite = _LimiteBL.All();

                var columns = from t in listlimite
                              select new
                              {
                                  ID = t.idLimit,
                                  LIMITE = TimeSpan.FromMinutes(t.numValue),
                                  CREADO_POR = t.createdBy,
                                  FECHA_ALTA = t.createdDate,
                                  MODIFICADO_POR = t.modifiedBy,
                                  FECHA_MODIFICADO = t.modifiedDate
                              };
                ConfigureGrid();
                dataGridView1.DataSource = columns.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        protected void ConfigureGrid()
        {
            try
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void limiteDeTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = false;
                pnlLimite.Visible = true;
                SessionVariable.entityID = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                    eLimite Limite = new eLimite();
                    Limite.numValue = Convert.ToDouble(txtLimite.Text == "" ? "0" : txtLimite.Text);

                    if (SessionVariable.entityID != null)
                        Limite.modifiedBy = 1;
                    else
                        Limite.createdBy = 1;

                    LimiteBL _LimiteBL = new LimiteBL();
                    _LimiteBL.Register(Limite);
                    MessageBox.Show(csConstants.SuccessMessage, csConstants.SuccessMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanText();
                    if (SessionVariable.entityID != null)
                    {
                        btnCancel_Click(null, null);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }


        protected void CleanText()
        {
            try
            {
                txtLimite.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CleanText();
                pnlLimite.Visible = false;
                dataGridView1.Visible = true;
                SessionVariable.entityID = null;
                GetLimite();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void frmLimite_Load(object sender, EventArgs e)
        {
            GetLimite();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //SessionVariable.entityID != null
                if (SessionVariable.entityID == null)
                {
                    DialogResult _answer;
                    _answer = MessageBox.Show(csConstants.DeleteMessage, csConstants.ConfirmMessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (_answer == DialogResult.Yes)
                    {
                        LimiteBL _UserBL = new LimiteBL();
                        _UserBL.Delete(Convert.ToInt32(dataGridView1.Rows[Convert.ToInt32(SessionVariable.entityID)].Cells[0].Value.ToString())); //User
                        MessageBox.Show(csConstants.DelSuccessMessage, csConstants.DelSuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetLimite();
                    }
                }
                else
                {
                    MessageBox.Show(csConstants.ValidateDelete, "Validación de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text != "")
                {
                    CleanText();
                    pnlLimite.Visible = false;
                    dataGridView1.Visible = true;
                    SessionVariable.entityID = null;
                    GetLimite();

                    DataTable dtSearch = new DataTable();
                    dtSearch.Columns.Add("ID", typeof(System.Int32));
                    dtSearch.Columns.Add("LIMITE", typeof(System.Double));
                    dtSearch.Columns.Add("CREADO_POR", typeof(System.Int32));
                    dtSearch.Columns.Add("FECHA_ALTA", typeof(System.DateTime));
                    dtSearch.Columns.Add("MODIFICADO_POR", typeof(System.Int32));
                    dtSearch.Columns.Add("FECHA_MODIFICADO", typeof(System.DateTime));

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.DataBoundItem != null)
                        {
                            if (row.Cells[0].Value.ToString().Contains(txtBuscar.Text) || row.Cells[1].Value.ToString().Contains(txtBuscar.Text))
                            {
                                DataRow searchRow = dtSearch.NewRow();
                                searchRow["ID"] = row.Cells[0].Value;
                                searchRow["LIMITE"] = row.Cells[1].Value;
                                searchRow["CREADO_POR"] = row.Cells[2].Value;
                                searchRow["FECHA_ALTA"] = row.Cells[3].Value;
                                searchRow["MODIFICADO_POR"] = row.Cells[4].Value;
                                searchRow["FECHA_MODIFICADO"] = row.Cells[5].Value;

                                dtSearch.Rows.Add(searchRow);
                            }
                        }
                    }
                    dataGridView1.DataSource = dtSearch;
                }
                else
                    GetLimite();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipal _p = new frmPrincipal();
            this.Hide();
            _p.ShowDialog();
            this.Close();
        }

        private void analisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnalisis _p = new frmAnalisis();
            this.Hide();
            _p.ShowDialog();
            this.Close();
        }

        private void semanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteSemanal _p = new frmReporteSemanal();
            this.Hide();
            _p.ShowDialog();
            this.Close();
        }

        private void crudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteCrudo _frmReporteCrudo = new frmReporteCrudo();
            this.Hide();
            _frmReporteCrudo.ShowDialog();
            this.Close();
        }

        private void uusariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.CatalogoUsuarios _P = new Catalogos.CatalogoUsuarios();
            this.Hide();
            _P.ShowDialog();
            this.Close();
        }

        private void metaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmMeta _p = new Catalogos.frmMeta();
            this.Hide();
            _p.ShowDialog();
            this.Close();
        }

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFileUpload _frmFileUpload = new frmFileUpload();
            this.Hide();
            _frmFileUpload.ShowDialog();
            this.Close();
        }
    }
}
