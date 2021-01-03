namespace LIBRARY.Forms
{
    partial class Profile
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Birthday = new System.Windows.Forms.DateTimePicker();
            this.Password = new DevExpress.XtraEditors.TextEdit();
            this.Username = new DevExpress.XtraEditors.TextEdit();
            this.PhoneNumber = new DevExpress.XtraEditors.TextEdit();
            this.Fullname = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fullname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(220, 33);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Manager Profile";
            // 
            // windowsUIButtonPanel1
            // 
            windowsUIButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions1.SvgImage")));
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Edit", false, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Edit your profile", -1, true, null, true, false, true, "edit", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Close", false, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Close", -1, true, null, true, false, true, "close", -1, false)});
            this.windowsUIButtonPanel1.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.windowsUIButtonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(0, 222);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(386, 46);
            this.windowsUIButtonPanel1.TabIndex = 1;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.UseButtonBackgroundImages = false;
            this.windowsUIButtonPanel1.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanel1_ButtonClick);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Birthday);
            this.layoutControl1.Controls.Add(this.Password);
            this.layoutControl1.Controls.Add(this.Username);
            this.layoutControl1.Controls.Add(this.PhoneNumber);
            this.layoutControl1.Controls.Add(this.Fullname);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 33);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(386, 189);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Birthday
            // 
            this.Birthday.Enabled = false;
            this.Birthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Birthday.Location = new System.Drawing.Point(106, 45);
            this.Birthday.Name = "Birthday";
            this.Birthday.Size = new System.Drawing.Size(268, 20);
            this.Birthday.TabIndex = 9;
            // 
            // Password
            // 
            this.Password.Enabled = false;
            this.Password.Location = new System.Drawing.Point(106, 147);
            this.Password.Name = "Password";
            this.Password.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Password.Properties.Appearance.Options.UseBackColor = true;
            this.Password.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.Password.Properties.UseSystemPasswordChar = true;
            this.Password.Size = new System.Drawing.Size(268, 20);
            this.Password.StyleController = this.layoutControl1;
            this.Password.TabIndex = 8;
            // 
            // Username
            // 
            this.Username.Enabled = false;
            this.Username.Location = new System.Drawing.Point(106, 113);
            this.Username.Name = "Username";
            this.Username.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Username.Properties.Appearance.Options.UseBackColor = true;
            this.Username.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.Username.Size = new System.Drawing.Size(268, 20);
            this.Username.StyleController = this.layoutControl1;
            this.Username.TabIndex = 7;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.Enabled = false;
            this.PhoneNumber.Location = new System.Drawing.Point(106, 79);
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.PhoneNumber.Properties.Appearance.Options.UseBackColor = true;
            this.PhoneNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.PhoneNumber.Size = new System.Drawing.Size(268, 20);
            this.PhoneNumber.StyleController = this.layoutControl1;
            this.PhoneNumber.TabIndex = 6;
            this.PhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PhoneNumber_KeyPress);
            // 
            // Fullname
            // 
            this.Fullname.Enabled = false;
            this.Fullname.Location = new System.Drawing.Point(106, 12);
            this.Fullname.Name = "Fullname";
            this.Fullname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Fullname.Properties.Appearance.Options.UseBackColor = true;
            this.Fullname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.Fullname.Size = new System.Drawing.Size(268, 20);
            this.Fullname.StyleController = this.layoutControl1;
            this.Fullname.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Root.AppearanceItemCaption.Options.UseFont = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem2});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 100D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1});
            rowDefinition1.Height = 100D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition2.Height = 100D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition3.Height = 100D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition4.Height = 100D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition5.Height = 100D;
            rowDefinition5.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3,
            rowDefinition4,
            rowDefinition5});
            this.Root.Size = new System.Drawing.Size(386, 189);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Fullname;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(366, 33);
            this.layoutControlItem1.Text = "Full name";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.PhoneNumber;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 67);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem3.Size = new System.Drawing.Size(366, 34);
            this.layoutControlItem3.Text = "Phone number";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.Username;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 101);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem4.Size = new System.Drawing.Size(366, 34);
            this.layoutControlItem4.Text = "Username";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.Password;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 135);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsTableLayoutItem.RowIndex = 4;
            this.layoutControlItem5.Size = new System.Drawing.Size(366, 34);
            this.layoutControlItem5.Text = "Password";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.Birthday;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 33);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(366, 34);
            this.layoutControlItem2.Text = "Birthday";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(82, 13);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 268);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.windowsUIButtonPanel1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fullname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        protected internal DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
        protected internal DevExpress.XtraEditors.TextEdit Password;
        protected internal DevExpress.XtraEditors.TextEdit Username;
        protected internal DevExpress.XtraEditors.TextEdit PhoneNumber;
        protected internal DevExpress.XtraEditors.TextEdit Fullname;
        protected internal System.Windows.Forms.DateTimePicker Birthday;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}