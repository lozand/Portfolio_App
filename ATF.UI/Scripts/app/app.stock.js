var app = app || {};

app.stock = (function () {
    var stock = ko.observableArray(),
        user = ko.observable();

    var index = function () {
        bindControls();
        app.service.getStocks(getStocksCallback);
        

        getUser();
    },
    bindControls = function () {

    },
    buyStock = function (data) {
        var stockId = data.ID;
        app.service.buyStock(stockId, 1, message.basicCallback);
    },
    sellStock = function (data) {
        var stockId = data.ID;
        app.service.sellStock(stockId, 1, message.basicCallback);
    },
    getStocksCallback = function (data) {
        //stock(data);
        for (var i = 0; i < data.length; i++) {
            app.service.getStockBySymbol(data[i].Symbol, assignStockData);
        }
        
        function assignStockData(apiData) {
            var tooManyRequests = 'Request blockedExceeded requests/sec limit.'
            if (apiData.indexOf('Try another symbol') === -1 && apiData.indexOf(tooManyRequests) === -1) {
                stock.push(JSON.parse(apiData));
            } else if (apiData.indexOf(tooManyRequests) !== -1) {
                message.error('Too many stock api calls / second');
                setTimeout(function () { }, 3000);
            }
            //stock.push(apiData);
        }
    },
    getUser = function () {
        app.service.getUser(getUserCallback);

        function getUserCallback(data) {
            user(data);
        }
    };

    return {
        index: index,
        buyStock: buyStock,
        sellStock: sellStock,
        user: user,
        stock: stock
    }
    
})();