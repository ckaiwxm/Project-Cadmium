using ProjectCadmiumConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.DBManagers
{
    class UserVersionDBManager : DBManager
    {
        private static UserVersionDBManager dbInstance;

        public static UserVersionDBManager GetInstance()
        {
            return dbInstance ?? (dbInstance = new UserVersionDBManager());
        }

        // Helper
        private UserVersion CreateInstance(SqlDataReader reader)
        {
            UserVersion UserVersion = new UserVersion();
            UserVersion.Id = (Guid)reader["Id"];
            UserVersion.Version = (Guid)reader["Version"];
            UserVersion.UserName = reader["UserName"].ToString();
            UserVersion.Password = reader["Password"].ToString();
            UserVersion.FirstName = reader["FirstName"].ToString();
            UserVersion.LastName = reader["LastName"].ToString();
            UserVersion.Phone = reader["Phone"].ToString();
            UserVersion.Email = reader["Email"].ToString();
            UserVersion.CreationDate = (DateTime)reader["CreationDate"];
            UserVersion.UserID = (Guid)reader["UserID"];
            UserVersion.Nth = (long)reader["Nth"];
            return UserVersion;
        }

        // Get List
        public List<UserVersion> GetUserVersions()
        {
            List<UserVersion> UserVersionList = new List<UserVersion>();
            try
            {
                sqlStr = "SELECT * FROM UserVersions";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.HasRows && reader.Read())
                    {
                        UserVersion UserVersion = CreateInstance(reader);
                        UserVersionList.Add(UserVersion);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserVersionList;
        }

        // Get by ID
        public UserVersion GetUserVersionById(Guid Id)
        {
            UserVersion UserVersion = new UserVersion();
            try
            {
                sqlStr = $"SELECT * FROM UserVersions WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        UserVersion = CreateInstance(reader);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserVersion;
        }

        // Insert
        public Guid InsertUserVersion(Guid Id, Guid Version, string UserName, string Password, string FirstName, String LastName,
                                      string Phone, String Email, Guid UserID)
        {
            DateTime CreationDate = DateTime.Now;
            string PhoneStr = string.IsNullOrEmpty(Phone) ? "NULL" : Phone;
            string EmailStr = string.IsNullOrEmpty(Email) ? "NULL" : Email;
            try
            {
                sqlStr = $@"INSERT INTO UserVersions(Id, Version, UserName, Password, FirstName, LastName, Phone, Email, CreationDate, UserID) 
                            VALUES('{Id}', '{Version}', '{UserName}', '{Password}', '{FirstName}', '{LastName}', '{Phone}', '{Email}', '{CreationDate}', '{UserID}')";
                command = new SqlCommand(sqlStr, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        // Update by ID
        public void UpdateUserVersion(Guid Id, Guid Version, string UserName, string Password, string FirstName, String LastName,
                                       string Phone, String Email, DateTime CreationDate, Guid UserID)
        {
            string PhoneStr = string.IsNullOrEmpty(Phone) ? "NULL" : Phone;
            string EmailStr = string.IsNullOrEmpty(Email) ? "NULL" : Email;
            try
            {
                sqlStr = $@"UPDATE UserVersions
                            SET Version = '{Version}',
                            UserName = '{UserName}',
                            Password = '{Password}',
                            FirstName = '{FirstName}',
                            LastName = '{LastName}',
                            Phone = '{Phone}',
                            Email = '{Email}',
                            CreationDate = '{CreationDate}',
                            userID = '{UserID}'
                            WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Delete by ID
        public void DeleteUserVersionById(Guid Id)
        {
            try
            {
                sqlStr = $@"DELETE UserVersions WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
