$(document).ready(function () {
        console.log("내용 출력");
        var data = [
            ["1", "파일1", "작성자", "2019-02", "123"], //{} :: 키와 value로 되어있는 순서가 없는 json 타입의 object
            ["2", "파일2", "작성자", "2019-02", "123"],
            ["3", "파일3", "작성자", "2019-02", "123"]
        ];

        for (var i = 0; i < data.length; i++) {
            var html = " <tr class = 'tr'>" +
                " <td>" + data[i][0] + "</td>" +
                " <td>" + data[i][1] + "</td>" +
                " <td>" + data[i][2] + "</td>" +
                " <td>" + data[i][3] + "</td>" +
                " <td>" + data[i][4] + "</td>" +
                "</tr>";
            $("tbody").append(html);
        }
    });