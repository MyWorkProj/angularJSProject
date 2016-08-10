<%@ Page Language="C#" MasterPageFile="~/Web/link_curd/MasterPage.Master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.userinfotb.Show" Title="显示页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">

                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">auto_increment
	：</td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">name
	：</td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblname" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">age
	：</td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">phone
	：</td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblphone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">adress
	：</td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lbladress" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




