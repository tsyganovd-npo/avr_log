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
    public partial class Fmain : Form
    {
        public static DataTable dtJournal = new DataTable();
        public Fmain()
        {
            InitializeComponent();
        }

        private void Fmain_Shown(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductVersion.ToString();
            Flogin flogin = new Flogin();
            flogin.ShowDialog();
            if ((flogin.DialogResult == DialogResult.Cancel) || (flogin.DialogResult == DialogResult.Abort))
            {
                Application.Exit();
            }
            else
            {
                this.BringToFront();
                StatusBarUserInfo.Text = "Пользователь - " + Config.LoginUser.Name + " (" + Config.LoginUser.Grant + ")"; //В StatusBarUserInfo отобразить имя пользователя и права доступа
                                                                                                                          //В заголовке окна указываем организацию
                if(Config.Companies.Count>0)
                {
                    if (Config.LoginUser.CompanyId > 0) //выводим ПО пользователя в заголовок
                        this.Text += " - " + Config.Companies.Values.First(p => p.Id == Config.LoginUser.CompanyId).FullName;
                }
                if (Config.Reses.Count > 0)
                {
                    if (Config.LoginUser.ResId > 0) //и если это простой пользователь, то выводим РЭС пользователя в заголовок
                        this.Text += " - " + Config.Reses.Values.First(p => p.Id == Config.LoginUser.ResId).Name;
                }
                //this.Text += " - " + Application.ProductVersion.ToString();
                if (Config.LoginUser.Grant == 'r') //права только на чтение (наблюдатель)
                {
                    OrganizationSetup.Enabled = false; //То отключим меню настроек Организаций
                    UsersSetup.Enabled = false; //отключим меню настроек Пользователей
                    ObjectSetup.Enabled = false; //отключим меню настроек Объектов отключения
                    MastersSetup.Enabled = false; //отключим меню настроек Руководителей бригад
                    OtklucheniyaMenuItem.Enabled = false; //отключим меню "Отключения"
                    //1.0.3.5
                    DelAllComandMasters.Enabled = false; //отключим меню Удалить весь командированный персонал
                }

                if ((Config.LoginUser.Grant == 'w') && (Config.LoginUser.ResId > 0)) //Если есть права на запись и пренадлежит РЭСу, то 
                {
                    OrganizationSetup.Enabled = false; //отключаем настройку организаций
                    UsersSetup.Enabled = false; //настройку пользователей
                    DelFiderMenu.Enabled = false; //возможность удаления фидеров
                    DelMasterMenu.Enabled = false; //возможность удаления мастеров
                    ImportFidersMenuItem.Enabled = false; //Импорт фидеров
                    ImportMastersMenuItem.Enabled = false; //Импорт фидеров
                    //1.0.3.5
                    DelAllComandMasters.Enabled = false; //отключим меню Удалить весь командированный персонал
                }
                if ((Config.LoginUser.Grant == 'w') && (Config.LoginUser.ResId == 0)) //Если Редактор, то
                {
                    AddNewCompanyMenu.Enabled = false; //отключаем настройку ПО
                    AddNewResMenu.Enabled = false; //отключаем настройку РЭС
                    //OrganizationSetup.Enabled = false; //отключаем настройку организаций
                    btnClearJournal.Visible = true;
                }

                if (Config.LoginUser.Grant == 'x') //Если Administrator
                {
                    btnClearJournal.Visible = true;
                }


                JournalUpdate();
                
                timer1.Interval = Config.Timer;
                timer1.Enabled = true;
            }
        }

        public void JournalUpdate()
        {
            //Проверка необходимости обновления словарей фидеров и мастеров
            int MAXUpdateJournalId = Config.MAXUpdateJournalId;
            Mysql.GetMaxUpdateJournalId();
            if (Config.MAXUpdateJournalId != MAXUpdateJournalId)
            {

                //Запоминаем какая строка была выбрана до обновления
                string curf = "";
                if (dgJournal.CurrentRow != null)
                {
                    curf = dgJournal.CurrentRow.Cells[1].Value.ToString(); ;
                }

                //StatusBarUpdateInfo.Visible = true;
                StatusBarUpdateInfo.Text = "Обновление данных журнала - "+DateTime.Now.ToShortTimeString() + ".";
                Application.DoEvents();

                dgJournal.Visible = false;
                //Запрос данных журнала
                if (Mysql.ShowJournal(dtJournal))
                {
                    if (dtJournal.Rows.Count != 0)
                    {
                        //Отображение журнала 
                        if (dgJournal.DataSource == null)
                            dgJournal.DataSource = dtJournal;

                        //Выключим все столбцы и отменим сортировку
                        foreach (DataGridViewColumn column in dgJournal.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            column.Visible = false;
                        }




                        dgJournal.Columns["resname"].HeaderText = "Наименование РЭС";
                        dgJournal.Columns["resname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgJournal.Columns["resname"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgJournal.Columns["resname"].Visible = true;

                        dgJournal.Columns["fidername"].Visible = true;
                        dgJournal.Columns["fidername"].HeaderText = "Наименование ЛЭП";
                        dgJournal.Columns["fidername"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgJournal.Columns["fidername"].MinimumWidth = 200;
                        dgJournal.Columns["fidername"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                        dgJournal.Columns["d_otkl"].Visible = true;
                        dgJournal.Columns["d_otkl"].HeaderText = "Дата отключ.";
                        dgJournal.Columns["d_otkl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgJournal.Columns["d_otkl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

                        dgJournal.Columns["t_otkl"].Visible = true;
                        dgJournal.Columns["t_otkl"].HeaderText = "Время отключ.";
                        dgJournal.Columns["t_otkl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //dgJournal.Columns["t_otkl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        dgJournal.Columns["t_otkl"].Width = 60;


                        dgJournal.Columns["t_osm"].Visible = true;
                        dgJournal.Columns["t_osm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgJournal.Columns["t_osm"].HeaderText = "Время допуска к осмотру";
                        dgJournal.Columns["t_osm"].Width = 72;

                        dgJournal.Columns["d_avr"].Visible = true;
                        dgJournal.Columns["d_avr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgJournal.Columns["d_avr"].HeaderText = "Дата допуска к АВР";
                        dgJournal.Columns["d_avr"].Width = 70;

                        dgJournal.Columns["t_avr"].Visible = true;
                        dgJournal.Columns["t_avr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgJournal.Columns["t_avr"].HeaderText = "Время допуска к АВР";
                        dgJournal.Columns["t_avr"].Width = 60;

                        dgJournal.Columns["d_vkl_potr"].Visible = true;
                        dgJournal.Columns["d_vkl_potr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgJournal.Columns["d_vkl_potr"].HeaderText = "Дата вкл. ВЛ";
                        dgJournal.Columns["d_vkl_potr"].Width = 90;

                        dgJournal.Columns["t_vkl_potr"].Visible = true;
                        dgJournal.Columns["t_vkl_potr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgJournal.Columns["t_vkl_potr"].HeaderText = "Время вкл. ВЛ";
                        dgJournal.Columns["t_vkl_potr"].Width = 90;

                        //Восстанавливаем какая строка была выбрана до обновления
                        if (curf != "")
                        {
                            foreach (DataGridViewRow row in dgJournal.Rows)
                            {

                                if (curf == row.Cells[1].Value.ToString())
                                {
                                    dgJournal.CurrentCell = dgJournal.Rows[row.Index].Cells[0];
                                    //dgJournal.Select();
                                    break;
                                }
                            }
                        }
                        dgJournal.Select();
                        dgJournal.Visible = true;

                        StatusBarCountFiders.Text = "Количество ВЛ 10кВ - " + Mysql.GetCountFiders(0).ToString() + " шт, ВЛ 0.4кВ - " + Mysql.GetCountFiders(1).ToString() + " шт, ВЛ 35/110кВ - " + Mysql.GetCountFiders(3).ToString() + " шт.";
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка загрузки журнала.\nОбратитесь к администратору.", "Критическая ошибка");
                }
                //StatusBarUpdateInfo.Visible = false;
            }
        }

        /// <summary>
        /// Прорисвка ячеек, добавленных вручную вручную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void dgJournal_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            
           /* if (e.RowIndex==2)
            {
                e.Value = "";

            }*/
       // }
        


        private void DgJournal_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dgJournal.RowCount)
            {
                if ((bool)dgJournal.Rows[e.RowIndex].Cells["endofwork"].Value) //если работы на фидере завершены
                {
                    TimeSpan t_vkl= TimeSpan.Parse("00:00");
                    try
                    {
                        //Пробуем получить время
                        t_vkl = TimeSpan.Parse(dgJournal.Rows[e.RowIndex].Cells["t_vkl_potr"].Value.ToString());
                    }
                    finally
                    {
                        if (t_vkl <= TimeSpan.Parse("03:05")) dgJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Config.Bgcolor.c1;
                        else if (t_vkl <= TimeSpan.Parse("07:05")) dgJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Config.Bgcolor.c2;
                        else if (t_vkl <= TimeSpan.Parse("11:05")) dgJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Config.Bgcolor.c3;
                        else if (t_vkl <= TimeSpan.Parse("13:05")) dgJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Config.Bgcolor.c4;
                        else if (t_vkl <= TimeSpan.Parse("18:05")) dgJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Config.Bgcolor.c5;
                        else if (t_vkl <= TimeSpan.Parse("22:05")) dgJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Config.Bgcolor.c6;
                        else if (t_vkl <= TimeSpan.Parse("23:05")) dgJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Config.Bgcolor.c7;
                        else dgJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Config.Bgcolor.c1; // как до 03:05
                    }
                }
            }

            dgJournal.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = dgJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor;
            dgJournal.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = dgJournal.DefaultCellStyle.ForeColor;



        }

        /// <summary>
        /// Рисуем рамку вокруг активной ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgJournal_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgJournal.Rows[e.RowIndex].Selected)
            {

                using (Pen pen = new Pen(Color.Black))
                {
                    int penWidth = 2;

                    pen.Width = penWidth;

                    int x = e.RowBounds.Left + (penWidth / 2);
                    int y = e.RowBounds.Top + (penWidth / 2);
                    int width = e.RowBounds.Width - penWidth;
                    int height = e.RowBounds.Height - penWidth;

					e.Graphics.DrawRectangle(pen, x, y, width, height);
                }
            }
        }

        /// <summary>
        /// Выделение строки и выпадение контекстного меню при ПКМ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgJournal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //if (e.Y > dgJournal.ColumnHeadersHeight)//Если клик не в заголовке
                //{
                    var h = dgJournal.HitTest(e.X, e.Y);
                    if (h.Type == DataGridViewHitTestType.Cell)
                    {
                        dgJournal.Rows[h.RowIndex].Selected = true;
                    }
                //} 
            }
        }


        /// <summary>
        /// Добавить новое отключение
        /// </summary>
        private void AddNewAVR()
        {
            timer1.Enabled = false; //Остановим таймер

            if ((Config.LoginUser.Grant == 'w')|| (Config.LoginUser.Grant == 'x'))
            { 
                Favr avr_new = new Favr();
                //favr.d_otkl.Text = DateTime.Now.ToString();
                avr_new.t_otkl.Text = DateTime.Now.ToString("HHmm");

                //Формируем список организаций
                avr_new.cbCompany.Items.Clear();
                avr_new.cbCompany.Items.AddRange(Config.Companies.Values.Select(p => p.Name).ToArray());
                if (Config.LoginUser.CompanyId > 0)
                {
                    avr_new.cbCompany.Text = Config.Companies.Values.First(p => p.Id == Config.LoginUser.CompanyId).Name;
                    avr_new.cbCompany.Enabled = false; //Отключае изменение значений комбобокса
                }

                //Формируем список РЭСов
                avr_new.cbRes.Items.Clear();
                avr_new.cbRes.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
                if (Config.LoginUser.ResId > 0)
                {
                    avr_new.CurResID = Config.LoginUser.ResId;
                    avr_new.cbRes.Text = Config.Reses.Values.First(p => p.Id == avr_new.CurResID).Name;
                    avr_new.cbRes.Enabled = false; //Отключае изменение значений комбобокса
                    avr_new.LoadOsmMasters();//Загрузить мастеров для осмотра

                }
                else
                {
                    //если РЭС не выбран, то отобразть предупреждение
                    avr_new.lbSelectRes.Visible = true;
                }

                //Загружаем список в комбобокс Типов линий
                avr_new.cbTypeVL.Items.AddRange(Config.TypeVL);

                //Новое в версии 1.0.3.3
                //Убираем из списка типов фидеров пустые.
                foreach (var item in Config.TypeVL)
                {
                    var query = from f in Config.Fiders
                                where f.Value.FiderType == Array.IndexOf(Config.TypeVL, item)
                                select f.Key;
                    if (query.Count() == 0) avr_new.cbTypeVL.Items.Remove(item);
                }

                if (avr_new.cbTypeVL.Items.Count>0)
                    avr_new.cbTypeVL.SelectedIndex = 0;
                //конец нового в версии 1.0.3.3




                //Загружаем список в комбобокс места базирования бригад
                avr_new.cbBasaAvr.DataSource = Config.Reses.Values.Select(p => p.Name).ToList();
                avr_new.cbBasaAvr.SelectedIndex = -1;

                //Загружаем список в комбобокс принадлежности бригад
                avr_new.cbPrinadl_br.Items.Clear();
                avr_new.cbPrinadl_br.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
                avr_new.cbMasterAvrOtherIndex=avr_new.cbPrinadl_br.Items.Add(Config.OtherWorkersName);
                avr_new.cbPrinadl_br.SelectedIndex = -1;
                //Загружаем список всех РЭС-ов в комбобокс перемещения бригад
                avr_new.cbPerem_br.Items.Clear();
                avr_new.cbPerem_br.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
                Mysql.FiderInAvrToCombobox(avr_new.cbPerem_br);
                avr_new.cbPerem_br.SelectedIndex = -1;

				//Новое в версии 1.0.5.0
				//Загружаем список в комбобокс принадлежности бригад 2
				avr_new.cbPrinadl_br2.Items.Clear();
				avr_new.cbPrinadl_br2.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
				avr_new.cbMasterAvrOtherIndex2 = avr_new.cbPrinadl_br2.Items.Add(Config.OtherWorkersName);
				avr_new.cbPrinadl_br2.SelectedIndex = -1;
				//Загружаем список всех РЭС-ов в комбобокс перемещения бригад 2
				avr_new.cbPerem_br2.Items.Clear();
				avr_new.cbPerem_br2.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
				Mysql.FiderInAvrToCombobox(avr_new.cbPerem_br2);
				avr_new.cbPerem_br2.SelectedIndex = -1;

				//Загружаем список в комбобокс принадлежности бригад 3
				avr_new.cbPrinadl_br3.Items.Clear();
				avr_new.cbPrinadl_br3.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
				avr_new.cbMasterAvrOtherIndex3 = avr_new.cbPrinadl_br3.Items.Add(Config.OtherWorkersName);
				avr_new.cbPrinadl_br3.SelectedIndex = -1;
				//Загружаем список всех РЭС-ов в комбобокс перемещения бригад 3
				avr_new.cbPerem_br3.Items.Clear();
				avr_new.cbPerem_br3.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
				Mysql.FiderInAvrToCombobox(avr_new.cbPerem_br3);
				avr_new.cbPerem_br3.SelectedIndex = -1;

				//Загружаем список в комбобокс принадлежности бригад 4
				avr_new.cbPrinadl_br4.Items.Clear();
				avr_new.cbPrinadl_br4.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
				avr_new.cbMasterAvrOtherIndex4 = avr_new.cbPrinadl_br4.Items.Add(Config.OtherWorkersName);
				avr_new.cbPrinadl_br4.SelectedIndex = -1;
				//Загружаем список всех РЭС-ов в комбобокс перемещения бригад 4
				avr_new.cbPerem_br4.Items.Clear();
				avr_new.cbPerem_br4.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
				Mysql.FiderInAvrToCombobox(avr_new.cbPerem_br4);
				avr_new.cbPerem_br4.SelectedIndex = -1;
				//конец нового в версии 1.0.5.0

				avr_new.ShowMasters_osm(1); //устанавливаем список из одного мастера для осмотра.
				avr_new.ShowMasters_avr(1); //устанавливаем список из одного мастера для АВР.

				avr_new.cbUser.Text = Config.LoginUser.Name; //автор отключения

                bool tmpBool = true;
                while (tmpBool)
                {
                    avr_new.ShowDialog(); //Открываем окно добавления нового отключения.
                    if (avr_new.DialogResult == DialogResult.OK)
                    {
                        if (SaveAvr(avr_new,0))
                        {
                            tmpBool = false;
                            JournalUpdate();
                        }
                    }
                    else
                    {
                        if (avr_new.DialogResult == DialogResult.Cancel) tmpBool = false;
                    }

                }
            }
            else {MessageBox.Show("У вас недостаточно прав для добавления новых отключений.");}
            timer1.Enabled = true; //Снова запустим таймер

        }
        /// <summary>
        /// Редактировать отключение
        /// </summary>
        private void EditAVR()
        {
            if (dgJournal.CurrentRow != null)//Усли есть что редактировать
            {
                timer1.Enabled = false; //Остановим таймер
                if ((Config.LoginUser.Grant == 'w') || (Config.LoginUser.Grant == 'x'))//Проверка прав пользователя на редактирование
                {
                    if ((Config.LoginUser.Grant == 'x') || ((Config.LoginUser.Grant == 'w') && (Config.LoginUser.ResId == 0/*Если пользователь редактор*/)) ||
                    (!(bool)dgJournal.CurrentRow.Cells["endofwork"].Value)) //Если фидер не введён в работу после ремонта
                    {
						Favr avr_edit = new Favr
						{
							CurJournalID = Convert.ToInt32(dgJournal.CurrentRow.Cells["id"].Value.ToString()),
							CheckFiders = false // не проверяем в ремонте ли фидер, т.к. это редактирование
						};

						//Формируем список организаций
						avr_edit.cbCompany.Items.Clear();
                        avr_edit.cbCompany.Items.AddRange(Config.Companies.Values.Select(p => p.Name).ToArray());
                        if (Config.LoginUser.CompanyId > 0)
                        {
                            avr_edit.cbCompany.Text = Config.Companies.Values.First(p => p.Id == Convert.ToInt32(dgJournal.CurrentRow.Cells["id_company"].Value.ToString())).Name;
                            avr_edit.cbCompany.Enabled = false; //Отключае изменение значений комбобокса
                        }

                        //Формируем список РЭСов
                        avr_edit.cbRes.Items.Clear();
                        avr_edit.cbRes.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
                        avr_edit.CurResID = Convert.ToInt32(dgJournal.CurrentRow.Cells["id_res"].Value.ToString());
                        avr_edit.cbRes.Text = Config.Reses.Values.First(p => p.Id == avr_edit.CurResID).Name;
                        avr_edit.cbRes.Enabled = false; //Отключае изменение значений комбобокса
                        avr_edit.LoadOsmMasters();//Загрузить мастеров для осмотра

                        avr_edit.d_otkl.Text = dgJournal.CurrentRow.Cells["d_otkl"].Value.ToString();
                        avr_edit.t_otkl.Text = dgJournal.CurrentRow.Cells["t_otkl"].Value.ToString();

                        avr_edit.cbTypeVL.Items.AddRange(Config.TypeVL);

                        try
                        {
                            avr_edit.cbTypeVL.SelectedIndex = Convert.ToInt32(dgJournal.CurrentRow.Cells["fidertype"].Value.ToString());
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка определения типа ВЛ");
                        }


                        avr_edit.cbFider.SelectedItem = dgJournal.CurrentRow.Cells["fidername"].Value.ToString();



                        if (Config.LoginUser.Grant != 'x')// Если пользователь не админ, то отключаем возможность смены фидера
                        {
                            avr_edit.cbFider.Enabled = false;
                            avr_edit.cbTypeVL.Enabled = false;
                        }


                        avr_edit.TP.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["TP"].Value.ToString());
                        avr_edit.SZO.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["SZO"].Value.ToString());
                        avr_edit.NP.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["NP"].Value.ToString());
                        avr_edit.Population.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["population"].Value.ToString());
						avr_edit.P_load.Value = Convert.ToDecimal(dgJournal.CurrentRow.Cells["P_load"].Value.ToString());       //Новое в версии 1.0.4.0
						
						//Новое в версии 1.0.4.0
						if ((Config.Fiders[dgJournal.CurrentRow.Cells["fidername"].Value.ToString()].P_load_l != 0) && (Config.Fiders[dgJournal.CurrentRow.Cells["fidername"].Value.ToString()].P_load_z != 0))
						{
							avr_edit.cbP_load.Items.Clear();
							avr_edit.cbP_load.Items.Add(Config.Fiders[dgJournal.CurrentRow.Cells["fidername"].Value.ToString()].P_load_l.ToString());
							avr_edit.cbP_load.Items.Add(Config.Fiders[dgJournal.CurrentRow.Cells["fidername"].Value.ToString()].P_load_z.ToString());
							avr_edit.cbP_load.Visible = true;
						}
						else
						{
							avr_edit.cbP_load.Visible = false;
						}



						avr_edit.kol_rise.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["kol_rise"].Value.ToString());	//Новое в версии 1.0.4.0
						avr_edit.P_rise.Value = Convert.ToDecimal(dgJournal.CurrentRow.Cells["P_rise"].Value.ToString());     //Новое в версии 1.0.4.0

						//1.0.3.3 получаем дату и время перезапитки не зависимо от осмотров и АВР
						avr_edit.t_vkl_vl.Text = dgJournal.CurrentRow.Cells["t_vkl_vl"].Value.ToString();
                        try
                        {
                            avr_edit.d_vkl_vl.Text = dgJournal.CurrentRow.Cells["d_vkl_vl"].Value.ToString();
                        }
                        catch
                        {
                            //
                        }


                   avr_edit.t_osm.Text = dgJournal.CurrentRow.Cells["t_osm"].Value.ToString();

                        if (avr_edit.t_osm.Text != "  :")//Если время осмотра указано, то
                        {
                            try
                            {
                                avr_edit.d_osm.Text = dgJournal.CurrentRow.Cells["d_osm"].Value.ToString();
                            }
                            catch
                            {
                                //
                            }
                            avr_edit.kol_br_osm.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["kol_br_osm"].Value.ToString());
                            avr_edit.kol_pers_osm.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["kol_pers_osm"].Value.ToString());
                            avr_edit.ShowMasters_osm((int)avr_edit.kol_br_osm.Value);

                            int mo_id1 = Convert.ToInt32(dgJournal.CurrentRow.Cells["master_osm_id1"].Value.ToString());
                            if (mo_id1 > 0)
                            {
                                string ofio = Config.Masters.Values.First(p => p.Id == mo_id1).Fio;
                                if (avr_edit.cbMasterOsm1.Items.IndexOf(ofio) < 0)
                                {
                                    avr_edit.cbMasterOsm1.Items.Add(ofio);
                                }
                                avr_edit.cbMasterOsm1.Text = ofio;
                                avr_edit.dolMasterOsm1.Text = Config.Masters.Values.First(p => p.Id == mo_id1).Dol;
                                avr_edit.telMasterOsm1.Text = Config.Masters.Values.First(p => p.Id == mo_id1).Tel;
                            }
                            int mo_id2 = Convert.ToInt32(dgJournal.CurrentRow.Cells["master_osm_id2"].Value.ToString());
                            if (mo_id2 > 0)
                            {
                                string ofio = Config.Masters.Values.First(p => p.Id == mo_id2).Fio;
                                if (avr_edit.cbMasterOsm2.Items.IndexOf(ofio) < 0)
                                {
                                    avr_edit.cbMasterOsm2.Items.Add(ofio);
                                }
                                avr_edit.cbMasterOsm2.Text = ofio;
                                avr_edit.dolMasterOsm2.Text = Config.Masters.Values.First(p => p.Id == mo_id2).Dol;
                                avr_edit.telMasterOsm2.Text = Config.Masters.Values.First(p => p.Id == mo_id2).Tel;
                            }
                            int mo_id3 = Convert.ToInt32(dgJournal.CurrentRow.Cells["master_osm_id3"].Value.ToString());
                            if (mo_id3 > 0)
                            {
                                string ofio = Config.Masters.Values.First(p => p.Id == mo_id3).Fio;
                                if (avr_edit.cbMasterOsm3.Items.IndexOf(ofio) < 0)
                                {
                                    avr_edit.cbMasterOsm3.Items.Add(ofio);
                                }
                                avr_edit.cbMasterOsm3.Text = ofio;
                                avr_edit.dolMasterOsm3.Text = Config.Masters.Values.First(p => p.Id == mo_id3).Dol;
                                avr_edit.telMasterOsm3.Text = Config.Masters.Values.First(p => p.Id == mo_id3).Tel;
                            }
                            int mo_id4 = Convert.ToInt32(dgJournal.CurrentRow.Cells["master_osm_id4"].Value.ToString());
                            if (mo_id4 > 0)
                            {
                                string ofio = Config.Masters.Values.First(p => p.Id == mo_id4).Fio;
                                if (avr_edit.cbMasterOsm4.Items.IndexOf(ofio) < 0)
                                {
                                    avr_edit.cbMasterOsm4.Items.Add(ofio);
                                }
                                avr_edit.cbMasterOsm4.Text = ofio;
                                avr_edit.dolMasterOsm4.Text = Config.Masters.Values.First(p => p.Id == mo_id4).Dol;
                                avr_edit.telMasterOsm4.Text = Config.Masters.Values.First(p => p.Id == mo_id4).Tel;
                            }


                            avr_edit.result_osm.Text = dgJournal.CurrentRow.Cells["result_osm"].Value.ToString();
                        }
                        else avr_edit.ShowMasters_osm(1);


						avr_edit.t_avr.Text = dgJournal.CurrentRow.Cells["t_avr"].Value.ToString();
                        //Загружаем список всех РЭС-ов в комбобокс места базирования бригад
                        avr_edit.cbBasaAvr.DataSource = Config.Reses.Values.Select(p => p.Name).ToList();
                        avr_edit.cbBasaAvr.SelectedIndex = -1;

                        //Загружаем список всех РЭС-ов в комбобокс принадлежности бригад
                        avr_edit.cbPrinadl_br.Items.Clear();
                        avr_edit.cbPrinadl_br.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
                        avr_edit.cbMasterAvrOtherIndex = avr_edit.cbPrinadl_br.Items.Add(Config.OtherWorkersName);
                        //Загружаем список всех РЭС-ов в комбобокс перемещения бригад
                        avr_edit.cbPerem_br.Items.Clear();
                        avr_edit.cbPerem_br.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
						/* было до версии 1.0.5.0
						int CurrentFiderID = -1;
                        try {CurrentFiderID = Convert.ToInt32(dgJournal.CurrentRow.Cells["id_fider"].Value.ToString());}
                        finally{Mysql.FiderInAvrToCombobox(avr_edit.cbPerem_br, CurrentFiderID);}
						avr_edit.cbPerem_br.SelectedIndex = -1;
						*/

						//Новое в версии 1.0.5.0
						//Загружаем список всех РЭС-ов в комбобокс принадлежности бригад 2
						avr_edit.cbPrinadl_br2.Items.Clear();
						avr_edit.cbPrinadl_br2.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
						avr_edit.cbMasterAvrOtherIndex2 = avr_edit.cbPrinadl_br2.Items.Add(Config.OtherWorkersName);
						//Загружаем список всех РЭС-ов в комбобокс перемещения бригад
						avr_edit.cbPerem_br2.Items.Clear();
						avr_edit.cbPerem_br2.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
						//Загружаем список всех РЭС-ов в комбобокс принадлежности бригад 3
						avr_edit.cbPrinadl_br3.Items.Clear();
						avr_edit.cbPrinadl_br3.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
						avr_edit.cbMasterAvrOtherIndex3 = avr_edit.cbPrinadl_br3.Items.Add(Config.OtherWorkersName);
						//Загружаем список всех РЭС-ов в комбобокс перемещения бригад
						avr_edit.cbPerem_br3.Items.Clear();
						avr_edit.cbPerem_br3.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
						//Загружаем список всех РЭС-ов в комбобокс принадлежности бригад 4
						avr_edit.cbPrinadl_br4.Items.Clear();
						avr_edit.cbPrinadl_br4.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());
						avr_edit.cbMasterAvrOtherIndex4 = avr_edit.cbPrinadl_br4.Items.Add(Config.OtherWorkersName);
						//Загружаем список всех РЭС-ов в комбобокс перемещения бригад
						avr_edit.cbPerem_br4.Items.Clear();
						avr_edit.cbPerem_br4.Items.AddRange(Config.Reses.Values.Select(p => p.Name).ToArray());

						int CurrentFiderID = -1;
						try { CurrentFiderID = Convert.ToInt32(dgJournal.CurrentRow.Cells["id_fider"].Value.ToString()); }
						finally
						{
							Mysql.FiderInAvrToCombobox(avr_edit.cbPerem_br, CurrentFiderID);
							Mysql.FiderInAvrToCombobox(avr_edit.cbPerem_br2, CurrentFiderID);
							Mysql.FiderInAvrToCombobox(avr_edit.cbPerem_br3, CurrentFiderID);
							Mysql.FiderInAvrToCombobox(avr_edit.cbPerem_br4, CurrentFiderID);
						}
						//конец нового в версии 1.0.5.0


						if (avr_edit.t_avr.Text != "  :")//Если время допуска к АВР указано, то
                        {
                            try
                            {
                                avr_edit.d_avr.Text = dgJournal.CurrentRow.Cells["d_avr"].Value.ToString();
                            }
                            catch
                            {
                                //
                            }
                            /*было до 1.0.3.3
                            avr_edit.t_vkl_vl.Text = dgJournal.CurrentRow.Cells["t_vkl_vl"].Value.ToString();
                            try
                            {
                                avr_edit.d_vkl_vl.Text = dgJournal.CurrentRow.Cells["d_vkl_vl"].Value.ToString();
                            }
                            catch
                            {
                                //
                            }*/
                            avr_edit.cbBasaAvr.Text = dgJournal.CurrentRow.Cells["basa_avr"].Value.ToString();

							avr_edit.cbPrinadl_br.Text = dgJournal.CurrentRow.Cells["Prinadl_br"].Value.ToString();
							avr_edit.LoadAvrMasters();
							//Новое в версии 1.0.5.0
							avr_edit.cbPrinadl_br2.Text = dgJournal.CurrentRow.Cells["Prinadl_br2"].Value.ToString();
							avr_edit.LoadAvrMasters2();
							avr_edit.cbPrinadl_br3.Text = dgJournal.CurrentRow.Cells["Prinadl_br3"].Value.ToString();
							avr_edit.LoadAvrMasters3();
							avr_edit.cbPrinadl_br4.Text = dgJournal.CurrentRow.Cells["Prinadl_br4"].Value.ToString();
							avr_edit.LoadAvrMasters4();
							//конец нового в версии 1.0.5.0

							avr_edit.kol_br_avr.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["kol_br_avr"].Value.ToString());
							avr_edit.kol_pers_avr.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["kol_pers_avr"].Value.ToString());
							avr_edit.ShowMasters_avr((int)avr_edit.kol_br_avr.Value);

							//Получить данные о 1 мастере
							int ma_id = Convert.ToInt32(dgJournal.CurrentRow.Cells["master_avr_id"].Value.ToString());
                            if (ma_id > 0)
                            {
                                string ofio = Config.Masters.Values.First(p => p.Id == ma_id).Fio;
                                if (avr_edit.cbMasterAvr.Items.IndexOf(ofio) < 0)//Если "Другой"
                                {
                                    avr_edit.cbMasterAvr.Items.Add(ofio);
                                    avr_edit.cbPrinadl_br.Items.Add(dgJournal.CurrentRow.Cells["Prinadl_br"].Value.ToString());
                                    avr_edit.cbPrinadl_br.Text = dgJournal.CurrentRow.Cells["Prinadl_br"].Value.ToString();
                                }
                                avr_edit.cbMasterAvr.Text = ofio;
                                avr_edit.dolMasterAvr.Text = Config.Masters.Values.First(p => p.Id == ma_id).Dol;
                                avr_edit.telMasterAvr.Text = Config.Masters.Values.First(p => p.Id == ma_id).Tel;
                            }
							//Новое в версии 1.0.5.0
							//Получить данные о 2 мастере
							int ma2_id = Convert.ToInt32(dgJournal.CurrentRow.Cells["master_avr2_id"].Value.ToString());
							if (ma2_id > 0)
							{
								string ofio = Config.Masters.Values.First(p => p.Id == ma2_id).Fio;
								if (avr_edit.cbMasterAvr2.Items.IndexOf(ofio) < 0)//Если "Другой"
								{
									avr_edit.cbMasterAvr2.Items.Add(ofio);
									avr_edit.cbPrinadl_br2.Items.Add(dgJournal.CurrentRow.Cells["Prinadl_br2"].Value.ToString());
									avr_edit.cbPrinadl_br2.Text = dgJournal.CurrentRow.Cells["Prinadl_br2"].Value.ToString();
								}
								avr_edit.cbMasterAvr2.Text = ofio;
								avr_edit.dolMasterAvr2.Text = Config.Masters.Values.First(p => p.Id == ma2_id).Dol;
								avr_edit.telMasterAvr2.Text = Config.Masters.Values.First(p => p.Id == ma2_id).Tel;
							}
							//Получить данные о 3 мастере
							int ma3_id = Convert.ToInt32(dgJournal.CurrentRow.Cells["master_avr3_id"].Value.ToString());
							if (ma3_id > 0)
							{
								string ofio = Config.Masters.Values.First(p => p.Id == ma3_id).Fio;
								if (avr_edit.cbMasterAvr3.Items.IndexOf(ofio) < 0)//Если "Другой"
								{
									avr_edit.cbMasterAvr3.Items.Add(ofio);
									avr_edit.cbPrinadl_br3.Items.Add(dgJournal.CurrentRow.Cells["Prinadl_br3"].Value.ToString());
									avr_edit.cbPrinadl_br3.Text = dgJournal.CurrentRow.Cells["Prinadl_br3"].Value.ToString();
								}
								avr_edit.cbMasterAvr3.Text = ofio;
								avr_edit.dolMasterAvr3.Text = Config.Masters.Values.First(p => p.Id == ma3_id).Dol;
								avr_edit.telMasterAvr3.Text = Config.Masters.Values.First(p => p.Id == ma3_id).Tel;
							}
							//Получить данные о 4 мастере
							int ma4_id = Convert.ToInt32(dgJournal.CurrentRow.Cells["master_avr4_id"].Value.ToString());
							if (ma4_id > 0)
							{
								string ofio = Config.Masters.Values.First(p => p.Id == ma4_id).Fio;
								if (avr_edit.cbMasterAvr4.Items.IndexOf(ofio) < 0)//Если "Другой"
								{
									avr_edit.cbMasterAvr4.Items.Add(ofio);
									avr_edit.cbPrinadl_br4.Items.Add(dgJournal.CurrentRow.Cells["Prinadl_br4"].Value.ToString());
									avr_edit.cbPrinadl_br4.Text = dgJournal.CurrentRow.Cells["Prinadl_br4"].Value.ToString();
								}
								avr_edit.cbMasterAvr4.Text = ofio;
								avr_edit.dolMasterAvr4.Text = Config.Masters.Values.First(p => p.Id == ma4_id).Dol;
								avr_edit.telMasterAvr4.Text = Config.Masters.Values.First(p => p.Id == ma4_id).Tel;
							}
							//конец нового в версии 1.0.5.0

                            avr_edit.AGP.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["teh_agp"].Value.ToString());
                            avr_edit.BKM.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["teh_bkm"].Value.ToString());
                            avr_edit.Kran.Value = Convert.ToInt32(dgJournal.CurrentRow.Cells["teh_kran"].Value.ToString());
                            avr_edit.t_plan_okon.Text = dgJournal.CurrentRow.Cells["t_plan_okon"].Value.ToString();
                        }
						else avr_edit.ShowMasters_avr(1);  //Новое в версии 1.0.5.0

						if ((bool)dgJournal.CurrentRow.Cells["endofwork"].Value)//Фидер включен в работу Только для админов и редакторов
                        {
                            avr_edit.cbEndOfWork.Checked = true;

							if ((bool)dgJournal.CurrentRow.Cells["apvrpv"].Value)   //АПВ РПВ успешно
								avr_edit.cbAPVRPV.Checked = true;

							avr_edit.d_vkl_potr.Text = dgJournal.CurrentRow.Cells["d_vkl_potr"].Value.ToString();
                            avr_edit.t_vkl_potr.Text = dgJournal.CurrentRow.Cells["t_vkl_potr"].Value.ToString();

							avr_edit.cbPerem_br.Text = dgJournal.CurrentRow.Cells["perem_br"].Value.ToString();
							avr_edit.cbPerem_br2.Text = dgJournal.CurrentRow.Cells["perem_br2"].Value.ToString(); //Новое в версии 1.0.5.0
							avr_edit.cbPerem_br3.Text = dgJournal.CurrentRow.Cells["perem_br3"].Value.ToString(); //Новое в версии 1.0.5.0
							avr_edit.cbPerem_br4.Text = dgJournal.CurrentRow.Cells["perem_br4"].Value.ToString(); //Новое в версии 1.0.5.0
							avr_edit.obem_rabot.Text = dgJournal.CurrentRow.Cells["obem_rabot"].Value.ToString();

                        }

                        avr_edit.cbUser.Text = dgJournal.CurrentRow.Cells["username"].Value.ToString(); //автор отключения
                        bool tmpBool = true;
                        while (tmpBool)
                        {
                            avr_edit.ShowDialog(); //Открываем окно добавления нового отключения.
                            if (avr_edit.DialogResult == DialogResult.OK)
                            {
                                if (SaveAvr(avr_edit, 1))
                                {
                                    tmpBool = false;
                                    JournalUpdate();
                                }
                            }
                            else
                            {
                                if (avr_edit.DialogResult == DialogResult.Cancel) tmpBool = false;
                            }

                        }
                    }
                    else { MessageBox.Show("Объект уже введён в работу после ремонта. Редактирование невозможно."); }
                }
                else { MessageBox.Show("У вас недостаточно прав для изменения отключений."); }
                timer1.Enabled = true; //Снова запустим таймер
            }
        }


        /// <summary>
        /// Запись в базу данных отключений
        /// </summary>
        /// <param name="avr">Окно с данными</param>
        /// <param name="Operation">Тип операции: 0 - новое отключение, 1 - обновить данные о существующем отключении</param>
        /// <returns></returns>
        private bool SaveAvr(Favr avr, byte Operation)
        {
            timer1.Enabled = false; //Остановим таймер

			Config.Journal javr = new Config.Journal
			{
				id = avr.CurJournalID,
				id_company = Config.Companies[avr.cbCompany.Text].Id,
				id_res = Config.Reses[avr.cbRes.Text].Id,
				id_fider = Config.Fiders[avr.cbFider.Text].Id,
				TP = (int)avr.TP.Value,
				SZO = (int)avr.SZO.Value,
				NP = (int)avr.NP.Value,
				population = (int)avr.Population.Value,
				P_load = avr.P_load.Value,        //Новое в версии 1.0.4.0
				kol_rise = (int)avr.kol_rise.Value,    //Новое в версии 1.0.4.0
				P_rise = avr.P_rise.Value,        //Новое в версии 1.0.4.0
				d_otkl = avr.d_otkl.Value.ToString("yyyy-MM-dd"),
				t_otkl = avr.t_otkl.Text
			};

			//1.0.3.3 Сохранять дату и время перезапитки независимо от осмотров и АВР
			if (avr.t_vkl_vl.Text != "  :")
            {
                javr.d_vkl_vl = avr.d_vkl_vl.Value.ToString("yyyy-MM-dd");
                javr.t_vkl_vl = avr.t_vkl_vl.Text;
            }


            /////Осмотр
            if (avr.t_osm.Text != "  :")//Если время осмотра указано, то
            {
                javr.d_osm = avr.d_osm.Value.ToString("yyyy-MM-dd");
                javr.t_osm = avr.t_osm.Text;
                javr.kol_br_osm = (int)avr.kol_br_osm.Value;
                javr.kol_pers_osm = (int)avr.kol_pers_osm.Value;
                if (avr.cbMasterOsm1.Text!="")
                    javr.master_osm_id1 = Config.Masters.Values.First(p => p.Fio == avr.cbMasterOsm1.Text).Id;
                if (avr.cbMasterOsm2.Text != "")
                    javr.master_osm_id2 = Config.Masters.Values.First(p => p.Fio == avr.cbMasterOsm2.Text).Id;
                if (avr.cbMasterOsm3.Text != "")
                    javr.master_osm_id3 = Config.Masters.Values.First(p => p.Fio == avr.cbMasterOsm3.Text).Id;
                if (avr.cbMasterOsm4.Text != "")
                    javr.master_osm_id4 = Config.Masters.Values.First(p => p.Fio == avr.cbMasterOsm4.Text).Id;
                javr.result_osm = avr.result_osm.Text;
                ///
            }

            /////АВР
            if (avr.t_avr.Text != "  :")//Если время допуска к АВР указано, то
            {
                javr.d_avr = avr.d_avr.Value.ToString("yyyy-MM-dd");
                javr.t_avr = avr.t_avr.Text;
                /*было до 1.0.3.3
                if(avr.t_vkl_vl.Text != "  :")
                {
                    javr.d_vkl_vl = avr.d_vkl_vl.Value.ToString("yyyy-MM-dd");
                    javr.t_vkl_vl = avr.t_vkl_vl.Text;
                }*/
                javr.kol_br_avr = (int)avr.kol_br_avr.Value;
                javr.kol_pers_avr = (int)avr.kol_pers_avr.Value;
                if (avr.cbMasterAvr.Text != "")
                    javr.master_avr_id = Config.Masters.Values.First(p => p.Fio == avr.cbMasterAvr.Text).Id;

				//Новое в версии 1.0.5.0
				if (avr.cbMasterAvr2.Text != "")
					javr.master_avr2_id = Config.Masters.Values.First(p => p.Fio == avr.cbMasterAvr2.Text).Id;
				if (avr.cbMasterAvr3.Text != "")
					javr.master_avr3_id = Config.Masters.Values.First(p => p.Fio == avr.cbMasterAvr3.Text).Id;
				if (avr.cbMasterAvr4.Text != "")
					javr.master_avr4_id = Config.Masters.Values.First(p => p.Fio == avr.cbMasterAvr4.Text).Id;
				//Конец нового в версии 1.0.5.0

				javr.basa_avr = avr.cbBasaAvr.Text;
                javr.teh_agp = (int)avr.AGP.Value;
                javr.teh_bkm = (int)avr.BKM.Value;
                javr.teh_kran = (int)avr.Kran.Value;
                javr.prinadl_br = avr.cbPrinadl_br.Text;
				javr.prinadl_br2 = avr.cbPrinadl_br2.Text; //Новое в версии 1.0.5.0
				javr.prinadl_br3 = avr.cbPrinadl_br3.Text; //Новое в версии 1.0.5.0
				javr.prinadl_br4 = avr.cbPrinadl_br4.Text; //Новое в версии 1.0.5.0
				if (avr.t_plan_okon.Text != "  :")
                    javr.t_plan_okon = avr.t_plan_okon.Text;

			}

			//Завершение работ
			if (avr.t_vkl_potr.Text != "  :")//Если время включения потребителей указано, то
            {
                javr.obem_rabot = avr.obem_rabot.Text;
				javr.perem_br = avr.cbPerem_br.Text;
				javr.perem_br2 = avr.cbPerem_br2.Text;//Новое в версии 1.0.5.0
				javr.perem_br3 = avr.cbPerem_br3.Text;//Новое в версии 1.0.5.0
				javr.perem_br4 = avr.cbPerem_br4.Text;//Новое в версии 1.0.5.0
				javr.d_vkl_potr = avr.d_vkl_potr.Value.ToString("yyyy-MM-dd");
                javr.t_vkl_potr = avr.t_vkl_potr.Text;
				if (avr.cbAPVRPV.Checked) javr.apvrpv = 1;//Новое в версии 1.0.5.0
				javr.endofwork = 1;
            }
            javr.id_user = Config.LoginUser.Id;

            timer1.Enabled = true; //Снова запустим таймер

            if (Operation == 0) // запись нового отключения
            {
                //Запишем результат в базу
                if (!Mysql.AddNewAvr(javr))
                {
                    MessageBox.Show("При записи отключения в базу произошла ошибка!");
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (Operation == 1) // Обновить данные об отключения
            {
                if (!Mysql.UpdateAvr(javr))
                {
                    MessageBox.Show("При записи отключения в базу произошла ошибка!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;



        }

        /// <summary>
        /// Удалить выбранное отключение
        /// </summary>
        private void DeleteAVR()
        {
            if (dgJournal.CurrentRow != null)//Усли есть что удалять
            {
                timer1.Enabled = false; //Остановим таймер
                if ((Config.LoginUser.Grant == 'w') || (Config.LoginUser.Grant == 'x'))//Проверка прав пользователя на редактирование
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить отключение \n" + dgJournal.CurrentRow.Cells["fidername"].Value.ToString(), "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Mysql.DeleteAvr(dgJournal.CurrentRow.Cells["id"].Value.ToString());
                        JournalUpdate();
                        dgJournal.CurrentCell = dgJournal.FirstDisplayedCell;
                    }
                }
                else{MessageBox.Show("У вас недостаточно прав для удаления отключений.");}
                timer1.Enabled = true; //Снова запустим таймер
            }
        }

        private void ExportJournalToExcel(object sender)
        {
            timer1.Enabled= false; //Остановим таймер
//            timer1.Enabled = true; //Снова запустим таймер

            Fexport export = new Fexport();

            for(int i=0;i<24;i++)
            {
                export.eTime.Items.Add(i.ToString("00")+":00");
            }

            /*
            //Получаем чётное число времени. (нужно проверять как работает)
            int t1 = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int t2;
            /// Нужно, чтобы 23:00 отображалось
            if (t1 == 23)
                    t2 = 0;
                else
                    t2 = t1 % 2;
            t1 += t2;*/
            int t1 = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int t2 = Convert.ToInt32(DateTime.Now.ToString("mm"));
            if (t2 > 5) t1++;


            export.eTime.Text = t1.ToString("00")+":00";
            export.ePath.Text = Config.ExportPath;
			if (sender is ToolStripMenuItem)
			{
				if ((sender as ToolStripMenuItem).Name == "f15") export.FormsControl.SelectedIndex = 1;
				if ((sender as ToolStripMenuItem).Name == "f4_2020") export.cbFormrVersion.SelectedIndex = 1;
				if ((sender as ToolStripMenuItem).Name == "f4_2016") export.cbFormrVersion.SelectedIndex = 0;
			}
			else
				export.cbFormrVersion.SelectedIndex = export.cbFormrVersion.Items.Count - 1;


			export.ShowDialog();

            timer1.Enabled = true; //Снова запустим таймер
        }


        private void BtnAddNewAvr(object sender, EventArgs e)
        {
            //отключаем перерисовку объекта
            //dgJournal.RowPrePaint -= new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgJournal_RowPrePaint);
            AddNewAVR();
            //Включаем перерисовку объекта
            //dgJournal.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgJournal_RowPrePaint);
        }

        private void BtnEditAvr(object sender, EventArgs e)
        {
            //отключаем перерисовку объекта
            //dgJournal.RowPrePaint -= new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgJournal_RowPrePaint);
            EditAVR();
            //Включаем перерисовку объекта
            //dgJournal.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgJournal_RowPrePaint);
        }

        private void Fmain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) Refresh();
            
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            JournalUpdate();

            //Проверка необходимости обновления словарей фидеров и мастеров
            int MAXUpdateId = Config.MAXUpdateLogId;
            Mysql.GetMaxUpdateId();

            if (Config.MAXUpdateLogId!= MAXUpdateId)
            {
                //StatusBarUpdateInfo.Visible = true;
                //string tstr = StatusBarUpdateInfo.Text;
                StatusBarUpdateInfo.Text += " Обновление словарей - "+DateTime.Now.ToShortTimeString()+".";
                Application.DoEvents();
                Mysql.GetFiders();
                Mysql.GetMasters();
                //StatusBarUpdateInfo.Text = tstr;
               //StatusBarUpdateInfo.Visible = false;

            }
        }

        private void BtnDeleteAvr(object sender, EventArgs e)
        {
            DeleteAVR();

        }

        private void BtnExportJournal(object sender, EventArgs e)
        {
            ExportJournalToExcel(sender);
        }
        
        
        
        ////////////////////////////////////Настройки программы
        /// <summary>
        /// Добавление нового фидера
        /// </summary>
        private void AddFiderMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false; //Остановим таймер


            SetupForms.AddNewFiderInBase fAddNewFider = new SetupForms.AddNewFiderInBase();
            fAddNewFider.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            if (Config.LoginUser.ResId > 0)
                fAddNewFider.cbRes.DataSource = Config.Reses.Values.Where(i => i.Id == Config.LoginUser.ResId).Select(p => p.Name).ToList();
            else
            {
                fAddNewFider.cbRes.DataSource = Config.Reses.Values.Where(i => i.FromCompanyId == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                fAddNewFider.cbRes.SelectedIndex = -1;
            }

            fAddNewFider.cbTypeVL.Items.AddRange(Config.TypeVL);
            fAddNewFider.cbTypeVL.SelectedIndex = 0;

            //fAddNewFider.edFiderName.Visible = false;

            fAddNewFider.ShowDialog();
            if (fAddNewFider.DialogResult == DialogResult.No) MessageBox.Show("При добавлении нового объекта возникла ошибка. Обратитесь к разработчику.");
            if (fAddNewFider.DialogResult == DialogResult.Yes) MessageBox.Show("Новый объект успешно внесён в базу.");
            timer1.Enabled = true; //Снова запустим таймер
        }

        //Имопрт фидеров
        private void ImportFidersMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false; //Остановим таймер


            SetupForms.ImportFidersToBase fImportFiders = new SetupForms.ImportFidersToBase();

            fImportFiders.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            if (Config.LoginUser.ResId > 0)
                fImportFiders.cbRes.DataSource = Config.Reses.Values.Where(i => i.Id == Config.LoginUser.ResId).Select(p => p.Name).ToList();
            else
            {
                fImportFiders.cbRes.DataSource = Config.Reses.Values.Where(i => i.FromCompanyId == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                fImportFiders.cbRes.SelectedIndex = -1;
            }
            fImportFiders.cbTypeVL.Items.AddRange(Config.TypeVL);
            fImportFiders.cbTypeVL.SelectedIndex = 0;
            

            fImportFiders.ShowDialog();
            timer1.Enabled = true; //Снова запустим таймер
        }


        /// <summary>
        /// Удаление Фидера
        /// </summary>
        private void DelFiderMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false; 

            SetupForms.SelectFiderInBase SelectFider = new SetupForms.SelectFiderInBase();
            SelectFider.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            if (Config.LoginUser.ResId > 0)
                SelectFider.cbRes.DataSource = Config.Reses.Values.Where(i => i.Id == Config.LoginUser.ResId).Select(p => p.Name).ToList();
            else
            {
                SelectFider.cbRes.DataSource = Config.Reses.Values.Where(i => i.FromCompanyId == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                SelectFider.cbRes.SelectedIndex = -1;
            }

            SelectFider.CurResID = Config.LoginUser.ResId;
            SelectFider.cbTypeVL.Items.AddRange(Config.TypeVL);
            SelectFider.cbTypeVL.SelectedIndex = 0;
            SelectFider.LoadFiders(0);
            
            SelectFider.ShowDialog();
            if (SelectFider.DialogResult== DialogResult.Yes)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить из базы:\n" + SelectFider.cbFider.Text, "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!Mysql.DeleteFiderFromBase(Config.Fiders[SelectFider.cbFider.Text].Id)) MessageBox.Show("При удалении объект возникла ошибка. Обратитесь к разработчику.");
                }

            }
			if (SelectFider.DialogResult == DialogResult.OK)
			{
				if (MessageBox.Show("Вы уверены, что хотите произвести групповое удаление фидеров из базы?", "Групповое удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (!Mysql.DeleteFidersGroupFromBase(Config.Companies[SelectFider.cbCompany.Text].Id, Config.Reses[SelectFider.cbRes.Text].Id, SelectFider.cbTypeVL.SelectedIndex)) MessageBox.Show("При групповом удалении объектов возникла ошибка. Обратитесь к разработчику.");
				}

			}

			timer1.Enabled = true; //Снова запустим таймер
        }


        /// <summary>
        /// Редактирование фидера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditFiderMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            SetupForms.SelectFiderInBase SelectFider = new SetupForms.SelectFiderInBase();
            SelectFider.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            if (Config.LoginUser.ResId > 0)
                SelectFider.cbRes.DataSource = Config.Reses.Values.Where(i => i.Id == Config.LoginUser.ResId).Select(p => p.Name).ToList();
            else
            {
                SelectFider.cbRes.DataSource = Config.Reses.Values.Where(i => i.FromCompanyId == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                SelectFider.cbRes.SelectedIndex = -1;
            }

            SelectFider.CurResID = Config.LoginUser.ResId;
            SelectFider.cbTypeVL.Items.AddRange(Config.TypeVL);
            SelectFider.cbTypeVL.SelectedIndex = 0;
            SelectFider.LoadFiders(0);

            ///Сначала выберем фидер для редактирования
            SelectFider.ShowDialog();
            if (SelectFider.DialogResult == DialogResult.Yes)
            {
				SetupForms.AddNewFiderInBase fAddNewFider = new SetupForms.AddNewFiderInBase
				{
					Text = "Редактирование объекта"
				};

				Config.Fider edFider = new Config.Fider();
                edFider = Config.Fiders[SelectFider.cbFider.Text];

                fAddNewFider.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == edFider.FromCompanyId).Select(p => p.Name).ToList();

                fAddNewFider.cbTypeVL.Items.AddRange(Config.TypeVL);
                fAddNewFider.cbTypeVL.SelectedIndex = edFider.FiderType;
                fAddNewFider.cbTypeVL.Enabled = false;


                fAddNewFider.cbRes.DataSource = Config.Reses.Values.Where(i => i.Id == edFider.FromResId).Select(p => p.Name).ToList();
                fAddNewFider.edFiderName.Text = edFider.Name;
                fAddNewFider.ldot.Visible = false;

                if (((Config.LoginUser.Grant == 'w') && (Config.LoginUser.ResId == 0)) || ((Config.LoginUser.Grant == 'w') && (Config.UserCanRenameFeeder)) || ((Config.LoginUser.Grant == 'x'))) //Если Редактор или администратор или в настройках разрешено редактировать название пользователю
                {
                    fAddNewFider.edFiderName.Enabled = true;
                    fAddNewFider.ldot.Visible = true;
                }
                fAddNewFider.DotPanel.Visible = false;
                fAddNewFider.FiderId = edFider.Id;
                fAddNewFider.NP.Value = edFider.NP;
                fAddNewFider.Population.Value = edFider.Population;
                fAddNewFider.SZO.Value = edFider.SZO;
                fAddNewFider.TP.Value = edFider.TP;
				fAddNewFider.P_load_l.Value = edFider.P_load_l; //Новое в версии 1.0.4.0
				fAddNewFider.P_load_z.Value = edFider.P_load_z; //Новое в версии 1.0.4.0

				fAddNewFider.ShowDialog();
                if (fAddNewFider.DialogResult == DialogResult.No) MessageBox.Show("При записи изменений в базу возникла ошибка. Обратитесь к разработчику.");
                if (fAddNewFider.DialogResult == DialogResult.Yes) MessageBox.Show("Изменения успешно внесены в базу.");


            }
            timer1.Enabled = true; //Снова запустим таймер
            JournalUpdate();

        }
        /// <summary>
        /// Добавить Нового Руководителя бригады
        /// </summary>
        /// <returns>Нужно ли обновлять словари true-да, false-нет</returns>
        public static bool AddMasterMenuExt()
        {
            SetupForms.AddNewMaster fNewMaster = new SetupForms.AddNewMaster();
            fNewMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            if (Config.LoginUser.ResId > 0)
            {
                fNewMaster.cbRes.Items.Clear();
                fNewMaster.cbRes.Items.AddRange(Config.Reses.Values.Where(i => i.Id == Config.LoginUser.ResId).Select(p => p.Name).ToArray());
                fNewMaster.cbRes.SelectedIndex = 0;
                //            fNewMaster.cbRes.DataSource = config.Reses.Values.Where(i => i.Id == config.LoginUser.ResId).Select(p => p.Name).ToList();
            }
            else
            {
                fNewMaster.cbRes.Items.Clear();
                fNewMaster.cbRes.Items.AddRange(Config.Reses.Values.Where(i => i.FromCompanyId == Config.LoginUser.CompanyId).Select(p => p.Name).ToArray());
                //                fNewMaster.cbRes.DataSource = config.Reses.Values.Where(i => i.FromCompanyId == config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                fNewMaster.cbRes.SelectedIndex = -1;
            }
            fNewMaster.cbRes.Items.Add(Config.OtherWorkersName);
            fNewMaster.ShowDialog();
            if (fNewMaster.DialogResult == DialogResult.Yes)
            {
                if (fNewMaster.cbRes.Text != Config.OtherWorkersName) ///Добавление работника РЭС
                {
                    if (Mysql.AddNewMasterInBase(fNewMaster.edFIO.Text, fNewMaster.edDol.Text, fNewMaster.edTel.Text, Config.Reses[fNewMaster.cbRes.Text].Id, Config.Companies[fNewMaster.cbCompany.Text].Id))
                    {
                        MessageBox.Show("Новый работник успешно внесён в базу.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("При добавлении нового работника возникла ошибка. Обратитесь к разработчику.");
                        return false;
                    }
                }
                else
                { //Добавление "Другого"
                    if (Mysql.AddNewMasterInBase(fNewMaster.edFIO.Text, fNewMaster.edDol.Text, fNewMaster.edTel.Text, Config.OtherWorkersId, Config.Companies[fNewMaster.cbCompany.Text].Id, Config.Filials[fNewMaster.cbOtherPrinandl.Text].Id))
                    {
                        MessageBox.Show("Новый коммандированный успешно внесён в базу.");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("При добавлении нового работника возникла ошибка. Обратитесь к разработчику.");
                        return false;
                    }
                }

            }
            else
            {
                return false;
            }
            

        }

        private void AddMasterMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false; //Остановим таймер
            AddMasterMenuExt();
            timer1.Enabled = true; //Снова запустим таймер
        }

        private void EditMasterMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            SetupForms.SelectMasterInBase SelectMaster = new SetupForms.SelectMasterInBase();
            SelectMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            if (Config.LoginUser.ResId > 0)
            {
                SelectMaster.cbRes.Items.Clear();
                SelectMaster.cbRes.Items.AddRange(Config.Reses.Values.Where(i => i.Id == Config.LoginUser.ResId).Select(p => p.Name).ToArray());
                SelectMaster.LoadMasters(Config.LoginUser.ResId);
                SelectMaster.cbRes.SelectedIndex = 0;
            }
            else
            {
                SelectMaster.cbRes.Items.Clear();
                SelectMaster.cbRes.Items.AddRange(Config.Reses.Values.Where(i => i.FromCompanyId == Config.LoginUser.CompanyId).Select(p => p.Name).ToArray());
                SelectMaster.cbRes.SelectedIndex = -1;
            }
            SelectMaster.cbRes.Items.Add(Config.OtherWorkersName);
            SelectMaster.ShowDialog();

            if (SelectMaster.DialogResult == DialogResult.Yes)
            {
				SetupForms.AddNewMaster fEditMaster = new SetupForms.AddNewMaster
				{
					Text = "Редактирование работника",
					MasterId = Config.Masters[SelectMaster.cbMasters.Text].Id,
					MasterFio = SelectMaster.cbMasters.Text
				};

				fEditMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.Masters[SelectMaster.cbMasters.Text].FromCompanyId).Select(p => p.Name).ToList();
                fEditMaster.cbRes.Items.Clear();
                fEditMaster.cbRes.Items.AddRange(Config.Reses.Values.Where(i => i.Id == Config.Masters[SelectMaster.cbMasters.Text].FromResId).Select(p => p.Name).ToArray());

                if (Config.Masters[SelectMaster.cbMasters.Text].FromResId==Config.OtherWorkersId)
                {
                    //Редактирование "Другого"
                    fEditMaster.cbRes.Items.Add(Config.OtherWorkersName);
                    fEditMaster.cbRes.SelectedIndex = 0;
                    fEditMaster.ShowHidePrinadl();
                    string ttt = Config.Filials.Values.First(i => i.Id == Config.Masters[SelectMaster.cbMasters.Text].FromFilialId).Name;
                    fEditMaster.cbOtherPrinandl.Text = ttt;
                }

                fEditMaster.cbRes.SelectedIndex = 0;
                fEditMaster.edFIO.Text = Config.Masters[SelectMaster.cbMasters.Text].Fio;
                fEditMaster.edDol.Text = Config.Masters[SelectMaster.cbMasters.Text].Dol;
                fEditMaster.edTel.Text = Config.Masters[SelectMaster.cbMasters.Text].Tel;
                
                fEditMaster.ShowDialog();
                if (fEditMaster.DialogResult == DialogResult.Yes)
                {
                    int filialid = 0;
                    if (fEditMaster.cbRes.Text== Config.OtherWorkersName) //Если "Другой"
                    {
                        filialid = Config.Filials[fEditMaster.cbOtherPrinandl.Text].Id;
                    }
                    if (Mysql.EditMasterInBase(fEditMaster.MasterId, fEditMaster.edFIO.Text, fEditMaster.edDol.Text, fEditMaster.edTel.Text,filialid))
                        MessageBox.Show("Изменения успешно внесены в базу.");
                    else MessageBox.Show("При записи изменений в базу возникла ошибка. Обратитесь к разработчику.");

                }


            }
            timer1.Enabled = true; //Снова запустим таймер
        }


        private void DelMasterMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            SetupForms.SelectMasterInBase SelectMaster = new SetupForms.SelectMasterInBase();
            SelectMaster.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            if (Config.LoginUser.ResId > 0)
            {
                SelectMaster.cbRes.Items.Clear();
                SelectMaster.cbRes.Items.AddRange(Config.Reses.Values.Where(i => i.Id == Config.LoginUser.ResId).Select(p => p.Name).ToArray());
                SelectMaster.LoadMasters(Config.LoginUser.ResId);
                SelectMaster.cbRes.SelectedIndex = 0;
            }
            else
            {
                SelectMaster.cbRes.Items.Clear();
                SelectMaster.cbRes.Items.AddRange(Config.Reses.Values.Where(i => i.FromCompanyId == Config.LoginUser.CompanyId).Select(p => p.Name).ToArray());
                SelectMaster.cbRes.SelectedIndex = -1;
            }
            //SelectMaster.cbMasters.SelectedIndex = -1;
            SelectMaster.cbRes.Items.Add(Config.OtherWorkersName);
            SelectMaster.ShowDialog();
            if (SelectMaster.DialogResult == DialogResult.Yes)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить из базы работнка:\n"+ SelectMaster.cbMasters.Text, "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!Mysql.DeleteMasterFromBase(Config.Masters[SelectMaster.cbMasters.Text].Id)) MessageBox.Show("При удалении работника возникла ошибка. Обратитесь к разработчику.");
                }

            }
            timer1.Enabled = true; //Снова запустим таймер


        }

        private void AddUserMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false; //Остановим таймер

            SetupForms.AddNewUser fNewUser = new SetupForms.AddNewUser();
            if (Config.LoginUser.CompanyId > 0) //и если это простой пользователь, то указываем и его РЭС
                fNewUser.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            else
                fNewUser.cbCompany.DataSource = Config.Companies.Values.Select(p => p.Name).ToList();
            if (Config.LoginUser.ResId > 0)
                fNewUser.cbRes.DataSource = Config.Reses.Values.Where(i => i.Id == Config.LoginUser.ResId).Select(p => p.Name).ToList();
            else
            {
                if (Config.LoginUser.CompanyId > 0) //и если это простой пользователь, то указываем и его РЭС
                    fNewUser.cbRes.DataSource = Config.Reses.Values.Where(i => i.FromCompanyId == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
                else
                    fNewUser.cbRes.DataSource = Config.Reses.Values.Select(p => p.Name).ToList();
                fNewUser.cbRes.SelectedIndex = -1;
            }
            if (Config.LoginUser.Grant != 'x')//Если пользователь не админ, то
            {
                fNewUser.rbDrant_x.Enabled = false; //он не может дать админские права
                fNewUser.checkBox1.Visible = false; //и не может создать пользователя без привязки к РЭС
            }

            fNewUser.ShowDialog();
            if (fNewUser.DialogResult == DialogResult.No) MessageBox.Show("При добавлении нового пользователя возникла ошибка. Обратитесь к разработчику.");
            if (fNewUser.DialogResult == DialogResult.Yes) MessageBox.Show("Новый пользователь успешно внесён в базу.");
            timer1.Enabled = true; //Снова запустим таймер


        }
        private void AddNewCompanyMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false; //Остановим таймер
            if(Mysql.GetCountCompanyInBase()==0)
            {
                SetupForms.AddNewCompany fNewCompany = new SetupForms.AddNewCompany();
                fNewCompany.ShowDialog();
                if (fNewCompany.DialogResult == DialogResult.Yes)
                {
                    if (Mysql.AddNewCompanyInBase(fNewCompany.edCompany.Text, fNewCompany.edFullName.Text))
                        MessageBox.Show("Новое ПО успешно внесено в базу. ");
                    else MessageBox.Show("При добавлении нового ПО возникла ошибка. Обратитесь к разработчику."); ;
                }
            }
            else MessageBox.Show("В базу уже внесено ПО. ");
            timer1.Enabled = true; //Снова запустим таймер
        }

        private void AddNewPrinadlMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false; //Остановим таймер
            SetupForms.AddNewCompany fNewCompany = new SetupForms.AddNewCompany();
            fNewCompany.label1.Visible = false;
            fNewCompany.edFullName.Visible = false;
            fNewCompany.label8.Text = "Название филиала";
            fNewCompany.label2.Text = "Образец: Оренбургэнерго - Оренбургское ПО";
            fNewCompany.Text = "Добавить новый филиал";

            fNewCompany.ShowDialog();
            if (fNewCompany.DialogResult == DialogResult.Yes)
            {
                if (Mysql.AddNewFilialInBase(fNewCompany.edCompany.Text))
                    MessageBox.Show("Новоый филиал успешно внесено в базу. ");
                else MessageBox.Show("При добавлении нового филиала возникла ошибка. Обратитесь к разработчику."); ;
                
            }
            timer1.Enabled = true; //Снова запустим таймер
        }



        private void AddNewResMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false; //Остановим таймер

            SetupForms.AddNewRes fNewRes = new SetupForms.AddNewRes();
            if (Config.LoginUser.CompanyId > 0) //и если это простой пользователь, то указываем и его РЭС
                fNewRes.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            else
                fNewRes.cbCompany.DataSource = Config.Companies.Values.Select(p => p.Name).ToList();

            fNewRes.ShowDialog();
            if (fNewRes.DialogResult == DialogResult.No) MessageBox.Show("При добавлении нового РЭС-а возникла ошибка. Обратитесь к разработчику.");
            if (fNewRes.DialogResult == DialogResult.Yes) MessageBox.Show("Новый РЭС успешно внесён в базу. ");
            timer1.Enabled = true; //Снова запустим таймер
        }

        private void PublicSetupMenu_Click(object sender, EventArgs e)
        {
            //
            SetupForms.PublicSetup PubSetup = new SetupForms.PublicSetup();
            PubSetup.eddbMySQL.Text = Config.dbMySQL;
            PubSetup.edhostMySQL.Text = Config.hostMySQL;
            PubSetup.edTimer.Value = (Config.Timer / 1000);
            PubSetup.edExportPath.Text = Config.ExportPath;
            PubSetup.edUpdatePath.Text = Config.UpdatePath;
            if (Config.CheckStartUpdate) PubSetup.checkStartUpdate.Checked = true;
            PubSetup.edSortvl10.Text = Config.Sortvl10;
            PubSetup.edSortvl04.Text = Config.Sortvl04;
            if (Config.UserCanRenameFeeder) PubSetup.cbUserCanRenameFeeder.Checked = true;

            PubSetup.ShowDialog();
            timer1.Enabled = false;
            timer1.Interval = Config.Timer;
            timer1.Enabled = true;
        }

        private void AboutPrgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupForms.AboutPrg aboutPrgForm = new SetupForms.AboutPrg();
            aboutPrgForm.ShowDialog();
        }

        private void ImportMastersMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false; //Остановим таймер


            SetupForms.ImportMastersToBase fImportMasters = new SetupForms.ImportMastersToBase();

            fImportMasters.cbCompany.DataSource = Config.Companies.Values.Where(i => i.Id == Config.LoginUser.CompanyId).Select(p => p.Name).ToList();
            if (Config.LoginUser.ResId > 0)
            {
                fImportMasters.cbRes.Items.Clear();
                fImportMasters.cbRes.Items.AddRange(Config.Reses.Values.Where(i => i.Id == Config.LoginUser.ResId).Select(p => p.Name).ToArray());
                fImportMasters.cbRes.SelectedIndex = 0;
            }
            else
            {
                fImportMasters.cbRes.Items.Clear();
                fImportMasters.cbRes.Items.AddRange(Config.Reses.Values.Where(i => i.FromCompanyId == Config.LoginUser.CompanyId).Select(p => p.Name).ToArray());
                fImportMasters.cbRes.SelectedIndex = -1;
            }
            //fImportMasters.cbRes.Items.Add(config.OtherWorkersName);


            fImportMasters.ShowDialog();
            //if (fImportFiders.DialogResult == DialogResult.No) MessageBox.Show("При добавлении нового объекта возникла ошибка. Обратитесь к разработчику.");
            //if (fImportFiders.DialogResult == DialogResult.Yes) MessageBox.Show("Новый объект успешно внесён в базу.");
            timer1.Enabled = true; //Снова запустим таймер

        }


        private void BtnClearJournal_Click(object sender, EventArgs e)
        {
            if (dgJournal.CurrentRow != null)//Усли есть что удалять
            {
                timer1.Enabled = false; //Остановим таймер
                if ((Config.LoginUser.Grant == 'w') || (Config.LoginUser.Grant == 'x'))//Проверка прав пользователя на редактирование
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить все записи из журнала? \nУдалённое из журнала отключение восстановить нельзя!", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Mysql.ClearJournal();
                        JournalUpdate();
                    }
                }
                else { MessageBox.Show("У вас недостаточно прав."); }
                timer1.Enabled = true; //Снова запустим таймер
            }
            else { MessageBox.Show("В журнале нет записей."); }

        }

        //1.0.3.5
        private void DelAllComandMasters_Click(object sender, EventArgs e)
        {
            if (dgJournal.CurrentRow != null)
            {
                MessageBox.Show("Сначала необходимо удалить из журнала все записи, так как командированный персонал может быть задействован в проведении работ.");
            } else
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить из словаря весь командированный персонал?", "Удаление командированного персонала", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (Mysql.DelAllComandMasters()) MessageBox.Show("Весь командированный персонал успешно удалён."); 
                }
            }

        }
	}
}
