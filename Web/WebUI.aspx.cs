using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using BLL;
using Model;

namespace myWeb
{
    /// <summary>
    /// WebForm1 的摘要说明。
    /// </summary>
    public partial class WebUI : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Label lblTitle;
        protected System.Web.UI.WebControls.Label lblDataTime;
        protected System.Web.UI.WebControls.Label lblContent;
        protected System.Web.UI.WebControls.Label lblMsg;

        private ContentInfo ci;


        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetContent("1");
            }
        }

        private void GetContent(string id)
        {
            int ID = myWeb.WebComponents.CleanString.GetInt(id);

            BLL.Content c = new BLL.Content();
            ci = c.GetContentInfo(ID);
            if (ci != null)
            {
                this.lblTitle.Text = ci.Title;
                this.lblDataTime.Text = ci.AddDate.ToString("yyyy-MM-dd");
                this.lblContent.Text = ci.Content;
            }
            else
            {
                this.lblMsg.Text = "没有找到这篇文章";
            }
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
