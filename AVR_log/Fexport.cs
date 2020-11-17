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

namespace AVR_log
{
    public partial class Fexport : Form
    {
        ///Return Type: DWORD->unsigned int
        ///hWnd: HWND->HWND__*
        ///lpdwProcessId: LPDWORD->DWORD*
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern int GetWindowThreadProcessId([System.Runtime.InteropServices.InAttribute()] System.IntPtr hWnd, out int lpdwProcessId);

        private bool PathChanged = false; //Флаг изменения пути для экспорта формы 4

        private string SaveFilePath; //Путь для экспорта

        public Fexport()
        {
            InitializeComponent();
        }

        private bool Export_Forma15()
        {
            ///SELECT r.resname, prinadl_br, sum(kol_br_avr), sum(kol_pers_avr) ,sum(teh_agp) FROM journal j, reses r WHERE j.id_res=r.id GROUP BY prinadl_br
            ///SELECT r.resname, prinadl_br, sum(kol_br_avr), sum(kol_pers_avr), sum(teh_agp)+sum(teh_bkm)+sum(teh_kran), sum(teh_agp) FROM journal j, reses r WHERE endofwork = false AND r.resname=prinadl_br AND j.id_res=r.id GROUP BY prinadl_br union SELECT r.resname, prinadl_br, sum(kol_br_avr), sum(kol_pers_avr), sum(teh_agp)+sum(teh_bkm)+sum(teh_kran), sum(teh_agp) FROM journal j, reses r WHERE endofwork = false AND r.resname<>prinadl_br AND j.id_res=r.id GROUP BY prinadl_br

            return true;
        }

        /// <summary>
        /// Удалить из поля ФИО весь текст после '('
        /// </summary>
        /// <returns></returns>
        private string DelAddition(string FIO)
        {
            int i = FIO.IndexOf('(');
            if (i > 0)
                return FIO.Remove(i);
            else return FIO;
        }

        /// <summary>
        /// Удаление из строки подстроки (Аренда)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string DelArenda(string str)
        {
            string tstr = str.ToLower();
            int i = tstr.IndexOf("(аренда)");
            if (i > 0)
                return str.Remove(i).Trim();
            else return str;
        }

		/* Было до версии 1.0.4.0 Если всё работает в следю версии удалить, так как реализация перенесена в процедуру экспорта форм.
        private void InsertNameTypeVL(Excel.Worksheet worksheet, int type, int i)
        {
            worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Font.Bold = true;
            worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Merge();
            worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Value = "       "+config.TypeVL[type];
            worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Interior.Color = ColorTranslator.ToOle(Color.Red);
            worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].EntireRow.AutoFit();//АВтоподбор высоты
            worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
        }
		
		private void InsertNameTypeVL_Forma4_2020(Excel.Worksheet worksheet, int type, int i)
		{
			worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Font.Bold = true;
			worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Merge();
			worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Value = "       " + config.TypeVL[type];
			worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Interior.Color = ColorTranslator.ToOle(Color.Red);
			worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].EntireRow.AutoFit();//АВтоподбор высоты
			worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
		}
		*/




		/// <summary>
		/// Форма 4 2016 года
		/// </summary>
		/// <returns></returns>
		private bool Export_Forma4_2016()
        {
			const int BeginString = 7;
			pb.Value = 0;
            pb.Visible = true;
            //ExcelTools.CheckExcellProcesses();

            Excel.Application application = new Excel.Application
            {
                DisplayAlerts = false
            };
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                const string template = "Форма_4.xltx";

                // Открываем книгу из папки с запускаемым файлом
                workbook = application.Workbooks.Open(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), template));

                // Получаем активную таблицу
                worksheet = workbook.ActiveSheet as Excel.Worksheet;

                //Задаём имя листа согласно времени состояния.
                string WorksheetName = eTime.Text;
                WorksheetName = WorksheetName.Replace(':', '-');
                (workbook.ActiveSheet as Excel.Worksheet).Name = WorksheetName;

                //Заголовок формы 4
                string a2 = worksheet.Range["A2"].Value;
                int n1 = a2.IndexOf("#company#") + 1; //Вставляем название организации
                string FullCompanyName = Config.Companies.Values.FirstOrDefault(p => p.Id == Config.LoginUser.CompanyId).FullName;
                string CompanyName = Config.Companies.Values.FirstOrDefault(p => p.Id == Config.LoginUser.CompanyId).Name;
                a2 = a2.Replace("#company#", FullCompanyName);

                int n2 = a2.IndexOf("#time#") + 1; //Вставляем время
                a2 = a2.Replace("#time#", eTime.Text.Substring(0, 2));

                int n3 = a2.IndexOf("#date#") + 1; //Вставляем время
                a2 = a2.Replace("#date#", eDate.Text.ToString());


                //Всиавка заголовка
                worksheet.Range["A2"].Value = a2;
                //Форматирование заголовка
                worksheet.Range["A2"].Characters[n1, FullCompanyName.Length].Font.Underline = true;
                worksheet.Range["A2"].Characters[n2, 2].Font.Underline = true;
                worksheet.Range["A2"].Characters[n3, eDate.Text.Length].Font.Underline = true;

                pb.Maximum = Fmain.dtJournal.Rows.Count+3;

                // Записываем данные
                int i = BeginString; //Начало таблицы
                int n = 0; //счётчик нумерации;


                string FlagVlType = "";

                DateTime t_export, t_otkl, t_osm, t_avr, t_vkl;

                t_export = DateTime.Parse(eDate.Text + " " + TimeSpan.Parse(eTime.Text));


                foreach (DataRow dr in Fmain.dtJournal.Rows)
                {
                    t_otkl = DateTime.Parse(dr["d_otkl"].ToString().Split(' ')[0] + " " + dr["t_otkl"].ToString());

                    if (t_otkl <= t_export)
                    {
                        //Вставка новой строки
                        Excel.Range cellRange = (Excel.Range)worksheet.Cells[i, 1];
                        Excel.Range rowRange = cellRange.EntireRow;
                        rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
                        worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Font.Bold = false;

                        //Если сменился тип фидера
                        string tstr = dr["fidertype"].ToString();
                        if (FlagVlType != tstr)
                        {
                            FlagVlType = tstr;
                            //вставляем новую строку
                            Excel.Range cellRange2 = (Excel.Range)worksheet.Cells[i+1, 1];
                            Excel.Range rowRang2e = cellRange.EntireRow;
                            rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);

							worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Font.Bold = true;
							worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Merge();
							worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Value = "       " + Config.TypeVL[Convert.ToInt32(FlagVlType)];
							worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Interior.Color = ColorTranslator.ToOle(Color.Red);
							worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].EntireRow.AutoFit();//АВтоподбор высоты
							worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

							///InsertNameTypeVL(worksheet, Convert.ToInt32(tstr), i); //Было до версии1.0.4.0

                            n = 1; // Начинаем нумерацию сначала
                            i++; //Увеличиваем номер строки

                        }
                        worksheet.Range["A" + i.ToString()].Value = n.ToString(); //нумерация
                        n++;
                        worksheet.Range["B" + i.ToString()].Value = CompanyName + " " + dr["resname"].ToString();
                        worksheet.Range["C" + i.ToString()].Value = DelArenda(dr["fidername"].ToString());
                        worksheet.Range["C" + i.ToString()].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;//Выравниваем название по левому краю

                        worksheet.Range["D" + i.ToString()].Value = dr["d_otkl"].ToString().Split(' ')[0];
                        worksheet.Range["E" + i.ToString()].Value = dr["t_otkl"].ToString();

                        //Версия 1.0.3.3
                        if (dr["t_vkl_vl"].ToString() != "")
                        {
                            if (DateTime.Parse(dr["d_vkl_vl"].ToString().Split(' ')[0] + " " + dr["t_vkl_vl"].ToString()) <= t_export)
                                worksheet.Range["R" + i.ToString()].Value = dr["d_vkl_vl"].ToString().Split(' ')[0] + "\n" + dr["t_vkl_vl"].ToString();
                        }

                        if (dr["t_osm"].ToString() != "")
                        {
                            t_osm = DateTime.Parse(dr["d_osm"].ToString().Split(' ')[0] + " " + dr["t_osm"].ToString());
                            if (t_osm <= t_export)
                            {
                                worksheet.Range["G" + i.ToString()].Value = dr["t_osm"].ToString();

                                if (dr["kol_br_osm"].ToString() != "0")
                                    worksheet.Range["H" + i.ToString()].Value = dr["kol_br_osm"].ToString();
                                if (dr["kol_pers_osm"].ToString() != "0")
                                    worksheet.Range["I" + i.ToString()].Value = dr["kol_pers_osm"].ToString();

                                int mo1 = Convert.ToInt32(dr["master_osm_id1"].ToString());
                                if (mo1 > 0)
                                {
                                    worksheet.Range["J" + i.ToString()].Value += Config.Masters.Values.First(p => p.Id == mo1).Dol + "\n" + DelAddition(Config.Masters.Values.First(p => p.Id == mo1).Fio);
                                    worksheet.Range["K" + i.ToString()].Value += "\n" + Config.Masters.Values.First(p => p.Id == mo1).Tel;
                                }
                                int mo2 = Convert.ToInt32(dr["master_osm_id2"].ToString());
                                if (mo2 > 0)
                                {
                                    worksheet.Range["J" + i.ToString()].Value += "\n" + Config.Masters.Values.First(p => p.Id == mo2).Dol + "\n" + DelAddition(Config.Masters.Values.First(p => p.Id == mo2).Fio);
                                    worksheet.Range["K" + i.ToString()].Value += "\n\n" + Config.Masters.Values.First(p => p.Id == mo2).Tel;
                                }
                                int mo3 = Convert.ToInt32(dr["master_osm_id3"].ToString());
                                if (mo3 > 0)
                                {
                                    worksheet.Range["J" + i.ToString()].Value += "\n" + Config.Masters.Values.First(p => p.Id == mo3).Dol + "\n" + DelAddition(Config.Masters.Values.First(p => p.Id == mo3).Fio);
                                    worksheet.Range["K" + i.ToString()].Value += "\n\n" + Config.Masters.Values.First(p => p.Id == mo3).Tel;
                                }
                                int mo4 = Convert.ToInt32(dr["master_osm_id4"].ToString());
                                if (mo4 > 0)
                                {
                                    worksheet.Range["J" + i.ToString()].Value += "\n" + Config.Masters.Values.First(p => p.Id == mo4).Dol + "\n" + DelAddition(Config.Masters.Values.First(p => p.Id == mo4).Fio);
                                    worksheet.Range["K" + i.ToString()].Value += "\n\n" + Config.Masters.Values.First(p => p.Id == mo4).Tel;
                                }

                                worksheet.Range["L" + i.ToString()].Value = dr["result_osm"].ToString();
                            }
                        }
                        worksheet.Range["M" + i.ToString()].Value = dr["NP"].ToString();
                        worksheet.Range["N" + i.ToString()].Value = dr["population"].ToString();
                        worksheet.Range["O" + i.ToString()].Value = dr["SZO"].ToString();
                        worksheet.Range["P" + i.ToString()].Value = dr["TP"].ToString();


                        if (dr["t_avr"].ToString() != "")
                        {
                            t_avr = DateTime.Parse(dr["d_avr"].ToString().Split(' ')[0] + " " + dr["t_avr"].ToString());

                            if (t_avr <= t_export)
                            {
                                worksheet.Range["Q" + i.ToString()].Value = dr["d_avr"].ToString().Split(' ')[0] + "\n" + dr["t_avr"].ToString();

                                /*Было до версии 1.0.3.3
                                if (dr["t_vkl_vl"].ToString() != "")
                                    worksheet.Range["R" + i.ToString()].Value = dr["d_vkl_vl"].ToString() + "\n" + dr["t_vkl_vl"].ToString();
                                  */
                                if (dr["kol_br_avr"].ToString() != "0")
                                    worksheet.Range["S" + i.ToString()].Value = dr["kol_br_avr"].ToString();
                                if (dr["kol_pers_avr"].ToString() != "0")
                                    worksheet.Range["T" + i.ToString()].Value = dr["kol_pers_avr"].ToString();
                                int mavrres1 = 0, mavrcomp1 = 0, mavr1 = Convert.ToInt32(dr["master_avr_id"].ToString());
                                if (mavr1 > 0)
                                {
                                    worksheet.Range["U" + i.ToString()].Value = Config.Masters.Values.First(p => p.Id == mavr1).Dol + "\n" + DelAddition(Config.Masters.Values.First(p => p.Id == mavr1).Fio);
                                    worksheet.Range["V" + i.ToString()].Value = Config.Masters.Values.First(p => p.Id == mavr1).Tel;
                                    mavrres1 = Config.Masters.Values.First(p => p.Id == mavr1).FromResId;
                                    mavrcomp1 = Config.Masters.Values.First(p => p.Id == mavr1).FromCompanyId;
                                }

								//Новое в версии 1.0.5.0
								int mavrres2 = 0, mavrcomp2 = 0, mavr2 = Convert.ToInt32(dr["master_avr2_id"].ToString());
								if (mavr2 > 0)
								{
									worksheet.Range["U" + i.ToString()].Value += "\n" + Config.Masters.Values.First(p => p.Id == mavr2).Dol + "\n" + DelAddition(Config.Masters.Values.First(p => p.Id == mavr2).Fio);
									worksheet.Range["V" + i.ToString()].Value += "\n" + Config.Masters.Values.First(p => p.Id == mavr2).Tel;
									mavrres2 = Config.Masters.Values.First(p => p.Id == mavr2).FromResId;
									mavrcomp2 = Config.Masters.Values.First(p => p.Id == mavr2).FromCompanyId;
								}
								int mavrres3 = 0, mavrcomp3 = 0, mavr3 = Convert.ToInt32(dr["master_avr3_id"].ToString());
								if (mavr3 > 0)
								{
									worksheet.Range["U" + i.ToString()].Value += "\n" + Config.Masters.Values.First(p => p.Id == mavr3).Dol + "\n" + DelAddition(Config.Masters.Values.First(p => p.Id == mavr3).Fio);
									worksheet.Range["V" + i.ToString()].Value += "\n" + Config.Masters.Values.First(p => p.Id == mavr3).Tel;
									mavrres3 = Config.Masters.Values.First(p => p.Id == mavr3).FromResId;
									mavrcomp3 = Config.Masters.Values.First(p => p.Id == mavr3).FromCompanyId;
								}
								int mavrres4 = 0, mavrcomp4 = 0, mavr4 = Convert.ToInt32(dr["master_avr4_id"].ToString());
								if (mavr4 > 0)
								{
									worksheet.Range["U" + i.ToString()].Value += "\n" + Config.Masters.Values.First(p => p.Id == mavr4).Dol + "\n" + DelAddition(Config.Masters.Values.First(p => p.Id == mavr4).Fio);
									worksheet.Range["V" + i.ToString()].Value += "\n" + Config.Masters.Values.First(p => p.Id == mavr4).Tel;
									mavrres4 = Config.Masters.Values.First(p => p.Id == mavr4).FromResId;
									mavrcomp4 = Config.Masters.Values.First(p => p.Id == mavr4).FromCompanyId;
								}
								//Конец нового в версии 1.0.5.0


								worksheet.Range["W" + i.ToString()].Value = dr["basa_avr"].ToString();
                                //if (dr["teh_agp"].ToString() != "0")
                                worksheet.Range["X" + i.ToString()].Value = dr["teh_agp"].ToString();
                                //if (dr["teh_bkm"].ToString() != "0")
                                worksheet.Range["Y" + i.ToString()].Value = dr["teh_bkm"].ToString();
                                //if (dr["teh_kran"].ToString() != "0")
                                worksheet.Range["Z" + i.ToString()].Value = dr["teh_kran"].ToString();
								if (mavrres1>0)
								{
									if (mavrres1 < Config.OtherWorkersId) //Если это не командированный
										worksheet.Range["AA" + i.ToString()].Value = Config.Companies.Values.First(p => p.Id == mavrcomp1).FullName + "\n" + dr["prinadl_br"].ToString();
									else
										worksheet.Range["AA" + i.ToString()].Value = dr["prinadl_br"].ToString();
								}

								//Новое в версии 1.0.5.0
								if (mavrres2 > 0)
								{
									if (mavrres2 < Config.OtherWorkersId) //Если это не командированный
										worksheet.Range["AA" + i.ToString()].Value += "\n" + Config.Companies.Values.First(p => p.Id == mavrcomp2).FullName + "\n" + dr["prinadl_br2"].ToString();
									else
										worksheet.Range["AA" + i.ToString()].Value += "\n" + dr["prinadl_br2"].ToString();
								}
								if (mavrres3 > 0)
								{
									if (mavrres3 < Config.OtherWorkersId) //Если это не командированный
										worksheet.Range["AA" + i.ToString()].Value += "\n" + Config.Companies.Values.First(p => p.Id == mavrcomp3).FullName + "\n" + dr["prinadl_br3"].ToString();
									else
										worksheet.Range["AA" + i.ToString()].Value += "\n" + dr["prinadl_br3"].ToString();
								}
								if (mavrres4 > 0)
								{
									if (mavrres4 < Config.OtherWorkersId) //Если это не командированный
										worksheet.Range["AA" + i.ToString()].Value += "\n" + Config.Companies.Values.First(p => p.Id == mavrcomp4).FullName + "\n" + dr["prinadl_br4"].ToString();
									else
										worksheet.Range["AA" + i.ToString()].Value += "\n" + dr["prinadl_br4"].ToString();
								}
								//Конец нового в версии 1.0.5.0

								worksheet.Range["AB" + i.ToString()].Value = dr["t_plan_okon"].ToString();
                            }
                        }


                        if (dr["t_vkl_potr"].ToString() != "")
                        {
                            t_vkl = DateTime.Parse(dr["d_vkl_potr"].ToString().Split(' ')[0] + " " + dr["t_vkl_potr"].ToString());

                            if (t_vkl <= t_export)
                            {

                                worksheet.Range["F" + i.ToString()].Value = dr["d_vkl_potr"].ToString().Split(' ')[0] + "\n" + dr["t_vkl_potr"].ToString();

                                worksheet.Range["AC" + i.ToString()].Value = dr["obem_rabot"].ToString();
                                worksheet.Range["AD" + i.ToString()].Value = dr["perem_br"].ToString();
								//Новое в версии 1.0.5.0
								string str2 = dr["perem_br2"].ToString();
								string str3 = dr["perem_br3"].ToString();
								string str4 = dr["perem_br4"].ToString();
								if (str2.Length > 0)
									worksheet.Range["AD" + i.ToString()].Value += "\n" + str2;
								if (str3.Length > 0)
									worksheet.Range["AD" + i.ToString()].Value += "\n" + str3;
								if (str4.Length > 0)
									worksheet.Range["AD" + i.ToString()].Value += "\n" + str4;
								//Конец нового в версии 1.0.5.

								if (dr["endofwork"].ToString() == "True") //если работы на фидере завершены
                                {
                                    Color color;
                                    TimeSpan time_vkl = TimeSpan.Parse(t_vkl.ToShortTimeString());

                                    if (time_vkl <= TimeSpan.Parse("03:05")) color = Config.Bgcolor.c1;
                                    else if (time_vkl <= TimeSpan.Parse("07:05")) color = Config.Bgcolor.c2;
                                    else if (time_vkl <= TimeSpan.Parse("11:05")) color = Config.Bgcolor.c3;
                                    else if (time_vkl <= TimeSpan.Parse("13:05")) color = Config.Bgcolor.c4;
                                    else if (time_vkl <= TimeSpan.Parse("18:05")) color = Config.Bgcolor.c5;
                                    else if (time_vkl <= TimeSpan.Parse("22:05")) color = Config.Bgcolor.c6;
                                    else if (time_vkl <= TimeSpan.Parse("23:05")) color = Config.Bgcolor.c7;
                                    else color = Config.Bgcolor.c1; // как до 03:05
                                                                    // }
                                    worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Interior.Color = ColorTranslator.ToOle(color);



                                }

                            }
                            else worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Interior.Color = ColorTranslator.ToOle(Color.Transparent);
                        }
                        if (dr["endofwork"].ToString() == "False")
                        {
                            worksheet.Range["A" + i.ToString(), "AD" + i.ToString()].Interior.Color = ColorTranslator.ToOle(Color.Transparent);
                        }
                        i++;
                        pb.Value = i - 7;
                        Application.DoEvents();
                    }
                }
                worksheet.Range["B" + BeginString.ToString(), "B" + i.ToString()].EntireRow.AutoFit();//АВтоподбор высоты

                //Включим все границы
                /*
                worksheet.Range["A" + BeginString.ToString(), "AD" + i.ToString()].Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;
                worksheet.Range["A" + BeginString.ToString(), "AD" + i.ToString()].Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
                worksheet.Range["A" + BeginString.ToString(), "AD" + i.ToString()].Borders[Excel.XlBordersIndex.xlInsideHorizontal].ColorIndex = 0;
                worksheet.Range["A" + BeginString.ToString(), "AD" + i.ToString()].Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlThin;
                worksheet.Range["A" + BeginString.ToString(), "AD" + i.ToString()].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                worksheet.Range["A" + BeginString.ToString(), "AD" + i.ToString()].Borders[Excel.XlBordersIndex.xlInsideVertical].ColorIndex = 0;
                */

                //worksheet.Range["A" + i.ToString()].Rows.Delete();// Hidden = true; /// Скрыть последнюю вставленную строку.

                Excel.Range rg = worksheet.Range["A" + i.ToString()].EntireRow;
                rg.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);



                //Сохраняем на диск
                //string NewFileName = "Форма4(" + DateTime.Now.ToString("dd.MM.yy_") + WorksheetName + ").xlsx"; //до 1.0.3.6
                string NewFileName = "Форма4(" + eDate.Text +"_" + WorksheetName + ").xlsx"; //c 1.0.3.6

                if (ePath.Text == "")
                {
                    //Если путь не указан, сохранять в текущую папку.
                    SaveFilePath = Environment.CurrentDirectory;
                }
                else
                {
                    SaveFilePath = ePath.Text;
                }
                if (!System.IO.Directory.Exists(SaveFilePath)) //Если папка не существует
                    System.IO.Directory.CreateDirectory(SaveFilePath); //То создать её.



                // Попытка закрыть открытый документ Excel с таким же именем как и у экспортируемого
                Excel.Application excelApp;
                try
                {// Присоединение к открытому приложению Excel (если оно открыто).
                    excelApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");

                    foreach (var item in excelApp.Workbooks)
                    {
                        string tstr = (item as Excel.Workbook).Name;
                        if (tstr == NewFileName)  //Если открыт документ с таки мже именем как и тот, что мы сохраняем, то
                        {
                            (item as Excel.Workbook).Close(false); //закрываем его.
                        }
                    }

                    if (excelApp.Workbooks.Count < 1) //Если открытых книг не осталось, то завершим процесс
                    {
						////Подготовка к убийству процесса Excel
						int tHwnd = 0;
						tHwnd = excelApp.Hwnd; //Получим HWND окна
                        System.Diagnostics.Process tExcelProcess;
                        GetWindowThreadProcessId((IntPtr)tHwnd, out int tExcelPID); //По HWND получим PID
                        tExcelProcess = System.Diagnostics.Process.GetProcessById(tExcelPID); //Подключимся к процессу
                        ////Убийство процесса Excel
                        tExcelProcess.Kill();
                        tExcelProcess = null;
                    }


                }
                finally
                {
                }

                try
                {
                    worksheet.SaveAs(System.IO.Path.Combine(SaveFilePath, NewFileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                //Закрываем Excel
                workbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(workbook);

				////Подготовка к убийству процесса Excel
				int Hwnd = 0;
				Hwnd = application.Hwnd;
                System.Diagnostics.Process ExcelProcess;
                GetWindowThreadProcessId((IntPtr)Hwnd, out int ExcelPID);
                ExcelProcess = System.Diagnostics.Process.GetProcessById(ExcelPID);
                ////Конец подготовки к убийству процесса Excel

                application.Quit();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(application);

                //                System.Threading.Thread.Sleep(5000);//Ждём 5 секунды на всякий случай

                GC.Collect();
                GC.WaitForPendingFinalizers();

                ////Убийство процесса Excel
                ExcelProcess.Kill();
                ExcelProcess = null;


                // Если чекбокс "Открыть файл после успешного экспорта" установлен
                if (cbOpenFile.Checked)
                {
                    // Показываем приложение
                    System.Diagnostics.Process.Start(System.IO.Path.Combine(SaveFilePath, NewFileName));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


            return true;
        }

		/// <summary>
		/// Форма 4 2020 года
		/// </summary>
		/// <returns></returns>
		private bool Export_Forma4_2020()
		{
			const int BeginString = 7;
			pb.Value = 0;
			pb.Visible = true;

			Excel.Application application = new Excel.Application
			{
				DisplayAlerts = false
			};
			Excel.Workbook workbook = null;
			Excel.Worksheet worksheet = null;

			try
			{
				const string template = "Форма_4_2020.xltx";

				// Открываем книгу из папки с запускаемым файлом
				workbook = application.Workbooks.Open(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), template));

				// Получаем активную таблицу
				worksheet = workbook.ActiveSheet as Excel.Worksheet;

				//Задаём имя листа согласно времени состояния.
				string WorksheetName = eTime.Text;
				WorksheetName = WorksheetName.Replace(':', '-');
				(workbook.ActiveSheet as Excel.Worksheet).Name = WorksheetName;

				//Заголовок формы 4
				string a2 = worksheet.Range["A2"].Value;
				int n1 = a2.IndexOf("#company#") + 1; //Вставляем название организации
				string FullCompanyName = Config.Companies.Values.FirstOrDefault(p => p.Id == Config.LoginUser.CompanyId).FullName;
				string CompanyName = Config.Companies.Values.FirstOrDefault(p => p.Id == Config.LoginUser.CompanyId).Name;
				a2 = a2.Replace("#company#", FullCompanyName);

				int n2 = a2.IndexOf("#time#") + 1; //Вставляем время
				a2 = a2.Replace("#time#", eTime.Text.Substring(0, 2));

				int n3 = a2.IndexOf("#date#") + 1; //Вставляем время
				a2 = a2.Replace("#date#", eDate.Text.ToString());


				//Всиавка заголовка
				worksheet.Range["A2"].Value = a2;
				//Форматирование заголовка
				worksheet.Range["A2"].Characters[n1, FullCompanyName.Length].Font.Underline = true;
				worksheet.Range["A2"].Characters[n2, 2].Font.Underline = true;
				worksheet.Range["A2"].Characters[n3, eDate.Text.Length].Font.Underline = true;

				pb.Maximum = Fmain.dtJournal.Rows.Count + 3;

				// Записываем данные
				int i = BeginString; //Начало таблицы
				int n = 0; //счётчик нумерации;


				string FlagVlType = "";

				DateTime t_export, t_otkl, t_osm, t_avr, t_vkl;

				t_export = DateTime.Parse(eDate.Text.Split(' ')[0] + " " + TimeSpan.Parse(eTime.Text));


				foreach (DataRow dr in Fmain.dtJournal.Rows)
				{
					t_otkl = DateTime.Parse(dr["d_otkl"].ToString().Split(' ')[0] + " " + dr["t_otkl"].ToString());

					if (t_otkl <= t_export)
					{
						//Вставка новой строки
						Excel.Range cellRange = (Excel.Range)worksheet.Cells[i, 1];
						Excel.Range rowRange = cellRange.EntireRow;
						rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
						worksheet.Range["A" + i.ToString(), "AE" + i.ToString()].Font.Bold = false;

						//Если сменился тип фидера
						string tstr = dr["fidertype"].ToString();
						if (FlagVlType != tstr)
						{
							FlagVlType = tstr;
							//вставляем новую строку
							Excel.Range cellRange2 = (Excel.Range)worksheet.Cells[i + 1, 1];
							Excel.Range rowRang2e = cellRange.EntireRow;
							rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
							worksheet.Range["A" + i.ToString(), "AF" + i.ToString()].Font.Bold = true;
							worksheet.Range["A" + i.ToString(), "AF" + i.ToString()].Merge();
							worksheet.Range["A" + i.ToString(), "AF" + i.ToString()].Value = "       " + Config.TypeVL[Convert.ToInt32(FlagVlType)];
							worksheet.Range["A" + i.ToString(), "AF" + i.ToString()].Interior.Color = ColorTranslator.ToOle(Color.Red);
							worksheet.Range["A" + i.ToString(), "AF" + i.ToString()].EntireRow.AutoFit();//АВтоподбор высоты
							worksheet.Range["A" + i.ToString(), "AF" + i.ToString()].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

							n = 1; // Начинаем нумерацию сначала
							i++; //Увеличиваем номер строки

						}
						worksheet.Range["A" + i.ToString()].Value = n.ToString(); //нумерация
						n++;
						worksheet.Range["B" + i.ToString()].Value = CompanyName + " " + dr["resname"].ToString();
						worksheet.Range["C" + i.ToString()].Value = DelArenda(dr["fidername"].ToString());
						worksheet.Range["C" + i.ToString()].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;//Выравниваем название по левому краю

						worksheet.Range["D" + i.ToString()].Value = dr["d_otkl"].ToString().Split(' ')[0];
						worksheet.Range["E" + i.ToString()].Value = dr["t_otkl"].ToString();

						//Версия 1.0.5.0
						if (dr["apvrpv"].ToString() == "True") //если АПВ РПВ успешно, то заполняем нулями
						{
							worksheet.Range["F" + i.ToString()].Value = "0";
							worksheet.Range["G" + i.ToString()].Value = "0";
							worksheet.Range["H" + i.ToString()].Value = "0";
							worksheet.Range["I" + i.ToString()].Value = "0";
							worksheet.Range["J" + i.ToString()].Value = "0";
						} else
						{
							//Версия 1.0.4.0
							worksheet.Range["F" + i.ToString()].Value = dr["TP"].ToString();
							try
							{
								//decimal p = decimal.Parse(dr["population"].ToString()) / 1000;
								//string st = p.ToString().Replace(',','.');
								//worksheet.Range["G" + i.ToString()].Value = (decimal.Parse(dr["population"].ToString()) / 1000).ToString().Replace(',', '.');
								worksheet.Range["G" + i.ToString()].Value = dr["population"].ToString().Replace(',', '.');
							}
							catch (Exception ex)
							{
								worksheet.Range["G" + i.ToString()].Value = $"!ОШИБКА{ex}";
							}
							worksheet.Range["H" + i.ToString()].Value = dr["P_load"].ToString().Replace(',', '.');
							worksheet.Range["I" + i.ToString()].Value = dr["NP"].ToString();
							worksheet.Range["J" + i.ToString()].Value = dr["SZO"].ToString();

						}
											   
						//РИСЭ
						worksheet.Range["K" + i.ToString()].Value = dr["kol_rise"].ToString();
						worksheet.Range["L" + i.ToString()].Value = dr["P_rise"].ToString().Replace(',', '.');


						worksheet.Range["M" + i.ToString()].Formula = $"=R{i}+W{i}";
						worksheet.Range["N" + i.ToString()].Formula = $"=S{i}+X{i}";
						worksheet.Range["O" + i.ToString()].Formula = $"=Z{i}+AA{i}+AB{i}";


						if (dr["t_osm"].ToString() != "")
						{
							t_osm = DateTime.Parse(dr["d_osm"].ToString().Split(' ')[0] + " " + dr["t_osm"].ToString());
							if (t_osm <= t_export)
							{
								worksheet.Range["Q" + i.ToString()].Value = dr["t_osm"].ToString();

								if (dr["kol_br_osm"].ToString() != "0")
									worksheet.Range["R" + i.ToString()].Value = dr["kol_br_osm"].ToString();
								if (dr["kol_pers_osm"].ToString() != "0")
									worksheet.Range["S" + i.ToString()].Value = dr["kol_pers_osm"].ToString();


								/*
								int mo1 = Convert.ToInt32(dr["master_osm_id1"].ToString());
								if (mo1 > 0)
								{
									worksheet.Range["J" + i.ToString()].Value += config.Masters.Values.First(p => p.Id == mo1).Dol + "\n" + DelAddition(config.Masters.Values.First(p => p.Id == mo1).Fio);
									worksheet.Range["K" + i.ToString()].Value += "\n" + config.Masters.Values.First(p => p.Id == mo1).Tel;
								}
								int mo2 = Convert.ToInt32(dr["master_osm_id2"].ToString());
								if (mo2 > 0)
								{
									worksheet.Range["J" + i.ToString()].Value += "\n" + config.Masters.Values.First(p => p.Id == mo2).Dol + "\n" + DelAddition(config.Masters.Values.First(p => p.Id == mo2).Fio);
									worksheet.Range["K" + i.ToString()].Value += "\n\n" + config.Masters.Values.First(p => p.Id == mo2).Tel;
								}
								int mo3 = Convert.ToInt32(dr["master_osm_id3"].ToString());
								if (mo3 > 0)
								{
									worksheet.Range["J" + i.ToString()].Value += "\n" + config.Masters.Values.First(p => p.Id == mo3).Dol + "\n" + DelAddition(config.Masters.Values.First(p => p.Id == mo3).Fio);
									worksheet.Range["K" + i.ToString()].Value += "\n\n" + config.Masters.Values.First(p => p.Id == mo3).Tel;
								}
								int mo4 = Convert.ToInt32(dr["master_osm_id4"].ToString());
								if (mo4 > 0)
								{
									worksheet.Range["J" + i.ToString()].Value += "\n" + config.Masters.Values.First(p => p.Id == mo4).Dol + "\n" + DelAddition(config.Masters.Values.First(p => p.Id == mo4).Fio);
									worksheet.Range["K" + i.ToString()].Value += "\n\n" + config.Masters.Values.First(p => p.Id == mo4).Tel;
								}
								*/

								worksheet.Range["T" + i.ToString()].Value = dr["result_osm"].ToString();
							}
						}


						//Версия 1.0.3.3
						if (dr["t_vkl_vl"].ToString() != "")
						{
							if (DateTime.Parse(dr["d_vkl_vl"].ToString().Split(' ')[0] + " " + dr["t_vkl_vl"].ToString()) <= t_export)
								worksheet.Range["V" + i.ToString()].Value = dr["d_vkl_vl"].ToString().Split(' ')[0] + "\n" + dr["t_vkl_vl"].ToString();
						}

						if (dr["t_avr"].ToString() != "")
						{
							t_avr = DateTime.Parse(dr["d_avr"].ToString().Split(' ')[0] + " " + dr["t_avr"].ToString());

							if (t_avr <= t_export)
							{
								worksheet.Range["U" + i.ToString()].Value = dr["d_avr"].ToString().Split(' ')[0] + "\n" + dr["t_avr"].ToString();

								if (dr["kol_br_avr"].ToString() != "0")
									worksheet.Range["W" + i.ToString()].Value = dr["kol_br_avr"].ToString();
								if (dr["kol_pers_avr"].ToString() != "0")
									worksheet.Range["X" + i.ToString()].Value = dr["kol_pers_avr"].ToString();

								
								int mavrres1 = 0, mavrcomp1 = 0, mavr1 = Convert.ToInt32(dr["master_avr_id"].ToString());
								
								if (mavr1 > 0)
								{
									mavrres1 = Config.Masters.Values.First(p => p.Id == mavr1).FromResId;
									mavrcomp1 = Config.Masters.Values.First(p => p.Id == mavr1).FromCompanyId;
								}
								//Новое в версии 1.0.5.0
								int mavrres2 = 0, mavrcomp2 = 0, mavr2 = Convert.ToInt32(dr["master_avr2_id"].ToString());
								if (mavr2 > 0)
								{
									mavrres2 = Config.Masters.Values.First(p => p.Id == mavr2).FromResId;
									mavrcomp2 = Config.Masters.Values.First(p => p.Id == mavr2).FromCompanyId;
								}
								int mavrres3 = 0, mavrcomp3 = 0, mavr3 = Convert.ToInt32(dr["master_avr3_id"].ToString());
								if (mavr3 > 0)
								{
									mavrres3 = Config.Masters.Values.First(p => p.Id == mavr3).FromResId;
									mavrcomp3 = Config.Masters.Values.First(p => p.Id == mavr3).FromCompanyId;
								}
								int mavrres4 = 0, mavrcomp4 = 0, mavr4 = Convert.ToInt32(dr["master_avr4_id"].ToString());
								if (mavr4 > 0)
								{
									mavrres4 = Config.Masters.Values.First(p => p.Id == mavr4).FromResId;
									mavrcomp4 = Config.Masters.Values.First(p => p.Id == mavr4).FromCompanyId;
								}
								//Конец нового в версии 1.0.5.0


								worksheet.Range["Y" + i.ToString()].Value = dr["basa_avr"].ToString();
								//if (dr["teh_agp"].ToString() != "0")
								worksheet.Range["Z" + i.ToString()].Value = dr["teh_agp"].ToString();
								//if (dr["teh_bkm"].ToString() != "0")
								worksheet.Range["AA" + i.ToString()].Value = dr["teh_bkm"].ToString();
								//if (dr["teh_kran"].ToString() != "0")
								worksheet.Range["AB" + i.ToString()].Value = dr["teh_kran"].ToString();
								if (mavrres1 > 0)
								{
									if (mavrres1 < Config.OtherWorkersId) //Если это не командированный
										worksheet.Range["AC" + i.ToString()].Value = Config.Companies.Values.First(p => p.Id == mavrcomp1).FullName + "\n" + dr["prinadl_br"].ToString();
									else
										worksheet.Range["AC" + i.ToString()].Value = dr["prinadl_br"].ToString();
								}

								//Новое в версии 1.0.5.0
								if (mavrres2 > 0)
								{
									if (mavrres2 < Config.OtherWorkersId) //Если это не командированный
										worksheet.Range["AC" + i.ToString()].Value += "\n" + Config.Companies.Values.First(p => p.Id == mavrcomp2).FullName + "\n" + dr["prinadl_br2"].ToString();
									else
										worksheet.Range["AC" + i.ToString()].Value += "\n" + dr["prinadl_br2"].ToString();
								}
								if (mavrres3 > 0)
								{
									if (mavrres3 < Config.OtherWorkersId) //Если это не командированный
										worksheet.Range["AC" + i.ToString()].Value += "\n" + Config.Companies.Values.First(p => p.Id == mavrcomp3).FullName + "\n" + dr["prinadl_br3"].ToString();
									else
										worksheet.Range["AC" + i.ToString()].Value += "\n" + dr["prinadl_br3"].ToString();
								}
								if (mavrres4 > 0)
								{
									if (mavrres4 < Config.OtherWorkersId) //Если это не командированный
										worksheet.Range["AC" + i.ToString()].Value += "\n" + Config.Companies.Values.First(p => p.Id == mavrcomp4).FullName + "\n" + dr["prinadl_br4"].ToString();
									else
										worksheet.Range["AC" + i.ToString()].Value += "\n" + dr["prinadl_br4"].ToString();
								}
								//Конец нового в версии 1.0.5.0

								worksheet.Range["AD" + i.ToString()].Value = "\n" + dr["t_plan_okon"].ToString();
							}
						}


						if (dr["t_vkl_potr"].ToString() != "")
						{
							t_vkl = DateTime.Parse(dr["d_vkl_potr"].ToString().Split(' ')[0] + " " + dr["t_vkl_potr"].ToString());

							if (t_vkl <= t_export)
							{

								worksheet.Range["P" + i.ToString()].Value = dr["d_vkl_potr"].ToString().Split(' ')[0] + "\n" + dr["t_vkl_potr"].ToString();

								worksheet.Range["AE" + i.ToString()].Value = dr["obem_rabot"].ToString();
								worksheet.Range["AF" + i.ToString()].Value = dr["perem_br"].ToString();
								//Новое в версии 1.0.5.0
								string str2 = dr["perem_br2"].ToString();
								string str3 = dr["perem_br3"].ToString();
								string str4 = dr["perem_br4"].ToString();
								if (str2.Length > 0)
									worksheet.Range["AF" + i.ToString()].Value += "\n" + str2;
								if (str3.Length > 0)
									worksheet.Range["AF" + i.ToString()].Value += "\n" + str3;
								if (str4.Length > 0)
									worksheet.Range["AF" + i.ToString()].Value += "\n" + str4;
								//Конец нового в версии 1.0.5.


								if (dr["endofwork"].ToString() == "True") //если работы на фидере завершены
								{
									Color color;
									TimeSpan time_vkl = TimeSpan.Parse(t_vkl.ToShortTimeString());

									if (time_vkl <= TimeSpan.Parse("03:05")) color = Config.Bgcolor.c1;
									else if (time_vkl <= TimeSpan.Parse("07:05")) color = Config.Bgcolor.c2;
									else if (time_vkl <= TimeSpan.Parse("11:05")) color = Config.Bgcolor.c3;
									else if (time_vkl <= TimeSpan.Parse("13:05")) color = Config.Bgcolor.c4;
									else if (time_vkl <= TimeSpan.Parse("18:05")) color = Config.Bgcolor.c5;
									else if (time_vkl <= TimeSpan.Parse("22:05")) color = Config.Bgcolor.c6;
									else if (time_vkl <= TimeSpan.Parse("23:05")) color = Config.Bgcolor.c7;
									else color = Config.Bgcolor.c1; // как до 03:05
																	// }
									worksheet.Range["A" + i.ToString(), "AE" + i.ToString()].Interior.Color = ColorTranslator.ToOle(color);



								}

							}
							else worksheet.Range["A" + i.ToString(), "AE" + i.ToString()].Interior.Color = ColorTranslator.ToOle(Color.Transparent);
						}
						if (dr["endofwork"].ToString() == "False")
						{
							worksheet.Range["A" + i.ToString(), "AE" + i.ToString()].Interior.Color = ColorTranslator.ToOle(Color.Transparent);
						}
						i++;
						pb.Value = i - 7;
						Application.DoEvents();
					}
				}
				worksheet.Range["B" + BeginString.ToString(), "B" + i.ToString()].EntireRow.AutoFit();//АВтоподбор высоты

				// Скрыть последнюю вставленную строку.
				Excel.Range rg = worksheet.Range["A" + i.ToString()].EntireRow;
				rg.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);



				//Сохраняем на диск
				//string NewFileName = "Форма4(" + DateTime.Now.ToString("dd.MM.yy_") + WorksheetName + ").xlsx"; //до 1.0.3.6
				string NewFileName = "Форма4(" + eDate.Text + "_" + WorksheetName + ").xlsx"; //c 1.0.3.6

				if (ePath.Text == "")
				{
					//Если путь не указан, сохранять в текущую папку.
					SaveFilePath = Environment.CurrentDirectory;
				}
				else
				{
					SaveFilePath = ePath.Text;
				}
				if (!System.IO.Directory.Exists(SaveFilePath)) //Если папка не существует
					System.IO.Directory.CreateDirectory(SaveFilePath); //То создать её.



				// Попытка закрыть открытый документ Excel с таким же именем как и у экспортируемого
				Excel.Application excelApp;
				try
				{// Присоединение к открытому приложению Excel (если оно открыто).
					excelApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");

					foreach (var item in excelApp.Workbooks)
					{
						string tstr = (item as Excel.Workbook).Name;
						if (tstr == NewFileName)  //Если открыт документ с таки мже именем как и тот, что мы сохраняем, то
						{
							(item as Excel.Workbook).Close(false); //закрываем его.
						}
					}

					if (excelApp.Workbooks.Count < 1) //Если открытых книг не осталось, то завершим процесс
					{
						////Подготовка к убийству процесса Excel
						int tHwnd = 0;
						tHwnd = excelApp.Hwnd; //Получим HWND окна
						System.Diagnostics.Process tExcelProcess;
						GetWindowThreadProcessId((IntPtr)tHwnd, out int tExcelPID); //По HWND получим PID
						tExcelProcess = System.Diagnostics.Process.GetProcessById(tExcelPID); //Подключимся к процессу
																							  ////Убийство процесса Excel
						tExcelProcess.Kill();
						tExcelProcess = null;
					}


				}
				finally
				{
				}

				try
				{
					worksheet.SaveAs(System.IO.Path.Combine(SaveFilePath, NewFileName));
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}


				//Закрываем Excel
				workbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
				System.Runtime.InteropServices.Marshal.FinalReleaseComObject(worksheet);
				System.Runtime.InteropServices.Marshal.FinalReleaseComObject(workbook);

				////Подготовка к убийству процесса Excel
				int Hwnd = 0;
				Hwnd = application.Hwnd;
				System.Diagnostics.Process ExcelProcess;
				GetWindowThreadProcessId((IntPtr)Hwnd, out int ExcelPID);
				ExcelProcess = System.Diagnostics.Process.GetProcessById(ExcelPID);
				////Конец подготовки к убийству процесса Excel

				application.Quit();
				System.Runtime.InteropServices.Marshal.FinalReleaseComObject(application);

				//                System.Threading.Thread.Sleep(5000);//Ждём 5 секунды на всякий случай

				GC.Collect();
				GC.WaitForPendingFinalizers();

				////Убийство процесса Excel
				ExcelProcess.Kill();
				ExcelProcess = null;

				// Если чекбокс "Открыть файл после успешного экспорта" установлен
				if (cbOpenFile.Checked)
				{
					// Показываем приложение
					System.Diagnostics.Process.Start(System.IO.Path.Combine(SaveFilePath, NewFileName));
				}


			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}


			return true;

		}


		private void Button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            switch (FormsControl.SelectedIndex)
            {
                case 0:
					switch (cbFormrVersion.SelectedIndex)
					{
						case 0:
							if (Export_Forma4_2016())
							{
								this.DialogResult = DialogResult.OK;
								this.Hide();
							}
							break;
						case 1:
							if (Export_Forma4_2020())
							{
								this.DialogResult = DialogResult.OK;
								this.Hide();
							}
							break;

						default:
							break;
					}
                    break;
                default:
                    break;
            }

            //Если пользователь изменил путь и файл удачно экспортирован, то запомним этот путь
            if (PathChanged && (this.DialogResult == DialogResult.OK))
            {
                const string userRoot = "HKEY_CURRENT_USER";
                const string subkey = "Software\\AVR_log";
                const string keyName = userRoot + "\\" + subkey;

                try
                {
                    SaveFilePath = System.IO.Path.GetFullPath(SaveFilePath);
                    Microsoft.Win32.Registry.SetValue(keyName, "ExportPath", SaveFilePath);
                    Config.ExportPath = SaveFilePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            pb.Visible = false;
            this.Cursor = Cursors.Default;

        }

		private void Button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ePath.Text = folderBrowserDialog1.SelectedPath;
                PathChanged = true;
            }
        }
	}
}
