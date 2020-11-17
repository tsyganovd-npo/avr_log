namespace AVR_log.SetupForms
{
    partial class AddNewFiderInBase
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
			this.btn_save = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.TP = new System.Windows.Forms.NumericUpDown();
			this.SZO = new System.Windows.Forms.NumericUpDown();
			this.Population = new System.Windows.Forms.NumericUpDown();
			this.NP = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.DotPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.l1 = new System.Windows.Forms.TextBox();
			this.p1 = new System.Windows.Forms.TextBox();
			this.p2 = new System.Windows.Forms.TextBox();
			this.p3 = new System.Windows.Forms.ComboBox();
			this.p4 = new System.Windows.Forms.TextBox();
			this.edFiderName = new System.Windows.Forms.TextBox();
			this.ldot = new System.Windows.Forms.Label();
			this.HidentLabel = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.cbTypeVL = new System.Windows.Forms.ComboBox();
			this.P_load_z = new System.Windows.Forms.NumericUpDown();
			this.P_load_l = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SZO)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Population)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NP)).BeginInit();
			this.DotPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.P_load_z)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.P_load_l)).BeginInit();
			this.SuspendLayout();
			// 
			// cbRes
			// 
			this.cbRes.DisplayMember = "0";
			this.cbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRes.FormattingEnabled = true;
			this.cbRes.Location = new System.Drawing.Point(248, 12);
			this.cbRes.Name = "cbRes";
			this.cbRes.Size = new System.Drawing.Size(174, 21);
			this.cbRes.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(219, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "РЭС";
			// 
			// cbCompany
			// 
			this.cbCompany.DisplayMember = "0";
			this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCompany.FormattingEnabled = true;
			this.cbCompany.Location = new System.Drawing.Point(37, 12);
			this.cbCompany.Name = "cbCompany";
			this.cbCompany.Size = new System.Drawing.Size(174, 21);
			this.cbCompany.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "ПО";
			// 
			// btn_save
			// 
			this.btn_save.Location = new System.Drawing.Point(294, 213);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(145, 28);
			this.btn_save.TabIndex = 18;
			this.btn_save.Text = "Сохранить и выйти";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(445, 213);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(99, 29);
			this.button2.TabIndex = 19;
			this.button2.Text = "Отмена";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox2.Controls.Add(this.P_load_z);
			this.groupBox2.Controls.Add(this.P_load_l);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.TP);
			this.groupBox2.Controls.Add(this.SZO);
			this.groupBox2.Controls.Add(this.Population);
			this.groupBox2.Controls.Add(this.NP);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(11, 121);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(533, 86);
			this.groupBox2.TabIndex = 23;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Количество отключенных";
			// 
			// TP
			// 
			this.TP.Location = new System.Drawing.Point(404, 31);
			this.TP.Name = "TP";
			this.TP.Size = new System.Drawing.Size(92, 20);
			this.TP.TabIndex = 3;
			// 
			// SZO
			// 
			this.SZO.Location = new System.Drawing.Point(404, 14);
			this.SZO.Name = "SZO";
			this.SZO.Size = new System.Drawing.Size(92, 20);
			this.SZO.TabIndex = 2;
			// 
			// Population
			// 
			this.Population.Location = new System.Drawing.Point(124, 31);
			this.Population.Name = "Population";
			this.Population.Size = new System.Drawing.Size(92, 20);
			this.Population.TabIndex = 1;
			// 
			// NP
			// 
			this.NP.Location = new System.Drawing.Point(124, 14);
			this.NP.Name = "NP";
			this.NP.Size = new System.Drawing.Size(92, 20);
			this.NP.TabIndex = 0;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label7.Location = new System.Drawing.Point(229, 33);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(170, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Трансформаторных подстанций";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label8.Location = new System.Drawing.Point(233, 14);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(166, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "Социально значимых объектов";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label6.Location = new System.Drawing.Point(6, 35);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Населения";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label5.Location = new System.Drawing.Point(5, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(113, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Населённых пунктов";
			// 
			// DotPanel
			// 
			this.DotPanel.AutoSize = true;
			this.DotPanel.Controls.Add(this.l1);
			this.DotPanel.Controls.Add(this.p1);
			this.DotPanel.Controls.Add(this.p2);
			this.DotPanel.Controls.Add(this.p3);
			this.DotPanel.Controls.Add(this.p4);
			this.DotPanel.Location = new System.Drawing.Point(11, 73);
			this.DotPanel.Margin = new System.Windows.Forms.Padding(0);
			this.DotPanel.Name = "DotPanel";
			this.DotPanel.Size = new System.Drawing.Size(530, 23);
			this.DotPanel.TabIndex = 24;
			// 
			// l1
			// 
			this.l1.Location = new System.Drawing.Point(1, 1);
			this.l1.Margin = new System.Windows.Forms.Padding(1);
			this.l1.Name = "l1";
			this.l1.Size = new System.Drawing.Size(65, 20);
			this.l1.TabIndex = 5;
			this.l1.Text = "ВЛ 10 кВ ф.";
			this.l1.TextChanged += new System.EventHandler(this.l1_TextChanged);
			// 
			// p1
			// 
			this.p1.Location = new System.Drawing.Point(68, 1);
			this.p1.Margin = new System.Windows.Forms.Padding(1);
			this.p1.Name = "p1";
			this.p1.Size = new System.Drawing.Size(44, 20);
			this.p1.TabIndex = 0;
			this.p1.TextChanged += new System.EventHandler(this.p1_TextChanged);
			// 
			// p2
			// 
			this.p2.Location = new System.Drawing.Point(114, 1);
			this.p2.Margin = new System.Windows.Forms.Padding(1);
			this.p2.Name = "p2";
			this.p2.Size = new System.Drawing.Size(161, 20);
			this.p2.TabIndex = 1;
			this.p2.TextChanged += new System.EventHandler(this.p1_TextChanged);
			// 
			// p3
			// 
			this.p3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.p3.FormattingEnabled = true;
			this.p3.Location = new System.Drawing.Point(277, 1);
			this.p3.Margin = new System.Windows.Forms.Padding(1);
			this.p3.Name = "p3";
			this.p3.Size = new System.Drawing.Size(78, 21);
			this.p3.TabIndex = 3;
			this.p3.TextChanged += new System.EventHandler(this.p1_TextChanged);
			// 
			// p4
			// 
			this.p4.Location = new System.Drawing.Point(357, 1);
			this.p4.Margin = new System.Windows.Forms.Padding(1);
			this.p4.Name = "p4";
			this.p4.Size = new System.Drawing.Size(171, 20);
			this.p4.TabIndex = 4;
			this.p4.TextChanged += new System.EventHandler(this.p1_TextChanged);
			// 
			// edFiderName
			// 
			this.edFiderName.Enabled = false;
			this.edFiderName.Location = new System.Drawing.Point(11, 99);
			this.edFiderName.MaxLength = 255;
			this.edFiderName.Name = "edFiderName";
			this.edFiderName.Size = new System.Drawing.Size(532, 20);
			this.edFiderName.TabIndex = 25;
			// 
			// ldot
			// 
			this.ldot.AutoSize = true;
			this.ldot.ForeColor = System.Drawing.Color.Maroon;
			this.ldot.Location = new System.Drawing.Point(12, 59);
			this.ldot.Name = "ldot";
			this.ldot.Size = new System.Drawing.Size(54, 13);
			this.ldot.TabIndex = 26;
			this.ldot.Text = "Образец:";
			// 
			// HidentLabel
			// 
			this.HidentLabel.AutoSize = true;
			this.HidentLabel.Location = new System.Drawing.Point(448, 19);
			this.HidentLabel.Name = "HidentLabel";
			this.HidentLabel.Size = new System.Drawing.Size(64, 13);
			this.HidentLabel.TabIndex = 27;
			this.HidentLabel.Text = "HidentLabel";
			this.HidentLabel.Visible = false;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label31.Location = new System.Drawing.Point(9, 42);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(44, 13);
			this.label31.TabIndex = 32;
			this.label31.Text = "Тип ВЛ";
			// 
			// cbTypeVL
			// 
			this.cbTypeVL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTypeVL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbTypeVL.FormattingEnabled = true;
			this.cbTypeVL.Location = new System.Drawing.Point(59, 39);
			this.cbTypeVL.Name = "cbTypeVL";
			this.cbTypeVL.Size = new System.Drawing.Size(78, 21);
			this.cbTypeVL.TabIndex = 31;
			this.cbTypeVL.SelectedIndexChanged += new System.EventHandler(this.cbTypeVL_SelectedIndexChanged);
			// 
			// P_load_z
			// 
			this.P_load_z.DecimalPlaces = 3;
			this.P_load_z.Location = new System.Drawing.Point(404, 50);
			this.P_load_z.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.P_load_z.Name = "P_load_z";
			this.P_load_z.Size = new System.Drawing.Size(92, 20);
			this.P_load_z.TabIndex = 9;
			// 
			// P_load_l
			// 
			this.P_load_l.DecimalPlaces = 3;
			this.P_load_l.Location = new System.Drawing.Point(124, 50);
			this.P_load_l.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.P_load_l.Name = "P_load_l";
			this.P_load_l.Size = new System.Drawing.Size(92, 20);
			this.P_load_l.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label3.Location = new System.Drawing.Point(282, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Нагрузка зимой, МВт";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label4.Location = new System.Drawing.Point(5, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Нагрузка летом, МВт";
			// 
			// AddNewFiderInBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(554, 247);
			this.ControlBox = false;
			this.Controls.Add(this.label31);
			this.Controls.Add(this.cbTypeVL);
			this.Controls.Add(this.HidentLabel);
			this.Controls.Add(this.ldot);
			this.Controls.Add(this.edFiderName);
			this.Controls.Add(this.DotPanel);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.cbRes);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbCompany);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "AddNewFiderInBase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Добавить новый объект в базу";
			this.Shown += new System.EventHandler(this.AddNewFiderInBase_Shown);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SZO)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Population)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NP)).EndInit();
			this.DotPanel.ResumeLayout(false);
			this.DotPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.P_load_z)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.P_load_l)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox cbRes;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbCompany;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.NumericUpDown TP;
        public System.Windows.Forms.NumericUpDown SZO;
        public System.Windows.Forms.NumericUpDown Population;
        public System.Windows.Forms.NumericUpDown NP;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox p1;
        private System.Windows.Forms.TextBox p2;
        private System.Windows.Forms.ComboBox p3;
        private System.Windows.Forms.TextBox p4;
        public System.Windows.Forms.TextBox edFiderName;
        public System.Windows.Forms.FlowLayoutPanel DotPanel;
        public System.Windows.Forms.Label ldot;
        private System.Windows.Forms.TextBox l1;
        private System.Windows.Forms.Label HidentLabel;
        private System.Windows.Forms.Label label31;
        public System.Windows.Forms.ComboBox cbTypeVL;
		public System.Windows.Forms.NumericUpDown P_load_z;
		public System.Windows.Forms.NumericUpDown P_load_l;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label4;
	}
}