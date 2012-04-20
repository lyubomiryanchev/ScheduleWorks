namespace ScheduleWorks.UI
{
    partial class SetTimeoffForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn3 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn4 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn5 = new Telerik.WinControls.UI.GridViewImageColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetTimeoffForm));
            this.gridviewTimeoff = new Telerik.WinControls.UI.RadGridView();
            this.buttonReady = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewTimeoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonReady)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridviewTimeoff
            // 
            this.gridviewTimeoff.Location = new System.Drawing.Point(13, 13);
            // 
            // gridviewTimeoff
            // 
            this.gridviewTimeoff.MasterTemplate.AllowAddNewRow = false;
            this.gridviewTimeoff.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.HeaderText = "№";
            gridViewTextBoxColumn1.Name = "number";
            gridViewTextBoxColumn1.Width = 15;
            gridViewImageColumn1.HeaderText = "понеделник";
            gridViewImageColumn1.Name = "monday";
            gridViewImageColumn2.HeaderText = "вторник";
            gridViewImageColumn2.Name = "tuesday";
            gridViewImageColumn3.HeaderText = "сряда";
            gridViewImageColumn3.Name = "wednesday";
            gridViewImageColumn4.HeaderText = "четвъртък";
            gridViewImageColumn4.Name = "thurstday";
            gridViewImageColumn5.HeaderText = "петък";
            gridViewImageColumn5.Name = "friday";
            this.gridviewTimeoff.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewImageColumn1,
            gridViewImageColumn2,
            gridViewImageColumn3,
            gridViewImageColumn4,
            gridViewImageColumn5});
            this.gridviewTimeoff.Name = "gridviewTimeoff";
            this.gridviewTimeoff.ReadOnly = true;
            this.gridviewTimeoff.Size = new System.Drawing.Size(417, 305);
            this.gridviewTimeoff.TabIndex = 0;
            this.gridviewTimeoff.Text = "gridviewTimeoff";
            this.gridviewTimeoff.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridviewTimeoff_CellClick);
            // 
            // buttonReady
            // 
            this.buttonReady.Location = new System.Drawing.Point(300, 324);
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.Size = new System.Drawing.Size(130, 24);
            this.buttonReady.TabIndex = 1;
            this.buttonReady.Text = "Готово";
            this.buttonReady.Click += new System.EventHandler(this.buttonReady_Click);
            // 
            // SetTimeoffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 356);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.gridviewTimeoff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.Name = "SetTimeoffForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(450, 390);
            this.Text = "SetTimeoffForm";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.gridviewTimeoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonReady)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridviewTimeoff;
        private Telerik.WinControls.UI.RadButton buttonReady;
    }
}
