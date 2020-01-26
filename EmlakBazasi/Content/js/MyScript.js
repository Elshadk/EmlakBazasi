
function deactiveUser(id) {
    data = { "id_user": id };
    $.ajax({
        type: "POST",
        url: "/home/deactiveUser",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $("#successOperationModal").modal('show');

            //  alert("We returned: " + result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}


function blockUser(id) {
    data = { "id_user": id };
    $.ajax({
        type: "POST",
        url: "/home/blockUser",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $("#successOperationModal").modal('show');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}

function activateUser(id) {
    data = { "id_user": id };
    $.ajax({
        type: "POST",
        url: "/home/activateUser",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $("#successOperationModal").modal('show');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}

function changeAsSubscriber(id) {
    data = { "id_user": id };
    $.ajax({
        type: "POST",
        url: "/home/changeAsSubscriber",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $("#successOperationModal").modal('show');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}

function deleteUser(id) {
    data = { "id_user": id };
    $.ajax({
        type: "POST",
        url: "/home/deleteUser",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $("#successOperationModal").modal('show');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}

function addNote() {
    data = { "fk_id_rem_user": $("#userIdForAddNoteID").val(), "note_date": $("#note_dateForAddNote").val(), "note": $("#noteForAddNote").val() };
    $.ajax({
        type: "POST",
        url: "/home/addNote",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $("#successOperationModal").modal('show');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}

function addReminder() {
    data = { "fk_id_rem_user": $("#userIdForAddReminderID").val(), "reminder_date": $("#dateForAddReminder").val(), "note": $("#noteForAddReminder").val() };
    $.ajax({
        type: "POST",
        url: "/home/addReminder",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $("#successOperationModal").modal('show');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}

function deleteReminder(id) {
    data = { "id_user": id };
    $.ajax({
        type: "POST",
        url: "/home/deleteReminder",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $("#successOperationModal").modal('show');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}

function getUserIdForAddNote(userId) {
    $("#userIdForAddNoteID").val(userId);
}

function getUserIdForAddReminder(userId) {
    $("#userIdForAddReminderID").val(userId);
}

function getUserIdForAddPayment(userId) {
    $("#userIdForAddPaymentID").val(userId);
}

function showNote(userId) {
    data = { "id_user": userId };
    $.ajax({
        type: "POST",
        url: "/home/showNote",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            var t = $('#tblShowNotes').DataTable();
            t.clear();
            for (i = 0; i < result.length; i++) {
                t.row.add([
                    i + 1,
                    formatDate(result[i].note_date),
                    result[i].note
                ]).draw(false);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}

function showAllNote() {
    $.ajax({
        type: "POST",
        url: "/home/showAllNote",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            var t = $('#tblAllNoteList').DataTable();
            t.clear();
            for (i = 0; i < result.length; i++) {
                t.row.add([
                    i + 1,
                    result[i].office_name,
                    result[i].full_name,
                    result[i].phone_number,
                    formatDate(result[i].note_date),
                    result[i].note
                ]).draw(false);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}


function showPayment(userId) {
    data = { "id_user": userId };
    $.ajax({
        type: "POST",
        url: "/home/showPayment",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            var t = $('#tblPaymentList').DataTable();
            t.clear();
            for (i = 0; i < result.length; i++) {
                t.row.add([
                    i + 1,
                    formatDate(result[i].payment_date),
                    result[i].sum,
                    result[i].note
                ]).draw(false);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}

function showAllPayment() {
    $.ajax({
        type: "POST",
        url: "/home/showAllPayment",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            var t = $('#tblAllPaymentList').DataTable();
            t.clear();
            for (i = 0; i < result.length; i++) {
                t.row.add([
                    i + 1,
                    result[i].office_name,
                    result[i].full_name,
                    result[i].phone_number,
                    formatDate(result[i].payment_date),
                    result[i].sum,
                    result[i].note
                ]).draw(false);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}

function addPayment() {
    data = { "fk_id_rem_user": $("#userIdForAddPaymentID").val(), "payment_date": $("#dateForAddPayment").val(), "sum": $("#sumForAddPayment").val(), "note": $("#noteForAddPayment").val() };
    $.ajax({
        type: "POST",
        url: "/home/addPayment",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result) {
                $("#successOperationModal").modal('show');
                setInterval(location.reload(), 2000);
            }
            else alert(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}



function changeTag(id) {
    data = { "id_user": id };
    $.ajax({
        type: "POST",
        url: "/home/changeTag",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result) $("#successOperationModal").modal('show');
            else alert(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
    });
}

function clearTag(id) {
    data = { "id_user": id };
    $.ajax({
        type: "POST",
        url: "/home/clearTag",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result) $("#successOperationModal").modal('show');
            else alert(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
    });
}

function clearAllTags() {
    $.ajax({
        type: "POST",
        url: "/home/clearAllTags",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result) $("#successOperationModal").modal('show');
            else alert(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
    });
}

function getInfoForAddUser() {
    $.ajax({
        type: "POST",
        url: "/home/getInfoForAddUser",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {

            for (i = 0; i < result.user_type_list.length; i++) {
                $("#fk_id_rem_user_type_forAddUser").append("<option value='" + result.user_type_list[i].id_rem_user_type + "'>" + result.user_type_list[i].type_name+"</option>")
            }

            for (i = 0; i < result.message_list.length; i++) {
                $("#fk_id_message_type_forAddUser").append("<option value='" + result.message_list[i].id_message_type + "'>" + result.message_list[i].message_code + "</option>")
            }     

            $("#user_forAddUser").val(result.user);

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
    });
}

function addUser() {
    var data = getFormData($("#frmAddUser")); //$("#frmAddUser").serialize();
    $.ajax({
        type: "POST",
        url: "/home/addUser",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result) $("#successOperationModal").modal('show');
            else alert(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
    });
}

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}


function formatDate(item) {
    var date = new Date(parseInt(item.substr(6, 13)));
    var year = "" + date.getFullYear();
    var day = "" + date.getDate();
    var month = "" + (date.getMonth() + 1);
    var hour = "" + date.getHours();
    var minute = "" + date.getMinutes();
    var second = "" + date.getSeconds();
    if (day.length == 1) day = "0" + date.getDate();
    if (month.length == 1) month = "0" + (date.getMonth() + 1);
    if (hour.length == 1) hour = "0" + date.getHours();
    if (minute.length == 1) minute = "0" + date.getMinutes();
    if (second.length == 1) second = "0" + date.getSeconds();

    return [year, month, day].join('-');
}

