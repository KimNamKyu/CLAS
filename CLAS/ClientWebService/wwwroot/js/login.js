$(document).ready(function () {

    var logininfo = sessionStorage.getItem("user");

    if (logininfo != null) {

    }


    $("form").submit(function (e) {
        e.preventDefault();
        var inputid = $("#login_user_id").val();
        var inputpwd = $("#login_user_pwd").val();

        if (inputid == "" && inputpwd == "") {
            alert("아이디와 비밀번호를 확인하세요!");
            return false;
        }
        
        var loginData = {
            spName: "UserLogon",
            id: $("#login_user_id").val(),
            pwd: $("#login_user_pwd").val()
        };

        $.post("/select/Login", loginData).done(
            function (data) {
                var id = data[0].MemberId;
                var pwd = data[0].MemberPassword;

                if (inputid == id && inputpwd == pwd) {
                    alert("아이디" + data[0].MemberId + "비번" + data[0].MemberPassword + "네임" +  data[0].MemberName);
                }
                else {
                    alert("아이디와 비밀번호를 확인하세요!");
                }
        })
    })
});

