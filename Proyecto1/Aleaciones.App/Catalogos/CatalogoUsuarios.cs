using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Aleaciones.BL;
using Aleaciones.Entities;

namespace Aleaciones.App.Catalogos
{
    public partial class CatalogoUsuarios : Form
    {
        public CatalogoUsuarios()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void CatalogoUsuarios_Load(object sender, EventArgs e)
        {
           
        }

        protected void GetUsers()
        {
            try
            {
                UsersBL _UserBL = new UsersBL();
                ProfileBL _profileBL = new ProfileBL();
                List<eUser> listUser = _UserBL.All();
                List<eProfile> listProfile = _profileBL.All();

                var columns = from prod in listProfile
                              join t in listUser on prod.idProfile equals t.idProfile
                              orderby t.idUser
                              select new
                              {
                                  ID = t.idUser,
                                  USUARIO = t.namUser,
                                  CONTRASEÑA = t.userPass,
                                  PERFIL = prod.idProfile,
                                  CREADOPOR = t.createdBy,
                                  FECHA_ALTA = t.createdDate
                              };
                ConfigureGrid();
                dataGridView1.DataSource = columns.ToList();
                dataGridView1.Columns["CONTRASEÑA"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = false;
                pnlUser.Visible = true;
                SessionVariable.entityID = null;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbProfile.SelectedValue.ToString() != "0")
                {
                    eUser User = new eUser();
                    User.idUser = Convert.ToInt32(txtIdUser.Text == "" ? "0" : txtIdUser.Text);
                    User.namUser = txtUser.Text;
                    User.userPass = txtPass.Text;
                    User.idProfile = Convert.ToInt32(cbProfile.SelectedValue.ToString());

                    if (SessionVariable.entityID != null)
                        User.modifiedBy = 1;
                    else
                        User.createdBy = 1;

                    UsersBL _UserBL = new UsersBL();
                    _UserBL.Register(User);
                    MessageBox.Show(csConstants.SuccessMessage, csConstants.SuccessMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanText();
                    if (SessionVariable.entityID != null)
                    {
                        btnCancel_Click(null, null);
                    }
                }
                else
                    MessageBox.Show(csConstants.ValidateFields("Perfil"), "Validación de Captura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                txtIdUser.Text = "";
                cbProfile.SelectedIndex = -1;
                txtUser.Text = "";
                txtPass.Text = "";
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
                pnlUser.Visible = false;
                dataGridView1.Visible = true;
                SessionVariable.entityID = null;
                GetUsers();
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

        private void metaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmMeta _p = new Catalogos.frmMeta();
            this.Hide();
            _p.ShowDialog();
            this.Close();
        }

        private void limiteDeTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmLimite _p = new Catalogos.frmLimite();
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

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFileUpload _frmFileUpload = new frmFileUpload();
            this.Hide();
            _frmFileUpload.ShowDialog();
            this.Close();
        }

    }
}
