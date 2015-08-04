/// 一些常自定义的方法
//防止初始化验证
$(function () {
    //$('input.easyui-validatebox').validatebox('disableValidation')//////////
    //.focus(function () { $(this).validatebox('enableValidation'); })
    //.blur(function () { $(this).validatebox('validate') });
});


/**
 * easyUI - mask
 * easyUI - 遮罩
 * @author isea533
 * @author http://blog.csdn.net/isea533
 * 
 *
 * Requires:
 * 依赖:
 * 		jquery.js
 * 		jquery.easyui.js
 * 
 * How to use:
 * 使用方法:
 * 		$('.class').easyMask('show'[,options]);
 *		$('.class').easyMask('hide'[,options]);
 *
 *		$.easyMask('.class','show'[,options]);
 *		$.easyMask('.class','hide'[,options]);
 * 		
 *		options = {msg:''}
 *		default options = $.easyMask.options;
 */
(function ($) {
    //$对象
    $.fn.easyMask = function (method, options) {
        return $.easyMask(this, method, options);
    }
    //全局函数
    $.easyMask = function (target, method, options) {
        var tar = target || 'body';
        var $targ = $(tar);
        var opt = $.extend({}, $.easyMask.options, options);
        var method = $.easyMask.methods[method];
        if (method) {
            return method(tar, opt);
        }
        return $targ;
    };

    $.easyMask.methods = {
        show: function (target, options) {
            return $(target).each(function () {
                var $targ = $(this);
                //如果当前对象不是relative,那就添加该属性
                //$("#hehe").css("position")
                if ($targ.css('position') != 'relative') {
                    $targ.data('position', $targ.css('position'));
                    $targ.css('position', 'relative');
                }
                $('<div class=\'datagrid-mask\' style=\"display:block\"></div>').appendTo($targ);
                var msg = $('<div class=\'datagrid-mask-msg\' style=\"display:block;left:50%\"></div>')
							.html(options.msg).appendTo($targ);
                msg.css("marginLeft", -msg.outerWidth() / 2);
            });
        },
        hide: function (target, options) {
            return $(target).each(function () {
                $here = $(this);
                $here.children('.datagrid-mask').remove();
                $here.children('.datagrid-mask-msg').remove();
                //还原position属性
                if ($here.data().position != undefined) {
                    $here.css("position", $here.data().position);
                    $here.removeData('position');
                }
            });
        }
    }

    $.easyMask.options = {
        msg: 'Loading...'
    };
})(jQuery)

//jquery.datagrid 扩展 
;(function () {
    $.extend($.fn.datagrid.methods, {
        //显示遮罩 
        loading: function (jq, loadingMsg) {
            return jq.each(function () {
                $(this).datagrid("getPager").pagination("loading");
                var opts = $(this).datagrid("options");
                var wrap = $.data(this, "datagrid").panel;
                opts.loadMsg = loadingMsg || opts.loadMsg;
                if (opts.loadMsg) {
                    $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: wrap.width(), height: wrap.height() }).appendTo(wrap);
                    $("<div class=\"datagrid-mask-msg\"></div>").html(opts.loadMsg).appendTo(wrap).css({ display: "block", left: (wrap.width() - $("div.datagrid-mask-msg", wrap).outerWidth()) / 2, top: (wrap.height() - $("div.datagrid-mask-msg", wrap).outerHeight()) / 2 });
                }
            });
        }
  ,
        //隐藏遮罩 
        loaded: function (jq) {
            return jq.each(function () {
                $(this).datagrid("getPager").pagination("loaded");
                var wrap = $.data(this, "datagrid").panel;
                wrap.find("div.datagrid-mask-msg").remove();
                wrap.find("div.datagrid-mask").remove();
            });
        }
    });
})(jQuery);


/**
 * From扩展
 * getData 获取数据接口
 * 
 * @param {Object} jq
 * @param {Object} params 设置为true的话，会把string型"true"和"false"字符串值转化为boolean型。
 */
$.extend($.fn.form.methods, {
    getData: function (jq, params) {
        var formArray = jq.serializeArray();
        var oRet = {};
        for (var i in formArray) {
            if (typeof (oRet[formArray[i].name]) == 'undefined') {
                if (params) {
                    oRet[formArray[i].name] = (formArray[i].value == "true" || formArray[i].value == "false") ? formArray[i].value == "true" : formArray[i].value;
                }
                else {
                    oRet[formArray[i].name] = formArray[i].value;
                }
            }
            else {
                if (params) {
                    oRet[formArray[i].name] = (formArray[i].value == "true" || formArray[i].value == "false") ? formArray[i].value == "true" : formArray[i].value;
                }
                else {
                    oRet[formArray[i].name] += "," + formArray[i].value;
                }
            }
        }
        return oRet;
    }
});
//使用方式：
//$('#ff').form('getData', true);