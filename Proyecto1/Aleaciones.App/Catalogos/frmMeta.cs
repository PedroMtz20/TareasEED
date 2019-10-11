using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aleaciones.Entities;
using Aleaciones.BL;

namespace Aleaciones.App.Catalogos
{
    public partial class frmMeta : Form
    {
        public frmMeta()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        protected void GetGoal()
        {
            try
            {
                GoalBL _GoalBL = new GoalBL();
                List<eGoal> listGoal = _GoalBL.GetAll();

                var columns = from t in listGoal
                              select new
                              {
                                  ID = t.IDMeta,
                                  META1 = TimeSpan.FromMinutes(t.Meta1),
                                  META2 = TimeSpan.FromMinutes(t.Meta2),
                                  META3 = TimeSpan.FromMinutes(t.Meta3)
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

        private void frmMeta_Load(object sender, EventArgs e)
        {
            GetGoal();
        }

            private void uusariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.CatalogoUsuarios _P = new Catalogos.CatalogoUsuarios();
            this.Hide();
            _P.ShowDialog();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                eGoal Goal = new eGoal();
                Goal.Meta1 = Convert.ToDouble(txtMeta1.Text == "" ? "0" : txtMeta1.Text);
                Goal.Meta2 = Convert.ToDouble(txtMeta2.Text == "" ? "0" : txtMeta2.Text);
                Goal.Meta3 = Convert.ToDouble(txtMeta3.Text == "" ? "0" : txtMeta3.Text);


                GoalBL _GoalBL = new GoalBL();
                _GoalBL.Register(Goal);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CleanText();
                pnlGoal.Visible = false;
                dataGridView1.Visible = true;
                SessionVariable.entityID = null;
                GetGoal();
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
                txtMeta1.Text = "";
                txtMeta2.Text = "";
                txtMeta3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                        GoalBL _GoalBL = new GoalBL();
                        _GoalBL.Delete(Convert.ToInt32(dataGridView1.Rows[Convert.ToInt32(SessionVariable.entityID)].Cells[0].Value.ToString())); //User
                        MessageBox.Show(csConstants.DelSuccessMessage, csConstants.DelSuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetGoal();
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
                    pnlGoal.Visible = false;
                    dataGridView1.Visible = true;
                    SessionVariable.entityID = null;
                    GetGoal();

                    DataTable dtSearch = new DataTable();
                    dtSearch.Columns.Add("ID", typeof(System.Int32));
                    dtSearch.Columns.Add("META1", typeof(System.Double));
                    dtSearch.Columns.Add("META2", typeof(System.Double));
                    dtSearch.Columns.Add("META3", typeof(System.Double));

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.DataBoundItem != null)
                        {
                            if (row.Cells[0].Value.ToString().Contains(txtBuscar.Text) || row.Cells[1].Value.ToString().Contains(txtBuscar.Text))
                            {
                                DataRow searchRow = dtSearch.NewRow();
                                searchRow["ID"] = row.Cells[0].Value;
                                searchRow["META1"] = row.Cells[1].Value;
                                searchRow["META2"] = row.Cells[2].Value;
                                searchRow["META3"] = row.Cells[3].Value;

                                dtSearch.Rows.Add(searchRow);
                            }
                        }
                    }
                    dataGridView1.DataSource = dtSearch;
                }
                else
                    GetGoal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = false;
                pnlGoal.Visible = true;
                SessionVariable.entityID = null;
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

        private void analisisToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAnalisis _p = new frmAnalisis();
            this.Hide();
            _p.ShowDialog();
            this.Close();
        }

        private void crudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteCrudo _p = new frmReporteCrudo();
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

        private void uusariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Catalogos.CatalogoUsuarios _catalogoUsuarios = new Catalogos.CatalogoUsuarios();
            this.Hide();
            _catalogoUsuarios.ShowDialog();
            this.Close();
        }

        private void limiteDeTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmLimite _p = new Catalogos.frmLimite();
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
