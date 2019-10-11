using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aleaciones.BL;
using Alreaciones.DL;
using Aleaciones.Entities;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;

namespace Aleaciones.App
{
    public partial class frmReporteSemanal : Form
    {
        private ReporteSemanalBL _reporte = new ReporteSemanalBL();
        private AnalisisBL _Analisis = new AnalisisBL();
        private LimiteDL _Limite = new LimiteDL();
        Microsoft.Office.Interop.Excel.Application aplicacion;
        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
        string x;
        int y;
        private eLimite _test = new eLimite();
        
        public frmReporteSemanal()
        {

            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            
            FormatTable(dtLineaMuestreo);
        }   

        private void GetTimesMuestreo(DateTime j, DateTime z)
        {
            chMuestreo.Titles.Add(new Title("Muestreo"));
            int i_maxLineas = 0;
            i_maxLineas = _Analisis.GetMaxLinea(i_maxLineas);
            List<eLimite> _LimiteModel = _Limite.GetAll();

            var groupValues = (from p in _LimiteModel
                               group p by p.idLimit into grupo
                               select new eLimite
                               {
                                   numValue = grupo.Sum(x => x.numValue)
                               }
                               ).ToList();

            List<TimeSpan> Promedios = new List<TimeSpan>();
            double prom;
            int cont = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("Linea");
            dt.Columns.Add("Tiempo Promedio");
            dt.Columns.Add("Max");
            dt.Columns.Add("Min");
            dt.Columns.Add("Numero de muestras");
            dt.Columns.Add("Veces que se tardo mas de x horas en volver a colectar");
            try
            {
                for (int i = 0; i < i_maxLineas; i++)
                {
                    cont = 0;
                    Promedios = _reporte.Avgtimes((i + 1), j, z);
                    foreach (TimeSpan diff in Promedios)
                    {
                        if (diff >= TimeSpan.FromMinutes(groupValues[0].numValue))
                        {
                            cont++;
                        }
                    }
                    prom = Promedios.Average(timeSpan => timeSpan.Ticks);
                    long longAverageTicks = Convert.ToInt64(prom);
                    TimeSpan span = new TimeSpan(longAverageTicks);
                    dt.Rows.Add((i + 1), span.ToString(@"dd\.hh\:mm\:ss"), Promedios.Max().ToString(@"dd\.hh\:mm\:ss"), Promedios.Min().ToString(@"dd\.hh\:mm\:ss"), (Promedios.Count + 2), cont);
                    FillChartLine(Promedios,cont,chMuestreo);
                }


            }
            catch (Exception e){
                MessageBox.Show("No se encontraron datos en la tabla muestreo");
            }
             dtLineaMuestreo.DataSource = dt;
        }

        private void GetTimesLingotes(DateTime j, DateTime z)
        {
            chLingotes.Titles.Add(new Title("Lingotes"));
            int i_maxLineas = 0;
            i_maxLineas = _Analisis.GetMaxLinea(i_maxLineas);
            List<eLimite> _LimiteModel = _Limite.GetAll();

            var groupValues = (from p in _LimiteModel
                               group p by p.idLimit into grupo
                               select new eLimite
                               {
                                   numValue = grupo.Sum(x => x.numValue)
                               }
                               ).ToList();

            List<TimeSpan> Promedios = new List<TimeSpan>();
            double prom;
            int cont = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("Linea");
            dt.Columns.Add("Tiempo Promedio");
            dt.Columns.Add("Max");
            dt.Columns.Add("Min");
            dt.Columns.Add("Numero de muestras");
            dt.Columns.Add("Veces que se tardo mas de x horas en volver a colectar");
            try
            {
                for (int i = 0; i < i_maxLineas; i++)
                {
                    cont = 0;
                    Promedios = _reporte.AvgtimesLingotes((i + 1), j, z);
                    foreach (TimeSpan diff in Promedios)
                    {
                        if (diff >= TimeSpan.FromMinutes(groupValues[0].numValue))
                        {
                            cont++;
                        }
                    }
                    prom = Promedios.Average(timeSpan => timeSpan.Ticks);
                    long longAverageTicks = Convert.ToInt64(prom);
                    TimeSpan span = new TimeSpan(longAverageTicks);
                    
                    dt.Rows.Add((i + 1), span.ToString(@"dd\.hh\:mm\:ss"), Promedios.Max().ToString(@"dd\.hh\:mm\:ss"), Promedios.Min().ToString(@"dd\.hh\:mm\:ss"), (Promedios.Count + 2), cont);
                    FillChartLine(Promedios, cont, chLingotes);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se encontraron datos en la tabla lingotes");
            }
            dtLineaLingotes.DataSource = dt;
        }

        private void FormatTable(DataGridView tbl)
        {
            tbl.RowTemplate.Height = 35;
            tbl.RowTemplate.Height = 35;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.ForeColor = Color.White;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FillChartLine(List<TimeSpan> list,int cont, Chart chart)
        {
                    try
                    {

                        int series = chart.Series.Count;
                        for (int i = 0 ; i < 1; i++)
                        {
                            if (chart.Series.Count == 0)
                            {
                                chart.Series.Add(new Series("Series2"));
                                chart.Series.Add(new Series("Series3"));
                                chart.Series["Series2"].ChartType = SeriesChartType.StackedColumn;
                                chart.Series["Series2"].IsValueShownAsLabel = true;
                                chart.Series["Series3"].ChartType = SeriesChartType.StackedColumn;
                                chart.Series["Series3"].IsValueShownAsLabel = true;
                                chart.Series["Series2"]["PixelPointWidth"] = "35";
                                chart.Series["Series3"]["PixelPointWidth"] = "35";
                            }
                            else
                            {
                                series = chart.Series["Series2"].Points.Count;
                            }   
                            x = ((series+1)).ToString();
                                y = Convert.ToInt32(list.Count - cont + 2);
                            chart.Series["Series2"].Points.AddXY(x, y);
                            if (cont >= 1)
                            {
                                chart.Series["Series3"].Points.AddXY(x, cont);
                                chart.Series["Series3"].Color = Color.Red;
                                chart.DataManipulator.InsertEmptyPoints(1, IntervalType.Number, "Series2, Series3 ");
                            }
                            else
                            {
                                chart.Series["Series3"].Points.AddXY(x, 0);
                            }
                    
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
                    }
        }

        private void chMuestreo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnExport.Visible = true;
            TablaLineas.Show();
            chMuestreo.Series.Clear();
            chMuestreo.Titles.Clear();
            chLingotes.Series.Clear();
            chLingotes.Titles.Clear();
            GetTimesMuestreo(dateTimePicker1.Value, dateTimePicker2.Value);
            GetTimesLingotes(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnExport.Visible = true;
            TablaLineas.Show();
            chMuestreo.Series.Clear();
            chMuestreo.Titles.Clear();
            chLingotes.Series.Clear();
            chLingotes.Titles.Clear();
            GetTimesMuestreoEquipos(dateTimePicker1.Value, dateTimePicker2.Value);
            GetTimesLingotesEquipos(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void GetTimesMuestreoEquipos(DateTime j, DateTime z)
        {
            chMuestreo.Titles.Add(new Title("Muestreo"));
            List<eLimite> _LimiteModel = _Limite.GetAll();

            var groupValues = (from p in _LimiteModel
                               group p by p.idLimit into grupo
                               select new eLimite
                               {
                                   numValue = grupo.Sum(x => x.numValue)
                               }
                               ).ToList();
            
            List<TimeSpan> Promedios = new List<TimeSpan>();
            List<DateTime> Turnos = new List<DateTime>();
            double prom;
            int cont = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("Equipo");
            dt.Columns.Add("Turno");
            dt.Columns.Add("Tiempo Promedio");
            dt.Columns.Add("Max");
            dt.Columns.Add("Min");
            dt.Columns.Add("Numero de muestras");
            dt.Columns.Add("Veces que se tardo mas de x horas en volver a colectar");
            try
            {
                Turnos = _reporte.GetTurnos();
                for (int i = 0; i < 3; i++)
                {
                    cont = 0;
                        Promedios = _reporte.AvgtimesEquipos(j, z, Turnos[i*2].ToShortTimeString(), Turnos[i*2+1].ToShortTimeString());
                    foreach (TimeSpan diff in Promedios)
                    {
                        if (diff >= TimeSpan.FromMinutes(groupValues[0].numValue))
                        {
                            cont++;
                        }
                    }
                    if (Promedios != null)
                    {
                        prom = Promedios.Average(timeSpan => timeSpan.Ticks);
                        long longAverageTicks = Convert.ToInt64(prom);
                        TimeSpan span = new TimeSpan(longAverageTicks);
                        dt.Rows.Add((i + 1), (i+1) , span.ToString(@"dd\.hh\:mm\:ss"), Promedios.Max().ToString(@"dd\.hh\:mm\:ss"), Promedios.Min().ToString(@"dd\.hh\:mm\:ss"), (Promedios.Count + 2), cont);
                        FillChartLine(Promedios, cont, chMuestreo);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("No se encontraron datos en la tabla muestreo");
            }
            dtLineaMuestreo.DataSource = dt;
        }

        private void GetTimesLingotesEquipos(DateTime j, DateTime z)
        {
            chLingotes.Titles.Add(new Title("Lingotes"));
            List<eLimite> _LimiteModel = _Limite.GetAll();

            var groupValues = (from p in _LimiteModel
                               group p by p.idLimit into grupo
                               select new eLimite
                               {
                                   numValue = grupo.Sum(x => x.numValue)
                               }
                               ).ToList();

            List<TimeSpan> Promedios = new List<TimeSpan>();
            List<DateTime> Turnos = new List<DateTime>();
            double prom;
            int cont = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("Equipo");
            dt.Columns.Add("Turno");
            dt.Columns.Add("Tiempo Promedio");
            dt.Columns.Add("Max");
            dt.Columns.Add("Min");
            dt.Columns.Add("Numero de muestras");
            dt.Columns.Add("Veces que se tardo mas de x horas en volver a colectar");
            try
            {
                Turnos = _reporte.GetTurnos();
                for (int i = 0; i < 3; i++)
                {
                    cont = 0;
                        Promedios = _reporte.AvgtimesLingotesEquipos(j, z, Turnos[i*2].ToShortTimeString(), Turnos[i*2 + 1].ToShortTimeString());
                    foreach (TimeSpan diff in Promedios)
                    {
                        if (diff >= TimeSpan.FromMinutes(groupValues[0].numValue))
                        {
                            cont++;
                        }
                    }
                    prom = Promedios.Average(timeSpan => timeSpan.Ticks);
                    long longAverageTicks = Convert.ToInt64(prom);
                    TimeSpan span = new TimeSpan(longAverageTicks);

                    dt.Rows.Add((i + 1),(i+1) , span.ToString(@"dd\.hh\:mm\:ss"), Promedios.Max().ToString(@"dd\.hh\:mm\:ss"), Promedios.Min().ToString(@"dd\.hh\:mm\:ss"), (Promedios.Count + 2), cont);
                    FillChartLine(Promedios, cont, chLingotes);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se encontraron datos en la tabla lingotes");
            }
            dtLineaLingotes.DataSource = dt;
        }

        private void principalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPrincipal _frmPrincipal = new frmPrincipal();
            this.Hide();
            _frmPrincipal.ShowDialog();
            this.Close();
        }

        private void analisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnalisis _frmAnalisis = new frmAnalisis();
            this.Hide();
            _frmAnalisis.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Reporte Crudo")
            {
                frmReporteCrudo _frmReporteCrudo = new frmReporteCrudo();
                this.Hide();
                _frmReporteCrudo.ShowDialog();
                this.Close();
            }
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["ChartPath"]);

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                libros_trabajo.Worksheets.Add();
                libros_trabajo.Worksheets.Add();
                libros_trabajo.Worksheets.Add();

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    string nomImagen = "chart_" + DateTime.Now.Millisecond.ToString();

                    Microsoft.Office.Interop.Excel.Worksheet hoja1;
                    hoja1 = libros_trabajo.Worksheets[1];
                    hoja1 = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                    hoja1.Name = "Muestreo";
                   

                    for (int x = 1; x < dtLineaMuestreo.Columns.Count + 1; x++)
                    {
                        hoja1.Cells[1, x] = dtLineaMuestreo.Columns[x - 1].HeaderText;
                    }

                    for (int x = 0; x < dtLineaMuestreo.Rows.Count; x++)
                    {
                        for (int j = 0; j < dtLineaMuestreo.Columns.Count; j++)
                        {
                            if (dtLineaMuestreo.Rows[x].Cells[j].Value != null)
                            {
                                hoja1.Cells[x + 2, j + 1] = dtLineaMuestreo.Rows[x].Cells[j].Value.ToString();
                            }
                        }
                        hoja1.Columns[x + 1].ColumnWidth = 18;
                    }

                    Microsoft.Office.Interop.Excel.Worksheet hoja2;
                    hoja2 = libros_trabajo.Worksheets[2];
                    hoja2 = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(2);
                    hoja2.Name = "Lingotes";

                    for (int x = 1; x < dtLineaLingotes.Columns.Count + 1; x++)
                    {
                        hoja2.Cells[1, x] = dtLineaLingotes.Columns[x - 1].HeaderText;
                    }

                    for (int x = 0; x < dtLineaLingotes.Rows.Count; x++)
                    {
                        for (int j = 0; j < dtLineaLingotes.Columns.Count; j++)
                        {
                            if (dtLineaLingotes.Rows[x].Cells[j].Value != null)
                            {
                                hoja2.Cells[x + 2, j + 1] = dtLineaLingotes.Rows[x].Cells[j].Value.ToString();
                            }
                        }
                        hoja2.Columns[x + 1].ColumnWidth = 18;
                    }

                    Microsoft.Office.Interop.Excel.Worksheet hoja3;
                    hoja3 = libros_trabajo.Worksheets[3];
                    hoja3 = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(3);
                    hoja3.Name = "GraficaMuestreo";

                    Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)hoja3.Cells[5, 1];

                    chMuestreo.SaveImage(ConfigurationManager.AppSettings["ChartPath"].ToString() + nomImagen + "_2" + ".png", ImageFormat.Png);

                    Image oImage = Image.FromFile(ConfigurationManager.AppSettings["ChartPath"].ToString() + nomImagen + "_2" + ".png");
                    System.Windows.Forms.Clipboard.SetDataObject(oImage, true);

                    hoja3.Paste(oRange, oImage);

                    Microsoft.Office.Interop.Excel.Worksheet hoja4;
                    hoja4 = libros_trabajo.Worksheets[4];
                    hoja4 = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(4);
                    hoja4.Name = "GraficaLingotes";

                    oRange = (Microsoft.Office.Interop.Excel.Range)hoja4.Cells[5, 1];

                    chLingotes.SaveImage(ConfigurationManager.AppSettings["ChartPath"].ToString() + nomImagen + "_3" + ".png", ImageFormat.Png);

                    oImage = Image.FromFile(ConfigurationManager.AppSettings["ChartPath"].ToString() + nomImagen + "_3" + ".png");
                    System.Windows.Forms.Clipboard.SetDataObject(oImage, true);

                    hoja4.Paste(oRange, oImage);

                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }
    }
}
