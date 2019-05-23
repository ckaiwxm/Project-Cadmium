using ProjectCadmiumConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.DBManagers
{
    public class ProjectDBManager : DBManager
    {
        private static ProjectDBManager dbInstance;

        public static ProjectDBManager GetInstance()
        {
            return dbInstance ?? (dbInstance = new ProjectDBManager());
        }

        // Helper
        private Project CreateInstance(SqlDataReader reader)
        {
            Project project = new Project();
            project.Id = (Guid)reader["Id"];
            project.Name = reader["Name"].ToString();
            project.LastUsedTimestamp = (DateTime)reader["LastUsedTimestamp"];
            project.Nth = (long)reader["Nth"];
            return project;
        }

        // Get List
        public List<Project> GetProjects()
        {
            List<Project> projectList = new List<Project>();
            try
            {
                sqlStr = "SELECT * FROM Projects";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Project project = CreateInstance(reader);
                        projectList.Add(project);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return projectList;
        }

        // Get by ID
        public Project GetProjectById(Guid Id)
        {
            Project project = new Project();
            try
            {
                sqlStr = $"SELECT * FROM Projects WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        project = CreateInstance(reader);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return project;
        }

        // Insert
        public Guid InsertProject(Guid Id, string Name)
        {
            DateTime LastUsedTimestamp = DateTime.Now;
            try
            {
                sqlStr = $@"INSERT INTO Projects(Id, Name, LastUsedTimestamp) 
                             VALUES('{Id}', '{Name}', '{LastUsedTimestamp}')";
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
        public void UpdateProject(Guid Id, string Name)
        {
            DateTime LastUsedTimestamp = DateTime.Now;
            try
            {
                sqlStr = $@"UPDATE Projects
                            SET Name = '{Name}',
                                LastUsedTimestamp = '{LastUsedTimestamp}'
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
        public void DeleteProjectById(Guid Id)
        {
            try
            {
                sqlStr = $@"DELETE Projects WHERE Id = '{Id}'";
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
