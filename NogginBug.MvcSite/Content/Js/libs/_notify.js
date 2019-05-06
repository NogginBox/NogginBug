var _notify = function () {

    var show = function (cssClass) {
        return function (msg) {
            var notification = _dom.create.div(msg, "alert " + cssClass);
            var main = _dom.findId("main").element;
            main.insertBefore(notification.element, main.firstChild);
        };
    };

    return {
        showSuccess: show("alert-success"),
        showError: show("alert-danger")
    }
}();