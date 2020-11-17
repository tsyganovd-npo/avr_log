namespace AVR_log.SetupForms
{
    partial class SelectMasterInBase
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
            this.btn_save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbMasters = new System.Windows.Forms.ComboBox();
            this.cbRes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewMaster = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(150, 64);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(201, 29);
            this.btn_save.TabIndex = 40;
            this.btn_save.Text = "Выбрать руководителя бригады";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(357, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 29);
            this.button2.TabIndex = 41;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbMasters
            // 
            this.cbMasters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMasters.FormattingEnabled = true;
            this.cbMasters.Location = new System.Drawing.Point(39, 37);
            this.cbMasters.Name = "cbMasters";
            this.cbMasters.Size = new System.Drawing.Size(174, 21);
            this.cbMasters.TabIndex = 39;
            // 
            // cbRes
            // 
            this.cbRes.DisplayMember = "0";
            this.cbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRes.FormattingEnabled = true;
            this.cbRes.Location = new System.Drawing.Point(250, 10);
            this.cbRes.Name = "cbRes";
            this.cbRes.Size = new System.Drawing.Size(174, 21);
            this.cbRes.TabIndex = 36;
            this.cbRes.SelectionChangeCommitted += new System.EventHandler(this.cbRes_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "РЭС";
            // 
            // cbCompany
            // 
            this.cbCompany.DisplayMember = "0";
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(39, 10);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(174, 21);
            this.cbCompany.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "ПО";
            // 
            // btnAddNewMaster
            // 
            this.btnAddNewMaster.Location = new System.Drawing.Point(219, 33);
            this.btnAddNewMaster.Name = "btnAddNewMaster";
            this.btnAddNewMaster.Size = new System.Drawing.Size(105, 26);
            this.btnAddNewMaster.TabIndex = 42;
            this.btnAddNewMaster.Text = "Добавить нового";
            this.btnAddNewMaster.UseVisualStyleBackColor = true;
            this.btnAddNewMaster.Visible = false;
            this.btnAddNewMaster.Click += new System.EventHandler(this.btnAddNewMaster_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "ФИО";
            // 
            // SelectMasterInBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 100);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewMaster);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbMasters);
            this.Controls.Add(this.cbRes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SelectMasterInBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите работника";
            this.Shown += new System.EventHandler(this.SelectMasterInBase_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox cbMasters;
        public System.Windows.Forms.ComboBox cbRes;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbCompany;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnAddNewMaster;
        private System.Windows.Forms.Label label3;
    }
}