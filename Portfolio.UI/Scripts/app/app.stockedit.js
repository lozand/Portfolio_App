var app = app || {};

app.stockedit = {
    index: function () {
        app.stockedit.bindControls();
        app.stockedit.getStock();
    },
    bindControls: function () {
        $('.save-stock').on('click', function (e) {
            app.stockedit.saveStock();
        });
        $('.navigate-back').on('click', function (e) {
            common.navigateBack();
        });
    },
    getStock: function () {
        var id = getStockId();
        app.service.getStockById(id, assignStock);

        function assignStock(data) {
            app.stockedit.stock(data);
        }

        function getStockId() {
            try
            {
                var url = window.location.href;
                var urlArray = url.split('/');
                return parseInt(urlArray[urlArray.length - 1],10);
            }
            catch(err)
            {
                return 0;
            }
        }
    },
    navigateBack: function(){

    },
    saveStock: function () {
        var stock = app.stockedit.stock();
        app.service.saveStock(stock.ID, stock.Symbol, stock.CompanyName, stock.LastPrice, writeMessage);

        function writeMessage(data) {
            if (data.StatusCode === 200) {
                message.success("Stock successfully saved");
            }
            else {
                message.error("There was an error while saving your stock. Please try again later.")
            }
            
        }
    },
    stock: ko.observable()
};