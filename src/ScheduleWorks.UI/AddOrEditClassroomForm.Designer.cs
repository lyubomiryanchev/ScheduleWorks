namespace ScheduleWorks.UI
{
    partial class AddOrEditClassroomForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrEditClassroomForm));
            this.classroomNameLabel = new Telerik.WinControls.UI.RadLabel();
            this.shortClassroomNameLabel = new Telerik.WinControls.UI.RadLabel();
            this.isSpecializedRoomCheckbox = new Telerik.WinControls.UI.RadCheckBox();
            this.chooseHeadclassOfThisClassroom = new Telerik.WinControls.UI.RadButton();
            this.chooseSubjectsToBeTaughtInThisRoomButton = new Telerik.WinControls.UI.RadButton();
            this.isHomeClassroomCheckbox = new Telerik.WinControls.UI.RadCheckBox();
            this.nameTextbox = new Telerik.WinControls.UI.RadTextBox();
            this.shortNameTextbox = new Telerik.WinControls.UI.RadTextBox();
            this.finishButton = new Telerik.WinControls.UI.RadButton();
            this.specificationGroup = new Telerik.WinControls.UI.RadGroupBox();
            this.colorSelectionGroup = new Telerik.WinControls.UI.RadGroupBox();
            this.changeClassroomColorButton = new Telerik.WinControls.UI.RadButton();
            this.panelClassroomColor = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.classroomNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortClassroomNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isSpecializedRoomCheckbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseHeadclassOfThisClassroom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseSubjectsToBeTaughtInThisRoomButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isHomeClassroomCheckbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortNameTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specificationGroup)).BeginInit();
            this.specificationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectionGroup)).BeginInit();
            this.colorSelectionGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeClassroomColorButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClassroomColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // classroomNameLabel
            // 
            this.classroomNameLabel.Location = new System.Drawing.Point(14, 14);
            this.classroomNameLabel.Name = "classroomNameLabel";
            this.classroomNameLabel.Size = new System.Drawing.Size(31, 18);
            this.classroomNameLabel.TabIndex = 0;
            this.classroomNameLabel.Text = "Име:";
            // 
            // shortClassroomNameLabel
            // 
            this.shortClassroomNameLabel.Location = new System.Drawing.Point(13, 38);
            this.shortClassroomNameLabel.Name = "shortClassroomNameLabel";
            this.shortClassroomNameLabel.Size = new System.Drawing.Size(68, 18);
            this.shortClassroomNameLabel.TabIndex = 2;
            this.shortClassroomNameLabel.Text = "Кратко име:";
            // 
            // isSpecializedRoomCheckbox
            // 
            this.isSpecializedRoomCheckbox.AccessibleDescription = "";
            this.isSpecializedRoomCheckbox.Location = new System.Drawing.Point(13, 23);
            this.isSpecializedRoomCheckbox.Name = "isSpecializedRoomCheckbox";
            this.isSpecializedRoomCheckbox.Size = new System.Drawing.Size(137, 18);
            this.isSpecializedRoomCheckbox.TabIndex = 3;
            this.isSpecializedRoomCheckbox.Text = "Специализирана стая?";
            this.isSpecializedRoomCheckbox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.isSpecializedRoomCheckboxToggleStateChanged);
            // 
            // chooseHeadclassOfThisClassroom
            // 
            this.chooseHeadclassOfThisClassroom.Location = new System.Drawing.Point(220, 42);
            this.chooseHeadclassOfThisClassroom.Name = "chooseHeadclassOfThisClassroom";
            this.chooseHeadclassOfThisClassroom.Size = new System.Drawing.Size(130, 24);
            this.chooseHeadclassOfThisClassroom.TabIndex = 6;
            this.chooseHeadclassOfThisClassroom.Text = "Избери клас";
            this.chooseHeadclassOfThisClassroom.Click += new System.EventHandler(this.chooseHeadclassOfThisClassroom_Click);
            // 
            // chooseSubjectsToBeTaughtInThisRoomButton
            // 
            this.chooseSubjectsToBeTaughtInThisRoomButton.Location = new System.Drawing.Point(220, 17);
            this.chooseSubjectsToBeTaughtInThisRoomButton.Name = "chooseSubjectsToBeTaughtInThisRoomButton";
            this.chooseSubjectsToBeTaughtInThisRoomButton.Size = new System.Drawing.Size(130, 24);
            this.chooseSubjectsToBeTaughtInThisRoomButton.TabIndex = 4;
            this.chooseSubjectsToBeTaughtInThisRoomButton.Text = "Избери предмети";
            this.chooseSubjectsToBeTaughtInThisRoomButton.Click += new System.EventHandler(this.chooseSubjectsToBeTaughtInThisRoomButton_Click);
            // 
            // isHomeClassroomCheckbox
            // 
            this.isHomeClassroomCheckbox.Location = new System.Drawing.Point(13, 48);
            this.isHomeClassroomCheckbox.Name = "isHomeClassroomCheckbox";
            this.isHomeClassroomCheckbox.Size = new System.Drawing.Size(86, 18);
            this.isHomeClassroomCheckbox.TabIndex = 5;
            this.isHomeClassroomCheckbox.Text = "Класна стая?";
            this.isHomeClassroomCheckbox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.isHomeClassroomCheckboxToggleStateChanged);
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(87, 10);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(243, 20);
            this.nameTextbox.TabIndex = 1;
            this.nameTextbox.TabStop = false;
            this.nameTextbox.TextChanged += new System.EventHandler(this.classroomNameTextboxTextChanged);
            // 
            // shortNameTextbox
            // 
            this.shortNameTextbox.Location = new System.Drawing.Point(87, 36);
            this.shortNameTextbox.Name = "shortNameTextbox";
            this.shortNameTextbox.Size = new System.Drawing.Size(100, 20);
            this.shortNameTextbox.TabIndex = 2;
            this.shortNameTextbox.TabStop = false;
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(251, 253);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(130, 24);
            this.finishButton.TabIndex = 9;
            this.finishButton.Text = "Готово";
            this.finishButton.Click += new System.EventHandler(this.finishButtonClick);
            // 
            // specificationGroup
            // 
            this.specificationGroup.Controls.Add(this.isSpecializedRoomCheckbox);
            this.specificationGroup.Controls.Add(this.isHomeClassroomCheckbox);
            this.specificationGroup.Controls.Add(this.chooseSubjectsToBeTaughtInThisRoomButton);
            this.specificationGroup.Controls.Add(this.chooseHeadclassOfThisClassroom);
            this.specificationGroup.FooterImageIndex = -1;
            this.specificationGroup.FooterImageKey = "";
            this.specificationGroup.HeaderImageIndex = -1;
            this.specificationGroup.HeaderImageKey = "";
            this.specificationGroup.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.specificationGroup.HeaderText = "Особености";
            this.specificationGroup.Location = new System.Drawing.Point(14, 63);
            this.specificationGroup.Name = "specificationGroup";
            this.specificationGroup.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.specificationGroup.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.specificationGroup.Size = new System.Drawing.Size(367, 78);
            this.specificationGroup.TabIndex = 3;
            this.specificationGroup.Text = "Особености";
            // 
            // colorSelectionGroup
            // 
            this.colorSelectionGroup.Controls.Add(this.changeClassroomColorButton);
            this.colorSelectionGroup.Controls.Add(this.panelClassroomColor);
            this.colorSelectionGroup.FooterImageIndex = -1;
            this.colorSelectionGroup.FooterImageKey = "";
            this.colorSelectionGroup.HeaderImageIndex = -1;
            this.colorSelectionGroup.HeaderImageKey = "";
            this.colorSelectionGroup.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.colorSelectionGroup.HeaderText = "Цвят";
            this.colorSelectionGroup.Location = new System.Drawing.Point(13, 147);
            this.colorSelectionGroup.Name = "colorSelectionGroup";
            this.colorSelectionGroup.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.colorSelectionGroup.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.colorSelectionGroup.Size = new System.Drawing.Size(368, 100);
            this.colorSelectionGroup.TabIndex = 8;
            this.colorSelectionGroup.Text = "Цвят";
            // 
            // changeClassroomColorButton
            // 
            this.changeClassroomColorButton.Location = new System.Drawing.Point(221, 24);
            this.changeClassroomColorButton.Name = "changeClassroomColorButton";
            this.changeClassroomColorButton.Size = new System.Drawing.Size(130, 24);
            this.changeClassroomColorButton.TabIndex = 8;
            this.changeClassroomColorButton.Text = "Смяна на цвета";
            this.changeClassroomColorButton.Click += new System.EventHandler(this.changeClassroomColorButtonClick);
            // 
            // panelClassroomColor
            // 
            this.panelClassroomColor.BackColor = System.Drawing.Color.White;
            this.panelClassroomColor.Location = new System.Drawing.Point(14, 24);
            this.panelClassroomColor.Name = "panelClassroomColor";
            this.panelClassroomColor.Size = new System.Drawing.Size(200, 63);
            this.panelClassroomColor.TabIndex = 0;
            // 
            // AddOrEditClassroomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 282);
            this.Controls.Add(this.colorSelectionGroup);
            this.Controls.Add(this.specificationGroup);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.shortNameTextbox);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.shortClassroomNameLabel);
            this.Controls.Add(this.classroomNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.Name = "AddOrEditClassroomForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(401, 316);
            this.Text = "Менажирай стая";
            this.ThemeName = "ControlDefault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddOrEditClassroomFormFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.classroomNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortClassroomNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isSpecializedRoomCheckbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseHeadclassOfThisClassroom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseSubjectsToBeTaughtInThisRoomButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isHomeClassroomCheckbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortNameTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specificationGroup)).EndInit();
            this.specificationGroup.ResumeLayout(false);
            this.specificationGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectionGroup)).EndInit();
            this.colorSelectionGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changeClassroomColorButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClassroomColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        public Telerik.WinControls.UI.RadLabel shortClassroomNameLabel;
        public Telerik.WinControls.UI.RadTextBox nameTextbox;
        public Telerik.WinControls.UI.RadCheckBox isSpecializedRoomCheckbox;
        public Telerik.WinControls.UI.RadCheckBox isHomeClassroomCheckbox;
        public Telerik.WinControls.UI.RadTextBox shortNameTextbox;
        private Telerik.WinControls.UI.RadLabel classroomNameLabel;
        private Telerik.WinControls.UI.RadButton chooseHeadclassOfThisClassroom;
        private Telerik.WinControls.UI.RadButton chooseSubjectsToBeTaughtInThisRoomButton;
        private Telerik.WinControls.UI.RadButton finishButton;
        private Telerik.WinControls.UI.RadGroupBox specificationGroup;
        private Telerik.WinControls.UI.RadGroupBox colorSelectionGroup;
        private Telerik.WinControls.UI.RadButton changeClassroomColorButton;
        public Telerik.WinControls.UI.RadPanel panelClassroomColor;
    }
}
