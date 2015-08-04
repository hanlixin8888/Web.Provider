$(function () {
    $("#tt").tabs({}); //加载显示标签
    //加载菜单
    loadMenu();
    $('#loginOut').click(function () {
        $.messager.confirm('系统提示', '您确定要退出本次登录吗?', function (r) {

            if (r) {
                location.href = '';
            }
        });
    })
});
function loadMenu() {
    //通过 ajax方法，获取当前用户的所有的菜单组合组 和项。
    $.post("/Home/MenuData", {}, function (data) {
        var dataObj = eval("(" + data + ")");
        for (var i = 0; i < dataObj.length; i++) {
            var title = dataObj[i].text;
            var url = dataObj[i].url;
            var childr = dataObj[i].children;
            $('#aa').accordion('add', {
                title: title,
                content: creatCenterUl(i),
                selected: false,
                iconCls: 'iocn-ok'
            });
            initMenuItemContent(childr, i, url);
            //绑定左边菜单栏点击事件
            bindLeftMenuclick(i);
        }
    });
}
function creatCenterUl(str) {
    var strId = "t" + str;
    return '<ul id=' + strId + ' class="easyui-tree"></ul>';
}
///初始化菜单组的内容
function initMenuItemContent(actions, str, url) {
    $('#t' + str).tree({
        data: actions,
        animate: true
    });
}
//绑定左边菜单栏点击事件
function bindLeftMenuclick(str) {
    $('#t' + str).tree({
        onClick: function (node) {//单击事件  
            var a = $("#tabs").tabs('tabs');
            var strNode = node.attributes
            if (strNode.url != "") {
                if (a.length >= 8) {
                    //$.messager.alert('My Title', '已经存在8个了  请先关闭！', 'warning');
                      $.messager.show({
                                title: '提示',
                                msg: '窗口太多，请先关闭！'
                            });
                    return false;
                }
                else {
                    addTab(node.text, strNode.url, "icon-save", true)
                }
            }
            return false;
        }
    })
}
function addTab(subtitle, url, icon, closeable) {
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: creatCenterFrame(url),
            closable: closeable,
            icon: icon
        });
    } else {
        $('#tabs').tabs('select', subtitle);
    }
    tabClose();
}
function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    })
    /*为选项卡绑定右键*/
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });

        var subtitle = $(this).children(".tabs-closable").text();

        $('#mm').data("currtab", subtitle);
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}
//绑定右键菜单事件
function creatCenterFrame(url) {
    return '<iframe src="' + url + '" scrolling="auto" frameborder="0" height="99%"  width="100%"></iframe>';
}