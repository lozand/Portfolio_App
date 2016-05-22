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
        var returnstring = ''
        //for (var i = 0; i < data.length; i++) {
        //    returnstring += data[i].Symbol + ', ';
        //}
        returnstring = _.map(data, 'Symbol').join(',');
        $('.display-stock')[0].innerHTML = returnstring;
    }
};