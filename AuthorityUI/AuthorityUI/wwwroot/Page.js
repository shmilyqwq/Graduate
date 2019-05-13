function goPage(pno) {
    var idTable = document.getElementById("idData");
    var rowNum = idTable.rows.length;//获取行数
    var totalPage;//总页数
    var pageSize = 15;//每页显示行数
    console.log(rowNum);

    var currentPage = pno;//当前页数
    var startRow = (currentPage - 1) * pageSize + 1;//开始显示时的行数
    var endRow = currentPage * pageSize;//结束显示时的行数
    endRow = (endRow > rowNum) ? num : endRow;
    console.log(endRow);
    //分页数量
    if (rowNum / pageSize > parseInt(rowNum / pageSize)) {
        totalPage = parseInt(rowNum / pageSize) + 1;
    }
    else {
        totalPage = parseInt(rowNum / pageSize);
    }
    //遍历显示数据实现分页
    for (var i = 1; i < (rowNum + 1); i++) {
        var irow = idTable.rows[i - 1];
        if (i >= startRow && i <= endRow) {
            irow.style.display = "table-row";
        }
        else {
            irow.style.display = "none";
        }
    }
    var pageEnd = document.getElementById("pageEnd");
    var tempStr = "<span>共" + totalPage + "页<span>"

    if (currentPage > 1) {
        tempStr += "<span class='btn' href=\"#\" onClick=\"goPage(" + (1) + ")\">首页</span>";
        tempStr += "<span class='btn' href=\"#\" onClick=\"goPage(" + (currentPage - 1) + ")\">上一页</span>"
    }
    else {
        tempStr += "<span class='btn'>首页</span>";
        tempStr += "<span class='btn'>上一页</span>";
    }

    for (var pageIndex = 1; pageIndex < totalPage + 1; pageIndex++) {
        tempStr += "<span class='btn' href=\"#\" onClick=\"goPage(" + (currentPage + 1) + ")\">下一页</span>";
        tempStr += "<span class='btn' href=\"#\" onClick=\"goPage(" + (totalPage) + ")\">尾页</span>";
    }
    else {
        tempStr += "<span class='btn'>下一页</span>";
        tempStr += "<span class='btn'>尾页</span>";
    }
    document.getElementById("barcon").innerHTML = tempStr;
}
