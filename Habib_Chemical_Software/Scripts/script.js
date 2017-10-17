//(function ($) {
//    $(document).ready(function () {
//        $('#cssmenu > ul > li > a').click(function () {
//            $('#cssmenu li').removeClass('active');
//            $(this).closest('li').addClass('active');
//            var checkElement = $(this).next();
//            if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
//                $(this).closest('li').removeClass('active');
//                checkElement.slideUp('normal');
//            }
//            if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
//                $('#cssmenu ul ul:visible').slideUp('normal');
//                checkElement.slideDown('normal');
//            }
//            if ($(this).closest('li').find('ul').children().length == 0) {
//                return true;
//            } else {
//                return false;
//            }
//        });

//        $('input:file').change(function () {
//            alert('Test');
//            $("#productEditSpan").attr('hidden', 'hidden');
//        });
//    });
//})(jQuery);

$(document).ready(function () {
    $('input[type=file]').change(function () {
        $("#productEditSpan").html($(this).val());
    });

    var counter = 2;

    $("#addContactTextBoxes").click(function () {

        if (counter > 4) {
            alert("Only 4 textboxes allow");
            return false;
        }

        var addtext = '<div class="form-group"  id="contactGroup'+ counter +'"> ' +
            '<div class="input-group"> ' +
                '<span class="input-group-addon">Name</span> ' +
            '<input type="text" name="name' + counter + '" id="name' + counter +'" class="form-control" /> ' +
                '<span class="input-group-addon">Contact</span> ' +
            '<input type="text" name="contact' + counter + '" id="contact' + counter +'" class="form-control" /> ' +
                '</div > ' +
            '</div>';

        $("#contactGroup1").after(addtext);


        counter++;
    });

    $("#removeButton").click(function () {
        if (counter == 1) {
            alert("No more textbox to remove");
            return false;
        }

        counter--;

        $("#TextBoxDiv" + counter).remove();

    });

    $("#getButtonValue").click(function () {

        var msg = '';
        for (i = 1; i < counter; i++) {
            msg += "\n Textbox #" + i + " : " + $('#textbox' + i).val();
        }
        alert(msg);
    });
})