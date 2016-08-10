using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace angularJSProj.Web.页面切换
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 页面跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void redirect2senond(object sender, EventArgs e)
        {
           // Response.Write("<script language='javascript'>window.location='sendond.aspx'</script>"); 
           // Response.Write("<script language='javascript'>window.open('aaa.aspx');</script>");
           // Response.Redirect("sendond.aspx");

            // Server.Transfer("sendond.aspx?name=zhangsan", true); 
            // Server.Execute("senond.aspx?address=beijing"); 
            // Response.Write("<script>window.showModalDialog('senond.aspx')</script>"); 
            Response.Write("<script>window.showModelessDialog('senond.aspx')</script>"); 
        }
    }
}