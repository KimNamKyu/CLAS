$(document).ready(function () {
    console.log("내용 출력");

        $.post("/select", { spName: "Board_Proc", param: "@cNo:1" })
            .done(function (data) {
                console.log(data[0]);

                $("tbody").empty();
                for (var i = 0; i < data.length; i++) {
                    var html = "    <tr class = 'tr'>" +
                        "    <td>" + data[i].sort + "</td>" +
                        "    <td>" + data[i].bTitle + "</td>" +
                        "    <td>" + data[i].bContents + "</td>" +
                        "    <td>" + data[i].MemberName + "</td>" +
                        "    <td>" + data[i].regDate + "</td>" +
                        "</tr>";                    $("tbody").append(html);
                }
        });
 });