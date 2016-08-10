
(function () {
    var app = angular.module('store', []);

    // 动态切换tab页
    app.controller('PanelController', function () {
        this.tab = 1;
        this.selectTab = function (setTab) {
            this.tab = setTab;
        };
        this.isSelected = function (checkTab) {
            return this.tab === checkTab;
        };
    });


    app.controller('StoreController', function () {
        this.product = gem;
        this.product2 = gem2;
    });

    var gem = {
        name: 'Cat',
        price: 2.0,
        description: 'this is a  cat !',
        canPurchase: true,
        soldOut:true
    }

    //数组
    var gem2 = [{
        name: 'Cat',
        price: 2.0,
        description: 'this is a  cat !',
        canPurchase: true
    }
    ,
    {
        name: 'Dog',
        price: 3.987,
        description: 'this is a  Dog !',
        canPurchase: false
    }]

})();
