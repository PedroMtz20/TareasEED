using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleaciones.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Alreaciones.DL
{
   public class ReporteCrudoDL
    {
        public eReporteCrudo GetReporteCrudo(int CategoryValue)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetReporteCrudo;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CategoryValue", (CategoryValue));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        eReporteCrudo Crudo = new eReporteCrudo
                        {
                            Bandera1 = Convert.ToDateTime(reader["Bandera1"]),
                            Bandera2 = Convert.ToDateTime(reader["Bandera2"]),
                            Bandera3 = Convert.ToDateTime(reader["Bandera3"]),
                            Sample_ca = Convert.ToDouble(reader["Sample"]),
                        };
                        reader.Read();
                        Crudo.Sample_es = Convert.ToDouble(reader["Sample"]);
                        Crudo.diff1 = TimeSpan.Parse(reader["diff1"].ToString());
                        Crudo.diff2 = TimeSpan.Parse(reader["diff2"].ToString());
                        Crudo.diff3 = TimeSpan.Parse(reader["diff3"].ToString());
                        return Crudo;
                    }
                    reader.Close();
                    return null;
                }
            }
        }
    }
}
