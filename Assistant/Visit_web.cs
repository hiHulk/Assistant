using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    public class Visit_web
    {
        /// <summary>
        /// 传入地址返回结果
        /// </summary>
        /// <param name="PostUrl">URL</param>
        /// <param name="type">获取返回类型</param>0:网页数据;1:http状态代码
        /// <returns></returns>
        public static string get_data(string PostUrl, int type)
        {
            string re;
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse myResponse;
            try
            {
                Stream newStream = myRequest.GetRequestStream();
                newStream.Flush();
                newStream.Close();
                myResponse = (HttpWebResponse)myRequest.GetResponse();
            }
            catch (Exception)
            {
                return null;
            }
            if (myResponse.StatusCode == HttpStatusCode.OK && type == 0)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                re = reader.ReadToEnd();
                return re;
            }
            else if (myResponse.StatusCode == HttpStatusCode.OK && type == 1)
            {
                HttpWebResponse response = (HttpWebResponse)myRequest.GetResponse();
                return 200 == Convert.ToInt32(response.StatusCode) ? "200" : null;
            }
            else
                return null;
        }

        /// <summary>
        /// 请求网页
        /// </summary>
        /// <param name="requestUrl">URL</param>
        /// <param name="v_type">请求类型，true为GET</param>
        /// <param name="ispc">是否为PC访问，true为PC访问</param>
        /// <returns></returns>
        public static string GetPage(string requestUrl, bool v_type, bool ispc)
        {
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            string User_Agent_Phone = "Mozilla/5.0 (Linux; U; Android 8.1.0; zh-CN; EML-AL00 Build/HUAWEIEML-AL00) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/57.0.2987.108 UCBrowser/11.9.4.974 UWS/2.13.1.48 Mobile Safari/537.36 AliApp(DingTalk/4.5.11) ";
            string User_Agent_PC = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.0; .NET CLR 1.1.4322; .NET CLR 2.0.50215;)";
            // 准备请求...
            try
            {
                // 设置参数
                request = WebRequest.Create(requestUrl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = v_type == true ? "GET" : "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                request.UserAgent = ispc ? User_Agent_PC : User_Agent_Phone;
                request.Headers.Add("Authorization", "Basic YWRtaW46YWRtaW4=");
                //发送请求并获取相应回应数据
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, Encoding.UTF8);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (Exception ex)
            {
                return "访问失败";
            }
        }

        public void Get_cookie(CookieContainer cc)
        {
            //

            //System.Windows.Application.GetCookie()
        }

        /*
        public static StreamReader GetResponse(string url, CookieContainer cc,out int mess)
        {
            try
            {
                CookieContainer container = cc ?? new CookieContainer();
                HttpWebRequest resquest = ResquestInit(url);
                resquest.CookieContainer = container;
                HttpWebResponse response = (HttpWebResponse)resquest.GetResponse();
                response.Cookies = container.GetCookies(resquest.RequestUri);
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                mess = (int)response.StatusCode;
                //response.Close();
                //myStreamReader.Close();
                return myStreamReader;
            }
            catch(WebException e)
            {
                Console.WriteLine(e.Message);
                int statuscode = (int)((HttpWebResponse)e.Response).StatusCode;

                mess = statuscode;
                Console.WriteLine(e.Message.ToString());
                return null;
            }
        }
        */

        public static WebResponse GetResponse(string url, CookieContainer cc, out int mess)
        {
            try
            {
                CookieContainer container = cc ?? new CookieContainer();
                HttpWebRequest resquest = ResquestInit(url);
                resquest.CookieContainer = container;
                HttpWebResponse response = (HttpWebResponse)resquest.GetResponse();
                response.Cookies = container.GetCookies(resquest.RequestUri);
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                mess = (int)response.StatusCode;
                //response.Close();
                //myStreamReader.Close();
                return response;
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                //int statuscode = (int)((HttpWebResponse)e.Response).StatusCode;

                mess = 0;
                Console.WriteLine(e.Message.ToString());
                return null;
            }
        }
        public static HttpWebRequest ResquestInit(string url)
        {
            Uri target = new Uri(url);
            HttpWebRequest resquest = (HttpWebRequest)WebRequest.Create(target);
            resquest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0; BOIE9;ZHCN)";
            resquest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            resquest.AllowAutoRedirect = true;
            resquest.KeepAlive = true;
            resquest.ReadWriteTimeout = 120000;
            resquest.ContentType = "application/x-www-form-urlencoded";
            resquest.Referer = url;

            return resquest;
        }
    }
}
