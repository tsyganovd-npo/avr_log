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

    public partial class ImportFidersToBase : Form
    {
        ///Return Type: DWORD->unsigned int
        ///hWnd: HWND->HWND__*
        ///lpdwProcessId: LPDWORD->DWORD*
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern int GetWindowThreadProcessId([System.Runtime.InteropServices.InAttribute()] System.IntPtr hWnd, out int lpdwProcessId);

        public ImportFidersToBase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                eImportFile.Text = openFileDialog1.FileName;
            }

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
                    if (cbTypeVL.SelectedIndex < 0)
                    {
                        MessageBox.Show("Необходимо выбрать тип ВЛ");
                    }
                    else
                    {
                        if (!System.IO.File.Exists(eImportFile.Text))
                        {
                            MessageBox.Show("Необходимо выбрать существующей файл");
                        } else
                        {
                            ImportFidersFile();
                        }

                    }

                }
            }
        }

        public bool ImportFidersFile()
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
            Excel.Workbook workbook=null;
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

                    string FiderName = worksheet.Cells[i, 1].Text;
                    if (FiderName == "") break;
                    string TP = worksheet.Cells[i, 2].Text;
                    if (TP == "") TP ="0";
                    string SZO = worksheet.Cells[i, 3].Text;
                    if (SZO == "") SZO = "0";
                    string NP = worksheet.Cells[i, 4].Text;
                    if (NP == "") NP = "0";
                    string population = worksheet.Cells[i, 5].Text;
                    if (population == "") population = "0";

					//Новое в версии 1.0.4.0
					string P_load_l = worksheet.Cells[i, 6].Text;
					if (P_load_l == "") P_load_l = "0,000";
					string P_load_z = worksheet.Cells[i, 7].Text;
					if (P_load_z == "") P_load_z = "0,000";

					int FiderType = cbTypeVL.SelectedIndex;

                    if (Mysql.FindFiderInBase(FiderName))
                    {
                        MessageBox.Show("В базе уже содержится " + FiderName + "\nДобавить объект с таким же именем невозможно!");
                    }
                    else
                    { 
                        if (!Mysql.AddNewFiderInBase(FiderName, FiderType, Config.Reses[cbRes.Text].Id, Config.Companies[cbCompany.Text].Id, Convert.ToInt32(TP), Convert.ToInt32(SZO), Convert.ToInt32(NP), Convert.ToInt32(population), Convert.ToDecimal(P_load_l), Convert.ToDecimal(P_load_z)))
                        {
                            MessageBox.Show("Ошибка при импорте объекта - " + FiderName);
                            break;
                        }else
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
                MessageBox.Show("Импортировано - "+ ImportCount.ToString()+" объектов");

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "ImportFiders.xlsx"));
        }
    }
}
