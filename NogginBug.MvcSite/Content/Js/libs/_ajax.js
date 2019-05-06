/*
 * Makes sending AJAX requests a little easier.
 * I wrote this for places.nogginbox.co.uk a personal project I'm experimenting with vanilla JS on
 */
var _ajax = function () {

    var asJson = function (text) {
        if (!text) return null;
        try {
            return JSON.parse(text);
        }
        catch (e) {
            console.log(e);
            return null;
        }
    };

    var ajxDelete = function (url, doneFunc) {
        sendUsing("DELETE", url, doneFunc);
    };

    var ajxGet = function (url, doneFunc) {
        sendUsing("GET", url, doneFunc);
    };

    var ajxPost = function (url, data, doneFunc) {
        var x = new XMLHttpRequest();
        x.open("POST", url, true);
        x.setRequestHeader("Content-Type", "application/json");
        x.onreadystatechange = function () {
            if (this.readyState == 4) {
                doneFunc(this.status, asJson(this.responseText), this);
            }
        };
        var c = JSON.stringify(data);
        x.send(c);
    };

    var sendUsing = function (method, url, doneFunc) {
        var x = new XMLHttpRequest();
        x.open(method, url, true);
        x.onreadystatechange = function () {
            if (this.readyState == 4) {
                doneFunc(this.status, asJson(this.responseText), this);
            }
        };
        x.send();
    };

    return {
        delete: ajxDelete,
        get: ajxGet,
        post: ajxPost
    };
}();