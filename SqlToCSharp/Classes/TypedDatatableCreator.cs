using SqlToCSharp.Extensions;
using System;

namespace SqlToCSharp.Classes
{
    /// <summary>
    /// Class to create typed datatables.
    /// </summary>
    public class TypedDatatableCreator : CSharpCreatorBase
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

            classBuilder.Clear();

            AppendLine("using System;");
            AppendLine("using System.Data;");
            AppendLine();

            bool hasNamespace = !string.IsNullOrEmpty(settings.Namespace);
            if (hasNamespace)
            {
                AppendLine($"namespace {settings.Namespace}");
                OpenCurlyBraces();
            }

            var modifier = Enum.GetName(typeof(Enums.AccessModifiers), settings.AccessModifier).ToLower();
            if (modifier.Length > 0)
                modifier = modifier + " ";

            AppendLine($"{modifier}class {settings.ClassName} : DataTable");

            //Class opens
            OpenCurlyBraces();

            AppendLine($"{modifier} {settings.ClassName}()");

            OpenCurlyBraces();
            this.AppendLine($"this.TableName = this.GetType().Name;");
            foreach (var p in properties)
            {
                this.AppendLine($"this.Columns.Add(\"{p.Name}\", typeof({p.PropertyType.GetDisplayName()}));");
            }
            CloseCurlyBraces();

            var rowClassName = $"{settings.ClassName}Row";

            this.AppendLine();

            this.AppendLine($"protected override Type GetRowType()");
            OpenCurlyBraces();

            this.AppendLine($"return typeof({rowClassName});");
            CloseCurlyBraces();

            this.AppendLine();

            this.AppendLine($"public {rowClassName} this[int rowIndex]");
            OpenCurlyBraces();

            this.AppendLine($"get {{ return ({rowClassName})Rows[rowIndex]; }}");
            CloseCurlyBraces();

            this.AppendLine();

            this.AppendLine($"public void AddRow({rowClassName} row)");
            OpenCurlyBraces();

            this.AppendLine($"Rows.Add(row);");
            CloseCurlyBraces();

            this.AppendLine();

            this.AppendLine($"public new {rowClassName} NewRow()");
            OpenCurlyBraces();

            this.AppendLine($"return ({rowClassName})base.NewRow();");
            CloseCurlyBraces();

            //table class closes here
            CloseCurlyBraces();

            this.AppendLine();

            //Writing Row Class starts here
            this.AppendLine($"{modifier} class {rowClassName} : DataRow");
            OpenCurlyBraces();


            //Adding Constructor
            this.AppendLine();
            this.AppendLine($"public {rowClassName}(DataRowBuilder rowBuilder) : base(rowBuilder) {{ }}");
            this.AppendLine();

            //Adding Property accessors
            foreach (var p in properties)
            {
                this.AppendLine($"public {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, settings.PropertiesNamingConvention, settings.PropertiesPrefix)} {{ get => ({p.PropertyType.GetDisplayName()})this[\"{p.Name}\"]; set => this[\"{p.Name}\"] = value;}}");
                this.AppendLine();
            }

            //Row Class closes here
            CloseCurlyBraces();

            if (hasNamespace)
            {
                CloseCurlyBraces();
            }

            return classBuilder.ToString();
        }
    }
}
