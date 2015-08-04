var grid, cbProgress;

//初始化表格
function InitGrid() {
    var SVENDERID = $('#SVENDERID').combobox('getValue');
    grid = $('#tab_list').datagrid({
        name:'tbl_data',
        url: '/User/Query',
        title: '供应商用户列表',
        queryParams: {
            SVENDERID: SVENDERID,
        },
        //width: 815,
        height: 530,
        //border : false,
        //fit: false,
        fitColumns: false,
        //nowrap: true,
        rownumbers: true,
        //showFooter: true,
        //loadMsg: '正在加载信息...',
        //frozen: true,
        //sortName: "CODE", //排序设置
        singleSelect: true,
        idField: 'GoodsID',
        columns: [[
        //{ field: 'ck', checkbox: true },
                    //{ field: 'GoodsID', title: '商品ID', hidden: true },
                    { field: 'VUSERCODE', title: '登录名', align: 'center', sortable: true },
                    { field: 'USERNAME', title: '用户名', width: 150, align: 'center', sortable: true},
                    { field: 'VENDERNAME', title: '供应商名称',  align: 'center', sortable: true },
                    { field: 'VENDERCODE', title: '供应商编码',  align: 'center', sortable: true }
        ]],
        toolbar: [{
            id: 'btnAdd',
            text: '新增',
            iconCls: 'icon-add',
            handler: function () {
                add();
            }
        }, '-', {
            id: 'btnRemove',
            text: '删除',
            iconCls: 'icon-remove',
            handler: function () {
                del();
            }
        }],
        pagination: true,
        pageSize: 20,
        pageNumber: 1,
        pageList: [10, 20, 30, 40, 50],
        rownumbers: true, //行号
        onLoadSuccess: function (data) {
            onRefreshButton();
        },
        onSelect: function (rowIndex, rowData) {
            onRefreshButton();
        },
        onUnselect: function (rowIndex, rowData) {
            onRefreshButton();
        },
        onSortColumn: function (sort, order) {
            grid.datagrid('reload');
        }
    });
    //清空选择
    //grid.datagrid('clearSelections');
}

//控制按钮
function onRefreshButton() {
    $('#btnAdd').linkbutton('enable');
    $('#btnEdit').linkbutton('disable');
    $('#btnRemove').linkbutton('disable');

    //$('#btnImport').linkbutton('disable');
    // $('#btnExport').linkbutton('disable');

    var rows = grid.datagrid('getSelections');
    if (rows.length == 1) {
        $('#btnEdit').linkbutton('enable');
        $('#btnRemove').linkbutton('enable');
    }
}


//增加
function add() {
    $('#p1').dialog('open').dialog('setTitle', '新增用户信息');
    $("#txtUserName").val("");
    $("#txtUserCode").val("");
    $("#txtpassword").val("");
    $("#txtpwd").val("");
    $('#VENDERID').combogrid("setValue","0"); 
    url = '/User/Saves';
}

////修改
//function edit() {
//    var rows = grid.datagrid('getSelections');
//    $('#p1').dialog('open').dialog('setTitle', '修改用户信息');
    
//    $("#txtUserCode").val("");
//    $("#txtpassword").val("");
//    $("#txtpwd").val("");
//    $('#VENDERID').combobox("setText", "");
//    $('#venderuser').form('load', rows[0]);
//    $("#txtUserName").val(rows[0].USERNAME);
//    $("#txtUserCode").val(rows[0].VUSERCODE);
//    //$('#venderuser').form('load', { 
//    //    DOC_DATE: changeDateFormat(rows[0].DOC_DATE),
//    //    BEGIN_SUMMITED_TIME: changeDateFormat(rows[0].BEGIN_SUMMITED_TIME),
//    //    END_SUMMITED_TIME: changeDateFormat(rows[0].END_SUMMITED_TIME)
//    //});
//    //$("#ORD_SUBJECT_CODE").searchbox("setValue", rows[0].ORD_SUBJECT_CODE);

//    url = '/Distr/Edit';
//}



//删除
function del() {
    var ids = [];
    var rows = grid.datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        ids.push(rows[i].VUSERCODE);
    }
    $.messager.confirm('提示信息', '您确认要删除吗?', function (data) {
        if (data) {
            var form = $('#venderuser');
            form.form('submit', {
                url: '/User/Delete' + '?ids=' + ids.join(','),
                success: function (data) {
                    eval('data=' + data);
                    if (data.success) {
                        InitGrid();
                    } else {
                        $.messager.alert('错误', data.msg, 'error');
                    }
                    $("#txtOrdSubjectCode").val("");
                }
            })

        }
    });
}


function save() {
    var code = $.trim($("#txtUserCode").attr("value"));
    var pwd1 = $.trim($("#txtpassword").attr("value"));
    var pwd2 = $.trim($("#txtpwd").attr("value"));
    var vid = $('#VENDERID').combobox('getValue');
   
    if (code == "") {
        $.messager.alert('提示', '登录名不能为空', 'warning');
        return false;
    }
    if (pwd1 == "" || pwd2 == "") {
        $.messager.alert('提示', '密码不能为空', 'warning');
        return false;
    }
    if (pwd1.length < 6 || pwd2.length < 6) {
        $.messager.alert('提示', '密码长度不能小于6位', 'warning');
        return false;
    }
    if (vid == null || vid == 0) {
        $.messager.alert('提示', '请选择供应商', 'warning');
        return false;
    }


    $('#venderuser').form('submit', {
        url: url,
        success: function (data) {
            eval('data=' + data);
            if (data.success) {
                $('#p1').dialog('close');
                InitGrid();
            } else {
                $.messager.alert('错误', data.msg, 'error');
                //alert("保存失败！请检查");
            }
        }
    });
}


//提交参数
function submitParams() {
    $('#fm2').form('submit', {
        url: '/Distr/UpdateParams',
        success: function (data) {
            eval('data=' + data);
            if (data.success) {
                grid.datagrid('reload');
                $.messager.alert('提示', '参数修改成功!', 'info');
            } else {
                $.messager.alert('错误', data.msg, 'error');
            }
        }
    });
}

