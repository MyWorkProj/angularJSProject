<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="angularJSProj.Web.页面切换.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>main</title>
    <script src="../../JS/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        function btnShow() {
            //  当前页面地址设置
            location.href = "senond.aspx?search_1=" + $("#search_1").val() + "&search_2=" + $("#search_2").val();
           
        }
        function btnBack() {
            window.history.back();
        }
    </script>
</head>
<body>
    <!--- form action 可以 --->
    <form id="form1" runat="server"  action="senond.aspx">


        <label>===============main======================</label>
        <div>
            <input type="text" value="<%=Request.QueryString["search_1"] %>" id="search_1"/>
            <%--<asp:TextBox runat="server" Text="Text" ID="search_2"><%=Request.QueryString["search_2"] %></asp:TextBox>--%>
          <input type="text" value="<%=Request.QueryString["search_2"] %>" id="search_2"/>
            <button onclick="btnBack()">history.back</button>
             <a href="senond.aspx">senond.aspx</a>
        </div>

       <asp:Button runat="server" OnClick="redirect2senond" Text="后台跳转"/>
        <input type="submit" value="提交"/>
    </form>

      <button onclick="btnShow()">显示新页面xxxxxxxxxxxxxx</button>

    <!--location.href 可以 -->
    <button onclick="location.href = 'senond.aspx'">显示新页面2</button>

</body>
</html>
