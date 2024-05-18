/*/*var fbEditor = document.getElementById('build-wrap');
var formBuilder = $(fbEditor).formBuilder();

var buttons = document.getElementsByClassName('addFieldBtn');
for (var i = 0; i < buttons.length; i++) {
    buttons[i].onclick = function () {
        var field = {
            type: 'text',
            class: 'form-control',
            label: this.dataset.label + ' added at: ' + new Date().getTime()
        };
        var index = this.dataset.index ? Number(this.dataset.index) : undefined;

        formBuilder.actions.addField(field, index);
    };
}#1#
jQuery(function ($) {
    var $fbEditor = $(document.getElementById('fb-editor')),
        $formContainer = $(document.getElementById('fb-rendered-form')),
        fbOptions = {
            onSave: function () {
                $fbEditor.toggle();
                $formContainer.toggle();
                $('form', $formContainer).formRender({
                    formData: formBuilder.formData
                });
            }
        },
        formBuilder = $fbEditor.formBuilder(fbOptions);

    $('.edit-form', $formContainer).click(function () {
        $fbEditor.toggle();
        $formContainer.toggle();
    });
});
 /*fbEditor = document.getElementById('build-wrap');
formData = JSON.stringify([
    {
        type: 'header',
        subtype: 'h1',
        label: 'Header',
    },
    {
        type: 'paragraph',
        subtype: 'p',
        label: 'Lots of text goes here',
    },
]);
formBuilder = $(fbEditor).formBuilder({ formData });

// Can be used 2 different ways
formBuilder.actions.toggleAllFieldEdit();// first
$(fbEditor).formBuilder('toggleAllFieldEdit'); // second#1#*/
/*var getUserDataBtn = document.getElementById("get-user-data");
var fbRender = document.getElementById("fb-render");
var originalFormData = [
    {
        type: "text",
        label: "Text Field",
        className: "form-control",
        name: "text-1478701075825"
    },
    {
        type: "checkbox-group",
        label: "Checkbox Group",
        className: "checkbox-group",
        name: "checkbox-group-1478704652409",
        values: [
            {
                label: "Option 1",
                value: "option-1",
                selected: true
            },
            {
                label: "Option 2",
                value: "option-2"
            },
            {
                label: "Option 3",
                value: "option-3",
                selected: true
            }
        ]
    },
    {
        type: "select",
        label: "Select",
        className: "form-control",
        name: "select-1478701076382",
        values: [
            {
                label: "Option 1",
                value: "option-1",
                selected: true
            },
            {
                label: "Option 2",
                value: "option-2"
            },
            {
                label: "Option 3",
                value: "option-3"
            }
        ]
    },
    {
        type: "textarea",
        label: "Text Area",
        className: "form-control",
        name: "textarea-1478701077511"
    }
];
jQuery(function ($) {
    var formData = JSON.stringify(originalFormData);

    $(fbRender).formRender({ formData });
    getUserDataBtn.addEventListener(
        "click",
        () => {
            window.alert(window.JSON.stringify($(fbRender).formRender("userData")));
        },
        false
    );
});*/
jQuery(function ($) {
    $(document.getElementById('fb-editor')).formBuilder();
    var fbEditor = document.getElementById("fb-editor");

    $("#saveData").click(function () {
        var fbEditor = formBuilder.actions.save();//document.getElementById("fb-editor");
        alert(fbEditor);
    });
    var fbEditor = document.getElementById('build-wrap');
    var formBuilder = $(fbEditor).formBuilder();

    //document.getElementById('getXML').addEventListener('click', function () {
    //    alert(formBuilder.actions.getData('xml'));
    //});
    document.getElementById('getJSON').addEventListener('click', function () {
        var formjson = formBuilder.actions.getData('json', true);
        var yourString = "/installers/";
        var result = yourString.substring(1, yourString.length - 1);
        obj = JSON.parse(formjson);
        console.log(result);
        var originalFormData = obj;/*
            [
        {
            "type": "autocomplete",
                "label": "Autocomplete",
                "className": "form-control",
                "name": "autocomplete-1549359929978",
                "values": [
                {
                    "label": "Option 1",
                    "value": "option-1"
                },{
                    "label": "Option 2",
                    "value": "option-2"
                },{
                    "label": "Option 3",
                    "value": "option-3"
                }
            ]
        },{
            "type": "button",
                "label": "Button",
                "subtype": "button",
                "name": "button-1549359930822"
        },{
            "type": "checkbox-group",
                "label": "Checkbox Group",
                "name": "checkbox-group-1549359931774",
                "values": [
                {
                    "label": "Option 1",
                    "value": "option-1",
                    "selected": true
                }
            ]
        },{
            "type": "date",
                "label": "Date Field",
                "className": "form-control",
                "name": "date-1549359932790"
        },{
            "type": "header",
                "subtype": "h1",
                "label": "Header"
        },{
            "type": "hidden",
                "name": "hidden-1549359934518"
        }
        ];*/
    //formBuilder.actions.getData('json', true);
        //alert(formBuilder.actions.getData('json', true));
         /*[{
            "type": "text",
            "required": true,
            "label": "What is the company Domain ?",
            "subtype": "text",
            "placeholder": "www.example.com",
            "className": "form-control",
            "name": "domain"
        }, {
            "type": "text",
            "required": true,
            "label": "What is the company Name ?",
            "subtype": "text",
            "placeholder": "Eg : coMakeIT",
            "className": "form-control",
            "name": "name"
        }, {
            "type": "textarea",
            "required": true,
            "label": "What is the customers challenge?",
            "className": "form-control",
            "name": "prospects"
        }, {
            "type": "select",
            "label": "What industry do they belong to ?",
            "className": "form-control",
            "name": "industry",
            "values": [{
                "label": "Accounting",
                "value": "Accounting",
                "selected": true
            }, {
                "label": "Airlines/Aviation",
                "value": "Airlines/Aviation"
            }, {
                "label": "Alternative Dispute Resolution",
                "value": "Alternative Dispute Resolution"
            }]
        }, {
            "type": "text",
            "required": true,
            "label": "What's the contact name?",
            "subtype": "text",
            "className": "form-control",
            "name": "contact"
        }, {
            "type": "select",
            "label": "Designation of the prospect",
            "className": "form-control",
            "name": "designation",
            "values": [{
                "label": "Founder",
                "value": "Founder",
                "selected": true
            }, {
                "label": "CXO",
                "value": "CXO"
            }, {
                "label": "Director",
                "value": "Director"
            }, {
                "label": "VP",
                "value": "VP"
            }, {
                "label": "Manager",
                "value": "Manager"
            }, {
                "label": "Other",
                "value": "new"
            }]
        }, {
            "type": "select",
            "label": "What form of content can solve this challenge?",
            "className": "form-control",
            "name": "challenge",
            "multiple": true,
            "values": [{
                "label": "Presentation",
                "value": "1",
                "selected": true
            }, {
                "label": "Blog",
                "value": "2"
            }, {
                "label": "Infographics",
                "value": "3"
            }]
        }, {
            "type": "file",
            "label": "Do you have a call recording ?",
            "className": "form-control",
            "name": "callrecording"
        }, {
            "type": "select",
            "label": "How fast do you want marketing to act on this?",
            "className": "form-control",
            "name": "priority",
            "values": [{
                "label": "High Priority",
                "value": "1",
                "selected": true
            }, {
                "label": "Low Priority",
                "value": "2"
            }, {
                "label": "Information",
                "value": "3"
            }]
        }, {
            "type": "select",
            "label": "How many days",
            "className": "form-control",
            "name": "days",
            "values": [{
                "label": "1 Days",
                "value": "1",
                "selected": true
            }, {
                "label": "2 Days",
                "value": "2"
            }, {
                "label": "3 Days",
                "value": "3"
            }]
        }, {
            "type": "hidden",
            "label": "Task",
            "className": "hidden-input",
            "name": "task",
            "value": "3"
        }, {
            "type": "hidden",
            "label": "CRM",
            "className": "hidden-input",
            "name": "crmid",
            "value": "intandemly"
        }, {
            "type": "hidden",
            "label": "CRM Sync field",
            "className": "hidden-input",
            "name": "crmsync",
            "value": "domain"
        }, {
            "type": "hidden",
            "label": "Create domain",
            "className": "hidden-input",
            "name": "domaincreate",
            "value": "0"
        }, {
            "type": "hidden",
            "label": "Create notes",
            "className": "hidden-input",
            "name": "notescreate",
            "value": "0"
        }, {
            "type": "hidden",
            "label": "Company ID",
            "className": "hidden-input",
            "name": "companyid",
            "value": "0"
        }, {
            "type": "hidden",
            "label": "Split field",
            "className": "hidden-input",
            "name": "splitfield",
            "value": "challenge"
        }, {
            "type": "button",
            "subtype": "submit",
            "label": "SEND INTANDEM",
            "className": "btn send feedbacksendbtn btn-primary",
            "name": "savehubspotfeedback",
            "value": "SEND INTANDEM",
            "style": "primary"
        }];*/
        var fbRender = document.getElementById('fb-render');
        var formRenderOpts = {
            formData: JSON.stringify(originalFormData),
            dataType: 'json'
        };
        console.log('Original formData: ', formRenderOpts);

        $(fbRender).formRender(formRenderOpts);

        /*document.getElementById('savehubspotfeedback').onclick = function () {
            var formData = new FormData(fbRender);

            function getObj(objs, key, val) {
                val = val.replace('[]', '');
                return objs.filter(function (obj) {
                    var filter = false;
                    if (val) {
                        filter = (obj[key] === val);
                    } else if (obj[key]) {
                        filter = true;
                    }
                    return filter;
                });
            }

            function setValue(name, value) {
                field = getObj(originalFormData, 'name', name)[0];

                if (!field) {
                    return;
                }

                if (['select', 'checkbox-group', 'radio-group'].indexOf(field.type) !== -1) {
                    for (var fieldOption of field.values) {
                        if (value.indexOf(fieldOption.value) !== -1) {
                            fieldOption.selected = true;
                        } else {
                            delete fieldOption.selected;
                        };
                    }
                } else {
                    field.value = value[0];
                }
            }

            console.log('Original formData: ', originalFormData);

            for (var key of formData.keys()) {
                setValue(key, formData.getAll(key));
            }

            console.log('Updated formData: ', originalFormData);
        };*/
    });
  
    /*document.getElementById('getJS').addEventListener('click', function () {
        alert('check console');
        console.log(formBuilder.actions.getData());
    });*/
    //document.getElementById("saveData").addEventListener("click", () => formBuilder.actions.save());
});
jQuery(function ($) {
    var container = document.getElementById("fb-editor");
    var options = {
        disabledFieldButtons: {
            text: ['remove'],
            select: ['edit']
        },
        defaultFields: [
            {
                className: "form-control",
                label: "First Name",
                placeholder: "Enter your first name",
                name: "first-name",
                required: true,
                type: "text"
            },
            {
                className: "form-control",
                label: "Select",
                name: "select-1454862249997",
                type: "select",
                required: true,
                multiple: "true",
                values: [
                    {
                        label: "Custom Option 1",
                        value: "test-value"
                    },
                    {
                        label: "Custom Option 2",
                        value: "test-value-2"
                    }
                ],
            },
            {
                label: "Radio",
                name: "select-1454862249997",
                type: "radio-group",
                required: true
            }
        ]
    };
    $(container).formBuilder(options);
});

///////////////////////////Form Data Loading

/*jQuery(document).ready(function ($) {
    var originalFormData = [{
        "type": "text",
        "required": true,
        "label": "What is the company Domain ?",
        "subtype": "text",
        "placeholder": "www.example.com",
        "className": "form-control",
        "name": "domain"
    }, {
        "type": "text",
        "required": true,
        "label": "What is the company Name ?",
        "subtype": "text",
        "placeholder": "Eg : coMakeIT",
        "className": "form-control",
        "name": "name"
    }, {
        "type": "textarea",
        "required": true,
        "label": "What is the customers challenge?",
        "className": "form-control",
        "name": "prospects"
    }, {
        "type": "select",
        "label": "What industry do they belong to ?",
        "className": "form-control",
        "name": "industry",
        "values": [{
            "label": "Accounting",
            "value": "Accounting",
            "selected": true
        }, {
            "label": "Airlines/Aviation",
            "value": "Airlines/Aviation"
        }, {
            "label": "Alternative Dispute Resolution",
            "value": "Alternative Dispute Resolution"
        }]
    }, {
        "type": "text",
        "required": true,
        "label": "What's the contact name?",
        "subtype": "text",
        "className": "form-control",
        "name": "contact"
    }, {
        "type": "select",
        "label": "Designation of the prospect",
        "className": "form-control",
        "name": "designation",
        "values": [{
            "label": "Founder",
            "value": "Founder",
            "selected": true
        }, {
            "label": "CXO",
            "value": "CXO"
        }, {
            "label": "Director",
            "value": "Director"
        }, {
            "label": "VP",
            "value": "VP"
        }, {
            "label": "Manager",
            "value": "Manager"
        }, {
            "label": "Other",
            "value": "new"
        }]
    }, {
        "type": "select",
        "label": "What form of content can solve this challenge?",
        "className": "form-control",
        "name": "challenge",
        "multiple": true,
        "values": [{
            "label": "Presentation",
            "value": "1",
            "selected": true
        }, {
            "label": "Blog",
            "value": "2"
        }, {
            "label": "Infographics",
            "value": "3"
        }]
    }, {
        "type": "file",
        "label": "Do you have a call recording ?",
        "className": "form-control",
        "name": "callrecording"
    }, {
        "type": "select",
        "label": "How fast do you want marketing to act on this?",
        "className": "form-control",
        "name": "priority",
        "values": [{
            "label": "High Priority",
            "value": "1",
            "selected": true
        }, {
            "label": "Low Priority",
            "value": "2"
        }, {
            "label": "Information",
            "value": "3"
        }]
    }, {
        "type": "select",
        "label": "How many days",
        "className": "form-control",
        "name": "days",
        "values": [{
            "label": "1 Days",
            "value": "1",
            "selected": true
        }, {
            "label": "2 Days",
            "value": "2"
        }, {
            "label": "3 Days",
            "value": "3"
        }]
    }, {
        "type": "hidden",
        "label": "Task",
        "className": "hidden-input",
        "name": "task",
        "value": "3"
    }, {
        "type": "hidden",
        "label": "CRM",
        "className": "hidden-input",
        "name": "crmid",
        "value": "intandemly"
    }, {
        "type": "hidden",
        "label": "CRM Sync field",
        "className": "hidden-input",
        "name": "crmsync",
        "value": "domain"
    }, {
        "type": "hidden",
        "label": "Create domain",
        "className": "hidden-input",
        "name": "domaincreate",
        "value": "0"
    }, {
        "type": "hidden",
        "label": "Create notes",
        "className": "hidden-input",
        "name": "notescreate",
        "value": "0"
    }, {
        "type": "hidden",
        "label": "Company ID",
        "className": "hidden-input",
        "name": "companyid",
        "value": "0"
    }, {
        "type": "hidden",
        "label": "Split field",
        "className": "hidden-input",
        "name": "splitfield",
        "value": "challenge"
    }, {
        "type": "button",
        "subtype": "submit",
        "label": "SEND INTANDEM",
        "className": "btn send feedbacksendbtn btn-primary",
        "name": "savehubspotfeedback",
        "value": "SEND INTANDEM",
        "style": "primary"
    }];
    var fbRender = document.getElementById('fb-render');
    var formRenderOpts = {
        formData: JSON.stringify(originalFormData),
        dataType: 'json'
    };
    console.log('Original formData: ', formRenderOpts);

    $(fbRender).formRender(formRenderOpts);

    document.getElementById('savehubspotfeedback').onclick = function () {
        var formData = new FormData(fbRender);

        function getObj(objs, key, val) {
            val = val.replace('[]', '');
            return objs.filter(function (obj) {
                var filter = false;
                if (val) {
                    filter = (obj[key] === val);
                } else if (obj[key]) {
                    filter = true;
                }
                return filter;
            });
        }

        function setValue(name, value) {
            field = getObj(originalFormData, 'name', name)[0];

            if (!field) {
                return;
            }

            if (['select', 'checkbox-group', 'radio-group'].indexOf(field.type) !== -1) {
                for (var fieldOption of field.values) {
                    if (value.indexOf(fieldOption.value) !== -1) {
                        fieldOption.selected = true;
                    } else {
                        delete fieldOption.selected;
                    };
                }
            } else {
                field.value = value[0];
            }
        }

        console.log('Original formData: ', originalFormData);

        for (var key of formData.keys()) {
            setValue(key, formData.getAll(key));
        }

        console.log('Updated formData: ', originalFormData);
    };
});*/
/*
jQuery($ => {
   
});
*/
