var app = app || {};

app.stockadd = {
    index: function ($context) {
        app.stockadd.bindControls($context);
        app.stockadd.stock({Symbol: '', LastPrice: 1, CompanyName: ''});
    },
    bindControls: function ($context) {
        $('.save-stock', $context).on('click', function (e) {
            app.stockadd.saveStock();
        });
        $('.navigate-back', $context).on('click', function (e) {
            common.navigateBack();
        });
    },
    saveStock: function () {
        var stock = app.stockadd.stock();
        app.service.addStock(stock.Symbol, stock.CompanyName, stock.LastPrice, writeMessage);

        function writeMessage(data) {
            if (data.StatusCode === 200) {
                message.success("Stock successfully Added");
                app.stockadd.stock({ Symbol: '', LastPrice: 1, CompanyName: '' });
            }
            else {
                message.error("There was an error while saving your stock. Please try again later.")
            }
            
        }
    },
    stock: ko.observable()
};