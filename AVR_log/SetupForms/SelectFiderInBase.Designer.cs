namespace AVR_log.SetupForms
{
    partial class SelectFiderInBase
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFider = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbFilter = new System.Windows.Forms.Label();
            this.edFilter = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cbTypeVL = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbRes
            // 
            this.cbRes.DisplayMember = "0";
            this.cbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRes.FormattingEnabled = true;
            this.cbRes.Location = new System.Drawing.Point(249, 12);
            this.cbRes.Name = "cbRes";
            this.cbRes.Size = new System.Drawing.Size(174, 21);
            this.cbRes.TabIndex = 26;
            this.cbRes.SelectedIndexChanged += new System.EventHandler(this.cbRes_SelectedIndexChanged);
            this.cbRes.SelectionChangeCommitted += new System.EventHandler(this.cbRes_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "РЭС";
            // 
            // cbCompany
            // 
            this.cbCompany.DisplayMember = "0";
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(38, 12);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(174, 21);
            this.cbCompany.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "ПО";
            // 
            // cbFider
            // 
            this.cbFider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFider.FormattingEnabled = true;
            this.cbFider.Location = new System.Drawing.Point(12, 62);
            this.cbFider.Name = "cbFider";
            this.cbFider.Size = new System.Drawing.Size(530, 21);
            this.cbFider.TabIndex = 32;
            this.cbFider.SelectionChangeCommitted += new System.EventHandler(this.cbFider_SelectionChangeCommitted);
            this.cbFider.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFider_KeyPress);
            this.cbFider.Leave += new System.EventHandler(this.cbFider_Leave);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(293, 89);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(145, 29);
            this.btn_save.TabIndex = 33;
            this.btn_save.Text = "Выбрать объект";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(444, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 29);
            this.button2.TabIndex = 34;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Location = new System.Drawing.Point(142, 46);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(50, 13);
            this.lbFilter.TabIndex = 36;
            this.lbFilter.Text = "Фильтр:";
            this.lbFilter.Visible = false;
            // 
            // edFilter
            // 
            this.edFilter.Location = new System.Drawing.Point(202, 43);
            this.edFilter.Name = "edFilter";
            this.edFilter.Size = new System.Drawing.Size(305, 20);
            this.edFilter.TabIndex = 35;
            this.edFilter.Visible = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label31.Location = new System.Drawing.Point(12, 41);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(44, 13);
            this.label31.TabIndex = 38;
            this.label31.Text = "Тип ВЛ";
            // 
            // cbTypeVL
            // 
            this.cbTypeVL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeVL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbTypeVL.FormattingEnabled = true;
            this.cbTypeVL.Location = new System.Drawing.Point(62, 38);
            this.cbTypeVL.Name = "cbTypeVL";
            this.cbTypeVL.Size = new System.Drawing.Size(78, 21);
            this.cbTypeVL.TabIndex = 37;
            this.cbTypeVL.SelectedIndexChanged += new System.EventHandler(this.cbTypeVL_SelectedIndexChanged);
            // 
            // SelectFiderInBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 137);
            this.ControlBox = false;
            this.Controls.Add(this.label31);
            this.Controls.Add(this.cbTypeVL);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.edFilter);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbFider);
            this.Controls.Add(this.cbRes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SelectFiderInBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите объект";
            this.Shown += new System.EventHandler(this.SelectFiderInBase_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbCompany;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbRes;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox cbFider;
        public System.Windows.Forms.Label lbFilter;
        public System.Windows.Forms.TextBox edFilter;
        private System.Windows.Forms.Label label31;
        public System.Windows.Forms.ComboBox cbTypeVL;
    }
}