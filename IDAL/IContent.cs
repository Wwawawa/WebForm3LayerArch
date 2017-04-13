using System;
using Model;

namespace IDAL
{
    /// <summary>
    /// 文章内容操作接口
    /// </summary>
    public interface IContent
    {
        /// <summary>
        /// 取得文章的内容。
        /// </summary>
        /// <param name="id">文章的ID</param>
        /// <returns></returns>
        ContentInfo GetContentInfo(int id);
    }
}
