namespace ScheduleWorks.UI
{
    partial class TimetableGridview
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
            this.gridviewSchedule = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // gridviewSchedule
            // 
            this.gridviewSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridviewSchedule.Location = new System.Drawing.Point(0, 0);
            this.gridviewSchedule.Name = "gridviewSchedule";
            this.gridviewSchedule.Size = new System.Drawing.Size(806, 377);
            this.gridviewSchedule.TabIndex = 1;
            this.gridviewSchedule.Text = "radGridView1";
            // 
            // TimetableGridview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridviewSchedule);
            this.Name = "TimetableGridview";
            this.Size = new System.Drawing.Size(806, 377);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView gridviewSchedule;



    }
}
