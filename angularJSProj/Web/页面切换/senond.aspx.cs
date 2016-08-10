using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace angularJSProj.Web.页面切换
{
    public partial class senond : System.Web.UI.Page
    {
        public string search_1;
        public string search_2;
        protected void Page_Load(object sender, EventArgs e)
        {
            search_1 = Request.QueryString["search_1"];
        }

    }
}