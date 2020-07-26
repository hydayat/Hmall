//初始化函数
window.onload = function(){
    goodName = decodeURI(getQueryVariable("GoodName"));
    document.getElementById("GoodName").innerText = goodName;
    document.getElementById("Price").innerText = "￥"+getQueryVariable("Price");
    document.getElementById("Img").style.backgroundImage = "url(../img/Good/" + goodName + ".jpg)";
    updateUsername();
}

//返回上一页
function back(){
    document.location.href = "../store.html"
}

//处理 url 参数
function getQueryVariable(variable)
{
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i=0;i<vars.length;i++) {
        var pair = vars[i].split("=");
        if(pair[0] == variable){return pair[1];}
    }
    return(false);
}

//添加购物车
function addCart(){
    //判断数量是否为 0
    const amount = document.getElementById("Amount").value;
    if(amount < 1){
        alert("The amount should be at least 1!");
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
                alert("Add to Shopping Cart Successfully!");
                document.location.href = "../store.html";
            }
            else{
                alert("This tank has been already in your shopping cart!")
            }
        }
    }
    //open设置请求方式和请求路径
    xmlhttp.open("post", "/addCart", true); //一个servlet，后面还可以写是否同步
    //设置发送数据为表单
    xmlhttp.setRequestHeader("Content-type","application/x-www-form-urlencoded");
    //send 发送
    const username = document.getElementById("Username").innerText;
    const goodName = document.getElementById("GoodName").innerText;
    const price = document.getElementById("Price").innerText.substring(1);
    xmlhttp.send("username=" + username + "&goodname=" + goodName + "&price=" + price + "&amount=" + amount);

}
function increase(){
    document.getElementById("Amount").value = Number(document.getElementById("Amount").value) + 1;
}
function decrease(){
    originAmount = Number(document.getElementById("Amount").value);
    if(originAmount > 0){
        document.getElementById("Amount").value = originAmount - 1;
    }
}