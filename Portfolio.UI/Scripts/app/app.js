var app = app || {};
(function () {
    var container = $('.content-container')[0];
    var vmName = container.id;
    var vmToRun = 'app.' + vmName + '.index()';
    eval(vmToRun);
})();