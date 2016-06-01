var toMoney = function (num) {
    return '$' + (num.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,'));
};

var handler = function (element, valueAccessor, allBindings) {
    var $el = $(element);
    var method;

    // Gives us the real value if it is a computed observable or not
    var valueUnwrapped = ko.unwrap(valueAccessor());

    if ($el.is(':input')) {
        method = 'val';
    } else {
        method = 'text';
    }
    return $el[method](toMoney(valueUnwrapped));
};

ko.bindingHandlers.money = {
    update: handler
};