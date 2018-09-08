namespace SqlToCSharp
{
    public static class AppStatic
    {
        public static string DBConnectionString = string.Empty;
        public static string Database = string.Empty;
        public static string Server = string.Empty;
    }

    public static class Constants
    {
        public const string Tables = "Tables";
        public const string Views = "Views";
        public const string TableValuedFunctions = "Table Valued Functions";
        public const string UserDefinedTableTypes = "User-Defined Table Types";
        public const string StoredProcedures = "Stored Procedures";

        public const string Contains = "Contains";
        public new const string Equals = "Equals";
        public const string DoesNotContain = "Does not Contain";

        public const string FilteredText = " (filtered)";

    }
}
