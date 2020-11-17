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
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void AddNewUser_Shown(object sender, EventArgs e)
        {
            if (cbRes.SelectedIndex < 0)
            {
                cbRes.Focus();
                cbRes.DroppedDown = true;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if ((edUserName.Text == "") || (edPass1.Text == "") || (edPass2.Text == ""))
            {
                MessageBox.Show("Необходимо заполнить все поля.");
            }
            else
            {
                if (edPass1.Text != edPass2.Text)
                {
                    MessageBox.Show("Пароли, введёные в полях 'Пароль' и 'Подтверждение' не совпадают");
                }
                else
                {
                    char id_grant='w';
                    if (rbDrant_r.Checked) id_grant = 'r';
                    if (rbDrant_x.Checked) id_grant = 'x';

                    int id_res;
                    if (checkBox1.Checked)
                    {
                        id_res = 0;
                    }
                    else
                    {
                        id_res = Config.Reses[cbRes.Text].Id;
                    }
                    string PassHash = Config.GetHashString(edPass1.Text);

                    //if (mysql.AddNewUserInBase(edUserName.Text, edPass1.Text, id_grant, id_res, config.Companies[cbCompany.Text].Id))
                    if (Mysql.AddNewUserInBase(edUserName.Text, PassHash.ToString(), id_grant, id_res, Config.Companies[cbCompany.Text].Id))
                        this.DialogResult = DialogResult.Yes;
                    else this.DialogResult = DialogResult.No;
                    this.Hide();
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) cbRes.Enabled = false;
                else cbRes.Enabled = true; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PassHash = Config.GetHashString(edPass1.Text);
            Clipboard.SetText(PassHash);

        }
    }
}
