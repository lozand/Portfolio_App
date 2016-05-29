﻿var app = app || {};

app.service = {
    _urls: {
        getMe: '/Home/GetMe',
        getStocks: '/Stock/Get',
        getStockById: '/Stock/GetById',
        updateStock: '/Stock/UpdateStock',
        addStock: '/Stock/AddStock',
        getPortfolio: '/Portfolio/GetPortfolio',
        signIn: '/User/SignIn',
        getUser: '/User/GetUser'
    },
    signIn: function (name, callback) {
        var data = { name: name };
        app.service.callController(data, false, callback, app.service._urls.signIn);
    },
    getUser: function(callback){
        app.service.callController({}, false, callback, app.service._urls.getUser);
    },
    getMe: function (data, isAsync, callback) {
        app.service.callController(data, isAsync, callback, app.service._urls.getMe);
    },
    getStocks: function (callback) {
        app.service.callController({}, false, callback, app.service._urls.getStocks);
    },
    getStockById: function(callback){
        app.service.callController({}, false, callback, app.service._urls.getStockById);
    },
    getPortfolio: function(callback){
        app.service.callController({}, false, callback, app.service._urls.getPortfolio)
    },
    updateStock: function(id, symbol, companyName, price, callback){
        var data = { id: id, symbol: symbol, companyName: companyName, price: price };
        app.service.callController(data, false, callback, app.service._urls.updateStock);
    },
    addStock: function (symbol, companyName, price, callback) {
        var data = { symbol: symbol, companyName: companyName, price: price };
        app.service.callController(data, false, callback, app.service._urls.addStock);
    },
    callController: function (data, isAsync, callback, url) {
        $.ajax({
            url: url,
            async: isAsync,
            data: data,
            cache: false,
            error: function (xhr, ajaxOptions, thrownError) {
                message.error(thrownError + '. Please try again later.');
            }
        }).then(function (data) {
            if (callback) {
                callback(data);
            }
        }).done();
    }
};