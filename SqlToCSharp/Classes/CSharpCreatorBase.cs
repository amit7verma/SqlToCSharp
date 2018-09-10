using SqlToCSharp.Enums;
using System;
using System.Text;

namespace SqlToCSharp.Classes
{
    /// <summary>
    /// Abstract base class for C# code generator.
    /// </summary>
    public abstract class CSharpCreatorBase
    {
        /// <summary>
        /// These many tabs will be added to a new line.
        /// </summary>
        private int tabCount;

        /// <summary>
        /// Instance of StringBuilder, on which C# class will be written.
        /// </summary>
        protected StringBuilder classBuilder = null;

        public CSharpCreatorBase()
        {
            classBuilder = new StringBuilder();
        }

        /// <summary>
        /// Generates C# code as per specified settings and properties.
        /// </summary>
        /// <param name="settings">C# generator settings</param>
        /// <param name="properties">Array of ClrProperty type</param>
        /// <returns>C# code body in string.</returns>
        public abstract string GenerateCSharpCode(CSharpSettings settings, ClrProperty[] properties);

        /// <summary>
        /// Adjust Indentation and write "{" to Class definition body.
        /// </summary>
        protected void OpenCurlyBraces()
        {
            AddTabs();
            classBuilder.AppendLine("{");
            ++tabCount;
        }

        /// <summary>
        /// Adjust Indentation and write "}" to Class definition body.
        /// </summary>
        protected void CloseCurlyBraces()
        {
            --tabCount;
            AddTabs();
            classBuilder.AppendLine("}");
        }

        /// <summary>
        /// Adjust Indentation and write new line of C# code to Class definition body.
        /// </summary>
        /// <param name="code"></param>
        protected void AppendLine(string code)
        {
            AddTabs();
            classBuilder.AppendLine(code);
        }

        /// <summary>
        /// Writes a blank new line to Class definition body.
        /// </summary>
        protected void AppendLine()
        {
            classBuilder.AppendLine();
        }

        /// <summary>
        /// Adds indentation by tabCount to current line.
        /// </summary>
        protected void AddTabs()
        {
            for (int i = 0; i < tabCount; ++i)
            {
                classBuilder.Append("\t");
            }
        }

        /// <summary>
        /// Gets name of member as per specified Naming convention, and if Convention is set to custom, then add specified prefix.
        /// </summary>
        /// <param name="name">Member name as retrieved form database.</param>
        /// <param name="convention">Naming convention as per C# generator setting.</param>
        /// <param name="customPrefix">String value, which has to be prefixed to member name.</param>
        /// <returns>Modified name of member, as per convention.</returns>
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

        /// <summary>
        /// Gets name of member, modified to Camel-case.
        /// </summary>
        /// <param name="name">Member name as retrieved form database.</param>
        /// <returns>Modified name of member in Camel-case.</returns>
        private string GetCamelCase(string name)
        {
            return (Char.ToLowerInvariant(name[0]) + name.Substring(1)).Replace("_", string.Empty).Replace(" ", string.Empty);
        }

        /// <summary>
        /// Gets name of member, modified to Pascal-case.
        /// </summary>
        /// <param name="name">Member name as retrieved form database.</param>
        /// <returns>Modified name of member in Pascal-case.</returns>
        private string GetPascalCase(string name)
        {
            return (Char.ToUpperInvariant(name[0]) + name.Substring(1)).Replace("_", string.Empty).Replace(" ", string.Empty);
        }
    }
}
