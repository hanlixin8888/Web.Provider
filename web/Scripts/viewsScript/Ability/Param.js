var grid;

$(function () {
    InitSearch();
    InitDiv();
    InitGrid();
});

//初始化搜索框
function InitSearch() {

}

//初始化弹出页
function InitDiv() {
    $("#divOrdSubject").css("display", "none");
    $("#divWareh").css("display", "none");

    $("#txtOrdSubjectCode").searchbox("textbox").attr({ readonly: 'true' });
    $("#ORD_SUBJECT_CODE").searchbox("textbox").attr({ readonly: 'true' });
    $("#WAREH_ID").searchbox("textbox").attr({ readonly: 'true' });
}

//初始化表格
function InitGrid() {
    var ord_subject_id = $("#txtOrdSubjectId").attr("value");
    var wareh_id = $("#txtWarehId").searchbox("getValue");

    grid = $('#grdAbility').datagrid({
        title: 'RDC仓库作业能力列表', //表格标题
        url: '/Ability/Query', //请求数据的页面
        queryParams: {
            ord_subject_id: ord_subject_id,
            wareh_id: wareh_id
        },
        //width: 815,
        height: 410,
        //sortName: 'ID', //排序字段
        idField: 'ID', //标识字段,主键
        // iconCls: '', //标题左边的图标           
        //nowrap: false, //是否换行，True 就会把数据显示在一行里
        // striped: true, //True 奇偶行使用不同背景色
        //collapsible: false, //可折叠
        // sortOrder: 'desc', //排序类型
        //remoteSort: true, //定义是否从服务器给数据排序
        // fit: true,
        singleSelect: true,
        fitColumns: false, //自适应
        columns: [[
                    { field: 'ORD_SUBJECT_ID', title: '主题编码', hidden: true },
                    { field: 'ORD_SUBJECT_CODE', title: '主题编码' },
                    { field: 'ORD_SUBJECT_NAME', title: '主题名称' },
                    { field: 'WAREH_ID', title: 'RDC仓库编码' },
                    { field: 'WAREH_NAME', title: 'RDC仓库名称' },
                    { field: 'START_DATE', title: '起始日期', align: 'center', formatter: function (value, row, index) { return changeDateFormat(value); } },
                    { field: 'END_DATE', title: '截止日期', align: 'center', formatter: function (value, row, index) { return changeDateFormat(value); } },
                    { field: 'DISP_QTY', title: '日发货件数' },
                    { field: 'RCV_BOX_QTY', title: '日收货箱数' }
                ]],
        toolbar: [{
            id: 'btnAdd',
            text: '新增',
            iconCls: 'icon-add',
            handler: function () {
                add();
            }
        }, '-', {
            id: 'btnEdit',
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () {
                edit();
            }
        }, '-', {
            id: 'btnRemove',
            text: '删除',
            iconCls: 'icon-remove',
            handler: function () {
                del();
            }
        }, '-', {
            id: 'btnImport',
            text: '导入',
            iconCls: 'icon-upload',
            handler: function () {
                openImport();
            }
        }, '-', {
            id: 'btnExport',
            text: '导出',
            iconCls: 'icon-download',
            handler: function () {
                $("#f1").submit();
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
        }
    });
    //清空选择
    grid.datagrid('clearSelections');

    onRefreshButton();
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
    $('#dlg').dialog('open').dialog('setTitle', '录入RDC日期范围作业能力');
    $('#fm').form('clear');
    $("#ORD_SUBJECT_CODE").searchbox("setValue", '');
    $("#WAREH_ID").searchbox("setValue", '');
    url = '/Ability/Add';
}

//修改
function edit() {
    var rows = grid.datagrid('getSelections');
    $('#dlg').dialog('open').dialog('setTitle', '修改RDC日期范围作业能力');
    $('#fm').form('load', rows[0]);
    $('#fm').form('load', {
        START_DATE: changeDateFormat(rows[0].START_DATE),
        END_DATE: changeDateFormat(rows[0].END_DATE)
    });
    $("#ORD_SUBJECT_CODE").searchbox("setValue", rows[0].ORD_SUBJECT_CODE);
    $("#WAREH_ID").searchbox("setValue", rows[0].WAREH_ID);
    url = '/Ability/Edit';
}

//保存
function save() {
    var ord_subject_id = $("#ORD_SUBJECT_CODE").searchbox("getValue");
    var wareh_id = $("#WAREH_ID").searchbox("getValue");
    var start_date = $('#START_DATE').datebox('getValue');
    var end_date = $('#END_DATE').datebox('getValue');

    if (ord_subject_id == "") {
        $.messager.alert('信息', "请选择订货会主题", 'info');
        return;
    }
    if (wareh_id == "") {
        $.messager.alert('信息', "请选择RDC仓库", 'info');
        return;
    }
    if (start_date == "") {
        $.messager.alert('信息', "请输入起始日期", 'info');
        return;
    }
    if (end_date == "") {
        $.messager.alert('信息', "请输入截止日期", 'info');
        return;
    }
    var d1 = new Date(start_date);
    var d2 = new Date(end_date);
    if (Date.parse(d1) - Date.parse(d2) >= 0) {
        $.messager.alert('信息', "起始日期必须小于截止日期", 'info');
        return;
    }
    
    $('#fm').form('submit', {
        url: url,
        success: function (data) {
            eval('data=' + data);
            if (data.success) {
                $('#dlg').dialog('close');
                InitGrid();
                //grid.datagrid('reload');
            } else {
                $.messager.alert('错误', data.msg, 'error');
                //$('#fm').form('clear');
            }
        }
    });
}

//删除
function del() {
    var arr = [];
    var rows = grid.datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        arr.push(rows[i].ID);
    }
    $.messager.confirm('提示信息', '您确认要删除吗?', function (data) {
        if (data) {
            $.ajax({
                url: '/Ability/Delete?ids=' + arr.join(','),
                type: 'GET',
                timeout: 1000,
                error: function () {
                    $.messager.alert('错误', '删除失败!', 'error');
                },
                success: function (data) {
                    eval('data=' + data);
                    if (data.success) {
                        grid.datagrid('reload');
                        grid.datagrid('clearSelections');
                    } else {
                        $.messager.alert('错误', data.msg, 'error');
                    }
                }
            });
        }
    });
}

//导入
function openImport() {
    $('#dlg_import').dialog('open').dialog('setTitle', '请选择文件');
}

//订货会弹出页
function DlgSearchOrdSubject() {
    ShowDlgOrdSubject('tbOrdSubject', $("#ipt_ordSubjectCode").val());
}
function selectOrdSubject(value, name) {
    $("#divOrdSubject").css("display", "block");
    ShowDlgOrdSubject('tbOrdSubject', '');
    $("#divOrdSubject").dialog({
        modal: true,
        resizable: true,
        title: "选择订货会主题",
        height: 400,
        width: 540,
        buttons: [{
            text: "确定",
            iconCls: 'icon-ok',
            handler: function () {
                var row = $('#tbOrdSubject').datagrid('getSelected');

                $("#txtOrdSubjectId").val(row.ID);
                $("#txtOrdSubjectCode").searchbox("setValue", row.CODE);

                $("#ORD_SUBJECT_ID").val(row.ID);
                $("#ORD_SUBJECT_CODE").searchbox("setValue", row.CODE);
                $("#ORD_SUBJECT_NAME").val(row.NAME);
                
                $("#divOrdSubject").dialog("close");
            }
        },
        {
            text: "取消",
            iconCls: 'icon-cancel',
            handler: function () {
                $("#divOrdSubject").dialog("close");
            }
        }]
    });
}

//RDC仓库弹出页
function DlgSearchWareh() {
    ShowDlgRDCOrder('tbWareh', $("#txtOrdSubjectCode").val(), $("#ipt_warehouseCode").val());
}
function selectWareh(value, name) {
    var ord_subject_code = $("#txtOrdSubjectCode").searchbox("getValue");
    if (ord_subject_code == "") {
        $.messager.alert('提示', "请先选择主题编码!", 'info');
        return false;
    }

    $("#divWareh").css("display", "block");

    ShowDlgRDCOrder('tbWareh', ord_subject_code, '');
    $("#divWareh").dialog({
        modal: true,
        resizable: true,
        title: "选择RDC仓库",
        height: 400,
        width: 540,
        buttons: [{
            text: "确定",
            iconCls: 'icon-ok',
            handler: function () {
                var row = $('#tbWareh').datagrid('getSelected');
                $("#txtWarehId").searchbox("setValue", row.WAREH_ID);
                $("#WAREH_ID").searchbox("setValue", row.WAREH_ID);
                $("#WAREH_NAME").val(row.WAREH_NAME);
                $("#divWareh").dialog("close");
            }
        },
        {
            text: "取消",
            iconCls: 'icon-cancel',
            handler: function () {
                $("#divWareh").dialog("close");
            }
        }]
    });
}