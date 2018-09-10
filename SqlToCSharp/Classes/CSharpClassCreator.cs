using SqlToCSharp.Enums;
using SqlToCSharp.Extensions;
using System;
using System.Text;

namespace SqlToCSharp.Classes
{
    public class CSharpClassCreator : CSharpCreatorBase
    {
        /// <summary>
        /// Generates C# code as per specified settings and properties.
        /// </summary>
        /// <param name="settings">C# generator settings</param>
        /// <param name="properties">Array of ClrProperty type</param>
        /// <returns>C# code body in string.</returns>
        public override string GenerateCSharpCode(CSharpSettings settings, ClrProperty[] properties)
        {
            if (settings == null)
                return string.Empty;

            if (properties == null)
                return string.Empty;

            if (string.IsNullOrEmpty(settings.ClassName))
                return string.Empty;

            classBuilder = new StringBuilder();

            //Add usings 
            AppendLine("using System;");
            AppendLine();

            bool hasNamespace = !string.IsNullOrEmpty(settings.Namespace);

            //Add Namespace block if present.
            if (hasNamespace)
            {
                AppendLine( $"namespace {settings.Namespace}");
                OpenCurlyBraces();
            }

            var modifier = Enum.GetName(typeof(Enums.AccessModifiers), settings.AccessModifier).ToLower();
            if (modifier.Length > 0)
                modifier = modifier + " ";

            //Add class name
            AppendLine( $"{modifier}class {settings.ClassName}");

            //Class opens
            OpenCurlyBraces();


            bool firstProperty = true;
            foreach (var p in properties)
            {
                switch (settings.MemberType)
                {
                    case MemberTypes.AutoProperties:
                        AppendLine( $"{AccessModifiers.Public.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, settings.PropertiesNamingConvention, settings.PropertiesPrefix)} {{ get; set; }}");
                        break;
                    case MemberTypes.FieldsOnly:
                        AppendLine( $"{AccessModifiers.Private.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, settings.FieldNamingConvention, settings.FieldsPrefix)} {{ get; set; }}");
                        break;
                    case MemberTypes.FieldEncapsulatedByproperties:
                        if (!firstProperty)
                        {
                            AppendLine();
                        }
                        var fldName = GetNamePerConvention(p.Name, settings.FieldNamingConvention, settings.FieldsPrefix);

                        AppendLine( $"{AccessModifiers.Private.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {fldName};");

                        if (settings.CustomLogicGetter.Length > 0 && settings.CustomLogicSetter.Length > 0)
                        {
                            AppendLine( $"{AccessModifiers.Public.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, settings.PropertiesNamingConvention, settings.PropertiesPrefix)} {{ get {{{settings.CustomLogicGetter}; return {fldName};}} set {{{settings.CustomLogicSetter}; {fldName} = value;}} }}");
                        }
                        else if (settings.CustomLogicGetter.Length > 0)
                        {
                            AppendLine( $"{AccessModifiers.Public.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, settings.PropertiesNamingConvention, settings.PropertiesPrefix)} {{ get {{{settings.CustomLogicGetter}; return {fldName};}} set => {fldName} = value; }}");
                        }
                        else if (settings.CustomLogicSetter.Length > 0)
                        {
                            AppendLine( $"{AccessModifiers.Public.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, settings.PropertiesNamingConvention, settings.PropertiesPrefix)} {{ get => {fldName}; set {{{settings.CustomLogicSetter}; {fldName} = value;}} }}");
                        }
                        else
                            AppendLine( $"{AccessModifiers.Public.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, settings.PropertiesNamingConvention, settings.PropertiesPrefix)} {{ get => {fldName}; set => {fldName} = value; }}");

                        break;
                }
                firstProperty = false;
            }

            //Class closes
            CloseCurlyBraces();

            if (hasNamespace)
            {
                CloseCurlyBraces();
            }
            return base.classBuilder.ToString();
        }
    }
}
