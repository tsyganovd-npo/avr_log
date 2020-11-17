using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVR_log.SetupForms
{
    public partial class AddNewFiderInBase : Form
    {
        public int FiderId = int.MinValue;

        public const string dot_f10 = "Образец: ВЛ 10кВ ф.{номер фидера} {наименование фидера} ПС 110 кВ {наименование ПС}";
        public const string dot_f04 = "Образец: ВЛ 0,4кВ от ТП №{ номер ТП} {Наименование населённого пункта}";
        public const string dot_f35_110 = "Образец: ВЛ-110/35кВ {Наименование населённых пунктов}";

        public AddNewFiderInBase()
        {
            InitializeComponent();
            TP.Maximum = int.MaxValue;
            NP.Maximum = int.MaxValue;
            SZO.Maximum = int.MaxValue;
            Population.Maximum = int.MaxValue;

        }

        private void cbTypeVL_SelectedIndexChanged(object sender, EventArgs e)
        {
            l1.Visible = true;
            p1.Visible = true;
            p2.Visible = true;
            p3.Visible = true;
            p4.Visible = true;
            p3.Items.Clear();
            switch (cbTypeVL.SelectedIndex)
            {
                case 0:
                    {
                        ldot.Text = dot_f10;
                        l1.Text = "ВЛ 10кВ ф.";
                        l1.ReadOnly = false;
                        p1.Text = p2.Text = p4.Text = "";
                        p3.Items.Add("ПС 110кВ");
                        p3.Items.Add("ПС 35кВ");
                        p4.Width = 171;
                        break;
                    }
                case 1:
                    {
                        ldot.Text = dot_f04;
                        l1.Text = "ВЛ 0,4кВ от ТП №";
                        l1.ReadOnly = true;
                        p1.Text = p2.Text = p4.Text = "";
                        p3.SelectedIndex = -1;
                        p3.Visible = false;
                        p4.Visible = false;
                        //p4.Width = edFiderName.Width - l1.Width - p1.Width - 6;
                        break;
                    }
                case 2:
                    {
                        ldot.Text = dot_f35_110;
                        l1.Text = "";
                        //l1.Text = "ВЛ 110кВ";
                        //l1.ReadOnly = true;
                        l1.Visible = false;
                        p1.Text = p2.Text = p4.Text = "";
                        p3.SelectedIndex = -1;
                        p1.Visible = false;
                        p2.Visible = false;
                        p3.Items.Add("ВЛ-110кВ");
                        p3.Items.Add("ВЛ-35кВ");
                        p4.Width = edFiderName.Width - p3.Width-4;

                        break;
                    }

            }
            edFiderName.Text = "";
        }

        private void p1_TextChanged(object sender, EventArgs e)
        {
            edFiderName.Text = l1.Text + p1.Text + " " + p2.Text+ " " + p3.Text + " " + p4.Text;
            edFiderName.Text=edFiderName.Text.Trim();
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cbRes.SelectedIndex < 0)
            {
                MessageBox.Show("Необходимо выбрать РЭС.");
            }
            else
            {
                bool err = false;
                if ((l1.Visible) && (l1.Text == "")) err = true;
                if ((p1.Visible) && (p1.Text == "")) err = true;
                if ((p2.Visible) && (p2.Text == "")) err = true;
                if ((p3.Visible) && (p3.Text == "")) err = true;
                if ((p4.Visible) && (p4.Text == "")) err = true;

                if ((FiderId == int.MinValue)&& err)
                {
                    MessageBox.Show("Не все поля заполнены");
                }
                else
                {
                    
                    if (FiderId == int.MinValue)  //Если это новый фидер
                    {
                        if(Mysql.FindFiderInBase(edFiderName.Text))
                        {
                            MessageBox.Show("В базе уже содержится "+ edFiderName.Text +"\nДобавить объект с таким же именем невозможно!");
                        }
                        else
                        { 
                            int FiderType = cbTypeVL.SelectedIndex;
                            if (Mysql.AddNewFiderInBase(edFiderName.Text, FiderType, Config.Reses[cbRes.Text].Id, Config.Companies[cbCompany.Text].Id, (int)TP.Value, (int)SZO.Value, (int)NP.Value, (int)Population.Value, P_load_l.Value, P_load_z.Value))
                                this.DialogResult = DialogResult.Yes;
                            else this.DialogResult = DialogResult.No;
                            this.Hide();
                        }
                    }
                    else //Если это редактирование фидера
                    {
                        if (Mysql.EditFiderFromBase(FiderId, edFiderName.Text, (int)TP.Value, (int)SZO.Value, (int)NP.Value, (int)Population.Value, P_load_l.Value, P_load_z.Value))
                            this.DialogResult = DialogResult.Yes;
                        else this.DialogResult = DialogResult.No;
                        this.Hide();
                    }
                }
            }
        }

        private void AddNewFiderInBase_Shown(object sender, EventArgs e)
        {
            //ldot.Text = dot_f10;

            //cbTypeVL_SelectedIndexChanged(this, null);

            if (cbRes.SelectedIndex < 0)
            {
                cbRes.Focus();
                //cbRes.DroppedDown = true;
            }

        }


        private void l1_TextChanged(object sender, EventArgs e)
        {
            HidentLabel.Text = l1.Text;
            l1.Width = HidentLabel.Width;
        }

    }
}
