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

    //$("#createCompanyForm").validate({
    //        rules{
                
    //        }
    //    }
    //);

    //Company/Create Add input group Button
    $("#addContactTextBoxes").click(function () {
        var elementCounter = $("input[name^='dynamicName']");
        counter = elementCounter.length + 1;
        if (counter > 4) {
            alert("You can not add any more contact");
            return false;
        }

        var addtextpart1 = '<div class="form-group"  id="contactGroup'+ counter +'"> ' +
            '<div class="input-group"> ' +
                '<span class="input-group-addon">Name</span> ' +
            '<input type="text" name="dynamicName' + counter + '" id="name' + counter +'" class="form-control" /> ' +
                '<span class="input-group-addon">Contact</span> ' +
            '<input type="text" name="dynamicContact' + counter + '" id="contact' + counter +'" class="form-control" /> ' +
                '</div > ' +
            '</div>';

        //var addtextpart1 = '<div class="form-group" id="contactGroup' + counter + '"> <div class="input-group" id="inputgroup' + counter + '"> <span class="input-group-addon">Name</span></div > </div>';
        //var addtextpart2 = '<input type= "text" name= "name' + counter + '" id= "name' + counter +'" class="form-control" />';
        //var addtextpart3 = '<span class="input-group-addon">Contact</span> ';
        //var addtextpart4 = '<input type="text" name="contact' + counter + '" id="contact' + counter + '" class="form-control" /> ';
        //var addtextpart5 = '</div > </div>';

        $("#contactGroup" + (counter - 1)).after(addtextpart1);
        //$("#inputgroup" + (counter)).append(addtextpart2).validate({
        //    rules: {
        //        field: {
        //            required: true
        //        }
        //    }
        //});
        //$("#inputgroup" + (counter)).append(addtextpart3);
        //$("#inputgroup" + (counter)).append(addtextpart4).validate({
        //    rules: {
        //        field: {
        //            required: true,
        //            digits: true
        //        }
        //    }
        //});
        //$("#inputgroup" + (counter)).append(addtextpart5);

        //$("#createCompanyForm").removeData('validator');
        //$("#createCompanyForm").removeData('unobtrusiveValidation');
        //$.validator.unobtrusive.parse("#createCompanyForm");
        //$("#createCompanyForm").validate();
        $("input[name^='dynamicName']").each(function () {
            $(this).rules("add", {
                required: true,
                messages: {
                    required: "Please Enter Contact Person Name"
                }
            });
        });

        $("input[name^='dynamicContact']").each(function () {
            $(this).rules("add", {
                required: true,
                digits: true,
                messages: {
                    required: "Please Enter a Valid Mobile Number",
                    digits: "Please Enter a Valid Mobile Number"
                }
            });
        });

        counter++;
    });

    //Company/Create Remove input group Button
    $("#removeContactTextBoxes").click(function () {
        if (counter == 2) {
            alert("Minimum 1 Contact is Required");
            return false;
        }

        counter--;

        $("#contactGroup" + counter).remove();

    });

    $("#getButtonValue").click(function () {

        var msg = '';
        for (i = 1; i < counter; i++) {
            msg += "\n Textbox #" + i + " : " + $('#textbox' + i).val();
        }
        alert(msg);
    });
})