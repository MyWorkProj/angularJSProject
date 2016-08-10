using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Blog.main
{
    /// <summary>
    /// AjaxWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class AjaxWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int GetAllCount()
        {
            BlogSpace.BLL.Blog.bloginfotb bll = new BlogSpace.BLL.Blog.bloginfotb();
            DataSet ds = bll.GetAllList();
            return ds.Tables[0].Rows.Count;
        }
        [WebMethod]
        public List<BlogSpace.Model.Blog.bloginfotb> GetListByPage(string strWhere, string orderby, int startIndex, int length)
        {
            BlogSpace.BLL.Blog.bloginfotb bll = new BlogSpace.BLL.Blog.bloginfotb();

            List<BlogSpace.Model.Blog.bloginfotb> list = new List<BlogSpace.Model.Blog.bloginfotb>();
            DataSet ds = bll.GetListByPage(strWhere, orderby, startIndex, length);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                BlogSpace.Model.Blog.bloginfotb model = new BlogSpace.Model.Blog.bloginfotb();
                model.Content = ds.Tables[0].Rows[i]["Content"].ToString();
                model.CreateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreateDate"]);
                model.Mark = ds.Tables[0].Rows[i]["Mark"].ToString();
                model.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                model.TypeNo = ds.Tables[0].Rows[i]["TypeNo"].ToString();

                list.Add(model);
            }

            return list;
        }
    }
}
