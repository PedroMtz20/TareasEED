using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Aleaciones.BL;
using Aleaciones.Entities;
using System.Configuration;

namespace Aleaciones.App
{
    public partial class frmReporteCrudo : Form
    {
        ReporteCrudoBL _ReporteCrudoBL = new ReporteCrudoBL();
        private GoalBL _Goal = new GoalBL();
        Microsoft.Office.Interop.Excel.Application aplicacion;
        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
        string x;
        int y;

        public frmReporteCrudo()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void GetReporteCrudo()
        {

            //  List<eLimite> _LimiteModel = _Limite.GetAll();

            // var groupValues = (from p in _LimiteModel
            //                    group p by p.idLimit into grupo
            //                    select new eLimite
            //                    {
            //                        numValue = grupo.Sum(x => x.numValue)
            //                    }
            //                    ).ToList();


            eReporteCrudo result = new eReporteCrudo();
            DataTable dt = new DataTable();
            dt.Columns.Add("Linea");
            dt.Columns.Add("fechahora b1");
            dt.Columns.Add("fechahora b2");
            dt.Columns.Add("fechahora b3");
            dt.Columns.Add("valor ca");
            dt.Columns.Add("valor estaño");
            dt.Columns.Add("diff1");
            dt.Columns.Add("diff2");
            dt.Columns.Add("diff3");
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    result = _ReporteCrudoBL.GetReporteCrudo((i+1));
                    dt.Rows.Add((i + 1), result.Bandera1, result.Bandera2, result.Bandera3, result.Sample_ca, result.Sample_es, result.diff1, result.diff2, result.diff3);
                    FillChartsdiff1(result, chdiff1, chdiff2, chdiff3);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("No se encontraron datos para los banderazos");
            }
            dgBanderazo.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnExport.Visible = true;
            chdiff1.Series.Clear();
            chdiff2.Series.Clear();
            chdiff3.Series.Clear();
            GetReporteCrudo();
            dgBanderazo.Show();

        }

        private void FillChartsdiff1(eReporteCrudo result, Chart chart, Chart chart2, Chart chart3)
        {
            try
            {
                List<eGoal> _GoalModel = _Goal.GetAll();

                var groupValues = (from p in _GoalModel
                                   group p by p.IDMeta into grupo
                                   select new eGoal
                                   {
                                       Meta1 = grupo.Sum(x => x.Meta1),
                                       Meta2 = grupo.Sum(x => x.Meta2),
                                       Meta3 = grupo.Sum(x => x.Meta3)
                                   }
                                     ).ToList();

                int series = chart.Series.Count;
                    if (chart.Series.Count == 0)
                    {
                        chart.Titles.Add(new Title("Meta 1"));
                        chart.Series.Add(new Series("Series2"));
                        chart.Series.Add(new Series("Series3"));
                        chart.Series["Series2"].ChartType = SeriesChartType.StackedColumn;
                        chart.Series["Series2"].IsValueShownAsLabel = true;
                        chart.Series["Series3"].ChartType = SeriesChartType.StackedColumn;
                        chart.Series["Series3"].IsValueShownAsLabel = true;
                        chart.Series["Series2"]["PixelPointWidth"] = "25";
                        chart.Series["Series3"]["PixelPointWidth"] = "25";
                    }
                    else
                    {
                        series = chart.Series["Series2"].Points.Count;
                    }
                    if (result.diff1 >= TimeSpan.FromMinutes(groupValues[0].Meta1))
                    {
                    x = ((series + 1)).ToString();
                    y = (int)TimeSpan.FromMinutes(groupValues[0].Meta1).TotalMinutes;
                    chart.Series["Series2"].Points.AddXY(x, y);
                    chart.Series["Series3"].Points.AddXY(x, (int) result.diff1.Subtract(TimeSpan.FromMinutes(groupValues[0].Meta1)).TotalMinutes);
                        chart.Series["Series3"].Color = Color.Red;
                        chart.DataManipulator.InsertEmptyPoints(1, IntervalType.Number, "Series2, Series3 ");
                }
                else
                {
                    x = ((series + 1)).ToString();
                    y = (int)result.diff1.TotalMinutes;
                    chart.Series["Series2"].Points.AddXY(x, y);
                    chart.Series["Series3"].Points.AddXY(x,0);
                    
                }
                foreach (Series s in chart.Series)
                {
                    foreach (DataPoint dp in s.Points) {
                        if (dp.YValues[0] == 0) {
                            dp.IsValueShownAsLabel = false;
                        }
                    }
                    }

                series = chart2.Series.Count;
                if (chart2.Series.Count == 0)
                {
                    chart2.Titles.Add(new Title("Meta 2"));
                    chart2.Series.Add(new Series("Series2"));
                    chart2.Series.Add(new Series("Series3"));
                    chart2.Series["Series2"].ChartType = SeriesChartType.StackedColumn;
                    chart2.Series["Series2"].IsValueShownAsLabel = true;
                    chart2.Series["Series3"].ChartType = SeriesChartType.StackedColumn;
                    chart2.Series["Series3"].IsValueShownAsLabel = true;
                    chart2.Series["Series2"]["PixelPointWidth"] = "25";
                    chart2.Series["Series3"]["PixelPointWidth"] = "25";
                }
                else
                {
                    series = chart2.Series["Series2"].Points.Count;
                }
                if (result.diff2 >= TimeSpan.FromMinutes(groupValues[0].Meta2))
                {
                    x = ((series + 1)).ToString();
                    y = (int)TimeSpan.FromMinutes(groupValues[0].Meta2).TotalMinutes;
                    chart2.Series["Series2"].Points.AddXY(x, y);
                    chart2.Series["Series3"].Points.AddXY(x, (int)result.diff2.Subtract(TimeSpan.FromMinutes(groupValues[0].Meta2)).TotalMinutes);
                    chart2.Series["Series3"].Color = Color.Red;
                    chart2.DataManipulator.InsertEmptyPoints(1, IntervalType.Number, "Series2, Series3 ");
                }
                else
                {
                    x = ((series + 1)).ToString();
                    y = (int)result.diff2.TotalMinutes;
                    chart2.Series["Series2"].Points.AddXY(x, y);
                    chart2.Series["Series3"].Points.AddXY(x, 0);

                }
                foreach (Series s in chart2.Series)
                {
                    foreach (DataPoint dp in s.Points)
                    {
                        if (dp.YValues[0] == 0)
                        {
                            dp.IsValueShownAsLabel = false;
                        }
                    }
                }

                series = chart3.Series.Count;
                if (chart3.Series.Count == 0)
                {
                    chart3.Titles.Add(new Title("Meta 3"));
                    chart3.Series.Add(new Series("Series2"));
                    chart3.Series.Add(new Series("Series3"));
                    chart3.Series["Series2"].ChartType = SeriesChartType.StackedColumn;
                    chart3.Series["Series2"].IsValueShownAsLabel = true;
                    chart3.Series["Series3"].ChartType = SeriesChartType.StackedColumn;
                    chart3.Series["Series3"].IsValueShownAsLabel = true;
                    chart3.Series["Series2"]["PixelPointWidth"] = "25";
                    chart3.Series["Series3"]["PixelPointWidth"] = "25";
                }
                else
                {
                    series = chart3.Series["Series2"].Points.Count;
                }
                if (result.diff3 >= TimeSpan.FromMinutes(groupValues[0].Meta3))
                {
                    x = ((series + 1)).ToString();
                    y = (int)TimeSpan.FromMinutes(groupValues[0].Meta3).TotalMinutes;
                    chart3.Series["Series2"].Points.AddXY(x, y);
                    chart3.Series["Series3"].Points.AddXY(x, (int)result.diff3.Subtract(TimeSpan.FromMinutes(groupValues[0].Meta3)).TotalMinutes);
                    chart3.Series["Series3"].Color = Color.Red;
                    chart3.DataManipulator.InsertEmptyPoints(1, IntervalType.Number, "Series2, Series3 ");
                }
                else
                {
                    x = ((series + 1)).ToString();
                    y = (int)result.diff3.TotalMinutes;
                    chart3.Series["Series2"].Points.AddXY(x, y);
                    chart3.Series["Series3"].Points.AddXY(x, 0);

                }

                foreach (Series s in chart3.Series)
                {
                    foreach (DataPoint dp in s.Points)
                    {
                        if (dp.YValues[0] == 0)
                        {
                            dp.IsValueShownAsLabel = false;
                        }
                    }
                }


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
            frmAnalisis _frmAnalisis = new frmAnalisis();
            this.Hide();
            _frmAnalisis.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Reporte Semanal")
            {
                frmReporteSemanal _frmReporteSemanal = new frmReporteSemanal();
                this.Hide();
                _frmReporteSemanal.ShowDialog();
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
                    hoja1.Name = "Banderazos";

                    for (int x = 1; x < dgBanderazo.Columns.Count + 1; x++)
                    {
                        hoja1.Cells[1, x] = dgBanderazo.Columns[x - 1].HeaderText;
                    }

                    for (int x = 0; x < dgBanderazo.Rows.Count; x++)
                    {
                        for (int j = 0; j < dgBanderazo.Columns.Count; j++)
                        {
                            if (dgBanderazo.Rows[x].Cells[j].Value != null)
                            {
                                hoja1.Cells[x + 2, j + 1] = dgBanderazo.Rows[x].Cells[j].Value.ToString();
                            }
                        }
                        hoja1.Columns[x+1].ColumnWidth = 18;
                    }

                    Microsoft.Office.Interop.Excel.Worksheet hoja2;
                    hoja2 = libros_trabajo.Worksheets[2];
                    hoja2 = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(2);
                    hoja2.Name = "Diferencia 1-2";

                    Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)hoja2.Cells[5, 1];

                    chdiff1.SaveImage(ConfigurationManager.AppSettings["ChartPath"].ToString() + nomImagen + "_1" + ".png", ImageFormat.Png);

                    Image oImage = Image.FromFile(ConfigurationManager.AppSettings["ChartPath"].ToString() + nomImagen + "_1" + ".png");
                    System.Windows.Forms.Clipboard.SetDataObject(oImage, true); 

                    hoja2.Paste(oRange, oImage);

                    Microsoft.Office.Interop.Excel.Worksheet hoja3;
                    hoja3 = libros_trabajo.Worksheets[3];
                    hoja3 = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(3);
                    hoja3.Name = "Diferencia 2-3";

                    oRange = (Microsoft.Office.Interop.Excel.Range)hoja3.Cells[5, 1];

                    chdiff2.SaveImage(ConfigurationManager.AppSettings["ChartPath"].ToString() + nomImagen + "_2" + ".png", ImageFormat.Png);

                    oImage = Image.FromFile(ConfigurationManager.AppSettings["ChartPath"].ToString() + nomImagen + "_2" + ".png");
                    System.Windows.Forms.Clipboard.SetDataObject(oImage, true);

                    hoja3.Paste(oRange, oImage);

                    Microsoft.Office.Interop.Excel.Worksheet hoja4;
                    hoja4 = libros_trabajo.Worksheets[4];
                    hoja4 = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(4);
                    hoja4.Name = "Diferencia 3-1";

                    oRange = (Microsoft.Office.Interop.Excel.Range)hoja4.Cells[5, 1];

                    chdiff3.SaveImage(ConfigurationManager.AppSettings["ChartPath"].ToString() + nomImagen + "_3" + ".png", ImageFormat.Png);

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
