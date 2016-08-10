<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="点击窗口删除.aspx.cs" Inherits="angularJSProj.Web.点击窗口删除" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/jquery-1.10.2.min.js"></script>
    <script>
        var del_tag = function () {
            var tag = null;
            return {
                get: function (e) {
                    tag = e;
                },
                del: function () {
                    $(tag).remove();
                }
            }
        }

        var dt = del_tag();//把del_tag赋值给dt

        function get_tag(e) {

            var ele = e.target;
            //$(ele).css('border', '1px solid red')
            $(ele).append("<button style='visibility: visible' id='del' onclick='dt.del();'>删除</button>");
            var tagname = ele.tagName;
            //定义一个tag数组. 用来存储我们想删除的对象
            var tagarr = ['SPAN', 'H1', 'H2', 'H3', 'H4', 'H5', 'H6', 'P', 'LABEL', 'DIV', 'BUTTON'];
            //判断如果我们点击的对象 是不是我们数组里所声明的,可以删除的.
            if (tagarr.indexOf(tagname) > -1) {
                //调用dt.get() 参数就是get_tag函数event参数的值的target
                dt.get($(ele));
            }
        }
        //$('#del').click(function () {
        //    //这里,由于创建了闭包.我们上次点击的对象被保存了起来.
        //    //所以这里可以直接调用dt.del()  删除对象
        //    dt.del();
        //})
        //function delFunc() {
        //    dt.del();
        //}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!----点击删除--->
        <div onclick="get_tag(event)">
            --------------------------------------------------1-----------------------------------------------------
            <h1>===h1==</h1>
            <h2>===h2==</h2>
            <h3>===h3==</h3>
            <h4>===h4==</h4>
            <h5>===h5==</h5>
            <h6>===h6==</h6>
            <label>===label==</label>
            <div>==div=====</div>
            <button>==button==</button>
        </div>
        <div>
            --------------------------------------------------2-----------------------------------------------------
            <h1>===h1==</h1>
            <label>===label==</label>
            <div>==div=====</div>
            <button>==button==</button>
        </div>
    </form>
</body>
</html>
