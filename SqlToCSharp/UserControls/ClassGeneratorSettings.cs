using SqlToCSharp.Classes;
using SqlToCSharp.Enums;
using System;
using System.Windows.Forms;

namespace SqlToCSharp.UserControls
{
    /// <summary>
    /// User-control to represent the settings, which is required to generate C# class.
    /// </summary>
    public partial class ClassGeneratorSettings : UserControl
    {
        /// <summary>
        /// The Event Handler delegate declaration.
        /// </summary>
        /// <param name="sender">sender of this event.</param>
        /// <param name="e">Event argument of type ClassGeneratorSettingsEventArgs</param>
        public delegate void ClassGeneratorSettingsEventHandler(ClassGeneratorSettings sender, ClassGeneratorSettingsEventArgs e);

        /// <summary>
        /// The Settings Changed event handler.
        /// </summary>
        public event ClassGeneratorSettingsEventHandler ClassGeneratorSettingsChangedEventHandler;

        /// <summary>
        /// Default Constructor to ClassGeneratorSettings
        /// </summary>
        public ClassGeneratorSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The Load event handler of control.
        /// </summary>
        /// <param name="sender">The object which caused this event.</param>
        /// <param name="e">The object of EventArgs type.</param>
        private void ClassSettings_Load(object sender, EventArgs e)
        {
            this.accessModifierControl.SelectedIndex = 0;
            this.membersTypeControl.SelectedIndex = 0;
            this.fieldsConventionControl.SelectedIndex = 0;
            this.propsConventionControl.SelectedIndex = 0;
        }

        /// <summary>
        /// Click event handler of Apply button.
        /// </summary>
        /// <param name="sender">The object which caused this event.</param>
        /// <param name="e">The object of EventArgs type.</param>
        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        /// <summary>
        /// Applies the changes in settings by raising an SettingsChanged event. 
        /// </summary>
        public void ApplySettings()
        {
            ClassGeneratorSettingsEventArgs settingEventArgs = new ClassGeneratorSettingsEventArgs()
            {
                ClassName = classNameControl.Text.Trim(),
                Namespace = namespaceControl.Text.Trim(),
                AccessModifier = GetAccessModifier(),
                MemberType = GetMemberType(),
                FieldNamingConvention = GetNamingConvention(fieldsConventionControl),
                FieldsPrefix = fieldsConventionControl.Text.Trim(),
                PropertiesNamingConvention = GetNamingConvention(propsConventionControl),
                PropertiesPrefix = propsConventionControl.Text.Trim(),
                CustomLogicSetter = prependSetterControl.Text.Trim(),
                CustomLogicGetter = prependGetterControl.Text.Trim()
            };

            ClassGeneratorSettingsChangedEventHandler(this, settingEventArgs);
        }

        /// <summary>
        /// Get the AccessModifiers enum from UI control. Default is 'public'.
        /// </summary>
        /// <returns>AccessModifiers enum</returns>
        private AccessModifiers GetAccessModifier()
        {
            switch (accessModifierControl.Text.Trim())
            {
                case "public": return AccessModifiers.Public;
                case "protected": return AccessModifiers.Protected;
                case "internal": return AccessModifiers.Internal;
                default: return AccessModifiers.Public;
            }
        }

        /// <summary>
        /// Get MemberTypes enum from UI control, default is 'AutoProperties'.
        /// </summary>
        /// <returns>MemberTypes enum</returns>
        private MemberTypes GetMemberType()
        {            
            switch (membersTypeControl.Text.Trim())
            {
                case "Auto-Implemented Properties": return MemberTypes.AutoProperties;
                case "Fields encapsulated with Properties": return MemberTypes.FieldEncapsulatedByproperties;
                case "Fields only": return MemberTypes.FieldsOnly;
                default: return MemberTypes.AutoProperties;
            }
        }

        /// <summary>
        /// Get NamingConventions enum from ComboBox UI contol, defaukt is 'Custom'.
        /// </summary>
        /// <param name="comboBox">UI control of ComboBox type.</param>
        /// <returns>NamingConventions enum</returns>
        private NamingConventions GetNamingConvention(ComboBox comboBox)
        {            
            switch (comboBox.Text.Trim())
            {
                case "Camel-Case": return NamingConventions.CamelCase;
                case "Pascal-Case": return NamingConventions.PascalCase;
                default: return NamingConventions.Custom;
            }
        }
    }
}
