define(["jquery", "requester"], function ($, requester) {
    var rootUrl = 'http://localhost:22954/api/';

    var registerUser = function (user) {
        var url = rootUrl + 'user/register';
        var response = requester.postJSON(url, user);
        return response;
    }

    var loginUser = function (user) {
        var url = rootUrl + 'user/login';
        var response = requester.postJSON(url, user);
        return response;
    }

    var getActiveGames = function (sessionKey) {
        var url = rootUrl + 'game/open/' + sessionKey;
        var response = requester.getJSON(url);
        return response;
    }

    var getMyActiveGames = function (sessionKey) {
        var url = rootUrl + 'game/my-active/'+ sessionKey;
        var response = requester.getJSON(url);
        return response;
    }

    return {
        registerUser: registerUser,
        loginUser: loginUser,
        getActiveGames: getActiveGames,
        getMyActiveGames: getMyActiveGames
    };
});