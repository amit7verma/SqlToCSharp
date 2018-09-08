using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SqlToCSharp.Classes;

namespace SqlToCSharp.Helpers
{
    public class SQLHelper
    {
        public enum DBObjectType
        {
            None = -1,
            Table = 0,
            Views = 1,
            Functions = 2,
            StoredProcedure = 4,
            UserDefinedTableTypes = 8
        }
        //private SqlConnection _sqlConn = null;
        private string _dbConnString;
        //protected virtual SqlConnection conn
        //{
        //    get { return _sqlConn; }
        //    set { _sqlConn = value; }
        //}

        public SQLHelper(string dbConnString)
        {
            _dbConnString = dbConnString;
        }
        public List<string[]> GetProcedures()
        {
            List<string[]> list = new List<string[]>();

            // Open connection to the database           
            using (SqlConnection con = new SqlConnection(this._dbConnString))
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

        public List<string[]> GetTables()
        {
            List<string[]> list = new List<string[]>();

            using (SqlConnection con = new SqlConnection(this._dbConnString))
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
        public List<string[]> GetTableTypes()
        {
            List<string[]> list = new List<string[]>();

            using (SqlConnection con = new SqlConnection(this._dbConnString))
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
        public List<string[]> GetViews()
        {
            List<string[]> list = new List<string[]>();

            using (SqlConnection con = new SqlConnection(this._dbConnString))
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
        public List<string[]> GetTableValuedFunctions()
        {
            List<string[]> list = new List<string[]>();

            using (SqlConnection con = new SqlConnection(this._dbConnString))
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
        public List<string> GetDatabaseList()
        {
            List<string> list = new List<string>();

            // Open connection to the database

            using (SqlConnection con = new SqlConnection(this._dbConnString))
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
        public bool IsEncrypted(string dbName, string spName)
        {
            string sql =
                @"SELECT 1 FROM sys.procedures WHERE OBJECTPROPERTY([object_id], 'IsEncrypted') = 1 and name=@name";
            // Open connection to the database
            bool returnVal = false;
            using (SqlConnection con = new SqlConnection(this._dbConnString))
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

        private SqlColumn[] GetSqlColumnsForStoredProcedure(string schema, string dbObjectName)
        {
            string sql = $"sp_describe_first_result_set N'{schema}.{dbObjectName}'";
            DataSet ds = new DataSet($"SP_HELP_{dbObjectName}");
            List<SqlColumn> sqlColumns = null;
            using (SqlConnection con = new SqlConnection(this._dbConnString))
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
                            SqlType = (SqlDbType)Enum.Parse(typeof(SqlDbType), dr[5].ToString().Split(new string[] { "(" }, StringSplitOptions.RemoveEmptyEntries)[0], true)
                        }
                        );
                }
            }

            return sqlColumns?.ToArray();
        }
        private SqlColumn[] GetSqlColumns(string schema, string dbObjectName)
        {
            string sql = $"sp_help '{schema}.{dbObjectName}'";
            DataSet ds = new DataSet($"SP_HELP_{dbObjectName}");
            List<SqlColumn> sqlColumns = null;
            using (SqlConnection con = new SqlConnection(this._dbConnString))
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
                            SqlType = (SqlDbType)Enum.Parse(typeof(SqlDbType), dr[1].ToString(), true)
                        }
                        );
                }
            }

            return sqlColumns?.ToArray();
        }

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
                        INNER JOIN sys.systypes AS ST  ON ST.xtype = c.system_type_id
                        where tt.name=@typeName
                        ";
            DataTable dataTable = new DataTable($"{schema}_{dbObjectName}");
            List<SqlColumn> sqlColumns = null;
            using (SqlConnection con = new SqlConnection(this._dbConnString))
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
                            SqlType = (SqlDbType)Enum.Parse(typeof(SqlDbType), dr[1].ToString(), true),
                            IsNullable = Convert.ToBoolean(dr[2])
                        }
                        );
                }
            }

            return sqlColumns?.ToArray();
        }

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
                    sqlColumns = GetSqlColumnsForStoredProcedure(schema, dbObjectName);
                    break;
                case DBObjectType.UserDefinedTableTypes:
                    sqlColumns = GetSqlColumnsForTableTypes(schema, dbObjectName);
                    break;
                default:
                    return null;
            }

            if (sqlColumns == null)
                return null;

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
                    throw new ArgumentOutOfRangeException("sqlType");
            }
        }
    }

}