var app = app || {};

app.home = {
    index: function () {
        alert('it worked');
        app.home.loadButtons();
    },
    loadButtons: function () {
        $('.js-say-hi').on('click', function (e) {
            e.preventDefault();
            alert('hi');
        });
    }
};