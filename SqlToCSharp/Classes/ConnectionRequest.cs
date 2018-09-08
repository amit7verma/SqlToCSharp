using System.Data.SqlClient;
using System;
namespace SqlToCSharp.Classes
{
    public class ConnectionRequest
    {
        public string ServerName;
        public bool WinAuth;
        public string Username = null;
        public string Password = null;

        public string DBName = null;
        public SqlConnection SqlConn { get; private set; }

        private const string FORMAT_WIN = "Server= {0}; Integrated Security = SSPI;";
        private const string FORMAT_SQL = "Data Source={0}; User ID = {1}; Password={2}";
        private const string FORMAT_DBName = "Initial Catalog = {0}";


        public ConnectionRequest(string server)
        {
            if (server == null || server.Length == 0)
                throw new ArgumentException("Server cannot be null or empty string", "server");
            this.SqlConn = null;
            ServerName = server;
            WinAuth = true;
        }
        public ConnectionRequest(string server, string dbName) : this(server)
        {
            DBName = dbName;
        }
        public ConnectionRequest(string server, string user, string pass) : this(server)
        {
            if (user == null || user.Length == 0)
                throw new ArgumentException("Username cannot be null or empty string", "user");

            if (pass == null || pass.Length == 0)
                throw new ArgumentException("Password cannot be null or empty string", "pass");

            WinAuth = false;
            Username = user;
            Password = pass;
        }
        public ConnectionRequest(string server, string user, string pass, string dbName) : this(server, user, pass)
        {
            DBName = dbName;
        }
        public bool TryConnect()
        {
            string connString = null;
            if (WinAuth)
                connString = string.Format(FORMAT_WIN, ServerName);
            else
                connString = string.Format(FORMAT_SQL, ServerName, Username, Password);

            if (!string.IsNullOrEmpty(DBName))
            {
                connString = $"{connString}; {string.Format(FORMAT_DBName, DBName)}";
            }

            if (connString == null || connString.Length == 0)
                throw new ArgumentException("Unable to create sql connection string.", "Connection String");

            SqlConnection sqlConn = null;
            try
            {
                sqlConn = new SqlConnection(connString);
                sqlConn.Open();
                this.SqlConn = sqlConn;
                return true;
            }
            catch (SqlException)
            {
                this.SqlConn = null;
            }
            catch (Exception)
            {
                this.SqlConn = null;
                throw;
            }
            finally
            {
                if (sqlConn != null && (sqlConn.State != System.Data.ConnectionState.Closed))
                {
                    sqlConn.Close();
                }
                if (this.SqlConn == null)
                {
                    sqlConn.Dispose();
                    sqlConn = null;
                }
            }
            return false;
        }
    }
}
