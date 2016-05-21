var app = app || {};

app.stock = {
    index: function () {
        app.stock.bindControls();
    },
    bindControls: function () {
        $('.get-stock').on('click', function (e) {
            app.service.getStocks(null, false, app.stock.getStocksCallback);
        });
    },
    getStocksCallback: function (data) {
        $('.display-stock')[0].innerHTML = data;
    }
};