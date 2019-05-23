using ProjectCadmiumConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjectCadmiumConsole.Database.DBManagers
{
    public class TaskDBManager : DBManager
    {
        private static TaskDBManager dbInstance;

        public static TaskDBManager GetInstance()
        {
            return dbInstance ?? (dbInstance = new TaskDBManager());
        }

        // Helper
        private Task CreateInstance(SqlDataReader reader)
        {
            Task Task = new Task();
            Task.Id = (Guid)reader["Id"];
            Task.Name = reader["Name"].ToString();
            Task.Hours = (decimal)reader["Hours"];
            Task.QuoteID = (Guid)reader["QuoteID"];
            Task.Nth = (long)reader["Nth"];
            return Task;
        }

        // Get List
        public List<Task> GetTasks()
        {
            List<Task> TaskList = new List<Task>();
            try
            {
                sqlStr = "SELECT * FROM Tasks";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Task Task = CreateInstance(reader);
                        TaskList.Add(Task);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TaskList;
        }

        // Get by ID
        public Task GetTaskById(Guid Id)
        {
            Task Task = new Task();
            try
            {
                sqlStr = $"SELECT * FROM Tasks WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Task = CreateInstance(reader);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Task;
        }

        // Insert
        public Guid InsertTask(Guid Id, string Name, decimal Hours, Guid QuoteID)
        {
            try
            {
                sqlStr = $@"INSERT INTO Tasks(Id, Name, Hours, QuoteID) 
                             VALUES('{Id}', '{Name}', {Hours}, '{QuoteID}')";
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
        public void UpdateTask(Guid Id, string Name, decimal Hours, Guid QuoteID)
        {
            try
            {
                sqlStr = $@"UPDATE Tasks
                            SET Name = '{Name}',
                            Hours = {Hours},
                            QuoteID = '{QuoteID}'
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
        public void DeleteTaskById(Guid Id)
        {
            try
            {
                sqlStr = $@"DELETE Tasks WHERE Id = '{Id}'";
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
