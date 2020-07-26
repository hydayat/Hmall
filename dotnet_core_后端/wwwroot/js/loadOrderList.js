let orders = [];
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
        if(xmlhttp.status === 200){
            console.log("response的内容为：");
            console.log(xmlhttp.responseText);
            orders = JSON.parse(xmlhttp.responseText);
        }
    }
}
//open设置请求方式和请求路径
xmlhttp.open("get", "/showOrders", false); //一个servlet，后面还可以写是否同步
xmlhttp.send();

//列表渲染
for(var i = 0; i < orders.length; i++){
    goodName = orders[i].goodname;
    date = orders[i].time.substring(0,19);
    price = orders[i].price;
    amount = orders[i].amount;
    total = price*amount;
    document.write(
        "<div class='Item'>" +
        "<div class='Atom'>" +
        "<div class='ItemImg' style='background-image: url(img/Good/" + goodName + ".jpg);'></div>" +
        "</div>" +
        "<div class='Atom'>" +
        "<p align='center' class='GoodName'>" + goodName + "</p>" +
        "</div>" +
        "<div class='Atom'>" +
        "<p align='center' class='Date'>" + date.replace(/T/, " ") + "</p>" +
        "</div>" +
        "<div class='Atom'>" +
        "<p align='center' class='Price'>￥" + price + "</p>" +
        "</div>" +
        "<div class='Atom'>" +
        "<p align='center' class='Amount'>"+ amount + "</p>" +
        "</div>" +
        "<div class='Atom'>" +
        "<p align='center' class='Total'>￥" + total + "</p>" +
        "</div>" +
        "</div>" +
        "<hr>"
    );
}