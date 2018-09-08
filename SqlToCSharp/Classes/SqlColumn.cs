namespace SqlToCSharp.Classes
{
    using System.Data;
    public class SqlColumn
    {
        public string Name { get; set; }
        public SqlDbType SqlType { get; set; }
        public bool IsNullable { get; set; }
    }    
}
