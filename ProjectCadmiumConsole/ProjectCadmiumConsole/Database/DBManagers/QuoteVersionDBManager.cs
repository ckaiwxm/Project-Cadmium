using ProjectCadmiumConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.DBManagers
{
    class QuoteVersionDBManager : DBManager
    {
        private static QuoteVersionDBManager dbInstance;

        public static QuoteVersionDBManager GetInstance()
        {
            return dbInstance ?? (dbInstance = new QuoteVersionDBManager());
        }

        // Helper
        private QuoteVersion CreateInstance(SqlDataReader reader)
        {
            QuoteVersion QuoteVersion = new QuoteVersion();
            QuoteVersion.Id = (Guid)reader["Id"];
            QuoteVersion.UniqueID = reader["UniqueID"].ToString();
            QuoteVersion.Version = (Guid)reader["Version"];
            QuoteVersion.IsBillable = (bool)reader["IsBillable"];
            QuoteVersion.Status = (States)reader["Status"];
            QuoteVersion.QuoteID = (Guid)reader["QuoteID"];
            QuoteVersion.ProjectID = (Guid)reader["ProjectID"];
            QuoteVersion.ClientID = (Guid)reader["ClientID"];
            QuoteVersion.CreationDate = (DateTime)reader["CreationDate"];
            QuoteVersion.CreatedById = (Guid)reader["CreatedById"];
            QuoteVersion.Nth = (long)reader["Nth"];
            return QuoteVersion;
        }

        // Get List
        public List<QuoteVersion> GetQuoteVersions()
        {
            List<QuoteVersion> QuoteVersionList = new List<QuoteVersion>();
            try
            {
                sqlStr = "SELECT * FROM QuoteVersions";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.HasRows && reader.Read())
                    {
                        QuoteVersion QuoteVersion = CreateInstance(reader);
                        QuoteVersionList.Add(QuoteVersion);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return QuoteVersionList;
        }

        // Get by ID
        public QuoteVersion GetQuoteVersionById(Guid Id)
        {
            QuoteVersion QuoteVersion = new QuoteVersion();
            try
            {
                sqlStr = $"SELECT * FROM QuoteVersions WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        QuoteVersion = CreateInstance(reader);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return QuoteVersion;
        }

        // Insert
        public Guid InsertQuoteVersion(Guid Id, string UniqueID, Guid Version, 
                                       bool IsBillable, Guid QuoteID, States Status, Guid ProjectID, Guid ClientID, Guid CreateById)
        {
            DateTime CreationDate = DateTime.Now;
            int BillableNum = IsBillable ? 1 : 0;
            int StatusNum = (int)Status;
            try
            {
                sqlStr = $@"INSERT INTO QuoteVersions(Id, UniqueID, Version, IsBillable, QuoteID, Status, ProjectID, ClientID, CreationDate, CreatedById) 
                            VALUES('{Id}', '{UniqueID}', '{Version}', {BillableNum}, '{QuoteID}', {StatusNum}, '{ProjectID}', '{ClientID}', '{CreationDate}', '{CreateById}')";
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
        public void UpdateQuoteVersion(Guid Id, string UniqueID, Guid Version, 
                                       bool IsBillable, Guid QuoteID, States Status, Guid ProjectID, Guid ClientID, DateTime CreationDate, Guid CreateById)
        {
            int BillableNum = IsBillable ? 1 : 0;
            int StatusNum = (int)Status;
            try
            {
                sqlStr = $@"UPDATE QuoteVersions
                            SET UniqueID = '{UniqueID}',
                            Version = '{Version}',
                            IsBillable = {BillableNum},
                            QuoteID = '{QuoteID}',
                            Status = {StatusNum},
                            ProjectID = '{ProjectID}',
                            ClientID = '{ClientID}',
                            CreationDate = '{CreationDate}',
                            CreatedById = '{CreateById}'
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
        public void DeleteQuoteVersionById(Guid Id)
        {
            try
            {
                sqlStr = $@"DELETE QuoteVersions WHERE Id = '{Id}'";
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
