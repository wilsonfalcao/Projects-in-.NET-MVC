$(document).ready(function () {

    var $menu = $("#menuF");

    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $menu.fadeOut('fast', function () {
                $(this).removeClass("default")
                       .addClass("fixed transbg")
                       .fadeIn('fast');
                document.getElementById("imagem1").className = "imagem2";

            });
        } else if ($(this).scrollTop() <= 100 && $menu.hasClass("fixed")) {
            $menu.fadeOut('fast', function () {
                $(this).removeClass("fixed transbg")
                       .addClass("default")
                       .fadeIn('fast');
                document.getElementById("imagem1").className = "imagemcss";
            });
        }
    });
});