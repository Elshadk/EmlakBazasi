﻿
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

function getSourcesStatistics() {
    $.ajax({
        type: "POST",
        url: "/home/getSourcesStatistics",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            var t = $('#tblSourcesStatistics').DataTable();
            t.clear();
            for (i = 0; i < result.length; i++) {
                t.row.add([
                    result[i].id_source,
                    result[i].source_name,
                    formatDate(result[i].last_reading_date),
                    result[i].last_read_property_type
                ]).draw(false);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
    });
}

function getUserIdForAddNote(userId) {
    $("#userIdForAddNoteID").val(userId);
    $("#noteForAddNote").val("");
}

function getUserIdForAddReminder(userId) {
    $("#userIdForAddReminderID").val(userId);
    $("#noteForAddReminder").val("");
}

function getUserIdForAddPayment(userId) {
    $("#userIdForAddPaymentID").val(userId);
    $("#sumForAddPayment").val("0");
    $("#noteForAddPayment").val("");
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
    $('#frmAddUser').find("input[type=text], textarea, input[type=number]").val("");
    $('#frmAddUser').find("input[type=checkbox]").prop("checked", false);
    $.ajax({
        type: "POST",
        url: "/home/getInfoForAddUser",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {

            for (i = 0; i < result.user_type_list.length; i++) {
                $("#fk_id_rem_user_type_forAddUser").append("<option value='" + result.user_type_list[i].id_rem_user_type + "'>" + result.user_type_list[i].type_name + "</option>")
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


function getUserInfoForUpdateUser(id) {
    data = { "id_user": id };
    $.ajax({
        type: "POST",
        url: "/home/getUserInfoForUpdateUser",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result != null && result != "") {
                $("#id_rem_user_forUpdate").val(result.id_rem_user);
                $("#user_forUpdate").val(result.user);
                $("#full_name_forUpdate").val(result.full_name);
                $("#office_name_forUpdate").val(result.office_name);
                $("#id_rem_user_forUpdate").val(result.id_rem_user);
                $("#reference_forUpdate").val(result.reference);
                $("#service_price_forUpdate").val(result.service_price);
                $("#phone_number_forUpdate").val(result.phone_number);
                $("#phone_number_ex_forUpdate").val(result.phone_number_ex);
                $("#email_address_forUpdate").val(result.email_address);
                $("#start_date_forUpdate").val(formatDate(result.start_date));
                $("#reading_data_count_forUpdate").val(result.reading_data_count);
                $("#last_request_date_forUpdate").val(formatDate(result.last_request_date));
                $("#version_forUpdate").val(result.version);
                $("#note_forUpdate").val(result.note);

                if (result.tag == 1) $("#tag_forUpdate").prop("checked", true);
                if (result.is_active == 1) $("#is_active_forUpdate").prop("checked", true);
                if (result.is_deleted == 1) $("#is_deleted_forUpdate").prop("checked", true);
                if (result.believe == 1) $("#believe_forUpdate").prop("checked", true);
                if (result.subscriber_tag == 1) $("#subscriber_tag_forUpdate").prop("checked", true);


                getUserTypeAndMessageTypeForUpdateUser(result.fk_id_message_type, result.fk_id_rem_user_type);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
    });
}

function getUserTypeAndMessageTypeForUpdateUser(message_type_id, user_type_id) {
    $.ajax({
        type: "POST",
        url: "/home/getUserTypeAndMessageTypeForUpdateUser",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $("#fk_id_rem_user_type_forUpdateUser").empty();
            $("#fk_id_message_type_forUpdateUser").empty();
            for (i = 0; i < result.user_type_list.length; i++) {
                if (result.user_type_list[i].id_rem_user_type == user_type_id) {
                    $("#fk_id_rem_user_type_forUpdateUser").append("<option selected value='" + result.user_type_list[i].id_rem_user_type + "'>" + result.user_type_list[i].type_name + "</option>")
                } else {
                    $("#fk_id_rem_user_type_forUpdateUser").append("<option value='" + result.user_type_list[i].id_rem_user_type + "'>" + result.user_type_list[i].type_name + "</option>")
                }
            }

            for (i = 0; i < result.message_list.length; i++) {
                if (result.message_list[i].id_message_type == message_type_id) {
                    $("#fk_id_message_type_forUpdateUser").append("<option selected value='" + result.message_list[i].id_message_type + "'>" + result.message_list[i].message_code + "</option>")
                } else {
                    $("#fk_id_message_type_forUpdateUser").append("<option value='" + result.message_list[i].id_message_type + "'>" + result.message_list[i].message_code + "</option>")
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
    });
}

function updateUser() {

    $("#tag_forUpdate").is(':checked') ? $("#tag_forUpdate").val("1") : $("#tag_forUpdate").val(0);
    $("#is_active_forUpdate").is(':checked') ? $("#is_active_forUpdate").val("1") : $("#is_active_forUpdate").val("0");
    $("#is_deleted_forUpdate").is(':checked') ? $("#is_deleted_forUpdate").val("1") : $("#is_deleted_forUpdate").val("0");
    $("#subscriber_tag_forUpdate").is(':checked') ? $("#subscriber_tag_forUpdate").val("1") : $("#subscriber_tag_forUpdate").val("0");
    $("#believe_forUpdate").is(':checked') ? $("#believe_forUpdate").val("1") : $("#believe_forUpdate").val("0");
    $("#additional_client_forUpdate").is(':checked') ? $("#additional_client_forUpdate").val("1") : $("#additional_client_forUpdate").val("0");

    var data = getFormData($("#frmUpdateUser"));
    data = { ...data, "id_rem_user": $("#id_rem_user_forUpdate").val() };
    $.ajax({
        type: "POST",
        url: "/home/updateUser",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result) {
                $("#successOperationModal").modal('show');
            }
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

$('#successOperationModal').on('hidden.bs.modal', function () {
    location.reload();
})

var msg01 = "Salam, Əmlak Bazası sisteminin yeni versiyası istifadəyə verilib. Zəhmət olmasa Team Vievver İD və şifər gödnərin, yeni versiyanı sizin komputerlərə yükləyək...";
var msg02 = "Salam, İstifadə etdiyiniz sistemdə yeni elanları oxunması problem mövcuddur. Zəhmət olmasa Team Vievver İD və şifər gödnərin, problemi araşdıraq...";
var msg03 = "Salam, Zəhmət olmasa Əmlak Bazası sisteminin aylıq ödənişlərini ödəyin...";
function sendSMS(phone, type) {

    var url = "";
    phone = phone.substring(10, 1);
    if (type == 1)
        url = "https://api.whatsapp.com/send?phone=994" + phone + "&text=" + msg01 + "&source=&data=";
    else if (type == 2)
        url = "https://api.whatsapp.com/send?phone=994" + phone + "&text=" + msg02 + "&source=&data=";
    else if (type == 3)
        url = "https://api.whatsapp.com/send?phone=994" + phone + "&text=" + msg03 + "&source=&data=";

    window.open(url, '_blank');
}

function sendMessage(user, msisdn, pass, type) {
    var message = "";
    if (type == 2)
        message = msg02;
    else if (type == 3)
        message = msg03;
    window.open("http://emlak-bazasi.com/admin/rem.php?password=" + pass + "&operation=sendsms&user=" + user + "&msisdn=" + msisdn + "&message=" + message, "_blank", "width=500, height=300");
}


