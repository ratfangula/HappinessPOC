$(document).ready(function () {
    $(".edit").hide();
});

$(".editbutton").click(function () {
    if ($(this).text() == "Finish")
    {
        var valueschanged = false;
        var displayname = $(this).closest('span').siblings('.display.itemname');
        var editname = $(this).closest('span').siblings('.edit.itemname').children('input');

        var displaydescription = $(this).closest('span').siblings('.display.itemdescription');
        var editdescription = $(this).closest('span').siblings('.edit.itemdescription').children('input');

        if ($(displayname).text() != $(editname).val()) {
            //alert("Different");
            //alert($(this).closest('span').siblings('.display.itemname').text());
            //alert($(this).closest('span').siblings('.edit.itemname').children('input').val());
            valueschanged = true;
        }
        if ($(displaydescription).text() != $(editdescription).val()) {
            //alert("Different");
            //alert($(this).closest('span').siblings('.display.itemname').text());
            //alert($(this).closest('span').siblings('.edit.itemname').children('input').val());
            valueschanged = true;
        }
        if (valueschanged)
        {
            if (confirm("Values have changed.  Accept and store changes?"))
            {
                //alert('values changed');
                $(displayname).text($(editname).val());
                $(displaydescription).text($(editdescription).val());
            }
            
        }
        $(this).text("Edit");
    } else {
        //alert($(this).text());

        $(this).text("Finish");
    }
    $(this).closest("span").siblings(".edit").toggle();
    $(this).closest("span").siblings(".display").toggle();
    
});

//$(".edit").focusout(function () {
//    //$(this).hide().siblings(".display").show().text($(this).val());
//    $(this).siblings(".display").show();
//    $(this).siblings(".edit").hide();
//    $(this).text("Edit");

//});