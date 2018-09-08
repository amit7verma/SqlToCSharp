using SqlToCSharp.Enums;
using SqlToCSharp.Extensions;
using System;
using System.Text;

namespace SqlToCSharp.Classes
{
    public class CSharpClassCreator : CSharpCreatorBase
    {
        public CSharpClassCreator(CSharpSettings setting) : base(setting)
        {

        }
        public CSharpClassCreator()
        {
        }


        public override void WriteClass(ref StringBuilder classBuilder, ClrProperty[] properties)
        {
            if (Settings == null) return;

            if (properties == null)
                return;
            if (string.IsNullOrEmpty(Settings.ClassName))
                return;

            classBuilder = new StringBuilder();
            AppendLine(classBuilder, "using System;");
            AppendLine(classBuilder);

            bool hasNamespace = !string.IsNullOrEmpty(Settings.Namespace);
            if (hasNamespace)
            {
                AppendLine(classBuilder, $"namespace {Settings.Namespace}");
                OpenCurlyBraces(classBuilder);
            }

            var modifier = Enum.GetName(typeof(Enums.AccessModifiers), Settings.AccessModifier).ToLower();
            if (modifier.Length > 0)
                modifier = modifier + " ";

            AppendLine(classBuilder, $"{modifier}class {Settings.ClassName}");

            //Class opens
            OpenCurlyBraces(classBuilder);


            bool firstProperty = true;
            foreach (var p in properties)
            {
                switch (Settings.MemberType)
                {
                    case MemberTypes.AutoProperties:
                        AppendLine(classBuilder, $"{AccessModifiers.Public.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, Settings.PropertiesNamingConvention, Settings.PropertiesPrefix)} {{ get; set; }}");
                        break;
                    case MemberTypes.FieldsOnly:
                        AppendLine(classBuilder, $"{AccessModifiers.Private.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, Settings.FieldNamingConvention, Settings.FieldsPrefix)} {{ get; set; }}");
                        break;
                    case MemberTypes.FieldEncapsulatedByproperties:
                        if (!firstProperty)
                        {
                            AppendLine(classBuilder);
                        }
                        var fldName = GetNamePerConvention(p.Name, Settings.FieldNamingConvention, Settings.FieldsPrefix);

                        AppendLine(classBuilder, $"{AccessModifiers.Private.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {fldName};");

                        if (Settings.CustomLogicGetter.Length > 0 && Settings.CustomLogicSetter.Length > 0)
                        {
                            AppendLine(classBuilder, $"{AccessModifiers.Public.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, Settings.PropertiesNamingConvention, Settings.PropertiesPrefix)} {{ get {{{Settings.CustomLogicGetter}; return {fldName};}} set {{{Settings.CustomLogicSetter}; {fldName} = value;}} }}");
                        }
                        else if (Settings.CustomLogicGetter.Length > 0)
                        {
                            AppendLine(classBuilder, $"{AccessModifiers.Public.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, Settings.PropertiesNamingConvention, Settings.PropertiesPrefix)} {{ get {{{Settings.CustomLogicGetter}; return {fldName};}} set => {fldName} = value; }}");
                        }
                        else if (Settings.CustomLogicSetter.Length > 0)
                        {
                            AppendLine(classBuilder, $"{AccessModifiers.Public.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, Settings.PropertiesNamingConvention, Settings.PropertiesPrefix)} {{ get => {fldName}; set {{{Settings.CustomLogicSetter}; {fldName} = value;}} }}");
                        }
                        else
                            AppendLine(classBuilder, $"{AccessModifiers.Public.ToString().ToLower()} {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, Settings.PropertiesNamingConvention, Settings.PropertiesPrefix)} {{ get => {fldName}; set => {fldName} = value; }}");

                        break;
                }
                firstProperty = false;
            }

            //Class closes
            CloseCurlyBraces(classBuilder);

            if (hasNamespace)
            {
                CloseCurlyBraces(classBuilder);
            }

        }
    }
}
