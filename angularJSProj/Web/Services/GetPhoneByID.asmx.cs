using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

namespace angularJSProj.Web.Services
{
    /// <summary>
    /// GetPhoneByID 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class GetPhoneByID : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //[WebMethod]
        //public static string GetPhoneNum(int? ID)
        //{
        //    if (ID == null)
        //        ID = 1;
        //    string str = "";
        //    switch (ID)
        //    {
        //        case 1: str = "18513557174"; break;
        //        case 2: str = "18210521373"; break;
        //    }
        //    return str;
        //}
        /// <summary>
        /// 获取真实电话号码
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>真实号码</returns>
        [WebMethod]
        public string GetPhoneNum(int? ID)
        {
            if (ID == null)
                ID = 1;
            string str = "";
            switch (ID)
            {
                case 1: str = "18513557174"; break;
                case 2: str = "18210521373"; break;
            }
            return str;
        }
        [WebMethod]
        public string GetRex(string oriStr) {
            Match match = Regex.Match(oriStr, @"^[,](*)$[,]");
            return match.Value;
        }
    }
}
