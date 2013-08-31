define(["jquery", "requester"], function ($, requester) {
    var rootUrl = 'http://localhost:1418/api/';

    var registerUser = function (user) {
        var url = rootUrl + 'users/register';
        var response = requester.postJSON(url, user);
        return response;
    }

    var loginUser = function (user) {
        var url = rootUrl + 'users/login';
        var response = requester.postJSON(url, user);
        return response;
    }

    var logoutUser = function () {
        localStorage.clear();
    }

    var allPosts = function (sessionKey) {
        var url = rootUrl + 'posts?sessionKey=' + sessionKey;
        var response = requester.getJSON(url);
        return response;
    }

    var postById = function (postId, sessionKey) {
        var url = rootUrl + 'posts/' + postId + '?sessionKey=' + sessionKey;
        var response = requester.getJSON(url);
        return response;
    }

    var postByTag = function (tags, sessionKey) {
        var url = rootUrl + 'posts?tags=' + tags + '&sessionKey=' + sessionKey;
        var response = requester.getJSON(url);
        return response;
    }

    var putComment = function (postId, sessionKey, comment) {
        var url = rootUrl + 'posts/' + postId + '/comment?sessionKey=' + sessionKey;
        var response = requester.putJSON(url, comment);
        return response;
    }

    return {
        registerUser: registerUser,
        loginUser: loginUser,
        logoutUser: logoutUser,
        allPosts: allPosts,
        postById: postById,
        postsByTag: postByTag,
        putComment: putComment
    };
});