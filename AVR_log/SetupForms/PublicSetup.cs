using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Win32;
using System.Net.NetworkInformation;
using MySql.Data.MySqlClient;

namespace AVR_log.SetupForms
{
    public partial class PublicSetup : Form
    {
        public PublicSetup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Config.CheckUpdate();
            this.Cursor = Cursors.Default;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            /*
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\AVR_log";
            const string keyName = userRoot + "\\" + subkey;
            bool NeedRestart = false;

            try
            {
                if (config.hostMySQL != edhostMySQL.Text)
                {
                    Registry.SetValue(keyName, "hostMySQL", edhostMySQL.Text);
                    NeedRestart = true;
                }

                if (config.dbMySQL != eddbMySQL.Text)
                {
                    Registry.SetValue(keyName, "dbMySQL", eddbMySQL.Text);
                    NeedRestart = true;
                }

                if (config.ExportPath != edExportPath.Text)
                {
                    Registry.SetValue(keyName, "ExportPath", edExportPath.Text);
                    NeedRestart = true;
                }
                if (config.UpdatePath != edUpdatePath.Text)
                {
                    Registry.SetValue(keyName, "UpdatePath", edUpdatePath.Text);
                    NeedRestart = true;
                }
                if (config.Timer / 1000 != edTimer.Value)
                {
                    config.Timer = (int)edTimer.Value * 1000;
                    Registry.SetValue(keyName, "Timer", config.Timer);
                }
                if (config.CheckStartUpdate != checkStartUpdate.Checked)
                {
                    if (checkStartUpdate.Checked) Registry.SetValue(keyName, "CheckUpdate", "true");
                    else Registry.SetValue(keyName, "CheckUpdate", "false");

                }


            }
            finally
            {
                if (NeedRestart) MessageBox.Show("Настройки успешно сохранены, но изменения встыпят в силу только при следующем запуске программы.");
                else MessageBox.Show("Настройки успешно сохранены.");
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }*/
            bool NeedRestart = false;
            try
            {
                INIManager manager = new INIManager(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "AVR_log.ini"));
                if (Config.hostMySQL != edhostMySQL.Text)
                {
                    manager.WritePrivateString("main", "hostMySQL", edhostMySQL.Text);
                    NeedRestart = true;
                }

                if (Config.dbMySQL != eddbMySQL.Text)
                {
                    manager.WritePrivateString("main", "dbMySQL", eddbMySQL.Text);
                    NeedRestart = true;
                }

                if (Config.ExportPath != edExportPath.Text)
                {
                    manager.WritePrivateString("main", "ExportPath", edExportPath.Text);
                    Config.ExportPath = edExportPath.Text;
                }
                if (Config.UpdatePath != edUpdatePath.Text)
                {
                    manager.WritePrivateString("main", "UpdatePath", edUpdatePath.Text);
                    NeedRestart = true;
                }
                if (Config.Timer / 1000 != edTimer.Value)
                {
                    Config.Timer = (int)edTimer.Value * 1000;
                    manager.WritePrivateString("main", "Timer", Config.Timer.ToString());
                }
                if (Config.CheckStartUpdate != checkStartUpdate.Checked)
                {
                    if (checkStartUpdate.Checked) manager.WritePrivateString("main", "CheckUpdate", "true");
                    else manager.WritePrivateString("main", "CheckUpdate", "false");
                    Config.CheckStartUpdate = checkStartUpdate.Checked;
                }

                if (Config.Sortvl10 != edSortvl10.Text)
                {
                    manager.WritePrivateString("main", "Sortvl10", edSortvl10.Text);
                    Config.Sortvl10 = edSortvl10.Text;
                    NeedRestart = true;
                }

                if (Config.Sortvl04 != edSortvl04.Text)
                {
                    manager.WritePrivateString("main", "Sortvl04", edSortvl04.Text);
                    Config.Sortvl04 = edSortvl04.Text;
                    NeedRestart = true;
                }

                if (Config.UserCanRenameFeeder != cbUserCanRenameFeeder.Checked)
                {
                    if (cbUserCanRenameFeeder.Checked) manager.WritePrivateString("main", "UserCanRenameFeeder", "true");
                    else manager.WritePrivateString("main", "UserCanRenameFeeder", "false");
                    Config.UserCanRenameFeeder = cbUserCanRenameFeeder.Checked;
                }




            }
            finally
            {
                if (NeedRestart) MessageBox.Show("Настройки успешно сохранены, но изменения встыпят в силу только при следующем запуске программы.");
                else MessageBox.Show("Настройки успешно сохранены.");
                this.DialogResult = DialogResult.OK;
                this.Hide();

            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(edhostMySQL.Text);

            if (reply.Status != IPStatus.Success)
            {
                MessageBox.Show("ОШИБКА: Сервер " + edhostMySQL.Text + " недоступен.");
            }
            else
            {
                MessageBox.Show("ОК. Сервер " + edhostMySQL.Text + " доступен.");
            }
            this.Cursor = Cursors.Default;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MySqlConnection conn;
            bool error = false;
            string myConnectionString = "server=" + edhostMySQL.Text + ";uid=avr;pwd=avr;database=" + eddbMySQL.Text + ";charset=utf8;Allow Zero Datetime=true;Connect Timeout=30";
            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Во время соединения с сервером " + edhostMySQL.Text + " и базой данных " + eddbMySQL.Text + " произошла следующаяя ошибка:\n" + ex.Message);
                error = true;
            }
            if (!error)
                MessageBox.Show("Соединение с сервером " + edhostMySQL.Text + " и базой данных " + eddbMySQL.Text + " устанвлено");
            this.Cursor = Cursors.Default;

        }

        private void edFolderSelect1_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Name == "btnFolderSelectExport")
                folderBrowserDialog1.SelectedPath = edExportPath.Text;

            if ((sender as Button).Name == "btnFolderSelectUpdate")
                folderBrowserDialog1.SelectedPath = edUpdatePath.Text;


            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if ((sender as Button).Name == "btnFolderSelectExport")
                    edExportPath.Text=folderBrowserDialog1.SelectedPath;
                if ((sender as Button).Name == "btnFolderSelectUpdate")
                    edUpdatePath.Text=folderBrowserDialog1.SelectedPath;
            }

        }
    }
}
