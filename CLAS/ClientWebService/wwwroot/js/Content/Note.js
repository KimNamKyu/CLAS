$(document).ready(function () {
    
    console.log("내용 출력");
    var pNo = "1";
    /*================== 첫화면 출력 ===============================*/
    $.post("/select/Note", { spName: "PAGE", param: cNo, pNo: pNo})
        .done(function (data) {
            console.log(data);
            console.log(data[0]);
            $("tbody").empty();
            for (var i = 0; i < data.length; i++) {
                
                var html = "    <tr class = 'tr'>" +
                    "    <td>" + data[i].sort + "</td>" +
                    "    <td>" + data[i].bTitle + "</td>" +
                    "    <td>" + data[i].MemberName + "</td>" +
                    "    <td>" + data[i].regDate + "</td>" +
                    "    <td>" + data[i].cnt + "</td>" +
                    "</tr>";                $("tbody").append(html);
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

            for (var i = 0; i < (cnt/15); i++) {
                var html =                    "<li class='pageNo'><a>" + (i + 1) + "</a></li>";                $("#paging").append(html);            }            $("#paging a").click(function () {                var no = $(this).text();
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
                                "</tr>";                            $("tbody").append(html);
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
            })        });
    var uNo = window.sessionStorage.getItem('uNo');
    $.post("/insert/Mapping", { urlNo: cNo, mNo: uNo })
        .done(function (data) {
            var result = data;
        });

    var state = window.sessionStorage.getItem('state');
    if (state == null) {
        $.post("/update/NouserCnt", { urlNo: cNo })
    }
    /*=============================검색 기능 처리 부분===================================*/

   
    $("#form").submit(function (e) {
        e.preventDefault();
        var bTitle = $("#text").val();
        if (bTitle == "") {
            alert("검색어를 입력해주세요");
        }
        else {
            $.post("/select/NoteSearch", { spName: "Board_Search", param: bTitle, pNo: "1" })
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
                            "</tr>";                        $("tbody").append(html);
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

            $.post("/select", { spName: "Search_total", param: "@bTitle:" + bTitle })
                .done(function (data) {
                    console.log(data);
                    var cnt = data[0].tot;
                    console.log(cnt);

                    $("#paging").empty();
                    for (var i = 0; i < (cnt / 15); i++) {
                        var html =                            "<li class='pageNo'><a>" + (i + 1) + "</a></li>";                        $("#paging").append(html);                    }                    $("#paging a").click(function () {                        var no = $(this).text();
                        console.log(this, no);
                        pNo = no;

                        $.post("/select/NoteSearch", { spName: "Board_Search", param: bTitle, pNo: pNo })
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
                                        "</tr>";                                    $("tbody").append(html);
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


                });

        }
       
       
      
    });

       
});



