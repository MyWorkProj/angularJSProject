<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="angularJSProj.Web.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/bootstrap.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>

<!--关联angularJS和对应app、控制器-->
<body ng-app="store">

    <form id="form1" runat="server">
        <hr />
        <section ng-controller="PanelController as panel" ng-init="tab=1">
            <ul class="nav nav-pills">
                <li ng-class="{active:panel.isSelected(1)}">
                    <a href ng-click="panel.selectTab(1)">Description</a>
                </li>

                <li ng-class="{active:panel.isSelected(2)}">
                    <a href ng-click="panel.selectTab(2)">Specifications</a>
                </li>

                <li ng-class="{active:panel.isSelected(3)}">
                    <a href ng-click="panel.selectTab(3)">Reviews</a>
                </li>
                
            </ul>
            <div class="panel" ng-controller="StoreController as store" ng-show="panel.isSelected(1)">
                <h4>description</h4>
                <p>{{store.product.description}}</p>
            </div>
        </section>
        <hr /><hr /><hr /><hr /><hr /><hr /><hr /><hr />
        <!-- 页面切换
             初始化-->
        <section ng-init="tab = 1">
            <ul class="nav nav-pills">
                <li><a href ng-click="tab = 1">Description</a> </li>
                <li><a href ng-click="tab = 2">Specifications</a> </li>
                <li><a href ng-click="tab = 3">Reviews</a> </li>

                {{tab}}
            </ul>
            <div class="panel" ng-show="tab === 1">
                <h4>Description</h4>
                <p>Description11111</p>
            </div>
            <div class="panel" ng-show="tab === 2">
                <h4>Description</h4>
                <p>Description22222</p>
            </div>
            <div class="panel" ng-show="tab === 3">
                <h4>Description</h4>
                <p>Description33333</p>
            </div>

            
        </section>
        <hr />
       
        <hr />
        <div ng-controller="StoreController as store">
            <hr />
            <%--显示隐藏按钮/模块--%>
            <%--<div ng-hide="store.product.soldOut">
                <h1>{{store.product.name}}</h1>
                <h2>${{store.product.price}}</h2>
                <p>{{store.product.description}}</p>
                <button ng-show="store.product.canPurchase">Add to Cart</button>
            </div>--%>

            <ul class="list-group">
                <li ng-repeat="product in store.product2">
                    <h3>{{product.name}}
                        <em class="pull-right">{{product.price | currency}}</em>
                    </h3>

                    <div class="panel" ng-show="tab ===1">
                        <h4>Description</h4>
                        <p>{{product.description}}</p>
                    </div>
                </li>
                <li>{{'1388123412323' | date:'MM/dd/yyyy @ h:mma'}}
                    {{'2016年3月30日17:17:33' | date:'MM/dd/yyyy @ h:mma'}}
                </li>

            </ul>
            <hr />
            <%--<div ng-repeat="product in store.product2">
                <h3>{{product.name}}</h3>
                <h3>${{product.price}}</h3>
                <p>{{product.description}}</p>
                <button ng-show="product.canPurchase">Add to Cart</button>

            </div>--%>
        </div>



        <hr />
        Search:
        <input ng-model="query">
        Sort by:
        <select ng-model="orderProp">
            <option value="name">Alphabetical</option>
            <option value="age">Newest</option>
        </select>



        <%--查询  排序 关键字  filter:  orderBy:   循环 ng-repeat="phone in phones"  --%>
       <%-- <ul ng-controller="PhoneListCtrl" class="phones">
            <li ng-repeat="phone in phones | filter:query | orderBy:orderProp">
                <span>{{phone.name}}</span>
                <p>{{phone.snippet}}</p>
            </li>
        </ul>--%>

        <hr />

        <%--<ul ng-controller="PhoneListCtrlGet" class="phones2">
            <li ng-repeat="phone in phones2 | filter:query | orderBy:orderProp">
                <span>{{phone.name}}</span>
                <p>{{phone.snippet}}</p>
            </li>
        </ul>

        <hr />
        <ul ng-controller="GetPhotos" class="phones3">
            <li ng-repeat="phone in phones3 | filter:query | orderBy:orderProp" class="thumbnail">
                <a href="#/phones/{{phone.id}}" class="thumb">
                    <img ng-src="{{phone.imageUrl}}" alt="{{phone.name}}"></a>
                <a href="#/phones/{{phone.id}}">{{phone.name}}</a>
                <p>{{phone.snippet}}</p>
            </li>
        </ul>--%>

        <%--<a href="#/phones/1"><img src="../phones/p1.jpg" alt="p1"/> p1.jpg</a>--%>
    </form>


    <script src="../JS/angular.min.js"></script>
    <script src="../JS/controller.js"></script>
    <script src="../JS/app.js"></script>
</body>
</html>
