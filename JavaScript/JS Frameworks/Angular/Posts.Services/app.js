/// <reference path="_references.js" />

(function () {
    angular.module("posts", [])
	.config(["$routeProvider", function ($routeProvider) {
	    $routeProvider
			.when("/", { templateUrl: "partials/posts.html", controller: PostsController })
			.when("/category/:id/posts", { templateUrl: "partials/list-post.html", controller: PostsByCategoryController })
			//.when("/category/:name", { templateUrl: "scripts/partials/category.html", controller: CategoryController })
			.otherwise({ redirectTo: "/" });
	}]);
})();