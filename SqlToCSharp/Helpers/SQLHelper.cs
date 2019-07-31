using SqlToCSharp.Classes;
using SqlToCSharp.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlToCSharp.Helpers
{
    /// <summary>
    /// Helper class to help in Sql Server communication.
    /// </summary>
    public class SQLHelper
    {
        /// <summary>
        /// Connection string to database.
        /// </summary>
        private string _dbConnString;

        /// <summary>
        /// Parametrised Contructor.
        /// </summary>
        /// <param name="dbConnString">Connection string to database.</param>
        public SQLHelper(string dbConnString)
        {
            _dbConnString = dbConnString;
        }

        /// <summary>
        /// Get list of Stored procedures from Sql Server database.
        /// </summary>
        /// <returns>List of string array; index 0 keeps schema name and index 1 has procedure name.</returns>
        public List<string[]> GetProcedures()
        {
            List<string[]> list = new List<string[]>();

            // Open connection to the database           
            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string sql = @"SELECT
                        S.name[Schema]
                        ,P.name[Procedure]
                        FROM SYS.procedures P
                        INNER JOIN SYS.schemas S ON P.[Schema_id]=S.[Schema_id]
                        order by S.name, P.name";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader sqlReader = cmd.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            string[] data = new string[2] { string.Empty, string.Empty };
                            data[0] = sqlReader.GetString(0);
                            data[1] = sqlReader.GetString(1);
                            list.Add(data);
                        }
                    }
                }
                con.Close();
            }
            return list;

        }

        /// <summary>
        /// Get list of alll tables in the Sql Server database.
        /// </summary>
        /// <returns>List of string array; index 0 keeps schema names and index 1 has table names.</returns>
        public List<string[]> GetTables()
        {
            List<string[]> list = new List<string[]>();

            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string sql = @" select 
                                    s.name [Schema]
                                    ,t.name [Table]
                                from sys.schemas s
                                join sys.tables t 
                                    on t.schema_id=s.schema_id
                                order by s.name, t.name";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader sqlReader = cmd.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            string[] data = new string[2] { string.Empty, string.Empty };
                            data[0] = sqlReader.GetString(0);
                            data[1] = sqlReader.GetString(1);
                            list.Add(data);
                        }
                    }
                }
                con.Close();
            }
            return list;
        }

        /// <summary>
        /// Get list of all user-defined table types in the Sql Server database.
        /// </summary>
        /// <returns>List of string array; index 0 keeps schema names and index 1 has user-defined table type names.</returns>
        public List<string[]> GetTableTypes()
        {
            List<string[]> list = new List<string[]>();

            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string sql = @" select 
	                                s.name [Schema]
	                                ,tt.name AS TableType
                                from sys.table_types tt
                                inner join sys.schemas s 
                                        on tt.schema_id=s.schema_id
                                order by s.name, tt.name";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader sqlReader = cmd.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            string[] data = new string[2] { string.Empty, string.Empty };
                            data[0] = sqlReader.GetString(0);
                            data[1] = sqlReader.GetString(1);
                            list.Add(data);
                        }
                    }
                }
                con.Close();
            }
            return list;
        }

        /// <summary>
        /// Get list of all Views in the Sql Server database.
        /// </summary>
        /// <returns>List of string array; index 0 keeps schema names and index 1 has View names.</returns>
        public List<string[]> GetViews()
        {
            List<string[]> list = new List<string[]>();

            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string sql = @" 
                                select 
                                    s.name [Schema]
                                    ,v.name [View]
                                from sys.schemas s
                                join sys.views v 
                                    on v.schema_id=s.schema_id
                                order by s.name, v.name
                                ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader sqlReader = cmd.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            string[] data = new string[2] { string.Empty, string.Empty };
                            data[0] = sqlReader.GetString(0);
                            data[1] = sqlReader.GetString(1);
                            list.Add(data);
                        }
                    }
                }
                con.Close();
            }
            return list;
        }

        /// <summary>
        /// Get list of all User-defined Table valued functions in the Sql Server database.
        /// </summary>
        /// <returns>List of string array; index 0 keeps schema names and index 1 has User-defined Table valued function names.</returns>
        public List<string[]> GetTableValuedFunctions()
        {
            List<string[]> list = new List<string[]>();

            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string sql = @" 
                                SELECT 
                                    s.name [Schema]
                                    ,O.name [Function]
                                FROM 
                                sys.schemas s 
                                INNER JOIN sys.objects O 
                                    ON s.schema_id=O.schema_id
                                WHERE O.type IN ('IF','TF')
                                order by s.name, O.name
                                ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader sqlReader = cmd.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            string[] data = new string[2] { string.Empty, string.Empty };
                            data[0] = sqlReader.GetString(0);
                            data[1] = sqlReader.GetString(1);
                            list.Add(data);
                        }
                    }
                }
                con.Close();
            }
            return list;
        }

        /// <summary>
        /// Get List of databases as per current server connection.
        /// </summary>
        /// <returns>List of databases.</returns>
        public List<string> GetDatabaseList()
        {
            List<string> list = new List<string>();

            // Open connection to the database

            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases order by name", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Finds out whether specified Stored Procedure is encrypted or not in specified database.
        /// </summary>
        /// <param name="dbName">Database name.</param>
        /// <param name="spName">Stored Procedure name.</param>
        /// <returns>True if encrypted, else false.</returns>
        public bool IsEncrypted(string dbName, string spName)
        {
            string sql =
                @"SELECT 1 FROM sys.procedures WHERE OBJECTPROPERTY([object_id], 'IsEncrypted') = 1 and name=@name";
            // Open connection to the database
            bool returnVal = false;
            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.               
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    object val = cmd.ExecuteScalar();
                    returnVal = val != null && Convert.ToBoolean(val);
                }
                con.Close();
            }
            return returnVal;
        }

        /// <summary>
        /// Gets array of SqlColumn objects for specified schema and Stored procedure name.
        /// </summary>
        /// <param name="schema">Database schema name.</param>
        /// <param name="dbObjectName">Stored Procedure name.</param>
        /// <returns>Array of type SqlColumn.</returns>
        private SqlColumn[] GetSqlColumnsForStoredProcedure(string schema, string dbObjectName)
        {
            string sql = $"sp_describe_first_result_set N'{schema}.{dbObjectName}'";
            DataSet ds = new DataSet($"SP_HELP_{dbObjectName}");
            List<SqlColumn> sqlColumns = null;
            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                // Set up a command with the given query and associate
                // this with the current connection.               
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandText = sql;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dataTable = ds.Tables[0];
                sqlColumns = new List<SqlColumn>(dataTable.Rows.Count);
                foreach (DataRow dr in dataTable.Rows)
                {
                    sqlColumns.Add(
                        new SqlColumn()
                        {
                            Name = dr[2].ToString(),
                            IsNullable = Convert.ToBoolean(dr[3]),
                            SqlType = GetSqlDbType(dr[5].ToString().Split(new string[] { "(" }, StringSplitOptions.RemoveEmptyEntries)[0])
                        }
                        );
                }
            }

            return sqlColumns?.ToArray();
        }

        private ClrProperty[] GetClrPropertyForStoredProcedure(string schema, string dbObjectName)
        {
            DataSet ds = new DataSet(dbObjectName);
            List<ClrProperty> sqlColumns = null;
            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                // Set up a command with the given query and associate
                // this with the current connection.               
                using (SqlCommand cmd = new SqlCommand(dbObjectName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlCommandBuilder.DeriveParameters(cmd);
                    con.Close();
                    foreach (SqlParameter p in cmd.Parameters)
                    {
                        p.Value = DBNull.Value;
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
            {
                DataTable dataTable = ds.Tables[0];
                sqlColumns = new List<ClrProperty>(dataTable.Rows.Count);
                foreach (DataColumn dc in dataTable.Columns)
                {
                    sqlColumns.Add(
                        new ClrProperty()
                        {
                            Name = dc.ColumnName,
                            PropertyType = dc.DataType
                        }
                        );
                }
            }

            return sqlColumns?.ToArray();
        }

        /// <summary>
        /// Gets array of SqlColumn objects for specified schema and Database object name i.e. Table, Views and Table-Valued function
        /// </summary>
        /// <param name="schema">Database schema name.</param>
        /// <param name="dbObjectName">Name of Table, View or Table-Valued function</param>
        /// <returns>Array of type SqlColumn.</returns>
        private SqlColumn[] GetSqlColumns(string schema, string dbObjectName)
        {
            string sql = $"sp_help '{schema}.{dbObjectName}'";
            DataSet ds = new DataSet($"SP_HELP_{dbObjectName}");
            List<SqlColumn> sqlColumns = null;
            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                // Set up a command with the given query and associate
                // this with the current connection.               
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandText = sql;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
            }

            if (ds.Tables.Count > 2 && ds.Tables[1].Rows.Count > 0)
            {
                DataTable dataTable = ds.Tables[1];
                sqlColumns = new List<SqlColumn>(dataTable.Rows.Count);
                foreach (DataRow dr in dataTable.Rows)
                {
                    sqlColumns.Add(
                        new SqlColumn()
                        {
                            Name = dr[0].ToString(),
                            IsNullable = dr[6].ToString() == "yes" ? true : false,
                            SqlType = GetSqlDbType(dr[1].ToString())
                        }
                    );
                }
            }

            return sqlColumns?.ToArray();
        }

        /// <summary>
        /// Get SqlDbType enum for specified sql db type name.
        /// </summary>
        /// <param name="sqlTypeName">The name of sql data type.</param>
        /// <returns></returns>
        private SqlDbType GetSqlDbType(string sqlTypeName)
        {
            sqlTypeName = sqlTypeName.ToLower(System.Globalization.CultureInfo.InvariantCulture);

            if (Enum.TryParse(sqlTypeName, true, out SqlDbType sqlType))
            {
                return sqlType;
            }
            else
            {
                switch (sqlTypeName)
                {
                    case "sql_variant":
                        return SqlDbType.Variant;
                    case "numeric":
                        return SqlDbType.Decimal;
                    case "rowversion":
                        return SqlDbType.Timestamp;
                    case "smalldatetime":
                        return SqlDbType.DateTime;
                    case "sysname":
                        return SqlDbType.VarChar;

                    default:
                        throw new InvalidCastException($"Unable to cast '{sqlTypeName}' to appropriate SqlDbType enum.");
                }
            }
        }

        /// <summary>
        /// Gets array of SqlColumn objects for specified schema and User-defined table type name.
        /// </summary>
        /// <param name="schema">Database schema name.</param>
        /// <param name="dbObjectName">User-defined table type name.</param>
        /// <returns>Array of type SqlColumn.</returns>
        private SqlColumn[] GetSqlColumnsForTableTypes(string schema, string dbObjectName)
        {
            string sql = @"
                        select 
	                        distinct
	                        c.name AS ColumnName
	                        ,st.name AS SqlType
	                        ,c.is_nullable [Nullable]
                        from sys.table_types tt
                        inner join sys.columns c on c.object_id = tt.type_table_object_id
                        INNER JOIN sys.systypes AS ST  ON ST.xusertype = c.user_type_id
                        where tt.name=@typeName
                        ";
            DataTable dataTable = new DataTable($"{schema}_{dbObjectName}");
            List<SqlColumn> sqlColumns = null;
            using (SqlConnection con = new SqlConnection(_dbConnString))
            {
                // Set up a command with the given query and associate
                // this with the current connection.               
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@typeName", dbObjectName);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                }
            }
            if (dataTable.Rows.Count > 0)
            {
                sqlColumns = new List<SqlColumn>(dataTable.Rows.Count);
                foreach (DataRow dr in dataTable.Rows)
                {
                    sqlColumns.Add(
                        new SqlColumn()
                        {
                            Name = dr[0].ToString(),
                            SqlType = GetSqlDbType(dr[1].ToString()),
                            IsNullable = Convert.ToBoolean(dr[2])
                        }
                        );
                }
            }

            return sqlColumns?.ToArray();
        }

        /// <summary>
        /// Get array of ClrProperty from specified schema, database object and database object type.
        /// </summary>
        /// <param name="schema">Database schema.</param>
        /// <param name="dbObjectName">Database object name.</param>
        /// <param name="dbObjectType">Database object type name.</param>
        /// <returns>Array of ClrProperty.</returns>
        public ClrProperty[] GetClrProperties(string schema, string dbObjectName, DBObjectType dbObjectType)
        {
            SqlColumn[] sqlColumns = null;
            switch (dbObjectType)
            {
                case DBObjectType.Table:
                case DBObjectType.Views:
                case DBObjectType.Functions:
                    sqlColumns = GetSqlColumns(schema, dbObjectName);
                    break;
                case DBObjectType.StoredProcedure:
                    //sqlColumns = GetSqlColumnsForStoredProcedure(schema, dbObjectName); break;
                    return GetClrPropertyForStoredProcedure(schema, dbObjectName);
                case DBObjectType.UserDefinedTableTypes:
                    sqlColumns = GetSqlColumnsForTableTypes(schema, dbObjectName);
                    break;
                default:
                    return null;
            }

            if (sqlColumns == null)
            {
                return null;
            }

            List<ClrProperty> list = new List<ClrProperty>(sqlColumns.Length);
            foreach (var sqlCol in sqlColumns)
            {
                list.Add(new ClrProperty()
                {
                    Name = sqlCol.Name,
                    PropertyType = GetClrType(sqlCol.SqlType, sqlCol.IsNullable),
                });
            }
            return list.ToArray();
        }

        /// <summary>
        /// Get Clr Type from specified SqlType.
        /// </summary>
        /// <param name="sqlType">Object of type SqlDbType</param>
        /// <param name="isNullable">Is this Sql type nullable.</param>
        /// <returns></returns>
        public static Type GetClrType(SqlDbType sqlType, bool isNullable)
        {
            switch (sqlType)
            {
                case SqlDbType.BigInt:
                    return isNullable ? typeof(long?) : typeof(long);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                    return typeof(byte[]);

                case SqlDbType.Bit:
                    return isNullable ? typeof(bool?) : typeof(bool);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                case SqlDbType.Xml:
                    return typeof(string);

                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Date:
                case SqlDbType.Time:
                case SqlDbType.DateTime2:
                    return isNullable ? typeof(DateTime?) : typeof(DateTime);

                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return isNullable ? typeof(decimal?) : typeof(decimal);

                case SqlDbType.Float:
                    return isNullable ? typeof(double?) : typeof(double);

                case SqlDbType.Int:
                    return isNullable ? typeof(int?) : typeof(int);

                case SqlDbType.Real:
                    return isNullable ? typeof(float?) : typeof(float);

                case SqlDbType.UniqueIdentifier:
                    return typeof(Guid);

                case SqlDbType.SmallInt:
                    return isNullable ? typeof(short?) : typeof(short);

                case SqlDbType.TinyInt:
                    return isNullable ? typeof(byte?) : typeof(byte);

                case SqlDbType.Variant:
                case SqlDbType.Udt:
                    return typeof(object);

                case SqlDbType.Structured:
                    return typeof(DataTable);

                case SqlDbType.DateTimeOffset:
                    return isNullable ? typeof(DateTimeOffset?) : typeof(DateTimeOffset);

                default:
                    throw new ArgumentException("Invalid SqlType", sqlType.ToString());
            }
        }
    }
}