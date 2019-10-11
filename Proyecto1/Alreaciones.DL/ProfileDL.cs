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
    public class ProfileDL
    {
        public eProfile GetById(int idProfile)
        {
            if (idProfile != 0)
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["BDAleaciones"].ConnectionString))
                {
                    cnx.Open();
                    const string sqlQuery = csQueries.sqlSelProfile;
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idProfile", idProfile);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {   
                            eProfile p = new eProfile
                            {
                                idUserProfile = Convert.ToInt32(reader["idUserProfile"]),
                                idProfile = Convert.ToInt32(reader["idProfile"]),
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

        public List<eProfile> GetAll()
        {
            List<eProfile> Profiles = new List<eProfile>();
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["BDAleaciones"].ConnectionString))
            {
                const string sqlQuery = csQueries.sqlSelProfile;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cnx.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProfile", 0);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        eProfile p = new eProfile
                        {
                            idUserProfile = Convert.ToInt32(reader["idUserProfile"]),
                            idProfile = Convert.ToInt32(reader["idProfile"]),
                            createdBy = Convert.ToInt32(reader["createdBy"]),
                            createdDate = Convert.ToDateTime(reader["createdDate"]),
                            modifiedBy = Convert.ToInt32(reader["modifiedBy"].ToString() == "" ? 0 : reader["modifiedBy"]),
                            modifiedDate = Convert.ToDateTime(reader["modifiedDate"].ToString() == "" ? new DateTime(1900, 01, 01) : reader["modifiedDate"])
                        };
                        Profiles.Add(p);
                    }
                }
            }
            return Profiles;
        }
    }
}
