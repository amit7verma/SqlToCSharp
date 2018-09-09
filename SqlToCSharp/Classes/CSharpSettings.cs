using SqlToCSharp.Enums;

namespace SqlToCSharp.Classes
{
    /// <summary>
    /// Represnts settings items which is required to generate C# class and typed datatable.
    /// </summary>
    public class CSharpSettings
    {
        /// <summary>
        /// private default constructor. Instance will be created by static method GetCSharpSettings(...).
        /// </summary>
        private CSharpSettings() { }

        /// <summary>
        /// Class name.
        /// </summary>
        public string ClassName { get; private set; }

        /// <summary>
        /// Namespace
        /// </summary>
        public string Namespace { get; private set; }

        /// <summary>
        /// AccessModifier enumm type.
        /// </summary>
        public AccessModifiers AccessModifier { get; private set; }

        /// <summary>
        /// MemberTypes enumm type.
        /// </summary>
        public MemberTypes MemberType { get; private set; }

        /// <summary>
        /// NamingConvention for fields.
        /// </summary>
        public NamingConventions FieldNamingConvention { get; private set; }

        /// <summary>
        /// Prefix for field names.
        /// </summary>
        public string FieldsPrefix { get; private set; }

        /// <summary>
        /// NamingConvention for properties.
        /// </summary>
        public NamingConventions PropertiesNamingConvention { get; private set; }

        /// <summary>
        /// prefix for property names.
        /// </summary>
        public string PropertiesPrefix { get; private set; }

        /// <summary>
        /// Custom logic in string which will be prepended to actual setter.
        /// </summary>
        public string CustomLogicSetter { get; private set; }

        /// <summary>
        /// Custom logic in string which will be prepended to actual getter.
        /// </summary>
        public string CustomLogicGetter { get; private set; }

        /// <summary>
        /// static creator method which creates an instance of CSharpSettings type by reading from ClassGeneratorSettingsEventArgs instance.
        /// </summary>
        /// <param name="e">instance of ClassGeneratorSettingsEventArgs type.</param>
        /// <returns>Instance of CSharpSettings type.</returns>
        public static CSharpSettings GetCSharpSettings(ClassGeneratorSettingsEventArgs e)
        {
            return new CSharpSettings()
            {
                ClassName = e.ClassName,
                Namespace = e.Namespace,
                AccessModifier=e.AccessModifier,
                MemberType=e.MemberType,
                FieldNamingConvention=e.FieldNamingConvention,
                FieldsPrefix=e.FieldsPrefix,
                PropertiesNamingConvention=e.PropertiesNamingConvention,
                PropertiesPrefix=e.PropertiesPrefix,
                CustomLogicGetter=e.CustomLogicGetter,
                CustomLogicSetter=e.CustomLogicSetter
            };
        }
    }
}
