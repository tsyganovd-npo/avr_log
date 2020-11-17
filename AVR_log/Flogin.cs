using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace AVR_log
{
    public partial class Flogin : Form
    {


        public Flogin()
        {
            InitializeComponent();            
        }

        private void PrintLog(string str) //Вывод лога работы
        {
                LoginLabel.Text = str;
                Application.DoEvents();
            if (Config.MakeLogFile){/*здесь д.б. процедура записи лог-файла */}
        }

        private void Flogin_Shown(object sender, EventArgs e)
        {
            LoginProgressBar.Maximum = 10;//// Изменить в случае увеличения кол-ва предварительных загрузок
            this.Cursor = Cursors.WaitCursor;

            LoginProgressBar.Value++;
            PrintLog("Чтение настроек программы из файла AVR_log.ini");
            if (!Config.LoadConfiguration())
            {
                PrintLog("ERROR:Ошибка чтения настроек программы из файла AVR_log.ini");
                MessageBox.Show("Ошибка чтения настроек программы из файла AVR_log.ini.\nДальнейшая работа невозможна.\nОбратитесь к администратору.", "Критическая ошибка");
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                if (Config.CheckStartUpdate) Config.CheckUpdate();

                LoginProgressBar.Value++;
                PrintLog("Чтение настроек программы из файла AVR_log.ini - Успешно");

                this.Text += " (" + Config.hostMySQL  + ")";

                PrintLog("Проверка доступности хоста сервера БД");
                Ping pingSender = new Ping();
                PingReply reply=null;
                try
                {
                    reply = pingSender.Send(Config.hostMySQL);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    PrintLog("ERROR:Ошибочно указан IP адрес или название хоста сервера БД");
                    MessageBox.Show("Ошибочно указан IP адрес или название хоста сервера БД.\nДальнейшая работа невозможна.\nОбратитесь к администратору.", "Критическая ошибка");
                    this.DialogResult = DialogResult.Abort;
                    return;
                }
//                finally
               // {
                    if (reply.Status != IPStatus.Success)
                    {
                        PrintLog("ERROR:Хост сервера БД недоступен");
                        MessageBox.Show("Хост сервера БД недоступен.\nДальнейшая работа невозможна.\nОбратитесь к администратору.", "Критическая ошибка");
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        LoginProgressBar.Value++;
                        PrintLog("Хост сервера БД доступен, попытка подключения к БД");
                        string ConnStatus = Mysql.Connection();
                        if (ConnStatus != "OK")
                        {
                            PrintLog("ERROR:" + ConnStatus);
                            MessageBox.Show(ConnStatus + "\nДальнейшая работа невозможна.\nОбратитесь к администратору.", "Критическая ошибка");
                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {

                            LoginProgressBar.Value++;
                            PrintLog("База данных AVR доступена, Запрос списка пользователей.");
                            if (!Mysql.GetUsersToCombobox(cbUsers.Items))
                            {
                                PrintLog("ERROR:Ошибка запроса списка пользователей");
                                MessageBox.Show("Ошибка запроса списка пользователей.\nДальнейшая работа невозможна.\nОбратитесь к администратору.", "Критическая ошибка");
                                this.DialogResult = DialogResult.Abort;
                            }
                            else
                            {
                                LoginProgressBar.Value++;
                                PrintLog("Список пользователей получен");
                                PrintLog("Выберите пользователя и введите пароль.");
                                this.Cursor = Cursors.Default;
                                cbUsers.Focus();
                                cbUsers.DroppedDown = true;
                            }
                        }

                    }

                //}


            }

        }

        private void CbUsers_SelectedIndexChanged(object sender, EventArgs e) //если выбран пользователь, то перейти в поле ввода пароля
        {
            edPassword.Focus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (Mysql.IsValidUser(cbUsers.Text, edPassword.Text))//Проверка логина и пароля
            {
                //если всё нормально, то:
                this.DialogResult = DialogResult.OK;
				if (!Mysql.CheckDBUpdate(Config.LoginUser.Grant))
				{
					PrintLog("ERROR:Во время обновления базы данных произошла ошибка.\nДальнейшая работа невозможна.\nОбратитесь к своему системному администратору или разработчику.");
					MessageBox.Show("ERROR:Во время обновления базы данных произошла ошибка.\nДальнейшая работа невозможна.\nОбратитесь к своему системному администратору или разработчику.");
					this.DialogResult = DialogResult.Abort;
					this.Cursor = Cursors.Default;
					this.Hide();
					return;
				}

				if (!Mysql.GetMaxUpdateId())
                {
                    PrintLog("ERROR:Ошибка получения индекса обновления");
                    MessageBox.Show("Ошибка получения индекса обновления");
                }
                else
                {

                    //Загружаем организации
                    LoginProgressBar.Value++;
                    PrintLog("Загрузка словаря организаций.");
                    if (!Mysql.GetCompanies())
                    {
                        PrintLog("ERROR:Ошибка загрузки словаря организаций");
                        MessageBox.Show("Ошибка загрузки словаря организаций.\nДальнейшая работа невозможна.\nОбратитесь к администратору.", "Критическая ошибка");
                        this.DialogResult = DialogResult.Abort;

                    }
                    else
                    {

                        //Загружаем словарь с данными о РЭС-ах                
                        LoginProgressBar.Value++;
                        PrintLog("Загрузка словаря РЭС.");
                        if (!Mysql.GetReses())
                        {
                            PrintLog("ERROR:Ошибка загрузки словаря РЭС");
                            MessageBox.Show("Ошибка загрузки словаря РЭС.\nДальнейшая работа невозможна.\nОбратитесь к администратору.", "Критическая ошибка");
                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {
                            PrintLog("Загружено РЭС - " + Config.Reses.Count.ToString());

                            //Загружаем словарь с данными о фидерах 
                            LoginProgressBar.Value++;
                            PrintLog("Загрузка словаря фидеров.");
                            if (!Mysql.GetFiders())
                            {
                                PrintLog("ERROR:Ошибка загрузки словаря фидеров");
                                MessageBox.Show("Ошибка загрузки словаря фидеров.\nДальнейшая работа невозможна.\nОбратитесь к администратору.", "Критическая ошибка");
                                this.DialogResult = DialogResult.Abort;
                            }
                            else
                            {
                                PrintLog("Загружено фидеров - " + Config.Fiders.Count.ToString());

                                //Загружаем словарь с данными о мастерах
                                LoginProgressBar.Value++;
                                PrintLog("Загрузка словаря мастеров.");
                                if (!Mysql.GetMasters())
                                {
                                    PrintLog("ERROR:Ошибка загрузки словаря мастеров");
                                    MessageBox.Show("Ошибка загрузки словаря мастеров.\nДальнейшая работа невозможна.\nОбратитесь к администратору.", "Критическая ошибка");
                                    this.DialogResult = DialogResult.Abort;
                                }
                                else
                                {
                                    PrintLog("Загружено мастеров - " + Config.Masters.Count.ToString());
                                    LoginProgressBar.Value++;
                                    PrintLog("Загрузка словаря филиалов.");
                                    if (!Mysql.GetFilials())
                                    {
                                        PrintLog("ERROR:Ошибка загрузки словаря филиалов");
                                        MessageBox.Show("Ошибка загрузки словаря филиалов.\nДальнейшая работа невозможна.\nОбратитесь к администратору.", "Критическая ошибка");
                                        this.DialogResult = DialogResult.Abort;
                                    }
                                }
                            }

                        }


                    }
                    this.Cursor = Cursors.Default;
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный пароль.");
                edPassword.SelectAll();
                edPassword.Focus();
            }
        }

        private void EdPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') //обработка нажатия клавиши ENTER в поле ввода пароля
            {
                Button1_Click(null, null);
                e.Handled = true;
            }
        }

        private void Flogin_Load(object sender, EventArgs e)
        {
            if ((DateTime.Now.Month == 12) || (DateTime.Now.Month == 1)) panel1.BackgroundImage = Properties.Resources.LogoAVR3;
            else panel1.BackgroundImage = Properties.Resources.LogoAVR2;
        }
    }
}
