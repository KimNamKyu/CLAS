﻿$(document).ready(function () {
    
    console.log("내용 출력");
    var pNo = "1";
    /*================== 첫화면 출력 ===============================*/
    $.post("/select/Note", { spName: "PAGE", param: cNo, pNo: pNo})
        .done(function (data) {
            console.log(data);
            $("tbody").empty();
            for (var i = 0; i < data.length; i++) {
                
                var html = "    <tr class = 'tr'>" +
                    "    <td>" + data[i].sort + "</td>" +
                    "    <td>" + data[i].bTitle + "</td>" +
                    "    <td>" + data[i].MemberName + "</td>" +
                    "    <td>" + data[i].regDate + "</td>" +
                    "    <td>" + data[i].cnt + "</td>" +
                    "</tr>";
            }

            $("tbody tr").off().on("click", function () {
                var index = $("tbody tr").index(this);
                console.log(data[index].bNo);
                location.href = "Note/Detail?bNo=" + data[index].bNo;

                $.post("/update/Cnt", { bNo: data[index].bNo })
                    .done(function (data) {
                        var result = data;
                        switch (result) {
                            case 1:
                                break;
                            case 0:
                                alert("조회수 증가 실패");
                                break;
                            default:
                                break;
                        }
                    });
            });
        });

    /*===================== 페이징 처리  ====================*/
    $.post("/select", { spName: "PageCount", param: "@cNo:" + cNo })
        .done(function (data)
        {
            var cnt = data[0].cnt;
            console.log(cnt);

            for (var i = 0; i < (cnt/10); i++) {
                var html =
                console.log(this, no);
                pNo = no;

                $.post("/select/Note", { spName: "PAGE", param: cNo, pNo: pNo })
                    .done(function (data) {
                        $("tbody").empty();
                        for (var i = 0; i < data.length; i++) {
                            var html = "    <tr class = 'tr'>" +
                                "    <td>" + data[i].sort + "</td>" +
                                "    <td>" + data[i].bTitle + "</td>" +
                                "    <td>" + data[i].MemberName + "</td>" +
                                "    <td>" + data[i].regDate + "</td>" +
                                "    <td>" + data[i].cnt + "</td>" +
                                "</tr>";
                        }

                        $("tbody tr").off().on("click", function () {
                            var index = $("tbody tr").index(this);
                            console.log(data[index].bNo);
                            
                            location.href = "Note/Detail?bNo=" + data[index].bNo;
                            
                            $.post("/update/Cnt", { bNo: bNo })
                                .done(function (data) {
                                    var result = data;
                                    switch (result) {
                                        case 1:
                                            break;
                                        case 0:
                                            alert("조회수 증가 실패");
                                            break;
                                        default:
                                            break;
                                    }
                                });
                        });
                    });
            })

    /*=============================검색 기능 처리 부분===================================*/
    
        //$("#form").submit(function (e) {
        //    e.preventDefault();
        //    var bTitle = $("#text").val();
        //    $.post("/select", { spName: "Board_Search", param: "@bTitle:" + bTitle })
        //        .done(function (data) {
        //            console.log(data);
        //            $("tbody").empty();
        //            for (var i = 0; i < data.length; i++) {
        //                var html = "    <tr class = 'tr'>" +
        //                    "    <td>" + data[i].sort + "</td>" +
        //                    "    <td>" + data[i].bTitle + "</td>" +
        //                    "    <td>" + data[i].MemberName + "</td>" +
        //                    "    <td>" + data[i].regDate + "</td>" +
        //                    "    <td>" + data[i].count + "</td>" +
        //                    "</tr>";
        //            }
        //        });
        //});
});