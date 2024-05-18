$(function () {

    // Default initialization
    $('.select').select2({
        minimumResultsForSearch: Infinity
    });

    // Select with search
    $('.select-search').select2();

    $('.select-multiple').select2({
        dropdownCssClass: 'border-primary',
        containerCssClass: 'border-primary text-primary-700'
    });

    $(".styled, .multiselect-container input").uniform({
        radioClass: 'choice'
    }); 

    $("#notificationBox").fadeIn(1000);
    if ($("#notificationAutoHide").val() === "true") {
        $("#notificationBox").delay(5000).slideToggle(1000);
    }

    $('td').find('.icons-list').hide();

    $("table tr").hover(function () {
        $(this).find('.icons-list').toggle();
    }, function () {
        $(this).find('.icons-list').toggle();
    });

    $("i.icon-trash").click(function (e) {
        e.preventDefault();
        var linkURL = $(this).parent().attr('href');
        swal({
            title: 'Are you sure you want to delete?',
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
                window.location.href = linkURL;
                return true;
            } else {
                return false;
            }
        });
    });
});


function getQueryStringValue(key) {
    key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + key + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return results[1];
}

function trim(inputString) {
    // Check for all whitespace
    if (isAllSpaces(inputString)) {
        return "";
    }

    // Removes leading and trailing spaces from the passed string.
    var retValue = inputString;
    retValue = retValue.replace(/^(\s+)?(.*\S)(\s+)?$/, '$2');
    return retValue; // Return the trimmed string back to the user
}

// Return true if the string contains just spaces or is empty
function isAllSpaces(inputValue) {
    if (inputValue.search(/^\s*$/) != -1)
        return true;
    else
        return false;
}


//Check is string null or empty
$.fn.isStringNullOrEmpty = function (val) {
    switch (val) {
        case "":
        case 0:
        case "0":
        case null:
        case false:
        case undefined:
        case typeof this === 'undefined':
            return true;
        default: return false;
    }
}

//Check is string null or whitespace
$.fn.isStringNullOrWhiteSpace = function (val) {
    return this.isStringNullOrEmpty(val) || val.replace(/\s/g, "") === '';
}

//If string is null or empty then return Null or else original value
$.fn.nullIfStringNullOrEmpty = function (val) {
    if (this.isStringNullOrEmpty(val)) {
        return null;
    }
    return val;
}

$.fn.fillAddress = function (e) {
    var locationId = $(e).val();
    $.ajax({
        url: '/JobOpenings/GetLocation',
        type: "GET",
        dataType: "JSON",
        data: { id: locationId },
        success: function (location) {
            $("#Street").val(location.Street);
            $("#City").val(location.City);
            $("#State").val(location.State);
            $("#ZipCode").val(location.Zip);
            $('#CountryId').val(location.CountryId);
        }
    });
};

$.fn.setJobCandidateStatus = function (input) {
    $.ajax({
        url: '/jobopenings/jobCandidateStatus',
        type: "POST",
        dataType: "JSON",
        data: { id: $(input).data("id"), statusId: $(input).data("status-value") },
        success: function (data) {
            $(input).parent("li").parents("li").children("a:first").children("span:first").text($(input).text())
        }
    });
};