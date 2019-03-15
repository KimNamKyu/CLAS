$(document).ready(function () {

    
    //회원가입==============================================
    $("#Res").submit(function (e) {
        e.preventDefault();
        var registerData = {
            id: $("#register_user_id").val(),
            pwd: $("#register_user_pwd").val(),
            name: $("#register_user_name").val()
        }

        $.post("/api/Register", registerData).done(
            function (data) {
                var result = data;
                console.log(result);
                switch (result)
                {
                    case 1:
                        alert("회원가입 성공");
                        location.href = "/Home/Index";
                        break;
                    case 0:
                        alert("회원가입 실패");
                        break;
                    default:
                        alert("회원가입 실패");
                        break;
                }
            })
    });

    //로그인
    $("login").submit(function (e) {
        e.preventDefault();
        var loginData = {
            id : $("#login_user_id").val(),
            pwd : $("#login_user_pwd").val()
        }

        $.post("/api/Login", loginData).done(
            function (data) {
                var result = data;
                switch (result) {
                    case 1:
                        break;
                    case 0:
                        break;
                    default:
                        break;
                }
        })
    })
});

