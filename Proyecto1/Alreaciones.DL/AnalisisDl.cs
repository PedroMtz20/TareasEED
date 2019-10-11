using Aleaciones.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Alreaciones.DL
{
    public class AnalisisDl
    {
        eAnalisis _max = new eAnalisis();

        public DateTime[,] GetAnalisisByLinea()
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                DateTime[,] ListAll = new DateTime[0, 0];
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetMaxLineas;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        _max.max = Convert.ToInt32(reader["max"]);
                        ListAll = new DateTime[_max.max, 2];
                    }

                    reader.Close();
                }

                const string sqlQuery2 = csQueries.sqlGetAnalisisFecha;
                using (SqlCommand cmd = new SqlCommand(sqlQuery2, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int j = 0; j < _max.max; j++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@CategoryValue", (j + 1));
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                if (ListAll[j, 0] == DateTime.MinValue)
                                    ListAll[j, 0] = Convert.ToDateTime(reader["subGroupDateTime"]);
                                else
                                {
                                    reader.Read();
                                    ListAll[j, 1] = Convert.ToDateTime(reader["subGroupDateTime"]);
                                }
                            }

                        }
                        reader.Close();
                    }

                }

                cnx.Close();
                return ListAll;

            }

        }

        public double[,] GetAnalisisByPorcenteaje()
        {
            double[,] ListAll = new double[_max.max, _max.max];
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetAnalisisPorcentaje;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int j = 0; j < _max.max; j++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@CategoryValue", (j+1));
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                if (ListAll[j, 0] == 0.0D)
                                    ListAll[j, 0] = Convert.ToDouble(reader["Sample"]);

                                else
                                {
                                    reader.Read();
                                    ListAll[j, 1] = Convert.ToDouble(reader["Sample"]);
                                    reader.Read();
                                    ListAll[j, 2] = Convert.ToDouble(reader["Sample"]);                                 }
                            }
                        }
                        reader.Close();
                    }
                }
                cnx.Close();
                return ListAll;
            }
        }

            
        public int getMax(int j)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetMaxLineas;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        _max.max = Convert.ToInt32(reader["max"]);
                        j = _max.max;
                    }
                    reader.Close();
                    return j;
                }   
            }
        }

        public string AnalisisLingotesRecomendadados(int i)
        {
             using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetAnalisisLingotesRecomendados;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    string Formula = null;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CategoryValue", (i));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Formula = reader["MathFormula"].ToString();
                    }
                    reader.Close();
                    return Formula;
                }
            }
        }

        public int CantidadLingotes(float calcio, float estano, string formula)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlLRecomendados;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Calcio", (calcio));
                    cmd.Parameters.AddWithValue("@Estano", (estano));
                    cmd.Parameters.AddWithValue("@MathFormula", (formula));
                    var returnParameter = cmd.Parameters.Add("@return_value", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int result = Convert.ToInt32(returnParameter.Value);
                    return result;
                }
            }
        }

        public int SumaLingotes(int i, DateTime Time)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqliaSumaLingotes;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    int Suma = 0;
                        cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CategoryValue", (i));
                    cmd.Parameters.AddWithValue("@Date", (Time.ToShortDateString()));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Suma = Convert.ToInt32(reader["Val"]);
                    }
                    reader.Close();
                    return Suma;
                }
            }
        }

        public TimeSpan AvgTimesLingotes(int i)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetDiffTimeLingotes;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    List<TimeSpan> lista = new List<TimeSpan>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    TimeSpan span = TimeSpan.FromMinutes(-99);
                    DateTime Time2 = DateTime.MinValue;
                    DateTime Time = DateTime.MinValue;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CategoryValue", (i));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            if (k == 0)
                                Time = Convert.ToDateTime(reader["DateAndTime"]);
                            else
                            {
                                reader.Read();
                                span = (Time - Convert.ToDateTime(reader["DateAndTime"]));
                            }
                        }
                    }
                    reader.Close();
                    return span;
                }
            }
        }

    }

    }
