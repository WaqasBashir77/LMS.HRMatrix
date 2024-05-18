$.fn.addTimesheetLine = function (e) {
    var rowCount = $('#timeGrid tbody tr').length;
    $.ajax({
        url: "/timesheet/entry/" + rowCount,
        type: "GET"
    }).done(function (result) {
        $('#timeGrid').children('tbody').append(result);
        $.validator.unobtrusive.parse("#popupForm");
        if ($("#nodata").length)
            $("#nodata").remove();
    });
};