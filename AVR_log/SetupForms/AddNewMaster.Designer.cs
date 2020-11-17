namespace AVR_log.SetupForms
{
    partial class AddNewMaster
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
            this.label1 = new System.Windows.Forms.Label();
            this.edFIO = new System.Windows.Forms.TextBox();
            this.edTel = new System.Windows.Forms.MaskedTextBox();
            this.edDol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbRes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbPrinadl = new System.Windows.Forms.Label();
            this.cbOtherPrinandl = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия И.О.";
            // 
            // edFIO
            // 
            this.edFIO.Location = new System.Drawing.Point(93, 39);
            this.edFIO.MaxLength = 255;
            this.edFIO.Name = "edFIO";
            this.edFIO.Size = new System.Drawing.Size(189, 20);
            this.edFIO.TabIndex = 1;
            // 
            // edTel
            // 
            this.edTel.Location = new System.Drawing.Point(93, 91);
            this.edTel.Mask = "00000000000";
            this.edTel.Name = "edTel";
            this.edTel.PromptChar = ' ';
            this.edTel.Size = new System.Drawing.Size(94, 20);
            this.edTel.TabIndex = 4;
            this.edTel.Click += new System.EventHandler(this.edTel_Click);
            // 
            // edDol
            // 
            this.edDol.Location = new System.Drawing.Point(93, 65);
            this.edDol.MaxLength = 255;
            this.edDol.Name = "edDol";
            this.edDol.Size = new System.Drawing.Size(189, 20);
            this.edDol.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Должность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Телефон";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(288, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "*Пример: Иванов И.И.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(288, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "*Пример: электромонтер";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(193, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "*Пример: 89995550100";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(219, 146);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(145, 29);
            this.btn_save.TabIndex = 20;
            this.btn_save.Text = "Сохранить и выйти";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(370, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 29);
            this.button2.TabIndex = 21;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbRes
            // 
            this.cbRes.DisplayMember = "0";
            this.cbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRes.FormattingEnabled = true;
            this.cbRes.Location = new System.Drawing.Point(252, 6);
            this.cbRes.Name = "cbRes";
            this.cbRes.Size = new System.Drawing.Size(217, 21);
            this.cbRes.TabIndex = 23;
            this.cbRes.SelectionChangeCommitted += new System.EventHandler(this.cbRes_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "РЭС";
            // 
            // cbCompany
            // 
            this.cbCompany.DisplayMember = "0";
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(41, 6);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(174, 21);
            this.cbCompany.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "ПО";
            // 
            // lbPrinadl
            // 
            this.lbPrinadl.AutoSize = true;
            this.lbPrinadl.Location = new System.Drawing.Point(3, 121);
            this.lbPrinadl.Name = "lbPrinadl";
            this.lbPrinadl.Size = new System.Drawing.Size(97, 13);
            this.lbPrinadl.TabIndex = 26;
            this.lbPrinadl.Text = "Принадлежность:";
            this.lbPrinadl.Visible = false;
            // 
            // cbOtherPrinandl
            // 
            this.cbOtherPrinandl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOtherPrinandl.FormattingEnabled = true;
            this.cbOtherPrinandl.Location = new System.Drawing.Point(106, 118);
            this.cbOtherPrinandl.Name = "cbOtherPrinandl";
            this.cbOtherPrinandl.Size = new System.Drawing.Size(363, 21);
            this.cbOtherPrinandl.TabIndex = 27;
            this.cbOtherPrinandl.Visible = false;
            // 
            // AddNewMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 187);
            this.ControlBox = false;
            this.Controls.Add(this.cbOtherPrinandl);
            this.Controls.Add(this.lbPrinadl);
            this.Controls.Add(this.cbRes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edTel);
            this.Controls.Add(this.edDol);
            this.Controls.Add(this.edFIO);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddNewMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить нового работника";
            this.Shown += new System.EventHandler(this.AddNewMaster_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.MaskedTextBox edTel;
        public System.Windows.Forms.TextBox edDol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox cbRes;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cbCompany;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox edFIO;
        public System.Windows.Forms.Label lbPrinadl;
        public System.Windows.Forms.ComboBox cbOtherPrinandl;
    }
}