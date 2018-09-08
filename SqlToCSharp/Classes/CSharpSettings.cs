using SqlToCSharp.Enums;

namespace SqlToCSharp.Classes
{
    public class CSharpSettings
    {
        private CSharpSettings() { }
        public string ClassName { get; private set; }
        public string Namespace { get; private set; }
        public AccessModifiers AccessModifier { get; private set; }
        public MemberTypes MemberType { get; private set; }
        public NamingConventions FieldNamingConvention { get; private set; }
        public string FieldsPrefix { get; private set; }
        public NamingConventions PropertiesNamingConvention { get; private set; }
        public string PropertiesPrefix { get; private set; }
        public string CustomLogicSetter { get; private set; }
        public string CustomLogicGetter { get; private set; }

        public static CSharpSettings GetCSharpSettings(ClassSettingsEventArgs e)
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
