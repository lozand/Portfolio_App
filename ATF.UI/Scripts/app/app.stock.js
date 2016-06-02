﻿var app = app || {};

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
        stock(data);
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