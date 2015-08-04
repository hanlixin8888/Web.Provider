
$(function () {
    $("#username").focus(function () {
        if ($(this).val() == this.defaultValue) {
            $(this).val("");
        }
    })
  .blur(function () {
      if ($(this).val() == "") {
          $(this).val(this.defaultValue);
      }
  });

    var showPwd = document.getElementById("showPassword");
    var pwd = document.getElementById("password");
    showPwd.onfocus = function () {
        if (this.value != "请输入密码") return;
        this.style.display = "none";
        pwd.style.display = "";
        pwd.value = "";
        pwd.focus();
    }
    pwd.onblur = function () {
        if (this.value != "") return;
        this.style.display = "none";
        showPwd.style.display = "";
        showPwd.value = "请输入密码";
    }


});

function ValidateLog() {
    //debugger;
    var userName = $("#username");
    var Pwd = $("#password");

    if (!userName.val() || userName.val() == "请输入用户名") {
        alert("请输入用户名!");
        userName.focus();
        return false;
    }

    if (!Pwd.val()) { 
        alert("请输入密码!");
        $("#showPassword").focus();
        return false;
    }
    return true;
}

