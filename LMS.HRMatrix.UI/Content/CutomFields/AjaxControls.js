function EditModal(url) {
    $.ajax({
        type: 'POST',
        url: url,
        success: function (data) {
            if (data != null) {

                abc = jQuery.makeArray(data);

                $('#usridd').val(abc[0]);
                $('#userFname').val(abc[1]);
                $('#userLnames').val(abc[2]);
                $('#userUname').val(abc[3]);
                $('#userPass').val(abc[4]);
                $('#userEmail').val(abc[5]);
                $('#userContact').val(abc[6]);

            }

            else {
                //$.notify(response.message, "error");
                swal("Error!", response.message, "error");
            }
        }
    });
};
function EditEmployeeid(url) {
    $.ajax({
        type: 'POST',
        url: url,
        success: function (data) {
            if (data != null) {
                abc = jQuery.makeArray(data);
                $('#Id').val(abc[0]);
                $('#OrganizationID').val(abc[1]);
                $('#OnboardingID').val(abc[2]);
                $('#Salutation').val(abc[3]);
                $('#FirstName').val(abc[4]);
                $('#MiddleName').val(abc[5]);
                $('#LastName').val(abc[6]);
                $('#NickName').val(abc[7]);
                $('#DisplayName').val(abc[8]);
                $('#PersonNumber').val(abc[9]);
                $('#WorkingEmail').val(abc[10]);
            }
            else {
                alert("Error!" + response.message + "error");
            }
        }
    });
};
$(function () {

    $("#btnEmployeeUpdate").click(function () {

        if ($.trim($('#Id').val()).length > 0) {
            var Id = 'Id';
            AssignAndRemoveBorderClass(Id, 1);
        }
        else if ($.trim($('#OrganizationID').val()).length > 0) {
            var Id = 'OrganizationID';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#OnboardingID').val()).length > 0) {
            var Id = 'OnboardingID';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#Salutation').val()).length > 0) {
            var Id = 'Salutation';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#FirstName').val()).length > 0) {
            var Id = 'FirstName';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#MiddleName').val()).length > 0) {
            var Id = 'MiddleName';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#LastName').val()).length > 0) {
            var Id = 'LastName';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#NickName').val()).length > 0) {
            var Id = 'NickName';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#DisplayName').val()).length > 0) {
            var Id = 'DisplayName';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#PersonNumber').val()).length > 0) {
            var Id = 'PersonNumber';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#WorkingEmail').val()).length > 0) {
            var Id = 'WorkingEmail';
            AssignAndRemoveBorderClass(Id, 1);
        } else {

        }
        var verified = true;
        if ($.trim($('#Id').val()).length < 1) {
            verified = false;
            var Id = 'Id';
            AssignAndRemoveBorderClass(Id, 0);
        }
        else if ($.trim($('#OrganizationID').val()).length < 1) {
            verified = false;
            var Id = 'OrganizationID';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#OnboardingID').val()).length < 1) {
            verified = false;
            var Id = 'OnboardingID';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#Salutation').val()).length < 1) {
            verified = false;
            var Id = 'Salutation';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#FirstName').val()).length < 1) {
            verified = false;
            var Id = 'FirstName';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#MiddleName').val()).length < 1) {
            verified = false;
            var Id = 'MiddleName';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#LastName').val()).length < 1) {
            verified = false;
            var Id = 'LastName';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#NickName').val()).length < 1) {
            verified = false;
            var Id = 'NickName';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#DisplayName').val()).length < 1) {
            verified = false;
            var Id = 'DisplayName';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#PersonNumber').val()).length < 1) {
            verified = false;
            var Id = 'PersonNumber';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#WorkingEmail').val()).length < 1) {
            verified = false;
            var Id = 'WorkingEmail';
            AssignAndRemoveBorderClass(Id, 0);
        }
        if (verified === true) {

            var $inputs = $('#myForm input');
            var values = {};
            var DictionaryData = {};
            var i = 0;
            $inputs.each(function () {
                DictionaryData['myDictionary[' + i + '].Key'] = values[this.name] = $(this).attr('id');
                DictionaryData['myDictionary[' + i + '].Value'] = values[this.name] = $(this).val();
                i++;
            });
            var data = new FormData();
            data.append("Id", $("#Id").val());
            data.append("OrganizationID", $("#OrganizationID").val());
            data.append("OnboardingID", $("#OnboardingID").val());
            data.append("Salutation", $("#Salutation").val());
            data.append("FirstName", $("#FirstName").val());
            data.append("MiddleName", $("#MiddleName").val());
            data.append("LastName", $("#LastName").val());
            data.append("NickName", $("#NickName").val());
            data.append("DisplayName", $("#DisplayName").val());
            data.append("PersonNumber", $("#PersonNumber").val());
            data.append("WorkEmail", $("#WorkingEmail").val());

            $.ajax({
                type: "POST",
                url: "/Employee/UpdateEmployee",
                data: JSON.stringify({
                    'employeeViewModel': data,
                    'DictionaryData': DictionaryData
                }),
             
                contentType: false, // Not to set any content header  
                processData: false,
                success: function (data) {
                    if ("True" === data) {
                        swal("Good job!", "Your data is Updated!", "success");
                        location.reload();
                    }
                    else {
                        swal("Error!", "Your data is not Updated!", "error");

                    }
                }

            });
        }

    });
});
function DeleteEmployeeid(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    })
        .then((willDelete) => {

            if (willDelete) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    success: function (response) {

                        if (response === "True") {
                            swal("Good job!", "Your data is Deleted!", "success");
                            location.reload();
                        }
                        else {
                            swal("Error!", response.message, "error");
                        }
                    }
                });
            } else {
                swal("Your imaginary data is safe!");
            }
        });


};
/*$(function () {

    $("#btnAddEmployee").click(function () {

        if ($.trim($('#OrganizationID1').val()).length > 0) {
            AssignAndRemoveBorderClass('OrganizationID1', 1);
        } else if ($.trim($('#OnboardingID1').val()).length > 0) {
            var Id = 'OnboardingID1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#Salutation1').val()).length > 0) {
            var Id = 'Salutation1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#FirstName1').val()).length > 0) {
            var Id = 'FirstName1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#MiddleName1').val()).length > 0) {
            var Id = 'MiddleName1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#LastName1').val()).length > 0) {
            var Id = 'LastName1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#NickName1').val()).length > 0) {
            var Id = 'NickName1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#DisplayName1').val()).length > 0) {
            var Id = 'DisplayName1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#PersonNumber1').val()).length > 0) {
            var Id = 'PersonNumber1';
            AssignAndRemoveBorderClass(Id, 1);
        } else if ($.trim($('#WorkingEmail1').val()).length > 0) {
            var Id = 'WorkingEmail1';
            AssignAndRemoveBorderClass(Id, 1);
        } else {

        }
        var verified = true;
        if ($.trim($('#OrganizationID1').val()).length < 1) {
            verified = false;
            var Id = 'OrganizationID1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#OnboardingID1').val()).length < 1) {
            verified = false;
            var Id = 'OnboardingID1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#Salutation1').val()).length < 1) {
            verified = false;
            var Id = 'Salutation1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#FirstName1').val()).length < 1) {
            verified = false;
            var Id = 'FirstName1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#MiddleName1').val()).length < 1) {
            verified = false;
            var Id = 'MiddleName1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#LastName1').val()).length < 1) {
            verified = false;
            var Id = 'LastName1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#NickName1').val()).length < 1) {
            verified = false;
            var Id = 'NickName1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#DisplayName1').val()).length < 1) {
            verified = false;
            var Id = 'DisplayName1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#PersonNumber1').val()).length < 1) {
            verified = false;
            var Id = 'PersonNumber1';
            AssignAndRemoveBorderClass(Id, 0);
        } else if ($.trim($('#WorkingEmail1').val()).length < 1) {
            verified = false;
            var Id = 'WorkingEmail1';
            AssignAndRemoveBorderClass(Id, 0);
        }
        if (verified === true) {
            var data = new FormData();
            var $inputs = $('#AddEmployeeModel input');
            var values = {};
            var employee = {
                OnboardingID: 1,
                Salutation: 1,
                FirstName: 'hello',
                MiddleName: 'abcd',
                LastName: 'kjasd',
                NickName: 'hafh',
                DisplayName: 'jhkfas',
                PersonNumber: '7824578',
                WorkEmail: 'wjkela@h.com'
            };
            var IDictionaryData = {};
            var i = 0;
            var test = "[{";
            $inputs.each(function () {
                IDictionaryData['myDictionary[' + i + '].Key'] = values[this.name] = $(this).attr('name');
                IDictionaryData['myDictionary[' + i + '].Value'] = values[this.name] = $(this).val();
                data.append(values[this.name] = $(this).attr('name'), values[this.name] = $(this).val());
                var a = values[this.name] = $(this).attr('name');
                var b = values[this.name] = $(this).val();
                /*if (i == 0) {
                    if (isNaN(b)) {
                        test += a + ":'" + b + "'";
                    } else {
                        
                        test += a + ":" + b;
                    }
                }
                else {
                    if (isNaN(b)) {
                        test += "," + a + ":'" + b + "'";
                        
                    } else {
                        test += "," + a + ":" + b;
                    }
                }
                #1#

                i++;
            });
            var SendObject = {
                employee: employee,   //loginModel same name as in Modal
                CustomField: DictionaryData  //registerModel same name as in Modal
            }

          $.ajax({
                type: "POST",
              url: "/Employee/FormSubmit",
               dataType: 'json',
              data: IDictionaryData,
                
                success: function (data) {
                    if (data === "true") {
                        swal({
                            title: "Success",
                            text: "Data is entered",
                            icon: "success",
                            buttons: [
                                'OK'
                            ],
                            dangerMode: false
                        }).then(function (isConfirm) {
                            location.reload();
                        });
                    }
                    else {
                        swal("Error!", "Your data is no added!", "error");
                    }
                }
            });
        }
    });
});*/
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
function PostEmailList() {
    var $inputs = $('#myForm input');
    var values = {};
    var finalData = {};
    var i = 0;
    $inputs.each(function () {
        // alert(values[this.name] = $(this).val() + $(this).attr('id'));
        finalData['myDictionary[' + i + '].Key'] = values[this.name] = $(this).attr('id');
        finalData['myDictionary[' + i + '].Value'] = values[this.name] = $(this).val();
        i++;

    });
    var x = document.getElementById("myForm");
    for (i = 0; i < x.length; i++) {
        finalData['myDictionary[' + i + '].Key'] = x.options[i].text;
        finalData['myDictionary[' + i + '].Value'] = parseInt(x.options[i].value);
    }
    $.ajax({
        url: '/Employee/FormSubmit',
        type: 'POST',
        data: DictionaryData,

        success: function (data) {

            swal("Good job!", "Your data is Added!", "success");
            location.reload();
            //$("#EmailList").html($("#EmailList").html() + data);
        }
    })
    return false;
};

$("#Save").on('click', function (e) {
    var queryName = $.trim($('#QueryName').val());
    if (queryName.length <= 0) {
        alert("Enter Query Name");
        return;
    }
    var i = true;
    var obj = "";
    $("#sortable-list-basic li").each(function () {
        var value = $(this).attr("value");
        var alias = $(this).find('p').text();
        if (!($("#" + value).length >= 1)) {
            if (i) {
                obj += '{ "value" : "' + value + '", "alias" : "' + alias + '"} ';
                i = false;
            } else {
                obj += "," + '{ "value" : "' + value + '", "alias" : "' + alias + '"} ';
            }
        }

    });
    var customize = $.parseJSON('[' + obj + ']');
    var obj1 = "";
    i = true;
    $("#js-columns .active").each(function () {
        var value = $(this).attr("value");
        var alias = $(this).text();
        if (i) {
            obj1 += '{ "value" : "' + value + '", "alias" : "' + alias + '"} ';
            i = false;
        } else {
            obj1 += "," + '{ "value" : "' + value + '", "alias" : "' + alias + '"} ';
        }
    });
    var selected = $.parseJSON('[' + obj1 + ']');
    //selected = JSON.stringify({ 'selected': selected });
    var entity = $("#js-columns .row h4:first").text();
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: '/Query/SaveSectedColumn',
        data: '{queryName:"' + queryName + '",entity:"' + entity + '",customize:' + JSON.stringify(customize) + ',selected:' + JSON.stringify(selected) + '}',
        success: function () {

        },
        failure: function (response) {
            alert(response);
        }
    });
});