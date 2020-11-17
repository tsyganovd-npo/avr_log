using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVR_log
{
    public partial class Favr : Form
    {
        public int CurResID = 0;
        public int CurJournalID=0;
        public int CurFiderType = 0;
		public int cbMasterAvrOtherIndex = int.MaxValue;
		public int cbMasterAvrOtherIndex2 = int.MaxValue;
		public int cbMasterAvrOtherIndex3 = int.MaxValue;
		public int cbMasterAvrOtherIndex4 = int.MaxValue;
		public bool CheckFiders = true; //Для проверки в ремонте ли фидер (false - не проверять);
        public string strFindFiders = "";
		public string cbP_load_Valid_string = "0,000";


		public Favr()
        {
            InitializeComponent();
            TP.Maximum = int.MaxValue;
            NP.Maximum = int.MaxValue;
            SZO.Maximum = int.MaxValue;
            Population.Maximum = int.MaxValue;
        }

        public void ShowMasters_osm(int i)
        {
            switch (i)
            {
                case 1:
                    cbMasterOsm2.Visible = false;
                    dolMasterOsm2.Visible = false;
                    telMasterOsm2.Visible = false;
                    cbMasterOsm3.Visible = false;
                    dolMasterOsm3.Visible = false;
                    telMasterOsm3.Visible = false;
                    cbMasterOsm4.Visible = false;
                    dolMasterOsm4.Visible = false;
                    telMasterOsm4.Visible = false;

                    cbMasterOsm2.SelectedIndex = -1;
                    dolMasterOsm2.Text = "";
                    telMasterOsm2.Text = "";
                    cbMasterOsm3.SelectedIndex = -1;
                    dolMasterOsm3.Text = "";
                    telMasterOsm3.Text = "";
                    cbMasterOsm4.SelectedIndex = -1;
                    dolMasterOsm4.Text = "";
                    telMasterOsm4.Text = "";

                    break;
                case 2:
                    cbMasterOsm2.Visible = true;
                    dolMasterOsm2.Visible = true;
                    telMasterOsm2.Visible = true;
                    cbMasterOsm3.Visible = false;
                    dolMasterOsm3.Visible = false;
                    telMasterOsm3.Visible = false;
                    cbMasterOsm4.Visible = false;
                    dolMasterOsm4.Visible = false;
                    telMasterOsm4.Visible = false;
                    cbMasterOsm3.SelectedIndex = -1;
                    dolMasterOsm3.Text = "";
                    telMasterOsm3.Text = "";
                    cbMasterOsm4.SelectedIndex = -1;
                    dolMasterOsm4.Text = "";
                    telMasterOsm4.Text = "";

                    break;
                case 3:
                    cbMasterOsm2.Visible = true;
                    dolMasterOsm2.Visible = true;
                    telMasterOsm2.Visible = true;
                    cbMasterOsm3.Visible = true;
                    dolMasterOsm3.Visible = true;
                    telMasterOsm3.Visible = true;
                    cbMasterOsm4.Visible = false;
                    dolMasterOsm4.Visible = false;
                    telMasterOsm4.Visible = false;
                    cbMasterOsm4.SelectedIndex = -1;
                    dolMasterOsm4.Text = "";
                    telMasterOsm4.Text = "";
                    break;

                default:
                    cbMasterOsm2.Visible = true;
                    dolMasterOsm2.Visible = true;
                    telMasterOsm2.Visible = true;
                    cbMasterOsm3.Visible = true;
                    dolMasterOsm3.Visible = true;
                    telMasterOsm3.Visible = true;
                    cbMasterOsm4.Visible = true;
                    dolMasterOsm4.Visible = true;
                    telMasterOsm4.Visible = true;
                    break;
            }

        }

		public void ShowMasters_avr(int i)
		{
			switch (i)
			{
				case 1:
					cbMasterAvr2.Visible = false;
					dolMasterAvr2.Visible = false;
					telMasterAvr2.Visible = false;
					cbMasterAvr3.Visible = false;
					dolMasterAvr3.Visible = false;
					telMasterAvr3.Visible = false;
					cbMasterAvr4.Visible = false;
					dolMasterAvr4.Visible = false;
					telMasterAvr4.Visible = false;
					cbPerem_br2.Visible = false;
					cbPerem_br3.Visible = false;
					cbPerem_br4.Visible = false;
					cbPrinadl_br2.Visible = false;
					cbPrinadl_br3.Visible = false;
					cbPrinadl_br4.Visible = false;
					lPrBr1.Visible = lPerBr1.Visible = false;
					lPrBr2.Visible = lPerBr2.Visible = false;
					lPrBr3.Visible = lPerBr3.Visible = false;
					lPrBr4.Visible = lPerBr4.Visible = false;

					cbMasterAvr2.SelectedIndex = -1;
					dolMasterAvr2.Text = "";
					telMasterAvr2.Text = "";
					cbMasterAvr3.SelectedIndex = -1;
					dolMasterAvr3.Text = "";
					telMasterAvr3.Text = "";
					cbMasterAvr4.SelectedIndex = -1;
					dolMasterAvr4.Text = "";
					telMasterAvr4.Text = "";
					cbPerem_br2.SelectedIndex = -1;
					cbPerem_br3.SelectedIndex = -1;
					cbPerem_br4.SelectedIndex = -1;
					cbPrinadl_br2.SelectedIndex = -1;
					cbPrinadl_br3.SelectedIndex = -1;
					cbPrinadl_br4.SelectedIndex = -1;


					break;
				case 2:
					cbMasterAvr2.Visible = true;
					dolMasterAvr2.Visible = true;
					telMasterAvr2.Visible = true;
					cbMasterAvr3.Visible = false;
					dolMasterAvr3.Visible = false;
					telMasterAvr3.Visible = false;
					cbMasterAvr4.Visible = false;
					dolMasterAvr4.Visible = false;
					telMasterAvr4.Visible = false;
					cbPerem_br2.Visible = true;
					cbPerem_br3.Visible = false;
					cbPerem_br4.Visible = false;
					cbPrinadl_br2.Visible = true;
					cbPrinadl_br3.Visible = false;
					cbPrinadl_br4.Visible = false;
					lPrBr1.Visible = lPerBr1.Visible = true;
					lPrBr2.Visible = lPerBr2.Visible = true;
					lPrBr3.Visible = lPerBr3.Visible = false;
					lPrBr4.Visible = lPerBr4.Visible = false;

					cbMasterAvr3.SelectedIndex = -1;
					dolMasterAvr3.Text = "";
					telMasterAvr3.Text = "";
					cbMasterAvr4.SelectedIndex = -1;
					dolMasterAvr4.Text = "";
					telMasterAvr4.Text = "";
					cbPerem_br3.SelectedIndex = -1;
					cbPerem_br4.SelectedIndex = -1;
					cbPrinadl_br3.SelectedIndex = -1;
					cbPrinadl_br4.SelectedIndex = -1;

					break;
				case 3:
					cbMasterAvr2.Visible = true;
					dolMasterAvr2.Visible = true;
					telMasterAvr2.Visible = true;
					cbMasterAvr3.Visible = true;
					dolMasterAvr3.Visible = true;
					telMasterAvr3.Visible = true;
					cbMasterAvr4.Visible = false;
					dolMasterAvr4.Visible = false;
					telMasterAvr4.Visible = false;
					cbPerem_br2.Visible = true;
					cbPerem_br3.Visible = true;
					cbPerem_br4.Visible = false;
					cbPrinadl_br2.Visible = true;
					cbPrinadl_br3.Visible = true;
					cbPrinadl_br4.Visible = false;
					lPrBr1.Visible = lPerBr1.Visible = true;
					lPrBr2.Visible = lPerBr2.Visible = true;
					lPrBr3.Visible = lPerBr3.Visible = true;
					lPrBr4.Visible = lPerBr4.Visible = false;


					cbMasterAvr4.SelectedIndex = -1;
					dolMasterAvr4.Text = "";
					telMasterAvr4.Text = "";
					cbPerem_br4.SelectedIndex = -1;
					cbPrinadl_br4.SelectedIndex = -1;

					break;

				default:
					cbMasterAvr2.Visible = true;
					dolMasterAvr2.Visible = true;
					telMasterAvr2.Visible = true;
					cbMasterAvr3.Visible = true;
					dolMasterAvr3.Visible = true;
					telMasterAvr3.Visible = true;
					cbMasterAvr4.Visible = true;
					dolMasterAvr4.Visible = true;
					telMasterAvr4.Visible = true;
					cbPerem_br2.Visible = true;
					cbPerem_br3.Visible = true;
					cbPerem_br4.Visible = true;
					cbPrinadl_br2.Visible = true;
					cbPrinadl_br3.Visible = true;
					cbPrinadl_br4.Visible = true;
					lPrBr1.Visible = lPerBr1.Visible = true;
					lPrBr2.Visible = lPerBr2.Visible = true;
					lPrBr3.Visible = lPerBr3.Visible = true;
					lPrBr4.Visible = lPerBr4.Visible = true;
					break;
			}

		}



		private void Kol_pers_osm_ValueChanged(object sender, EventArgs e)
        {
            //ShowMasters((int)kol_pers_osm.Value);
        }

        private void Kol_br_osm_ValueChanged(object sender, EventArgs e)
        {
            ShowMasters_osm((int)kol_br_osm.Value);
        }


        private void Button6_Click(object sender, EventArgs e)
        {
            t_otkl.Text = System.DateTime.Now.ToString("HHmm");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            t_osm.Text = System.DateTime.Now.ToString("HHmm");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            t_avr.Text = System.DateTime.Now.ToString("HHmm");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            t_vkl_vl.Text = System.DateTime.Now.ToString("HHmm");
        }
        private void Btn_set_t_vkl_potr_Click(object sender, EventArgs e)
        {
            t_vkl_potr.Text = System.DateTime.Now.ToString("HHmm");
        }


        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
			cbPerem_br.Enabled = cbEndOfWork.Checked;
			cbPerem_br2.Enabled = cbEndOfWork.Checked;
			cbPerem_br3.Enabled = cbEndOfWork.Checked;
			cbPerem_br4.Enabled = cbEndOfWork.Checked;
			obem_rabot.Enabled = cbEndOfWork.Checked;
            d_vkl_potr.Enabled = cbEndOfWork.Checked;
            t_vkl_potr.Enabled = cbEndOfWork.Checked;
            btn_set_t_vkl_potr.Enabled = cbEndOfWork.Checked;
            btnDotObemRabot.Enabled = cbEndOfWork.Checked;
			cbAPVRPV.Enabled= cbEndOfWork.Checked;

			if (!cbEndOfWork.Checked) t_vkl_potr.Text = "";

        }

        /// <summary>
        /// Изменился тип ВЛ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTypeVL_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurFiderType = Array.IndexOf(Config.TypeVL,cbTypeVL.Text);
            LoadFiders(CurFiderType);
        }

        /// <summary>
        /// // Получить в комбобоксе список нужных фидеров
        /// </summary>
        /// <param name="FiderType">0 - фидера 10 кв, 1 - фидера 0,4 кв.</param>
        /// <param name="filtertext">текст фильтра</param>
        public void LoadFiders(int FiderType, string filtertext="")
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
                if (query.Count()>0)
                {
                    cbFider.DataSource = query.ToList();
                }
            }
            //cbFider.DataSource = config.Fiders.Values.Where(i => i.FromResId == CurResID).Where(f=>f.FiderType==0).Select(p => p.Name).ToList();


            if (cbFider.Items.Count==1)
                cbFider.SelectedIndex = 0; //фидерать единственный фидер
            else
                cbFider.SelectedIndex = -1; //фидер не выбран

            if (cbFider.Items.Count > 0) 
                    cbFider.Text = tstr;
        }
        /// <summary>
        /// // Получить в комбобоксах для ОСМОТРА Ф.И.О.  список нужных мастеров
        /// </summary> 
        public void LoadOsmMasters()
        {
            int Maxdd;
            cbMasterOsm1.Items.Clear();
            cbMasterOsm1.Items.AddRange(Config.Masters.Values.Where(n => n.FromResId == CurResID).Select(p => p.Fio).ToArray());
            cbMasterOsm1.Items.Add(Config.OtherWorkersName);
            cbMasterOsm1.SelectedIndex = -1;
            Maxdd = cbMasterOsm1.Items.Count;
            if (Maxdd > 24) Maxdd = 24;
            cbMasterOsm1.MaxDropDownItems = Maxdd;

            cbMasterOsm2.Items.Clear();
            cbMasterOsm2.Items.AddRange(Config.Masters.Values.Where(n => n.FromResId == CurResID).Select(p => p.Fio).ToArray());
            cbMasterOsm2.Items.Add(Config.OtherWorkersName);
            cbMasterOsm2.SelectedIndex = -1;
            Maxdd = cbMasterOsm2.Items.Count;
            if (Maxdd > 24) Maxdd = 24;
            cbMasterOsm2.MaxDropDownItems = Maxdd;

            cbMasterOsm3.Items.Clear();
            cbMasterOsm3.Items.AddRange(Config.Masters.Values.Where(n => n.FromResId == CurResID).Select(p => p.Fio).ToArray());
            cbMasterOsm3.Items.Add(Config.OtherWorkersName);
            cbMasterOsm3.SelectedIndex = -1;
            Maxdd = cbMasterOsm3.Items.Count;
            if (Maxdd > 24) Maxdd = 24;
            cbMasterOsm3.MaxDropDownItems = Maxdd;

            cbMasterOsm4.Items.Clear();
            cbMasterOsm4.Items.AddRange(Config.Masters.Values.Where(n => n.FromResId == CurResID).Select(p => p.Fio).ToArray());
            cbMasterOsm4.Items.Add(Config.OtherWorkersName);
            cbMasterOsm4.SelectedIndex = -1;
            Maxdd = cbMasterOsm4.Items.Count;
            if (Maxdd > 24) Maxdd = 24;
            cbMasterOsm4.MaxDropDownItems = Maxdd;

        }

        /// <summary>
        /// // Получить в комбобоксe для АВР Ф.И.О.  список нужных мастеров
        /// </summary> 
        public void LoadAvrMasters()
        {
            if (cbPrinadl_br.SelectedItem != null)
            {
                int tResId = Config.Reses[cbPrinadl_br.SelectedItem.ToString()].Id;
                cbMasterAvr.Items.Clear();
                cbMasterAvr.Items.AddRange(Config.Masters.Values.Where(n => n.FromResId == tResId).Select(p => p.Fio).ToArray());
                cbMasterAvr.SelectedIndex = -1;
            }
            else
            {
                cbMasterAvr.Items.Clear();
            }
			//Удаляем должгости и телефоны мастеров, т.к. список мастеров изменился.
			dolMasterAvr.Text = "";
			telMasterAvr.Text = "";

			//cbMasterAvr.Items.Add(config.OtherWorkersName);
		}

		//Новое в версии 1.0.5.0
		public void LoadAvrMasters2()
		{
			if (cbPrinadl_br2.SelectedItem != null)
			{
				int tResId = Config.Reses[cbPrinadl_br2.SelectedItem.ToString()].Id;
				cbMasterAvr2.Items.Clear();
				cbMasterAvr2.Items.AddRange(Config.Masters.Values.Where(n => n.FromResId == tResId).Select(p => p.Fio).ToArray());
				cbMasterAvr2.SelectedIndex = -1;
			}
			else
			{
				cbMasterAvr2.Items.Clear();
			}
			//Удаляем должгости и телефоны мастеров, т.к. список мастеров изменился.
			dolMasterAvr2.Text = "";
			telMasterAvr2.Text = "";
		}
		public void LoadAvrMasters3()
		{
			if (cbPrinadl_br3.SelectedItem != null)
			{
				int tResId = Config.Reses[cbPrinadl_br3.SelectedItem.ToString()].Id;
				cbMasterAvr3.Items.Clear();
				cbMasterAvr3.Items.AddRange(Config.Masters.Values.Where(n => n.FromResId == tResId).Select(p => p.Fio).ToArray());
				cbMasterAvr3.SelectedIndex = -1;
			}
			else
			{
				cbMasterAvr3.Items.Clear();
			}
			//Удаляем должгости и телефоны мастеров, т.к. список мастеров изменился.
			dolMasterAvr3.Text = "";
			telMasterAvr3.Text = "";
		}
		public void LoadAvrMasters4()
		{
			if (cbPrinadl_br4.SelectedItem != null)
			{
				int tResId = Config.Reses[cbPrinadl_br4.SelectedItem.ToString()].Id;
				cbMasterAvr4.Items.Clear();
				cbMasterAvr4.Items.AddRange(Config.Masters.Values.Where(n => n.FromResId == tResId).Select(p => p.Fio).ToArray());
				cbMasterAvr4.SelectedIndex = -1;
			}
			else
			{
				cbMasterAvr4.Items.Clear();
			}
			//Удаляем должгости и телефоны мастеров, т.к. список мастеров изменился.
			dolMasterAvr4.Text = "";
			telMasterAvr4.Text = "";
		}
		//конец нового в версии 1.0.5.0



		//Изменён Фидер
		private void CbFider_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((cbFider.Items.Count>0)&&(cbFider.Text!=""))
            {
                //Фидер не времонте?
                if (!ValidFider(cbFider.Text))
                {
                    MessageBox.Show("Данный объект уже в ремонте!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //Если фидер выбран, то необходимо отобразить кол-во ТП, СЗО, нас. пуктов, населенеия.           
                TP.Value = Config.Fiders[cbFider.Text].TP;
                SZO.Value = Config.Fiders[cbFider.Text].SZO;
                NP.Value = Config.Fiders[cbFider.Text].NP;
                Population.Value = Config.Fiders[cbFider.Text].Population;

				//Новое в версии 1.0.4.0
				P_load.Value = 0;
				if ((Config.Fiders[cbFider.Text].P_load_l != 0) && (Config.Fiders[cbFider.Text].P_load_z != 0))
				{
					cbP_load.Items.Clear();
					cbP_load.Items.Add(Config.Fiders[cbFider.Text].P_load_l.ToString());
					cbP_load.Items.Add(Config.Fiders[cbFider.Text].P_load_z.ToString());
					cbP_load.Visible = true;
					cbP_load.DroppedDown = true;
				}
				else
				{
					if (Config.Fiders[cbFider.Text].P_load_l != 0)
						P_load.Value = Config.Fiders[cbFider.Text].P_load_l;
					if (Config.Fiders[cbFider.Text].P_load_z != 0)
						P_load.Value = Config.Fiders[cbFider.Text].P_load_z;
					cbP_load.Visible = false;
				}

				//Спрячем фильтр
				HideFilter();
				
				//cbFider.DataSource = config.Fiders04.Values.Where(n => n.FromResId == 0).Select(p => p.Name).ToList();

			}
		}


        //Изменён РЭС
        private void CbRes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Config.Reses.ContainsKey(cbRes.Text))
            {

                CurResID = Config.Reses[cbRes.Text].Id;
                LoadOsmMasters();//Загрузить мастеров для осмотра
                //Удаляем должости и телефоны мастеров, т.к. список мастеров изменился.
                dolMasterOsm1.Text = dolMasterOsm2.Text = dolMasterOsm3.Text = dolMasterOsm4.Text = "";
                telMasterOsm1.Text = telMasterOsm2.Text = telMasterOsm3.Text = telMasterOsm4.Text = "";
                LoadFiders(CurFiderType);

                lbSelectRes.Visible = false;//спрятать предупреждение, что РЭС не выбран
                //MessageBox.Show(config.Reses[cbRes.Text].Id.ToString());
            }
        }

        //Выбор должности и телефона, если:
        //Выбрали 1 мастера из списка
        private void CbMasterOsm1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (((sender as ComboBox).SelectedItem != null) && ((sender as ComboBox).SelectedItem.ToString() != Config.OtherWorkersName))
            {
                dolMasterOsm1.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
                telMasterOsm1.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
                if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
                    MessageBox.Show("Руководитель бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Если выбран раздел Другие работники
            if ((sender as ComboBox).SelectedItem.ToString() == Config.OtherWorkersName)
            {
                SetupForms.SelectMasterInBase SelectMaster = new SetupForms.SelectMasterInBase();
                SelectMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                SelectMaster.cbRes.DropDownStyle = ComboBoxStyle.Simple;
                SelectMaster.cbRes.Text=Config.OtherWorkersName;
                SelectMaster.cbRes.Enabled = false;
                SelectMaster.LoadMasters(Config.OtherWorkersId);
                SelectMaster.cbMasters.SelectedIndex = -1;
                SelectMaster.btnAddNewMaster.Visible = true;
                SelectMaster.ShowDialog();
                if (SelectMaster.DialogResult == DialogResult.Yes)
                {
                    cbMasterOsm1.Items.Add(SelectMaster.cbMasters.Text);
                    cbMasterOsm1.Text = SelectMaster.cbMasters.Text;
                    dolMasterOsm1.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
                    telMasterOsm1.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
                    if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
                        MessageBox.Show("Руководитель бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    (sender as ComboBox).SelectedIndex = -1;
                    dolMasterOsm1.Text = "";
                    telMasterOsm1.Text = "";
                }
            }
        }

        //Выбрали 2 мастера из списка
        private void CbMasterOsm2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (((sender as ComboBox).SelectedItem != null) && ((sender as ComboBox).SelectedItem.ToString() != Config.OtherWorkersName))
            {
                dolMasterOsm2.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
                telMasterOsm2.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
                if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
                    MessageBox.Show("Руководителе бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Если выбран раздел Другие работники
            if ((sender as ComboBox).SelectedItem.ToString() == Config.OtherWorkersName)
            {
                SetupForms.SelectMasterInBase SelectMaster = new SetupForms.SelectMasterInBase();
                SelectMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                SelectMaster.cbRes.DropDownStyle = ComboBoxStyle.Simple;
                SelectMaster.cbRes.Text = Config.OtherWorkersName;
                SelectMaster.cbRes.Enabled = false;
                SelectMaster.LoadMasters(Config.OtherWorkersId);
                SelectMaster.cbMasters.SelectedIndex = -1;
                SelectMaster.btnAddNewMaster.Visible = true;
                SelectMaster.ShowDialog();
                if (SelectMaster.DialogResult == DialogResult.Yes)
                {
                    cbMasterOsm2.Items.Add(SelectMaster.cbMasters.Text);
                    cbMasterOsm2.Text = SelectMaster.cbMasters.Text;
                    dolMasterOsm2.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
                    telMasterOsm2.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
                    if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
                        MessageBox.Show("Руководитель бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    (sender as ComboBox).SelectedIndex = -1;
                    dolMasterOsm2.Text = "";
                    telMasterOsm2.Text = "";
                }
            }
        }

        //Выбрали 3 мастера из списка
        private void CbMasterOsm3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (((sender as ComboBox).SelectedItem != null) && ((sender as ComboBox).SelectedItem.ToString() != Config.OtherWorkersName))
            {
                dolMasterOsm3.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
                telMasterOsm3.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
                if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
                    MessageBox.Show("Руководителе бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Если выбран раздел Другие работники
            if ((sender as ComboBox).SelectedItem.ToString() == Config.OtherWorkersName)
            {
                SetupForms.SelectMasterInBase SelectMaster = new SetupForms.SelectMasterInBase();
                SelectMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                SelectMaster.cbRes.DropDownStyle = ComboBoxStyle.Simple;
                SelectMaster.cbRes.Text = Config.OtherWorkersName;
                SelectMaster.cbRes.Enabled = false;
                SelectMaster.LoadMasters(Config.OtherWorkersId);
                SelectMaster.cbMasters.SelectedIndex = -1;
                SelectMaster.btnAddNewMaster.Visible = true;
                SelectMaster.ShowDialog();
                if (SelectMaster.DialogResult == DialogResult.Yes)
                {
                    cbMasterOsm3.Items.Add(SelectMaster.cbMasters.Text);
                    cbMasterOsm3.Text = SelectMaster.cbMasters.Text;
                    dolMasterOsm3.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
                    telMasterOsm3.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
                    if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
                        MessageBox.Show("Руководитель бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    (sender as ComboBox).SelectedIndex = -1;
                    dolMasterOsm3.Text = "";
                    telMasterOsm3.Text = "";
                }
            }
        }

        //Выбрали 4 мастера из списка
        private void CbMasterOsm4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (((sender as ComboBox).SelectedItem != null)&& ((sender as ComboBox).SelectedItem.ToString() != Config.OtherWorkersName))
            {
                dolMasterOsm4.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
                telMasterOsm4.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
                if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
                    MessageBox.Show("Руководителе бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Если выбран раздел Другие работники
            if ((sender as ComboBox).SelectedItem.ToString() == Config.OtherWorkersName)
            {
                SetupForms.SelectMasterInBase SelectMaster = new SetupForms.SelectMasterInBase();
                SelectMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                SelectMaster.cbRes.DropDownStyle = ComboBoxStyle.Simple;
                SelectMaster.cbRes.Text = Config.OtherWorkersName;
                SelectMaster.cbRes.Enabled = false;
                SelectMaster.LoadMasters(Config.OtherWorkersId);
                SelectMaster.cbMasters.SelectedIndex = -1;
                SelectMaster.ShowDialog();
                SelectMaster.btnAddNewMaster.Visible = true;
                if (SelectMaster.DialogResult == DialogResult.Yes)
                {
                    cbMasterOsm4.Items.Add(SelectMaster.cbMasters.Text);
                    cbMasterOsm4.Text = SelectMaster.cbMasters.Text;
                    dolMasterOsm4.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
                    telMasterOsm4.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
                    if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
                        MessageBox.Show("Руководитель бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    (sender as ComboBox).SelectedIndex = -1;
                    dolMasterOsm4.Text = "";
                    telMasterOsm4.Text = "";
                }
            }
        }

        //Выбор рпинадлежности бригады 1 к РЭС-у из списка
        private void CbPrinadl_br1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPrinadl_br.SelectedIndex <= cbMasterAvrOtherIndex)
            {
                ///Раз выбран конкретный РЭС, то удалим все "принадлежности бригад" "других" работников
                for (int i = cbMasterAvrOtherIndex + 1; i < cbPrinadl_br.Items.Count; i++)
                {
                    cbPrinadl_br.Items.RemoveAt(i);
                }

                if (cbPrinadl_br.Text != Config.OtherWorkersName)
                {
                    LoadAvrMasters();
                }
                else //Если другие, то
                {
                    SetupForms.SelectMasterInBase SelectMaster = new SetupForms.SelectMasterInBase();
                    SelectMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                    SelectMaster.cbRes.DropDownStyle = ComboBoxStyle.Simple;
                    SelectMaster.cbRes.Text = Config.OtherWorkersName;
                    SelectMaster.cbRes.Enabled = false;
                    SelectMaster.LoadMasters(Config.OtherWorkersId);
                    SelectMaster.cbMasters.SelectedIndex = -1;
                    SelectMaster.btnAddNewMaster.Visible = true;
                    SelectMaster.ShowDialog();
                    if (SelectMaster.DialogResult == DialogResult.Yes)
                    {
                        cbMasterAvr.Items.Add(SelectMaster.cbMasters.Text);
                        cbMasterAvr.Text = SelectMaster.cbMasters.Text;
                        dolMasterAvr.Text = Config.Masters[cbMasterAvr.Text].Dol;
                        telMasterAvr.Text = Config.Masters[cbMasterAvr.Text].Tel;
                        cbPrinadl_br.SelectedIndex = cbPrinadl_br.Items.Add(Config.Filials.Values.First(i => i.Id == Config.Masters[SelectMaster.cbMasters.Text].FromFilialId).Name);
                        if (!ValidMaster(cbMasterAvr.Text))
                            MessageBox.Show("Руководитель бригады " + cbMasterAvr.Text + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        cbMasterAvr.Items.Clear();
                        //cbMasterAvr.SelectedIndex = -1;
                        dolMasterAvr.Text = "";
                        telMasterAvr.Text = "";
                    }
                }
            }
        }

		//Новое в версии 1.0.5.0
		//Выбор рпинадлежности бригады 2 к РЭС-у из списка
		private void CbPrinadl_br2_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cbPrinadl_br2.SelectedIndex <= cbMasterAvrOtherIndex2)
			{
				///Раз выбран конкретный РЭС, то удалим все "принадлежности бригад" "других" работников
				for (int i = cbMasterAvrOtherIndex2 + 1; i < cbPrinadl_br2.Items.Count; i++)
				{
					cbPrinadl_br2.Items.RemoveAt(i);
				}

				if (cbPrinadl_br2.Text != Config.OtherWorkersName)
				{
					LoadAvrMasters2();
				}
				else //Если другие, то
				{
					SetupForms.SelectMasterInBase SelectMaster = new SetupForms.SelectMasterInBase();
					SelectMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
					SelectMaster.cbRes.DropDownStyle = ComboBoxStyle.Simple;
					SelectMaster.cbRes.Text = Config.OtherWorkersName;
					SelectMaster.cbRes.Enabled = false;
					SelectMaster.LoadMasters(Config.OtherWorkersId);
					SelectMaster.cbMasters.SelectedIndex = -1;
					SelectMaster.btnAddNewMaster.Visible = true;
					SelectMaster.ShowDialog();
					if (SelectMaster.DialogResult == DialogResult.Yes)
					{
						cbMasterAvr2.Items.Add(SelectMaster.cbMasters.Text);
						cbMasterAvr2.Text = SelectMaster.cbMasters.Text;
						dolMasterAvr2.Text = Config.Masters[cbMasterAvr2.Text].Dol;
						telMasterAvr2.Text = Config.Masters[cbMasterAvr2.Text].Tel;
						cbPrinadl_br2.SelectedIndex = cbPrinadl_br2.Items.Add(Config.Filials.Values.First(i => i.Id == Config.Masters[SelectMaster.cbMasters.Text].FromFilialId).Name);
						if (!ValidMaster(cbMasterAvr2.Text))
							MessageBox.Show("Руководитель бригады " + cbMasterAvr2.Text + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					else
					{
						cbMasterAvr2.Items.Clear();
						//cbMasterAvr.SelectedIndex = -1;
						dolMasterAvr2.Text = "";
						telMasterAvr2.Text = "";
					}
				}
			}
		}

		//Выбор рпинадлежности бригады 3 к РЭС-у из списка
		private void CbPrinadl_br3_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cbPrinadl_br3.SelectedIndex <= cbMasterAvrOtherIndex3)
			{
				///Раз выбран конкретный РЭС, то удалим все "принадлежности бригад" "других" работников
				for (int i = cbMasterAvrOtherIndex3 + 1; i < cbPrinadl_br3.Items.Count; i++)
				{
					cbPrinadl_br3.Items.RemoveAt(i);
				}

				if (cbPrinadl_br3.Text != Config.OtherWorkersName)
				{
					LoadAvrMasters3();
				}
				else //Если другие, то
				{
					SetupForms.SelectMasterInBase SelectMaster = new SetupForms.SelectMasterInBase();
					SelectMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
					SelectMaster.cbRes.DropDownStyle = ComboBoxStyle.Simple;
					SelectMaster.cbRes.Text = Config.OtherWorkersName;
					SelectMaster.cbRes.Enabled = false;
					SelectMaster.LoadMasters(Config.OtherWorkersId);
					SelectMaster.cbMasters.SelectedIndex = -1;
					SelectMaster.btnAddNewMaster.Visible = true;
					SelectMaster.ShowDialog();
					if (SelectMaster.DialogResult == DialogResult.Yes)
					{
						cbMasterAvr3.Items.Add(SelectMaster.cbMasters.Text);
						cbMasterAvr3.Text = SelectMaster.cbMasters.Text;
						dolMasterAvr3.Text = Config.Masters[cbMasterAvr3.Text].Dol;
						telMasterAvr3.Text = Config.Masters[cbMasterAvr3.Text].Tel;
						cbPrinadl_br3.SelectedIndex = cbPrinadl_br3.Items.Add(Config.Filials.Values.First(i => i.Id == Config.Masters[SelectMaster.cbMasters.Text].FromFilialId).Name);
						if (!ValidMaster(cbMasterAvr3.Text))
							MessageBox.Show("Руководитель бригады " + cbMasterAvr3.Text + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					else
					{
						cbMasterAvr3.Items.Clear();
						//cbMasterAvr.SelectedIndex = -1;
						dolMasterAvr3.Text = "";
						telMasterAvr3.Text = "";
					}
				}
			}
		}

		//Выбор рпинадлежности бригады 4 к РЭС-у из списка
		private void CbPrinadl_br4_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cbPrinadl_br4.SelectedIndex <= cbMasterAvrOtherIndex4)
			{
				///Раз выбран конкретный РЭС, то удалим все "принадлежности бригад" "других" работников
				for (int i = cbMasterAvrOtherIndex4 + 1; i < cbPrinadl_br4.Items.Count; i++)
				{
					cbPrinadl_br4.Items.RemoveAt(i);
				}

				if (cbPrinadl_br4.Text != Config.OtherWorkersName)
				{
					LoadAvrMasters4();
				}
				else //Если другие, то
				{
					SetupForms.SelectMasterInBase SelectMaster = new SetupForms.SelectMasterInBase();
					SelectMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
					SelectMaster.cbRes.DropDownStyle = ComboBoxStyle.Simple;
					SelectMaster.cbRes.Text = Config.OtherWorkersName;
					SelectMaster.cbRes.Enabled = false;
					SelectMaster.LoadMasters(Config.OtherWorkersId);
					SelectMaster.cbMasters.SelectedIndex = -1;
					SelectMaster.btnAddNewMaster.Visible = true;
					SelectMaster.ShowDialog();
					if (SelectMaster.DialogResult == DialogResult.Yes)
					{
						cbMasterAvr4.Items.Add(SelectMaster.cbMasters.Text);
						cbMasterAvr4.Text = SelectMaster.cbMasters.Text;
						dolMasterAvr4.Text = Config.Masters[cbMasterAvr4.Text].Dol;
						telMasterAvr4.Text = Config.Masters[cbMasterAvr4.Text].Tel;
						cbPrinadl_br4.SelectedIndex = cbPrinadl_br4.Items.Add(Config.Filials.Values.First(i => i.Id == Config.Masters[SelectMaster.cbMasters.Text].FromFilialId).Name);
						if (!ValidMaster(cbMasterAvr4.Text))
							MessageBox.Show("Руководитель бригады " + cbMasterAvr4.Text + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					else
					{
						cbMasterAvr4.Items.Clear();
						//cbMasterAvr.SelectedIndex = -1;
						dolMasterAvr4.Text = "";
						telMasterAvr4.Text = "";
					}
				}
			}
		}

		private void Kol_br_avr_ValueChanged(object sender, EventArgs e)
		{
			ShowMasters_avr((int)kol_br_avr.Value);
		}
		//конец нового в версии 1.0.5.0



		//Выбор должности и телефона при выборе 1 руководителя работ
		private void CbMasterAvr1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null) 
            {
                dolMasterAvr.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
                telMasterAvr.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
                if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
                    MessageBox.Show("Руководителе бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

		//Новое в версии 1.0.5.0
		//Выбор должности и телефона при выборе 2 руководителя работ
		private void CbMasterAvr2_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if ((sender as ComboBox).SelectedItem != null)
			{
				dolMasterAvr2.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
				telMasterAvr2.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
				if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
					MessageBox.Show("Руководителе бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		//Выбор должности и телефона при выборе 3 руководителя работ
		private void CbMasterAvr3_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if ((sender as ComboBox).SelectedItem != null)
			{
				dolMasterAvr3.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
				telMasterAvr3.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
				if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
					MessageBox.Show("Руководителе бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		//Выбор должности и телефона при выборе 4 руководителя работ
		private void CbMasterAvr4_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if ((sender as ComboBox).SelectedItem != null)
			{
				dolMasterAvr4.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Dol;
				telMasterAvr4.Text = Config.Masters[(sender as ComboBox).SelectedItem.ToString()].Tel;
				if (!ValidMaster((sender as ComboBox).SelectedItem.ToString()))
					MessageBox.Show("Руководителе бригады " + (sender as ComboBox).SelectedItem.ToString() + ", уже задействован в работах на другом объекте.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		//конец нового в версии 1.0.5.0


		/// <summary>
		/// Проверка факта того, что выбранный фидер уже не находится в ремонте.
		/// </summary> 
		/// <param name="FiderName">Название фидера</param>
		private bool ValidFider(string FiderName)
        {
            if (Mysql.FiderInAvr(Config.Fiders[FiderName].Id)) return false;
            return true;
        }


        /// <summary>
        /// Проверка корректности введённого времени.
        /// </summary> 
        private bool ValidTime(string time)
        {
           try
            {
                TimeSpan.Parse(time);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidMaster(string masterfio)
        {
            int masterid = Config.Masters.Values.First(p => p.Fio == masterfio).Id;
            if (!Mysql.FindMasterInJournal(masterid, CurJournalID))
                return false;                   
            return true;
        }


        /// <summary>
        /// Проверка корректности заполнения формы.
        /// </summary> 
        private bool ValidAVR()
        {
            List<string> ValidError = new List<string>();
            DateTime dt_otkl, dt_osm, dt_avr, dt_vkl_vl, dt_vkl_potr;
            dt_otkl = dt_osm = dt_avr = dt_vkl_vl = dt_vkl_potr = DateTime.Parse("01.01.2000 00:00");

            if (cbFider.Text == "")
            {
                ValidError.Add("Не указан объект отключения");
            }
            else
            {
                if ((CheckFiders)&&(!cbEndOfWork.Checked) && (!ValidFider(cbFider.Text))) //Фидер не времонте?
                    ValidError.Add(Config.Fiders[cbFider.Text].Name + " уже в ремонте и ремонтные работы по нему не завершены");
            }

            if (cbRes.Text == "")
                ValidError.Add("Не указан РЭС");


            if (t_otkl.Text == "  :")//Если время отключения НЕ указано, то
            {
                ValidError.Add("Не указано время отключения");
            }
            else
            {
                if (!ValidTime(t_otkl.Text))
                {
                    ValidError.Add("Время отключения указано неверно");
                }
                else
                {
                    dt_otkl = DateTime.Parse(d_otkl.Text + " " + t_otkl.Text);
                }
            }

            /////Осмотр
            if (t_osm.Text != "  :")//Если время осмотра указано, то
            {
                if (!ValidTime(t_osm.Text))
                {
                    ValidError.Add("Время допуска к осмотру указано неверно");
                }
                else
                {
                    dt_osm = DateTime.Parse(d_osm.Text + " " + t_osm.Text);
                    if (dt_osm < dt_otkl) ValidError.Add("Время допуска к осмотру не может быть меньше времени отключения");
                    //if (TimeSpan.Parse(t_osm.Text) < TimeSpan.Parse(t_otkl.Text)) ValidError.Add("Время допуска к осмотру не может быть меньше времени отключения");
                }

                if ((cbMasterOsm1.Text == "") || (dolMasterOsm1.Text == "") || (telMasterOsm1.Text == ""))
                    ValidError.Add("О руководителе бригады, проводящем осмотр, заполнены не все данные.");
                else
                {
                    if ((cbMasterOsm1.Text== cbMasterOsm2.Text)|| (cbMasterOsm1.Text == cbMasterOsm3.Text)|| (cbMasterOsm1.Text == cbMasterOsm4.Text))
                        ValidError.Add("Руководитель 1 бригады "+ cbMasterOsm1.Text + ", проводящей осмотр, указан несколько раз.");
                }

                if(kol_br_osm.Value > 1)
                {
                    if ((cbMasterOsm2.Text == "") || (dolMasterOsm2.Text == "") || (telMasterOsm2.Text == ""))
                        ValidError.Add("О втором руководителе бригады, проводящем осмотр, заполнены не все данные.");
                    else
                    {
                        if ((cbMasterOsm2.Text == cbMasterOsm3.Text) || (cbMasterOsm2.Text == cbMasterOsm4.Text))
                            ValidError.Add("Руководитель 2 бригады " + cbMasterOsm2.Text + ", проводящей осмотр, указан несколько раз.");
                    }

                }
                if (kol_br_osm.Value > 2)
                {
                    if ((cbMasterOsm3.Text == "") || (dolMasterOsm3.Text == "") || (telMasterOsm3.Text == ""))
                        ValidError.Add("О третьем руководителе бригады, проводящем осмотр, заполнены не все данные.");
                    else
                    {
                        if (cbMasterOsm3.Text == cbMasterOsm4.Text)
                            ValidError.Add("Руководитель 3 бригады " + cbMasterOsm3.Text + ", проводящей осмотр, указан несколько раз.");
                    }
                }
                if (kol_br_osm.Value > 3)
                {

                    if ((cbMasterOsm4.Text == "") || (dolMasterOsm4.Text == "") || (telMasterOsm4.Text == ""))
                        ValidError.Add("О четвёртом руководителе бригады, проводящем осмотр, заполнены не все данные.");
                }

            }
            else //если время осмотра не заполнено
            {
                if ((cbMasterOsm1.Text != "") || (dolMasterOsm1.Text != "") || (telMasterOsm1.Text != "") ||
                    (cbMasterOsm2.Text != "") || (dolMasterOsm2.Text != "") || (telMasterOsm2.Text != "") ||
                    (cbMasterOsm3.Text != "") || (dolMasterOsm3.Text != "") || (telMasterOsm3.Text != "") ||
                    (cbMasterOsm4.Text != "") || (dolMasterOsm4.Text != "") || (telMasterOsm4.Text != "") || (result_osm.Text != ""))
                    ValidError.Add("Внесены данны о осмотре, но не проставлено время осмотра");
            }

            //////АВР
            if (t_avr.Text != "  :")//Если время допуска к авр указано, то
            {
                if (t_osm.Text == "  :") ValidError.Add("До проведения АВР необходимо внести данные о проведённом осмотре");
                else if (result_osm.Text == "") ValidError.Add("До проведения АВР необходимо указать обнаруженные повреждения");

                if (cbPrinadl_br.Text == "") ValidError.Add("Не указана Принадлежность бригад.");
                if (cbBasaAvr.Text == "") ValidError.Add("Не указано Место базирования бригад.");

                if ((cbMasterAvr.Text == "") || (dolMasterAvr.Text == "") || (telMasterAvr.Text == ""))
                    ValidError.Add("О руководителе 1 бригады, проводящем АВР, заполнены не все данные.");
				//Новое в версии 1.0.5.0
				else
				{
					if ((cbMasterAvr.Text == cbMasterAvr2.Text) || (cbMasterAvr.Text == cbMasterAvr3.Text) || (cbMasterAvr.Text == cbMasterAvr4.Text))
						ValidError.Add("Руководитель 1 бригады " + cbMasterAvr.Text + ", проводящей АВР, указан несколько раз.");
				}

				if (kol_br_avr.Value > 1)
				{
					if ((cbMasterAvr2.Text == "") || (dolMasterAvr2.Text == "") || (telMasterAvr2.Text == ""))
						ValidError.Add("О втором руководителе бригады, проводящем АВР, заполнены не все данные.");
					else
					{
						if ((cbMasterAvr2.Text == cbMasterAvr3.Text) || (cbMasterAvr2.Text == cbMasterAvr4.Text))
							ValidError.Add("Руководитель 2 бригады " + cbMasterAvr2.Text + ", проводящей АВР, указан несколько раз.");
					}

				}
				if (kol_br_avr.Value > 2)
				{
					if ((cbMasterAvr3.Text == "") || (dolMasterAvr3.Text == "") || (telMasterAvr3.Text == ""))
						ValidError.Add("О третьем руководителе бригады, проводящем АВР, заполнены не все данные.");
					else
					{
						if (cbMasterAvr3.Text == cbMasterAvr4.Text)
							ValidError.Add("Руководитель 3 бригады " + cbMasterAvr3.Text + ", проводящей АВР, указан несколько раз.");
					}
				}
				if (kol_br_avr.Value > 3)
				{

					if ((cbMasterAvr4.Text == "") || (dolMasterAvr4.Text == "") || (telMasterAvr4.Text == ""))
						ValidError.Add("О четвёртом руководителе бригады, проводящем АВР, заполнены не все данные.");
				}
				//Конец Новое в версии 1.0.5.0
				dt_avr = DateTime.Parse(d_avr.Text + " " + t_avr.Text);
                if (dt_avr < dt_osm) ValidError.Add("Время допуска к АВР не может быть меньше времени допуска к осмотру");

            }
            else
            {
                if ((cbPrinadl_br.Text != "") || (cbMasterAvr.Text != "") || (dolMasterAvr.Text != "") || (telMasterAvr.Text != "") || (cbBasaAvr.Text!="") ||
                (BKM.Value>0) || (AGP.Value>0) || (Kran.Value>0) /*|| (t_vkl_vl.Text!= "  :") || (t_plan_okon.Text != "  :")*/)
                    ValidError.Add("Внесены данны об АВР, но не проставлено время допуска к АВР");
            }
            
            ////Завершение работ
            //Если установлен чекбокс "Работы завершены"
            if (cbEndOfWork.Checked)
            {
                if (t_vkl_potr.Text == "  :")
                {
                    ValidError.Add("Не указано время запитки потребителей");
                }
                else
                {
                    dt_vkl_potr = DateTime.Parse(d_vkl_potr.Text + " " + t_vkl_potr.Text);
                    if (dt_vkl_potr < dt_avr) ValidError.Add("Дата и время включения потребителей не может быть меньше времени допуска к АВР");

                }
				//Новое в версии 1.0.5.0 До этого параметра cbAPVRPV небыло
				if (!cbAPVRPV.Checked)
				{
					if (t_osm.Text == "  :") ValidError.Add("До завершения работ необходимо внести данные о проведённом осмотре");
					if (t_avr.Text == "  :") ValidError.Add("До завершения работ необходимо внести данные о проведённых АВР");
					if (cbPerem_br.Text == "") ValidError.Add("Не указано место перемещения бригады по завершении работ");
					if (obem_rabot.Text == "") ValidError.Add("Не указан объём выполненных работ");
				}
			}

            // если есть проблемы, то
            if (ValidError.Count > 0)
            {
                //Вывод сообщения об обнаруженных проблемах.
                string str = "";
                int i = 0;
                foreach (string item in ValidError)
                {
                    i++;
                    str += i.ToString() + ": " + item + "\n";
                }
                MessageBox.Show(str, "Обнаруженные проблемы");
                return false;
            } else //если проблем нет:
            {
                return true;
            }

        }

        //Нажата кнопка сохранить и выйти
        private void Button1_Click(object sender, EventArgs e)
        {
            if (ValidAVR())
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        //Выделить все поле ввода
        private void ClicOnTlfVield(object sender, EventArgs e)
        {
            (sender as MaskedTextBox).SelectAll();
        }

        //Выделение для поля время
        private void ClicOnTimeVield(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.MouseEventArgs)e).X < (int)(sender as MaskedTextBox).ClientRectangle.Width / 2)
                (sender as MaskedTextBox).Select(0, 2);
            else
                (sender as MaskedTextBox).Select(3, 2);
        }


        private void Favr_Shown(object sender, EventArgs e)
        {
            t_otkl.Focus();
            t_otkl.Select(3, 2);

        }


        //Работа с меню шаблонов результатов осмотра и объемов выполненых работ
        private void BtnDotResultOsm_Click(object sender, EventArgs e)
        {
            Point point = new Point(0, result_osm.Size.Height);
            contextMenuResult_Osm.Show(result_osm, point);
        }


        private void ContextMenuResult_Osm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            result_osm.Text += e.ClickedItem.Text;

        }

        private void BtnDotObemRabot_Click(object sender, EventArgs e)
        {
            Point point = new Point(0, obem_rabot.Size.Height);
            contextMenuObem_Rabot.Show(obem_rabot, point);
        }

        private void ContextMenuObem_Rabot_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            obem_rabot.Text += e.ClickedItem.Text;
        }

        //КОНЕЦ Работы с меню шаблонов результатов осмотра и объемов выполненых работ

        private void CbFider_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                strFindFiders = "";
                HideFilter();
            }

            if (((ComboBox)sender).DroppedDown)
            {
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
            strFindFiders= "";
            LoadFiders(CurFiderType);
        }


        private void CbFider_Leave(object sender, EventArgs e)
        {
            HideFilter();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            string m1 = cbMasterOsm1.Text;
            string m2 = cbMasterOsm2.Text;
            string m3 = cbMasterOsm3.Text;
            string m4 = cbMasterOsm4.Text;
            if (Fmain.AddMasterMenuExt())
            {
                LoadOsmMasters();
            }

            cbMasterOsm1.Text = m1;
            cbMasterOsm2.Text = m2;
            cbMasterOsm3.Text = m3;
            cbMasterOsm4.Text = m4;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            string m1 = cbMasterAvr.Text;
            string m2 = dolMasterAvr.Text;
            string m3 = telMasterAvr.Text;
            if (Fmain.AddMasterMenuExt())
            {
                LoadAvrMasters();
            }
            cbMasterAvr.Text = m1;
            dolMasterAvr.Text = m2;
            telMasterAvr.Text = m3;

        }

		private void CbP_load_DrawItem(object sender, DrawItemEventArgs e)
		{
			ComboBox s = sender as ComboBox;
			e.DrawBackground();
			if ((s.Items.Count > 0)&&(e.Index!=-1))
			{
				Font f = new Font(s.Font, FontStyle.Italic);
				switch (e.Index)
				{
					case 0:
						e.Graphics.DrawString("Лето", f, Brushes.Orange, new RectangleF(e.Bounds.Width - e.Font.Size * 4, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
						break;
					case 1:
						e.Graphics.DrawString("Зима", f, Brushes.Orange, new RectangleF(e.Bounds.Width - e.Font.Size * 4, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
						break;
				}
				e.Graphics.DrawString(s.Items[e.Index].ToString(), s.Font, Brushes.Black, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
			}
			e.DrawFocusRectangle();
		}

		private void CbP_load_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (decimal.TryParse((sender as ComboBox).SelectedItem.ToString(), out decimal newdec))
				P_load.Value = newdec;
			else
				MessageBox.Show("Ошибка.выбранное значение невозможно преобразовать к числу с плавающей точкой. (decimal).");
		}
	}
}
