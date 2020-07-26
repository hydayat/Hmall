window.onload = function(){
    //加载商品图片
    document.getElementById("Img1").style.backgroundImage = "url(img/Good/M1A1.jpg)";
    document.getElementById("Img2").style.backgroundImage = "url(img/Good/M1A2.jpg)";
    document.getElementById("Img3").style.backgroundImage = "url(img/Good/M41.jpg)";
    document.getElementById("Img4").style.backgroundImage = "url(img/Good/MarderIII.jpg)";
    document.getElementById("Img5").style.backgroundImage = "url(img/Good/Merkava.jpg)";
    document.getElementById("Img6").style.backgroundImage = "url(img/Good/Panther.jpg)";
    document.getElementById("Img7").style.backgroundImage = "url(img/Good/Wespe.jpg)";
    document.getElementById("Img8").style.backgroundImage = "url(img/Good/T-55A.jpg)";
    document.getElementById("Img9").style.backgroundImage = "url(img/Good/StugIII.jpg)";
    document.getElementById("Img10").style.backgroundImage = "url(img/Good/M109A3G.jpg)";
    //加载用户名
    updateUsername();
}
function nextPage(){
    document.location.href = "store2.html";
}