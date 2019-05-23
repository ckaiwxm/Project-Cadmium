using ProjectCadmiumConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.DBManagers
{
    class ClientDBManager : DBManager
    {
        private static ClientDBManager dbInstance;

        public static ClientDBManager GetInstance()
        {
            return dbInstance ?? (dbInstance = new ClientDBManager());
        }

        // Helper
        private Client CreateInstance(SqlDataReader reader)
        {
            Client Client = new Client();
            Client.Id = (Guid)reader["Id"];
            Client.Name = reader["Name"].ToString();
            Client.PricePerHour = (decimal)reader["PricePerHour"];
            Client.LastUsedTimestamp = (DateTime)reader["LastUsedTimestamp"];
            Client.Nth = (long)reader["Nth"];
            return Client;
        }

        // Get List
        public List<Client> GetClients()
        {
            List<Client> ClientList = new List<Client>();
            try
            {
                sqlStr = "SELECT * FROM Clients";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Client Client = CreateInstance(reader);
                        ClientList.Add(Client);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ClientList;
        }

        // Get by ID
        public Client GetClientById(Guid Id)
        {
            Client Client = new Client();
            try
            {
                sqlStr = $"SELECT * FROM Clients WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Client = CreateInstance(reader);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Client;
        }

        // Insert
        public Guid InsertClient(Guid Id, string Name, decimal PricePerHour)
        {
            DateTime LastUsedTimestamp = DateTime.Now;
            try
            {
                sqlStr = $@"INSERT INTO Clients(Id, Name, PricePerHour, LastUsedTimestamp) 
                             VALUES('{Id}', '{Name}', {PricePerHour}, '{LastUsedTimestamp}')";
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
        public void UpdateClient(Guid Id, string Name, decimal PricePerHour)
        {
            DateTime LastUsedTimestamp = DateTime.Now;
            try
            {
                sqlStr = $@"UPDATE Clients
                            SET Name = '{Name}',
                                LastUsedTimestamp = '{LastUsedTimestamp}',
                                PricePerHour = {PricePerHour}
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
        public void DeleteClientById(Guid Id)
        {
            try
            {
                sqlStr = $@"DELETE Clients WHERE Id = '{Id}'";
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
