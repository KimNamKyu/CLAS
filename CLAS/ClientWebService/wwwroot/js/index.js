$(document).ready(function () {
    console.log("내용 출력");

    $.post("/select", { spName: "Board_Proc", param: "@cNo:1" })
        .done(function (data) {
            console.log(data);

            $(".list-group-board").empty();
            for (var i = 0; i < 5; i++) {
                var html = "<li class='list-group-item'>" +
                    "<div class='list-title'>" +
                    "<a href='#'>"+data[i].bTitle+"</a>" +
                    "<div class='list-gorup-item-author'>" +
                    "<div class='avatar'>" +
                    "<div class='info'>" +
                    "<span class='nicname'>" + data[i].MemberName + "</span>" +
                    "<span class='nicname'>" + "&nbsp; "+ data[i].regDate + "</span>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</li>";
                $(".list-group-board").append(html);
            }
        });

    $.post("/select", { spName: "Board_Proc", param: "@cNo:3" })
        .done(function (data) {
            console.log(data);

            $(".list-group-QnA").empty();
            for (var i = 0; i < 5; i++) {
                var html = "<li class='list-group-item'>" +
                    "<div class='list-title'>" +
                    "<a href='#'>" + data[i].bTitle + "</a>" +
                    "<div class='list-gorup-item-author'>" +
                    "<div class='avatar'>" +
                    "<div class='info'>" +
                    "<span class='nicname'>" + data[i].MemberName + "</span>" +
                    "<span class='nicname'>" + "&nbsp; "+ data[i].regDate + "</span>" +
                    "</div>" +
                    "</div>" +
                    "</div>" +
                    "</div>" +
                    "</li>";
                $(".list-group-QnA").append(html);
            }
        });

    $.post("/select", { spName: "Board_Proc", param: "@cNo:2" })
        .done(function (data) {
            console.log(data);

            $(".list-group-Notice").empty();
            for (var i = 0; i < 5; i++) {
                var html = "<li class='list-group-item'>" +
                    "<div class='list-title'>" +
                    "<a href='#'>" + data[i].bTitle + "</a>" +
                    "<div class='list-gorup-item-author'>" +
                    "<div class='avatar'>" +
                    "<div class='info'>" +
                    "<span class='nicname'>" + data[i].MemberName + "</span>" +
                    "<span class='nicname'>" + "&nbsp; "+ data[i].regDate + "</span>" +
                    "</div>" +
                    "</div>" +
                    "</div>" +
                    "</div>" +
                    "</li>";
                $(".list-group-Notice").append(html);
            }
        });
});


