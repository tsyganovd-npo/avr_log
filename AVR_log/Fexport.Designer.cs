namespace AVR_log
{
    partial class Fexport
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
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.pb = new System.Windows.Forms.ProgressBar();
			this.button2 = new System.Windows.Forms.Button();
			this.FormsControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.cbFormrVersion = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.eDate = new System.Windows.Forms.DateTimePicker();
			this.eTime = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.ePath = new System.Windows.Forms.TextBox();
			this.cbOpenFile = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			this.FormsControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.Description = "Укажите папку, куда следует экспортировать форму";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.pb);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 193);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(414, 50);
			this.panel1.TabIndex = 2;
			// 
			// button3
			// 
			this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button3.Location = new System.Drawing.Point(316, 27);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "Отмена";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// pb
			// 
			this.pb.Dock = System.Windows.Forms.DockStyle.Top;
			this.pb.Location = new System.Drawing.Point(0, 0);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(414, 23);
			this.pb.TabIndex = 4;
			this.pb.Visible = false;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(1, 27);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Сохранить";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// FormsControl
			// 
			this.FormsControl.Controls.Add(this.tabPage1);
			this.FormsControl.Controls.Add(this.tabPage2);
			this.FormsControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.FormsControl.Location = new System.Drawing.Point(3, 3);
			this.FormsControl.Name = "FormsControl";
			this.FormsControl.SelectedIndex = 0;
			this.FormsControl.Size = new System.Drawing.Size(414, 114);
			this.FormsControl.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.cbFormrVersion);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(406, 88);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Форма 4";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Версия";
			// 
			// cbFormrVersion
			// 
			this.cbFormrVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFormrVersion.FormattingEnabled = true;
			this.cbFormrVersion.Items.AddRange(new object[] {
            "2016 года",
            "2020 года"});
			this.cbFormrVersion.Location = new System.Drawing.Point(59, 5);
			this.cbFormrVersion.Name = "cbFormrVersion";
			this.cbFormrVersion.Size = new System.Drawing.Size(121, 21);
			this.cbFormrVersion.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.eDate);
			this.groupBox1.Controls.Add(this.eTime);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(3, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(400, 53);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Параметры";
			// 
			// eDate
			// 
			this.eDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.eDate.Location = new System.Drawing.Point(235, 23);
			this.eDate.Name = "eDate";
			this.eDate.Size = new System.Drawing.Size(95, 20);
			this.eDate.TabIndex = 3;
			// 
			// eTime
			// 
			this.eTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.eTime.FormatString = "t";
			this.eTime.FormattingEnabled = true;
			this.eTime.Location = new System.Drawing.Point(151, 22);
			this.eTime.Name = "eTime";
			this.eTime.Size = new System.Drawing.Size(68, 21);
			this.eTime.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Данные по состоянию на:";
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(406, 88);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Форма 15";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(365, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(28, 20);
			this.button1.TabIndex = 1;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// ePath
			// 
			this.ePath.Location = new System.Drawing.Point(9, 19);
			this.ePath.Name = "ePath";
			this.ePath.Size = new System.Drawing.Size(350, 20);
			this.ePath.TabIndex = 0;
			// 
			// cbOpenFile
			// 
			this.cbOpenFile.AutoSize = true;
			this.cbOpenFile.Checked = true;
			this.cbOpenFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbOpenFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbOpenFile.Location = new System.Drawing.Point(3, 164);
			this.cbOpenFile.Name = "cbOpenFile";
			this.cbOpenFile.Padding = new System.Windows.Forms.Padding(10, 3, 0, 0);
			this.cbOpenFile.Size = new System.Drawing.Size(414, 20);
			this.cbOpenFile.TabIndex = 3;
			this.cbOpenFile.Text = "Открыть файл после успешного экспорта";
			this.cbOpenFile.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.ePath);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(3, 117);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(414, 47);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Путь для экспорта";
			// 
			// Fexport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 246);
			this.Controls.Add(this.cbOpenFile);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.FormsControl);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Fexport";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Экспорт в Excel";
			this.panel1.ResumeLayout(false);
			this.FormsControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox eTime;
        public System.Windows.Forms.DateTimePicker eDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbOpenFile;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox ePath;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TabControl FormsControl;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.ComboBox cbFormrVersion;
	}
}