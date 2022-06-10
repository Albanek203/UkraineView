$(".regionUA").mouseover(function () {
    $(this).css("cursor", "pointer");
    $(this).css("fill", "rgba(196, 196, 196, 0.8)");
});

$(".regionUA").mouseout(function () {
    $(this).css("fill", "rgba(215, 215, 215, 0.8)");
});

$(".regionUA").on("click", function () {
    $("#routeMapValue").val(this.dataset.element);
    $("#mapForm").submit();
});