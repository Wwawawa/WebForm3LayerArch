using System;
using System.Data;
using System.Data.SqlClient;
using DBUtility;

namespace SQLServerDAL
{
    /// <summary>
    /// SqlHelper 的摘要说明。
    /// </summary>
    public abstract class SqlHelper
    {
        public static readonly string CONN_STR = ConnectionInfo.GetSqlServerConnectionString();

        /// <summary>
        /// 用提供的函数，执行SQL命令，返回一个从指定连接的数据库记录集
        /// </summary>
        /// <remarks>
        /// 例如：
        /// SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">SqlConnection有效的SQL连接字符串</param>
        /// <param name="commandType">CommandType：CommandType.Text、CommandType.StoredProcedure</param>
        /// <param name="commandText">SQL语句或存储过程</param>
        /// <param name="commandParameters">SqlParameter[]参数数组</param>
        /// <returns>SqlDataReader：执行结果的记录集</returns>
        public static SqlDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connString);

            // 我们在这里用 try/catch 是因为如果这个方法抛出异常，我们目的是关闭数据库连接，再抛出异常，
            // 因为这时不会有DataReader存在，此后commandBehaviour.CloseConnection将不会工作。
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }


        /// <summary>
        /// 为执行命令做好准备：打开数据库连接，命令语句，设置命令类型（SQL语句或存储过程），函数语取。
        /// </summary>
        /// <param name="cmd">SqlCommand 组件</param>
        /// <param name="conn">SqlConnection 组件</param>
        /// <param name="trans">SqlTransaction 组件，可以为null</param>
        /// <param name="cmdType">语句类型：CommandType.Text、CommandType.StoredProcedure</param>
        /// <param name="cmdText">SQL语句，可以为存储过程</param>
        /// <param name="cmdParms">SQL参数数组</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}
