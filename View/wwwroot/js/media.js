$(document).ready(() => {
    function media() {
        if (window.innerWidth < 1210) {
            $(".left-panel-navigate").removeClass("d-flex");
            $(".left-panel-navigate").hide();
            $(".body-box").css("margin","0 50px 0 50px");
        }if(window.innerWidth > 1210){
            $(".left-panel-navigate").addClass("d-flex");
            $(".body-box").css("margin","0 50px 0 330px");
        }
    }

    window.addEventListener("resize", media);
});