$(document).ready(function () {
    var createView = function (cNo, taget) {
        $.post("/select", { spName: "Board_Proc", param: "@cNo:" + cNo })
         .done(function (data) {
                $(taget).empty();
                for (var i = 0; i < 6; i++) {
                    if (data.length == i) break;
                    var html = "<li class='list-group-item'>" +
                        "<div class='list-title'>" +
                        "<a href='/Note/Detail?bNo=" + data[i].bNo + "'>" + data[i].bTitle + "</a>" +
                        "<div class='list-gorup-item-author'>" +
                        "<div class='avatar'>" +
                        "<div class='info'>" +
                        "<span class='nicname'>" + data[i].MemberName + "</span>" +
                        "<span class='nicname'>" + "&nbsp; " + data[i].regDate + "</span>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</li>";
                    $(taget).append(html);
                 }
             });
         });
    }
    createView(1, ".list-group-board");
    createView(2, ".list-group-Notice");
    createView(3, ".list-group-QnA");
});


