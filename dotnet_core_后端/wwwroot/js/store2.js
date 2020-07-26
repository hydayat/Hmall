window.onload = function(){
    //加载商品图片
    document.getElementById("Img1").style.backgroundImage = "url(img/Good/Challenger.jpg)";
    document.getElementById("Img2").style.backgroundImage = "url(img/Good/Chieftain.jpg)";
    document.getElementById("Img3").style.backgroundImage = "url(img/Good/Hetzer.jpg)";
    document.getElementById("Img4").style.backgroundImage = "url(img/Good/JS3-Stalin.jpg)";
    document.getElementById("Img5").style.backgroundImage = "url(img/Good/M4-Sherman.jpg)";
    document.getElementById("Img6").style.backgroundImage = "url(img/Good/M26-Pershing.jpg)";
    document.getElementById("Img7").style.backgroundImage = "url(img/Good/M60A1.jpg)";
    document.getElementById("Img8").style.backgroundImage = "url(img/Good/M2A2.jpg)";
    // document.getElementById("Img9").style.backgroundImage = "url(img/Good/StugIII.jpg)";
    // document.getElementById("Img10").style.backgroundImage = "url(img/Good/M109A3G.jpg)";
    document.getElementById("Good9").style.background = "none";
    document.getElementById("Good10").style.background = "none";

    updateUsername();
}
function lastPage(){
    document.location.href = "store.html";
}