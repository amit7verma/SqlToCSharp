using SqlToCSharp.Enums;
using System;

namespace SqlToCSharp.Classes
{
    /// <summary>
    /// Event Argument class for ClassGeneratorSettings user-control's Settings Changed event.
    /// </summary>
    public class ClassGeneratorSettingsEventArgs : EventArgs
    {
        public string ClassName { get; set; }
        public string Namespace { get; set; }
        public AccessModifiers AccessModifier { get; set; }
        public MemberTypes MemberType { get; set; }
        public NamingConventions FieldNamingConvention { get; set; }
        public string FieldsPrefix { get; set; }
        public NamingConventions PropertiesNamingConvention { get; set; }
        public string PropertiesPrefix { get; set; }
        public string CustomLogicSetter { get; set; }
        public string CustomLogicGetter { get; set; }
    }
}
