namespace ScheduleWorks.UI
{
    partial class AddOrEditTeacherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrEditTeacherForm));
            this.labelGender = new Telerik.WinControls.UI.RadLabel();
            this.radioButtonMale = new Telerik.WinControls.UI.RadRadioButton();
            this.radioButtonFemale = new Telerik.WinControls.UI.RadRadioButton();
            this.groupboxColor = new Telerik.WinControls.UI.RadGroupBox();
            this.groupboxColorButtonChangeColor = new Telerik.WinControls.UI.RadButton();
            this.groupboxColorPanelColor = new Telerik.WinControls.UI.RadPanel();
            this.labelName = new Telerik.WinControls.UI.RadLabel();
            this.textboxName = new Telerik.WinControls.UI.RadTextBox();
            this.textboxShortName = new Telerik.WinControls.UI.RadTextBox();
            this.labelShortName = new Telerik.WinControls.UI.RadLabel();
            this.buttonFinish = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.labelGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonMale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonFemale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxColor)).BeginInit();
            this.groupboxColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxColorButtonChangeColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxColorPanelColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGender
            // 
            this.labelGender.Location = new System.Drawing.Point(12, 62);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(29, 18);
            this.labelGender.TabIndex = 4;
            this.labelGender.Text = "Пол:";
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.Location = new System.Drawing.Point(86, 62);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(47, 18);
            this.radioButtonMale.TabIndex = 3;
            this.radioButtonMale.Text = "Мъж";
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.Location = new System.Drawing.Point(139, 62);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(57, 18);
            this.radioButtonFemale.TabIndex = 4;
            this.radioButtonFemale.Text = "Жена";
            // 
            // groupboxColor
            // 
            this.groupboxColor.Controls.Add(this.groupboxColorButtonChangeColor);
            this.groupboxColor.Controls.Add(this.groupboxColorPanelColor);
            this.groupboxColor.FooterImageIndex = -1;
            this.groupboxColor.FooterImageKey = "";
            this.groupboxColor.HeaderImageIndex = -1;
            this.groupboxColor.HeaderImageKey = "";
            this.groupboxColor.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.groupboxColor.HeaderText = "Цвят";
            this.groupboxColor.Location = new System.Drawing.Point(12, 86);
            this.groupboxColor.Name = "groupboxColor";
            this.groupboxColor.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.groupboxColor.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.groupboxColor.Size = new System.Drawing.Size(330, 100);
            this.groupboxColor.TabIndex = 5;
            this.groupboxColor.Text = "Цвят";
            // 
            // groupboxColorButtonChangeColor
            // 
            this.groupboxColorButtonChangeColor.Location = new System.Drawing.Point(190, 24);
            this.groupboxColorButtonChangeColor.Name = "groupboxColorButtonChangeColor";
            this.groupboxColorButtonChangeColor.Size = new System.Drawing.Size(130, 24);
            this.groupboxColorButtonChangeColor.TabIndex = 5;
            this.groupboxColorButtonChangeColor.Text = "Смяна на цвета";
            this.groupboxColorButtonChangeColor.Click += new System.EventHandler(this.groupboxColorButtonChangeColorClick);
            // 
            // groupboxColorPanelColor
            // 
            this.groupboxColorPanelColor.BackColor = System.Drawing.Color.White;
            this.groupboxColorPanelColor.Location = new System.Drawing.Point(13, 24);
            this.groupboxColorPanelColor.Name = "groupboxColorPanelColor";
            this.groupboxColorPanelColor.Size = new System.Drawing.Size(171, 63);
            this.groupboxColorPanelColor.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(12, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(31, 18);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Име:";
            // 
            // textboxName
            // 
            this.textboxName.Location = new System.Drawing.Point(86, 10);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(200, 20);
            this.textboxName.TabIndex = 1;
            this.textboxName.TabStop = false;
            this.textboxName.TextChanged += new System.EventHandler(this.textboxNameTextChanged);
            // 
            // textboxShortName
            // 
            this.textboxShortName.Location = new System.Drawing.Point(86, 36);
            this.textboxShortName.Name = "textboxShortName";
            this.textboxShortName.Size = new System.Drawing.Size(100, 20);
            this.textboxShortName.TabIndex = 2;
            this.textboxShortName.TabStop = false;
            // 
            // labelShortName
            // 
            this.labelShortName.Location = new System.Drawing.Point(12, 37);
            this.labelShortName.Name = "labelShortName";
            this.labelShortName.Size = new System.Drawing.Size(68, 18);
            this.labelShortName.TabIndex = 7;
            this.labelShortName.Text = "Кратко име:";
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(212, 192);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(130, 24);
            this.buttonFinish.TabIndex = 9;
            this.buttonFinish.Text = "Готово";
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinishClick);
            // 
            // AddOrEditTeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 221);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.radioButtonFemale);
            this.Controls.Add(this.groupboxColor);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.radioButtonMale);
            this.Controls.Add(this.textboxName);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.textboxShortName);
            this.Controls.Add(this.labelShortName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.Name = "AddOrEditTeacherForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(362, 255);
            this.Text = "AddOrEditTeacher";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.labelGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonMale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonFemale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxColor)).EndInit();
            this.groupboxColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxColorButtonChangeColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxColorPanelColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel labelGender;
        private Telerik.WinControls.UI.RadRadioButton radioButtonMale;
        private Telerik.WinControls.UI.RadRadioButton radioButtonFemale;
        private Telerik.WinControls.UI.RadGroupBox groupboxColor;
        private Telerik.WinControls.UI.RadButton groupboxColorButtonChangeColor;
        private Telerik.WinControls.UI.RadPanel groupboxColorPanelColor;
        private Telerik.WinControls.UI.RadLabel labelName;
        private Telerik.WinControls.UI.RadTextBox textboxName;
        private Telerik.WinControls.UI.RadTextBox textboxShortName;
        private Telerik.WinControls.UI.RadLabel labelShortName;
        private Telerik.WinControls.UI.RadButton buttonFinish;
    }
}
