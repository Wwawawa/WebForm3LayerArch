using System;

using Model;
using IDAL;

namespace BLL
{
    /// <summary>
    /// Content 的摘要说明。
    /// </summary>
    public class Content
    {

        public ContentInfo GetContentInfo(int id)
        {

            // 取得从数据访问层取得一个文章内容实例
            //IContent dal =new SQLServerDAL.Content(); // need to add DAL layer referance
            IContent dal = DALFactory.Content.Create();

            // 用DAL查找文章内容
            return dal.GetContentInfo(id);
        }
    }
}
