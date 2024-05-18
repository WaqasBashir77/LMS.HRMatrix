
function createCourse() {
    var ErrorMessage;
    if ($.trim($('#courseTitle').val()).length > 0) {
        $('#courseTitle').addClass('border-primary');
        $('#courseTitle').removeClass('border-danger');
        ErrorMessage = "Course Title Null";
    }
    else if ($.trim($('#courseDescription').val()).length > 0) {
        $('#courseDescription').addClass('border-primary');
        $('#courseDescription').removeClass('border-danger');
        ErrorMessage = "Course Description Null";
    }
    else {
        try {
            var fileInput = document.getElementById("courseFile");
            var size = fileInput.files[0].size;
            if (size > 0) {
                $('#courseFile').addClass('border-primary');
                $('#courseFile').removeClass('border-danger');
            } 
        } catch (e) {
            ErrorMessage = "Course Image Null";
        }
    }
    var verified = true;
    if ($.trim($('#courseTitle').val()).length < 1) {
        verified = false;
        $('#courseTitle').removeClass('border-primary');
        $('#courseTitle').addClass('border-danger'); ErrorMessage = "Course Title Null";
    }
    else if ($.trim($('#courseDescription').val()).length < 1) {
        verified = false;
        $('#courseDescription').removeClass('border-primary');
        $('#courseDescription').addClass('border-danger'); ErrorMessage = "Course Title Null";
    }
    else {
        try {
            var fileInput = document.getElementById("courseFile");
            var filename = getFile(fileInput.value);
            var extension = fileInput.value.split('.')[1];
            if (extension === "jpg" || extension === "jpeg" || extension === "png" || extension === "gif" || extension === "mp4") {
             } else {
                ErrorMessage ="not correct file choosen";
            }
            var size = fileInput.files[0].size;
            size = size / 1024;
            size = size / 1024;
            if (size > 0 && size<50) {
            }
            else if (size > 50)//5mb
            {
                verified = false;
                $('#courseFile').removeClass('border-primary');
                $('#courseFile').addClass('border-danger');
                ErrorMessage = "Course Image size exceeded max size";
            }else {
                verified = false;
                $('#courseFile').removeClass('border-primary');
                $('#courseFile').addClass('border-danger');
                ErrorMessage = "Course Image Null";
            }
        }
        catch (e) {
            verified = false;
            $('#courseFile').removeClass('border-primary');
            $('#courseFile').addClass('border-danger');
            ErrorMessage = "Course Image Null";
          }
        }
        if (verified) {
                       var empdata = { "course_Name": "", "Description": "" };
                       empdata.course_Name = $("#courseTitle").val();
                       empdata.Description = $("#courseDescription").val();
                       var data = new FormData();
                       var files = $("#courseFile").get(0).files;
                       data.append("Image", files[0]);
                       data.append("course_Name", $("#courseTitle").val());
                       data.append("Description", $("#courseDescription").val());
                       $.ajax({
                           type: "POST",
                           url: "/Home/createCourse",
                           data: data,
                           contentType: false, // Not to set any content header
                           processData: false,
                           success: function(msg) {
                               if (msg != "") {
                                   var count=0;
                                   var myVar = setInterval(function () { myTimer() }, 0);
                                   $('#courseFile').val("");
                                   $('#courseDescription').val("");
                                   $('#courseTitle').val("");
                                  $('#progresswa').css('width', count + "%");
                                   //calling LoadProgressBar function to load the progress bar.
                                  
                               }
                           },
                           error: function(data) {
                               alert("Record not updated!");
            }
        });
        } else {
            alert(ErrorMessage);
            return;
        }
    }
function getFile(filePath) {
    return filePath.substr(filePath.lastIndexOf('\\') + 1).split('.')[0];
}

var count = 0;
function myTimer() {

    if (count < 100) {
     //   $('.progress').css('width', count + "%"); //progress
    $('#progresswa').css('width', count + "%");
        count += 1;
        document.getElementById("demo").innerHTML = Math.round(count) + "%";
        // code to do when loading
    }
   
   
}

