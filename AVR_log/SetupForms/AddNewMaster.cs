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
    public partial class AddNewMaster : Form
    {
        public int MasterId = int.MinValue;
        public string MasterFio = "";
        public AddNewMaster()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cbRes.SelectedIndex < 0)
            {
                MessageBox.Show("Необходимо выбрать РЭС.");
            }
            else
            {
                //            if (mysql.AddNewFiderInBase(edFiderName.Text, FiderType, config.Companies[cbCompany.Text].Id, config.Reses[cbRes.Text].Id, (int)TP.Value, (int)SZO.Value, (int)NP.Value, (int)Population.Value))
                if ((edFIO.Text == "") || (edDol.Text == "") || (edTel.Text == "")|| ((cbRes.Text == Config.OtherWorkersName) && (cbOtherPrinandl.Text == "")))
                {
                    MessageBox.Show("Необходимо заполнить все поля.");
                }
                else
                {
                    if (edTel.Text.Length != 11)
                    {
                        MessageBox.Show("В поле телефон должно быть внесено 11 цифр.");
                    }
                    else
                    {
                            if (((MasterId>=0)&&(MasterFio==edFIO.Text))||(!Mysql.FindMasterInBase(edFIO.Text))) //Если пользователь с такими Фамилия И.О. не найден
                            {
                                this.DialogResult = DialogResult.Yes;
                                this.Hide();
                            }
                            else
                            {
                                string addition = "(число)";
                                for (int i = 1; i < 99; i++)
                                {
                                    addition = "(" + i.ToString() + ")";
                                    if (!Mysql.FindMasterInBase(edFIO.Text + addition))
                                        break;
                                }


                                MessageBox.Show("Работник " + edFIO.Text + " уже содержится в базе. \nНеобходимо ввести другие Ф.И.О., например " + edFIO.Text + addition +
                                    "\nВ Форму 4 данный работник будет выгружен без дополнения '" + addition + "'");

                                edFIO.Text += addition;

                            }
                        
                    }
                }
            }
        }

        private void edTel_Click(object sender, EventArgs e)
        {
            (sender as MaskedTextBox).SelectAll();
        }

        private void AddNewMaster_Shown(object sender, EventArgs e)
        {
            
            if (cbRes.SelectedIndex < 0)
            {
                cbRes.Focus();
                //cbRes.DroppedDown = true;
            }
        }

        private void cbRes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowHidePrinadl();
        }

        public void ShowHidePrinadl()
        {
            if (cbRes.Text == Config.OtherWorkersName)
            {
                cbCompany.Enabled = false;
                lbPrinadl.Visible = true;
                cbOtherPrinandl.Visible = true;
                cbOtherPrinandl.Items.Clear();
                cbOtherPrinandl.Items.AddRange(Config.Filials.Values.Select(p => p.Name).ToArray());
            }
            else
            {
                cbCompany.Enabled = true;
                lbPrinadl.Visible = false;
                cbOtherPrinandl.Visible = false;
            }
        }
    }
}
