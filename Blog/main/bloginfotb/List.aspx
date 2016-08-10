<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="angularJSProj.blog.main.bloginfotb.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="Id" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="Mark" HeaderText="Mark" SortExpression="Mark" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TypeNo" HeaderText="TypeNo" SortExpression="TypeNo" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="CreateDate" HeaderText="CreateDate" SortExpression="CreateDate" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
        <div id="divSearchContent">
            <div id="div_page"></div>
        </div>
        
    </div>
    </form>

    <script src="../../js/jquery-1.6.4.min.js"></script>
    <script src="../../js/json2.js"></script>
    <script src="../../js/pageSplit.js"></script>

    
    <script>
        function btnOptionSearch() {
            var searchValue = $("#searchInput").val();

            pageChange(1, getObj(0));
        }

        function getObj(mysqlIndex) {
            var searchValue = $("#searchInput").val();
            var obj = new Object();
            obj.strWhere = " title like '%" + searchValue + "%' or Content like '%" + searchValue + "%'";
            obj.orderby = "";

            // mysql  limit 第一个参数，从第几个数开始取
            obj.startIndex = mysqlIndex;
            // mysql  limit 第二个参数，要取数据的个数
            obj.length = 6;

            var parm = JSON2.stringify(obj);
            return parm;
        }

        $().ready(function () {
            // 获取数据总数
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../AjaxService/AjaxWebService.asmx/GetAllCount",
                data: {},
                dataType: 'json',
                success: function (result) {
                    try {
                        var allCount = result.d;
                        
                        pageChange(1, getObj(0));
                    }
                    catch (e) {
                        //window.link.utility.showSuccessMessage(e);
                        return;
                    }
                },
                error: function (result, status) {
                    if (status == 'error') {
                        //window.link.utility.showSuccessMessage(status);
                    }
                }
            });
        });

        
        // pageIndex : 第几页， parm  查询参数
        function pageChange(pageIndex, parm) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../AjaxService/AjaxWebService.asmx/GetListByPage",
                data: parm,
                dataType: 'json',
                success: function (result) {
                    try {

                        showValue(result, pageIndex, parm);
                    }
                    catch (e) {
                        window.link.utility.showSuccessMessage(e);
                        return;
                    }
                },
                error: function (result, status) { //如果没有上面的捕获出错会执行这里的回调函数
                    if (status == 'error') {
                        window.link.utility.showSuccessMessage(status);
                    }
                }
            });
        }

        function showValue(result, pageIndex, parm) {
            var DataSet = result.d;
            var str = "";
            $.each(DataSet, function (i, item) {
                var minContent = getMinContent(item.Content);
                str += "<div class='col-xs-12' onclick='showDetailDiv(this," + item.ID + ")'><p><a class='text-medium text-lg text-primary' href='#'>" + item.FaqTitle + "</a><br><div class='contain-xs pull-left'>" + minContent + "</div></div>";
            })
            $("#divSearchContent").html('');
            $("#divSearchContent").append(str);


            $("#div_page").children().remove();

            // 获取数据总数
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../AjaxService/AjaxWebService.asmx/GetAllFAQCount",
                data: {},
                dataType: 'json',
                success: function (result) {
                    try {
                        var allCount = result.d;
                        var pagegroup = PageSplit(pageIndex, allCount, 6);

                        $("#div_page").html(pagegroup);
                        $("#div_page").find("a").click(function () {
                            var pageindex = parseInt($(this).attr("pageindex"));
                            var str2 = JSON.parse(parm);
                            str2.startIndex = (pageindex - 1) * 6;
                            parm = JSON.stringify(str2);

                            if (pageindex != 0) {
                                pageChange(pageindex, parm);
                            }
                        });
                    }
                    catch (e) {
                        window.link.utility.showSuccessMessage(e);
                        return;
                    }
                },
                error: function (result, status) {
                    if (status == 'error') {
                        window.link.utility.showSuccessMessage(status);
                    }
                }
            });
        }
    </script>
</body>
</html>
