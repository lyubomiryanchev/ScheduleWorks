namespace ScheduleWorks.UI
{
    partial class AddOrEditClassForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrEditClassForm));
            this.colorGroup = new Telerik.WinControls.UI.RadGroupBox();
            this.changeColorButton = new Telerik.WinControls.UI.RadButton();
            this.colorPanel = new Telerik.WinControls.UI.RadPanel();
            this.nameLabel = new Telerik.WinControls.UI.RadLabel();
            this.nameTextbox = new Telerik.WinControls.UI.RadTextBox();
            this.shortNameLabel = new Telerik.WinControls.UI.RadLabel();
            this.shortNameTextbox = new Telerik.WinControls.UI.RadTextBox();
            this.headTeacherGroup = new Telerik.WinControls.UI.RadGroupBox();
            this.changingHeadteacherReadyButton = new Telerik.WinControls.UI.RadButton();
            this.teachersDropdownlist = new Telerik.WinControls.UI.RadDropDownList();
            this.changeHeadTeacherButton = new Telerik.WinControls.UI.RadButton();
            this.headTeacherNameLabel = new Telerik.WinControls.UI.RadLabel();
            this.gradeDropdownlist = new Telerik.WinControls.UI.RadDropDownList();
            this.gradeLabel = new Telerik.WinControls.UI.RadLabel();
            this.finishButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.colorGroup)).BeginInit();
            this.colorGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeColorButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortNameTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headTeacherGroup)).BeginInit();
            this.headTeacherGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changingHeadteacherReadyButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teachersDropdownlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeHeadTeacherButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headTeacherNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeDropdownlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // colorGroup
            // 
            this.colorGroup.Controls.Add(this.changeColorButton);
            this.colorGroup.Controls.Add(this.colorPanel);
            this.colorGroup.FooterImageIndex = -1;
            this.colorGroup.FooterImageKey = "";
            this.colorGroup.HeaderImageIndex = -1;
            this.colorGroup.HeaderImageKey = "";
            this.colorGroup.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.colorGroup.HeaderText = "Цвят";
            this.colorGroup.Location = new System.Drawing.Point(12, 61);
            this.colorGroup.Name = "colorGroup";
            this.colorGroup.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.colorGroup.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.colorGroup.Size = new System.Drawing.Size(450, 100);
            this.colorGroup.TabIndex = 3;
            this.colorGroup.Text = "Цвят";
            // 
            // changeColorButton
            // 
            this.changeColorButton.Location = new System.Drawing.Point(270, 44);
            this.changeColorButton.Name = "changeColorButton";
            this.changeColorButton.Size = new System.Drawing.Size(130, 24);
            this.changeColorButton.TabIndex = 4;
            this.changeColorButton.Text = "Смяна на цвета";
            this.changeColorButton.Click += new System.EventHandler(this.changeColorButtonClicked);
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.Color.White;
            this.colorPanel.Location = new System.Drawing.Point(13, 24);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(171, 63);
            this.colorPanel.TabIndex = 5;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(12, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(31, 18);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Име:";
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(86, 12);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(200, 20);
            this.nameTextbox.TabIndex = 1;
            this.nameTextbox.TabStop = false;
            this.nameTextbox.TextChanged += new System.EventHandler(this.nameTextboxTextChanged);
            // 
            // shortNameLabel
            // 
            this.shortNameLabel.Location = new System.Drawing.Point(12, 37);
            this.shortNameLabel.Name = "shortNameLabel";
            this.shortNameLabel.Size = new System.Drawing.Size(68, 18);
            this.shortNameLabel.TabIndex = 2;
            this.shortNameLabel.Text = "Кратко име:";
            // 
            // shortNameTextbox
            // 
            this.shortNameTextbox.Location = new System.Drawing.Point(86, 36);
            this.shortNameTextbox.Name = "shortNameTextbox";
            this.shortNameTextbox.Size = new System.Drawing.Size(100, 20);
            this.shortNameTextbox.TabIndex = 2;
            this.shortNameTextbox.TabStop = false;
            // 
            // headTeacherGroup
            // 
            this.headTeacherGroup.Controls.Add(this.changingHeadteacherReadyButton);
            this.headTeacherGroup.Controls.Add(this.teachersDropdownlist);
            this.headTeacherGroup.Controls.Add(this.changeHeadTeacherButton);
            this.headTeacherGroup.Controls.Add(this.headTeacherNameLabel);
            this.headTeacherGroup.FooterImageIndex = -1;
            this.headTeacherGroup.FooterImageKey = "";
            this.headTeacherGroup.HeaderImageIndex = -1;
            this.headTeacherGroup.HeaderImageKey = "";
            this.headTeacherGroup.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.headTeacherGroup.HeaderText = "Класен ръководител";
            this.headTeacherGroup.Location = new System.Drawing.Point(12, 168);
            this.headTeacherGroup.Name = "headTeacherGroup";
            this.headTeacherGroup.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.headTeacherGroup.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.headTeacherGroup.Size = new System.Drawing.Size(450, 48);
            this.headTeacherGroup.TabIndex = 4;
            this.headTeacherGroup.Text = "Класен ръководител";
            // 
            // changingHeadteacherReadyButton
            // 
            this.changingHeadteacherReadyButton.Location = new System.Drawing.Point(270, 17);
            this.changingHeadteacherReadyButton.Name = "changingHeadteacherReadyButton";
            this.changingHeadteacherReadyButton.Size = new System.Drawing.Size(130, 24);
            this.changingHeadteacherReadyButton.TabIndex = 6;
            this.changingHeadteacherReadyButton.Text = "Готово";
            this.changingHeadteacherReadyButton.Click += new System.EventHandler(this.changingHeadteacherReadyButtonClick);
            // 
            // teachersDropdownlist
            // 
            this.teachersDropdownlist.Location = new System.Drawing.Point(131, 20);
            this.teachersDropdownlist.Name = "teachersDropdownlist";
            this.teachersDropdownlist.ShowImageInEditorArea = true;
            this.teachersDropdownlist.Size = new System.Drawing.Size(106, 21);
            this.teachersDropdownlist.TabIndex = 5;
            // 
            // changeHeadTeacherButton
            // 
            this.changeHeadTeacherButton.Location = new System.Drawing.Point(270, 17);
            this.changeHeadTeacherButton.Name = "changeHeadTeacherButton";
            this.changeHeadTeacherButton.Size = new System.Drawing.Size(130, 24);
            this.changeHeadTeacherButton.TabIndex = 1;
            this.changeHeadTeacherButton.Text = "Смяна";
            this.changeHeadTeacherButton.Click += new System.EventHandler(this.changeHeadTeacherButtonClick);
            // 
            // headTeacherNameLabel
            // 
            this.headTeacherNameLabel.Location = new System.Drawing.Point(13, 23);
            this.headTeacherNameLabel.Name = "headTeacherNameLabel";
            this.headTeacherNameLabel.Size = new System.Drawing.Size(93, 18);
            this.headTeacherNameLabel.TabIndex = 0;
            this.headTeacherNameLabel.Text = "Изберете учител";
            // 
            // gradeDropdownlist
            // 
            this.gradeDropdownlist.Location = new System.Drawing.Point(350, 11);
            this.gradeDropdownlist.Name = "gradeDropdownlist";
            this.gradeDropdownlist.ShowImageInEditorArea = true;
            this.gradeDropdownlist.Size = new System.Drawing.Size(48, 21);
            this.gradeDropdownlist.TabIndex = 3;
            // 
            // gradeLabel
            // 
            this.gradeLabel.Location = new System.Drawing.Point(312, 14);
            this.gradeLabel.Name = "gradeLabel";
            this.gradeLabel.Size = new System.Drawing.Size(32, 18);
            this.gradeLabel.TabIndex = 6;
            this.gradeLabel.Text = "Клас:";
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(332, 222);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(130, 24);
            this.finishButton.TabIndex = 9;
            this.finishButton.Text = "Готово";
            this.finishButton.Click += new System.EventHandler(this.finishButtonClick);
            // 
            // AddOrEditClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 255);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.gradeLabel);
            this.Controls.Add(this.gradeDropdownlist);
            this.Controls.Add(this.headTeacherGroup);
            this.Controls.Add(this.colorGroup);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.shortNameTextbox);
            this.Controls.Add(this.shortNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.Name = "AddOrEditClassForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(483, 289);
            this.Text = "AddOrRemoveClassForm";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.colorGroup)).EndInit();
            this.colorGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changeColorButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortNameTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headTeacherGroup)).EndInit();
            this.headTeacherGroup.ResumeLayout(false);
            this.headTeacherGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changingHeadteacherReadyButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teachersDropdownlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeHeadTeacherButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headTeacherNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeDropdownlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox colorGroup;
        private Telerik.WinControls.UI.RadButton changeColorButton;
        private Telerik.WinControls.UI.RadPanel colorPanel;
        private Telerik.WinControls.UI.RadLabel nameLabel;
        private Telerik.WinControls.UI.RadTextBox nameTextbox;
        private Telerik.WinControls.UI.RadLabel shortNameLabel;
        private Telerik.WinControls.UI.RadTextBox shortNameTextbox;
        private Telerik.WinControls.UI.RadGroupBox headTeacherGroup;
        private Telerik.WinControls.UI.RadButton changeHeadTeacherButton;
        private Telerik.WinControls.UI.RadLabel headTeacherNameLabel;
        private Telerik.WinControls.UI.RadDropDownList gradeDropdownlist;
        private Telerik.WinControls.UI.RadLabel gradeLabel;
        private Telerik.WinControls.UI.RadButton finishButton;
        private Telerik.WinControls.UI.RadDropDownList teachersDropdownlist;
        private Telerik.WinControls.UI.RadButton changingHeadteacherReadyButton;
    }
}
