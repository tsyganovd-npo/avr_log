using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AVR_log.SetupForms
{
    public partial class ImportMastersToBase : Form
    {
        ///Return Type: DWORD->unsigned int
        ///hWnd: HWND->HWND__*
        ///lpdwProcessId: LPDWORD->DWORD*
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern int GetWindowThreadProcessId([System.Runtime.InteropServices.InAttribute()] System.IntPtr hWnd, out int lpdwProcessId);

        public int ResId=-1;

        public ImportMastersToBase()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "ImportMasters.xlsx"));
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cbCompany.SelectedIndex < 0)
            {
                MessageBox.Show("Необходимо выбрать ПО");
            }
            else
            {
                if (cbRes.SelectedIndex < 0)
                {
                    MessageBox.Show("Необходимо выбрать РЭС.");
                }
                else
                {
                    if(cbRes.Text==Config.OtherWorkersName)
                    {
                        ResId = Config.OtherWorkersId;
                    }
                    else
                    {
                        ResId = Config.Reses[cbRes.Text].Id;
                    }
                        if (!System.IO.File.Exists(eImportFile.Text))
                        {
                            MessageBox.Show("Необходимо выбрать существующей файл");
                        }
                        else
                        {
                            ImportMastersFile();
                        }
                }
            }

        }

        public bool ImportMastersFile()
        {
            this.Cursor = Cursors.WaitCursor;
            int i = 1;
            int ImportCount = 0;
            bool result = true;

            //ExcelTools.CheckExcellProcesses();

            Excel.Application ExcelImportFile = new Excel.Application
            {
                DisplayAlerts = false
            };
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;


            try
            {

                // Открываем книгу из папки с запускаемым файлом
                workbook = ExcelImportFile.Workbooks.Open(eImportFile.Text);

                // Получаем первую таблицу
                worksheet = workbook.ActiveSheet as Excel.Worksheet;
                while (true)
                {
                    i++;
                    string fio = worksheet.Cells[i, 1].Text;
                    string dol = worksheet.Cells[i, 2].Text;
                    string tel = worksheet.Cells[i, 3].Text;
                    if ((fio == "") || (dol == "") || (tel == ""))
                        break;

                    if (Mysql.FindMasterInBase(fio))
                    {
                        string addition = "(число)";
                        for (int add = 1; add < 99999; add++)
                        {
                            addition = "(" + add.ToString() + ")";
                            if (!Mysql.FindMasterInBase(fio + addition))
                                break;
                        }


                        MessageBox.Show("Работник " + fio + " уже содержится в базе.\nВ базу "+fio+" будет импортирован под именем - " + fio  + addition +
                            "\nВ Форму 4 данный работник будет выгружен без дополнения '" + addition + "'");
                        fio += addition;
                        if (!Mysql.AddNewMasterInBase(fio, dol, tel, ResId, Config.Companies[cbCompany.Text].Id))
                        {
                            MessageBox.Show("Ошибка при импорте работника - " + fio);
                            break;
                        }
                        else
                        {
                            ImportCount++;
                        }



                    }
                    else
                    {
                        if (!Mysql.AddNewMasterInBase(fio, dol, tel, ResId, Config.Companies[cbCompany.Text].Id))
                        {
                            MessageBox.Show("Ошибка при импорте работника - " + fio);
                            break;
                        }
                        else
                        {
                            ImportCount++;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = false;

            }
            finally
            {
                MessageBox.Show("Импортировано - " + ImportCount.ToString() + " работников");

                workbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(workbook);

                ////Подготовка к убийству процесса Excel
                int ExcelPID = 0;
                int Hwnd = 0;
                Hwnd = ExcelImportFile.Hwnd;
                System.Diagnostics.Process ExcelProcess;
                GetWindowThreadProcessId((IntPtr)Hwnd, out ExcelPID);
                ExcelProcess = System.Diagnostics.Process.GetProcessById(ExcelPID);
                ////Конец подготовки к убийству процесса Excel



                ExcelImportFile.Quit();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(ExcelImportFile);

                GC.Collect();
                GC.WaitForPendingFinalizers();

                ////Убийство процесса Excel
                ExcelProcess.Kill();
                ExcelProcess = null;

                //ExcelTools.KillExcel();
                this.Cursor = Cursors.Default;

            }

            return result;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                eImportFile.Text = openFileDialog1.FileName;
            }

        }
    }
}
