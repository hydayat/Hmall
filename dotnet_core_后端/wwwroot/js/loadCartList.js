let goods = [];
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
           goods = JSON.parse(xmlhttp.responseText);
        }
    }
}
//open设置请求方式和请求路径
xmlhttp.open("get", "/showCart", false); //一个servlet，后面还可以写是否同步
xmlhttp.send();
//列表渲染
console.log("goods的内容为：");
console.log(goods);
for(var i = 0; i < goods.length; i++){
    console.log("i=" + i.toString());
    console.log("goods.length=" + goods.length.toString());
    goodName = goods[i].goodname;
    price = goods[i].price;
    amount = goods[i].amount;
    total = price * amount;
    document.write(
        "<div id = 'Item" + i + "' class='Item'>" +
        "<div class='Atom'>" +
        "<div class='ItemImg' style='background-image: url(img/Good/" + goodName + ".jpg);'></div>" +
        "</div>" +
        "<div class='Atom'>" +
        "<p id='GoodName" + i +"' align='center' class='GoodName'>" + goodName + "</p>" +
        "</div>" +
        "<div class='Atom'>" +
        "<p id='Price" + i + "' align='center' class='Price'>￥" + price + "</p>" +
        "</div>" +
        "<div class='Atom'>" +
        "<p id='Amount" + i + "' align='center' class='Amount'>" + amount + "</p>" +
        "</div>" +
        "<div class='Atom'>" +
        "<p align='center' class='Total'>￥" + total + "</p>" +
        "</div>" +
        "<div class='Atom'>" +
        "<div>" +
        "<button class='BuyButton' onclick='buy(" + i + ")'>Buy</button><br>" +
        "<button class='DeleteButton' onclick='remove(" + i + ")'>Delete</button>" +
        "</div>" +
        "</div>" +
        "</div>" +
        "<hr id='Hr" + i + "'>"
    );
}