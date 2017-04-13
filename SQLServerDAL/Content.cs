using System;
using System.Data;
using System.Data.SqlClient;
using Model;
using IDAL;

namespace SQLServerDAL
{
    /// <summary>
    /// Content 的摘要说明。
    /// </summary>
    public class Content : IContent
    {

        private const string PARM_ID = "@ID";
        private const string SQL_SELECT_CONTENT = "Select ID, Title, Content, AddDate, CategoryID From newsContent";


        public ContentInfo GetContentInfo(int id)
        {
            //创意文章内容类
            ContentInfo ci = null;

            //创建一个参数
            SqlParameter parm = new SqlParameter(PARM_ID, SqlDbType.BigInt, 3);
            //赋上ID值
            parm.Value = id;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_SELECT_CONTENT, null))
            {
                if (sdr.Read())
                {
                    ci = new ContentInfo(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2),
                           "",sdr.GetDateTime(3), 0,0);
                }
            }
            return ci;
        }
    }
}
