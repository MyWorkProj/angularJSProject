<%@ Page Title="userinfotb" Language="C#" MasterPageFile="~/Web/link_curd/MasterPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.userinfotb.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Title -->

    <!--Title end -->

    <!--Add  -->

    <!--Add end -->

    <!--Search -->
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td style="width: 80px" align="right" class="tdbg">
                <b>关键字：</b>
            </td>
            <td class="tdbg">
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"></asp:Button>



            </td>
            <td class="tdbg"></td>
        </tr>
    </table>

    <div class="btn-group fr">
        <span class="btn  btn-sm btn-warning btn-file ink-reaction btn-block" id="sp_upload" style="margin-top: 10px">选择上传文件…
            <input runat="server" name="File" type="file" id="fileImp" />
            <asp:HiddenField runat="server" Value="" ID="hidePath" />
        </span>
    </div>

    <div class="btn-group fr">
        <asp:Button runat="server" ID="Button1" OnClick="importFaq" OnClientClick="importFaq()" CssClass="btn  green btn-sm ink-reaction  fr" Style="margin-top: 10px;" Text="Excel导入" />
    </div>
    <!--Search end-->
    <br />
    <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging"
        BorderWidth="1px" DataKeyNames="id" OnRowDataBound="gridView_RowDataBound"
        AutoGenerateColumns="false" PageSize="10" RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
        <Columns>
            <asp:TemplateField ControlStyle-Width="30" HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="adress" HeaderText="adress" SortExpression="adress" ItemStyle-HorizontalAlign="Center" />

            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                Text="详细" />
            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                Text="编辑" />
            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除" Visible="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="删除"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
        <tr>
            <td style="width: 1px;"></td>
            <td align="left">
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
