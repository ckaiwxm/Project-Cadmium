using ProjectCadmiumConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.DBManagers
{
    class QuoteDBManager : DBManager
    {
        private static QuoteDBManager dbInstance;

        public static QuoteDBManager GetInstance()
        {
            return dbInstance ?? (dbInstance = new QuoteDBManager());
        }

        // Helper
        private Quote CreateInstance(SqlDataReader reader)
        {
            Quote Quote = new Quote();
            Quote.Id = (Guid)reader["Id"];

            int PublishVersionIndex = reader.GetOrdinal("PublishVersion");
            if (reader.IsDBNull(PublishVersionIndex))
            {
                Quote.PublishVersion = null;
            } else
            {
                Quote.PublishVersion = (Guid)reader["PublishVersion"];
            }

            int NewPricePerHourIndex = reader.GetOrdinal("NewPricePerHour");
            if (reader.IsDBNull(NewPricePerHourIndex))
            {
                Quote.NewPricePerHour = null;
            }
            else
            {
                Quote.NewPricePerHour = (decimal)reader["NewPricePerHour"];
            }

            Quote.Nth = (long)reader["Nth"];
            return Quote;
        }

        // Get List
        public List<Quote> GetQuotes()
        {
            List<Quote> QuoteList = new List<Quote>();
            try
            {
                sqlStr = "SELECT * FROM Quotes";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Quote Quote = CreateInstance(reader);
                        QuoteList.Add(Quote);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return QuoteList;
        }

        // Get by ID
        public Quote GetQuoteById(Guid Id)
        {
            Quote Quote = new Quote();
            try
            {
                sqlStr = $"SELECT * FROM Quotes WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Quote = CreateInstance(reader);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Quote;
        }

        // Insert
        public Guid InsertQuote(Guid Id, Guid? PublishVersion, decimal? NewPricePerHour)
        {
            try
            {
                sqlStr = $@"INSERT INTO Quotes(Id, PublishVersion, NewPricePerHour) 
                             VALUES('{Id}', " + (PublishVersion == null ? "NULL" : ("'" + Convert.ToString(PublishVersion)) + "'") + "," 
                                               + (NewPricePerHour == null ? "NULL" : Convert.ToString(NewPricePerHour)) + ")";
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
        public void UpdateQuote(Guid Id, Guid? PublishVersion, decimal? NewPricePerHour)
        {
            try
            {
                sqlStr = $@"UPDATE Quotes
                            SET PublishVersion = " + (PublishVersion == null ? "NULL" : ("'" + Convert.ToString(PublishVersion)) + "'") + "," +
                            $"NewPricePerHour = " + (NewPricePerHour == null ? "NULL" : Convert.ToString(NewPricePerHour)) +
                            $"WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Delete by ID
        public void DeleteQuoteById(Guid Id)
        {
            try
            {
                sqlStr = $@"DELETE Quotes WHERE Id = '{Id}'";
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
