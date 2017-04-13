using System;
using System.Configuration;

namespace DBUtility
{
    /// <summary>
    /// ConnectionInfo 的摘要说明。
    /// </summary>
    public class ConnectionInfo
    {
        public static string GetSqlServerConnectionString()
        {
            return ConfigurationSettings.AppSettings["SQLConnString"];
        }
    }
}
