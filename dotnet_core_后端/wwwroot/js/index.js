function signup(){
    window.location.href="signup.html";
}
function login() {
    //创建核心对象
    xmlhttp = null;
    if (window.XMLHttpRequest) { // code for Firefox, Opera, IE7, etc.
        xmlhttp = new XMLHttpRequest();
    } else if (window.ActiveXObject) { // code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    //编写回调函数
    xmlhttp.onreadystatechange = function() {
        //if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
        if (xmlhttp.readyState === 4) {//当后端返回的时候
            if(xmlhttp.status === 200){
                alert("Sign in successfully!");
                document.location.href="store.html";
            }
            else {
                alert("The username or password is wrong!");
            }
        }
    }
    //open设置请求方式和请求路径
    xmlhttp.open("post", "/signin", true); //一个servlet，后面还可以写是否同步
    //设置发送数据为表单
    xmlhttp.setRequestHeader("Content-type","application/x-www-form-urlencoded");
    //send 发送
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    xmlhttp.send("username=" + username + "&password=" + password);
}