using ScheduleWorks.Utility;
namespace ScheduleWorks.UI
{
    public partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabSpecificationGroupHelper = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.tabSpecificationsGroupDBOperations = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.tabTimetableGroupGenerate = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.tabTimetableGroupStatistics = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.radButtonElement2 = new Telerik.WinControls.UI.RadButtonElement();
            this.headerBar = new Telerik.WinControls.UI.RadRibbonBar();
            this.tabHome = new Telerik.WinControls.UI.RibbonTab();
            this.tabHomeGroupFiles = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.tabHomeGroupFilesButtonNewFile = new Telerik.WinControls.UI.RadButtonElement();
            this.tabHomeGroupFilesButtonOpenFile = new Telerik.WinControls.UI.RadButtonElement();
            this.tabHomeGroupFilesButtonSaveFile = new Telerik.WinControls.UI.RadButtonElement();
            this.tabHomeGroupOthers = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.tabHomeGroupOthersButtonHelper = new Telerik.WinControls.UI.RadButtonElement();
            this.buttonParameters = new Telerik.WinControls.UI.RadButtonElement();
            this.tabHomeGroupOperations = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.tabHomeGroupOperationsButtonTeachers = new Telerik.WinControls.UI.RadButtonElement();
            this.tabHomeGroupOperationsButtonSubjects = new Telerik.WinControls.UI.RadButtonElement();
            this.tabHomeGroupOperationsButtonClasses = new Telerik.WinControls.UI.RadButtonElement();
            this.tabHomeGroupOperationsButtonClassrooms = new Telerik.WinControls.UI.RadButtonElement();
            this.tabHomeGroupOperationsButtonLessons = new Telerik.WinControls.UI.RadButtonElement();
            this.tabHomeGroupTimetable = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.buttonGenerateTimetable = new Telerik.WinControls.UI.RadButtonElement();
            this.printTheScheduleButton = new Telerik.WinControls.UI.RadButtonElement();
            this.radRibbonBarGroup1 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.radRibbonBarButtonGroup1 = new Telerik.WinControls.UI.RadRibbonBarButtonGroup();
            this.dropDownListTypeOfTimetablePreview = new Telerik.WinControls.UI.RadDropDownListElement();
            this.dropDownListElementOfTimetablePreview = new Telerik.WinControls.UI.RadDropDownListElement();
            this.buttonNew = new Telerik.WinControls.UI.RadMenuItem();
            this.buttonOpen = new Telerik.WinControls.UI.RadMenuItem();
            this.buttonSave = new Telerik.WinControls.UI.RadMenuItem();
            this.buttonHelp = new Telerik.WinControls.UI.RadMenuItem();
            this.buttonWizard = new Telerik.WinControls.UI.RadMenuItem();
            this.tabHelpGroupDocumentation = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.tabHelpGroupDocumentationButtonHelp = new Telerik.WinControls.UI.RadButtonElement();
            this.radImageButtonElement8 = new Telerik.WinControls.UI.RadButtonElement();
            this.radButtonElement1 = new Telerik.WinControls.UI.RadButtonElement();
            this.dockWindow = new Telerik.WinControls.UI.Docking.RadDock();
            this.na = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.homePicture = new System.Windows.Forms.PictureBox();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.radDropDownButtonElement1 = new Telerik.WinControls.UI.RadDropDownButtonElement();
            ((System.ComponentModel.ISupportInitialize)(this.headerBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropDownListTypeOfTimetablePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropDownListElementOfTimetablePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockWindow)).BeginInit();
            this.dockWindow.SuspendLayout();
            this.na.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSpecificationGroupHelper
            // 
            this.tabSpecificationGroupHelper.Name = "tabSpecificationGroupHelper";
            // 
            // tabSpecificationsGroupDBOperations
            // 
            this.tabSpecificationsGroupDBOperations.Name = "tabSpecificationsGroupDBOperations";
            // 
            // tabTimetableGroupGenerate
            // 
            this.tabTimetableGroupGenerate.Name = "tabTimetableGroupGenerate";
            this.tabTimetableGroupGenerate.Text = "Генерация";
            // 
            // tabTimetableGroupStatistics
            // 
            this.tabTimetableGroupStatistics.Name = "tabTimetableGroupStatistics";
            this.tabTimetableGroupStatistics.Text = "Статистика";
            // 
            // radButtonElement2
            // 
            this.radButtonElement2.Class = "RibbonBarButtonElement";
            this.radButtonElement2.Name = "radButtonElement2";
            this.radButtonElement2.Text = "radButtonElement2";
            // 
            // headerBar
            // 
            this.headerBar.AutoSize = true;
            this.headerBar.CommandTabs.AddRange(new Telerik.WinControls.RadItem[] {
            this.tabHome});
            this.headerBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerBar.EnableKeyMap = true;
            // 
            // 
            // 
            this.headerBar.ExitButton.Text = "Exit";
            this.headerBar.Location = new System.Drawing.Point(0, 0);
            this.headerBar.Name = "headerBar";
            // 
            // 
            // 
            this.headerBar.OptionsButton.Text = "Options";
            // 
            // 
            // 
            this.headerBar.RootElement.PositionOffset = new System.Drawing.SizeF(0F, 0F);
            this.headerBar.RootElement.ShouldPaint = false;
            this.headerBar.Size = new System.Drawing.Size(960, 151);
            this.headerBar.StartButtonImage = ((System.Drawing.Image)(resources.GetObject("headerBar.StartButtonImage")));
            this.headerBar.StartMenuItems.AddRange(new Telerik.WinControls.RadItem[] {
            this.buttonNew,
            this.buttonOpen,
            this.buttonSave,
            this.buttonHelp});
            this.headerBar.StartMenuRightColumnItems.AddRange(new Telerik.WinControls.RadItem[] {
            this.buttonWizard});
            this.headerBar.TabIndex = 0;
            this.headerBar.Text = "УПроГен 1.1";
            this.headerBar.ThemeName = "ControlDefault";
            // 
            // tabHome
            // 
            this.tabHome.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tabHome.ContentPanel
            // 
            this.tabHome.ContentPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabHome.ContentPanel.CausesValidation = true;
            this.tabHome.ContentPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabHome.ContentPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabHome.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.tabHome.ContentPanel.Size = new System.Drawing.Size(200, 100);
            this.tabHome.IsSelected = true;
            this.tabHome.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tabHomeGroupFiles,
            this.tabHomeGroupOthers,
            this.tabHomeGroupOperations,
            this.tabHomeGroupTimetable,
            this.radRibbonBarGroup1});
            this.tabHome.Name = "tabHome";
            this.tabHome.StretchHorizontally = false;
            this.tabHome.Text = "Начало";
            // 
            // tabHomeGroupFiles
            // 
            this.tabHomeGroupFiles.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tabHomeGroupFilesButtonNewFile,
            this.tabHomeGroupFilesButtonOpenFile,
            this.tabHomeGroupFilesButtonSaveFile});
            this.tabHomeGroupFiles.Name = "tabHomeGroupFiles";
            this.tabHomeGroupFiles.Text = "Файлове";
            // 
            // tabHomeGroupFilesButtonNewFile
            // 
            this.tabHomeGroupFilesButtonNewFile.Class = "RibbonBarButtonElement";
            this.tabHomeGroupFilesButtonNewFile.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tabHomeGroupFilesButtonNewFile.Image = global::ScheduleWorks.UI.Properties.Resources.newFile;
            this.tabHomeGroupFilesButtonNewFile.Name = "tabHomeGroupFilesButtonNewFile";
            this.tabHomeGroupFilesButtonNewFile.Text = "Нов";
            this.tabHomeGroupFilesButtonNewFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tabHomeGroupFilesButtonNewFile.UseDefaultDisabledPaint = true;
            this.tabHomeGroupFilesButtonNewFile.Click += new System.EventHandler(this.tabHomeGroupFilesButtonNewFile_Click);
            // 
            // tabHomeGroupFilesButtonOpenFile
            // 
            this.tabHomeGroupFilesButtonOpenFile.Class = "RibbonBarButtonElement";
            this.tabHomeGroupFilesButtonOpenFile.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tabHomeGroupFilesButtonOpenFile.Image = global::ScheduleWorks.UI.Properties.Resources.openFile;
            this.tabHomeGroupFilesButtonOpenFile.Name = "tabHomeGroupFilesButtonOpenFile";
            this.tabHomeGroupFilesButtonOpenFile.Text = "Отвори";
            this.tabHomeGroupFilesButtonOpenFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tabHomeGroupFilesButtonOpenFile.Click += new System.EventHandler(this.tabHomeGroupFilesButtonOpenFile_Click);
            // 
            // tabHomeGroupFilesButtonSaveFile
            // 
            this.tabHomeGroupFilesButtonSaveFile.Class = "RibbonBarButtonElement";
            this.tabHomeGroupFilesButtonSaveFile.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tabHomeGroupFilesButtonSaveFile.Image = global::ScheduleWorks.UI.Properties.Resources.saveFile;
            this.tabHomeGroupFilesButtonSaveFile.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tabHomeGroupFilesButtonSaveFile.Name = "tabHomeGroupFilesButtonSaveFile";
            this.tabHomeGroupFilesButtonSaveFile.Text = "Запази";
            this.tabHomeGroupFilesButtonSaveFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tabHomeGroupFilesButtonSaveFile.Click += new System.EventHandler(this.tabHomeGroupFilesButtonSaveFile_Click);
            // 
            // tabHomeGroupOthers
            // 
            this.tabHomeGroupOthers.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tabHomeGroupOthersButtonHelper,
            this.buttonParameters});
            this.tabHomeGroupOthers.Name = "tabHomeGroupOthers";
            this.tabHomeGroupOthers.Text = "Други";
            // 
            // tabHomeGroupOthersButtonHelper
            // 
            this.tabHomeGroupOthersButtonHelper.Class = "RibbonBarButtonElement";
            this.tabHomeGroupOthersButtonHelper.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tabHomeGroupOthersButtonHelper.Image = global::ScheduleWorks.UI.Properties.Resources.wizardImage;
            this.tabHomeGroupOthersButtonHelper.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tabHomeGroupOthersButtonHelper.Name = "tabHomeGroupOthersButtonHelper";
            this.tabHomeGroupOthersButtonHelper.Text = "Помощник";
            this.tabHomeGroupOthersButtonHelper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tabHomeGroupOthersButtonHelper.Click += new System.EventHandler(this.buttonHelperClick);
            // 
            // buttonParameters
            // 
            this.buttonParameters.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonParameters.Class = "RibbonBarButtonElement";
            this.buttonParameters.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.buttonParameters.Image = global::ScheduleWorks.UI.Properties.Resources.parametersIcon;
            this.buttonParameters.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonParameters.Name = "buttonParameters";
            this.buttonParameters.Text = "Особености";
            this.buttonParameters.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonParameters.Click += new System.EventHandler(this.buttonParameters_Click);
            // 
            // tabHomeGroupOperations
            // 
            this.tabHomeGroupOperations.AutoSize = true;
            this.tabHomeGroupOperations.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tabHomeGroupOperationsButtonTeachers,
            this.tabHomeGroupOperationsButtonSubjects,
            this.tabHomeGroupOperationsButtonClasses,
            this.tabHomeGroupOperationsButtonClassrooms,
            this.tabHomeGroupOperationsButtonLessons});
            this.tabHomeGroupOperations.Name = "tabHomeGroupOperations";
            this.tabHomeGroupOperations.Text = "Операции с разписанието";
            // 
            // tabHomeGroupOperationsButtonTeachers
            // 
            this.tabHomeGroupOperationsButtonTeachers.Class = "RibbonBarButtonElement";
            this.tabHomeGroupOperationsButtonTeachers.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tabHomeGroupOperationsButtonTeachers.Image = global::ScheduleWorks.UI.Properties.Resources.teacherImage;
            this.tabHomeGroupOperationsButtonTeachers.Name = "tabHomeGroupOperationsButtonTeachers";
            this.tabHomeGroupOperationsButtonTeachers.Text = "Учители";
            this.tabHomeGroupOperationsButtonTeachers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tabHomeGroupOperationsButtonTeachers.Click += new System.EventHandler(this.buttonTeachersClick);
            // 
            // tabHomeGroupOperationsButtonSubjects
            // 
            this.tabHomeGroupOperationsButtonSubjects.Class = "RibbonBarButtonElement";
            this.tabHomeGroupOperationsButtonSubjects.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tabHomeGroupOperationsButtonSubjects.Image = global::ScheduleWorks.UI.Properties.Resources.subjectsImage;
            this.tabHomeGroupOperationsButtonSubjects.Name = "tabHomeGroupOperationsButtonSubjects";
            this.tabHomeGroupOperationsButtonSubjects.Text = "Предмети";
            this.tabHomeGroupOperationsButtonSubjects.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tabHomeGroupOperationsButtonSubjects.Click += new System.EventHandler(this.buttonSubjectsClick);
            // 
            // tabHomeGroupOperationsButtonClasses
            // 
            this.tabHomeGroupOperationsButtonClasses.Class = "RibbonBarButtonElement";
            this.tabHomeGroupOperationsButtonClasses.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tabHomeGroupOperationsButtonClasses.Image = global::ScheduleWorks.UI.Properties.Resources.classImage;
            this.tabHomeGroupOperationsButtonClasses.Name = "tabHomeGroupOperationsButtonClasses";
            this.tabHomeGroupOperationsButtonClasses.Text = "Класове";
            this.tabHomeGroupOperationsButtonClasses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tabHomeGroupOperationsButtonClasses.Click += new System.EventHandler(this.buttonClassesClick);
            // 
            // tabHomeGroupOperationsButtonClassrooms
            // 
            this.tabHomeGroupOperationsButtonClassrooms.Class = "RibbonBarButtonElement";
            this.tabHomeGroupOperationsButtonClassrooms.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tabHomeGroupOperationsButtonClassrooms.Image = global::ScheduleWorks.UI.Properties.Resources.classroomIcon;
            this.tabHomeGroupOperationsButtonClassrooms.Name = "tabHomeGroupOperationsButtonClassrooms";
            this.tabHomeGroupOperationsButtonClassrooms.Text = "Стаи";
            this.tabHomeGroupOperationsButtonClassrooms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tabHomeGroupOperationsButtonClassrooms.Click += new System.EventHandler(this.buttonClassroomsClick);
            // 
            // tabHomeGroupOperationsButtonLessons
            // 
            this.tabHomeGroupOperationsButtonLessons.Class = "RibbonBarButtonElement";
            this.tabHomeGroupOperationsButtonLessons.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tabHomeGroupOperationsButtonLessons.Image = global::ScheduleWorks.UI.Properties.Resources.blackboardImage;
            this.tabHomeGroupOperationsButtonLessons.Name = "tabHomeGroupOperationsButtonLessons";
            this.tabHomeGroupOperationsButtonLessons.Text = "Уроци";
            this.tabHomeGroupOperationsButtonLessons.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tabHomeGroupOperationsButtonLessons.Click += new System.EventHandler(this.buttonLessonsClick);
            // 
            // tabHomeGroupTimetable
            // 
            this.tabHomeGroupTimetable.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.buttonGenerateTimetable,
            this.printTheScheduleButton});
            this.tabHomeGroupTimetable.Name = "tabHomeGroupTimetable";
            this.tabHomeGroupTimetable.Text = "Разписание";
            // 
            // buttonGenerateTimetable
            // 
            this.buttonGenerateTimetable.Class = "RibbonBarButtonElement";
            this.buttonGenerateTimetable.Image = global::ScheduleWorks.UI.Properties.Resources.databaseGenerate;
            this.buttonGenerateTimetable.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonGenerateTimetable.Name = "buttonGenerateTimetable";
            this.buttonGenerateTimetable.Text = "Генерирай";
            this.buttonGenerateTimetable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonGenerateTimetable.Click += new System.EventHandler(this.buttonGenerateTimetable_Click);
            // 
            // printTheScheduleButton
            // 
            this.printTheScheduleButton.Class = "RibbonBarButtonElement";
            this.printTheScheduleButton.Image = global::ScheduleWorks.UI.Properties.Resources.printerImage;
            this.printTheScheduleButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.printTheScheduleButton.Name = "printTheScheduleButton";
            this.printTheScheduleButton.Text = "Експортиране за принтиране";
            this.printTheScheduleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.printTheScheduleButton.Click += new System.EventHandler(this.printTheScheduleButton_Click);
            // 
            // radRibbonBarGroup1
            // 
            this.radRibbonBarGroup1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radRibbonBarButtonGroup1});
            this.radRibbonBarGroup1.Name = "radRibbonBarGroup1";
            this.radRibbonBarGroup1.Text = "Изглед";
            // 
            // radRibbonBarButtonGroup1
            // 
            this.radRibbonBarButtonGroup1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.dropDownListTypeOfTimetablePreview,
            this.dropDownListElementOfTimetablePreview});
            this.radRibbonBarButtonGroup1.Name = "radRibbonBarButtonGroup1";
            this.radRibbonBarButtonGroup1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radRibbonBarButtonGroup1.Text = "radRibbonBarButtonGroup1";
            // 
            // dropDownListTypeOfTimetablePreview
            // 
            this.dropDownListTypeOfTimetablePreview.AutoCompleteAppend = null;
            this.dropDownListTypeOfTimetablePreview.AutoCompleteDataSource = null;
            this.dropDownListTypeOfTimetablePreview.AutoCompleteDisplayMember = null;
            this.dropDownListTypeOfTimetablePreview.AutoCompleteSuggest = null;
            this.dropDownListTypeOfTimetablePreview.AutoCompleteValueMember = null;
            this.dropDownListTypeOfTimetablePreview.DataSource = null;
            this.dropDownListTypeOfTimetablePreview.DefaultItemsCountInDropDown = 6;
            this.dropDownListTypeOfTimetablePreview.DefaultValue = null;
            this.dropDownListTypeOfTimetablePreview.DisplayMember = "";
            this.dropDownListTypeOfTimetablePreview.DropDownAnimationEasing = Telerik.WinControls.RadEasingType.InQuad;
            this.dropDownListTypeOfTimetablePreview.EditableElementText = "";
            this.dropDownListTypeOfTimetablePreview.EditorElement = this.dropDownListTypeOfTimetablePreview;
            this.dropDownListTypeOfTimetablePreview.EditorManager = null;
            this.dropDownListTypeOfTimetablePreview.Filter = null;
            this.dropDownListTypeOfTimetablePreview.FilterExpression = "";
            this.dropDownListTypeOfTimetablePreview.Focusable = true;
            this.dropDownListTypeOfTimetablePreview.FormatInfo = new System.Globalization.CultureInfo("bg-BG");
            this.dropDownListTypeOfTimetablePreview.FormatString = "";
            this.dropDownListTypeOfTimetablePreview.FormattingEnabled = true;
            this.dropDownListTypeOfTimetablePreview.ItemHeight = 16;
            this.dropDownListTypeOfTimetablePreview.MaxLength = 32767;
            this.dropDownListTypeOfTimetablePreview.MaxValue = null;
            this.dropDownListTypeOfTimetablePreview.MinValue = null;
            this.dropDownListTypeOfTimetablePreview.Name = "dropDownListTypeOfTimetablePreview";
            this.dropDownListTypeOfTimetablePreview.NullValue = null;
            this.dropDownListTypeOfTimetablePreview.OwnerOffset = 0;
            this.dropDownListTypeOfTimetablePreview.ShowImageInEditorArea = true;
            this.dropDownListTypeOfTimetablePreview.SortStyle = Telerik.WinControls.Enumerations.SortStyle.None;
            this.dropDownListTypeOfTimetablePreview.Value = null;
            this.dropDownListTypeOfTimetablePreview.ValueMember = "";
            this.dropDownListTypeOfTimetablePreview.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.dropDownListTypeOfTimetablePreview_SelectedIndexChanged);
            // 
            // dropDownListElementOfTimetablePreview
            // 
            this.dropDownListElementOfTimetablePreview.AutoCompleteAppend = null;
            this.dropDownListElementOfTimetablePreview.AutoCompleteDataSource = null;
            this.dropDownListElementOfTimetablePreview.AutoCompleteDisplayMember = null;
            this.dropDownListElementOfTimetablePreview.AutoCompleteSuggest = null;
            this.dropDownListElementOfTimetablePreview.AutoCompleteValueMember = null;
            this.dropDownListElementOfTimetablePreview.DataSource = null;
            this.dropDownListElementOfTimetablePreview.DefaultItemsCountInDropDown = 6;
            this.dropDownListElementOfTimetablePreview.DefaultValue = null;
            this.dropDownListElementOfTimetablePreview.DisplayMember = "";
            this.dropDownListElementOfTimetablePreview.DropDownAnimationEasing = Telerik.WinControls.RadEasingType.InQuad;
            this.dropDownListElementOfTimetablePreview.EditableElementText = "";
            this.dropDownListElementOfTimetablePreview.EditorElement = this.dropDownListElementOfTimetablePreview;
            this.dropDownListElementOfTimetablePreview.EditorManager = null;
            this.dropDownListElementOfTimetablePreview.Filter = null;
            this.dropDownListElementOfTimetablePreview.FilterExpression = "";
            this.dropDownListElementOfTimetablePreview.Focusable = true;
            this.dropDownListElementOfTimetablePreview.FormatInfo = new System.Globalization.CultureInfo("bg-BG");
            this.dropDownListElementOfTimetablePreview.FormatString = "";
            this.dropDownListElementOfTimetablePreview.FormattingEnabled = true;
            this.dropDownListElementOfTimetablePreview.ItemHeight = 16;
            this.dropDownListElementOfTimetablePreview.MaxLength = 32767;
            this.dropDownListElementOfTimetablePreview.MaxValue = null;
            this.dropDownListElementOfTimetablePreview.MinValue = null;
            this.dropDownListElementOfTimetablePreview.Name = "dropDownListElementOfTimetablePreview";
            this.dropDownListElementOfTimetablePreview.NullValue = null;
            this.dropDownListElementOfTimetablePreview.OwnerOffset = 0;
            this.dropDownListElementOfTimetablePreview.ShowImageInEditorArea = true;
            this.dropDownListElementOfTimetablePreview.SortStyle = Telerik.WinControls.Enumerations.SortStyle.None;
            this.dropDownListElementOfTimetablePreview.Value = null;
            this.dropDownListElementOfTimetablePreview.ValueMember = "";
            this.dropDownListElementOfTimetablePreview.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.dropDownListElementOfTimetablePreview_SelectedIndexChanged);
            // 
            // buttonNew
            // 
            this.buttonNew.Image = global::ScheduleWorks.UI.Properties.Resources.newFile;
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Text = "Нов";
            this.buttonNew.Click += new System.EventHandler(this.tabHomeGroupFilesButtonNewFile_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Image = global::ScheduleWorks.UI.Properties.Resources.openFile;
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Text = "Отвори";
            this.buttonOpen.Click += new System.EventHandler(this.tabHomeGroupFilesButtonOpenFile_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Image = global::ScheduleWorks.UI.Properties.Resources.saveFile;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Text = "Запази";
            this.buttonSave.Click += new System.EventHandler(this.tabHomeGroupFilesButtonSaveFile_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Image = global::ScheduleWorks.UI.Properties.Resources.helpIcon;
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Text = "Помощ";
            // 
            // buttonWizard
            // 
            this.buttonWizard.Image = global::ScheduleWorks.UI.Properties.Resources.wizardImage;
            this.buttonWizard.Name = "buttonWizard";
            this.buttonWizard.Text = "Помощник";
            this.buttonWizard.Click += new System.EventHandler(this.buttonHelperClick);
            // 
            // tabHelpGroupDocumentation
            // 
            this.tabHelpGroupDocumentation.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tabHelpGroupDocumentationButtonHelp});
            this.tabHelpGroupDocumentation.Name = "tabHelpGroupDocumentation";
            this.tabHelpGroupDocumentation.Text = "";
            // 
            // tabHelpGroupDocumentationButtonHelp
            // 
            this.tabHelpGroupDocumentationButtonHelp.Class = "RibbonBarButtonElement";
            this.tabHelpGroupDocumentationButtonHelp.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tabHelpGroupDocumentationButtonHelp.Image = global::ScheduleWorks.UI.Properties.Resources.helpIcon;
            this.tabHelpGroupDocumentationButtonHelp.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tabHelpGroupDocumentationButtonHelp.Name = "tabHelpGroupDocumentationButtonHelp";
            this.tabHelpGroupDocumentationButtonHelp.Text = "Документация";
            this.tabHelpGroupDocumentationButtonHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // radImageButtonElement8
            // 
            this.radImageButtonElement8.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.radImageButtonElement8.Image = global::ScheduleWorks.UI.Properties.Resources.classroomIcon;
            this.radImageButtonElement8.Name = "radImageButtonElement8";
            this.radImageButtonElement8.Text = "Стаи";
            this.radImageButtonElement8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // radButtonElement1
            // 
            this.radButtonElement1.Class = "RibbonBarButtonElement";
            this.radButtonElement1.Image = global::ScheduleWorks.UI.Properties.Resources.databaseGenerate;
            this.radButtonElement1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonElement1.Name = "radButtonElement1";
            this.radButtonElement1.Text = "Генерирай";
            this.radButtonElement1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // dockWindow
            // 
            this.dockWindow.ActiveWindow = this.na;
            this.dockWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dockWindow.BackgroundImage = global::ScheduleWorks.UI.Properties.Resources.ScheduleWorksHomeScreen;
            this.dockWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dockWindow.Controls.Add(this.documentContainer1);
            this.dockWindow.DocumentManager.DocumentInsertOrder = Telerik.WinControls.UI.Docking.DockWindowInsertOrder.InFront;
            this.dockWindow.IsCleanUpTarget = true;
            this.dockWindow.Location = new System.Drawing.Point(0, 154);
            this.dockWindow.MainDocumentContainer = this.documentContainer1;
            this.dockWindow.Name = "dockWindow";
            this.dockWindow.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.dockWindow.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.dockWindow.RootElement.Padding = new System.Windows.Forms.Padding(5);
            this.dockWindow.Size = new System.Drawing.Size(960, 367);
            this.dockWindow.SplitterWidth = 4;
            this.dockWindow.TabIndex = 1;
            this.dockWindow.TabStop = false;
            // 
            // na
            // 
            this.na.Controls.Add(this.homePicture);
            this.na.Location = new System.Drawing.Point(6, 30);
            this.na.Name = "na";
            this.na.Size = new System.Drawing.Size(938, 321);
            this.na.Text = "Начало";
            // 
            // homePicture
            // 
            this.homePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.homePicture.Image = global::ScheduleWorks.UI.Properties.Resources.ScheduleWorksHomeScreen;
            this.homePicture.ImageLocation = "";
            this.homePicture.Location = new System.Drawing.Point(271, 48);
            this.homePicture.Name = "homePicture";
            this.homePicture.Size = new System.Drawing.Size(403, 232);
            this.homePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.homePicture.TabIndex = 0;
            this.homePicture.TabStop = false;
            // 
            // documentContainer1
            // 
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Location = new System.Drawing.Point(5, 5);
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.Size = new System.Drawing.Size(950, 357);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 4;
            this.documentContainer1.TabIndex = 0;
            this.documentContainer1.TabStop = false;
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.Controls.Add(this.na);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(950, 357);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            // 
            // radDropDownButtonElement1
            // 
            this.radDropDownButtonElement1.ArrowButtonMinSize = new System.Drawing.Size(12, 12);
            this.radDropDownButtonElement1.DropDownDirection = Telerik.WinControls.UI.RadDirection.Down;
            this.radDropDownButtonElement1.ExpandArrowButton = false;
            this.radDropDownButtonElement1.Name = "radDropDownButtonElement1";
            this.radDropDownButtonElement1.Text = "radDropDownButtonElement1";
            this.radDropDownButtonElement1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 522);
            this.Controls.Add(this.dockWindow);
            this.Controls.Add(this.headerBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = null;
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "УПроГен 1.1";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.headerBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropDownListTypeOfTimetablePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropDownListElementOfTimetablePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockWindow)).EndInit();
            this.dockWindow.ResumeLayout(false);
            this.na.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRibbonBar headerBar;
        private Telerik.WinControls.UI.RibbonTab tabHome;
        private Telerik.WinControls.UI.RadRibbonBarGroup tabHomeGroupFiles;
        private Telerik.WinControls.UI.RadRibbonBarGroup tabHomeGroupTimetable;
        private Telerik.WinControls.UI.RadRibbonBarGroup tabHomeGroupOperations;
        private Telerik.WinControls.UI.RadRibbonBarGroup tabHomeGroupOthers;
        private Telerik.WinControls.UI.RadRibbonBarGroup tabSpecificationGroupHelper;
        private Telerik.WinControls.UI.RadRibbonBarGroup tabSpecificationsGroupDBOperations;
        private Telerik.WinControls.UI.RadRibbonBarGroup tabTimetableGroupGenerate;
        private Telerik.WinControls.UI.RadRibbonBarGroup tabTimetableGroupStatistics;
        private Telerik.WinControls.UI.RadRibbonBarGroup tabHelpGroupDocumentation;
        private Telerik.WinControls.UI.RadButtonElement tabHomeGroupFilesButtonNewFile;
        private Telerik.WinControls.UI.RadButtonElement tabHomeGroupFilesButtonOpenFile;
        private Telerik.WinControls.UI.RadButtonElement tabHomeGroupFilesButtonSaveFile;
        private Telerik.WinControls.UI.RadButtonElement tabHelpGroupDocumentationButtonHelp;
        private Telerik.WinControls.UI.RadButtonElement tabHomeGroupOperationsButtonClasses;
        private Telerik.WinControls.UI.RadButtonElement tabHomeGroupOperationsButtonClassrooms;
        private Telerik.WinControls.UI.RadButtonElement tabHomeGroupOperationsButtonSubjects;
        private Telerik.WinControls.UI.RadButtonElement tabHomeGroupOperationsButtonTeachers;
        private Telerik.WinControls.UI.RadButtonElement tabHomeGroupOperationsButtonLessons;
        private Telerik.WinControls.UI.RadButtonElement tabHomeGroupOthersButtonHelper;
        private Telerik.WinControls.UI.RadButtonElement radImageButtonElement8;
        private Telerik.WinControls.UI.RadButtonElement buttonGenerateTimetable;
        private Telerik.WinControls.UI.RadButtonElement radButtonElement1;
        private Telerik.WinControls.UI.RadButtonElement radButtonElement2;
        private Telerik.WinControls.UI.RadButtonElement buttonParameters;
        private Telerik.WinControls.UI.RadButtonElement printTheScheduleButton;
        private Telerik.WinControls.UI.RadMenuItem buttonNew;
        private Telerik.WinControls.UI.RadMenuItem buttonOpen;
        private Telerik.WinControls.UI.RadMenuItem buttonSave;
        private Telerik.WinControls.UI.RadMenuItem buttonHelp;
        private Telerik.WinControls.UI.RadMenuItem buttonWizard;
        private Telerik.WinControls.UI.Docking.RadDock dockWindow;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup1;
        private Telerik.WinControls.UI.RadDropDownButtonElement radDropDownButtonElement1;
        private Telerik.WinControls.UI.RadRibbonBarButtonGroup radRibbonBarButtonGroup1;
        private Telerik.WinControls.UI.RadDropDownListElement dropDownListTypeOfTimetablePreview;
        private Telerik.WinControls.UI.RadDropDownListElement dropDownListElementOfTimetablePreview;
        private Telerik.WinControls.UI.Docking.DocumentWindow na;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private System.Windows.Forms.PictureBox homePicture;
    }
}