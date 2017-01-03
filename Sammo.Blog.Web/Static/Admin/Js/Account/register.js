$(document).ready(function () {
    $('.i-checks').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green',
    });
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
        },
        success: function (element) {
            element.closest('.form-group').removeClass('has-error').addClass('has-success');
        },
        errorElement: "span",
        errorClass: "help-block m-b-none",
        validClass: "help-block m-b-none"
    });
            
    var RegisterViewModel = function () {
        this.el = "#registerForm";
        this.data = {
            registerModel: {
                userName: '',
                email: '',
                password: '',
                confirmPassword: ''
            },
            user:{}
        };
        
        var registerUrl = 'Admin/Account/RegisterAsync';
        this.methods = {
            register: function () {
                var self = this;
                //alert(registerUrl);
                //toastr.success('Without any options', 'Simple notification!');
                this.validation();
                if ($('#registerForm').valid()) {
                    this.$http.post(registerUrl, self.user).then(function (result) {
                        alert(result);
                    });
                };
            },
            validation: function () {
                $('#registerForm').validate({
                    rules: {
                        userName: {
                            required: true,
                            minlength: 4,
                            maxlength:20
                        },
                        email: {
                            required: true,
                            email: true
                        },
                        password: {
                            required: true,
                            minlength:6,
                            maxlength:20
                        },
                        confirmPassword: {
                            required:true,
                            equalTo:'#password'
                        }
                    }
                });
            }
        };
    }

    new Vue(new RegisterViewModel());
});
