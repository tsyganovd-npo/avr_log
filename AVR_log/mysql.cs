using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace AVR_log
{
    /// <summary> Работа с сервером MySQL</summary> 
    class Mysql
    {
        public static MySqlConnection conn;
        public static string myConnectionString;

        /// <summary>
        /// Метод Connection() Соединение с БД с возвратом ошибки или OK
        /// </summary>  
        public static string Connection() 
        {
            myConnectionString = "server="+Config.hostMySQL+";uid=avr;pwd=avr;database="+ Config.dbMySQL+ ";charset=utf8;Allow Zero Datetime=true;Connect Timeout=30";
            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();
                return "OK";
            }
            catch (MySqlException ex)
            {
                return "Во время соединения с сервером " + Config.hostMySQL + " и базой данных "+ Config.dbMySQL+" произошла следующаяя ошибка:\n"+ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

		/// <summary>
		/// Проверка необходимости обновлений базы данных
		/// </summary>
		/// <returns></returns>
		public static bool CheckDBUpdate(char UserGrant)
		{
			try
			{
				conn.Open();
				string sql;
				string ver;
				//Проверка необходимости обновлений базы данных для версии 1.0.4.0 (август 2020 года)
				ver = "1.0.4.0";
				sql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='AVR' AND "+
					"TABLE_NAME='journalavr' AND (COLUMN_NAME='P_load' OR COLUMN_NAME='kol_rise' OR COLUMN_NAME='P_rise')" +
					" OR TABLE_NAME='fiders' AND (COLUMN_NAME='P_load_l' OR COLUMN_NAME='P_load_z')";
				using (MySqlCommand cmd = new MySqlCommand(sql, conn))
				{
					var res = cmd.ExecuteScalar();
					if ((long)res == 0)
					{
						if (UserGrant == 'x')
						{
							MySqlCommand UpdateFiders = new MySqlCommand("ALTER TABLE fiders ADD P_load_l DECIMAL(6,3) NOT NULL AFTER population, ADD P_load_z DECIMAL(6,3) NOT NULL AFTER P_load_l", conn);
							UpdateFiders.ExecuteNonQuery();
							MySqlCommand UpdateJournalavr = new MySqlCommand("ALTER TABLE journalavr ADD P_load DECIMAL(6,3) NOT NULL AFTER population, ADD kol_rise INT(11) NOT NULL AFTER P_load, ADD P_rise DECIMAL(6,3) NOT NULL AFTER kol_rise", conn);
							UpdateJournalavr.ExecuteNonQuery();
							System.Windows.Forms.MessageBox.Show("База данных обновлена для работы программы Журнал АВР версии "+ver);
							//return true;  //Было до версии 1.0.5.0
						}
						else
						{
							System.Windows.Forms.MessageBox.Show("Для работы программы Журнал АВР версии "+ver+" и выше необходимо внести изменения в структуру базы данных.\nЭто может сделать только Администратор. Обратитесь к нему.");
							return false;
						}
					}
					if (((long)res > 0) && ((long)res < 5))
					{
						System.Windows.Forms.MessageBox.Show("Предыдущее обновление структуры базы данных для работы программы Журнал АВР версии "+ver+" завершилось неудачей.\nОбратитесь к разработчику.");
						return false;
					}
					//return true;  //Было до версии 1.0.5.0
				}
				//Новое в версии 1.0.5.0
				//Проверка необходимости обновлений базы данных для версии 1.0.5.0 (ноябрь 2020 года)
				ver = "1.0.5.0";
				sql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='AVR' AND " +
					"TABLE_NAME='journalavr' AND (COLUMN_NAME='master_avr2_id' OR COLUMN_NAME='master_avr3_id' OR COLUMN_NAME='master_avr4_id' OR "+
												 "COLUMN_NAME='prinadl_br2' OR COLUMN_NAME='prinadl_br3' OR COLUMN_NAME='prinadl_br4' OR "+
												 "COLUMN_NAME='perem_br2' OR COLUMN_NAME='perem_br3' OR COLUMN_NAME='perem_br4' OR COLUMN_NAME='apvrpv')";
					
				using (MySqlCommand cmd = new MySqlCommand(sql, conn))
				{
					var res = cmd.ExecuteScalar();
					if ((long)res == 0)
					{
						if (UserGrant == 'x')
						{
							MySqlCommand UpdateJournalavr = new MySqlCommand("ALTER TABLE journalavr "+
										"ADD master_avr4_id int(11) NOT NULL AFTER master_avr_id, " +
										"ADD master_avr3_id int(11) NOT NULL AFTER master_avr_id, " +
										"ADD master_avr2_id int(11) NOT NULL AFTER master_avr_id, " +
										"ADD prinadl_br4 VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL AFTER prinadl_br, " +
										"ADD prinadl_br3 VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL AFTER prinadl_br, " +
										"ADD prinadl_br2 VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL AFTER prinadl_br, " +
										"ADD perem_br4 VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL AFTER perem_br, " +
										"ADD perem_br3 VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL AFTER perem_br, " +
										"ADD perem_br2 VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL AFTER perem_br, " +
										"ADD apvrpv tinyint(1) NOT NULL AFTER id_user", conn);
							UpdateJournalavr.ExecuteNonQuery();
							System.Windows.Forms.MessageBox.Show("База данных обновлена для работы программы Журнал АВР версии " + ver);
							//return true;  //Было до версии 1.0.5.0
						}
						else
						{
							System.Windows.Forms.MessageBox.Show("Для работы программы Журнал АВР версии " + ver + " и выше необходимо внести изменения в структуру базы данных.\nЭто может сделать только Администратор. Обратитесь к нему.");
							return false;
						}
					}
					if (((long)res > 0) && ((long)res < 10))
					{
						System.Windows.Forms.MessageBox.Show("Предыдущее обновление структуры базы данных для работы программы Журнал АВР версии " + ver + " завершилось неудачей.\nОбратитесь к разработчику.");
						return false;
					}
					//return true;  //Было до версии 1.0.5.0
				}

				return true;
			}
			catch (Exception ex)
			{
				conn.Close();
				System.Windows.Forms.MessageBox.Show(ex.Message);
				return false;
			}
			finally
			{
				conn.Close();
			}


			//return true;
		}


		/// <summary>
		/// Получить из БД список имен пользователей и вернуть в Combobox.items
		/// </summary> 
		public static bool GetUsersToCombobox(System.Windows.Forms.ComboBox.ObjectCollection items)
        {
            try
            {
                conn.Open();

                string sql = "SELECT username FROM users ORDER BY id_company, id_res, username";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                items.Clear();
                while (rdr.Read())
                {
                    items.Add(rdr[0]);
                }
                rdr.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }


        /// <summary>
        /// Проверить соответствие имени пользователя и пароля
        /// </summary> 
        /// <param name="user">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        public static bool IsValidUser(string user, string password) 
        {
            
            bool UserValid = false;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM users WHERE username = '" + user + "'";
                //string sql = "SELECT * FROM users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                string tuser, tpassword;

                while (rdr.Read())
                {
                    tuser = rdr["username"].ToString();
                    if (tuser == user)
                    {
                        tpassword = rdr["password"].ToString();

                        if ((tpassword.Length == 0)||(tpassword == Config.GetHashString(password)))
                        {
                            //Если логин-пароль верные, то заполняем структуру config.User
                            UserValid = true;
                            Config.LoginUser.Name = rdr["username"].ToString();
                            Config.LoginUser.Id = Convert.ToInt32(rdr["id"].ToString());
                            Config.LoginUser.Grant = rdr["id_grant"].ToString()[0];
                            Config.LoginUser.ResId = Convert.ToInt32(rdr["id_res"].ToString());
                            Config.LoginUser.CompanyId = Convert.ToInt32(rdr["id_company"].ToString());
                            break;
                        }
                    }
                }

                rdr.Close();
                return UserValid;

            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Получить из БД список Организаций и внести из в config.Companies
        /// </summary> 
        public static bool GetCompanies()
        {
            try
            {
                conn.Open();
                //Выборка всех РЭС-ов организации
                string sql = "SELECT * FROM companies";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Config.Companies.Clear();
                while (rdr.Read())
                {
					Config.Company tempCompany = new Config.Company
					{
						Id = Convert.ToInt32(rdr["id"].ToString()),
						Name = rdr["companyname"].ToString(),
						FullName = rdr["fullname"].ToString()
					};

					Config.Companies.Add(tempCompany.Name, tempCompany);

                }
                rdr.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }


        /// <summary>
        /// Получить из БД список РЭС-ов и внести их в config.Reses
        /// </summary> 
        public static bool GetReses()
        {
            try
            {
                conn.Open();
                //Выборка всех РЭС-ов организации (не только РЭСа пользователя, т.к. в дальнейшем понадобятся названия других РЭС-ов)
                string sql;
                if (Config.LoginUser.CompanyId > 0)
                     sql= "SELECT * FROM reses WHERE id_company=" + Config.LoginUser.CompanyId.ToString();
                else
                    sql = "SELECT * FROM reses" ;


                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Config.Reses.Clear();
                while (rdr.Read())
                {
					Config.Res tempRes = new Config.Res
					{
						Id = Convert.ToInt32(rdr["id"].ToString()),
						Name = rdr["resname"].ToString(),
						FromCompanyId = Convert.ToInt32(rdr["id_company"].ToString())
					};

					Config.Reses.Add(tempRes.Name, tempRes);
                }
                rdr.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }


        /// <summary>
        /// Получить из БД список фидеров 10 кв и внести их в config.Fiders10
        /// </summary> 
        public static bool GetFiders()
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM fiders "; 
                if (Config.LoginUser.ResId > 0)
                {
                    //Выборка всех фидеров организации, относящихся к РЭС-у пользователя
                    sql += "WHERE id_res=" + Config.LoginUser.ResId.ToString()+ " AND id_company=" + Config.LoginUser.CompanyId.ToString();
                }
                else
                {
                    //Выборка всех фидеров организации
                    sql += "WHERE id_company=" + Config.LoginUser.CompanyId.ToString();
                }

				//Добавим "хитрую" сортировку по символам в названии фидера после строки "ПС"
				//sql += " AND  fidertype=0 AND deleted=false ORDER BY id_res, CAST(SUBSTRING_INDEX(fidername, " + config.Sortvl10 + ", -1) AS CHAR)";
				// И по арендованным линиям POSITION('(аренда)' in LCASE(fidername)) (Версия 1.0.3.2)
				//Было до версии 1.0.5.1
				//sql += " AND  fidertype=0 AND deleted=false ORDER BY id_res, POSITION('(аренда)' in LCASE(fidername)), CAST(SUBSTRING_INDEX(fidername, " + Config.Sortvl10 + ", -1) AS CHAR)";
				sql += " AND  fidertype=0 ORDER BY id_res, POSITION('(аренда)' in LCASE(fidername)), CAST(SUBSTRING_INDEX(fidername, " + Config.Sortvl10 + ", -1) AS CHAR)";


				MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Config.Fiders.Clear();
                while (rdr.Read())
                {
					Config.Fider tempFider = new Config.Fider
					{
						Id = Convert.ToInt32(rdr["id"].ToString()),
						FiderType = Convert.ToByte(rdr["fidertype"].ToString()),
						Name = rdr["fidername"].ToString(),
						FromResId = Convert.ToInt32(rdr["id_res"].ToString()),
						FromCompanyId = Convert.ToInt32(rdr["id_company"].ToString()),
						TP = Convert.ToInt32(rdr["TP"].ToString()),
						SZO = Convert.ToInt32(rdr["SZO"].ToString()),
						NP = Convert.ToInt32(rdr["NP"].ToString()),
						Population = Convert.ToInt32(rdr["population"].ToString()),
						P_load_l = Convert.ToDecimal(rdr["P_load_l"].ToString()),     //Новое в версии 1.0.4.0
						P_load_z = Convert.ToDecimal(rdr["P_load_z"].ToString())     //Новое в версии 1.0.4.0
					};
					Config.Fiders.Add(tempFider.Name, tempFider);
                }
                rdr.Close();

                //0.4 фидера
                sql = "SELECT * FROM fiders ";

                if (Config.LoginUser.ResId > 0)
                {
                    //Выборка всех фидеров организации, относящихся к РЭС-у пользователя
                    sql += "WHERE id_res=" + Config.LoginUser.ResId.ToString() + " AND id_company=" + Config.LoginUser.CompanyId.ToString();
                }
                else
                {
                    //Выборка всех фидеров организации
                    sql += "WHERE id_company=" + Config.LoginUser.CompanyId.ToString();
                }
				//Добавим "хитрую" сортировку по числам в названии фидера после строки "ТП №" 
				//sql += " AND  fidertype=1 AND deleted=false ORDER BY id_res, CAST(SUBSTRING_INDEX(fidername, " + config.Sortvl04 + ", -1) AS signed)";
				// И по арендованным линиям POSITION('(аренда)' in LCASE(fidername)) (Версия 1.0.3.2)
				//Было до версии 1.0.5.1
				//sql += " AND  fidertype=1 AND deleted=false ORDER BY id_res, POSITION('(аренда)' in LCASE(fidername)),CAST(SUBSTRING_INDEX(fidername, " + Config.Sortvl04 + ", -1) AS signed)";
				sql += " AND fidertype=1 ORDER BY id_res, POSITION('(аренда)' in LCASE(fidername)),CAST(SUBSTRING_INDEX(fidername, " + Config.Sortvl04 + ", -1) AS signed)";

				//System.Windows.Forms.Clipboard.SetText(sql);

				cmd.CommandText = sql;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
					Config.Fider tempFider = new Config.Fider
					{
						Id = Convert.ToInt32(rdr["id"].ToString()),
						FiderType = Convert.ToByte(rdr["fidertype"].ToString()),
						Name = rdr["fidername"].ToString(),
						FromResId = Convert.ToInt32(rdr["id_res"].ToString()),
						FromCompanyId = Convert.ToInt32(rdr["id_company"].ToString()),
						TP = Convert.ToInt32(rdr["TP"].ToString()),
						SZO = Convert.ToInt32(rdr["SZO"].ToString()),
						NP = Convert.ToInt32(rdr["NP"].ToString()),
						Population = Convert.ToInt32(rdr["population"].ToString()),
						P_load_l = Convert.ToDecimal(rdr["P_load_l"].ToString()),     //Новое в версии 1.0.4.0
						P_load_z = Convert.ToDecimal(rdr["P_load_z"].ToString())     //Новое в версии 1.0.4.0
					};
					Config.Fiders.Add(tempFider.Name, tempFider);
                }
                rdr.Close();

                //35/110 фидера
                sql = "SELECT * FROM fiders ";
                if (Config.LoginUser.ResId > 0)
                {
                    //Выборка всех фидеров организации, относящихся к РЭС-у пользователя
                    sql += "WHERE id_res=" + Config.LoginUser.ResId.ToString() + " AND id_company=" + Config.LoginUser.CompanyId.ToString();
                }
                else
                {
                    //Выборка всех фидеров организации
                    sql += "WHERE id_company=" + Config.LoginUser.CompanyId.ToString();
                }
				//Добавим сортировку арендованным линиям POSITION('(аренда)' in LCASE(fidername)) (Версия 1.0.3.2)
				//Было до версии 1.0.5.1
				//sql += " AND  fidertype=2 AND deleted=false ORDER BY id_res, POSITION('(аренда)' in LCASE(fidername)), fidername";
				sql += " AND fidertype=2 ORDER BY id_res, POSITION('(аренда)' in LCASE(fidername)), fidername";
				cmd.CommandText = sql;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
					Config.Fider tempFider = new Config.Fider
					{
						Id = Convert.ToInt32(rdr["id"].ToString()),
						FiderType = Convert.ToByte(rdr["fidertype"].ToString()),
						Name = rdr["fidername"].ToString(),
						FromResId = Convert.ToInt32(rdr["id_res"].ToString()),
						FromCompanyId = Convert.ToInt32(rdr["id_company"].ToString()),
						TP = Convert.ToInt32(rdr["TP"].ToString()),
						SZO = Convert.ToInt32(rdr["SZO"].ToString()),
						NP = Convert.ToInt32(rdr["NP"].ToString()),
						Population = Convert.ToInt32(rdr["population"].ToString()),
						P_load_l = Convert.ToDecimal(rdr["P_load_l"].ToString()),     //Новое в версии 1.0.4.0
						P_load_z = Convert.ToDecimal(rdr["P_load_z"].ToString())     //Новое в версии 1.0.4.0
					};
					Config.Fiders.Add(tempFider.Name, tempFider);
                }
                rdr.Close();


                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// Получить из БД список Мастеров и внести их в config.Masters
        /// </summary> 
        public static bool GetMasters()
        {
            try
            {
                conn.Open();
                string sql = "";

                /* Отключаю, так как в поле принадлежности бригад могут быть мастера с разных РЭС-ов
                if (config.LoginUser.ResId > 0){
                    //Выборка всех мастеров организации, относящихся к РЭС-у пользователя
                    sql = "SELECT * FROM masters WHERE id_res=" + config.LoginUser.ResId.ToString() + " AND id_company=" + config.LoginUser.CompanyId.ToString();
                }else{
                    //Выборка всех мастеров организации
                    sql = "SELECT * FROM masters WHERE id_company=" + config.LoginUser.CompanyId.ToString();}
                */

                //Выборка всех мастеров организации
                sql = "SELECT * FROM masters WHERE id_company=" + Config.LoginUser.CompanyId.ToString()+ " AND deleted = false ORDER by id_res, fio";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Config.Masters.Clear();
                while (rdr.Read())
                {
					Config.Master tempMaster = new Config.Master
					{
						Id = Convert.ToInt32(rdr["id"].ToString()),
						Fio = rdr["fio"].ToString(),
						Dol = rdr["dol"].ToString(),
						Tel = rdr["tel"].ToString(),
						FromResId = Convert.ToInt32(rdr["id_res"].ToString()),
						FromCompanyId = Convert.ToInt32(rdr["id_company"].ToString()),
						FromFilialId = Convert.ToInt32(rdr["id_filial"].ToString())
					};

					Config.Masters.Add(tempMaster.Fio, tempMaster);
                }
                rdr.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }


        /// <summary>
        /// Получить словарь филиалов
        /// </summary>
        /// <returns></returns>
        public static bool GetFilials()
        {
            if (Config.LoginUser.CompanyId > 0)
            {
                try
                {
                    conn.Open();
                    string sql = "";
                    //Выборка всех filials
                    sql = "SELECT * FROM filials ORDER by id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    Config.Filials.Clear();
                    string temp_PO_name = Config.Companies.Values.First(p => p.Id == Config.LoginUser.CompanyId).FullName.Replace("\"",""); //В версии 1.0.3.5 Name изменён на FullName

                    while (rdr.Read())
                    {
						Config.Filial tempFL = new Config.Filial
						{
							Id = Convert.ToInt32(rdr["id"].ToString()),
							Name = rdr["name"].ToString()
						};
						if (tempFL.Name.IndexOf(temp_PO_name)<0)
                            Config.Filials.Add(tempFL.Name, tempFL);
                    }
                    rdr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }else
            { return true; }

        }


        /// <summary>
        /// Получение переменной необходимости обновления словарей
        /// </summary>
        /// <returns></returns>
        public static bool GetMaxUpdateId()
        {
            try
            {
                conn.Open();

                string sql = "SELECT MAX(id) FROM updatelog WHERE id_company ="+ Config.LoginUser.CompanyId.ToString();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                    Config.MAXUpdateLogId = Convert.ToInt32(result);
                return true; 
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Получение переменной необходимости обновления словарей
        /// </summary>
        /// <returns></returns>
        public static bool GetMaxUpdateJournalId()
        {
            try
            {
                conn.Open();

                string sql = "SELECT MAX(id) FROM updatejournal WHERE id_company =" + Config.LoginUser.CompanyId.ToString();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                    Config.MAXUpdateJournalId = Convert.ToInt32(result);
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// Добавить новое отключение в базу
        /// </summary>
        /// <param name="avr">Параметры отключения</param>
        /// <returns></returns>
        public static bool AddNewAvr(Config.Journal avr)
        {
            string sql = "";
            try
            {
                conn.Open();

				avr.d_osm = avr.d_osm ?? "0000-00-00";
				avr.d_avr = avr.d_avr ?? "0000-00-00";
				avr.d_vkl_vl = avr.d_vkl_vl ?? "0000-00-00";
				avr.d_vkl_potr = avr.d_vkl_potr ?? "0000-00-00";


				sql = "INSERT INTO `journalavr` (`id_company`, `id_res`, `id_fider`, `TP`, `SZO`, `NP`, `population`,`P_load`, `kol_rise`, `P_rise`, `d_otkl`, `t_otkl`," +
                                             "`d_osm`,`t_osm`, `kol_br_osm`, `kol_pers_osm`, `master_osm_id1`, `master_osm_id2`, `master_osm_id3`, `master_osm_id4`, "+
                                             "`result_osm`, `d_avr`, `t_avr`, `d_vkl_vl`, `t_vkl_vl`, `kol_br_avr`, "+
											 "`kol_pers_avr`, `master_avr_id`, `master_avr2_id`, `master_avr3_id`, `master_avr4_id`, `basa_avr`, `teh_agp`, `teh_bkm`, `teh_kran`, " +
											 "`prinadl_br`, `prinadl_br2`, `prinadl_br3`, `prinadl_br4`, `t_plan_okon`, `obem_rabot`, `perem_br`, `perem_br2`, `perem_br3`, `perem_br4`, `d_vkl_potr`, `t_vkl_potr`, `id_user`, `apvrpv`, `endofwork`) " +
                        "VALUES (" +
                        avr.id_company.ToString() + "," +
                        avr.id_res.ToString() + "," +
                        avr.id_fider.ToString() + "," +
                        avr.TP.ToString() + "," +
                        avr.SZO.ToString() + "," +
                        avr.NP.ToString() +","+
                        avr.population.ToString()+"," +
						avr.P_load.ToString().Replace(',','.') + "," +		//Новое в версии 1.0.4.0
						avr.kol_rise.ToString() + "," +						//Новое в версии 1.0.4.0
						avr.P_rise.ToString().Replace(',', '.') +			//Новое в версии 1.0.4.0
						",'" + avr.d_otkl+"','"+
                        avr.t_otkl+"','"+
                        avr.d_osm + "','" +
                        avr.t_osm+"',"+
                        avr.kol_br_osm.ToString()+ ","+
                        avr.kol_pers_osm.ToString()+ "," +
                        avr.master_osm_id1+ "," +
                        avr.master_osm_id2+ "," +
                        avr.master_osm_id3+ "," +
                        avr.master_osm_id4 + ",'" +
                        avr.result_osm + "','" +
                        avr.d_avr+ "','" +
                        avr.t_avr+ "','" +
                        avr.d_vkl_vl+ "','" +
                        avr.t_vkl_vl+ "'," +
                        avr.kol_br_avr.ToString()+ "," +
                        avr.kol_pers_avr.ToString()+ "," +
						avr.master_avr_id + "," +
						avr.master_avr2_id + "," +					//Новое в версии 1.0.5.0
						avr.master_avr3_id + "," +                 //Новое в версии 1.0.5.0
						avr.master_avr4_id + ",'" +                 //Новое в версии 1.0.5.0
						avr.basa_avr + "'," +
						avr.teh_agp.ToString()+ "," +
                        avr.teh_bkm.ToString()+ "," +
                        avr.teh_kran.ToString()+ ",'" +
						avr.prinadl_br + "','" +
						avr.prinadl_br2 + "','" +                   //Новое в версии 1.0.5.0
						avr.prinadl_br3 + "','" +                   //Новое в версии 1.0.5.0
						avr.prinadl_br4 + "','" +                   //Новое в версии 1.0.5.0
						avr.t_plan_okon+ "','" +
                        avr.obem_rabot+ "','" +
                        avr.perem_br + "','" +
						avr.perem_br2 + "','" +                   //Новое в версии 1.0.5.0
						avr.perem_br3 + "','" +                   //Новое в версии 1.0.5.0
						avr.perem_br4 + "','" +                   //Новое в версии 1.0.5.0
						avr.d_vkl_potr+ "','" +
                        avr.t_vkl_potr+ "'," +
                        avr.id_user.ToString()+ "," +
						avr.apvrpv.ToString() + "," +
						avr.endofwork.ToString()+")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message+"\n"+sql);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Обновить данные по отключению в базе
        /// </summary>
        /// <param name="avr">Параметры отключения</param>
        /// <returns></returns>

        public static bool UpdateAvr(Config.Journal avr)
        {
            string sql = "";
            try
            {
                conn.Open();
                avr.d_osm = avr.d_osm ?? "0000-00-00";
                avr.d_avr = avr.d_avr ?? "0000-00-00";
                avr.d_vkl_vl = avr.d_vkl_vl ?? "0000-00-00";
                avr.d_vkl_potr = avr.d_vkl_potr ?? "0000-00-00";

                //string sql = "";
                sql = "UPDATE `journalavr` SET "+
                    "`id_company`=" + avr.id_company.ToString() + ",`id_res`="+avr.id_res.ToString()+ ",`id_fider`="+avr.id_fider.ToString()+
                    ",`TP`="+avr.TP.ToString()+ ",`SZO`="+avr.SZO.ToString()+ ",`NP`="+avr.NP.ToString()+ ",`population`="+avr.population.ToString()+
					",`P_load`=" + avr.P_load.ToString().Replace(',', '.') + ",`kol_rise`=" + avr.kol_rise.ToString() + ",`P_rise`=" + avr.P_rise.ToString().Replace(',', '.') +   //Новое в версии 1.0.4.0
					",`d_otkl`='" +avr.d_otkl+ "',`t_otkl`='"+avr.t_otkl+ "',`d_osm`='"+avr.d_osm+ "',`t_osm`='"+avr.t_osm+
                    "',`kol_br_osm`="+avr.kol_br_osm.ToString()+ ",`kol_pers_osm`="+ avr.kol_pers_osm.ToString()+
                    ",`master_osm_id1`=" + avr.master_osm_id1 +
                    ",`master_osm_id2`=" + avr.master_osm_id2 +
                    ",`master_osm_id3`=" + avr.master_osm_id3 +
                    ",`master_osm_id4`=" + avr.master_osm_id4 +
                    ",`result_osm`='" + avr.result_osm+"',`d_avr`='"+avr.d_avr+"',`t_avr`='"+avr.t_avr+"',`d_vkl_vl`='"+avr.d_vkl_vl+"',`t_vkl_vl`='"+avr.t_vkl_vl+
                    "',`kol_br_avr`="+avr.kol_br_avr.ToString()+",`kol_pers_avr`="+avr.kol_pers_avr.ToString()+
					",`master_avr_id`=" + avr.master_avr_id +
					",`master_avr2_id`=" + avr.master_avr2_id +//Новое в версии 1.0.5.0
					",`master_avr3_id`=" + avr.master_avr3_id +//Новое в версии 1.0.5.0
					",`master_avr4_id`=" + avr.master_avr4_id +//Новое в версии 1.0.5.0
					",`basa_avr`='" + avr.basa_avr+"',`teh_agp`="+avr.teh_agp.ToString()+",`teh_bkm`="+avr.teh_bkm.ToString()+",`teh_kran`="+avr.teh_kran.ToString()+
					",`prinadl_br`='" + avr.prinadl_br +
					"',`prinadl_br2`='" + avr.prinadl_br2 +//Новое в версии 1.0.5.0
					"',`prinadl_br3`='" + avr.prinadl_br3 +//Новое в версии 1.0.5.0
					"',`prinadl_br4`='" + avr.prinadl_br4 +//Новое в версии 1.0.5.0
					"',`t_plan_okon`='" + avr.t_plan_okon+"',`obem_rabot`='"+avr.obem_rabot+
					"',`perem_br`='" + avr.perem_br +
					"',`perem_br2`='" + avr.perem_br2 +//Новое в версии 1.0.5.0
					"',`perem_br3`='" + avr.perem_br3 +//Новое в версии 1.0.5.0
					"',`perem_br4`='" + avr.perem_br4 +//Новое в версии 1.0.5.0
					"',`d_vkl_potr`='" + avr.d_vkl_potr+"',`t_vkl_potr`='"+avr.t_vkl_potr+
                    "',`id_user`="+avr.id_user.ToString()+ ",`apvrpv`=" + avr.apvrpv.ToString() + ",`endofwork`=" +avr.endofwork.ToString()+" WHERE id="+avr.id;


                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + sql);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        
        public static bool ShowJournal(System.Data.DataTable dt)
        {
            try
            {

                string sql = "SELECT r.resname, f.fidername, f.fidertype ,j.*, u.username FROM journalavr j, reses r, fiders f, users u ";
                if (Config.LoginUser.ResId > 0)
                {
                    sql += "WHERE j.id_res=" + Config.LoginUser.ResId.ToString() + " AND j.id_company=" + Config.LoginUser.CompanyId.ToString();
                }
                else
                {
                    sql += "WHERE j.id_company=" + Config.LoginUser.CompanyId.ToString();
                }

                sql += " AND j.id_res=r.id AND j.id_fider=f.id AND j.id_user=u.id ORDER BY f.fidertype, j.d_otkl, j.t_otkl";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                dt.Clear();
                MySqlDataReader rdr = cmd.ExecuteReader();
                
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                }
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                /*
                System.Data.DataRow[] rowsInError;
                rowsInError = dt.GetErrors();
                // Print the error of each column in each row.
                for (int i = 0; i < rowsInError.Length; i++)
                {
                    foreach (System.Data.DataColumn column in dt.Columns)
                    {
                        System.Windows.Forms.MessageBox.Show(column.ColumnName + " " +
                            rowsInError[i].GetColumnError(column));
                    }
                    // Clear the row errors
                    rowsInError[i].ClearErrors();
                }*/

                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// Проверка, находится ли фидер уже в ремонте 
        /// </summary>
        /// <param name="FiderId">id фидера</param>
        /// <returns></returns>
        public static bool FiderInAvr(int FiderId)
        {
            try
            {
                conn.Open();

                string sql = "SELECT COUNT(id_fider) FROM journalavr WHERE id_fider=" + FiderId.ToString()+ " AND endofwork = false";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int r = Convert.ToInt32(result);
                    if (r>0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }


        }

        /// <summary>
        /// Найти в журналы все фидера, находящиеся в ремонте и загрузить их в ComboBox
        /// </summary>
        /// <param name="sender">ссылка на ComboBox</param>
        public static void FiderInAvrToCombobox(object sender, int CurrentFiderID=-1)
        {
            try
            {
                
                string sql = "SELECT f.fidername,j.* FROM journalavr j, fiders f ";
                if (Config.LoginUser.ResId > 0)
                {
                    sql += "WHERE j.id_res=" + Config.LoginUser.ResId.ToString() + " AND j.id_company=" + Config.LoginUser.CompanyId.ToString();
                }
                else
                {
                    sql += "WHERE j.id_company=" + Config.LoginUser.CompanyId.ToString();
                }
                if (CurrentFiderID > 0) sql += " AND j.id_fider<>"+CurrentFiderID.ToString();

                sql += " AND j.id_fider=f.id " + " AND endofwork = false"+ " ORDER BY f.fidername";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    (sender as System.Windows.Forms.ComboBox).Items.Add (rdr["fidername"].ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                conn.Close();
            }


        }


        /// <summary>
        /// Удаление отключения из журнала
        /// </summary>
        /// <param name="JoirnalID">ID номер отключения в журнале</param>
        /// <returns></returns>
        public static bool DeleteAvr(String JoirnalID)
        {
            try
            {
                conn.Open();
                string sql = "DELETE FROM `journalavr` WHERE id="+ JoirnalID;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Удаление все отключение из бжурнала
        /// </summary>
        public static bool ClearJournal()
        {
            try
            {
                conn.Open();
                string sql = "DELETE FROM `journalavr`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// Добавить новый фидер в базу
        /// </summary>
        public static bool AddNewFiderInBase(string FiderName, int Type, int id_res, int id_company, int TP, int SZO, int NP, int population, decimal P_load_l, decimal P_load_z)
        {
            try
            {
                conn.Open();
                string sql = "";
                sql = "INSERT INTO `fiders`(`fidertype`, `fidername`, `id_res`, `id_company`, `TP`, `SZO`, `NP`, `population`, `P_load_l`, `P_load_z`) " +
                        "VALUES (" +
                        Type.ToString() + ",'" +
                        FiderName + "'," +
                        id_res.ToString() + "," +
                        id_company.ToString() + "," +
                        TP.ToString() + "," +
                        SZO.ToString() + "," +
                        NP.ToString() + "," +
                        population.ToString() + ","+
						P_load_l.ToString().Replace(',', '.') + "," +		//Новое в версии 1.0.4.0
						P_load_z.ToString().Replace(',', '.') +				//Новое в версии 1.0.4.0
						")";

				MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

                GetFiders(); // Обновим список фидеров

                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Удалить фидер из базы (установить ему признак удалён)
        /// </summary>
        /// <param name="id">ID Фидера</param>
        /// <returns></returns>
        public static bool DeleteFiderFromBase(int id)
        {
            try
            {
                conn.Open();
                string sql = "";
                
                //проверка, нет ли ссылок на данный фидер в журнале.
                sql = "SELECT COUNT(id_fider) FROM journalavr WHERE id_fider=" + id.ToString();

                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                object result = cmd1.ExecuteScalar();

                if (result != null)
                {
                    int r = Convert.ToInt32(result);
                    if (r > 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Удаление невозможно, так как на выбранный фидер есть ссылки в журнале отключений.");
                        return false;
                    }
                }

				//Было до версии 1.0.5.1
				//sql = "UPDATE fiders SET deleted= 1 WHERE id =" + id.ToString();
				sql = "DELETE FROM fiders WHERE id =" + id.ToString();


				MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                conn.Close();

                GetFiders(); // Обновим список фидеров

                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

		public static bool DeleteFidersGroupFromBase(int Company, int Res, int TypeVL)
		{
			try
			{
				conn.Open();
				string sql = "";

				//проверка, нет ли ссылок на данный фидер в журнале.
				sql = $"SELECT COUNT(id_fider) FROM journalavr WHERE id_company={Company.ToString()} AND id_res={Res.ToString()}";

				MySqlCommand cmd1 = new MySqlCommand(sql, conn);
				object result = cmd1.ExecuteScalar();

				if (result != null)
				{
					int r = Convert.ToInt32(result);
					if (r > 0)
					{
						System.Windows.Forms.MessageBox.Show($"Удаление невозможно, так как в журнале отключений есть объекты подразделения {Config.Reses.Values.First(p => p.Id == Res).Name}.");
						return false;
					}
				}

				//Было до версии 1.0.5.1
				//sql = $"UPDATE fiders SET deleted= 1 WHERE id_company={Company.ToString()} AND id_res={Res.ToString()} AND fidertype={TypeVL.ToString()}";
				sql = $"DELETE FROM fiders WHERE id_company={Company.ToString()} AND id_res={Res.ToString()} AND fidertype={TypeVL.ToString()}";
			
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				cmd.ExecuteNonQuery();


				conn.Close();

				GetFiders(); // Обновим список фидеров

				return true;
			}
			catch (Exception ex)
			{
				conn.Close();
				System.Windows.Forms.MessageBox.Show(ex.Message);
				return false;
			}
			finally
			{
				conn.Close();
			}

		}


		/// <summary>
		/// Изменить данные о фидере в базе (Название, кол-во ТП, СЗО, Нас.пунктов, населения)
		/// </summary>
		/// <param name="id"></param>
		/// <param name="FiderName"></param>
		/// <param name="TP"></param>
		/// <param name="SZO"></param>
		/// <param name="NP"></param>
		/// <param name="population"></param>
		/// <returns></returns>
		public static bool EditFiderFromBase(int id, string FiderName, int TP, int SZO, int NP, int population, decimal P_load_l, decimal P_load_z)
        {
            try
            {
                conn.Open();
                string sql = "UPDATE fiders SET fidername='"+ FiderName + "', TP="+TP.ToString()+", SZO="+SZO.ToString()+", NP="+NP.ToString() + ", population=" + population.ToString() +
					", P_load_l=" + P_load_l.ToString().Replace(',', '.') + ", P_load_z=" + P_load_z.ToString().Replace(',', '.') + " WHERE id =" + id.ToString();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

                GetFiders(); // Обновим список фидеров

                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

        }

        public static bool FindMasterInBase(string FIO)
        {
            try
            {
                conn.Open();
				string sql = "SELECT id FROM masters WHERE fio='" + FIO + "'";

				MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool FindFiderInBase(string fidername)
        {
            try
            {
                conn.Open();
				string sql = "SELECT id FROM fiders WHERE fidername='" + fidername + "'";

				MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }
        public static bool AddNewMasterInBase(string FIO, string dol, string tel, int id_res, int id_company, int id_filial=0)
        {
            
            try
            {
                conn.Open();
                string sql = "INSERT INTO `masters`(`fio`, `dol`, `tel`, `id_res`, `id_company`,`id_filial`) " +
                        "VALUES ('" +
                         FIO + "','" +
                         dol + "','" +
                         tel + "'," +
                         id_res.ToString() + "," +
                         id_company.ToString() + "," +
                         id_filial.ToString() + ")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                conn.Close();

                GetMasters(); // Обновим список мастеров

                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }


        }

        public static bool EditMasterInBase(int id, string fio, string dol, string tel, int id_filial= 0)
        {
            try
            {
                conn.Open();
                string sql = "UPDATE masters SET fio='"+fio+"', dol='"+dol+"', tel='"+tel+ "', `id_filial`="+ id_filial.ToString()+ "  WHERE id =" + id.ToString();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

                GetMasters(); // Обновим список фидеров

                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }


        }

        public static bool DeleteMasterFromBase(int id)
        {
            try
            {
                conn.Open();
                int RCount = 0;
				
				//проверка, нет ли ссылок на данного мастера в журнале.
				string sql = "SELECT COUNT(master_osm_id1) FROM journalavr WHERE master_osm_id1=" + id.ToString();
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                object result1 = cmd1.ExecuteScalar();
                if (result1 != null)
                {
                    int r = Convert.ToInt32(result1);
                    if (r > 0) RCount++;
                }
                sql = "SELECT COUNT(master_osm_id2) FROM journalavr WHERE master_osm_id2=" + id.ToString();
                MySqlCommand cmd2 = new MySqlCommand(sql, conn);
                object result2 = cmd2.ExecuteScalar();
                if (result2 != null)
                {
                    int r = Convert.ToInt32(result2);
                    if (r > 0) RCount++;
                }
                sql = "SELECT COUNT(master_osm_id3) FROM journalavr WHERE master_osm_id3=" + id.ToString();
                MySqlCommand cmd3 = new MySqlCommand(sql, conn);
                object result3 = cmd3.ExecuteScalar();
                if (result3 != null)
                {
                    int r = Convert.ToInt32(result3);
                    if (r > 0) RCount++;
                }
                sql = "SELECT COUNT(master_osm_id4) FROM journalavr WHERE master_osm_id4=" + id.ToString();
                MySqlCommand cmd4 = new MySqlCommand(sql, conn);
                object result4 = cmd4.ExecuteScalar();
                if (result4 != null)
                {
                    int r = Convert.ToInt32(result4);
                    if (r > 0) RCount++;
                }
                sql = "SELECT COUNT(master_avr_id) FROM journalavr WHERE master_avr_id=" + id.ToString();
                MySqlCommand cmd5 = new MySqlCommand(sql, conn);
                object result5 = cmd5.ExecuteScalar();
                if (result5 != null)
                {
                    int r = Convert.ToInt32(result5);
                    if (r > 0) RCount++;
                }


                if (RCount>0)
                {
                    System.Windows.Forms.MessageBox.Show("Удаление невозможно, так как на выбранного мастера есть ссылки в журнале отключений.");
                    return false;
                }



                sql = "UPDATE masters SET deleted= 1 WHERE id =" + id.ToString();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                conn.Close();

                GetMasters(); // Обновим список фидеров

                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public static bool AddNewUserInBase(string username, string pass, char id_grant, int id_res, int id_company)
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO `users`(`username`, `password`, `id_grant`, `id_res`, `id_company`) " +
                        "VALUES ('" +
                         username + "','" +
                         pass + "','" +
                         id_grant + "'," +
                         id_res.ToString() + "," +
                         id_company.ToString() + ")";
                

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }


        }

        /// <summary>
        /// Получить количество ПО в базе
        /// </summary>
        /// <returns>кол-во ПО</returns>
        public static int GetCountCompanyInBase()
        {
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(id) FROM companies";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else return 0;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }

        }

        public static bool AddNewCompanyInBase(string companyname, string maincompany)
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO `companies`(`companyname`, `fullname`) " +
                        "VALUES ('" + companyname + "','" + maincompany +"')";

                MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                GetCompanies();

                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

        }

        public static bool AddNewResInBase(string resname, int id_company)
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO `reses`(`resname`, `id_company`)" +
                        "VALUES ('" +
                         resname + "'," +
                         id_company.ToString() + ")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                GetReses();

                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool AddNewFilialInBase(string companyname)
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO `filials`(`name`)" +
                        "VALUES ('" +
                         companyname + "')";

                MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                GetFilials();

                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

        }


        /// <summary>
        /// Получить из базы кол-во фидеров
        /// </summary>
        /// <param name="FiderType">Тип ВЛ</param>
        /// <returns></returns>
        public static int GetCountFiders(int FiderType)
        {
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(j.id) FROM journalavr j, fiders f ";
                if (Config.LoginUser.ResId > 0)
                {
                    sql += "WHERE j.id_res=" + Config.LoginUser.ResId.ToString() + " AND j.id_company=" + Config.LoginUser.CompanyId.ToString();
                }
                else
                {
                    sql += "WHERE j.id_company=" + Config.LoginUser.CompanyId.ToString();
                }
                sql += " AND j.id_fider=f.id AND fidertype=" + FiderType.ToString();

                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                object result = cmd1.ExecuteScalar();

                if (result != null)
                    return Convert.ToInt32(result);
                else
                    return 0;
            }
            catch 
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool FindMasterInJournal(int masterid, int journalid)
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM journalavr WHERE id_company=" + Config.LoginUser.CompanyId.ToString()+ " AND endofwork = false AND ID<>"+ journalid;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (Convert.ToInt32(rdr["master_avr_id"].ToString())>0)//если заполнен мастер на ремонте, то
                    {
                        if (Convert.ToInt32(rdr["master_avr_id"].ToString()) == masterid)
                            return false;
                    } else //значит идёт осмотор.
                    {
						if((rdr["result_osm"]).ToString().Trim()=="") //Если результат осмотра не указан
						{
							if (Convert.ToInt32(rdr["master_osm_id1"].ToString()) == masterid)
								return false;
							if (Convert.ToInt32(rdr["master_osm_id2"].ToString()) == masterid)
								return false;
							if (Convert.ToInt32(rdr["master_osm_id3"].ToString()) == masterid)
								return false;
							if (Convert.ToInt32(rdr["master_osm_id3"].ToString()) == masterid)
								return false;
						}

					}
                }
                rdr.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        //1.0.3.5
        /// <summary>
        /// Удаление всего командированного персонала
        /// </summary>
        /// <returns></returns>
        public static bool DelAllComandMasters()
        {
            try
            {
                conn.Open();
                string sql = "UPDATE masters SET deleted=1 WHERE id_res=999999999 AND id_company=" + Config.LoginUser.CompanyId.ToString();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
