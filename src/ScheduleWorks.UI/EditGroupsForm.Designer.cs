namespace ScheduleWorks.UI
{
    partial class EditGroupsForm
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
            this.gridviewGroups = new Telerik.WinControls.UI.RadGridView();
            this.buttonReady = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonReady)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridviewGroups
            // 
            this.gridviewGroups.Location = new System.Drawing.Point(12, 12);
            this.gridviewGroups.Name = "gridviewGroups";
            this.gridviewGroups.Size = new System.Drawing.Size(500, 163);
            this.gridviewGroups.TabIndex = 0;
            this.gridviewGroups.Text = "radGridView1";
            // 
            // buttonReady
            // 
            this.buttonReady.Location = new System.Drawing.Point(382, 181);
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.Size = new System.Drawing.Size(130, 24);
            this.buttonReady.TabIndex = 1;
            this.buttonReady.Text = "Готово";
            this.buttonReady.Click += new System.EventHandler(this.buttonReady_Click);
            // 
            // EditGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 212);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.gridviewGroups);
            this.Name = "EditGroupsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Редактирай групи";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.gridviewGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonReady)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridviewGroups;
        private Telerik.WinControls.UI.RadButton buttonReady;


    }
}
