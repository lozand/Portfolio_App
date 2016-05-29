var app = app || {};

app.portfolio = {
    index: function ($context) {
        app.portfolio.bindControls($context);
        app.portfolio.getPortfolio();
    },
    bindControls: function ($context) {

    },
    getPortfolio: function () {
        app.service.getPortfolio(2, getPortfolioCallback);

        function getPortfolioCallback(data) {
            app.portfolio.portfolio(data);
        }
    },
    portfolio: ko.observableArray()
};