var app = app || {};

app.service = (function () {
    var urls = {
        getMe: '/Home/GetMe',
        getStocks: '/Stock/Get',
        getStockById: '/Stock/GetById',
        updateStock: '/Stock/UpdateStock',
        addStock: '/Stock/AddStock',
        getPortfolio: '/Portfolio/GetPortfolio',
        signIn: '/User/SignIn',
        getUser: '/User/GetUser',
        buyStock: '/Stock/BuyStock',
        sellStock: '/Stock/SellStock'
    };

    var signIn = function (name, callback) {
        var data = { name: name };
        app.service.callController(data, false, callback, urls.signIn);
    },
    getUser = function (callback) {
        app.service.callController({}, false, callback, urls.getUser);
    },
    getMe = function (data, isAsync, callback) {
        app.service.callController(data, isAsync, callback, urls.getMe);
    },
    getStocks = function (callback) {
        app.service.callController({}, false, callback, urls.getStocks);
    },
    getStockById = function (id, callback) {
        var data = { id: id };
        app.service.callController(data, false, callback, urls.getStockById);
    },
    getPortfolio = function (callback) {
        app.service.callController({}, false, callback, urls.getPortfolio)
    },
    updateStock = function (id, symbol, companyName, price, callback) {
        var data = { id: id, symbol: symbol, companyName: companyName, price: price };
        app.service.callController(data, false, callback, urls.updateStock);
    },
    addStock = function (symbol, companyName, price, callback) {
        var data = { symbol: symbol, companyName: companyName, price: price };
        app.service.callController(data, false, callback, urls.addStock);
    },
    callController = function (data, isAsync, callback, url) {
        $.ajax({
            url: url,
            async: isAsync,
            data: data,
            cache: false,
            error: function (xhr, ajaxOptions, thrownError) {
                message.error(thrownError + '. Please try again later.');
            }
        }).then(function (data) {
            if (callback) {
                callback(data);
            }
        }).done();
    };

    return {
        signIn: signIn,
        getUser: getUser,
        getMe: getMe,
        getStocks: getStocks,
        getStockById: getStockById,
        getPortfolio: getPortfolio,
        updateStock: updateStock,
        addStock: addStock
    }
})();