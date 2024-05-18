function EditCustomField(url) {
    $.ajax({
        type: 'POST',
        url: url,
        success: function (data) {
            if (data != null) {
                abc = jQuery.makeArray(data);
                $('#CustomFiledKeyId1').val(abc[0]);
                $('#Name1').val(abc[1]);
                $('#type1').val(abc[2]);
                $('#DefaultValue1').val(abc[3]);
                $('#MinValue1').val(abc[4]);
                $('#MaxValue1').val(abc[5]);
               
            }
            else {
                alert("Error!" + response.message + "error");
            }
        }
    });
};
function AddValuesToField(id) {
    $('#CustomFieldKeyId').val(id);
};
function DeleteCustomField(url) {
    $.ajax({
        type: 'POST',
        url: url,
        success: function (data) {
            if (data === "True") {
                swal("Success!", "Data is deleted", "Success");
                location.reload();
            }
            else {
                swal("Error!" ,"Data is not  deleted", "error");
            }
        }
    });
};
$(function () {
    $("#btnAddCustomField1").click(function () {
      
        if ($.trim($('#CustomFiledKeyId1').val()).length > 0) {
            AssignAndRemoveBorderClass('CustomFiledKeyId1', 1);
        } else if ($.trim($('#Name1').val()).length > 0) {
            AssignAndRemoveBorderClass('Name1', 1);
        } else if ($.trim($('#type1').val()).length > 0) {
            var Id = 'type1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#DefaultValue1').val()).length > 0) {
            var Id = 'DefaultValue1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#MinValue1').val()).length > 0) {
            var Id = 'MinValue1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#MaxValue1').val()).length > 0) {
            var Id = 'MaxValue1';
            AssignAndRemoveBorderClass(Id, 1);
        }
        var verified = true;
        if ($.trim($('#Name1').val()).length < 1) {
            verified = false;
            var Id = 'Name1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#CustomFiledKeyId1').val()).length < 1) {
            verified = false;
            var Id = 'CustomFiledKeyId1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#type1').val()).length < 1) {
            verified = false;
            var Id = 'type1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#DefaultValue1').val()).length < 1) {
            verified = false;
            var Id = 'DefaultValue1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#MinValue1').val()).length < 1) {
            verified = false;
            var Id = 'MinValue1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#MaxValue1').val()).length < 1) {
            verified = false;
            var Id = 'MinValue1';
            AssignAndRemoveBorderClass(Id, 0);
        }
        if (verified === true) {
            var data = new FormData();
            var $inputs = $('#CustomFiledKeyFormEdit input');
            var values = {};
            $inputs.each(function () {
                data.append(values[this.name] = $(this).attr('name'), values[this.name] = $(this).val());
             });
            $.ajax({
                type: "POST",
                url: "/CustomFieldKey/UpdateCustomFieldKey",
                data: data,
                contentType: false, 
                processData: false,
                success: function (data) {
                    if (data === "True") {
                        swal("Success", "Data is updated", "success"); 
                            location.reload();
                    }
                    else {
                        swal("Error!", "Your data is no added!", "error");
                    }
                }
            });
        }
    });
});
$(function () {
    $("#btnAddCustomField").click(function () {
        if ($.trim($('#Name').val()).length > 0) {
            AssignAndRemoveBorderClass('Name', 1);
        } else if ($.trim($('#type').val()).length > 0) {
            var Id = 'type';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#DefaultValue').val()).length > 0) {
            var Id = 'DefaultValue';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#MinValue').val()).length > 0) {
            var Id = 'MinValue';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#MaxValue').val()).length > 0) {
            var Id = 'MaxValue';
            AssignAndRemoveBorderClass(Id, 1);
        } 
        var verified = true;
        if ($.trim($('#Name').val()).length < 1) {
            verified = false;
            var Id = 'Name';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#type').val()).length < 1) {
            verified = false;
            var Id = 'type';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#DefaultValue').val()).length < 1) {
            verified = false;
            var Id = 'DefaultValue';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#MinValue').val()).length < 1) {
            verified = false;
            var Id = 'MinValue';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#MaxValue').val()).length < 1) {
            verified = false;
            var Id = 'MinValue';
            AssignAndRemoveBorderClass(Id, 0);
        } 
        if (verified === true) {
             var data = new FormData();
            var $inputs = $('#btnAddCustomFieldForm input');
            var values = {};
            $inputs.each(function () {
               data.append(values[this.name] = $(this).attr('name'), values[this.name] = $(this).val());
             });
           $.ajax({
                type: "POST",
                url: "/CustomFieldKey/AddFieldKey",
                    data: data,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data === "true") {
                        swal("Success", "Data Added", "success");//.then(function (isConfirm) {
                        location.reload();
                    }
                    else {
                        swal("Error!", "Your data is no added!", "error");
                    }
                }
            });
        }
    });
});
$(function () {
    $("#btnAddCustomFieldValue").click(function () {
        if ($.trim($('#CustomFieldKeyId').val()).length > 0) {
            AssignAndRemoveBorderClass('CustomFieldKeyId', 1);
        } else if ($.trim($('#Value').val()).length > 0) {
            AssignAndRemoveBorderClass('Value', 1);
        }
        var verified = true;
        if ($.trim($('#Value').val()).length < 1) {
            verified = false;
            var Id = 'Value';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#CustomFieldKeyId').val()).length < 1) {
            verified = false;
            var Id = 'CustomFieldKeyId';
            AssignAndRemoveBorderClass(Id, 0);
        } 
        if (verified === true) {
            var data = new FormData();
            var $inputs = $('#CustomFiledKeyFormAddValue input');
            var values = {};
            $inputs.each(function () {
                data.append(values[this.name] = $(this).attr('name'), values[this.name] = $(this).val());
            });
            $.ajax({
                type: "POST",
                url: "/CustomFieldKey/AddFieldKeyValues",
                data: data,
                contentType: false, 
                processData: false,
                success: function (data) {
                    if (data === "true") {
                        swal("Success", "Data Added", "success");//.then(function (isConfirm) {
                            location.reload();
                        
                    }
                    else {
                        swal("Error!", "Your data is no added!", "error");
                    }
                }
            });
        }
    });
});
function AssignAndRemoveBorderClass(InputFieldId, AssignId) {
    if (AssignId == 1) {
        ////////assignClass
        $('#' + InputFieldId + '').addClass('border-primary');
        $('#' + InputFieldId + '').removeClass('border-danger');
    } else if (AssignId == 0) {
        ////RemoveClass
        $('#' + InputFieldId + '').removeClass('border-primary');
        $('#' + InputFieldId + '').addClass('border-danger');
    }
}