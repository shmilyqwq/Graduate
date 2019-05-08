var a = document.getElementsByTagName("a")[3];
var mask = document.getElementById("mask1");
function ac(event) {
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
    var bbb = event.target ? event.target : event.srcElement;
    if (bbb.id == "mask1" || bbb.id == "cancel") {
        mask.style.display = "none";
    }
}