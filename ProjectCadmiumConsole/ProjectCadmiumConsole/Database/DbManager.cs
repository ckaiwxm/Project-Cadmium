using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjectCadmiumConsole.Database.Models;

namespace ProjectCadmiumConsole.Database
{
    public class DbManager
    {
        private readonly SqlConnection connection;
        private SqlCommand command = null;
        private SqlDataReader reader = null;

        private static DbManager dbInstance;
        //sample connection string: data source=TRACETHISPC\\SQLEXPRESS2016;initial catalog=dev_PharmaWorkflow;integrated security=True;
        //TODO: Modify {Server Name} and {Database Name}
        private string connectionString =
            "data source={Server Name};initial catalog={Database Name};integrated " +
            "security=True;";

        private string sqlStr = "";

        public DbManager()
        {
            connection = new SqlConnection(connectionString);
            Open();
        }

        private void Open()
        {
            connection.Open();
        }
        public void Close()
        {
            connection.Close();
        }

        public static DbManager getInstance()
        {
            return dbInstance ?? (dbInstance = new DbManager());
        }
        //Sample: Get List
        public List<Role> GetRoles()
        {

            List<Role> roles = new List<Role>();
            try
            {
                sqlStr = "SELECT * FROM Roles";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Role role = new Role();
                        role.Id = Convert.ToInt32(reader["Id"]);
                        role.Name = reader["Name"].ToString();
                        role.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        role.Description = reader["Description"].ToString();
                        role.Nth = (long)reader["Nth"];
                        roles.Add(role);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return roles;
        }

        //Sample: Get List
        public Role GetRoleByName(string name)
        {

            Role role = new Role();
            try
            {
                sqlStr = $"SELECT TOP 1 * FROM Roles WHERE Name = '{name}'";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        role.Id = Convert.ToInt32(reader["Id"]);
                        role.Name = reader["Name"].ToString();
                        role.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        role.Description = reader["Description"].ToString();
                        role.Nth = (long)reader["Nth"];
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return role;
        }

        //Sample: Insert/Update/Delete
        public int InsertRole(string roleName, string description, bool isActive)
        {
            int id = -1;
            try
            {
                sqlStr = $@"insert into roles(id, name, isActive, description) 
                                values({id}, '{roleName}', '{isActive}', '{description}')";
                command = new SqlCommand(sqlStr, connection);
                id = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return id;
        }

        public void UpdateRole(int id, string roleName, string description)
        {
            try
            {
                sqlStr = $@"UPDATE ROLES
                                SET Name = '{roleName}',
                                    Description = '{description}'
                            WHERE Id = {id}";
                command = new SqlCommand(sqlStr, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteRoleById(int id)
        {
            try
            {
                sqlStr = $@"DELETE ROLES WHERE Id = {id}";
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
