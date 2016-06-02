var common = common || {};

common = {
    navigateBack: function () {
        window.history.back(1);
    },
    isAuthenticated: function () {
        var isUserSignedIn;
        app.service.getUser(getUserCallback);
        return isUserSignedIn;
        function getUserCallback(data) {
            isUserSignedIn = data.IsSignedIn;
        }
    }
};