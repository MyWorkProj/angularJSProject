using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcProj.DB
{
    public class LinkConfiguration
    {
        /// <summary>
        /// 在线聊天数据库
        /// </summary>
        public static string ChatConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["homecoming"];
            }
        }

        /// <summary>
        /// 在线统计数据库
        /// </summary>
        public static string PiwikConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["PiwikDB"];
            }
        }
        /// <summary>
        /// CRM数据库
        /// </summary>
        public static string CrmConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        }
        /// <summary>
        /// CRM账户数据库
        /// </summary>
        public static string CrmAccountString
        {
            get
            {
                return ConfigurationManager.AppSettings["MySql"];
            }
        }

        public static string PhoneAPIUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["PhoneAPIUrl"];
            }
        }
    }
    
}