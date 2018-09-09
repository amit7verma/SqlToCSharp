using SqlToCSharp.Extensions;
using System;
using System.Text;

namespace SqlToCSharp.Classes
{
    /// <summary>
    /// Class to create typed datatables.
    /// </summary>
    public class TypedDatatableCreator : CSharpCreatorBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TypedDatatableCreator() { }

        /// <summary>
        /// Parametrized constructor.
        /// </summary>
        /// <param name="Settings">settings object.</param>
        public TypedDatatableCreator(CSharpSettings Settings):base(Settings)
        {

        }


        public override void WriteClass(ref StringBuilder classBuilder, ClrProperty[] properties)
        {
            if (Settings == null) return;

            if (properties == null)
                return;
            if (string.IsNullOrEmpty(Settings.ClassName))
                return;

            AppendLine(classBuilder,"using System;");
            AppendLine(classBuilder,"using System.Data;");
            AppendLine(classBuilder);

            bool hasNamespace = !string.IsNullOrEmpty(Settings.Namespace);
            if (hasNamespace)
            {
                AppendLine(classBuilder,$"namespace {Settings.Namespace}");
                OpenCurlyBraces(classBuilder);
            }

            var modifier = Enum.GetName(typeof(Enums.AccessModifiers), Settings.AccessModifier).ToLower();
            if (modifier.Length > 0)
                modifier = modifier + " ";

            AppendLine(classBuilder,$"{modifier}class {Settings.ClassName} : DataTable");

            //Class opens
            OpenCurlyBraces(classBuilder);

            AppendLine(classBuilder,$"{modifier} {Settings.ClassName}()");

            OpenCurlyBraces(classBuilder);
            this.AppendLine(classBuilder,$"this.TableName = this.GetType().Name;");
            foreach (var p in properties)
            {
                this.AppendLine(classBuilder,$"this.Columns.Add(\"{p.Name}\", typeof({p.PropertyType.GetDisplayName()}));");
            }
            CloseCurlyBraces(classBuilder);

            var rowClassName = $"{Settings.ClassName}Row";

            this.AppendLine(classBuilder);

            this.AppendLine(classBuilder,$"protected override Type GetRowType()");
            OpenCurlyBraces(classBuilder);

            this.AppendLine(classBuilder,$"return typeof({rowClassName});");
            CloseCurlyBraces(classBuilder);

            this.AppendLine(classBuilder);

            this.AppendLine(classBuilder,$"public {rowClassName} this[int rowIndex]");
            OpenCurlyBraces(classBuilder);

            this.AppendLine(classBuilder,$"get {{ return ({rowClassName})Rows[rowIndex]; }}");
            CloseCurlyBraces(classBuilder);

            this.AppendLine(classBuilder);

            this.AppendLine(classBuilder,$"public void AddRow({rowClassName} row)");
            OpenCurlyBraces(classBuilder);

            this.AppendLine(classBuilder,$"Rows.Add(row);");
            CloseCurlyBraces(classBuilder);

            this.AppendLine(classBuilder);

            this.AppendLine(classBuilder,$"public new {rowClassName} NewRow()");
            OpenCurlyBraces(classBuilder);

            this.AppendLine(classBuilder,$"return ({rowClassName})base.NewRow();");
            CloseCurlyBraces(classBuilder);

            //table class closes here
            CloseCurlyBraces(classBuilder);

            this.AppendLine(classBuilder);

            //Writing Row Class starts here
            this.AppendLine(classBuilder,$"{modifier} class {rowClassName} : DataRow");
            OpenCurlyBraces(classBuilder);


            //Adding Constructor
            this.AppendLine(classBuilder);
            this.AppendLine(classBuilder,$"public {rowClassName}(DataRowBuilder rowBuilder) : base(rowBuilder) {{ }}");
            this.AppendLine(classBuilder);

            //Adding Property accessors
            foreach (var p in properties)
            {
                this.AppendLine(classBuilder,$"public {p.PropertyType.GetDisplayName()} {GetNamePerConvention(p.Name, Settings.PropertiesNamingConvention, Settings.PropertiesPrefix)} {{ get => ({p.PropertyType.GetDisplayName()})this[\"{p.Name}\"]; set => this[\"{p.Name}\"] = value;}}");
                this.AppendLine(classBuilder);
            }

            //Row Class closes here
            CloseCurlyBraces(classBuilder);

            if (hasNamespace)
                CloseCurlyBraces(classBuilder);
        }
    }
}
