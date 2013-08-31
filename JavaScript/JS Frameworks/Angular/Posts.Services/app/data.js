/// <reference path="../_references.js" />
window.persisters = (function () {
    var PostsPersister = Class.create({
        init: function (apiUrl) {
            this.rootUrl = apiUrl;
            this.apiUrl = apiUrl + "posts/";
        },
        all: function () {
            return httpRequester.getJson(this.apiUrl);
        },
        create: function (post) {
            return httpRequester.postJson(this.apiUrl, post);
        },
        getPostsByCategory: function (categoryId) {
            var url = this.rootUrl + "category/" + categoryId + "/posts";
            return httpRequester.getJson(url);
        }
    });

    var CategoriesPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl + "category";
        },
        all: function() {
            return httpRequester.getJson(this.apiUrl);
        }
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.posts = new PostsPersister(apiUrl);
            this.categories = new CategoriesPersister(apiUrl);
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());