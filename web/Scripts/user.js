
/* 显示遮罩层 */
function showOverlay(obj) {
    var w = $("#" + obj).width();
    var h = $("#" + obj).height();
    var t = document.getElementById(obj).offsetTop;
    var l = document.getElementById(obj).offsetLeft;

    $("#overlay").css({ width: w + 'px', height: h + 'px', left: l + 'px', top: t + 'px' });
    $("#overlay").fadeTo(200, 0.05);
    $("#loading").css("display", "block");
}

function showOverlay2(obj,lay,load) {
    var w = $("#" + obj).width();
    var h = $("#" + obj).height();
    var t = document.getElementById(obj).offsetTop;
    var l = document.getElementById(obj).offsetLeft;

    $("#" + lay).css({ width: w + 'px', height: h + 'px', left: l + 'px', top: t + 'px' });
    $("#" + lay).fadeTo(200, 0.05);
    $("#" + load).css("display", "block");
}

/* 隐藏覆盖层 */
function hideOverlay() {
    $("#overlay").fadeOut(200);
    $("#loading").css("display", "none");
}

function hideOverlay2(lay, load) {
    $("#" + lay).fadeOut(200);
    $("#" + load).css("display", "none");
}

$(function () {
    $(".easyui-dialog").dialog({
        onMove: function (left, top) {             
            if (left <= 0) {
                $(this).dialog("move", { left: 0 });
            }
            if (top <= 0) {
                $(this).dialog("move", { top: 0 });
            }
        }
    });
});


//转换 下拉列表 
function convertCombobox(cmb, value) {
    cmb.combobox('setValue', value);
    var val = cmb.combobox('getText');
    return val;
}

function convertNumber(value) {
    var num = parseFloat(value);
    if (num > 0 || num < 0) {
        return value;
    }
    else {
        return "";
    }
}


//显示 进度条
function showprogress(){
    var win = $.messager.progress({
        title: 'Please waiting',
        //msg: '正在处理,请稍待...',
        text: '正在处理,请稍待...',
        interval: 400
    });
}

function closeprogress() {
    $.messager.progress('close');
}

