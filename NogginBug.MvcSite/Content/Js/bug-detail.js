// Bug detail page actions

// Assign bug action
_dom.findId("Bug_AssignedUser_Id").onchange(function (el) {
    var id = el.data("bugId");
    var assigneeId = el.val();

    _ajax.post("/api/v1/bugs/" + id + "/assign", { id: assigneeId }, function (status, data) {
        if (status == 200) {
            _notify.showSuccess("Bug assigned to " +
                (data.assignedUser ? data.assignedUser.name : "no one"));
        }
        else {
            _notify.showError("Could not assign bug to user");
        }
    });
});

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
