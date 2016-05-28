var app = app || {};

app.service = {
    _urls: {
        getMe: '/Home/GetMe',
        getStocks: '/Stock/Get',
        getStockById: '/Stock/GetById',
        saveStock: '/Stock/SaveStock'
    },
    getMe: function (data, isAsync, callback) {
        app.service.callController(data, isAsync, callback, app.service._urls.getMe);
    },
    getStocks: function (callback) {
        app.service.callController({}, false, callback, app.service._urls.getStocks);
    },
    getStockById: function(id, callback){
        var data = { id: id };
        app.service.callController(data, false, callback, app.service._urls.getStockById);
    },
    saveStock: function(id, symbol, companyName, price, callback){
        var data = { id: id, symbol: symbol, companyName: companyName, price: price };
        app.service.callController(data, false, callback, app.service._urls.saveStock);
    },
    callController: function (data, isAsync, callback, url) {
        $.ajax({
            url: url,
            async: isAsync,
            data: data,
            cache: false
        }).then(function (data) {
            if (callback) {
                callback(data);
            }
        }).done();
    }
};