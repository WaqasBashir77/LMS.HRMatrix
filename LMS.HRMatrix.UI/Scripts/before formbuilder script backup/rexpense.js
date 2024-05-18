$("#addProject").click(function () {
    var rowCount = $('.table').rowCount();
    $.ajax({
        url: "/expenses/entries/" + rowCount,
        type: "GET"
    }).done(function (result) {
        $("#expense").append(result);
    });
});

$(".addExpenseLine").click(function () {

});

$('ul').on('click', 'a.expenseProject', function () {
    $.fn.getProject(this);
});

$.fn.getProject = function (e) {
    $(e).parents('div').children('a').find('.text-semibold').text($(e).text());
    $(e).parents('div').siblings('table').find("input[id*='expenseProject_']:hidden").val($(e).data("value"));
}

$.fn.rowCount = function () {
    return $(this).children("tbody").children("tr").length;
};

$.fn.addExpenseLine = function (e) {
    var rowCount = $('.table').rowCount();
    var _p = $(e).parents('div.panel').children('table').children('tbody').find("input[id*='expenseProject_']:hidden").val();
    if ($.fn.isAllSpaces(_p))
        _p = 0;
    $.ajax({
        url: "/expenses/_add/" + rowCount + "/?project=" + _p,
        type: "GET"
    }).done(function (result) {
        $(e).parents('div.panel').children('table').children('tbody').append(result);
    });
}

$.fn.deleteExpenseLine = function (line) {
    swal({
        title: 'Are you sure you want to delete this line?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#ff7043',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger',
        buttonsStyling: false
    }, function (isConfirm) {
        if (isConfirm) {
            var e = $("#deletedExpenseLine_" + line);
            $(e).val("True");
            $(e).parents('tr').hide();
        } else {
            return false;
        }
    });
}

$.fn.deleteAllExpenseLine = function (element) {

    swal({
        title: 'Are you sure you want to delete all expenses for the project: "< None >"?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#ff7043',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger',
        buttonsStyling: false
    }, function (isConfirm) {
        if (isConfirm) {
            $(element).parents('.panel-footer').siblings('table').children('tbody').find("input[id*='deletedExpenseLine_']:hidden").val('True');
            $(element).parents('.panel').hide();
        } else {
            return false;
        }
    });
}

$.fn.isAllSpaces = function (inputValue) {
    if (inputValue.search(/^\s*$/) != -1)
        return true;
    else
        return false;
}

$.fn.expenseTypeOnChange = function (e) {
    var expenseTypeId = $(e).val();
    $.ajax({
        url: '/Expenses/GetExpenseType',
        type: "GET",
        dataType: "JSON",
        data: { id: expenseTypeId },
        success: function (expenseType) {
            alert(expenseType.IsRate);
        }
    });
}

$.fn.editExpenseLine = function (index) {
    alert($("select[name='expenseType_" + index + "']").val());
    $("#date").val($("input[name='date_" + index + "']").val());
    $("#description").val($("input[name='description_" + index + "']").val());
    $("#expenseType").select2().select2('val', $("select[name='expenseType_" + index + "']").val());
    $('#inlinePopup').modal()
}