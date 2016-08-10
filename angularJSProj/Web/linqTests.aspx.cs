using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace angularJSProj.Web
{
    public partial class linqTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            //var data = list.Where(X => EntityFunctions.DiffDays(X.endtime, X.starttime) > 1).ToList();
        }
    }
}