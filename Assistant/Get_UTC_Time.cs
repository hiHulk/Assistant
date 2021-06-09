using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    class Get_UTC_Time
    {
        #region
        ///
        /// 获取标准北京时间
        /// ///
        /// ///
        ///
        public static string GetStandardTime()
        {
            string dt;
            WebRequest wrt = null;
            WebResponse wrp = null;
            try
            {
                wrt = WebRequest.Create("http://www.time.ac.cn/timeflash.asp?user=flash");
                wrt.Credentials = CredentialCache.DefaultCredentials;
                wrp = wrt.GetResponse();
                StreamReader sr = new StreamReader(wrp.GetResponseStream(), Encoding.UTF8);
                string html = sr.ReadToEnd();
                sr.Close();
                wrp.Close();
                int yearIndex = html.IndexOf("") + 6;
                int monthIndex = html.IndexOf("") + 7;
                int dayIndex = html.IndexOf("") + 5;
                int hourIndex = html.IndexOf("") + 6;
                int miniteIndex = html.IndexOf("") + 8;
                int secondIndex = html.IndexOf("") + 8;
                string year = html.Substring(yearIndex, html.IndexOf("") - yearIndex);
                string month = html.Substring(monthIndex, html.IndexOf("") - monthIndex);
                string day = html.Substring(dayIndex, html.IndexOf("") - dayIndex);
                string hour = html.Substring(hourIndex, html.IndexOf("") - hourIndex);
                string minite = html.Substring(miniteIndex, html.IndexOf("") - miniteIndex);
                string second = html.Substring(secondIndex, html.IndexOf("") - secondIndex);

                //这里可以设置需要时间的规则
                //dt = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + minite + ":" + second);

                dt = year + month;
            }
            catch (WebException)
            {
                return DateTime.Now.ToString("yyyyMM");
            }
            catch (Exception)
            {
                return DateTime.Now.ToString("yyyyMM");
            }
            finally
            {
                if (wrp != null)
                    wrp.Close();
                if (wrt != null)
                    wrt.Abort();
            }
            return dt;
        }
        #endregion
    }
}
