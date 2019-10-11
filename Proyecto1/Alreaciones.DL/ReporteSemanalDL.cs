using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Alreaciones.DL
{
    public class ReporteSemanalDL
    {
        public List<TimeSpan> AvgTimes(int i, DateTime j, DateTime z)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetAllTime;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    List<TimeSpan> lista = new List<TimeSpan>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    TimeSpan span = TimeSpan.FromMinutes(-99);
                    DateTime Time2 = DateTime.MinValue;
                    DateTime Time = DateTime.MinValue;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CategoryValue", (i));
                    cmd.Parameters.AddWithValue("@TimeBajo", (j));
                    cmd.Parameters.AddWithValue("@TimeAlto", (z));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Time2 != DateTime.MinValue)
                        {
                            span = (Time - Time2);
                            
                        }
                        Time = Convert.ToDateTime(reader["SubgroupDateTime"]);
                        if (span != TimeSpan.FromMinutes(-99))
                        {
                            if (!reader.HasRows)
                            {
                                return lista;
                            }
                            lista.Add(span);
                        }

                        if (Time2 != DateTime.MinValue)
                        {
                            span = (Time2 - Time);
                        }


                        if (!reader.Read())
                        {
                            return lista;
                        }
                        else
                        {
                            Time2 = Convert.ToDateTime(reader["SubgroupDateTime"]);
                            if (span != TimeSpan.FromMinutes(-99))
                                lista.Add(span);
                        }
                    }   
                    reader.Close();
                    return lista;
                }
            }
        }

        public List<TimeSpan> AvgTimesEquipos(DateTime j, DateTime z, string TurnoBajo, string TurnoAlto)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetAllTimeEquipos;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    List<TimeSpan> lista = new List<TimeSpan>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    TimeSpan span = TimeSpan.FromMinutes(-99);
                    DateTime Time2 = DateTime.MinValue;
                    DateTime Time = DateTime.MinValue;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@TimeBajo", (j));
                    cmd.Parameters.AddWithValue("@TimeAlto", (z));
                    cmd.Parameters.AddWithValue("@TurnoBajo", (TurnoBajo));
                    cmd.Parameters.AddWithValue("@TurnoAlto", (TurnoAlto));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Time2 != DateTime.MinValue)
                        {
                            span = (Time - Time2);

                        }
                        Time = Convert.ToDateTime(reader["SubgroupDateTime"]);
                        if (span != TimeSpan.FromMinutes(-99))
                        {
                            if (!reader.HasRows)
                            {
                                return lista;
                            }
                            lista.Add(span);
                        }

                        if (Time2 != DateTime.MinValue)
                        {
                            span = (Time2 - Time);
                        }


                        if (!reader.Read())
                        {
                            return lista;
                        }
                        else
                        {
                            Time2 = Convert.ToDateTime(reader["SubgroupDateTime"]);
                            if (span != TimeSpan.FromMinutes(-99))
                                lista.Add(span);
                        }
                    }
                    reader.Close();
                    return lista;
                }
            }
        }

        public List<TimeSpan> AvgTimesLingotes(int i, DateTime j, DateTime z)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetAllTimeLingotes;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    List<TimeSpan> lista = new List<TimeSpan>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    TimeSpan span = TimeSpan.FromMinutes(-99);
                    DateTime Time2 = DateTime.MinValue;
                    DateTime Time = DateTime.MinValue;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CategoryValue", (i));
                    cmd.Parameters.AddWithValue("@TimeBajo", (j)    );
                    cmd.Parameters.AddWithValue("@TimeAlto", (z));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Time2 != DateTime.MinValue)
                        {
                            span = (Time - Time2);

                        }
                        Time = Convert.ToDateTime(reader["DateAndTime"]);
                        if (span != TimeSpan.FromMinutes(-99))
                        {
                            if (!reader.HasRows)
                            {
                                return lista;
                            }
                            lista.Add(span);
                        }

                        if (Time2 != DateTime.MinValue)
                        {
                            span = (Time2 - Time);
                        }


                        if (!reader.Read())
                        {
                            return lista;
                        }
                        else
                        {
                            Time2 = Convert.ToDateTime(reader["DateAndTime"]);
                            if (span != TimeSpan.FromMinutes(-99))
                                lista.Add(span);
                        }
                    }
                    reader.Close();
                    return lista;
                }
            }
        }

        public List<TimeSpan> AvgTimeLingotesEquipos(DateTime j, DateTime z, string TurnoBajo, string TurnoAlto)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetAllTimeLingotesEquipos;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    List<TimeSpan> lista = new List<TimeSpan>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    TimeSpan span = TimeSpan.FromMinutes(-99);
                    DateTime Time2 = DateTime.MinValue;
                    DateTime Time = DateTime.MinValue;
                    cmd.Parameters.Clear();     
                    cmd.Parameters.AddWithValue("@TimeBajo", (j));
                    cmd.Parameters.AddWithValue("@TimeAlto", (z));
                    cmd.Parameters.AddWithValue("@TurnoBajo", (TurnoBajo));
                    cmd.Parameters.AddWithValue("@TurnoAlto", (TurnoAlto));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Time2 != DateTime.MinValue)
                        {
                            span = (Time - Time2);

                        }
                        Time = Convert.ToDateTime(reader["DateAndTime"]);
                        if (span != TimeSpan.FromMinutes(-99))
                        {
                            if (!reader.HasRows)
                            {
                                return lista;
                            }
                            lista.Add(span);
                        }

                        if (Time2 != DateTime.MinValue)
                        {
                            span = (Time2 - Time);
                        }


                        if (!reader.Read())
                        {
                            return lista;
                        }
                        else
                        {
                            Time2 = Convert.ToDateTime(reader["DateAndTime"]);
                            if (span != TimeSpan.FromMinutes(-99))
                                lista.Add(span);
                        }
                    }
                    reader.Close();
                    return lista;
                }
            }
        }

        public List<DateTime> GetTurnos()
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlGetTurnos;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    List<DateTime> lista = new List<DateTime>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(Convert.ToDateTime(reader["HoraInicio"].ToString()));
                        lista.Add(Convert.ToDateTime(reader["HoraFinal"].ToString()));
                    }
                    reader.Close();
                    return lista;
                }
            }
        }

    }
}
