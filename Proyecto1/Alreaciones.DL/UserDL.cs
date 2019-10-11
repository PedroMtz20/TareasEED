using Aleaciones.Entities;
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
    public class UserDL
    {
        public void Insert(eUser User)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlInsUser;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@namUser", User.namUser);
                    cmd.Parameters.AddWithValue("@userPass", User.userPass);
                    cmd.Parameters.AddWithValue("@idProfile", User.idProfile);
                    cmd.Parameters.AddWithValue("@createdBy", User.createdBy);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public eUser GetById(int idUser)
        {
            if (idUser != 0)
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
                {
                    cnx.Open();
                    const string sqlQuery = csQueries.sqlSelUser;
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idUser", idUser);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            eUser p = new eUser
                            {
                                idUser = Convert.ToInt32(reader["idUser"]),
                                namUser = reader["namUser"].ToString(),
                                userPass = reader["userPass"].ToString(),
                                idProfile = Convert.ToInt32(reader["idProfile"].ToString()),
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

        public List<eUser> GetAll()
        {
            List<eUser> Users = new List<eUser>();
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                const string sqlQuery = csQueries.sqlSelUser;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cnx.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUser", 0);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        eUser p = new eUser
                        {
                            idUser = Convert.ToInt32(reader["idUser"]),
                            namUser = reader["namUser"].ToString(),
                            userPass = reader["userPass"].ToString(),
                            idProfile = Convert.ToInt32(reader["idProfile"].ToString()),
                            createdBy = Convert.ToInt32(reader["createdBy"]),
                            createdDate = Convert.ToDateTime(reader["createdDate"]),
                            modifiedBy = Convert.ToInt32(reader["modifiedBy"].ToString() == "" ? 0 : reader["modifiedBy"]),
                            modifiedDate = Convert.ToDateTime(reader["modifiedDate"].ToString() == "" ? new DateTime(1900, 01, 01) : reader["modifiedDate"])
                        };
                        Users.Add(p);
                    }
                }
            }
            return Users;
        }

        public void Update(eUser User)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlUpdUser;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUser", User.idUser);
                    cmd.Parameters.AddWithValue("@namUser", User.namUser);
                    cmd.Parameters.AddWithValue("@userPass", User.userPass);
                    cmd.Parameters.AddWithValue("@idProfile", User.idProfile);
                    cmd.Parameters.AddWithValue("@User", User.modifiedBy);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idUser, int User)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlDelUser;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUser", idUser);
                    cmd.Parameters.AddWithValue("@User", User);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public eUser ValidateUser(string namUser, string userPass)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["AleacionesLocalDB"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = csQueries.sqlValUser;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@namUser", namUser);
                    cmd.Parameters.AddWithValue("@userPass", userPass);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        eUser p = new eUser
                        {
                            idUser = Convert.ToInt32(reader["idUser"]),
                            namUser = reader["namUser"].ToString(),
                            userPass = reader["userPass"].ToString(),
                            idProfile = Convert.ToInt32(reader["idProfile"].ToString()),
                            createdBy = Convert.ToInt32(reader["createdBy"]),
                            createdDate = Convert.ToDateTime(reader["createdDate"]),
                            modifiedBy = Convert.ToInt32(reader["modifiedBy"].ToString() == "" ? 0 : reader["modifiedBy"]),
                            modifiedDate = Convert.ToDateTime(reader["modifiedDate"].ToString() == "" ? new DateTime(1900, 01, 01) : reader["modifiedDate"])
                        };
                        return p;
                    }
                }
            }
            return null;
        }
    }
 }
