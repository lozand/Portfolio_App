var app = app || {};

app.home = {
    index: function () {
    },
    loadButtons: function () {
        $('.js-say-hi').on('click', function (e) {
            e.preventDefault();
            
        });
    }
};