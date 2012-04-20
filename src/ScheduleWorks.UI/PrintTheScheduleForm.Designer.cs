namespace ScheduleWorks.UI
{
    partial class PrintTheScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintTheScheduleForm));
            this.gridviewSchedule = new Telerik.WinControls.UI.RadGridView();
            this.exportButton = new Telerik.WinControls.UI.RadButton();
            this.dropdownListClasses = new Telerik.WinControls.UI.RadDropDownList();
            this.buttonLoadTimetable = new Telerik.WinControls.UI.RadButton();
            this.labelFor = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownListClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadTimetable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridviewSchedule
            // 
            this.gridviewSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridviewSchedule.Location = new System.Drawing.Point(12, 66);
            this.gridviewSchedule.Name = "gridviewSchedule";
            this.gridviewSchedule.Size = new System.Drawing.Size(762, 256);
            this.gridviewSchedule.TabIndex = 0;
            this.gridviewSchedule.Text = "radGridView1";
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(644, 328);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(130, 24);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "Запази";
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // dropdownListClasses
            // 
            this.dropdownListClasses.Location = new System.Drawing.Point(39, 36);
            this.dropdownListClasses.Name = "dropdownListClasses";
            this.dropdownListClasses.ShowImageInEditorArea = true;
            this.dropdownListClasses.Size = new System.Drawing.Size(155, 21);
            this.dropdownListClasses.TabIndex = 2;
            // 
            // buttonLoadTimetable
            // 
            this.buttonLoadTimetable.Location = new System.Drawing.Point(200, 35);
            this.buttonLoadTimetable.Name = "buttonLoadTimetable";
            this.buttonLoadTimetable.Size = new System.Drawing.Size(130, 24);
            this.buttonLoadTimetable.TabIndex = 4;
            this.buttonLoadTimetable.Text = "Зареди разписанието";
            this.buttonLoadTimetable.Click += new System.EventHandler(this.buttonLoadTimetable_Click);
            // 
            // labelFor
            // 
            this.labelFor.Location = new System.Drawing.Point(12, 37);
            this.labelFor.Name = "labelFor";
            this.labelFor.Size = new System.Drawing.Size(21, 18);
            this.labelFor.TabIndex = 6;
            this.labelFor.Text = "За:";
            // 
            // PrintTheScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 364);
            this.Controls.Add(this.labelFor);
            this.Controls.Add(this.buttonLoadTimetable);
            this.Controls.Add(this.dropdownListClasses);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.gridviewSchedule);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintTheScheduleForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Ескпортирай разписание";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownListClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadTimetable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridviewSchedule;
        private Telerik.WinControls.UI.RadButton exportButton;
        private Telerik.WinControls.UI.RadDropDownList dropdownListClasses;
        private Telerik.WinControls.UI.RadButton buttonLoadTimetable;
        private Telerik.WinControls.UI.RadLabel labelFor;
    }
}
