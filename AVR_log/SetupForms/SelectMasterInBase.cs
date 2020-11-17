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
    public partial class SelectMasterInBase : Form
    {
        public SelectMasterInBase()
        {
            InitializeComponent();
        }

        public void LoadMasters(int ResID)
        {
            cbMasters.Items.Clear();
            cbMasters.Items.AddRange(Config.Masters.Values.Where(n => n.FromResId == ResID).Select(p => p.Fio).ToArray());
        }

        private void cbRes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cbRes.Text!=Config.OtherWorkersName)
            {
                LoadMasters(Config.Reses[cbRes.Text].Id);
                cbCompany.Enabled = true;
            }
            else
            {
                LoadMasters(Config.OtherWorkersId);
                cbCompany.Enabled = false;
            }
            cbMasters.Focus();
            cbMasters.SelectedIndex = -1;

        }

        private void SelectMasterInBase_Shown(object sender, EventArgs e)
        {
            
            /*
            if (cbRes.SelectedIndex < 0)
            {
                cbRes.Focus();
                cbRes.DroppedDown = true;
            }*/
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cbMasters.SelectedIndex >= 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Hide();
            }
        }

        private void btnAddNewMaster_Click(object sender, EventArgs e)
        {
            
            SetupForms.AddNewMaster fNewMaster = new SetupForms.AddNewMaster();
            fNewMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            fNewMaster.cbRes.Items.Add(Config.OtherWorkersName);
            fNewMaster.cbRes.SelectedIndex = 0;
            fNewMaster.ShowHidePrinadl();
            fNewMaster.ShowDialog();
            if (fNewMaster.DialogResult == DialogResult.Yes)
            {
                if (Mysql.AddNewMasterInBase(fNewMaster.edFIO.Text, fNewMaster.edDol.Text, fNewMaster.edTel.Text, Config.OtherWorkersId, Config.Companies[fNewMaster.cbCompany.Text].Id, Config.Filials[fNewMaster.cbOtherPrinandl.Text].Id))
                {
                    MessageBox.Show("Новый работник успешно внесён в базу.");
                    LoadMasters(Config.OtherWorkersId);
                    cbMasters.Text = fNewMaster.edFIO.Text;
                }
                else MessageBox.Show("При добавлении нового работника возникла ошибка. Обратитесь к разработчику.");
            }
        }
    }
}
