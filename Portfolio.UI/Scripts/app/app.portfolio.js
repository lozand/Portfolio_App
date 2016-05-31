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
            if (!data || data.StatusCode === 500) {
                var msg = data.StatusDescription;
                message.error(msg);
            }
            else {
                app.portfolio.portfolio(data.Folio);
                app.portfolio.availableCash(data.UserCash);
                app.portfolio.portfolioValue(data.FolioValue);
            }
        }
    },
    availableCash: ko.observable(),
    portfolioValue: ko.observable(),
    portfolio: ko.observableArray()
};