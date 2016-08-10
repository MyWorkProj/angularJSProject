<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="senond.aspx.cs" Inherits="angularJSProj.Web.页面切换.senond" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>second</title>
    <script src="../../JS/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        function btnBack() {
            window.history.back();
        }
        function btnSubmit() {
            var v1 = $("#search_1").val();
            var v2 = $("#search_2").val();
            var str = "main.aspx?search_1=" +v1 + "&search_2=" +v2;
            location.href = str;
            //alert("提交成功！！！！");
        }
        function btnBack2() {
            //location.href = "main.aspx";
            var v1 = $("#search_1").val();
            var v2 = $("#search_2").val();
            var str = "main.aspx?search_1=" + v1 + "&search_2=" + v2;
            //location.href = str;
            form1.action = str;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <label>===============second======================</label>
        <div>
            <input type="text" value="22222" />

            <button onclick="btnBack()">history.back</button>
            <a href="main.aspx?search_1=11111&search_2=22222">main.aspx</a>
            <%--<a href=<%= "main.aspx?search_1=" + $("#search_1").val() + "&search_2=" + $("#search_2").val()%>>返回main</a>--%>
            <button onclick="btnBack2()">返回main</button>
        </div>


        <input type="submit" onclick="btnSubmit()" value="second提交"/>
    </form>

    <form hidden="hidden">
        <input type="hidden" id="search_1" value="<% = Request.QueryString["search_1"] %>" />
        <input type="hidden" id="search_2" value="<% = Request.QueryString["search_2"] %>" />
    </form>
</body>
</html>
