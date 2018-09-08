using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlToCSharp.Enums;

namespace SqlToCSharp.Classes
{
    public abstract class CSharpCreatorBase
    {
        protected int tabCount;

        public CSharpSettings Settings { get; set; }

        public CSharpCreatorBase(CSharpSettings settings)
        {
            this.Settings = settings;
        }
        public CSharpCreatorBase()
        {
        }

        public abstract void WriteClass(ref StringBuilder classBuilder, ClrProperty[] properties);

        protected void OpenCurlyBraces(StringBuilder classBuilder)
        {
            AddTabs(classBuilder);
            classBuilder.AppendLine("{");
            ++tabCount;
        }

        protected void CloseCurlyBraces(StringBuilder classBuilder)
        {
            --tabCount;
            AddTabs(classBuilder);
            classBuilder.AppendLine("}");
        }

        protected void AppendLine(StringBuilder classBuilder, string code)
        {
            AddTabs(classBuilder);
            classBuilder.AppendLine(code);
        }
        protected void AppendLine(StringBuilder classBuilder)
        {
            classBuilder.AppendLine();
        }

        protected void AddTabs(StringBuilder classBuilder)
        {
            for (int i = 0; i < tabCount; ++i)
            {
                classBuilder.Append("\t");
            }
        }

        protected string GetNamePerConvention(string name, NamingConventions convention, string customPrefix)
        {
            switch (convention)
            {
                case NamingConventions.CamelCase: return GetCamelCase(name);
                case NamingConventions.Custom: return $"{customPrefix}{name}";
                case NamingConventions.PascalCase: return GetPascalCase(name);
            }
            return name;
        }

        private string GetCamelCase(string name)
        {
            return (Char.ToLowerInvariant(name[0]) + name.Substring(1)).Replace("_", string.Empty).Replace(" ", string.Empty);
        }

        private string GetPascalCase(string name)
        {
            return (Char.ToUpperInvariant(name[0]) + name.Substring(1)).Replace("_", string.Empty).Replace(" ", string.Empty);
        }
    }
}
