namespace SqlToCSharp.Enums
{
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
