
function deactiveUser(id) {
    data = { "id_user": id };
    $.ajax({
        type: "POST",
        url: "/home/deactiveUser",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            alert("We returned: " + result);
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
            alert("We returned: " + result);
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
            alert("We returned: " + result);
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
            alert("We returned: " + result);
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
            alert("We returned: " + result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },

    });
}
