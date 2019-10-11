using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleaciones.Entities;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Alreaciones.DL
{
    public class GoalDL
    {
        public void Insert(eGoal Goal)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlInsGoal;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Meta1", Goal.Meta1);
                    cmd.Parameters.AddWithValue("@Meta2", Goal.Meta2);
                    cmd.Parameters.AddWithValue("@Meta3", Goal.Meta3);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<eGoal> GetAll()
        {
            List<eGoal> Goals = new List<eGoal>();
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                const string sqlQuery = csQueries.sqlSelGoal;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cnx.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMeta", 0);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        eGoal p = new eGoal
                        {
                            IDMeta = Convert.ToInt32(reader["IDMeta"]),
                            Meta1 = Convert.ToDouble(reader["Meta1"]),
                            Meta2 = Convert.ToDouble(reader["Meta2"]),
                            Meta3 = Convert.ToDouble(reader["Meta3"])
                        };
                        Goals.Add(p);
                    }
                }
            }
            return Goals;
        }

        public eGoal GetById(int IDMeta)
        {
            if (IDMeta != 0)
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
                {
                    cnx.Open();
                    const string sqlQuery = csQueries.sqlSelGoal;
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDMeta", IDMeta);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            eGoal p = new eGoal
                            {
                                IDMeta = Convert.ToInt32(reader["IDMeta"]),
                                Meta1 = Convert.ToDouble(reader["Meta1"]),
                                Meta2 = Convert.ToDouble(reader["Meta2"]),
                                Meta3 = Convert.ToDouble(reader["Meta3"])
                            };
                            return p;
                        }
                    }
                }
            }
            return null;
        }

        public void Delete(int IDMeta)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlDelGoal;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMeta", IDMeta);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
