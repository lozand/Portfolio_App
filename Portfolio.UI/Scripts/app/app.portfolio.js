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
                app.portfolio.portfolio(data);
            }
        }
    },
    portfolio: ko.observableArray()
};