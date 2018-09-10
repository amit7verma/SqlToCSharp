namespace SqlToCSharp.Enums
{
    /// <summary>
    /// Enum of Database object types.
    /// </summary>
    public enum DBObjectType
    {
        None = -1,
        Table = 0,
        Views = 1,
        Functions = 2,
        StoredProcedure = 4,
        UserDefinedTableTypes = 8
    }

    public enum MemberTypes
    {
        AutoProperties,
        FieldEncapsulatedByproperties,
        FieldsOnly
    }

    public enum AccessModifiers
    {
        Public,
        Protected,
        Internal,
        Private
    }

    public enum NamingConventions
    {
        CamelCase,
        PascalCase,
        Custom
    }
}
