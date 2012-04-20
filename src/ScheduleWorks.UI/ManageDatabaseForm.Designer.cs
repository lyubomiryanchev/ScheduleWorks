namespace ScheduleWorks.UI
{
    partial class ManageDatabaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDatabaseForm));
            this.pageviewManageDatabase = new Telerik.WinControls.UI.RadPageView();
            this.buttonGroups = new Telerik.WinControls.UI.RadButton();
            this.buttonTimeoff = new Telerik.WinControls.UI.RadButton();
            this.buttonEdit = new Telerik.WinControls.UI.RadButton();
            this.buttonRemove = new Telerik.WinControls.UI.RadButton();
            this.buttonAdd = new Telerik.WinControls.UI.RadButton();
            this.pageTeachers = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridViewTeachers = new Telerik.WinControls.UI.RadGridView();
            this.pageSubjects = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridViewSubjects = new Telerik.WinControls.UI.RadGridView();
            this.pageClasses = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridViewClasses = new Telerik.WinControls.UI.RadGridView();
            this.pageClassrooms = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridViewClassrooms = new Telerik.WinControls.UI.RadGridView();
            this.pageLessons = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridViewLessons = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pageviewManageDatabase)).BeginInit();
            this.pageviewManageDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonTimeoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAdd)).BeginInit();
            this.pageTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTeachers)).BeginInit();
            this.pageSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSubjects)).BeginInit();
            this.pageClasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClasses)).BeginInit();
            this.pageClassrooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClassrooms)).BeginInit();
            this.pageLessons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLessons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageviewManageDatabase
            // 
            this.pageviewManageDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pageviewManageDatabase.Controls.Add(this.pageTeachers);
            this.pageviewManageDatabase.Controls.Add(this.pageSubjects);
            this.pageviewManageDatabase.Controls.Add(this.pageClasses);
            this.pageviewManageDatabase.Controls.Add(this.pageClassrooms);
            this.pageviewManageDatabase.Controls.Add(this.pageLessons);
            this.pageviewManageDatabase.Location = new System.Drawing.Point(13, 13);
            this.pageviewManageDatabase.Name = "pageviewManageDatabase";
            // 
            // 
            // 
            this.pageviewManageDatabase.RootElement.Text = "test";
            this.pageviewManageDatabase.SelectedPage = this.pageTeachers;
            this.pageviewManageDatabase.Size = new System.Drawing.Size(609, 432);
            this.pageviewManageDatabase.TabIndex = 0;
            this.pageviewManageDatabase.Text = "Класове";
            this.pageviewManageDatabase.SelectedPageChanged += new System.EventHandler(this.pageviewManageDatabase_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageviewManageDatabase.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageviewManageDatabase.GetChildAt(0))).ItemAlignment = Telerik.WinControls.UI.StripViewItemAlignment.Center;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageviewManageDatabase.GetChildAt(0))).ItemFitMode = ((Telerik.WinControls.UI.StripViewItemFitMode)((Telerik.WinControls.UI.StripViewItemFitMode.Shrink | Telerik.WinControls.UI.StripViewItemFitMode.Fill)));
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageviewManageDatabase.GetChildAt(0))).ItemDragMode = Telerik.WinControls.UI.PageViewItemDragMode.None;
            // 
            // buttonGroups
            // 
            this.buttonGroups.Image = global::ScheduleWorks.UI.Properties.Resources.users_add;
            this.buttonGroups.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGroups.Location = new System.Drawing.Point(628, 248);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Size = new System.Drawing.Size(130, 24);
            this.buttonGroups.TabIndex = 5;
            this.buttonGroups.Text = "Групи";
            this.buttonGroups.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGroups.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            // 
            // buttonTimeoff
            // 
            this.buttonTimeoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTimeoff.Image = global::ScheduleWorks.UI.Properties.Resources.setTimeoffSmall;
            this.buttonTimeoff.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTimeoff.Location = new System.Drawing.Point(628, 217);
            this.buttonTimeoff.Name = "buttonTimeoff";
            this.buttonTimeoff.Size = new System.Drawing.Size(130, 24);
            this.buttonTimeoff.TabIndex = 4;
            this.buttonTimeoff.Text = "Време за почивка";
            this.buttonTimeoff.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTimeoff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonTimeoff.Click += new System.EventHandler(this.buttonTimeoffClick);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Image = global::ScheduleWorks.UI.Properties.Resources.editSmall;
            this.buttonEdit.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEdit.Location = new System.Drawing.Point(628, 115);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(130, 24);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Редактирай";
            this.buttonEdit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEditClick);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Image = global::ScheduleWorks.UI.Properties.Resources.deleteSmall;
            this.buttonRemove.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRemove.Location = new System.Drawing.Point(628, 145);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(130, 24);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Изтрий";
            this.buttonRemove.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Image = global::ScheduleWorks.UI.Properties.Resources.addSmall;
            this.buttonAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.Location = new System.Drawing.Point(628, 85);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(130, 24);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добави";
            this.buttonAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddClick);
            // 
            // pageTeachers
            // 
            this.pageTeachers.Controls.Add(this.gridViewTeachers);
            this.pageTeachers.Image = global::ScheduleWorks.UI.Properties.Resources.teacherImage;
            this.pageTeachers.Location = new System.Drawing.Point(10, 69);
            this.pageTeachers.Name = "pageTeachers";
            this.pageTeachers.Size = new System.Drawing.Size(588, 352);
            this.pageTeachers.Text = "Учители";
            // 
            // gridViewTeachers
            // 
            this.gridViewTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewTeachers.Location = new System.Drawing.Point(0, 3);
            this.gridViewTeachers.Name = "gridViewTeachers";
            this.gridViewTeachers.Size = new System.Drawing.Size(588, 349);
            this.gridViewTeachers.TabIndex = 0;
            this.gridViewTeachers.Text = "radGridView1";
            // 
            // pageSubjects
            // 
            this.pageSubjects.Controls.Add(this.gridViewSubjects);
            this.pageSubjects.Image = global::ScheduleWorks.UI.Properties.Resources.subjectsImage;
            this.pageSubjects.Location = new System.Drawing.Point(10, 69);
            this.pageSubjects.Name = "pageSubjects";
            this.pageSubjects.Size = new System.Drawing.Size(588, 352);
            this.pageSubjects.Text = "Предмети";
            // 
            // gridViewSubjects
            // 
            this.gridViewSubjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewSubjects.Location = new System.Drawing.Point(0, 3);
            this.gridViewSubjects.Name = "gridViewSubjects";
            this.gridViewSubjects.Size = new System.Drawing.Size(588, 349);
            this.gridViewSubjects.TabIndex = 0;
            this.gridViewSubjects.Text = "radGridView1";
            // 
            // pageClasses
            // 
            this.pageClasses.Controls.Add(this.gridViewClasses);
            this.pageClasses.Image = global::ScheduleWorks.UI.Properties.Resources.classImage;
            this.pageClasses.Location = new System.Drawing.Point(10, 69);
            this.pageClasses.Name = "pageClasses";
            this.pageClasses.Size = new System.Drawing.Size(588, 352);
            this.pageClasses.Text = "Класове";
            // 
            // gridViewClasses
            // 
            this.gridViewClasses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewClasses.Location = new System.Drawing.Point(0, 3);
            this.gridViewClasses.Name = "gridViewClasses";
            this.gridViewClasses.Size = new System.Drawing.Size(588, 349);
            this.gridViewClasses.TabIndex = 0;
            this.gridViewClasses.Text = "gridViewClasses";
            // 
            // pageClassrooms
            // 
            this.pageClassrooms.Controls.Add(this.gridViewClassrooms);
            this.pageClassrooms.Image = global::ScheduleWorks.UI.Properties.Resources.classroomIcon;
            this.pageClassrooms.Location = new System.Drawing.Point(10, 69);
            this.pageClassrooms.Name = "pageClassrooms";
            this.pageClassrooms.Size = new System.Drawing.Size(588, 352);
            this.pageClassrooms.Text = "Стаи";
            // 
            // gridViewClassrooms
            // 
            this.gridViewClassrooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewClassrooms.Location = new System.Drawing.Point(0, 3);
            this.gridViewClassrooms.Name = "gridViewClassrooms";
            this.gridViewClassrooms.Size = new System.Drawing.Size(588, 349);
            this.gridViewClassrooms.TabIndex = 0;
            this.gridViewClassrooms.Text = "radGridView1";
            // 
            // pageLessons
            // 
            this.pageLessons.Controls.Add(this.gridViewLessons);
            this.pageLessons.Image = global::ScheduleWorks.UI.Properties.Resources.blackboardImage;
            this.pageLessons.Location = new System.Drawing.Point(10, 69);
            this.pageLessons.Name = "pageLessons";
            this.pageLessons.Size = new System.Drawing.Size(588, 352);
            this.pageLessons.Text = "Уроци";
            // 
            // gridViewLessons
            // 
            this.gridViewLessons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewLessons.Location = new System.Drawing.Point(0, 3);
            this.gridViewLessons.Name = "gridViewLessons";
            this.gridViewLessons.Size = new System.Drawing.Size(588, 349);
            this.gridViewLessons.TabIndex = 0;
            this.gridViewLessons.Text = "radGridView1";
            // 
            // ManageDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 457);
            this.Controls.Add(this.buttonGroups);
            this.Controls.Add(this.buttonTimeoff);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.pageviewManageDatabase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageDatabaseForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Manage Database Form";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.pageviewManageDatabase)).EndInit();
            this.pageviewManageDatabase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonTimeoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAdd)).EndInit();
            this.pageTeachers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTeachers)).EndInit();
            this.pageSubjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSubjects)).EndInit();
            this.pageClasses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClasses)).EndInit();
            this.pageClassrooms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClassrooms)).EndInit();
            this.pageLessons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLessons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadPageView pageviewManageDatabase;
        public Telerik.WinControls.UI.RadPageViewPage pageClasses;
        public Telerik.WinControls.UI.RadPageViewPage pageTeachers;
        public Telerik.WinControls.UI.RadPageViewPage pageSubjects;
        public Telerik.WinControls.UI.RadPageViewPage pageClassrooms;
        public Telerik.WinControls.UI.RadPageViewPage pageLessons;
        private Telerik.WinControls.UI.RadButton buttonAdd;
        private Telerik.WinControls.UI.RadButton buttonEdit;
        private Telerik.WinControls.UI.RadButton buttonRemove;
        private Telerik.WinControls.UI.RadButton buttonTimeoff;
        private Telerik.WinControls.UI.RadGridView gridViewClasses;
        private Telerik.WinControls.UI.RadGridView gridViewTeachers;
        private Telerik.WinControls.UI.RadGridView gridViewSubjects;
        private Telerik.WinControls.UI.RadGridView gridViewClassrooms;
        private Telerik.WinControls.UI.RadGridView gridViewLessons;
        private Telerik.WinControls.UI.RadButton buttonGroups;

    }
}
