function signup() {
    //检查密码是否一致
    var password1 = document.getElementById("password1").value;
    var password2 = document.getElementById("password2").value;
    if(password1 != password2){
        alert("These two password doesn't match!");
        return;
    }
    //创建核心对象
    xmlhttp = null;
    if (window.XMLHttpRequest) { // code for Firefox, Opera, IE7, etc.
        xmlhttp = new XMLHttpRequest();
    } else if (window.ActiveXObject) { // code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    //编写回调函数
    xmlhttp.onreadystatechange = function() {
        if (xmlhttp.readyState === 4) {
            if(xmlhttp.status === 200){
                alert("Sign up successfully!")
                document.location.href="index.html";
            }
            else if(xmlhttp.status === 400){
                alert("These username has already existed!")
            }
            else{
                alert("There's somthing error. Sign up unsuccessfully!")
            }
        }
    }
    //open设置请求方式和请求路径
    xmlhttp.open("post", "/signup", true); //一个servlet，后面还可以写是否同步
    //设置发送数据为表单
    xmlhttp.setRequestHeader("Content-type","application/x-www-form-urlencoded");
    //send 发送
    var username = document.getElementById("username").value;
    xmlhttp.send("username=" + username + "&password=" + password1);
}