var app = app || {};

app.service = {
    _urls: {
        getMe: '/Home/GetMe'
    },
    getMe: function (data, isAsync, callback) {
        $.ajax({
            url: app.service._urls.getMe,
            async: isAsync,
            data: data
        }).then(function (data) {
            if (callback) {
                callback(data);
            }
        }).done();
    }
};