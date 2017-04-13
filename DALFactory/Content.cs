using System;
using System.Reflection;
using System.Configuration;
using IDAL;

namespace DALFactory
{
    /// <summary>
    /// 工产模式实现文章接口。
    /// </summary>
    public class Content
    {
        public static IDAL.IContent Create()
        {
            // 这里可以查看 DAL 接口类。
            string path = System.Configuration.ConfigurationSettings.AppSettings["WebDAL"].ToString();
            string className = path + ".Content";

            // 用配置文件指定的类组合
            return (IDAL.IContent)Assembly.Load(path).CreateInstance(className);
        }
    }
}
