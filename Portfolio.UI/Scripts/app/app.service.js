var app = app || {};

app.service = {
    _urls: {
        getMe: '/Home/GetMe',
        getStocks: '/Stock/Get'
    },
    getMe: function (data, isAsync, callback) {
        app.service.callController(data, isAsync, callback, app.service._urls.getMe);
    },
    getStocks: function (data, isAsync, callback) {
        app.service.callController(data, isAsync, callback, app.service._urls.getStocks);
    },
    callController: function (data, isAsync, callback, url) {
        $.ajax({
            url: url,
            async: isAsync,
            data: data
        }).then(function (data) {
            if (callback) {
                callback(data);
            }
        }).done();
    }
};