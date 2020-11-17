namespace AVR_log.SetupForms
{
    partial class AddNewUser
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
            this.cbRes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.edPass1 = new System.Windows.Forms.TextBox();
            this.edUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edPass2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDrant_x = new System.Windows.Forms.RadioButton();
            this.rbDrant_r = new System.Windows.Forms.RadioButton();
            this.rbDrant_w = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbRes
            // 
            this.cbRes.DisplayMember = "0";
            this.cbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRes.FormattingEnabled = true;
            this.cbRes.Location = new System.Drawing.Point(253, 12);
            this.cbRes.Name = "cbRes";
            this.cbRes.Size = new System.Drawing.Size(174, 21);
            this.cbRes.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "РЭС";
            // 
            // cbCompany
            // 
            this.cbCompany.DisplayMember = "0";
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(42, 12);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(174, 21);
            this.cbCompany.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "ПО";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(173, 149);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(145, 29);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Сохранить и выйти";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(324, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Пароль";
            // 
            // edPass1
            // 
            this.edPass1.Location = new System.Drawing.Point(100, 92);
            this.edPass1.MaxLength = 255;
            this.edPass1.Name = "edPass1";
            this.edPass1.PasswordChar = '*';
            this.edPass1.Size = new System.Drawing.Size(148, 20);
            this.edPass1.TabIndex = 5;
            // 
            // edUserName
            // 
            this.edUserName.Location = new System.Drawing.Point(100, 66);
            this.edUserName.MaxLength = 255;
            this.edUserName.Name = "edUserName";
            this.edUserName.Size = new System.Drawing.Size(148, 20);
            this.edUserName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Пользователь";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Подтверждение";
            // 
            // edPass2
            // 
            this.edPass2.Location = new System.Drawing.Point(100, 118);
            this.edPass2.MaxLength = 255;
            this.edPass2.Name = "edPass2";
            this.edPass2.PasswordChar = '*';
            this.edPass2.Size = new System.Drawing.Size(148, 20);
            this.edPass2.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDrant_x);
            this.groupBox1.Controls.Add(this.rbDrant_r);
            this.groupBox1.Controls.Add(this.rbDrant_w);
            this.groupBox1.Location = new System.Drawing.Point(254, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 83);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Права пользователя";
            // 
            // rbDrant_x
            // 
            this.rbDrant_x.AutoSize = true;
            this.rbDrant_x.Location = new System.Drawing.Point(6, 57);
            this.rbDrant_x.Name = "rbDrant_x";
            this.rbDrant_x.Size = new System.Drawing.Size(77, 17);
            this.rbDrant_x.TabIndex = 2;
            this.rbDrant_x.Text = "Все права";
            this.rbDrant_x.UseVisualStyleBackColor = true;
            // 
            // rbDrant_r
            // 
            this.rbDrant_r.AutoSize = true;
            this.rbDrant_r.Location = new System.Drawing.Point(6, 38);
            this.rbDrant_r.Name = "rbDrant_r";
            this.rbDrant_r.Size = new System.Drawing.Size(99, 17);
            this.rbDrant_r.TabIndex = 1;
            this.rbDrant_r.Text = "Только чтение";
            this.rbDrant_r.UseVisualStyleBackColor = true;
            // 
            // rbDrant_w
            // 
            this.rbDrant_w.AutoSize = true;
            this.rbDrant_w.Checked = true;
            this.rbDrant_w.Location = new System.Drawing.Point(6, 19);
            this.rbDrant_w.Name = "rbDrant_w";
            this.rbDrant_w.Size = new System.Drawing.Size(137, 17);
            this.rbDrant_w.TabIndex = 0;
            this.rbDrant_w.TabStop = true;
            this.rbDrant_w.Text = "Создание\\Изменение";
            this.rbDrant_w.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(253, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(129, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Без привязки к РЭС";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "C";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 184);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edPass2);
            this.Controls.Add(this.cbRes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edPass1);
            this.Controls.Add(this.edUserName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить нового пользователя";
            this.Shown += new System.EventHandler(this.AddNewUser_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbRes;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cbCompany;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox edPass1;
        private System.Windows.Forms.TextBox edUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox edPass2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rbDrant_w;
        public System.Windows.Forms.RadioButton rbDrant_r;
        public System.Windows.Forms.RadioButton rbDrant_x;
        public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
    }
}