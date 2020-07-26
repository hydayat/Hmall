window.onload = function(){
    //设置商品名
    goodName = decodeURI(getQueryVariable("GoodName"));
    document.getElementById("GoodName").innerText = goodName;
    //设置订单时间
    var day2 = new Date();
    day2.setTime(day2.getTime());
    var s2 = day2.getFullYear()+"-" + (day2.getMonth()+1) + "-" + day2.getDate();
    document.getElementById("Time").innerText = s2
    //设置商品单价
    document.getElementById("Price").innerText = "￥"+getQueryVariable("Price");
    //设置商品图片
    document.getElementById("Img").style.backgroundImage = "url(img/Good/" + goodName + ".jpg)"
    //设置商品数量
    document.getElementById("Amount").value = getQueryVariable("Amount");
    //设置商品总金额
    document.getElementById("TotalAmount").innerHTML = "￥" + getQueryVariable("Amount")*getQueryVariable("Price")

    //设置用户名
    updateUsername();
}
function back(){
    document.location.href = "store.html"
}
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
function updateTotal(){
    perPrice = document.getElementById("Price").innerText.substring(1);
    amount = document.getElementById("Amount").value;
    totalPrice = perPrice*amount;
    document.getElementById("TotalAmount").innerText = "￥" + totalPrice;
}
function increase(){
    document.getElementById("Amount").value = Number(document.getElementById("Amount").value) + 1;
    updateTotal();
}
function decrease(){
    originAmount = Number(document.getElementById("Amount").value);
    if(originAmount > 0){
        document.getElementById("Amount").value = originAmount - 1;
        updateTotal();
    }
}
function createOrder(){
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
                alert("Create an order successfully!");
                document.location.href = "store.html";
            }
            else{
                alert("Fail! There's something wrong.")
            }
        }
    }
    //open设置请求方式和请求路径
    xmlhttp.open("post", "/createOrder", true); //一个servlet，后面还可以写是否同步
    //设置发送数据为表单
    xmlhttp.setRequestHeader("Content-type","application/x-www-form-urlencoded");
    //send 发送
    const username = document.getElementById("Username").innerText;
    const goodName = document.getElementById("GoodName").innerText;
    const price = document.getElementById("Price").innerText.substring(1);
    xmlhttp.send("username=" + username + "&goodname=" + goodName + "&price=" + price + "&amount=" + amount);

}