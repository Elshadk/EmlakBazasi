// Call the dataTables jQuery plugin
$(document).ready(function() {
  $('#dataTable').DataTable();
});

$(document).ready(function () {
    $('#tblAllNoteList').DataTable({
        "lengthMenu": [[5,10, 25, 50, 100], [5,10, 25, 50, 100]]
    });
});

$(document).ready(function () {
    $('#tblNotesList').DataTable({
        "lengthMenu": [[5, 10, 25, 50, 100], [5, 10, 25, 50, 100]]
    });
});

$(document).ready(function () {
    $('#tblShowNotes').DataTable({
        "lengthMenu": [[5, 10, 25, 50, 100], [5, 10, 25, 50, 100]]
    });
});


$(document).ready(function () {
    $('#tblAllPaymentList').DataTable({
        "lengthMenu": [[5, 10, 25, 50, 100], [5, 10, 25, 50, 100]]
    });
});

$(document).ready(function () {
    $('#tblPaymentList').DataTable({
        "lengthMenu": [[5, 10, 25, 50, 100], [5, 10, 25, 50, 100]]
    });
});
