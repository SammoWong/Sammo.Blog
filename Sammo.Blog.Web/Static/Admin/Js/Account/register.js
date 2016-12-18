$(document).ready(function () {
    $('.i-checks').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green',
    });

    //var viewModel = new Vue ({
    //    el : "#registerForm",
    //    data : {
    //        registerModel: {
    //            userName: '',
    //            email: '',
    //            password: '',
    //            confirmPassword: ''
    //        }
    //    },
    //    methods : {
    //        register: function () {
    //            alert('注册成功');
    //        }
    //    }
    //});
    var RegisterViewModel = function () {
        this.el = "#registerForm";
        this.data = {
            registerModel: {
                userName: '',
                email: '',
                password: '',
                confirmPassword: ''
            }
        };
        this.validators = {
            userName:function(val){
                if(/^[A-Za-z0-9_\-\u4e00-\u9fa5]{1,10}$/.test(val)){
                    toastr.success('Without any options', 'Simple notification!');
                }
            }
        };
        var registerUrl = '/Admin/Account/Register';
        this.methods = {
            register: function () {
                var self = this;
                alert(registerUrl);
                toastr.success('Without any options', 'Simple notification!');
            }
        };
    }

    new Vue(new RegisterViewModel());
});
