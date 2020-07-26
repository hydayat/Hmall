window.onload = function () {
    updateUsername();
}
function back(){
    document.location.href = "store.html";
}
function buy(index){
    goodName = document.getElementById("GoodName" + index).innerText;
    price = document.getElementById("Price" + index).innerText.substring(1);
    amount = document.getElementById("Amount" + index).innerText;
    url = "createOrder.html?GoodName=" + goodName + "&Price=" + price + "&Amount=" + amount;
    document.location.href = url;
}
function remove(index){
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
                document.getElementById("Item" + index).remove();
                document.getElementById("Hr" + index).remove();
            }
            else{
                alert("Fail to delete!");
            }
        }
    }
    //open设置请求方式和请求路径
    const username = document.getElementById("Username").innerText;
    const goodname = document.getElementById("GoodName" + index).innerText;
    const url = "/deleteCart?username=" + username + "&goodname=" + goodname;
    xmlhttp.open("get", url, true); //一个servlet，后面还可以写是否同步
    xmlhttp.send();
}