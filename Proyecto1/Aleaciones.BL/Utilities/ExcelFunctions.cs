using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;


namespace Aleaciones.BL.Utilities
{
    public class ExcelFunctions
    {
        protected string ExcelConnectionString(string ext)
        {
            string connectionString = "";
            if (ext == ".xls")
            {   //For Excel 97-03
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties = 'Excel 8.0;HDR={1}'";
            }
            else if (ext == ".xlsx")
            {    //For Excel 07 and greater
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties = 'Excel 8.0;HDR={1}'";
            }
            return connectionString;

        }

        public DataTable FillTableFromExcelSheet(string FilePath, string ext, string isHader)
        {
            string connectionString = "";
            connectionString = String.Format(ExcelConnectionString(ext), FilePath, isHader);
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmd.Connection = conn;
            //Fetch 1st Sheet Name
            conn.Open();
            DataTable dtSchema;
            dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string ExcelSheetName = dtSchema.Rows[2]["TABLE_NAME"].ToString();
            conn.Close();
            //Read all data of fetched Sheet to a Data Table
            conn.Open();
            cmd.CommandText = "SELECT * From [" + ExcelSheetName + "]";
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dt);
            conn.Close();
            //Bind Sheet Data to GridView
            //ExcelGridView.Caption = Path.GetFileName(FilePath);
            //ExcelGridView.DataSource = dt;
            //ExcelGridView.DataBind();
            return dt;
        }

        public DataTable getExcelFile(string pathFile)
        {

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(pathFile);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;


            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            //int rowCount = 4;
            //int colCount = 4;

            DataTable data = new DataTable();

            for (int c = 1; c <= colCount; c++)
            {
                DataColumn col = new DataColumn();
                col.ColumnName = "A" + c.ToString();
                data.Columns.Add(col);
            }

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 2; i <= rowCount; i++)
            {
                DataRow row = null;
                row = data.NewRow();
                for (int j = 1; j <= colCount; j++)
                {
                    //write the value to the console
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        if(j == 1)
                        {
                            row["A" + j] = (xlRange.Cells[i, j].Value2.ToString());
                        }else
                        row["A" + j] = (xlRange.Cells[i, j].Value2.ToString());//+ " / " + ((Excel.Range)xlRange.Cells[i, j]).Interior.ColorIndex);
                    }
                    else
                        row["A" + j] = "0 / 0";
                }

                if (row["A1"].ToString() != "0 / 0")
                {
                    if (row["A2"].ToString() != "0 / 0")
                    {
                        if (row["A3"].ToString() != "0 / 0")
                        {
                            data.Rows.Add(row);
                        }
                        else
                        {
                            MessageBox.Show("Valores en Campo Pb Obligatorios", "Validación de Captura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valores en Campo Modelo Obligatorios", "Validación de Captura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show("Valores en Campo Producto Obligatorios", "Validación de Captura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }

            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            return data;
        }
    }
}
