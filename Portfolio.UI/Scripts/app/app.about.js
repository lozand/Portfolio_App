var app = app || {};

app.about = {
    index: function () {
        app.about.bindControls();
    },
    bindControls: function () {
        $('.add-stock').on('click', function (e) {
            e.preventDefault();
            //$.ajax({
            //    url: '/Home/GetMe',
            //    async: false
            //}).then(function (data) {
            //    $('.message')[0].innerHTML = data;
            //}).done();
            app.service.getMe({}, false, app.about.setMessage);
        });
    },
    setMessage: function (data) {
        $('.message')[0].innerHTML = data;
    }
};