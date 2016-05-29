var app = app || {};

app.home = {
    index: function () {
        app.home.bindControls();
        app.home.getUser();
    },
    bindControls: function () {
        $('.js-sign-in').on('click', function (e) {
            e.preventDefault();
            //app.home.signIn();
        });
    },
    signIn: function () {
        app.service.signIn(app.home.user().Name, signInCallback);

        function signInCallback(data) {
            app.home.getUser();
        }
    },
    getUser: function(){
        app.service.getUser(getUserCallback);

        function getUserCallback(data) {
            app.home.user(data);
        }
    },
    user: ko.observable()
};