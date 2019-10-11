using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Data.SqlClient;
using System.Configuration;
using Aleaciones.BL;
using Aleaciones.Entities;
using Alreaciones.DL;

//Relacion: SubGroupData -> CharData

namespace Aleaciones.App
{
    public partial class frmAnalisis : Form
    {

        AnalisisBL _Analisis = new AnalisisBL();
        private LimiteDL _Limite = new LimiteDL();

        public frmAnalisis()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            GetDataFecha();
            getDataPorcentaje();
            FormatTable(dataGridView1);
            FormatTable(dataGridView2);
          
        }

        private void GetDataFecha()
        {
            try
            {
                List<eLimite> _LimiteModel = _Limite.GetAll();

                var groupValues = (from p in _LimiteModel
                                   group p by p.idLimit into grupo
                                   select new eLimite
                                   {
                                       numValue = grupo.Sum(x => x.numValue)
                                   }
                   ).ToList();

                int i_maxLineas = 0;
                i_maxLineas = _Analisis.GetMaxLinea(i_maxLineas);
                DataTable dt = new DataTable();
                for (int i = 0; i < i_maxLineas; i++)
                {
                    dt.Columns.Add((Convert.ToString(i + 1)));
                }
                DateTime[,] array = new DateTime[i_maxLineas, 3];
                array = _Analisis.GetByLinea();

                TimeSpan[] temp = new TimeSpan[i_maxLineas];

                for (int i = 0; i < i_maxLineas; i++)
                {
                    TimeSpan span = array[i, 0] - array[i, 1];
                    span = FormatDate(span);
                    if (span > TimeSpan.FromMinutes(groupValues[0].numValue))
                    {
                        span = TimeSpan.FromMinutes(groupValues[0].numValue);
                    }

                    temp[i] = span;

                }

                dt.Rows.Add(array[0, 0].ToShortTimeString(), array[1, 0].ToShortTimeString(), array[2, 0].ToShortTimeString(), array[3, 0].ToShortTimeString(), array[4, 0].ToShortTimeString());



                dt.Rows.Add(temp[0], temp[1], temp[2], temp[3], temp[4]);

                dt.Rows.Add(_Analisis.AvgTimeLingotes(1), _Analisis.AvgTimeLingotes(2), _Analisis.AvgTimeLingotes(3), _Analisis.AvgTimeLingotes(4), _Analisis.AvgTimeLingotes(5));

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                }   

        private void getDataPorcentaje()
        {
            string formula;
            int max = 0;
                max = _Analisis.GetMaxLinea(max);
            DataTable dt = new DataTable();
            for (int i = 0; i < max; i++)
            {
                dt.Columns.Add((Convert.ToString(i + 1)));
            }
            double[,] array = new double[max, 3];
            array = _Analisis.GetByPorcentaje();


            for (int i = 0; i < 3; i++)
            {
                dt.Rows.Add(array[0, i], array[1, i], array[2, i], array[3, i], array[4,i]);
            }

            for (int i = 0; i < max; i++)
            {
                formula = _Analisis.GetAnalisisLingotesRecomendados(i + 1);
                dt.Rows[2][i] = _Analisis.CantidadLingotes(float.Parse(array[i, 1].ToString()), float.Parse(array[i, 0].ToString()), formula);
            }
            
            dataGridView2.DataSource = dt;

        }

        private void FormatTable(DataGridView tbl)
        {
            tbl.RowTemplate.Height = 40;
            tbl.RowTemplate.Height = 40;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.ForeColor = Color.White;

        }

        private TimeSpan FormatDate(TimeSpan span)
        {
            String.Format("{0} minutos, {1} segundos",
            span.Minutes, span.Seconds);
            
            return span;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            List<eLimite> _LimiteModel = _Limite.GetAll();

            var groupValues = (from p in _LimiteModel
                               group p by p.idLimit into grupo
                               select new eLimite
                               {
                                   numValue = grupo.Sum(x => x.numValue)
                               }
               ).ToList();

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dataGridView1.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    if (row.Index == 1)
                    {
                        if ((row.Cells[i].Value.ToString()).Equals(TimeSpan.FromMinutes(groupValues[0].numValue).ToString()))
                        {
                            this.dataGridView1.Rows[1].Cells[i].Style.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DateTime[,] array = new DateTime[dataGridView1.Columns.Count, 3];
            array = _Analisis.GetByLinea();

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (Convert.ToInt32(dataGridView2.Rows[2].Cells[i].Value) != _Analisis.SumaLingotes((i + 1), Convert.ToDateTime(array[i,0])))
                {
                    dataGridView2.Rows[2].Cells[i].Style.BackColor = Color.Red;
                }else
                    dataGridView2.Rows[2].Cells[i].Style.BackColor = Color.DarkSeaGreen;
            }

            style.ForeColor = Color.White;
            int max = 0;
            max = _Analisis.GetMaxLinea(max);
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                for (int i = 0; i < max ; i++)
                {
                    if (Convert.ToDouble(row.Cells[i].Value) == -9999)
                    {
                        row.Cells[i].Style = style;
                    }
                }

            }
        }

        private void frmAnalisis_Load(object sender, EventArgs e)
        {
            this.label2.Text = "Hora Actual: " + DateTime.Now.ToShortTimeString().ToString();

        }

        private void principalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPrincipal _Principal = new frmPrincipal();
            this.Hide();
            _Principal.ShowDialog();
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

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFileUpload _frmFileUpload = new frmFileUpload();
            this.Hide();
            _frmFileUpload.ShowDialog();
            this.Close();
        }
    }
}
