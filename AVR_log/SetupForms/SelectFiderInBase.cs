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
    public partial class SelectFiderInBase : Form
    {
        public int CurResID = 0;
        public int CurFiderType = 0;
        public string strFindFiders = "";

        public SelectFiderInBase()
        {
            InitializeComponent();
        }

        private void cbTypeVL_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurFiderType = cbTypeVL.SelectedIndex;
            LoadFiders(CurFiderType);
        }
/*
        private void CheckRbKv(object sender, EventArgs e)
        {
            if ((sender == rb10kv) && (rb10kv.Checked))
                CurFiderType = 0;

            if ((sender == rb04kv) && (rb04kv.Checked))
                CurFiderType = 1;

            LoadFiders(CurFiderType);
        }*/

        /// <summary>
        /// // Получить в комбобоксе список нужных фидеров
        /// </summary>
        /// <param name="FiderType">0 - фидера 10 кв, 1 - фидера 0,4 кв.</param>
        /// <param name="filtertext">текст фильтра</param>
        public void LoadFiders(int FiderType, string filtertext = "")
        {

            string tstr = cbFider.Text;
            if (filtertext == "")
            {
                var query = from f in Config.Fiders
                            where f.Value.FromResId == CurResID && f.Value.FiderType == FiderType
                            select f.Key;
                cbFider.DataSource = query.ToList();
            }
            else
            {
                var query = from f in Config.Fiders
                            where f.Value.FromResId == CurResID && f.Value.FiderType == FiderType && f.Value.Name.ToLower().Contains(filtertext.ToLower())
                            select f.Key;
                if (query.Count() > 0)
                    cbFider.DataSource = query.ToList();
            }
            //cbFider.DataSource = config.Fiders.Values.Where(i => i.FromResId == CurResID).Where(f=>f.FiderType==0).Select(p => p.Name).ToList();



            cbFider.SelectedIndex = -1; //фидер не выбран
            if (cbFider.Items.Count > 0)
                cbFider.Text = tstr;
        }


        private void cbRes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Config.Reses.ContainsKey(cbRes.Text))
            {
                CurResID = Config.Reses[cbRes.Text].Id;
/*                if (rb10kv.Checked)
                    CurFiderType = 0;

                if (rb04kv.Checked)
                    CurFiderType = 1;*/
                LoadFiders(CurFiderType);
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(cbFider.SelectedIndex>=0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Hide();
            }
			else
			{
				if((cbCompany.SelectedIndex>=0)&&(cbRes.SelectedIndex>=0)&&(cbTypeVL.SelectedIndex>=0))
				{
					if (MessageBox.Show($"Фидер не выбран. Произвести удаление всех фидеров {cbTypeVL.Text}, относящихся к подразделению {cbRes.Text}-{cbCompany.Text}?", "Групповое удаление фидеров", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						this.DialogResult = DialogResult.OK;
						this.Hide();
					}
				}
			}
        }

        private void SelectFiderInBase_Shown(object sender, EventArgs e)
        {
            /*
            if (cbRes.SelectedIndex < 0)
            {
                cbRes.Focus();
                cbRes.DroppedDown = true;
            } else
            {
                cbFider.Focus();
                cbFider.DroppedDown = true;

            }*/

        }

        private void cbFider_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                strFindFiders = "";
                HideFilter();
            }

            if (((ComboBox)sender).DroppedDown)
            {
                if (e.KeyChar == (char)Keys.Escape)
                {
                    ((ComboBox)sender).SelectedIndex = -1;
                }

                if ((e.KeyChar == (char)Keys.Back) && (strFindFiders.Length > 0))
                    strFindFiders = strFindFiders.Remove(strFindFiders.Length - 1);

                if (e.KeyChar > 31)
                    strFindFiders += (char)e.KeyChar;

                if (strFindFiders.Length > 0)
                {
                    lbFilter.Visible = true;
                    edFilter.Visible = true;
                    edFilter.Text = strFindFiders;
                    LoadFiders(CurFiderType, strFindFiders);
                }
                else
                {
                    HideFilter();
                    LoadFiders(CurFiderType);
                }
            }
        }

        private void HideFilter()
        {
            lbFilter.Visible = false;
            edFilter.Visible = false;
            edFilter.Text = "";
            strFindFiders = "";
            LoadFiders(CurFiderType);
        }



        private void cbFider_Leave(object sender, EventArgs e)
        {
            HideFilter();
        }

        private void cbFider_SelectionChangeCommitted(object sender, EventArgs e)
        {
            HideFilter();
        }

        private void cbRes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
