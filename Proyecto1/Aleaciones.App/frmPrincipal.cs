using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aleaciones.App
{
    public partial class frmPrincipal : Form
    {

        public frmPrincipal()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void análisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnalisis _frmAnalisis = new frmAnalisis();
            this.Hide();
            _frmAnalisis.ShowDialog();
            this.Close();
        }

        private void mensualToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void diferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmLimite _Limite = new Catalogos.frmLimite();
            this.Hide();
            _Limite.ShowDialog();
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
