var message = message || {};

message = {
    success: function (text) {
        message.setOptions();
        toastr.success(text);
    },
    error: function (text) {
        var errorText = text || "An error occurred. Please try again later.";
        message.setOptions();
        toastr.error(errorText);
    },
    info: function (text) {
        message.setOptions();
        toastr.info(text);
    },
    warning: function (text) {
        message.setOptions();
        toastr.warning(text);
    },
    setOptions: function () {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-full-width",
            //"positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "slideDown",
            "hideMethod": "fadeOut"
        }
    }
}