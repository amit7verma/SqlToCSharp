namespace SqlToCSharp.UserControls
{
    partial class ClassGeneratorSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.resetAction = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.prependGetterControl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.prependSetterControl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.propsConventionControl = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fieldsConventionControl = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.membersTypeControl = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.accessModifierControl = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.namespaceControl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.classNameControl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(118, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "&Help";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(175, 345);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(73, 23);
            this.applyButton.TabIndex = 13;
            this.applyButton.Text = "&Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.resetAction);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.applyButton);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 373);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // resetAction
            // 
            this.resetAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetAction.Location = new System.Drawing.Point(8, 345);
            this.resetAction.Name = "resetAction";
            this.resetAction.Size = new System.Drawing.Size(52, 23);
            this.resetAction.TabIndex = 14;
            this.resetAction.Text = "&Reset";
            this.resetAction.UseVisualStyleBackColor = true;
            this.resetAction.Click += new System.EventHandler(this.resetAction_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.prependGetterControl);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.prependSetterControl);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.propsConventionControl);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.fieldsConventionControl);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.membersTypeControl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(7, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 181);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fields && Properties";
            // 
            // prependGetterControl
            // 
            this.prependGetterControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prependGetterControl.Location = new System.Drawing.Point(111, 148);
            this.prependGetterControl.Name = "prependGetterControl";
            this.prependGetterControl.Size = new System.Drawing.Size(119, 20);
            this.prependGetterControl.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Prepend in Getter: ";
            // 
            // prependSetterControl
            // 
            this.prependSetterControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prependSetterControl.Location = new System.Drawing.Point(111, 117);
            this.prependSetterControl.Name = "prependSetterControl";
            this.prependSetterControl.Size = new System.Drawing.Size(119, 20);
            this.prependSetterControl.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Prepend in Setter: ";
            // 
            // propsConventionControl
            // 
            this.propsConventionControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propsConventionControl.FormattingEnabled = true;
            this.propsConventionControl.Items.AddRange(new object[] {
            "Pascal-Case",
            "Camel-Case"});
            this.propsConventionControl.Location = new System.Drawing.Point(111, 88);
            this.propsConventionControl.Name = "propsConventionControl";
            this.propsConventionControl.Size = new System.Drawing.Size(119, 21);
            this.propsConventionControl.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Convention (Proprts): ";
            // 
            // fieldsConventionControl
            // 
            this.fieldsConventionControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsConventionControl.FormattingEnabled = true;
            this.fieldsConventionControl.Items.AddRange(new object[] {
            "Camel-Case",
            "Pascal-Case"});
            this.fieldsConventionControl.Location = new System.Drawing.Point(111, 57);
            this.fieldsConventionControl.Name = "fieldsConventionControl";
            this.fieldsConventionControl.Size = new System.Drawing.Size(119, 21);
            this.fieldsConventionControl.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Convention (Fields): ";
            // 
            // membersTypeControl
            // 
            this.membersTypeControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.membersTypeControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.membersTypeControl.FormattingEnabled = true;
            this.membersTypeControl.Items.AddRange(new object[] {
            "Auto-Implemented Properties",
            "Fields encapsulated with Properties",
            "Fields only"});
            this.membersTypeControl.Location = new System.Drawing.Point(111, 26);
            this.membersTypeControl.Name = "membersTypeControl";
            this.membersTypeControl.Size = new System.Drawing.Size(119, 21);
            this.membersTypeControl.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Member Type: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.accessModifierControl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.namespaceControl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.classNameControl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Class && Namespace";
            // 
            // accessModifierControl
            // 
            this.accessModifierControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accessModifierControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accessModifierControl.FormattingEnabled = true;
            this.accessModifierControl.Items.AddRange(new object[] {
            "public",
            "protected",
            "internal"});
            this.accessModifierControl.Location = new System.Drawing.Point(99, 88);
            this.accessModifierControl.Name = "accessModifierControl";
            this.accessModifierControl.Size = new System.Drawing.Size(131, 21);
            this.accessModifierControl.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Access Modifier: ";
            // 
            // namespaceControl
            // 
            this.namespaceControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.namespaceControl.Location = new System.Drawing.Point(99, 57);
            this.namespaceControl.Name = "namespaceControl";
            this.namespaceControl.Size = new System.Drawing.Size(131, 20);
            this.namespaceControl.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Namespace: ";
            // 
            // classNameControl
            // 
            this.classNameControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classNameControl.Location = new System.Drawing.Point(99, 27);
            this.classNameControl.Name = "classNameControl";
            this.classNameControl.Size = new System.Drawing.Size(131, 20);
            this.classNameControl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class name: ";
            // 
            // ClassGeneratorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "ClassGeneratorSettings";
            this.Size = new System.Drawing.Size(255, 373);
            this.Load += new System.EventHandler(this.ClassSettings_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox prependGetterControl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox prependSetterControl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox propsConventionControl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox fieldsConventionControl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox membersTypeControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox accessModifierControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox namespaceControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox classNameControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetAction;
    }
}
