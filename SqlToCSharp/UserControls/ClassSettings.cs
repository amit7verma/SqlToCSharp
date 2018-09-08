using SqlToCSharp.Classes;
using SqlToCSharp.Enums;
using System;
using System.Windows.Forms;

namespace SqlToCSharp.UserControls
{
    public partial class ClassSettings : UserControl
    {
        public delegate void ClassSettingsEventHandler(ClassSettings sender, ClassSettingsEventArgs e);

        public event ClassSettingsEventHandler ClassSettingChangedEventHandler;

        public ClassSettings()
        {
            InitializeComponent();
        }

        private void ClassSettings_Load(object sender, EventArgs e)
        {
            this.accessModifierControl.SelectedIndex = 0;
            this.membersTypeControl.SelectedIndex = 0;
            this.fieldsConventionControl.SelectedIndex = 0;
            this.propsConventionControl.SelectedIndex = 0;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        public void ApplySettings()
        {
            ClassSettingsEventArgs settingEventArgs = new ClassSettingsEventArgs()
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

            ClassSettingChangedEventHandler(this, settingEventArgs);
        }
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
        private MemberTypes GetMemberType()
        {
            /*
                Auto-Implemented Properties
                Fields encapsulated with Properties
                Fields only
             */
            switch (membersTypeControl.Text.Trim())
            {
                case "Auto-Implemented Properties": return MemberTypes.AutoProperties;
                case "Fields encapsulated with Properties": return MemberTypes.FieldEncapsulatedByproperties;
                case "Fields only": return MemberTypes.FieldsOnly;
                default: return MemberTypes.AutoProperties;
            }
        }

        private NamingConventions GetNamingConvention(ComboBox comboBox)
        {
            /*
                Camel-Case
                Pascal-Case
             */
            switch (comboBox.Text.Trim())
            {
                case "Camel-Case": return NamingConventions.CamelCase;
                case "Pascal-Case": return NamingConventions.PascalCase;
                default: return NamingConventions.Custom;
            }
        }       
    }
}
