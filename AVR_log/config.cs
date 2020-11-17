using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace AVR_log
{
    /// <summary> Настройки работы программы </summary> 
    class Config
    {
        /// <summary> Адрес сервера MySQL </summary> 
        public static string hostMySQL;

        /// <summary> Имя базы данных MySQL (стандартные имя пользователя\пароль для подключения к бд avr\avr) </summary> 
        public static string dbMySQL;

        /// <summary>  Вести ли лог-файл (по-умолчанию нет)</summary> 
        public static bool MakeLogFile = false;

        /// <summary> Таймер обновления данных в журнале</summary>
        public static int Timer;

        /// <summary> Путь для экспортируемых Excel-файлов</summary>
        public static string ExportPath;

        /// <summary> Путь к папке с обновлениями</summary>
        public static string UpdatePath;

        /// <summary>Проверять обновления при старте программы</summary>
        public static bool CheckStartUpdate;

		/// <summary> Переменнная для определения необходимости обновления словарей фидеров и мастеров</summary>
		public static int MAXUpdateLogId = 0;

        /// <summary> Переменнная для определения необходимости обновления журнала</summary>
        public static int MAXUpdateJournalId = 0;

        /// <summary>Название раздела для приезжих работников</summary>
        public const string OtherWorkersName = "Командированные";

        /// <summary>ID раздела для приезжих работников</summary>
        public const int OtherWorkersId = 999999999;

        /// <summary>Сортровка по подстроке для ВЛ10</summary>
        public static string Sortvl10 = "'ПС '";
        /// <summary>Сортровка по подстроке для ВЛ0,4</summary>
        public static string Sortvl04 = "'ТП №'";
        /// <summary>Разрешить пользователю переименовывать объекты отключения</summary>
        public static bool UserCanRenameFeeder=false;

        /// <summary>Тип ЛЭП (тип фидера)</summary>
        public static string[] TypeVL = { "10кВ", "0.4кВ", "35/110кВ" };


        /// <summary>  Данные о подключившемся пользователе</summary> 
        public static class LoginUser
        {
            /// <summary> Идентификатор пользователя </summary> 
            public static int Id;
            /// <summary> Имя пользователя </summary> 
            public static string Name;
            /// <summary> Права пользователя [r-только чтение, w-запись и чтение, x-полные(администратор)] </summary> 
            public static char Grant;
            /// <summary> Идентификатор принадлежности пользователя к Организации (0 - всем организациям)</summary> 
            public static int CompanyId;
            /// <summary> Идентификатор принадлежности пользователя к РЭС-у (0 - всем рэсам организации)</summary> 
            public static int ResId;
        }

        public static string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            //byte[] bytes = Encoding.Unicode.GetBytes(s);

            // создаем объект этого класса. Отмечу, что он создается не через new, а вызовом метода Create
            MD5 md5Hasher = MD5.Create();

            // Преобразуем входную строку в массив байт и вычисляем хэш
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(s));

            // Создаем новый Stringbuilder (Изменяемую строку) для набора байт
            StringBuilder sBuilder = new StringBuilder();

            // Преобразуем каждый байт хэша в шестнадцатеричную строку
            for (int i = 0; i < data.Length; i++)
            {
                //указывает, что нужно преобразовать элемент в шестнадцатиричную строку длиной в два символа
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }


        /// <summary> Организация </summary> 
        public class Company
        {
            /// <summary> Идентификатор организации </summary> 
            public int Id;
            /// <summary> Название организации </summary> 
            public string Name;
            /// <summary> Полное название организации для отчётов</summary> 
            public string FullName;

        }
        /// <summary> Словарь Организаций </summary> 
        public static Dictionary<string, Company> Companies = new Dictionary<string, Company>();

        /// <summary> Class РЭС </summary> 
        public class Res
        {
            /// <summary> Название РЭС-а </summary> 
            public string Name;
            /// <summary> Идентификатор РЭС-а </summary> 
            public int Id;
            /// <summary> Идентификатор принадлежности РЭС-а к организации</summary> 
            public int FromCompanyId;

        }
        /// <summary> Словарь РЭС-ов </summary> 
        public static Dictionary<string, Res> Reses = new Dictionary<string, Res>();

        /// <summary>
        /// Другие филиалы
        /// </summary>
        public class Filial
        {
            public int Id;
            public string Name;
        }
        /// <summary>
        /// Словарь других филиалов
        /// </summary>
        public static Dictionary<string, Filial> Filials = new Dictionary<string, Filial>();
        

        /// <summary> Class Данные о фидере </summary> 
        public class Fider
        {
            /// <summary> Идентификатор фидера </summary> 
            public int Id;
            /// <summary>Тип фидера '0'-10кв, '1'-0,4 кв</summary> 
            public byte FiderType;
            /// <summary>Диспетчерское наименование фидера и ЛЭП </summary> 
            public string Name;
            /// <summary>Идентификатор принадлежности фидера к РЭС </summary> 
            public int FromResId;
            /// <summary> Идентификатор принадлежности фидера к Организации </summary> 
            public int FromCompanyId;
            /// <summary>Кол-во Трансформаторных подстанций </summary> 
            public int TP;
            /// <summary>Кол-во социально значимых объектов </summary> 
            public int SZO;
            /// <summary>Кол-во населённых пунктов </summary> 
            public int NP;
            /// <summary>Численность населения </summary> 
            public int Population;
			/// <summary>Летняя нагрузка потребителей, МВт </summary> 
			public decimal P_load_l;          //Новое в версии 1.0.4.0
			/// <summary>Зимняя нагрузка потребителей, МВт </summary> 
			public decimal P_load_z;          //Новое в версии 1.0.4.0

		}
		/// <summary> Словарь фидеровов</summary> 
		public static Dictionary<string, Fider> Fiders = new Dictionary<string, Fider>();


        /// <summary>Класс мастр </summary>
        public class Master
        {
            /// <summary> Идентификатор mastera </summary> 
            public int Id;
            /// <summary> ФИО мастера </summary> 
            public string Fio;
            /// <summary> Должность мастера </summary> 
            public string Dol;
            /// <summary> Телефон мастера </summary> 
            public string Tel;
            /// <summary> Идентификатор принадлежности мастера к РЭС </summary> 
            public int FromResId;
            /// <summary> Идентификатор принадлежности мастера к Организации </summary> 
            public int FromCompanyId;
            /// <summary> Идентификатор принадлежности мастера к РЭС </summary> 
            public int FromFilialId;
        }
        /// <summary> Словарь мастеров </summary> 
        public static Dictionary<string, Master> Masters = new Dictionary<string, Master>();

        public class Journal
        {
            public int id;
            public int id_company;
            public int id_res;
            public int id_fider;
            public int TP;
            public int SZO;
            public int NP;
            public int population;
			public decimal P_load;			//Новое в версии 1.0.4.0
			public int kol_rise;        //Новое в версии 1.0.4.0
			public decimal P_rise;			//Новое в версии 1.0.4.0
			public string d_otkl;
            public string t_otkl;
            public string d_osm;
            public string t_osm;
            public int kol_br_osm;
            public int kol_pers_osm;
            public int master_osm_id1;  //* new v1.0.2.1
            public int master_osm_id2;  //* new v1.0.2.1
            public int master_osm_id3;  //* new v1.0.2.1
            public int master_osm_id4;  //* new v1.0.2.1

            public string result_osm;
            public string d_avr;
            public string t_avr;
            public string d_vkl_vl;
            public string t_vkl_vl;
            public int kol_br_avr;
            public int kol_pers_avr;
			public int master_avr_id;  //* new v1.0.2.1
			public int master_avr2_id;  //* new v1.0.5.0
			public int master_avr3_id;  //* new v1.0.5.0
			public int master_avr4_id;  //* new v1.0.5.0

			public string basa_avr;
            public int teh_agp;
            public int teh_bkm;
            public int teh_kran;
			public string prinadl_br;
			public string prinadl_br2;//* new v1.0.5.0
			public string prinadl_br3;//* new v1.0.5.0
			public string prinadl_br4;//* new v1.0.5.0
			public string t_plan_okon;
            public string obem_rabot;
			public string perem_br;
			public string perem_br2;//* new v1.0.5.0
			public string perem_br3;//* new v1.0.5.0
			public string perem_br4;//* new v1.0.5.0
			public string d_vkl_potr;
            public string t_vkl_potr;
            public int id_user;
			public byte apvrpv;
			public byte endofwork;

        }

        public static class Bgcolor
        {
            public static System.Drawing.Color c1 = System.Drawing.Color.FromArgb(228, 223, 236); //включены до 3-05
            public static System.Drawing.Color c2 = System.Drawing.Color.FromArgb(183, 222, 232); //включены до 7-05
            public static System.Drawing.Color c3 = System.Drawing.Color.FromArgb(252, 213, 180); //включены до 11-05
            public static System.Drawing.Color c4 = System.Drawing.Color.FromArgb(196, 189, 151); //включены до 13-05
            public static System.Drawing.Color c5 = System.Drawing.Color.FromArgb(146, 208, 80);  //включены до 18-05
            public static System.Drawing.Color c6 = System.Drawing.Color.FromArgb(0, 176, 240);   //включены до 22-05
            public static System.Drawing.Color c7 = System.Drawing.Color.Yellow; //включены до 23-05
        }


        /// <summary> Загрузка из ini-файла настроек программы </summary> 
        public static bool LoadConfiguration()
        {
            try
            {
                INIManager manager = new INIManager(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "AVR_log.ini"));
                hostMySQL = manager.GetPrivateString("main", "hostMySQL"); 
                dbMySQL = manager.GetPrivateString("main", "dbMySQL");
                ExportPath = manager.GetPrivateString("main", "ExportPath");
                UpdatePath = manager.GetPrivateString("main", "UpdatePath");
                if (ExportPath == "") ExportPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Формы Журнала АВР";
                Timer = Convert.ToInt32(manager.GetPrivateString("main", "Timer"));
                string tstr = manager.GetPrivateString("main", "CheckUpdate");
                if (tstr == "false")
                    CheckStartUpdate = false;
                else
                    CheckStartUpdate = true;

                //параметры сортировки
                tstr = manager.GetPrivateString("main", "Sortvl10");
                if (tstr != "") Sortvl10 = "'" + tstr + "'";
                tstr = manager.GetPrivateString("main", "Sortvl04");
                if (tstr != "") Sortvl04 = "'" + tstr + "'";;

                //Разрешить пользователю переименовывать объекты отключения?
                tstr = manager.GetPrivateString("main", "UserCanRenameFeeder");
                if (tstr == "true")
                    UserCanRenameFeeder = true;
                else
                    UserCanRenameFeeder = false;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }


        /// <summary>
        /// Проверка обновлений программы
        /// </summary>
        /// <returns></returns>
        public static bool CheckUpdate()
        {
            if (UpdatePath!="")
            {
                //Флаг обнаружения расхождений
                bool diff = false;
                
                //получим коллекцию файлов SrcDir из папки откуда запущена программа
                string SourcePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                System.IO.DirectoryInfo DirInfoSrc = new System.IO.DirectoryInfo(SourcePath);
                IEnumerable<System.IO.FileInfo> ListSrc = DirInfoSrc.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly);
                Dictionary<string, System.IO.FileInfo> SrcDir = new Dictionary<string, System.IO.FileInfo>();
                foreach (var files in ListSrc)
                    SrcDir.Add(files.Name, files);

                if(!System.IO.Directory.Exists(UpdatePath))
                {
                    System.Windows.Forms.MessageBox.Show("Не могу открыть папку для проверки обновлений.\n"+ UpdatePath);
                    return false;
                }
                //получим коллекцию файлов DstDir из папки для проверки обновлений
                System.IO.DirectoryInfo DirInfoDst = new System.IO.DirectoryInfo(UpdatePath);
                IEnumerable<System.IO.FileInfo> ListDst = DirInfoDst.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly);
                Dictionary<string, System.IO.FileInfo> DstDir = new Dictionary<string, System.IO.FileInfo>();
                foreach (var files in ListDst)
                    DstDir.Add(files.Name, files);

                
                //Проверяем необходимость обновлений.
                foreach (var file in DstDir)
                {
                    if (!SrcDir.ContainsKey(file.Value.Name))//Если файл есть в dst и его нет в src
                    {
                        diff = true; //нужно обновлять
                        break;
                    }
                    else
                    {
                        if(file.Value.LastWriteTimeUtc > SrcDir[file.Value.Name].LastWriteTimeUtc)//Если даты создания файлов в dst и src не совпадают
                        {
                            diff = true; //нужно обновлять
                            break;
                        }
                    }
                }
                if(diff)
                {
                    if (System.Windows.Forms.MessageBox.Show("Обнаружено обновление для программы. \nУстановить его?","Обновление программы", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            //Если программа обновления сама обновлена, то сначала скопируем её.
                            if (DstDir["UpdateAvrLog.exe"].LastWriteTimeUtc > SrcDir["UpdateAvrLog.exe"].LastWriteTimeUtc)
                            {
                                try
                                {
                                    System.IO.File.Copy(DstDir["UpdateAvrLog.exe"].FullName, SrcDir["UpdateAvrLog.exe"].FullName, true);
                                }
                                catch (Exception ex)
                                {
                                    System.Windows.Forms.MessageBox.Show("Ошибка при запуске обновления программы UpdateAvrLog.\n"+ex.ToString()+"\n Обратитесь к разработчику");
                                }
                            }

                            string StartCMD = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "UpdateAvrLog.exe");

                            System.Diagnostics.Process.Start(StartCMD, UpdatePath);
                            System.Windows.Forms.Application.Exit();
                        }
                        catch 
                        {
                            System.Windows.Forms.MessageBox.Show("Ошибка при запуске программы обновления. Обратитесь к разработчику");
                        }

                    }
                }
            }
            return false;
        }

    }

}
