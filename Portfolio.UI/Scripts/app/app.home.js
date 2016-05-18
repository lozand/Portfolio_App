var app = app || {};

app.home = {
    index: function () {
        app.home.bindControls();
    },
    bindControls: function () {
        $('.js-say-hi').on('click', function (e) {
            e.preventDefault();
        });
    }
};