

window.addEventListener("scroll", function () {
    var header = document.querySelector("header");
    header.classList.toggle("sticky", window.scrollY > 0);
    var nav = document.querySelector("nav");
    nav.style.paddingTop = "30px";

    if (window.scrollY == 0) {
        var nav = document.querySelector("nav");
        nav.style.paddingTop = "50px";
    }
    if (window.scrollY < 1700) {  //opacity für main seite ganz oben
        var p = document.querySelector("p");
        p.style.opacity = 0.4;
    }
    if (window.scrollY > 1700) { //opacity für text von main seite ganz unter
        var p = document.querySelector("p");
        p.style.opacity = 1;
    }
    if (window.scrollY > 600) {   //opacity fürs scrollen
        var oppicture = document.querySelector("section");
        oppicture.style.opacity = 0.1;
    }
    if (window.scrollY < 600) { //opacity wenn seite ganz oben !wichtig
        var oppicture = document.querySelector("section");
        oppicture.style.opacity = 1;
    }
});
