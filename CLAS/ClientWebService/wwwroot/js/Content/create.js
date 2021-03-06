﻿
$(document).ready(function () {
    console.log("글쓰기 시작");
    
    
    var uNo = window.sessionStorage.getItem("uNo");
    
    console.log(uNo);
    $("#NoteInsert").submit(function (e) {
        e.preventDefault();
        var cNo = $("#selectBox option:selected").val();
        
        if ($("#selectBox option:selected").val() == 1) {
            alert("게시물을 선택해주세요");
        }
        else {
            var createDate = {
                cNo: $("#selectBox option:selected").val(),
                bTitle: $("#title").val(),
                bContents: $("#content").val(),
                MemberNo: uNo
            }
            $.post("/insert/Note", createDate).done(
                function (data) {
                    var result = data;
                    switch (result) {
                        case 1:
                            alert("글 작성되었습니다!");
                            location.href = "/Note?cNo=" + cNo;
                            break;
                        case 0:
                            alert("글작성 실패하였습니다. 로그인 후 이용가능합니다.");
                            break;
                        default:
                            alert("글작성 오류");
                            break;
                    }
                })
        }
    })

})