// Bug detail page actions

// Close bug action
_dom.findId("action-close").onclick(function (el) {

    var id = el.data("bugId");
    _ajax.post("/api/v1/bugs/" + id + "/close", {}, function (status, data) {
        if (status == 200) {
            _notify.showSuccess("Bug closed");
            _dom.findId("bug-status").element.textContent = "(" + data.status + ")";
            el.classAdd("hide");
        }
        else {
            _notify.showError("Could not close bug due to error");
        }
    });
});
