namespace AVR_log.SetupForms
{
    partial class PublicSetup
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
            this.edUpdatePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edExportPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edTimer = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.eddbMySQL = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edhostMySQL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkStartUpdate = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnFolderSelectExport = new System.Windows.Forms.Button();
            this.btnFolderSelectUpdate = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edSortvl04 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edSortvl10 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbUserCanRenameFeeder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.edTimer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // edUpdatePath
            // 
            this.edUpdatePath.Location = new System.Drawing.Point(190, 136);
            this.edUpdatePath.Name = "edUpdatePath";
            this.edUpdatePath.Size = new System.Drawing.Size(273, 20);
            this.edUpdatePath.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Путь к папке с обновлениями";
            // 
            // edExportPath
            // 
            this.edExportPath.Location = new System.Drawing.Point(190, 110);
            this.edExportPath.Name = "edExportPath";
            this.edExportPath.Size = new System.Drawing.Size(273, 20);
            this.edExportPath.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Путь для экспорта Excel-файлов";
            // 
            // edTimer
            // 
            this.edTimer.Location = new System.Drawing.Point(249, 85);
            this.edTimer.Name = "edTimer";
            this.edTimer.Size = new System.Drawing.Size(65, 20);
            this.edTimer.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(231, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Таймер обновления данных в журнале (сек)";
            // 
            // eddbMySQL
            // 
            this.eddbMySQL.Location = new System.Drawing.Point(116, 58);
            this.eddbMySQL.Name = "eddbMySQL";
            this.eddbMySQL.Size = new System.Drawing.Size(198, 20);
            this.eddbMySQL.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Имя базы данных";
            // 
            // edhostMySQL
            // 
            this.edhostMySQL.Location = new System.Drawing.Point(116, 32);
            this.edhostMySQL.Name = "edhostMySQL";
            this.edhostMySQL.Size = new System.Drawing.Size(198, 20);
            this.edhostMySQL.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Адрес сервера";
            // 
            // checkStartUpdate
            // 
            this.checkStartUpdate.AutoSize = true;
            this.checkStartUpdate.Location = new System.Drawing.Point(12, 166);
            this.checkStartUpdate.Name = "checkStartUpdate";
            this.checkStartUpdate.Size = new System.Drawing.Size(271, 17);
            this.checkStartUpdate.TabIndex = 24;
            this.checkStartUpdate.Text = "Проверять обновления программы при запуске";
            this.checkStartUpdate.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Проверить обновления сейчас";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Неправильные настройки могут привести к неработоспособности программы!!!";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(320, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 21);
            this.button3.TabIndex = 27;
            this.button3.Text = "Проверить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(320, 58);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 21);
            this.button4.TabIndex = 28;
            this.button4.Text = "Проверить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnFolderSelectExport
            // 
            this.btnFolderSelectExport.Location = new System.Drawing.Point(463, 110);
            this.btnFolderSelectExport.Margin = new System.Windows.Forms.Padding(0);
            this.btnFolderSelectExport.Name = "btnFolderSelectExport";
            this.btnFolderSelectExport.Size = new System.Drawing.Size(24, 20);
            this.btnFolderSelectExport.TabIndex = 29;
            this.btnFolderSelectExport.Text = "...";
            this.btnFolderSelectExport.UseVisualStyleBackColor = true;
            this.btnFolderSelectExport.Click += new System.EventHandler(this.edFolderSelect1_Click);
            // 
            // btnFolderSelectUpdate
            // 
            this.btnFolderSelectUpdate.Location = new System.Drawing.Point(463, 136);
            this.btnFolderSelectUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnFolderSelectUpdate.Name = "btnFolderSelectUpdate";
            this.btnFolderSelectUpdate.Size = new System.Drawing.Size(24, 20);
            this.btnFolderSelectUpdate.TabIndex = 30;
            this.btnFolderSelectUpdate.Text = "...";
            this.btnFolderSelectUpdate.UseVisualStyleBackColor = true;
            this.btnFolderSelectUpdate.Click += new System.EventHandler(this.edFolderSelect1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edSortvl04);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.edSortvl10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 86);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки сортировки  объектов";
            // 
            // edSortvl04
            // 
            this.edSortvl04.Location = new System.Drawing.Point(414, 51);
            this.edSortvl04.Name = "edSortvl04";
            this.edSortvl04.Size = new System.Drawing.Size(86, 20);
            this.edSortvl04.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(405, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сортровка объектов ВЛ 0,4 кВ по тексту, находящемуся справа от подстроки";
            // 
            // edSortvl10
            // 
            this.edSortvl10.Location = new System.Drawing.Point(414, 25);
            this.edSortvl10.Name = "edSortvl10";
            this.edSortvl10.Size = new System.Drawing.Size(86, 20);
            this.edSortvl10.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Сортровка объектов ВЛ 10 кВ по тексту, находящемуся справа от подстроки";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 35);
            this.panel1.TabIndex = 32;
            // 
            // btn_save
            // 
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_save.Location = new System.Drawing.Point(283, 0);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(145, 35);
            this.btn_save.TabIndex = 24;
            this.btn_save.Text = "Сохранить и выйти";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Location = new System.Drawing.Point(428, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 35);
            this.button2.TabIndex = 25;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbUserCanRenameFeeder
            // 
            this.cbUserCanRenameFeeder.AutoSize = true;
            this.cbUserCanRenameFeeder.Location = new System.Drawing.Point(12, 281);
            this.cbUserCanRenameFeeder.Name = "cbUserCanRenameFeeder";
            this.cbUserCanRenameFeeder.Size = new System.Drawing.Size(364, 17);
            this.cbUserCanRenameFeeder.TabIndex = 33;
            this.cbUserCanRenameFeeder.Text = "Разрешить пользователю переименовывать объекты отключения";
            this.cbUserCanRenameFeeder.UseVisualStyleBackColor = true;
            // 
            // PublicSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 348);
            this.ControlBox = false;
            this.Controls.Add(this.cbUserCanRenameFeeder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFolderSelectUpdate);
            this.Controls.Add(this.btnFolderSelectExport);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkStartUpdate);
            this.Controls.Add(this.edUpdatePath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edExportPath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edTimer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.eddbMySQL);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.edhostMySQL);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PublicSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Общие настройки";
            ((System.ComponentModel.ISupportInitialize)(this.edTimer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox edUpdatePath;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox edExportPath;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown edTimer;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox eddbMySQL;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox edhostMySQL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.CheckBox checkStartUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnFolderSelectExport;
        private System.Windows.Forms.Button btnFolderSelectUpdate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox edSortvl04;
        public System.Windows.Forms.TextBox edSortvl10;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.CheckBox cbUserCanRenameFeeder;
    }
}