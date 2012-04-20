namespace ScheduleWorks.UI
{
    partial class WizardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardForm));
            this.schoolNameTextbox = new Telerik.WinControls.UI.RadTextBox();
            this.schoolYearTextbox = new Telerik.WinControls.UI.RadTextBox();
            this.schoolYearLabel = new Telerik.WinControls.UI.RadLabel();
            this.schoolNameLabel = new Telerik.WinControls.UI.RadLabel();
            this.subjectsDifficultyButton = new Telerik.WinControls.UI.RadButton();
            this.addRoomsInformationButton = new Telerik.WinControls.UI.RadButton();
            this.browseForDBFileButton = new Telerik.WinControls.UI.RadButton();
            this.filePathLabel = new Telerik.WinControls.UI.RadTextBox();
            this.chooseDBFileLabel = new Telerik.WinControls.UI.RadLabel();
            this.wizardFinishedButton = new Telerik.WinControls.UI.RadButton();
            this.schoolGroup = new Telerik.WinControls.UI.RadGroupBox();
            this.databaseGroup = new Telerik.WinControls.UI.RadGroupBox();
            this.parametersButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.schoolNameTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsDifficultyButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addRoomsInformationButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browseForDBFileButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filePathLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseDBFileLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardFinishedButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolGroup)).BeginInit();
            this.schoolGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseGroup)).BeginInit();
            this.databaseGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parametersButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // schoolNameTextbox
            // 
            this.schoolNameTextbox.Location = new System.Drawing.Point(98, 23);
            this.schoolNameTextbox.Name = "schoolNameTextbox";
            this.schoolNameTextbox.Size = new System.Drawing.Size(593, 20);
            this.schoolNameTextbox.TabIndex = 1;
            this.schoolNameTextbox.TabStop = false;
            // 
            // schoolYearTextbox
            // 
            this.schoolYearTextbox.Location = new System.Drawing.Point(98, 49);
            this.schoolYearTextbox.Name = "schoolYearTextbox";
            this.schoolYearTextbox.Size = new System.Drawing.Size(141, 20);
            this.schoolYearTextbox.TabIndex = 2;
            this.schoolYearTextbox.TabStop = false;
            // 
            // schoolYearLabel
            // 
            this.schoolYearLabel.Location = new System.Drawing.Point(6, 49);
            this.schoolYearLabel.Name = "schoolYearLabel";
            this.schoolYearLabel.Size = new System.Drawing.Size(85, 18);
            this.schoolYearLabel.TabIndex = 2;
            this.schoolYearLabel.Text = "Учебна година:";
            // 
            // schoolNameLabel
            // 
            this.schoolNameLabel.Location = new System.Drawing.Point(6, 23);
            this.schoolNameLabel.Name = "schoolNameLabel";
            this.schoolNameLabel.Size = new System.Drawing.Size(31, 18);
            this.schoolNameLabel.TabIndex = 1;
            this.schoolNameLabel.Text = "Име:";
            // 
            // subjectsDifficultyButton
            // 
            this.subjectsDifficultyButton.Image = global::ScheduleWorks.UI.Properties.Resources.subjectsDifficultyIcon;
            this.subjectsDifficultyButton.Location = new System.Drawing.Point(406, 59);
            this.subjectsDifficultyButton.Name = "subjectsDifficultyButton";
            this.subjectsDifficultyButton.Size = new System.Drawing.Size(284, 56);
            this.subjectsDifficultyButton.TabIndex = 5;
            this.subjectsDifficultyButton.Text = "Редактирай трудността на предметите";
            this.subjectsDifficultyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.subjectsDifficultyButton.Click += new System.EventHandler(this.subjectsDifficultyButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.subjectsDifficultyButton.GetChildAt(0))).Image = global::ScheduleWorks.UI.Properties.Resources.subjectsDifficultyIcon;
            ((Telerik.WinControls.UI.RadButtonElement)(this.subjectsDifficultyButton.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.subjectsDifficultyButton.GetChildAt(0))).Text = "Редактирай трудността на предметите";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.subjectsDifficultyButton.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.subjectsDifficultyButton.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addRoomsInformationButton
            // 
            this.addRoomsInformationButton.Image = global::ScheduleWorks.UI.Properties.Resources.classroomIcon;
            this.addRoomsInformationButton.Location = new System.Drawing.Point(6, 59);
            this.addRoomsInformationButton.Name = "addRoomsInformationButton";
            this.addRoomsInformationButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            // 
            // 
            // 
            this.addRoomsInformationButton.RootElement.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.addRoomsInformationButton.Size = new System.Drawing.Size(232, 56);
            this.addRoomsInformationButton.TabIndex = 3;
            this.addRoomsInformationButton.Text = "Въведи информация за стаите";
            this.addRoomsInformationButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addRoomsInformationButton.Click += new System.EventHandler(this.addRoomsInformationButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.addRoomsInformationButton.GetChildAt(0))).Image = global::ScheduleWorks.UI.Properties.Resources.classroomIcon;
            ((Telerik.WinControls.UI.RadButtonElement)(this.addRoomsInformationButton.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.addRoomsInformationButton.GetChildAt(0))).Text = "Въведи информация за стаите";
            ((Telerik.WinControls.UI.RadButtonElement)(this.addRoomsInformationButton.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.addRoomsInformationButton.GetChildAt(0).GetChildAt(1).GetChildAt(0))).PositionOffset = new System.Drawing.SizeF(0F, 0F);
            // 
            // browseForDBFileButton
            // 
            this.browseForDBFileButton.Location = new System.Drawing.Point(561, 21);
            this.browseForDBFileButton.Name = "browseForDBFileButton";
            this.browseForDBFileButton.Size = new System.Drawing.Size(130, 24);
            this.browseForDBFileButton.TabIndex = 2;
            this.browseForDBFileButton.Text = "Разлисти";
            this.browseForDBFileButton.Click += new System.EventHandler(this.browseForDBFileButtonClick);
            // 
            // filePathLabel
            // 
            this.filePathLabel.Location = new System.Drawing.Point(182, 23);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(373, 20);
            this.filePathLabel.TabIndex = 1;
            this.filePathLabel.TabStop = false;
            // 
            // chooseDBFileLabel
            // 
            this.chooseDBFileLabel.Location = new System.Drawing.Point(6, 23);
            this.chooseDBFileLabel.Name = "chooseDBFileLabel";
            this.chooseDBFileLabel.Size = new System.Drawing.Size(170, 18);
            this.chooseDBFileLabel.TabIndex = 0;
            this.chooseDBFileLabel.Text = "Избери файла на базата данни:";
            // 
            // wizardFinishedButton
            // 
            this.wizardFinishedButton.Location = new System.Drawing.Point(580, 226);
            this.wizardFinishedButton.Name = "wizardFinishedButton";
            this.wizardFinishedButton.Size = new System.Drawing.Size(130, 24);
            this.wizardFinishedButton.TabIndex = 2;
            this.wizardFinishedButton.Text = "Готово";
            this.wizardFinishedButton.Click += new System.EventHandler(this.wizardFinishedButton_Click);
            // 
            // schoolGroup
            // 
            this.schoolGroup.Controls.Add(this.schoolNameTextbox);
            this.schoolGroup.Controls.Add(this.schoolNameLabel);
            this.schoolGroup.Controls.Add(this.schoolYearLabel);
            this.schoolGroup.Controls.Add(this.schoolYearTextbox);
            this.schoolGroup.FooterImageIndex = -1;
            this.schoolGroup.FooterImageKey = "";
            this.schoolGroup.HeaderImageIndex = -1;
            this.schoolGroup.HeaderImageKey = "";
            this.schoolGroup.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.schoolGroup.HeaderText = "Вашето училище";
            this.schoolGroup.Location = new System.Drawing.Point(13, 13);
            this.schoolGroup.Name = "schoolGroup";
            this.schoolGroup.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.schoolGroup.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.schoolGroup.Size = new System.Drawing.Size(697, 77);
            this.schoolGroup.TabIndex = 3;
            this.schoolGroup.Text = "Вашето училище";
            // 
            // databaseGroup
            // 
            this.databaseGroup.Controls.Add(this.chooseDBFileLabel);
            this.databaseGroup.Controls.Add(this.subjectsDifficultyButton);
            this.databaseGroup.Controls.Add(this.filePathLabel);
            this.databaseGroup.Controls.Add(this.browseForDBFileButton);
            this.databaseGroup.Controls.Add(this.parametersButton);
            this.databaseGroup.Controls.Add(this.addRoomsInformationButton);
            this.databaseGroup.FooterImageIndex = -1;
            this.databaseGroup.FooterImageKey = "";
            this.databaseGroup.HeaderImageIndex = -1;
            this.databaseGroup.HeaderImageKey = "";
            this.databaseGroup.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.databaseGroup.HeaderText = "База данни";
            this.databaseGroup.Location = new System.Drawing.Point(13, 97);
            this.databaseGroup.Name = "databaseGroup";
            this.databaseGroup.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.databaseGroup.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.databaseGroup.Size = new System.Drawing.Size(697, 123);
            this.databaseGroup.TabIndex = 6;
            this.databaseGroup.Text = "База данни";
            // 
            // parametersButton
            // 
            this.parametersButton.Image = global::ScheduleWorks.UI.Properties.Resources.parametersIcon;
            this.parametersButton.Location = new System.Drawing.Point(245, 59);
            this.parametersButton.Name = "parametersButton";
            this.parametersButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            // 
            // 
            // 
            this.parametersButton.RootElement.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.parametersButton.Size = new System.Drawing.Size(154, 56);
            this.parametersButton.TabIndex = 4;
            this.parametersButton.Text = "Особености";
            this.parametersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.parametersButton.Click += new System.EventHandler(this.parametersButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.parametersButton.GetChildAt(0))).Image = global::ScheduleWorks.UI.Properties.Resources.parametersIcon;
            ((Telerik.WinControls.UI.RadButtonElement)(this.parametersButton.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.parametersButton.GetChildAt(0))).Text = "Особености";
            ((Telerik.WinControls.UI.RadButtonElement)(this.parametersButton.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.parametersButton.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 257);
            this.Controls.Add(this.databaseGroup);
            this.Controls.Add(this.schoolGroup);
            this.Controls.Add(this.wizardFinishedButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Помощник за създаване на ново разписание";
            this.ThemeName = "ControlDefault";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WizardForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.schoolNameTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsDifficultyButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addRoomsInformationButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browseForDBFileButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filePathLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseDBFileLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardFinishedButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolGroup)).EndInit();
            this.schoolGroup.ResumeLayout(false);
            this.schoolGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseGroup)).EndInit();
            this.databaseGroup.ResumeLayout(false);
            this.databaseGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parametersButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel schoolYearLabel;
        private Telerik.WinControls.UI.RadLabel schoolNameLabel;
        private Telerik.WinControls.UI.RadTextBox schoolNameTextbox;
        private Telerik.WinControls.UI.RadTextBox schoolYearTextbox;
        private Telerik.WinControls.UI.RadButton addRoomsInformationButton;
        private Telerik.WinControls.UI.RadButton browseForDBFileButton;
        private Telerik.WinControls.UI.RadTextBox filePathLabel;
        private Telerik.WinControls.UI.RadLabel chooseDBFileLabel;
        private Telerik.WinControls.UI.RadButton subjectsDifficultyButton;
        private Telerik.WinControls.UI.RadButton wizardFinishedButton;
        private Telerik.WinControls.UI.RadGroupBox schoolGroup;
        private Telerik.WinControls.UI.RadGroupBox databaseGroup;
        private Telerik.WinControls.UI.RadButton parametersButton;

    }
}
