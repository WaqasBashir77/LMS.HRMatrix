//Variables
var add_members_for_group_id;
var add_members_for_group_person_id;
var usersarray = Array();
var lastidarray = Array();
var lastmeidarray = Array();
var groupidsarray = Array();
var grouplastidarray = Array();
var groupmelastidarray = Array();
UserId = "1";

//Get Users for Adding Members
function getusers(id, group) {
    var message = {
        "Id": id,
        "Group": group
    }
    $.ajax({
        url: "/Chat/GetUsers/",
        type: 'POST',
        data: message,
        success: function (result) {
            $("select.select").html("");
            $('input:text[name="name"]').val("");
            $.each(result, function (i) {
                $("select.select").append("<option value='" + result[i].Id + "'>" + result[i].DisplayName + "</option>");
            });
            $("#add-group").modal();
        }
    });
}
//Get Users/Groups for Chat Menu

get_users_groups(UserId);
function get_users_groups(id) {
    var message = {
        "Id": id,
        "Group": false
    }
    $.ajax({
        url: "/Chat/GetUsersGroups/",
        type: 'POST',
        data: message,
        success: function (result) {
            $("#usertable").html("");
            $.each(result, function (i) {
                $("#usertable").append('<li class="emp" value="' + result[i].Id + '"><img src="/assets/images/placeholder.jpg" class="img-circle img-md" width="25" alt="">' + result[i].DisplayName + '</li>');
            });
            var message = {
                "Id": id,
                "Group": true
            }
            $.ajax({
                url: "/Chat/GetUsersGroups/",
                type: 'POST',
                data: message,
                success: function (result) {
                    $("#usertable").html("");
                    $.each(result, function (i) {
                        $("#usertable").append('<li class="groups" value="' + result[i].Id + '"><img src="/assets/images/group.png" class="img-circle img-md" width="25" alt="">' + result[i].Name + '</li>');
                    });
                }
            });
        }
    });
}
//Filter Users in Chat Menu
function user_filter() {
    // Declare variables
    var input, filter, ul, li, data;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    ul = document.getElementById("usertable");
    li = ul.getElementsByTagName("li");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < li.length; i++) {

        if (li[i].innerHTML.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";

        } else {
            li[i].style.display = "none";
        }
    }
}

//Jquery Load Functions When Ready to Run
$(document).ready(function () {
    //Get Users for Adding/Creating New Groups
    $("body").on("click", ".icon-users4", function () {
        if ($(this).parents(".chatbox").attr("data"))
            var user = $(this).parents(".chatbox").attr("data");
        else
            var user = $(this).parents("#chatusers-box").attr("data");
        if (user.indexOf("g") > -1) {
            var group = true;
            getusers(user.replace("g", ""), group);
            add_members_for_group_id = user.replace("g", "");
            add_members_for_group_person_id = "";
        }
        else {
            var group = false;
            getusers(user, group);
            add_members_for_group_id = "";
            add_members_for_group_person_id = user;
        }
    });
    //Unknown
    $(".message-users").on("click", ".panel-title", function () {
        $(".message-users").find(".panel-body").slideToggle();
    });
    // Send Message
    $("body").on("keydown", 'input[name = "enter-message"]', function (event) {
        if (event.keyCode == 13) {
            var user = $(this).parents(".chatbox").attr("data");

            if (user.indexOf("g") > -1) {
                var group = true;
            }
            else
                var group = false;

            var text = $(this).val();
            $(this).val("");
            if (text != "") {
                var message = {
                    "UserId": UserId,
                    "ToId": user.replace("g", ""),
                    "Group": group,
                    "Text": text
                };
                $.ajax({
                    url: "/Chat/Push/",
                    type: 'POST',
                    data: message,
                    success: function (result) {

                    }
                });
            }
        }
    });
    //Close the Chat Box of Specific Person
    $("body").on("click", '.icon-cross2', function (event) {
        onlinechatpop($(this).parents(".chatbox").attr("data"));
        $(this).parents(".chatbox").remove();
        $('.chatbox').each(function (i, obj) {
            var right;
            if (i > 0) {
                right = $(this).width() * i + 10 * i + $("#chatusers-box").width() + 10 + "px";
            } else {
                var right = $("#chatusers-box").width() + 10 + "px";
            }
            $(this).css('right', right);
        });
    });
    //Chat Box Slide Toggle
    $("body").on("click", '.panel-title', function (event) {
        $(this).parents(".chatbox").find(".panel-body").toggle('slow');
    });
    //Unknown
    $(".users-btn").on("click", function (event) {
        $(".message-usres-list").toggle();
    });
    //Open Chat Box of Specific Person from Chat Menu
    $("body").on("click", 'li.emp', function (event) {
        alert($(this).val());
        var id = $(this).val();
        var name = $(this).text();

        if ($('.chatbox').is('[data = "' + id + '"]') == false) {

            getinitchat(id, name);
        }
    });
    //Open Chat Box of Specific Group from Chat Menu
    $("body").on("click", 'li.groups', function (event) {
        var id = $(this).val();
        var name = $(this).text();

        if ($('.chatbox').is('[data = "g' + id + '"]') == false) {

            getinitchat("g" + id, name);
        }
    });
    //Create Group Onclick Function
    $("#create-group-button").click(function () {
        if ($('input:text[name="name"]').val() != "" || $('#userforchat').val() != "") {
            var groupname = $('input:text[name="name"]').val();
            var message = {
                "UserId": UserId,
                "Name": groupname,
                "Members": $('#userforchat').val(),
                "GroupId": add_members_for_group_id,
                "SecondUser": add_members_for_group_person_id
            };
            $.ajax({
                url: "/Chat/CreateGroup/",
                type: 'POST',
                data: message,
                success: function (result) {
                    var Data = {
                        "Id": UserId,
                        "GroupId": add_members_for_group_id
                    };
                    $.ajax({
                        url: "/Chat/GetRecentCreateGroup/",
                        type: 'POST',
                        data: Data,
                        success: function (result) {
                            if (add_members_for_group_id == "") {
                                getinitchat("g" + result.Id, result.Name);
                            }
                            else {
                                if ($('.chatbox').is('[data = "g' + add_members_for_group_id + '"]') == false) {
                                    getinitchat("g" + add_members_for_group_id, result.Name);
                                } else {
                                    $('.chatbox[data = "g' + add_members_for_group_id + '"]').find('.panel-title').html(result.Name);
                                }
                            }
                            $("#add-group").modal('hide');

                        }
                    });

                }
            });
        } else {
            if ($('input:text[name="name"]').val() == "" && add_members_for_group_id != "") {
                alert("Please Type Name!");
            } else {
                alert("Select Users First!");
            }
        }
    });
    //Onclick Specific Message Detail View
    $("body").on("click", ".chatbox li", function () {
        //$(this).find(".media-annotation").slideToggle(function () {
        //    if ($(this).is(':hidden'))
        //        $(this).css('display', 'block');
        //});
        if ($(this).find(".media-annotation").is(':hidden')) {
            $(this).find(".media-annotation").css('display', 'block');
        }
        else {
            $(this).find(".media-annotation").css('display', 'none');
        }

    });
    //Check Syncronously for Message
    window.setInterval(async function () {
        var message = {
            "UserId": UserId,
            "OnlineUsers": usersarray,
            "OnlineUsersLastMsg": lastidarray,
            "OnlineUsersLastMsgMe": lastmeidarray,
            "OnlineGroups": groupidsarray,
            "OnlineGroupLastMsg": grouplastidarray,
            "OnlineGroupLastMsgMe": groupmelastidarray
        };
        try {
            await $.ajax({
                url: "/Chat/Get/",
                type: 'POST',
                data: message,
                success: function (result) {
                    $.each(result, function (i) {
                        var name;
                        if (result[i].FromId != UserId) {
                            var msg = "<li class='media' value='" + result[i].Id + "'><div class='media-left'><a href='~/assets/images/placeholder.jpg'><img src='/assets/images/placeholder.jpg' class='img-circle img-md' alt=''></a></div><div class='media-body'><div class='media-content'>" + result[i].Message + "</div><span class='media-annotation display-block mt-10'>Mon, 10:24 am <a href='#'><i class='icon-pin-alt position-right text-muted'></i></a></span></div></li>";
                            var chatid = result[i].FromId;
                        } else {
                            var msg = "<li class='media reversed' value='" + result[i].Id + "'><div class='media-body'><div class='media-content'>" + result[i].Message + "</div><span class='media-annotation display-block mt-10'>Mon, 10:24 am <a href='#'><i class='icon-pin-alt position-right text-muted'></i></a></span></div></li>";
                            var chatid = result[i].ToId;
                        }
                        if (result[i].HasGroup == true) {

                            if ($('.chatbox').is('[data = "g' + result[i].ChatGroupId + '"]') == false) {
                                getinitchat("g" + result[i].ChatGroupId, result[i].ChatGroup.Name);
                            } else {
                                id = groupidsarray.indexOf(String(result[i].ChatGroupId));
                                if (result[i].FromId == UserId) {
                                    groupmelastidarray[id] = result[i].Id;
                                } else {
                                    grouplastidarray[id] = result[i].Id;
                                }
                                var chatid = "g" + result[i].ChatGroupId;
                                $(msg).insertAfter("#chatbox" + chatid + " li:Last").css("opacity", "0.2").animate({ opacity: '1' }, "slow");
                                var elmnt = document.getElementById("chatbox" + chatid);
                                $("#chatbox" + chatid).scrollTop(elmnt.scrollHeight);
                            }
                            name = result[i].ChatGroup.Name;
                        } else {

                            if ($('.chatbox').is('[data = "' + chatid + '"]') == false) {
                                getinitchat(result[i].FromId, result[i].From.DisplayName);
                            } else {

                                id = usersarray.indexOf(chatid);
                                if (result[i].FromId == UserId) {
                                    lastmeidarray[id] = result[i].Id;
                                } else {
                                    lastidarray[id] = result[i].Id;
                                }
                                $(msg).insertAfter("#chatbox" + chatid + " li:Last").css("opacity", "0.2").animate({ opacity: '1' }, "slow");
                                var elmnt = document.getElementById("chatbox" + chatid);
                                $("#chatbox" + chatid).scrollTop(elmnt.scrollHeight);
                            }
                            name = result[i].From.DisplayName;
                        }
                        if (!document.hasFocus() && result[i].FromId != UserId) {
                            Notification.requestPermission(function (permission) {
                                var notification = new Notification(name, { body: result[i].Message, icon: 'https://image.flaticon.com/icons/png/128/542/542638.png', dir: 'auto' });
                            });
                        }
                        var audio = new Audio('/Content/UserFiles/Mesage-Notifiaction-Bell.mp3');

                        audio.loop = false;
                        audio.autoplay = false;
                        audio.play();


                    });

                }
            });
        } catch (err) {
        }
    }, 2000);
});
//Load Initially Chat Data
function getinitchat(user, name) {

    var flag = user.toString().indexOf("g");
    if (flag > -1) {
        var group = true;
        groupidsarray.push(user.toString().replace("g", ""));
    }
    else {
        var group = false;
        usersarray.push(user);
    }
    id = "chatbox" + user;
    var right;
    var lastchatid = 0;
    var lastmechatid = 0;
    if (name.length > 32) name = name.substring(0, 32) + "...";
    if ($('.chatbox').length > 0) {
        right = $('.chatbox:last').width() * $('.chatbox').length + 10 * $('.chatbox').length + $("#chatusers-box").width() + 10 + "px";
    } else {
        var right = $("#chatusers-box").width() + 10 + "px";
    }
    chattemplate = `<div class="chatbox panel panel-info col-md-3" data="${user}" style="position:fixed; bottom:40px; padding:0; right:${right};">
                <div class="panel-heading" style="padding:8px;">
                    <h6 class="panel-title">${name}</h6>
                    <div class="heading-elements">
                        <ul class="icons-list" style="margin-top: 3px; font-size:12px;">
                            <li><a class="icon-users4"></a></li>
                            
                            <li><a class="icon-cross2"></a></li>
                        </ul>
                    </div>
                </div>
                <div class="panel-body" style="padding:3px; margin-bottom: 0 !important;">
                    <ul class="media-list chat-list content-group" id="chatbox${user}" style="height:200px;overflow-x: hidden;">
                        <li class="media date-step">
                            <span></span>
                        </li>
                    </ul>
                    <div class="col-lg-12">
							<input type="text" name="enter-message" class="form-control send-message" rows="3" cols="1" placeholder="Enter your message...">

						</div>
					</div>
                </div>
                </div>`;
    $("body").append(chattemplate);

    var message = {
        "UserId": UserId,
        "FromId": user.toString().replace("g", ""),
        "Group": group
    };
    $.ajax({
        url: "/Chat/GetInitPrevious/",
        type: 'POST',
        data: message,
        success: function (result) {
            $.each(result, function (i) {
                var d = result[i].DateTime;
                d = d.replace("/Date(", "");
                d = d.replace(")/", "");
                console.log(d);
                d = new Date(parseInt(d));
                if (result[i].FromId != UserId) {
                    var msg = "<li class='media' value='" + result[i].Id + "'><div class='media-left'><a href='~/assets/images/placeholder.jpg'><img src='/assets/images/placeholder.jpg' class='img-circle img-md' alt=''></a></div><div class='media-body'><div class='media-content'>" + result[i].Message + "</div><span class='media-annotation display-block mt-10'>" + d.toLocaleString() + "</span></div></li>";
                    lastchatid = result[i].Id;
                } else {
                    var msg = "<li class='media reversed'><div class='media-body'><div class='media-content'>" + result[i].Message + "</div><span class='media-annotation display-block mt-10'>" + d.toLocaleString() + "</span></div></li>";
                    lastmechatid = result[i].Id;
                }
                $(msg).insertAfter("#chatbox" + user + " li:Last").css("opacity", "0.2").animate({ opacity: '1' }, "slow");

            });
            if (flag > -1) {
                grouplastidarray.push(lastchatid);
                groupmelastidarray.push(lastmechatid);
            }
            else {
                lastidarray.push(lastchatid);
                lastmeidarray.push(lastmechatid);
            }
            var elmnt = document.getElementById(id);
            $("#chatbox" + user).scrollTop(elmnt.scrollHeight);
            var audio = new Audio('/Content/UserFiles/Mesage-Notifiaction-Bell.mp3');

            audio.loop = false;
            audio.autoplay = false;
            audio.play();
            $(this).find(".media-annotation").hide();
        }
    });
}
function getdivs() {
    alert($(".chatbox").length);

}
//Remove Person Chat from
function onlinechatpop(user) {
    var flag = user.toString().indexOf("g");
    var id;
    if (flag > -1) {
        id = groupidsarray.indexOf(user.toString().replace("g", ""));
        groupidsarray.splice(id, 1);
        grouplastidarray.splice(id, 1);
        groupmelastidarray.splice(id, 1);
    }
    else {
        id = usersarray.indexOf(user);
        usersarray.splice(id, 1);
        lastidarray.splice(id, 1);
        lastmeidarray.splice(id, 1);
    }
}
