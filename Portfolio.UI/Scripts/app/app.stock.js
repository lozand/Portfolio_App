var app = app || {};

app.stock = {
    index: function () {
        app.stock.bindControls();
        app.service.getStocks(app.stock.getStocksCallback);
    },
    bindControls: function () {
    },
    getStocksCallback: function (data) {
        app.stock.stock(data);
    },
    stock: ko.observableArray()
};