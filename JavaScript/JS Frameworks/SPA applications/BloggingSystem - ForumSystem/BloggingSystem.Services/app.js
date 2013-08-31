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

        var app = sammy("#content", function () {
            this.get("#/", function () {
                var html = mustache.compile($('#home-template').html());
                $('#content').html(html);

                $('#register').click(function () {
                    location.href = 'index.html#/register';
                });

                $('#login').click(function () {
                    location.href = 'index.html#/login';
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
                        location.href = 'index.html#/home';
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
                        location.href = 'index.html#/home';
                    });
                });
            });

            this.get("#/home", function () {
                var currUser = localStorage.getObject("loggedUser");
                if (currUser) {
                    var html = mustache.render($('#welcome-template').html(), currUser);
                    $('#content').html(html);
                    $('#logout-user').click(function () {
                        controler.logoutUser();
                        location.href = 'index.html#/';
                    });

                    $('#all-posts').click(function() {
                        location.href = 'index.html#/posts';
                    });
                }
                else {
                    location.href = 'index.html#/';
                }
            });

            this.get("#/posts", function () {
                var currUser = localStorage.getObject("loggedUser");

                if (currUser) {
                    controler.allPosts(currUser.SessionKey).then(function (posts) {
                        var template = mustache.compile($('#posts-template').html());
                        var html = c.controls.getListView(posts).render(template);
                        $('#content').html(html);
                    });
                }
                else {
                    location.href = 'index.html#/';
                }
            });

            this.get("#/post/:postId", function () {
                var currUser = localStorage.getObject("loggedUser");

                if (currUser) {
                    controler.postById(this.params['postId'], currUser.SessionKey).then(function (post) {
                        var html = mustache.render($('#posts-template').html(), post);
                        $('#content').html(html);
                    });
                }
                else {
                    location.href = 'index.html#/';
                }
            });

            this.get("#/posts/:tags", function () {
                var currUser = localStorage.getObject("loggedUser");

                if (currUser) {
                    controler.postsByTag(this.params['tags'], currUser.SessionKey).then(function (posts) {
                        var template = mustache.compile($('#posts-template').html());
                        var html = c.controls.getListView(posts).render(template);
                        $('#content').html(html);
                    });
                }
                else {
                    location.href = 'index.html#/';
                }
            });

            this.get("#/post/:postId/comment", function () {
                var currUser = localStorage.getObject("loggedUser");

                if (currUser) {
                    var commentTemplate = mustache.render($('#comment-template').html());
                    $('#content').html(commentTemplate);

                    var that = this;

                    $('#submit-comment').click(function () {
                        var comment = {
                            Text: $('#content').val()
                        };

                        controler.putComment(that.params['postId'], currUser.SessionKey, comment).then(function () {
                            alert('Comment submitted!');
                        });
                    });
                }
                else {
                    location.href = 'index.html#/';
                }
            });
        });
        app.run("#/");
    });	
})(); 