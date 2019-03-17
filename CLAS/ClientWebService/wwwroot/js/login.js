$(document).ready(function () {


    //회원가입==============================================
    $("#Res").submit(function (e) {
        e.preventDefault();
        var registerData = {
            id: $("#register_user_id").val(),
            pwd: $("#register_user_pwd").val(),
            name: $("#register_user_name").val()
        }
        console.log(registerData);
        $.post("/api/Register", registerData).done(
            function (data) {
                var result = data;
                console.log(result);
                switch (result) {
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
    $("#login").submit(function (e) {
        e.preventDefault();

        var loginData = {
            id: $("#login_user_id").val(),
            pwd: $("#login_user_pwd").val()
        }

       

        $.post("/api/Login", loginData)
            .done(function (data) {
                console.log(data);
                var result = data[0].state;
                var uNo = data[0].MemberNo;
                var uName = data[0].MemberName;
                if (result == "1") {
                    alert("로그인 성공하였습니다.");
                    sessionStorage.setItem("state", result);
                    sessionStorage.setItem("uNo", uNo);
                    sessionStorage.setItem("uName", uName);
                    location.href = "/Home";
                }
                else {
                    $("#login_user_id").val("");
                    $("#login_user_pwd").val("");
                    alert("아이디나 비밀번호를 확인해주세요!");
                }   
            });
    });

    var state = window.sessionStorage.getItem("state");
    var uName = window.sessionStorage.getItem("uName");

    $("#userName").text(uName + "님 환영합니다.");    
    if (state == null) {
        $("#afterlogin").empty();
        var html = "<li class='beuser' onclick='home_login_btn()'>" + "로그인" + "</li>" +
            "<li class='beuser' onclick='home_register_btn()'>" + "회원가입" + "</li>";
        $("#afterlogin").append(html);
    }

    $("#logout").click(function () {
        alert("로그아웃되었습니다.");
        sessionStorage.clear();
        location.href = "/Home";
    });
});

