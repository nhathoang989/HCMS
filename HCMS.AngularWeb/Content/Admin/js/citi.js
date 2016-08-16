$(document).ready(function () {
    
    $(".rightMenu span").on('click', function () {        
        $(this).parent().find(".ulRightMenu").toggle(500);
    });
    $(".icon-pencil").click(function(){
        $(this).children("tr .OneThis").addClass("abc");
    });
    $(".Add").click(function(){
        $(".newTag").toggle(200);
    })
    $(".btn-cancel").click(function(){
        $(".newTag").toggle(200);
    })
});

function editprice(p1, p2) {

    var price = $("input." + p1).val();

    var formatPrice = price.replace(/,/g, "");
    var new_price = FormatNumber(formatPrice);

    $("input." + p1).val(new_price);
    $("input." + p2).val(formatPrice);
}


function FormatNumber(nStr) {
    nStr += '';
    var x = nStr.split(',');
    var x1 = x[0];
    //alert(x1);
    var x2 = x.length > 1 ? ',' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}

//function editprice(p1, p2) {
//    var price = $("input." + p1).val();

//    var formatPrice = price.replace(/./g, "");
//    var new_price = FormatNumber(formatPrice);

//    $("input." + p1).val(new_price);
//    $("input." + p2).val(formatPrice);

//}


//function FormatNumber(nStr) {
//    nStr += '';
//    var x = nStr.split('.');
//    var x1 = x[0];
//    var x2 = x.length > 1 ? '.' + x[1] : '';
//    var rgx = /(\d+)(\d{3})/;
//    while (rgx.test(x1)) {
//        x1 = x1.replace(rgx, '$1' + '.' + '$2');
//    }
//    return x1 + x2;
//}

jQuery(function () {
    jQuery("input.price").on("keydown", function (e) {
        var key = e.charCode || e.keyCode || 0;
        return (
            key == 8 || key == 9 || key == 46 || (key >= 37 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105));
    });
});

