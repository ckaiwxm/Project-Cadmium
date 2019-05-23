using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.DBManagers
{
    public class DBManager
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["ProjectCadmiumEntities"].ConnectionString;
        protected readonly SqlConnection connection;

        protected SqlCommand command = null;
        protected SqlDataReader reader = null;
        protected string sqlStr = string.Empty;

        public DBManager()
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
    }
}
