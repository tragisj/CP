

$(document).ready(function () {



    $("div:contains('" + search + "')").each(function () {
        var regex = new RegExp(search, 'gi');
        $(this).html($(this).text().replace(regex, "<span class='red'>" + search + "</span>"));
    });

    function greenColor() {
        $(".project - name - display").css("color", "green");
    }


});