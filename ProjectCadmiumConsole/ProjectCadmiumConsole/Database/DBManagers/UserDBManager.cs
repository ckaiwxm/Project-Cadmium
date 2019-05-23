using ProjectCadmiumConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.DBManagers
{
    public class UserDBManager : DBManager
    {
        private static UserDBManager dbInstance;

        public static UserDBManager GetInstance()
        {
            return dbInstance ?? (dbInstance = new UserDBManager());
        }

        // Helper
        private User CreateInstance(SqlDataReader reader)
        {
            User User = new User();
            User.Id = (Guid)reader["Id"];
            int PublishVersionIndex = reader.GetOrdinal("PublishVersion");
            if (reader.IsDBNull(PublishVersionIndex))
            {
                User.PublishVersion = null;
            }
            else
            {
                User.PublishVersion = (Guid)reader["PublishVersion"];
            }
            User.IsActive = (bool)reader["IsActive"];
            User.LastLoginTimestamp = (DateTime)reader["LastLoginTimestamp"];
            User.Nth = (long)reader["Nth"];
            return User;
        }

        // Get List
        public List<User> GetUsers()
        {
            List<User> UserList = new List<User>();
            try
            {
                sqlStr = "SELECT * FROM Users";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.HasRows && reader.Read())
                    {
                        User User = CreateInstance(reader);
                        UserList.Add(User);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserList;
        }

        // Get by ID
        public User GetUserById(Guid Id)
        {
            User User = new User();
            try
            {
                sqlStr = $"SELECT * FROM Users WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        User = CreateInstance(reader);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return User;
        }

        // Insert
        public Guid InsertUser(Guid Id, Guid? PublishVersion, bool IsActive, DateTime LastLoginTimestamp)
        {
            int ActiveNum = IsActive ? 1 : 0;
            try
            {
                sqlStr = $@"INSERT INTO Users(Id, PublishVersion, IsActive, LastLoginTimestamp) 
                             VALUES('{Id}'," + (PublishVersion == null ? "NULL" : ("'" + Convert.ToString(PublishVersion)) + "'") +
                             $@", {ActiveNum}, '{LastLoginTimestamp}')";
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
        public void UpdateUser(Guid Id, Guid? PublishVersion, bool IsActive, DateTime LastLoginTimestamp)
        {
            int ActiveNum = IsActive ? 1 : 0;
            try
            {
                sqlStr = $@"UPDATE Users
                            SET PublishVersion = " + (PublishVersion == null ? "NULL" : ("'" + Convert.ToString(PublishVersion)) + "'") +
                                $@",IsActive = {ActiveNum}, LastLoginTimestamp = '{LastLoginTimestamp}' WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Delete by ID
        public void DeleteUserById(Guid Id)
        {
            try
            {
                sqlStr = $@"DELETE Users WHERE Id = '{Id}'";
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
