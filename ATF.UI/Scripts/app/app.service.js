var app = app || {};

app.service = (function () {
    var urls = {
        getMe: '/Home/GetMe',
        getStocks: '/Stock/Get',
        getStockById: '/Stock/GetById',
        updateStock: '/Stock/UpdateStock',
        addStock: '/Stock/AddStock',
        deleteStock: '/Stock/DeleteStock',
        getPortfolio: '/Portfolio/GetPortfolio',
        signIn: '/User/SignIn',
        getUser: '/User/GetUser',
        buyStock: '/Stock/BuyStock',
        sellStock: '/Stock/SellStock'
    };

    var signIn = function (name, callback) {
        var data = { name: name };
        callController(data, false, callback, urls.signIn);
    },
    buyStock = function (stockId, quantity, callback) {
        var data = { stockId: stockId, quantity: quantity };
        callController(data, false, callback, urls.buyStock);
    },
    sellStock = function (stockId, quantity, callback) {
        var data = { stockId: stockId, quantity: quantity };
        callController(data, false, callback, urls.sellStock);
    },
    deleteStock = function (stockId, callback) {
        var data = { stockId: stockId };
        callController(data, false, callback, urls.deleteStock);
    },
    getUser = function (callback) {
        callController({}, false, callback, urls.getUser);
    },
    getMe = function (data, isAsync, callback) {
        callController(data, isAsync, callback, urls.getMe);
    },
    getStocks = function (callback) {
        callController({}, false, callback, urls.getStocks);
    },
    getStockById = function (id, callback) {
        var data = { id: id };
        callController(data, false, callback, urls.getStockById);
    },
    getPortfolio = function (callback) {
        callController({}, false, callback, urls.getPortfolio)
    },
    updateStock = function (id, symbol, companyName, price, callback) {
        var data = { id: id, symbol: symbol, companyName: companyName, price: price };
        callController(data, false, callback, urls.updateStock);
    },
    addStock = function (symbol, companyName, price, callback) {
        var data = { symbol: symbol, companyName: companyName, price: price };
        callController(data, false, callback, urls.addStock);
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
        buyStock: buyStock,
        sellStock: sellStock,
        deleteStock: deleteStock,
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