const menuIcon = document.querySelector(".ham-menu")
const navbar = document.querySelector(".navigation")
const section = document.querySelector(".banner")
const section2 = document.querySelector(".banner")

menuIcon.addEventListener("click", () => {
    navbar.classList.toggle("change")
});

window.addEventListener("scroll", function () {
    var header = document.querySelector("header");
    header.classList.toggle("sticky", window.scrollY > 0);
});


/*function myFunction() {
    document.getElementById("lul").style.background = "url('../Img/Stadt.jpg')  center no-repeat ";
    document.getElementById("lul").style.backgroundSize = "cover";
}*/
/*function swap(sheet) {
document.getElementById("pagestyle").setAttribute("href", sheet);

}*/
$(function () {
    $('#lul').click(function (e) {
        $('#pagestyle').attr('href', $(this).attr('rel'));
        e.preventDefault();
        window.location.href = "../Home/NewYork";
    });
    
    



});
