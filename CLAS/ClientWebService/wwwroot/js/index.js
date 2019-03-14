$(document).ready(function () {
    console.log("내용 출력");

    $.post("/select", { spName: "Board_Proc", param: "@cNo:3" })
        .done(function (data) {
            console.log(data[0]);

            $(".list-group-item").empty();
            for (var i = 0; i < data.length; i++) {
                var html =  + "<div class='list-title'>" +
                    "<a href=''>" + data[i].bTitle + "</a>" +
                        "<div class='list-gorup-item-author'>" +
                        "<div class='avatar'>" +
                        "<div class='info'>" +
                        "<span class='nicname'>" + data[i].MemberName + "</span>" +
                        "<span class='nicname'>" + data[i].regDate + "</span>" +
                            "</div>" +
                            "</div>" +
                            "</div>" +
                            "</div>";                $(".list-group-item").append(html);
            }
        });
});
