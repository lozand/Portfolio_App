var app = app || {};
app.util = app.util || {};
app.util = {
    init: function ($context) {
        var container = $('.content-container')[0];
        var vmName = container.id;
        app[vmName].index();
    }
};

$(function () {
    app.util.init($('body'));
});