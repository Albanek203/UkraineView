$(document).ready(() => {
    $(".dropdown-list").children("ul").slideUp(0);
})

$(".dropdown-list").on("click", function () {
        if ($(this).children("ul").is(':visible')) {
            ToggleDropdownIcon($(this).children("div").children("i"));
            $(this).children("ul").slideUp(200);
        } else {
            ToggleDropdownIcon($(this).children("div").children("i"));
            $(this).children("ul").slideDown(200);
        }
    }
);

function ToggleDropdownIcon(object) {
    if (object.hasClass("fa-angle-down")) {
        object.removeClass("fa-angle-down").addClass("fa-angle-up");
    } else {
        object.removeClass("fa-angle-up").addClass("fa-angle-down");
    }
}