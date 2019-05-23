using ProjectCadmiumConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.DBManagers
{
    public class PaymentDBManager : DBManager
    {
        private static PaymentDBManager dbInstance;

        public static PaymentDBManager GetInstance()
        {
            return dbInstance ?? (dbInstance = new PaymentDBManager());
        }

        // Helper
        private Payment CreateInstance(SqlDataReader reader)
        {
            Payment Payment = new Payment();
            Payment.Id = (Guid)reader["Id"];
            Payment.Amount = (decimal)reader["Amount"];
            Payment.PaymentDate = (DateTime)reader["PaymentDate"];
            Payment.QuoteID = (Guid)reader["QuoteID"];
            Payment.Nth = (long)reader["Nth"];
            return Payment;
        }

        // Get List
        public List<Payment> GetPayments()
        {
            List<Payment> PaymentList = new List<Payment>();
            try
            {
                sqlStr = "SELECT * FROM Payments";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Payment Payment = CreateInstance(reader);
                        PaymentList.Add(Payment);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PaymentList;
        }

        // Get by ID
        public Payment GetPaymentById(Guid Id)
        {
            Payment Payment = new Payment();
            try
            {
                sqlStr = $"SELECT * FROM Payments WHERE Id = '{Id}'";
                command = new SqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Payment = CreateInstance(reader);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Payment;
        }

        // Insert
        public Guid InsertPayment(Guid Id, decimal Amount, DateTime PaymentDate, Guid QuoteID)
        {
            try
            {
                sqlStr = $@"INSERT INTO Payments(Id, Amount, PaymentDate, QuoteID) 
                             VALUES('{Id}', {Amount}, '{PaymentDate}','{QuoteID}')";
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
        public void UpdatePayment(Guid Id, decimal Amount, DateTime PaymentDate, Guid QuoteID)
        {
            DateTime LastUsedTimestamp = DateTime.Now;
            try
            {
                sqlStr = $@"UPDATE Payments
                            SET Id = '{Id}',
                                Amount = {Amount},
                                PaymentDate = '{PaymentDate}',
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
        public void DeletePaymentById(Guid Id)
        {
            try
            {
                sqlStr = $@"DELETE Payments WHERE Id = '{Id}'";
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
