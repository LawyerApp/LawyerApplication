/* Add here all your JS customizations */

$("#Img").change(function () {
    var fileExtension = $(this).val().split('.').pop().toLowerCase();
    $("[data-valmsg-for='Img']").text("");
    if (!(fileExtension == "jpg" ||
        fileExtension == "jpeg" ||
        fileExtension == "png" ||
        fileExtension == "svg" ||
        fileExtension == "gif")) {
        $("[data-valmsg-for='Img']").text("This file content type not supported.")
        $("#btnSubmit").attr("type", "button")
    }
    else {
        $("[data-valmsg-for='Img']").text("")
        $("#btnSubmit").attr("type", "submit")
    }
})