using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Diagnostics;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Net;
using HtmlAgilityPack;
using Ivony.Html;
using Ivony.Html.Parser;
using System.Web;

namespace Assistant
{
    public partial class Main : Form
    {
        public Main()
        {
            Cheack_User cu = new Cheack_User();
            cu.ShowDialog();
            InitializeComponent();
            Load_something();
            DataView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            DataView.RowsDefaultCellStyle.WrapMode = (DataGridViewTriState.True);
        }
        string Robot_id;
        string Key = "";
        int Threads_Num = 2;
        public static Stopwatch watch = new Stopwatch();
        public static Queue<String> all_site = new Queue<string>();
        public static Queue<String> all_firs_jsontxt = new Queue<string>();
        Majestic_Filter_results mfr_data = new Majestic_Filter_results();
        MySQLDBHelp mysqlhelpr = new MySQLDBHelp();
        Class_box class_Box = new Class_box();
        bool get_cond_chinese, get_cond_nobet, get_cond_nosexy, get_cond_nonull, Query_thread_switch;
        List<string> bc_key, sexy_key, Cookie_name, Cookie_value;
        string select_switch;
        CookieContainer cookieContainer;
        
        /// <summary>
        /// 预加载
        /// </summary>
        private void Load_something()
        {
            get_cond_chinese = false;
            get_cond_nobet = false;
            get_cond_nosexy = false;
            get_cond_nonull = false;
            Robot_id = Class_box.GetRandomString(16, true, true, true, false, "");
            String line;
            try
            {
                StreamReader sr = new StreamReader("Key.txt");

                line = sr.ReadLine();
                while (line != null)
                {
                    Key_list.Items.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
       
        public void Information_loading(string Select_type)
        {
            switch (Select_type)
            {
                case "api":
                    if (Domain_Box.Lines.Count() == 0 || Key_list.Text.Count() == 0)
                    {
                        MessageBox.Show("检查域名或者KEY格式是否正确？", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
                case "web":
                    if (cookie_box.Lines.Count() == 0)
                    {
                        MessageBox.Show("Cookie不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DataSet ds = MySQLDBHelp.Query_for_mysql("select Id,Robot_num,TIME_TO_SEC(NOW()) - TIME_TO_SEC(Last_road_time) from user_number_control;");
                    if (ds == null)
                    {
                        MessageBox.Show("数据库连接失败，请检查网络！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bool free = false;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Robot_id == ds.Tables[0].Rows[i][1].ToString())
                        {
                            MySQLDBHelp.GetSingle("update user_number_control set Last_road_time = now() where Robot_num = '" + Robot_id + "';");
                            free = true;
                            break;
                        }
                        else
                        {
                            if (int.Parse(ds.Tables[0].Rows[i][2].ToString()) > 120 || int.Parse(ds.Tables[0].Rows[i][2].ToString()) < -120)
                            {
                                MySQLDBHelp.GetSingle("update user_number_control set Robot_num = '" + Robot_id + "',Last_road_time = now() where Id = '" + ds.Tables[0].Rows[i][0].ToString() + "';");
                                free = true;
                                break;
                            }
                        }
                    }
                    if (!free)
                    {
                        MessageBox.Show("查询人数超限，请稍后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        Reload_number_people.Enabled = true;
                    }
                    break;
            }
            string bc, sexy;
            StreamReader sr_bc = new StreamReader("Bc_key.txt");
            StreamReader sr_sexy = new StreamReader("Sexy_key.txt");
            try
            {

                bc_key = new List<string>();
                sexy_key = new List<string>();

                bc = sr_bc.ReadLine();
                while (bc != null)
                {
                    bc_key.Add(bc);
                    bc = sr_bc.ReadLine();
                }
                sr_bc.Close();

                sexy = sr_sexy.ReadLine();
                while (sexy != null)
                {
                    sexy_key.Add(sexy);
                    sexy = sr_sexy.ReadLine();
                }
                sr_sexy.Close();

            }
            catch (Exception f)
            {
                Console.WriteLine("Exception: " + f.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            Query_thread_switch = true;
            
            get_cond_chinese = Set_cond_language.Checked ? true : false;
            get_cond_nobet = Set_cond_bet.Checked ? true : false;
            get_cond_nosexy = Set_cond_sexy.Checked ? true : false;
            get_cond_nonull = Set_cond_null.Checked ? true : false;
            list_num = 1;
            Out_box.Clear();//***************************需要删除*****************************8
            DataView.Rows.Clear();
            all_site.Clear();
            for (int i = 0; i < Domain_Box.Lines.Count(); i++)
            {
                string a_site = Domain_Box.Lines[i];
                a_site = a_site.Replace(" ", "").Replace("\t", "");
                if (a_site == "")
                {
                    continue;
                }
                a_site = Regex.Replace(a_site, @"\n\s*\n", "\r\n");
                a_site = a_site.ToLower();
                all_site.Enqueue(a_site != "" ? a_site : null);
                //Out_box.Text += a_site + "\r\n";
            }

            all_site_num = all_site.Count();
            All_site_num_show.Text = all_site_num.ToString();
        }

        private void Filter_domain_button_Click(object sender, EventArgs e)
        {
            select_switch = "api";
            Information_loading(select_switch);

            Thread[] get_majestic_data_Thread;//声名线程
            get_majestic_data_Thread = new Thread[Threads_Num];
            watch.Start();
            for (int i = 0; i < Threads_Num; i++)
            {
                ThreadStart startDownload = new ThreadStart(Select_data);
                get_majestic_data_Thread[i] = new Thread(startDownload);//指定线程起始设置
                if (Query_thread_switch)
                {
                    get_majestic_data_Thread[i].Start();//逐个开启线程
                }
                else
                {
                    i = Threads_Num;
                    Filter_domain_button.Enabled = true;
                    Filter_domain_web_button.Enabled = true;
                }
            }
        }



        public delegate void ProcessDelegate();
        public static object locker = new object();
        public static object locker1 = new object();
        public static object locker2 = new object();
        public static object locker3 = new object();
        public static object locker4 = new object();
        public static object locker5 = new object();
        public static object locker6 = new object();

        public int all_site_num = 0;//所有的域名数量
        public int Queried_site_num = 0;//已查询的域名数量
        public int all_auc_secelt_site = 0;//成功查询的域名数量
        public int all_fail_secelt_site = 0;//查询失败的域名数量
        List<string> list_fail_site = new List<string>();
        object obj = null;//从数据库查询网站是否被添加过

        int list_num = 1;

        public void Select_data()
        {
            if (!Query_thread_switch)
            {
                return;
            }
            Queried_site_num = 0;
            all_auc_secelt_site = 0;
            string get_page_out = "";
            mfr_data.Mfr.Clear();//清空容器
            string url;

            ProcessDelegate En_btn = delegate ()
            {
                Filter_domain_button.Enabled = false;
                Filter_domain_web_button.Enabled = false;
            };
            Filter_domain_button.Invoke(En_btn);

            do
            {
                lock (locker1)
                {
                    if (all_site.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        url = all_site.Dequeue();
                    }
                }

                //Thread.Sleep(2000);

                object obj = MySQLDBHelp.GetSingle("select Domain_id from domain_list where Domain_name = '" + url + "';");
                if (update_data_checkBox.Checked && obj != null)
                {
                    obj = null;
                }
                ProcessDelegate En_btn_Query = delegate ()
                {
                    Out_box.AppendText("正在查询:" + url + "\r\n");
                };
                Out_box.Invoke(En_btn_Query);
                if (obj == null)
                {
                    WebResponse myResponse = null;
                    switch (select_switch)
                    {
                        case "api":
                            get_page_out = Visit_web.GetPage("https://api.majestic.com/api/json?app_api_key=" + Key + "&cmd=GetBackLinkData&item=" + url + "&Count=20&datasource=fresh", true, true);
                            break;
                        case "web":
                            int statuscode;
                            int i = 1;
                            do
                            {
                                if (i > 1)
                                {
                                    ProcessDelegate En_btn_outwrong = delegate ()
                                                                        {
                                                                            Out_box.AppendText("提示:" + url + "第" + (i - 1).ToString() + "次查询失败，正在进行第" + i + "次查询" + "\r\n");
                                                                            Filter_domain_button.Enabled = true;
                                                                            Filter_domain_web_button.Enabled = true;
                                                                        };
                                    Out_box.Invoke(En_btn_outwrong);
                                }
                                if (i > 3)
                                {
                                    Thread.Sleep(5000);
                                }
                                //myStreamReader = Visit_web.GetResponse("http://www.balabalaxiaomoxian.com", cookieContainer,out string mess);
                                myResponse = Visit_web.GetResponse("https://zh.majestic.com/reports/site-explorer/top-backlinks?folder=&q=" + url + "&IndexDataSource=F&MaxSourceUrlsPerRefDomain=1&removeDeleted=0", cookieContainer, out statuscode);
                                i++;
                            } while (myResponse == null && i <= 5);
                            float Query_interval = float.Parse(Query_interval_Textbox.Text);
                            int sleep_tome = int.Parse((Query_interval * 1000).ToString());
                            Thread.Sleep(sleep_tome);
                            //int Query_interval = Query_interval_Textbox.Text;
                            if (myResponse == null)
                            {
                                if (statuscode == 429)
                                {
                                    all_fail_secelt_site++;
                                    all_site.Clear();
                                    ProcessDelegate En_btn_test = delegate ()
                                    {
                                        Out_box.AppendText("提示:账户被锁，已终止查询..." + "\r\n");
                                        Filter_domain_button.Enabled = true;
                                        Filter_domain_web_button.Enabled = true;
                                    };
                                    Out_box.Invoke(En_btn_test);
                                    return;
                                }
                                /*
                                all_fail_secelt_site++;
                                all_site.Clear();
                                ProcessDelegate En_btn_test = delegate ()
                                {
                                    Out_box.AppendText("提示:网络异常，已终止查询..." + "\r\n");
                                    Filter_domain_button.Enabled = true;
                                    Filter_domain_web_button.Enabled = true;
                                };
                                Out_box.Invoke(En_btn_test);
                                return;
                                */
                            }
                            break;
                        default:
                            break;
                    }
                    
                    Queried_site_num++;
                    if (get_page_out == "访问失败" || get_page_out == null)
                    {
                        all_fail_secelt_site++;
                        all_site.Clear();
                        ProcessDelegate En_btn_test = delegate ()
                        {
                            Out_box.AppendText("提示:访问网页失败，已终止查询..." + "\r\n");
                            Filter_domain_button.Enabled = true;
                            Filter_domain_web_button.Enabled = true;
                        };
                        Out_box.Invoke(En_btn_test);
                        //list_fail_site.Add(url);
                    }
                    else
                    {
                        //all_firs_jsontxt.Enqueue(jsontxt);
                        switch (select_switch)
                        {
                            case "api":
                                Refined_query(get_page_out);
                                break;
                            case "web":
                                Refined_query(myResponse, url);
                                //Refined_query(myStreamReader, url);
                                break;
                        }
                    }
                }
                else if (obj.ToString() == "Database_connection_failed")
                {
                    Queried_site_num++;
                    all_site.Clear();
                    ProcessDelegate En_btn_test = delegate ()
                    {
                        Out_box.AppendText("提示:数据库链接失败，已终止查询..." + "\r\n");
                        Filter_domain_button.Enabled = true;
                        Filter_domain_web_button.Enabled = true;
                    };
                    Out_box.Invoke(En_btn_test);
                    return;
                }
                else
                {
                    Queried_site_num++;
                    DataSet ds = MySQLDBHelp.Query_for_mysql("select Info_title,Info_url,Info_language,Nofollow,Delete_url from domain_data where Domain_id = '" + obj.ToString() + "';");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        if (!get_cond_nonull)
                        {
                            ProcessDelegate En_btn_tre = delegate ()
                            {
                                DataView.Rows.Add(list_num, url, null, null, "数据库");
                            };
                            DataView.Invoke(En_btn_tre);
                            list_num++;
                        }
                    }
                    else
                    {
                        Refined_query(ds, url);
                    }
                }
            } while (all_site.Count != 0);

            if (Queried_site_num == all_site_num)
            {
                ProcessDelegate En_btn_tre = delegate ()
                            {
                                Out_box.AppendText("本次查询结束...\r\n");
                                Filter_domain_button.Enabled = true;
                                Filter_domain_web_button.Enabled = true;
                            };
                Filter_domain_button.Invoke(En_btn_tre);
                Reload_number_people.Enabled = false;
                //efined_query();//分析数据
            }
        }

        /// <summary>
        /// DataSet解析
        /// </summary>
        /// <param name="ds">从Mysql查询结果</param>
        /// <param name="url">域名</param>
        public void Refined_query(DataSet ds, string url)
        {
            good_domain Good_domain_info_for_data = new good_domain();
            int rowCount, columnCount, i, j;
            rowCount = ds.Tables[0].Rows.Count;
            columnCount = ds.Tables[0].Columns.Count;
            domain_data simp_list_data;
            bool save = false;

            lock (locker4)
            {
                Good_domain_info_for_data.Num_id = list_num;
                Good_domain_info_for_data.Ok_domain = url;
                Good_domain_info_for_data.Data_sources = "数据库";


                for (i = 0; i < rowCount; i++)
                {
                    simp_list_data = new domain_data();
                    save = true;
                    string ti, ur, la, nf, del;
                    ti = ds.Tables[0].Rows[i][0].ToString().Replace(" ", "");
                    ur = ds.Tables[0].Rows[i][1].ToString().Replace(" ", "");
                    la = ds.Tables[0].Rows[i][2].ToString().Replace(" ", "");
                    nf = ds.Tables[0].Rows[i][3].ToString() == "0" ? "" : "Nofollow|";
                    del = ds.Tables[0].Rows[i][4].ToString() == "0" ? "" : "已删除|";
                    if (get_cond_chinese && !Regex.IsMatch(ti, @"[\u4e00-\u9fa5]"))//&& la != "zh" 
                    {
                        save = false;
                        continue;
                    }
                    else
                    {

                        simp_list_data.good_domain_language = la;
                    }

                    if (get_cond_nonull && (ti == "" || ur == ""))
                    {
                        save = false;
                        continue;
                    }
                    else
                    {
                        if (get_cond_nobet)
                        {
                            for (int s = 0; s < bc_key.Count; s++)
                            {
                                if (ti != "" && ti.Contains(bc_key[s]))
                                {
                                    save = false;
                                    continue;
                                }
                            }
                        }

                        if (get_cond_nosexy)
                        {
                            for (int s = 0; s < sexy_key.Count; s++)
                            {
                                if (ti != "" && ti.Contains(sexy_key[s]))
                                {
                                    save = false;
                                    continue;
                                }
                            }
                        }

                        if (save)
                        {
                            simp_list_data.good_domain_title = nf + del + ti;
                            simp_list_data.good_domain_url = ur;
                            Good_domain_info_for_data.Domain_info.Add(simp_list_data);
                        }
                    }
                }
                if (save)
                {
                    mfr_data.Mfr.Add(Good_domain_info_for_data);
                }

                if (Good_domain_info_for_data.Domain_info.Count != 0)
                {
                    ProcessDelegate show_data_data_view = delegate ()
                        {
                            string title = "";
                            string site_url = "";
                            for (int s = 0; s < Good_domain_info_for_data.Domain_info.Count; s++)
                            {
                                title += Good_domain_info_for_data.Domain_info[s].good_domain_title + "\r\n";
                                site_url += Good_domain_info_for_data.Domain_info[s].good_domain_url + "\r\n";
                            }
                            DataView.Rows.Add(Good_domain_info_for_data.Num_id, Good_domain_info_for_data.Ok_domain, title, site_url, Good_domain_info_for_data.Data_sources);
                        };
                    DataView.Invoke(show_data_data_view);
                }
                
                list_num++;
            }
        }

        /// <summary>
        /// 解析网站api
        /// </summary>
        public void Refined_query(string get_page_out)
        {
            //mfr_data.Mfr = null;
            if (get_page_out.Length == 0)
            {
                return;
            }
            
            BackLinksRootObject rb;
            try
            {
                rb = JsonConvert.DeserializeObject<BackLinksRootObject>(get_page_out);
                switch (rb.Code)
                {
                    case "InsufficientAnalysisUnits":
                        Query_thread_switch = false;
                        all_site.Clear();
                        ProcessDelegate En_btn_test = delegate ()
                        {
                            Out_box.AppendText("提示:配额已使用完..." + "\r\n");
                            Filter_domain_button.Enabled = true;
                            Filter_domain_web_button.Enabled = true;

                        };
                        Out_box.Invoke(En_btn_test);
                        return;
                    case "OK":
                        int Number_of_rows_affected = MySQLDBHelp.Getmysqlcom($"insert into domain_list value(null,'" + rb.DataTables.BackLinks.Headers.BackLinkItem + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd") + "');");
                        break;
                    default:
                        all_fail_secelt_site++;
                        return;
                }

                if (rb.DataTables.BackLinks.Data.Count() != 0)//判断是否有引用域数据
                {
                    List<string> sqllist = new List<string>();
                    for (int i = 0; i < rb.DataTables.BackLinks.Data.Count(); i++)
                    {
                        string simp_title = rb.DataTables.BackLinks.Data[i].TargetTitle != "" ? rb.DataTables.BackLinks.Data[i].TargetTitle : rb.DataTables.BackLinks.Data[i].SourceTitle;
                        sqllist.Add("insert into domain_data value(null,(select Domain_id from domain_list where Domain_name = '" + rb.DataTables.BackLinks.Headers.BackLinkItem + "'),'" + Filter_mysql_str(simp_title) + "','" + rb.DataTables.BackLinks.Data[i].SourceURL + "','" + rb.DataTables.BackLinks.Data[i].SourceLanguage + "'," + rb.DataTables.BackLinks.Data[i].FlagNoFollow + ",'" + rb.DataTables.BackLinks.Data[i].FlagDeleted + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',1);");
                    }
                    MySQLDBHelp.ExecuteSqlTransaction(sqllist);
                }
                else
                {
                    //return;//这里很重要。。。。。。。。。。。。。。。。。。。。
                }
            }
            catch (Exception)
            {
                return;
                throw;
            }

            good_domain good_domain_info = new good_domain();
            bool save;
            lock (locker5)
            {
                good_domain_info.Num_id = list_num;
                good_domain_info.Ok_domain = rb.DataTables.BackLinks.Headers.Item;
                good_domain_info.Data_sources = "外网";//数据来源
                for (int i = 0; i < rb.DataTables.BackLinks.Data.Count(); i++)//循环排查数据
                {
                    save = true;
                    string ti, ur, la, nf, del;
                    ti = rb.DataTables.BackLinks.Data[i].TargetTitle != "" ? rb.DataTables.BackLinks.Data[i].TargetTitle : rb.DataTables.BackLinks.Data[i].SourceTitle;
                    ur = rb.DataTables.BackLinks.Data[i].SourceURL;
                    la = (rb.DataTables.BackLinks.Data[i].SourceLanguage == "zh" && rb.DataTables.BackLinks.Data[i].SourceLanguageDesc == "Chinese") ? "zh" : "";
                    nf = rb.DataTables.BackLinks.Data[i].FlagNoFollow == "0" ? "" : "Nofollow|";
                    del = rb.DataTables.BackLinks.Data[i].FlagDeleted == "0" ? "" : "已删除|";
                    domain_data simp_list_data = new domain_data();
                    if (get_cond_chinese && !Regex.IsMatch(ti, @"[\u4e00-\u9fa5]"))
                    {
                        save = false;
                        continue;
                    }
                    else
                    {
                        simp_list_data.good_domain_language = la;
                    }
                    if (get_cond_nonull && (ti == "" || ur == ""))
                    {
                        save = false;
                        continue;
                    }
                    else
                    {
                        if (get_cond_nobet)
                        {
                            for (int s = 0; s < bc_key.Count; s++)
                            {
                                if (ti != "" && ti.Contains(bc_key[s]))
                                {
                                    save = false;
                                    continue;
                                }
                            }
                        }
                        if (get_cond_nosexy)
                        {
                            for (int s = 0; s < sexy_key.Count; s++)
                            {
                                if (ti != "" && ti.Contains(sexy_key[s]))
                                {
                                    save = false;
                                    continue;
                                }
                            }
                        }
                        simp_list_data.good_domain_title = ti;
                        simp_list_data.good_domain_url = ur;
                    }
                    //if (rb.DataTables.BackLinks.Data[i].FlagNoFollow == "0") { }//判断应用域
                    if (save)
                    {
                        good_domain_info.Domain_info.Add(simp_list_data);
                        ProcessDelegate show_data_data_view = delegate ()
                        {
                            string title_ = "";
                            string site_url_ = "";
                            for (int j = 0; j < good_domain_info.Domain_info.Count; j++)
                            {
                                title_ += good_domain_info.Domain_info[j].good_domain_title + "\r\n";
                                site_url_ += good_domain_info.Domain_info[j].good_domain_url + "\r\n";
                            }
                            DataView.Rows.Add(good_domain_info.Num_id, good_domain_info.Ok_domain, title_, site_url_, good_domain_info.Data_sources);
                        };
                        DataView.Invoke(show_data_data_view);
                    }
                }//
                mfr_data.Mfr.Add(good_domain_info);//****************************************尝试修改
                list_num++;
            }
        }

        /// <summary>
        /// 从网页数据解析网站
        /// </summary>
        /// <param name="get_page_out"></param>
        /// <param name="url"></param>
        public void Refined_query(WebResponse myresponse, string url)
        {
            if (myresponse == null)
            {
                return;
            }

            IHtmlDocument source;

            try
            {
                source = new JumonyParser().LoadDocument(myresponse);
            }
            catch (Exception)
            {
                return;
            }
            
            if (source.Find("#vue-backlinks-table").FirstOrDefault() == null)
            {
                if (source.Find(".is-four-fifths").FirstOrDefault() != null)
                {
                    all_site.Clear();
                    ProcessDelegate En_btn_test = delegate ()
                    {
                        Out_box.AppendText("提示:账户异常，需要手动检查账户状态..." + "\r\n");
                        Filter_domain_button.Enabled = true;
                        Filter_domain_web_button.Enabled = true;

                    };
                    Out_box.Invoke(En_btn_test);
                }
                else if (source.Find("#usage_blocked").FirstOrDefault() != null)
                {
                    all_site.Clear();
                    ProcessDelegate En_btn_test = delegate ()
                    {
                        Out_box.AppendText("提示:账户锁了，要等等了..." + "\r\n");
                        Filter_domain_button.Enabled = true;
                        Filter_domain_web_button.Enabled = true;
                    };
                    Out_box.Invoke(En_btn_test);
                }
                else
                {
                    if (!get_cond_nonull)
                    {
                        ProcessDelegate En_btn_tre = delegate ()
                        {
                            DataView.Rows.Add(list_num, url, null, null, "外网");
                        };
                        DataView.Invoke(En_btn_tre);
                        list_num++;
                    }
                    int Number_of_rows_affected = MySQLDBHelp.Getmysqlcom($"insert into domain_list value(null,'" + url + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd") + "');");
                }
                return;
            }
            int Number_of_rows_affected_ = MySQLDBHelp.Getmysqlcom($"insert into domain_list value(null,'" + url + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd") + "');");
            List<string> sqllist = new List<string>();
            good_domain good_domain_info = new good_domain();
            bool save;

            var dom = source.Find("#vue-backlinks-table .odd,.even");
            foreach (var adom in dom)
            {
                string bianhao = "";
                string language = "";
                string domain_title = "";
                string domain_url = "";
                string domain_nofollow = "";
                string domain_delete = "";
                if (adom.Find(".center").FirstOrDefault() == null)
                {
                    continue;
                }
                good_domain_info.Num_id = list_num;
                good_domain_info.Ok_domain = url;
                good_domain_info.Data_sources = "外网";

                language = adom.Find(".backlink-source .lang span").FirstOrDefault() == null ? "" : Filter_str(adom.Find(".backlink-source .lang span").FirstOrDefault().InnerText().Replace(" ", ""));
                domain_title = adom.Find(".backlink-source .sourceTitle span").FirstOrDefault() == null ? "" : HttpUtility.HtmlDecode(Filter_str(adom.Find(".backlink-source .sourceTitle span").FirstOrDefault().InnerText()));
                var alink = adom.Find(".backlink-source .sourceURL span .redirectLink");
                foreach (var link in alink)
                {
                    domain_url = link.Attribute("href").Value();
                    break;
                }
                if (domain_url == null)
                {
                    domain_url = "";
                }
                domain_nofollow = adom.Find(".backlink-source .inline-block .no-follow").FirstOrDefault() == null ? "0" : Filter_str(adom.Find(".backlink-source .inline-block .no-follow").FirstOrDefault().InnerText()).Replace(" ", "") == "NoFollow" ? "1" : "0";
                domain_delete = adom.Find(".backlink-source .inline-block .deleted").FirstOrDefault() == null ? "0" : Filter_str(adom.Find(".backlink-source .inline-block .deleted").FirstOrDefault().InnerText()).Replace(" ", "") == "已删除" ? "1" : "0";
                sqllist.Add("insert into domain_data value(null,(select Domain_id from domain_list where Domain_name = '" + url + "'),'" + Filter_mysql_str(domain_title) + "','" + domain_url.Replace(" ","") + "','" + language + "'," + domain_nofollow + "," + domain_delete + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "',1);");

                save = true;
                string ti, ur, la, nf, del;
                ti = domain_title.Replace(" ", ""); ;
                ur = domain_url.Replace(" ", ""); ;
                la = language.Replace(" ", ""); ;
                nf = domain_nofollow == "0" ? "" : "Nofollow|";
                del = domain_delete == "0" ? "" : "已删除|";
                domain_data simp_list_data = new domain_data();
                if (get_cond_chinese && !Regex.IsMatch(ti, @"[\u4e00-\u9fa5]"))
                {
                    save = false;
                    continue;
                }
                else
                {
                    simp_list_data.good_domain_language = la;
                }
                if (get_cond_nonull && (ti == "" || ur == ""))
                {
                    save = false;
                    continue;
                }
                else
                {
                    if (get_cond_nobet)
                    {
                        for (int s = 0; s < bc_key.Count; s++)
                        {
                            if (ti != "" && ti.Contains(bc_key[s]))
                            {
                                save = false;
                                continue;
                            }
                        }
                    }
                    if (get_cond_nosexy)
                    {
                        for (int s = 0; s < sexy_key.Count; s++)
                        {
                            if (ti != "" && ti.Contains(sexy_key[s]))
                            {
                                save = false;
                                continue;
                            }
                        }
                    }
                    simp_list_data.good_domain_title = nf + del + ti;
                    simp_list_data.good_domain_url = ur;
                }
                if (save)
                {
                    good_domain_info.Domain_info.Add(simp_list_data);
                }
            }
            if (good_domain_info.Domain_info.Count > 0)
            {
                ProcessDelegate show_data_data_view = delegate ()
                {
                    string title_ = "";
                    string site_url_ = "";
                    for (int j = 0; j < good_domain_info.Domain_info.Count; j++)
                    {
                        title_ += good_domain_info.Domain_info[j].good_domain_title + "\r\n";
                        site_url_ += good_domain_info.Domain_info[j].good_domain_url + "\r\n";
                    }
                    DataView.Rows.Add(good_domain_info.Num_id, good_domain_info.Ok_domain, title_, site_url_, good_domain_info.Data_sources);
                };
                DataView.Invoke(show_data_data_view);
            }

            MySQLDBHelp.ExecuteSqlTransaction(sqllist);
            mfr_data.Mfr.Add(good_domain_info);//****************************************尝试修改
            list_num++;
        }


        private void DataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //MessageBox.Show("单元格的内容是：" + DataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        #region 小图标的活动方法
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Little_ico.Visible = true; //托盘图标隐藏
            }
            if (WindowState == FormWindowState.Minimized)//最小化事件
            {
                Hide();//最小化时窗体隐藏
            }
        }

        private void Little_ico_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal; //还原窗体
            }
        }

        bool Sure_exit = false;//判断是否确定退出
        private void Close_Menu_ico_Click(object sender, EventArgs e)
        {
            Sure_exit = true;
            Close();
            Application.Exit();
        }

        #endregion
        
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Sure_exit)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;//将窗体变为最小化
            }
        }

        private void Key_list_TextChanged(object sender, EventArgs e)
        {
            Key = Key_list.Text;
        }

        private void Set_Threads_Num_TextChanged(object sender, EventArgs e)
        {
            Threads_Num = int.Parse(Set_Threads_Num.Text);
        }

        private void Filter_domain_web_button_Click(object sender, EventArgs e)
        {
            select_switch = "web";
            Information_loading(select_switch);
            Cookie_name = new List<string>();
            Cookie_value = new List<string>();

            for (int i = 0; i < cookie_box.Lines.Count(); i++)
            {
                if (cookie_box.Lines[i] != "")
                {
                    string str_cookie = cookie_box.Lines[i];
                    string[] sArray = str_cookie.Split(';');
                    foreach (var item in sArray)
                    {
                        string[] cookie_Array = item.Split('=');
                        Cookie_name.Add(cookie_Array[0].Replace(" ", ""));
                        Cookie_value.Add(UrlEncode(cookie_Array[1].Replace(" ","")));
                    }
                }
            }

            if (Cookie_value.Count() != Cookie_name.Count())
            {
                MessageBox.Show("检查Cookie信息！！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cookieContainer = new CookieContainer();
            for (int i = 0; i < Cookie_value.Count; i++)
            {
                Cookie ck = new Cookie(Cookie_name[i], @Cookie_value[i]);
                Uri uri = new Uri("https://zh.majestic.com");
                cookieContainer.Add(uri, ck);
            }
            Thread[] get_majestic_data_Thread;//声名线程
            get_majestic_data_Thread = new Thread[1];
            watch.Start();
            for (int i = 0; i < 1; i++)
            {
                ThreadStart startDownload = new ThreadStart(Select_data);
                get_majestic_data_Thread[i] = new Thread(startDownload);//指定线程起始设置
                get_majestic_data_Thread[i].Start();//逐个开启线程
            }
        }

        public void Retrieve_from_database()
        {
            ProcessDelegate En_btn_test = delegate ()
            {
                Out_box.AppendText("提示:正在检索数据库信息..." + "\r\n");
                Filter_domain_button.Enabled = true;
                Filter_domain_web_button.Enabled = true;
            };
            Out_box.Invoke(En_btn_test);

            do
            {


            } while (all_site.Count > 0);


            
        }

        private void Reload_cookie_Click(object sender, EventArgs e)
        {
            cookie_box.Clear();
            string str_cookie_info;
            List<string> list_cookie_key, list_cookie_value;
            StreamReader Read_Cookie_info = new StreamReader("Cookie_info.txt");
            try
            {

                list_cookie_key = new List<string>();
                list_cookie_value = new List<string>();

                str_cookie_info = Read_Cookie_info.ReadLine();
                while (str_cookie_info != null)
                {
                    cookie_box.Text += str_cookie_info+"\r\n";
                    str_cookie_info = Read_Cookie_info.ReadLine();
                }
                Read_Cookie_info.Close();
            }
            catch (Exception f)
            {
                Console.WriteLine("Exception: " + f.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void Reload_number_people_Tick(object sender, EventArgs e)
        {
            MySQLDBHelp.GetSingle("update user_number_control set Last_road_time = NOW() where Robot_num = '" + Robot_id + "';");
        }

        private void Query_interval_Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 31 && (e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != 46)) { e.Handled = true; }
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
            {
                e.Handled = true;
            }
            //第1位小数点不可
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
            {
                e.Handled = true;
            }
            //第1位是0，第2位必须是小数点
            if (e.KeyChar != (char)('.') && e.KeyChar != 8 && ((TextBox)sender).Text == "0")
            {
                e.Handled = true;
            }
            //小数点（最大到2位）   
            if (e.KeyChar != '\b' && (((TextBox)sender).SelectionStart) > (((TextBox)sender).Text.LastIndexOf('.')) + 1 && ((TextBox)sender).Text.IndexOf(".") >= 0)
                e.Handled = true;
        }
        
        public string Filter_str(string str)
        {
            str = str.Replace("\r", "");
            str = str.Replace("\n", "");
            str = str.Replace("\t", "");
            return str;
        }

        public string Filter_mysql_str(string str)
        {
            str = str.Replace("\\", "\\\\");
            str = str.Replace("'", "\\'");
            str = str.Replace('"', '\"');
            return str;
        }

        /// <summary>
        /// 向txt文件写入内容
        /// </summary>
        /// <param name="path">txt文件保存的路径，没有就创建，有内容就覆盖。例："E:\\text.txt"</param>
        /// <param name="contentSrt">要写入的内容</param>
        private void WriteForTxt(string path, List<string> contentSrt)
        {
            if (!File.Exists(path))//判断有没有没有新建个
            {
                StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);

                sw.WriteLine(contentSrt);
                sw.Close();
                sw.Dispose();
            }
            //StreamReader sr = new StreamReader(s);
            bool isexist = false;
            string alltxt = "";
            if (!isexist)//写入内容
            {
                for (int i = 0; i < contentSrt.Count; i++)
                {
                    alltxt += contentSrt[i];
                }
                try
                {
                    File.WriteAllText(@path, alltxt, Encoding.UTF8);
                }
                catch (Exception)
                {
                    MessageBox.Show("Cookie写入异常！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //throw;
                }
            }
        }

        private void WriteCookiefile_Click(object sender, EventArgs e)
        {
            
            if (cookie_box.Text == "")
            {
                MessageBox.Show("Cookie为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                List<string> listfiletxt = new List<string>();
                for (int i = 0; i < cookie_box.Lines.Count(); i++)
                {
                    listfiletxt.Add(cookie_box.Lines[i] + "\r\n");
                }
                string file_path = @"Cookie_info.txt";
                WriteForTxt(file_path, listfiletxt);
            }
        }

        /// <summary>
        /// Url转码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string UrlEncode(string url)
        {
            return HttpUtility.UrlEncode(url);
        }

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string UrlDecode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }


        int jishuqi = 0;
        private void Show_Query_Num_timer500_Tick(object sender, EventArgs e)
        {
            Queried_site_num_lable.Text = Queried_site_num.ToString();
        }

        private void out_data_excel_Click(object sender, EventArgs e)
        {
            if (mfr_data.Mfr.Count == 0)
            {
                MessageBox.Show("数据为空？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string save_path;
            FolderBrowserDialog dilog = new FolderBrowserDialog();
            dilog.Description = "请选择文件夹";
            if (dilog.ShowDialog() == DialogResult.OK || dilog.ShowDialog() == DialogResult.Yes)
            {
                save_path = dilog.SelectedPath;
            }
            else
            {
                MessageBox.Show("路径错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            save_path = save_path + "查询结果.xlsx";
            
            XSSFWorkbook workBook = new XSSFWorkbook();  //实例化XSSF
            XSSFSheet sheet = (XSSFSheet)workBook.CreateSheet();  //创建一个sheet

            IRow frow0 = sheet.CreateRow(0);  // 添加一行（一般第一行是表头）
            frow0.CreateCell(0).SetCellValue("序号");
            frow0.CreateCell(1).SetCellValue("域名");
            frow0.CreateCell(2).SetCellValue("标题");
            frow0.CreateCell(3).SetCellValue("url");

            for (int i = 0; i < mfr_data.Mfr.Count; i++)  //循环添加list中的内容放到表格里
            {
                IRow frow1 = sheet.CreateRow(i + 1);  //之所以从i+1开始 因为第一行已经有表头了
                frow1.CreateCell(0).SetCellValue(mfr_data.Mfr[i].Num_id);
                frow1.CreateCell(1).SetCellValue(mfr_data.Mfr[i].Ok_domain);
                

                string all_title = "";
                string all_url = "";
                for (int j = 0; j < mfr_data.Mfr[i].Domain_info.Count; j++)
                {
                    /*做超链用的
                    HSSFHyperlink link = new HSSFHyperlink(HyperlinkType.Url);
                    link.Address = mfr_data.Mfr[i].Domain_info[j].good_domain_url;
                    frow1.Hyperlink = link;
                    */
                    all_title += mfr_data.Mfr[i].Domain_info[j].good_domain_title+"\r\n";
                    all_url += mfr_data.Mfr[i].Domain_info[j].good_domain_url+"\r\n";
                }
                frow1.CreateCell(2).SetCellValue(all_title);
                frow1.CreateCell(3).SetCellValue(all_url);
            }
            try
            {
                using (FileStream fs = new FileStream(save_path, FileMode.Create, FileAccess.Write))
                {
                    workBook.Write(fs);  //写入文件
                    workBook.Close();  //关闭
                }
                MessageBox.Show("导出成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                workBook.Close();
            }
        }
        
        private void replace_go_Click(object sender, EventArgs e)
        {
            Go_change();
        }

        public void Go_change()
        {
            string dbname;
            string code_e_line;
            Replace_out.Clear();
            for (int i = 0; i < Domain_list_box.Lines.Count(); i++)
            {
                string site = Domain_list_box.Lines[i];
                site = site.Replace(" ", "");
                site = site.Replace("\t", "");
                site = Regex.Replace(site, @"\n\s*\n", "\r\n");
                if (site != "")
                {
                    dbname = site.Replace(".", "_");
                    dbname = dbname.Replace("-", "_");
                    for (int j = 0; j < Model_S.Lines.Count(); j++)
                    {
                        code_e_line = Model_S.Lines[j].Replace("[site]", site);
                        code_e_line = code_e_line.Replace("[dbname]", dbname);
                        Replace_out.AppendText(code_e_line + "\r\n");
                    }
                }
            }
        }

    }
}
