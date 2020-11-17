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
    public partial class AddNewRes : Form
    {
        public AddNewRes()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (edRes.Text == "")
            {
                MessageBox.Show("Необходимо заполнить наименование РЭС.");
            }
            else
            {
                if (Mysql.AddNewResInBase(edRes.Text, Config.Companies[cbCompany.Text].Id))
                    this.DialogResult = DialogResult.Yes;
                else this.DialogResult = DialogResult.No;
                this.Hide();
            }
        }
    }
}
