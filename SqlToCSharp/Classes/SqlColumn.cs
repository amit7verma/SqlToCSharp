namespace SqlToCSharp.Classes
{
    using System.Data;

    /// <summary>
    /// Represents properties of a column fetched from sql server.
    /// </summary>
    public class SqlColumn
    {
        /// <summary>
        /// Name of column.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Data type of column.
        /// </summary>
        public SqlDbType SqlType { get; set; }

        /// <summary>
        /// Is Column nullable?
        /// </summary>
        public bool IsNullable { get; set; }
    }    
}
