function updateUsername() {
    //创建核心对象
    xmlhttp = null;
    if (window.XMLHttpRequest) { // code for Firefox, Opera, IE7, etc.
        xmlhttp = new XMLHttpRequest();
    } else if (window.ActiveXObject) { // code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    //编写回调函数
    xmlhttp.onreadystatechange = function() {
        if (xmlhttp.readyState === 4) {//当后端返回的时候
            if (xmlhttp.status === 200) {
                username = xmlhttp.responseText;
                document.getElementById("Username").innerText = username;
                //加载头像
                document.getElementById("Avator").style.backgroundImage = "url(../avator/" + username + ".jpg)";
            }
            else {
                document.getElementById("Username").innerText = "No User";
            }
        }
    }
    //open设置请求方式和请求路径
    xmlhttp.open("get", "/getUsername", true); //一个servlet，后面还可以写是否同步
    xmlhttp.send();
}