using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace angularJSProj.blog.main.bloginfotb
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            //string strErr = "";
            //if (this.txtMark.Text.Trim().Length == 0)
            //{
            //    strErr += "Mark不能为空！\\n";
            //}
            //if (this.txtTitle.Text.Trim().Length == 0)
            //{
            //    strErr += "Title不能为空！\\n";
            //}
            //if (this.txtContent.Text.Trim().Length == 0)
            //{
            //    strErr += "Content不能为空！\\n";
            //}
            //if (this.txtTypeNo.Text.Trim().Length == 0)
            //{
            //    strErr += "TypeNo不能为空！\\n";
            //}
            //if (!PageValidate.IsDateTime(txtCreateDate.Text))
            //{
            //    strErr += "CreateDate格式错误！\\n";
            //}

            //if (strErr != "")
            //{
            //    MessageBox.Show(this, strErr);
            //    return;
            //}
            string Mark = this.txtMark.Text;
            string Title = this.txtTitle.Text;
            string Content = this.txtContent2.Value;
            string TypeNo = this.txtTypeNo.Text;

            BlogSpace.Model.Blog.bloginfotb model = new BlogSpace.Model.Blog.bloginfotb();
            model.Mark = Mark;
            model.Title = Title;
            model.Content = Content;
            model.TypeNo = TypeNo;
            model.CreateDate = System.DateTime.Now;

            BlogSpace.BLL.Blog.bloginfotb bll = new BlogSpace.BLL.Blog.bloginfotb();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}