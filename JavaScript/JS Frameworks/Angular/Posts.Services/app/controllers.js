function PostsController($scope) {
    $scope.newPost = {
        title: "",
        content: "",
        category: ""
    }

    var data = persisters.get("http://localhost:17387/api/");

    data.posts.all().then(function (data) {
        $scope.posts = data;
    });

    data.categories.all().then(function (data) {
        $scope.categories = data;
    });

    $scope.addPost = function () {
        var currPost = $scope.newPost;
        var newPost = {
            title: currPost.title,
            content: currPost.content,
            category: {name: currPost.category}
        };

        data.posts.create(newPost).then(function () {
            $scope.post.push(currPost);
        }, function (err) {
            console.log(err);
        });
    }
}

function PostsByCategoryController($scope, $routeParams) {
    var data = persisters.get("http://localhost:17387/api/");
    data.posts.getPostsByCategory($routeParams.id).then(function (data) {
        $scope.posts = data;
        console.log($scope.posts);
    });
}