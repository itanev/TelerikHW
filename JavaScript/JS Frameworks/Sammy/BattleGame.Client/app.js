/// <reference path="Scripts/cryptojs-sha1.js" />
/// <reference path="Scripts/mustache.js" />

( function () {
    require.config({
        paths: {
            jquery: "Scripts/jquery-2.0.3",
            sammy: "Scripts/sammy",
            mustache: "Scripts/mustache",
            requester: "Scripts/http-requester",
            underscore: "Scripts/underscore",
            rsvp: "Scripts/rsvp.min",
            crypto: "Scripts/cryptojs-sha1",
            storage: "Scripts/storage",
            controls: "Scripts/list-view",
            class: "Scripts/class"
        }
    });

    require(["jquery", "sammy", "mustache", "crypto", "controler", "storage", "controls"],
            function ($, sammy, mustache, crypto, controler, storage, c) {

                function getActive(getGames) {
                    var sessionKey = localStorage.getObject('loggedUser').sessionKey;
                    getGames(sessionKey).then(function (games) {
                        var template = mustache.compile($("#active-template").html());
                        var listView = c.controls.getListView(games);

                        var html = listView.render(template);

                        $("#content").html(html);
                    });
                }

        var app = sammy("#content", function () {
            this.get("#/", function () {
                var html = mustache.compile($('#home-template').html());
                $('#content').html(html);

                $('#register').click(function () {
                    location.href = '/#/register';
                });

                $('#login').click(function () {
                    location.href = '/#/login';
                });
            });

            this.get("#/register", function () {
                var html = mustache.compile($('#register-template').html());
                $('#content').html(html);

                $('#register-user').click(function () {
                    var username = $('#username').val();
                    var nickname = $('#nickname').val();
                    var password = $('#password').val();

                    var newUser = {
                        username: username,
                        nickname: nickname,
                        authcode: crypto.SHA1(username + password).toString()
                    }

                    controler.registerUser(newUser).then(function (usr) {
                        localStorage.setObject("loggedUser", usr);
                        location.href = '/#/home';
                    });
                });
            });

            this.get("#/login", function () {
                var html = mustache.compile($('#login-template').html());
                $('#content').html(html);

                $('#login-user').click(function () {
                    var username = $('#username').val();
                    var password = $('#password').val();

                    var currUser = {
                        username: username,
                        authCode: crypto.SHA1(username + password).toString()
                    }

                    controler.loginUser(currUser).then(function (usr) {
                        localStorage.setObject("loggedUser", usr);
                        location.href = '/#/home';
                    });
                });
            });

            this.get("#/home", function () {
                var currUser = localStorage.getObject("loggedUser");
                var html = mustache.render($('#welcome-template').html(), currUser);
                $('#content').html(html);

                $("#active").click(function () {
                    location.href = '/#/active';
                });

                $("#my-active").click(function () {
                    location.href = '/#/my-active';
                });
            });

            this.get("#/active", function () {
                getActive(controler.getActiveGames);
            });

            this.get("#/my-active", function () {
                getActive(controler.getMyActiveGames);
            });
        });

        app.run("#/");		
    });    
}());