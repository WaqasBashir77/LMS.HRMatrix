

    $(document).ready(function () {
            $("#lessons-list").height($("#contents").height());
        $("#video-player").hide(); $("#content").hide(); $("#pptfile").hide();

        $("#lessons-list").height($("#lesson-container").height() + 20);
    });
function GetLessonData(id) {

        SetNextOrPrevious(id);
            $.ajax({
                url: "/LessonContent/GetContentData/" + id,
                type: 'POST',
                success: function (result) {

                    LessonContentIndexID = id;
                    SyncCourseData(EnrolledId, id);

                    //$("#lessons-list").height($("#contents").height());
                    LessonContent = result;
                    console.log(LessonContent);
                    ContentType = LessonContent.ContentType;

                    var mediaPlayer = $("#MediaPlayer").data("kendoMediaPlayer");
                    mediaPlayer.stop();

                    $("#video-player").hide(); $("#content").hide(); $("#pptfile").hide();

                    $.ajax({
                        url: "/TopicContentQuestion/GetQuestions/" + id,
                        type: 'POST',
                        success: function (result) {
                            stringArray = result;

                            if (LessonContent.ContentType == "video") {
                                if (stringArray != null) {
                                    for (var i = 0; i < stringArray.length; i++) {
                                        times[i] = stringArray[i].Time;
                                    }
                                }
                                $("#video-player").show();
                                var x = document.getElementsByClassName("k-mediaplayer-media")[0];
                                var mediaPlayer = $("#MediaPlayer").data("kendoMediaPlayer");
                                mediaPlayer.stop();
                                
                                x.setAttribute('src', LessonContent.Url);
                                document.getElementsByClassName("k-mediaplayer-titlebar")[0].innerHTML = LessonContent.Name;
                                
                                mediaPlayer.play();
                                

                            }
                            else if (LessonContent.ContentType == "content") {
                                if (stringArray != null) {
                                    for (var i = 0; i < stringArray.length; i++) {
                                        times[i] = "notanswered";
                                    }
                                }
                                document.getElementById("content-text").innerHTML = LessonContent.ContentText.replace(/&lt;/g, '<').replace(/&gt;/g, '>');

                                $("#content").show();
                                $("#lessons-list").height($("#lesson-container").height() + 20);
                            }

                            console.log(times);
                            console.log(stringArray);
                        }
                    });
                }
            });
        }
    var xmlhttp;
    function loadXMLDoc(url, cfunc) {
        if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp = new XMLHttpRequest();
        }
        else {// code for IE6, IE5
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.onreadystatechange = cfunc;
        xmlhttp.open("GET", url, true);
        xmlhttp.send();
    }
    function GetQuestions(id) {

            loadXMLDoc("/TopicContentQuestion/Index/" + id, function () {
                document.getElementById("QuestionsList").innerHTML = "<div id='order-status-active'><h1 class='text-center'>Processing...  </h1></div>";
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById("QuestionsList").innerHTML = xmlhttp.responseText;
                }
            });
        }

    $(document).ready(function () {
            $("#AddQuestionBtn").click(function () {
                $("#AddQuestion").modal();
            });
        });
    $(document).ready(function () {
            $("#UploadVideoBtn").click(function () {
                $("#ContentType").val("video");
            });
        });
    $(document).ready(function () {
            $("#ContentBtn").click(function () {
                $("#ContentType").val("content");
            });
        });
    $(document).ready(function () {
            $("#VideoUrlBtn").click(function () {
                $("#ContentType").val("video");
            });
        });
    function SetContentId(id) {
            $("#LessonContentId").val(id);
        GetQuestions(id);
    }

    function CalculateAnswer() {
        if (document.getElementById("Answer").innerHTML != "") {
            if (ContentType == "video") {
                var x = document.getElementsByClassName("k-mediaplayer-currenttime")[0].innerHTML;
                if (times.indexOf(x) > -1) {
                    index = times.indexOf(x);
                    setquestion(index);
                } else {
                    var mediaPlayer = $("#MediaPlayer").data("kendoMediaPlayer");
                    $("#Questions").modal('hide');
                    //pauses the video
                    mediaPlayer.play();
                }
            } else if (ContentType == "ppt") {
                var x = document.getElementsByClassName("ndfHFb-c4YZDc-DARUcf-NnAfwf-cQYSPc")[0].innerHTML;
                if (times.indexOf(x) > -1) {
                    index = times.indexOf(x);
                    setquestion(index);
                } else {
                    $("#Questions").modal('hide');
                }
            } else if (ContentType == "content") {

                if (times.indexOf("notanswered") > -1) {
                    index = times.indexOf("notanswered");
                    setquestion(index);
                } else {
                    $("#Questions").modal('hide');
                }
            }
        } else {
            var index = document.getElementById("Index").value;

            if (stringArray[index].optionone != null && String(document.getElementById("optionone").checked) != String(stringArray[index].optiononestatus)) {
                AnswerMessage(index, "false");
                SaveAnswer(stringArray[index].Id, "false")
            }
            else if (stringArray[index].optiontwo != null && String(document.getElementById("optiontwo").checked) != String(stringArray[index].optiontwostatus)) {
                AnswerMessage(index, "false");
                SaveAnswer(stringArray[index].Id, "false")
            }
            else if (stringArray[index].optionthree != null && String(document.getElementById("optionthree").checked) != String(stringArray[index].optionthreestatus)) {
                AnswerMessage(index, "false");
                SaveAnswer(stringArray[index].Id, "false")
            }
            else if (stringArray[index].optionfour != null && String(document.getElementById("optionfour").checked) != String(stringArray[index].optionfourstatus)) {
                AnswerMessage(index, "false");
                SaveAnswer(stringArray[index].Id, "false")
            }
            else {
                AnswerMessage(index, "true");
                SaveAnswer(stringArray[index].Id, "true")
            }
            TrueAnswers(index);
        }
    }
    function TrueAnswers(index) {
        var success = '<div class="form-control-feedback">< i class="icon-checkmark-circle" ></i ></div >';
        var error = '<div class="form-control-feedback">< i class="icon-cancel-circle2" ></i ></div >';
        if (stringArray[index].optiononestatus == "true") {
            $(".checkbox").eq(0).addClass("has-success");
        }
        if (stringArray[index].optiontwostatus == "true") {
            $(".checkbox").eq(1).addClass("has-success");
        }
        if (stringArray[index].optionthreestatus == "true") {
            $(".checkbox").eq(2).addClass("has-success");
        }
        if (stringArray[index].optionfourstatus == "true") {
            $(".checkbox").eq(3).addClass("has-success");
        }
    }
    function RemoveAnswers() {
        $(".checkbox").eq(0).removeClass("has-success");
        $(".checkbox").eq(1).removeClass("has-success");
        $(".checkbox").eq(2).removeClass("has-success");
        $(".checkbox").eq(3).removeClass("has-success");
        document.getElementById("Answer").innerHTML = "";
        document.getElementById("optionone").checked = false;
        document.getElementById("optiontwo").checked = false
        document.getElementById("optionthree").checked = false;
        document.getElementById("optionfour").checked = false;
    }
    function AnswerMessage(index, answer) {
        if (answer == "true") {
            document.getElementById("Answer").innerHTML = '<h3 class="text-success">True Answer</h3>';
        } else {
            document.getElementById("Answer").innerHTML = '<h3 class="text-danger">Wrong Answer</h3>';
        }
    }
    function setquestion(index) {
        RemoveAnswers();
        if (ContentType == "content") {
            times[index] = "answered";
        } else {
            times[index] = "";
        }
        document.getElementById("Index").value = index;
        document.getElementById("askquestion").innerHTML = stringArray[index].Question;
        if (stringArray[index].optionone != null) {
            document.getElementById("askoptionone").innerHTML = stringArray[index].optionone;
            document.getElementsByClassName("checkbox")[0].style.visibility = "visible";
        } else {
            document.getElementsByClassName("checkbox")[0].style.visibility = "hidden";
        }
        if (stringArray[index].optiontwo != null) {
            document.getElementById("askoptiontwo").innerHTML = stringArray[index].optiontwo;
            document.getElementsByClassName("checkbox")[1].style.visibility = "visible";
        } else {
            document.getElementsByClassName("checkbox")[1].style.visibility = "hidden";
        }
        if (stringArray[index].optionthree != null) {
            document.getElementById("askoptionthree").innerHTML = stringArray[index].optionthree;
            document.getElementsByClassName("checkbox")[2].style.visibility = "visible";
        } else {
            document.getElementsByClassName("checkbox")[2].style.visibility = "hidden";
        }
        if (stringArray[index].optionfour != null) {
            document.getElementById("askoptionfour").innerHTML = stringArray[index].optionfour;
            document.getElementsByClassName("checkbox")[3].style.visibility = "visible";
        } else {
            document.getElementsByClassName("checkbox")[3].style.visibility = "hidden";
        }
        if (ContentType == "video") {
            var mediaPlayer = $("#MediaPlayer").data("kendoMediaPlayer");
            //pauses the video
            mediaPlayer.pause();
        }
        $("#Questions").modal();
    }
    $(document).ready(function () {
        $("#btnSubmit").click(function () {
            if (times.indexOf("notanswered") > -1) {
                index = times.indexOf("notanswered");
                setquestion(index);
            }
        });
    });
    $(document).ready(function () {
        $("#btnSubmitfile").click(function () {
            if (times.indexOf("notanswered") > -1) {
                index = times.indexOf("notanswered");
                setquestion(index);
            }
        });
    });

    function SaveAnswer(id, result) {
        var answer = {
            "CourseEnrollmentId": CourseId,
            "Result": result,
            "TopicContentQuestionId": id
        };
        $.ajax({
            url: "/LessonContent/SubmitAnswer/",
            type: 'POST',
            data: answer,
            success: function (result) {
                if (result.success == true) {

                    alert("Ok");
                } else {
                    alert("Something Wrong");
                }
            }
        });
    }

    function SyncCourseData(id, contentid, time) {
        var syncdata = {
            "Id": id,
            "LessonContentId": contentid,
            "Time": time
        };
        $.ajax({
            url: "/LessonContent/SyncLessonContent/",
            type: 'POST',
            data: syncdata,
            success: function (result) {
                if (result.success == true) {

                    console.log("Data Sync Successful...");
                } else {
                    alert("Something Wrong");
                }
            }
        });
    }
    window.setInterval(function () {
        if (ContentType !== 'undefined' && ContentType == "video") {
            var mediaPlayer = $("#MediaPlayer").data("kendoMediaPlayer");
            if (mediaPlayer.isPlaying()) {
                var x = document.getElementsByClassName("k-mediaplayer-currenttime")[0].innerHTML;

                var timeParts = x.split(":").reverse();
                var seconds = 0;
                for (var i = 0; i < timeParts.length; i++) {
                    seconds = seconds + (parseInt(timeParts[i]) * Math.pow(60, i));
                }

                if (times.indexOf(x) > -1) {
                    index = times.indexOf(x);
                    setquestion(index);
                }
                if (LastLessonContentTime != "" && seconds == 1) {

                    mediaPlayer.seek(parseInt(LastLessonContentTime) * 1000);
                    LastLessonContentTime = "";
                    
                    //alert("sdf");
                }
                SyncCourseData(EnrolledId, LessonContentIndexID, seconds);
                console.log(Math.round(mediaPlayer.seek()));
            }
        }
        else if (ContentType !== 'undefined' && ContentType == "ppt") {
            var iframe = document.getElementById("myFrame");
            var x = iframe.contentWindow.document.getElementsByClassName("ndfHFb-c4YZDc-DARUcf-NnAfwf-cQYSPc")[0].innerHTML;
            if (times.indexOf(x) > -1) {
                index = times.indexOf(x);
                setquestion(index);
            }
        }
    }, 800);
