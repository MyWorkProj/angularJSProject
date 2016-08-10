using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;
using System.Drawing;
using LTP.Accounts.Bus;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data.OleDb;
namespace Maticsoft.Web.userinfotb
{
    public partial class List : Page
    {
        
        
        
		Maticsoft.BLL.userinfotb bll = new Maticsoft.BLL.userinfotb();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridView.BorderColor = ColorTranslator.FromHtml("Blue");
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml("Gray");
                btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？\")");
                BindData();
            }
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0) 
                return;
            bll.DeleteList(idlist);
            BindData();
        }
        
        #region gridView
                        
        public void BindData()
        {
            #region
            //if (!Context.User.Identity.IsAuthenticated)
            //{
            //    return;
            //}
            //AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
            //if (user.HasPermissionID(PermId_Modify))
            //{
            //    gridView.Columns[6].Visible = true;
            //}
            //if (user.HasPermissionID(PermId_Delete))
            //{
            //    gridView.Columns[7].Visible = true;
            //}
            #endregion

            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (txtKeyword.Text.Trim() != "")
            {      
                #warning 代码生成警告：请修改 keywordField 为需要匹配查询的真实字段名称
                //strWhere.AppendFormat("keywordField like '%{0}%'", txtKeyword.Text.Trim());
            }            
            ds = bll.GetList(strWhere.ToString());            
            gridView.DataSource = ds;
            gridView.DataBind();
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void gridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].Text = "<input id='Checkbox2' type='checkbox' onclick='CheckAll()'/><label></label>";
            }
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
                linkbtnDel.Attributes.Add("onclick", "return confirm(\"你确认要删除吗\")");
                
                //object obj1 = DataBinder.Eval(e.Row.DataItem, "Levels");
                //if ((obj1 != null) && ((obj1.ToString() != "")))
                //{
                //    e.Row.Cells[1].Text = obj1.ToString();
                //}
               
            }
        }
        
        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //#warning 代码生成警告：请检查确认真实主键的名称和类型是否正确
            //int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            //bll.Delete(ID);
            //gridView.OnBind();
        }

        private string GetSelIDlist()
        {
            string idlist = "";
            bool BxsChkd = false;
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl("DeleteThis");
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;
                    //#warning 代码生成警告：请检查确认Cells的列索引是否正确
                    if (gridView.DataKeys[i].Value != null)
                    {                        
                        idlist += gridView.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
            return idlist;
        }


        protected void importFaq(Object sender, EventArgs e)
        {
            // 服务端控件上传文件路径
            string path = Server.MapPath("~/FileUpload/") + System.IO.Path.GetFileName(fileImp.Value);

            //将文件保存在这个路径里面。
            fileImp.PostedFile.SaveAs(path);

            DataSet ds = ExcelSqlConnection(path,fileImp.Value);
            DataRow[] dr = ds.Tables[0].Select();            //定义一个DataRow数组
            int rowsnum = ds.Tables[0].Rows.Count;
            if (rowsnum == 0)
            {
                Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
            }
            else
            {
                BLL.userinfotb bll = new BLL.userinfotb();
                for (int i = 1; i < dr.Length; i++)
                {
                    //前面除了你需要在建立一个“upfiles”的文件夹外，其他的都不用管了，你只需要通过下面的方式获取Excel的值，然后再将这些值用你的方式去插入到数据库里面
                    string title = dr[i]["name"].ToString();
                    string linkurl = dr[i]["age"].ToString();
                    string categoryname = dr[i]["phone"].ToString();
                    string customername = dr[i]["adress"].ToString();

                    Model.userinfotb modeluser = new Model.userinfotb();
                    modeluser.name = dr[i]["name"].ToString();
                    modeluser.age = Convert.ToInt32(dr[i]["age"].ToString());
                    modeluser.phone = dr[i]["phone"].ToString();
                    modeluser.adress = dr[i]["adress"].ToString();
                    bll.Add(modeluser);
                    //Response.Write("<script>alert('导入内容:" + ex.Message + "')</script>");
                }
                Response.Write("<script>alert('Excle表导入成功!');</script>");
            }

            //ReadFromExcelFile(path);
        }
        //public void ReadFromExcelFile(string filePath)
        //{
        //    NPOI.SS.UserModel.IWorkbook wk = null;
        //    string extension = System.IO.Path.GetExtension(filePath);
        //    try
        //    {
        //        FileStream fs = File.OpenRead(filePath);
        //        if (extension.Equals(".xls"))
        //        {
        //            //把xls文件中的数据写入wk中
        //            wk = new HSSFWorkbook(fs);
        //        }
        //        else
        //        {
        //            //把xlsx文件中的数据写入wk中
        //            wk = new XSSFWorkbook(fs);
        //        }

        //        fs.Close();
        //        //读取当前表数据
        //        ISheet sheet = wk.GetSheetAt(0);

        //        IRow row = sheet.GetRow(0);  //读取当前行数据
        //        //LastRowNum 是当前表的总行数-1（注意）
        //        int offset = 0;

        //        // 从第二行开始导入
        //        for (int i = 1; i <= sheet.LastRowNum; i++)
        //        {
        //            row = sheet.GetRow(i);  //读取当前行数据
        //            if (row != null)
        //            {
        //                ////LastCellNum 是当前行的总列数
        //                //for (int j = 0; j < row.LastCellNum; j++)
        //                //{
        //                //    //读取该行的第j列数据
        //                //    string value = row.GetCell(j).ToString();
        //                //    Console.Write(value.ToString() + " ");
        //                //}
        //                //Console.WriteLine("\n");
        //                Model.userinfotb modeluser = new Model.userinfotb();
        //                //modeltfaq.ID = 0;
        //                //if (FrameWork.UserData.GetUserDate != null)
        //                //{
        //                //    modeltfaq.IDAgent = int.Parse(FrameWork.UserData.GetUserDate.U_UserNO);
        //                //}
        //                //modeluser.CreateDate = DateTime.Now;
        //                modeluser.name = row.GetCell(0).ToString();
        //                modeluser.age =Convert.ToInt32( row.GetCell(1).ToString());
        //                modeluser.phone = row.GetCell(2).ToString();
        //                modeluser.adress = row.GetCell(3).ToString();
                        
        //                BLL.userinfotb bll = new BLL.userinfotb();
        //                bll.Add(modeluser);
        //            }
        //        }
        //    }

        //    catch (Exception e)
        //    {
        //        //只在Debug模式下才输出
        //        Console.WriteLine(e.Message);
        //    }
        //}

        #region 连接Excel  读取Excel数据   并返回DataSet数据集合
        /// <summary>
        /// 连接Excel  读取Excel数据   并返回DataSet数据集合
        /// </summary>
        /// <param name="filepath">Excel服务器路径</param>
        /// <param name="tableName">Excel表名称</param>
        /// <returns></returns>
        public static System.Data.DataSet ExcelSqlConnection(string filepath, string tableName)
        {
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
            OleDbConnection ExcelConn = new OleDbConnection(strCon);
            try
            {
                string strCom = string.Format("SELECT * FROM [Sheet1$]");
                ExcelConn.Open();
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, ExcelConn);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "[" + tableName + "$]");
                ExcelConn.Close();
                return ds;
            }
            catch
            {
                ExcelConn.Close();
                return null;
            }
        }
        #endregion
        #endregion





    }
}
