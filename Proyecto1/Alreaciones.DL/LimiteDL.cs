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
    public class LimiteDL
    {
        public void Insert(eLimite Limite)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlInsLimit;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@numValue", Limite.numValue);
                    cmd.Parameters.AddWithValue("@createdBy", Limite.createdBy);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<eLimite> GetAll()
        {
            List<eLimite> Limites = new List<eLimite>();
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                const string sqlQuery = csQueries.sqlSelLimit;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cnx.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idLimit", 0);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        eLimite p = new eLimite
                        {
                            idLimit = Convert.ToInt32(reader["idLimit"]),
                            numValue = Convert.ToDouble(reader["numValue"]),
                            createdBy = Convert.ToInt32(reader["createdBy"]),
                            createdDate = Convert.ToDateTime(reader["createdDate"]),
                            modifiedBy = Convert.ToInt32(reader["modifiedBy"].ToString() == "" ? 0 : reader["modifiedBy"]),
                            modifiedDate = Convert.ToDateTime(reader["modifiedDate"].ToString() == "" ? new DateTime(1900, 01, 01) : reader["modifiedDate"])
                        };
                        Limites.Add(p);
                    }
                }
            }
            return Limites;
        }

        public eLimite GetById(int idLimite)
        {
            if (idLimite != 0)
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
                {
                    cnx.Open();
                    const string sqlQuery = csQueries.sqlSelLimit;
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idLimit", idLimite);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            eLimite p = new eLimite 
                            {
                                idLimit = Convert.ToInt32(reader["idLimit"]),
                                numValue = Convert.ToDouble(reader["numValue"]),
                                createdBy = Convert.ToInt32(reader["createdBy"]),
                                createdDate = Convert.ToDateTime(reader["createdDate"]),
                                modifiedBy = Convert.ToInt32(reader["modifiedBy"].ToString() == "" ? 0 : reader["modifiedBy"]),
                                modifiedDate = Convert.ToDateTime(reader["modifiedDate"].ToString() == "" ? new DateTime(1900, 01, 01) : reader["modifiedDate"])
                            };
                            return p;
                        }
                    }
                }
            }
            return null;
        }

        public void Delete(int idLimit)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlDelLimit;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idLimit", idLimit);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
