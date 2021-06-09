using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assistant
{
    public class Processing_chars
    {
        /// <summary>
        /// 字符串处理
        /// </summary>
        /// <param name="type">类型id</param>
        /// <param name="source">要处理的字符串</param>
        /// <returns></returns>
        public static string Filter_chars(int type,string source)
        {
            string pattern;//规则
            switch (type)
            {
                case 0://只保留字符串数字
                    pattern = "[A-Za-z0-9]";
                    break;
                default:
                    return null;
            }
            
            string strRet = "";
            MatchCollection results = Regex.Matches(source, pattern);
            foreach (var v in results)
            {
                strRet += v.ToString();
            }
            return strRet;
        }

    }
}
