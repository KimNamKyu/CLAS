$(document).ready(function () {
    console.log("내용 출력");

    var rNo = "";
    var uNo = window.sessionStorage.getItem("uNo");
    var uName = window.sessionStorage.getItem("uName");
    
    $.post("/select", { spName: "Board_Detail_Proc", param: "@bNo:"+bNo })
        .done(function (data) {
            console.log(data);
            var contents = data[0];
            $("#MemberName").text(contents.MemberName);
            $("#regDate").text(contents.regDate);
            $("#bTitle").text(contents.bTitle);
            $("#bContents").text(contents.bContents);
        });

    $.post("/select", { spName: "Reply_Proc", param: "@bNo:" + bNo })
        .done(function (data) {
            
            $("#reply").empty();
            for (var i = 0; i < data.length; i++) {
                rNo = data[i].rNo;
                var html = "<li class='list-group-item'>" +
                    "<div class='replybox'>" +
                    "<p id='MemberName'>" + data[i].MemberName + "</p>" +
                    "<p id='MemberName'>" + data[i].regDate + "</p>" +
                    "<br>" +
                    "<p id='MemberName'>" + data[i].rContent + "</p>" +
                    
                            "</div>" +
                        "</li>";
                $("#reply").append(html);
            }
        });
  
    

    $("#replyform").submit(function (e) {
        e.preventDefault();

        var replyData = {
            bNo: bNo,
            uNo: uNo,   //추후 수정 요망
            rContent: $("#content").val()
        }

        $.post("/insert/Reply", replyData)
            .done(function (data) {
                var result = data;
                switch (result) {
                    case 1:
                        alert("댓글 작성되었습니다!");
                        location.href = "/Note/Detail?bNo="+bNo;
                        break;
                    case 0:
                        alert("댓글 실패하였습니다. 댓글을 입력하세요");
                        break;
                    default:
                        alert("댓글 오류");
                        break;
                }
            });
    });

    $("#cancel_btn").on("click", function () {
        location.href = "/Note/Detail?bNo=" + bNo;
    });

    $("#userName").text(uName);
});