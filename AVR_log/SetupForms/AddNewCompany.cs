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
    public partial class AddNewCompany : Form
    {
        public AddNewCompany()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (edCompany.Text == "")
            {
                MessageBox.Show("Необходимо заполнить наименование ПО.");
            }
            else
            {
                this.DialogResult = DialogResult.Yes;
                this.Hide();
            }
        }

        private void edCompany_TextChanged(object sender, EventArgs e)
        {
            edFullName.Text = "\"Пензаэнерго\" - "+edCompany.Text;
        }
    }
}
