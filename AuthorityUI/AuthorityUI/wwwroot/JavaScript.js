//onblur失去焦点事件，用户离开输入框时执行 JavaScript 代码：
//函数：验证邮箱格式
function isEmail(strEmail) {
    //定义正则表达式的变量:邮箱正则
    var reg = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
        ///([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/;
  		//文本框不为空，并且验证邮箱正则成功，给出正确提示
  		if (strEmail != null && strEmail.search(reg) != -1) {
        document.getElementById("test_user").innerHTML = "<font color='green' size='4px'>√邮箱格式正确！</font>";
    } else {
        document.getElementById("test_user").innerHTML = "<font color='red' size='4px'>邮箱格式错误！</font>";
    }
}