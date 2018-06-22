(function ($, W, D) {
    var JQUERY4U = {};

    JQUERY4U.UTIL =
    {
        setupFormValidation: function () {
            //form validation rules
            $("#registerform").validate({
                rules: {
                    datepicker: "required",
                    TextName: "required",
                    TextEmail: {
                        required: true,
                        email: true
                    },
                    
                },
                messages: {
                    datepicker: "Please enter a date",
                    TextName: "Please enter your lastname",
                    TextEmail: "Please enter a valid email address",
                    
                },
                submitHandler: function (form) {
                    form.submit();
                }
            });
        }
    }

    //when the dom has loaded setup form validation rules
    $(D).ready(function ($) {
        JQUERY4U.UTIL.setupFormValidation();
    });

})(jQuery, window, document);