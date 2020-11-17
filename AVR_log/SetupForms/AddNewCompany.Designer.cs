namespace AVR_log.SetupForms
{
    partial class AddNewCompany
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
            this.edCompany = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.edFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // edCompany
            // 
            this.edCompany.Location = new System.Drawing.Point(140, 6);
            this.edCompany.MaxLength = 255;
            this.edCompany.Name = "edCompany";
            this.edCompany.Size = new System.Drawing.Size(223, 20);
            this.edCompany.TabIndex = 45;
            this.edCompany.TextChanged += new System.EventHandler(this.edCompany_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Наименование ПО";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(208, 76);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(145, 29);
            this.btn_save.TabIndex = 42;
            this.btn_save.Text = "Сохранить и выйти";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(359, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 29);
            this.button2.TabIndex = 43;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // edFullName
            // 
            this.edFullName.Location = new System.Drawing.Point(140, 32);
            this.edFullName.MaxLength = 255;
            this.edFullName.Name = "edFullName";
            this.edFullName.Size = new System.Drawing.Size(316, 20);
            this.edFullName.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Полное наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(146, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "*Образец:\"Пензаэнерго\" - Нижнеломовское ПО";
            // 
            // AddNewCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 110);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edFullName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edCompany);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddNewCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить новое ПО";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox edFullName;
        public System.Windows.Forms.TextBox edCompany;
    }
}