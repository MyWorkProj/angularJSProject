var phonecatApp = angular.module('phonecatApp', []);
phonecatApp.controller('PhoneListCtrl', function ($scope) {
    $scope.phones = [
      {
          'name': 'Nexus S',
          'snippet': 'Fast just got faster with Nexus S.',
          'age': 1
      },
      {
          'name': 'Motorola XOOM™ with Wi-Fi',
          'snippet': 'The Next, Next Generation tablet.',
          'age': 2
      },
      {
          'name': 'MOTOROLA XOOM™',
          'snippet': 'The Next, Next Generation tablet.',
          'age': 3
      }
    ];

    $scope.orderProp = 'age';
});


        //发送get请求获取json数据，展示到页面
phonecatApp.controller('PhoneListCtrlGet', function ($scope, $http) {
    $http.get('json/phones.json').success(function (data) {
        $scope.phones2 = data;
    }).error(function (ex) {
        alert("error!!!!!!!");
    });

    $scope.orderProp = 'age';
});


phonecatApp.controller('GetPhotos', function ($scope, $http) {
    $http.get('json/phoneImg.json').success(function (data) {
        $scope.phones3 = data;
    }).error(function (ex) {
        alert("error!!!!!!!");
    });

    $scope.orderProp = 'id';
});
