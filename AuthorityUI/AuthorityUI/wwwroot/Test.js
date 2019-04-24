var a = document.getElementsByTagName("a")[0];
var mask = document.getElementById("mask");
function ab(event) {
    mask.style.display = "block";
    //阻止冒泡
    event = event || window.event;
    if (event || event.stopPropagation()) {
        event.stopPropagation();
    } else {
        event.cancelBubble = true;
    }
}

document.onclick = function (event) {
    event = event || window.event;
    //兼容获取触动事件时被传递过来的对象
    var aaa = event.target ? event.target : event.srcElement;
    if (aaa.id == "mask" || aaa.id == "cancel") {
        mask.style.display = "none";
    }
}