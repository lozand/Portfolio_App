var app = app || {};

app.portfolio = {
    index: function ($context) {
        app.portfolio.bindControls($context);
        app.portfolio.getPortfolio();
    },
    bindControls: function ($context) {

    },
    getPortfolio: function () {
        app.service.getPortfolio(getPortfolioCallback);

        function getPortfolioCallback(data) {
            if (!data) {
                message.error();
            }
            else {
                app.portfolio.portfolio(data);
            }
        }
    },
    portfolio: ko.observableArray()
};