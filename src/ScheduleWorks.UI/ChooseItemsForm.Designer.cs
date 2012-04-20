namespace ScheduleWorks.UI
{
    partial class ChooseItemsForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseItemsForm));
            this.gridviewItems = new Telerik.WinControls.UI.RadGridView();
            this.gridviewSelectedItems = new Telerik.WinControls.UI.RadGridView();
            this.buttonBack = new Telerik.WinControls.UI.RadButton();
            this.buttonForward = new Telerik.WinControls.UI.RadButton();
            this.buttonReady = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSelectedItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonReady)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridviewItems
            // 
            this.gridviewItems.Location = new System.Drawing.Point(12, 12);
            // 
            // gridviewItems
            // 
            gridViewTextBoxColumn1.HeaderText = "Име";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn2.HeaderText = "Съкращение";
            gridViewTextBoxColumn2.Name = "Съкращение";
            gridViewTextBoxColumn3.HeaderText = "Tag";
            gridViewTextBoxColumn3.Name = "Tag";
            this.gridviewItems.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.gridviewItems.Name = "gridviewItems";
            this.gridviewItems.Size = new System.Drawing.Size(240, 409);
            this.gridviewItems.TabIndex = 0;
            // 
            // gridviewSelectedItems
            // 
            this.gridviewSelectedItems.Location = new System.Drawing.Point(309, 12);
            // 
            // gridviewSelectedItems
            // 
            gridViewTextBoxColumn4.HeaderText = "Име";
            gridViewTextBoxColumn4.Name = "Име";
            gridViewTextBoxColumn5.HeaderText = "Съкращение";
            gridViewTextBoxColumn5.Name = "Съкращение";
            gridViewTextBoxColumn6.HeaderText = "Tag";
            gridViewTextBoxColumn6.Name = "Tag";
            this.gridviewSelectedItems.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.gridviewSelectedItems.Name = "gridviewSelectedItems";
            this.gridviewSelectedItems.Size = new System.Drawing.Size(240, 409);
            this.gridviewSelectedItems.TabIndex = 1;
            // 
            // buttonBack
            // 
            this.buttonBack.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.buttonBack.Image = global::ScheduleWorks.UI.Properties.Resources.arrowBackImage;
            this.buttonBack.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonBack.Location = new System.Drawing.Point(262, 323);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(38, 38);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.buttonForward.Image = global::ScheduleWorks.UI.Properties.Resources.arrowForwardImage;
            this.buttonForward.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonForward.Location = new System.Drawing.Point(262, 99);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(38, 38);
            this.buttonForward.TabIndex = 2;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // buttonReady
            // 
            this.buttonReady.Location = new System.Drawing.Point(419, 427);
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.Size = new System.Drawing.Size(130, 24);
            this.buttonReady.TabIndex = 4;
            this.buttonReady.Text = "Готово";
            this.buttonReady.Click += new System.EventHandler(this.buttonReady_Click);
            // 
            // ChooseItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 462);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.gridviewSelectedItems);
            this.Controls.Add(this.gridviewItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChooseItemsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ChooseItemsForm";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.gridviewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSelectedItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonReady)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView gridviewItems;
        public Telerik.WinControls.UI.RadGridView gridviewSelectedItems;
        private Telerik.WinControls.UI.RadButton buttonForward;
        private Telerik.WinControls.UI.RadButton buttonBack;
        private Telerik.WinControls.UI.RadButton buttonReady;
    }
}
