$(document).ready(function () {
    $("form").submit(function (e) {
        e.preventDefault();
        var loginData = {
            id: $("#login_user_id").val(),
            password: $("#login_user_pwd").val()
        };

        $.post("User/Login", loginData).done(function (d) {
            if (d.state == 1) {
                location.href = "/Home/Index";
            }
            else if(d.state != 1) {
                $("#login_user_id").val("");
                $("#login_user_pwd").val("");
                alert("사용자가 없습니다.");
            }
        });
    });
});