using System;

namespace Model
{
    /// <summary>
    /// Class1 的摘要说明。
    /// </summary>
    public class ContentInfo
    {
        private int _ID;
        private string _Content;
        private string _Title;
        private string _From;
        private DateTime _AddDate;
        private int _clsID;
        private int _tmpID;

        /// <summary>
        /// 文章内容构造函数
        /// </summary>
        /// <param name="id">文章流水号ID</param>
        /// <param name="content">文章内容</param>
        /// <param name="title">文章标题</param>
        /// <param name="from">文章来源</param>
        /// <param name="clsid">文章的分类属性ID</param>
        /// <param name="tmpid">文章的模板属性ID</param>
        public ContentInfo(int id, string title, string content, string from, DateTime addDate, int clsid, int tmpid)
        {
            this._ID = id;
            this._Content = content;
            this._Title = title;
            this._From = from;
            this._AddDate = addDate;
            this._clsID = clsid;
            this._tmpID = tmpid;
        }


        //属性
        public int ID
        {
            get { return _ID; }
        }
        public string Content
        {
            get { return _Content; }
        }
        public string Title
        {
            get { return _Title; }
        }
        public string From
        {
            get { return _From; }
        }
        public DateTime AddDate
        {
            get { return _AddDate; }
        }
        public int ClsID
        {
            get { return _clsID; }
        }
        public int TmpID
        {
            get { return _tmpID; }
        }



    }
}
