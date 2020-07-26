function showCart(){
	show("cart.html");
}
function showOrder(){
	show("order.html");
}
function show(url) {
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
			if(xmlhttp.status === 200){//已登录
				document.location.href = url;
			}
			else {//未登录
				alert("You need to sign in!");
				document.location.href = "index.html";
			}
		}
	}
	//open设置请求方式和请求路径
	xmlhttp.open("get", "/isSign", true); //一个servlet，后面还可以写是否同步
	xmlhttp.send();
}