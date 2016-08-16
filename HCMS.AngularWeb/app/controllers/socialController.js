app.controller('socialController', ['$scope', function ($scope) {
    $scope.socialModel = {
        Url: location.href,//'https://www.huggies.com.vn/',// 
        Name: $(document).find("title").text(),
        ImageUrl: $("meta[property='og:image']").attr("content")
    };
}]);