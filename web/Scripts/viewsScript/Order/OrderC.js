var grid, cbProgress;

//初始化
$(function () {
    InitSearch();
    InitGrid();
    onRefreshButton();
});

//初始化搜索框
function InitSearch() {
    cbProgress = $('#PROGRESS').combobox({
        url: '/Data/GetBfCodeDetails?code=DDT_PROG',
        valueField: 'CODE',
        textField: 'NAME'
    });

    $("#divOrdSubject").css("display", "none");

    $("#txtOrdSubjectCode").searchbox("textbox").attr({ readonly: 'true' });
    $("#ORD_SUBJECT_CODE").searchbox("textbox").attr({ readonly: 'true' });
}

//function RefGrid() {
//    var tableInfo = "";
//    var tableObj = document.getElementById('tab_list');
//    for (var i = 0; i < tableObj.rows.length; i++) {    //遍历Table的所有Row
//        for (var j = 0; j < tableObj.rows[i].cells.length; j++) {   //遍历Row中的每一列
//            tableInfo += tableObj.rows[i].cells[j].innerText;   //获取Table中单元格的内容
//            //tableInfo += "   ";
//            alert(tableObj.rows[i].cells[j].innerText);
//        }
//        //tableInfo += "\n";
//    }
//}


function ChangeDateFormat(val) {
    if (val != null) {
        var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
        //月份为0-11，所以+1，月份小于10时补个0
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        return date.getFullYear() + "-" + month + "-" + currentDate;
    }

    return "";
}

//初始化表格
function InitGrid() {
    var ord_id = $.trim($("#txtOrdSubjectCode").attr("value"));
    grid = $('#tab_list').datagrid({
        name:'tbl_data',
        url: '/OrderCheck/Query',
        title: '商品列表',
        queryParams: {
            OrderNoOrGoodsCode: ord_id,
        },
        //width: 815,
        height: 730,
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
        pagination: true,
        pageSize: 20,
        pageNumber: 1,
        pageList: [10, 20, 30, 40, 50],
        idField: 'GoodsID',
        columns: [[
        //{ field: 'ck', checkbox: true },
                    //{ field: 'GoodsID', title: '商品ID', hidden: true },
                    { field: 'SHEETID', title: '订单号', align: 'center', sortable: true },
                    { field: 'RATIONDATE', title: '发货时间', width: 150, align: 'center', sortable: true, formatter: ChangeDateFormat},
                    { field: 'GOODSCODE', title: '商品编码',  align: 'center', sortable: true },
                    { field: 'GOODSNAME', title: '商品名称',  align: 'center', sortable: true },
                    { field: 'QTY', title: '订单数量', align: 'center', sortable: true },
                    { field: 'REALQTY', title: '实发数量', align: 'center', sortable: true },
                    { field: 'CHECKQTY', title: '校验数量', align: 'center', sortable: true }

				]],
        //toolbar: [{
        //    id: 'btnAdd',
        //    text: '新增',
        //    iconCls: 'icon-add',
        //    handler: function () {
        //        add();
        //    }
        //}, '-', {
        //    id: 'btnEdit',
        //    text: '修改',
        //    iconCls: 'icon-edit',
        //    handler: function () {
        //        edit();
        //    }
        //}, '-', {
        //    id: 'btnRemove',
        //    text: '删除',
        //    iconCls: 'icon-remove',
        //    handler: function () {
        //        del();
        //    }
        //}, '-', {
        //    id: 'btnDetail',
        //    text: '任务明细',
        //    iconCls: 'icon-detail',
        //    handler: function () {
        //        detail();
        //    }
        //}],
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
    $('#btnDetail').linkbutton('disable');

    var rows = grid.datagrid('getSelections');
    if (rows.length == 1) {
        $('#btnDetail').linkbutton('enable');

        if (rows[0].PROGRESS == '100') {//已确认
            $('#btnEdit').linkbutton('enable');
            $('#btnRemove').linkbutton('enable');
        }
        else {
            $('#btnEdit').linkbutton('disable');
            $('#btnRemove').linkbutton('disable');
        }
    }
}

//控制按钮
function onRefreshButton2(progress) {
    $('#btnParams').linkbutton('disable');
    $('#btncmdAllot').linkbutton('disable');
    $('#btnendAllot').linkbutton('disable');
    $('#btnredoAllot').linkbutton('disable');
    $('#btncmdMerge').linkbutton('disable');
    $('#btnendMerge').linkbutton('disable');
    $('#btnredoMerge').linkbutton('disable');
    $('#btncmdSmall').linkbutton('disable');

    if (progress == '100') {//已确认
        $('#btncmdAllot').linkbutton('enable');
        $('#btnParams').linkbutton('enable');
    }
    else if (progress == '200') {//已生成配发计划
        $('#btnendAllot').linkbutton('enable');
        $('#btnredoAllot').linkbutton('enable');
    }
    else if (progress == '300') {//已结束配发计划
        $('#btncmdMerge').linkbutton('enable');
        $('#btnredoAllot').linkbutton('enable');
    }
    else if (progress == '400') {//已生成到仓计划
        $('#btnendMerge').linkbutton('enable');
        $('#btnredoAllot').linkbutton('enable');
        $('#btnredoMerge').linkbutton('enable');
        $('#btncmdSmall').linkbutton('enable');
    }
    else if (progress == '500') {//已结束到仓计划
        $('#btnredoAllot').linkbutton('enable');
        $('#btnredoMerge').linkbutton('enable');
        $('#btncmdSmall').linkbutton('enable');
    }
    else {

    }
}

//增加
function add() {
    $('#dlg').dialog('open').dialog('setTitle', '录入分拨任务单');
    $('#fm').form('clear');

    var now = new Date();
    var vnow = now.getFullYear() + "-" + (now.getMonth() + 1) + "-" + now.getDate();

    $('#fm').form('load', {
        CODE: '00000000',
        DOC_DATE: vnow
    });
    cbProgress.combobox('setValue', "100"); //已确认

    url = '/Distr/Add';
}

//修改
function edit() {
    var rows = grid.datagrid('getSelections');
    $('#dlg').dialog('open').dialog('setTitle', '修改分拨任务单');
    $('#fm').form('clear');
    $('#fm').form('load', rows[0]);
    $('#fm').form('load', {
        DOC_DATE: changeDateFormat(rows[0].DOC_DATE),
        BEGIN_SUMMITED_TIME: changeDateFormat(rows[0].BEGIN_SUMMITED_TIME),
        END_SUMMITED_TIME: changeDateFormat(rows[0].END_SUMMITED_TIME)
    });
    $("#ORD_SUBJECT_CODE").searchbox("setValue", rows[0].ORD_SUBJECT_CODE);

    url = '/Distr/Edit';
}

//保存
function save() {
    var name = $("#NAME").attr("value");
    var ord_subject_code = $("#ORD_SUBJECT_CODE").searchbox("getValue");

    if (name == "") {
        $.messager.alert('提示', '分拨任务名称不能为空', 'warning');
        return false;
    }
    if (ord_subject_code == "") {
        $.messager.alert('提示', '主题编码不能为空', 'warning');
        return false;
    }

    $('#fm').form('submit', {
        url: url,
        success: function (data) {
            eval('data=' + data);
            if (data.success) {
                $('#dlg').dialog('close');
                grid.datagrid('reload');
            } else {
                $.messager.alert('错误', data.msg, 'error');
            }
        }
    });
}

//删除
function del() {
    var ids = [];
    var rows = grid.datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        ids.push(rows[i].ID);
    }
    $.messager.confirm('提示信息', '您确认要删除吗?', function (data) {
        if (data) {
            $.ajax({
                url: '/Distr/Delete?ids=' + ids.join(','),
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

//明细
function detail() {
    $('#dlg2').dialog('open').dialog('setTitle', '分拨任务明细');
    var rows = grid.datagrid('getSelections');

    $('#fm2').form('clear');
    $('#fm2').form('load', rows[0]);
    $('#fm2').form('load', {
        _ID: rows[0].ID,
        _CODE: rows[0].CODE,
        _NAME: rows[0].NAME,
        _DOC_DATE: changeDateFormat(rows[0].DOC_DATE),
        _ORD_SUBJECT_ID: rows[0].ORD_SUBJECT_ID,
        _ORD_SUBJECT_CODE: rows[0].ORD_SUBJECT_CODE,
        _ORD_SUBJECT_NAME: rows[0].ORD_SUBJECT_NAME,
        _PROGRESS: convertCombobox(cbProgress, rows[0].PROGRESS),
        _MARKET_PRO: rows[0].MARKET_PRO,
        _BEGIN_SUMMITED_TIME: changeDateFormat(rows[0].BEGIN_SUMMITED_TIME),
        _END_SUMMITED_TIME: changeDateFormat(rows[0].END_SUMMITED_TIME)
    });

    onRefreshButton2(rows[0].PROGRESS);
    selectDetail(rows[0].ID, rows[0].ORD_SUBJECT_ID);
}

//查询明细
function selectDetail(distr_task_id, ord_subject_id) {
    $.ajax({
        url: '/Distr/QueryDetail?distr_task_id=' + distr_task_id + '&ord_subject_id=' + ord_subject_id,
        type: 'GET',
        beforeSend: function () {
            showprogress();
        },
        complete: function () {
            closeprogress();
            selectCollect(distr_task_id, ord_subject_id);
        },
        error: function () {
            $.messager.alert('错误', '查询明细失败!', 'error');
        },
        success: function (data) {
            eval('data=' + data);
            $('#fm3').form('clear');
            $('#fm3').form('load', data);
            $('#fm3').form('load', {
                ROW_COUNT: convertNumber(data.ROW_COUNT),
                CNTT_QTY_SUM: convertNumber(data.CNTT_QTY_SUM),
                AMOUNT_SUM: convertNumber(data.AMOUNT_SUM),
                PLAN_BATCH_MAX: convertNumber(data.PLAN_BATCH_MAX),
                PLAN_BATCH_MIN: convertNumber(data.PLAN_BATCH_MIN),
                PROD_CLS_ID_COUNT: convertNumber(data.PROD_CLS_ID_COUNT),
                PROD_ID_COUNT: convertNumber(data.PROD_ID_COUNT),

                BATCH_DATE_MAX: changeDateFormat(data.BATCH_DATE_MAX),
                BATCH_DATE_MIN: changeDateFormat(data.BATCH_DATE_MIN),
                INI_ALLOT_DATE_MAX: changeDateFormat(data.INI_ALLOT_DATE_MAX),
                INI_ALLOT_DATE_MIN: changeDateFormat(data.INI_ALLOT_DATE_MIN),
                ALLOT_DATE_MAX: changeDateFormat(data.ALLOT_DATE_MAX),
                ALLOT_DATE_MIN: changeDateFormat(data.ALLOT_DATE_MIN)
            });
        }
    });
}

//查询到仓明细
function selectCollect(distr_task_id, ord_subject_id) {
    $.ajax({
        url: '/Distr/QueryCollect?distr_task_id=' + distr_task_id + '&ord_subject_id=' + ord_subject_id,
        type: 'GET',
        beforeSend: function () {
            showprogress();
        },
        complete: function () {
            closeprogress();
        },
        error: function () {
            $.messager.alert('错误', '查询明细失败!', 'error');
        },
        success: function (data) {
            eval('data=' + data);
            $('#fm4').form('clear');
            $('#fm4').form('load', data);
            $('#fm4').form('load', {
                ROW_COUNT: convertNumber(data.ROW_COUNT),
                INI_QTY_SUM: convertNumber(data.INI_QTY_SUM),
                CNTT_QTY_SUM: convertNumber(data.CNTT_QTY_SUM),
                PROD_CLS_ID_COUNT: convertNumber(data.PROD_CLS_ID_COUNT),
                PROD_ID_COUNT: convertNumber(data.PROD_ID_COUNT),

                MAX_ALLOT_DATE_MAX: changeDateFormat(data.MAX_ALLOT_DATE_MAX),
                MIN_ALLOT_DATE_MIN: changeDateFormat(data.MIN_ALLOT_DATE_MIN),
                TOWAREH_DATE_MAX: changeDateFormat(data.TOWAREH_DATE_MAX),
                TOWAREH_DATE_MIN: changeDateFormat(data.TOWAREH_DATE_MIN)
            });
        }
    });
}

//生成配发计划
function cmdAllot() {
    $.messager.confirm('提示信息', '您确认要生成配发计划吗?', function (data) {
        if (data) {
            var distr_task_id = $("#_ID").attr("value");
            var ord_subject_id = $("#_ORD_SUBJECT_ID").attr("value");
            $.ajax({
                url: '/Distr/CmdAllot?distr_task_id=' + distr_task_id + '&ord_subject_id=' + ord_subject_id,
                type: 'GET',
                beforeSend: function () {
                    showprogress();
                },
                complete: function () {
                    closeprogress();
                    selectDetail(distr_task_id, ord_subject_id);
                },
                error: function () {
                    $.messager.alert('错误', data.msg, 'error');
                },
                success: function (data) {
                    eval('data=' + data);
                    grid.datagrid('reload');
                    $('#_PROGRESS').combobox('setValue', convertCombobox(cbProgress, '200'));
                    onRefreshButton2('200');
                    //$.messager.alert('提示', '生成配发计划成功!', 'info');
                }
            });
        }
    });
}

//重做配发
function redoAllot() {
    $.messager.confirm('提示信息', '您确认要重做配发计划吗?', function (data) {
        if (data) {
            var distr_task_id = $("#_ID").attr("value");
            var ord_subject_id = $("#_ORD_SUBJECT_ID").attr("value");
            $.ajax({
                url: '/Distr/RedoAllot?distr_task_id=' + distr_task_id + '&ord_subject_id=' + ord_subject_id,
                type: 'GET',
                beforeSend: function () {
                    showprogress();
                },
                complete: function () {
                    closeprogress();
                    selectDetail(distr_task_id, ord_subject_id);
                },
                error: function () {
                    $.messager.alert('错误', data.msg, 'error');
                },
                success: function (data) {
                    eval('data=' + data);
                    grid.datagrid('reload');
                    $('#_PROGRESS').combobox('setValue', convertCombobox(cbProgress, '100'));
                    onRefreshButton2('100');
                    //$.messager.alert('提示', '重做配发计划成功!', 'info');
                }
            });
        }
    });
}

//结束配发计划
function endAllot() {
    $.messager.confirm('提示信息', '您确认要结束配发计划吗?', function (data) {
        if (data) {
            var distr_task_id = $("#_ID").attr("value");
            var ord_subject_id = $("#_ORD_SUBJECT_ID").attr("value");
            $.ajax({
                url: '/Distr/EndAllot?distr_task_id=' + distr_task_id + '&ord_subject_id=' + ord_subject_id,
                type: 'GET',
                beforeSend: function () {
                    showprogress();
                },
                complete: function () {
                    closeprogress();
                },
                error: function () {
                    $.messager.alert('错误', data.msg, 'error');
                },
                success: function (data) {
                    eval('data=' + data);
                    if (data.success) {
                        if (data.result == 'true') {
                            grid.datagrid('reload');
                            $('#_PROGRESS').combobox('setValue', convertCombobox(cbProgress, '300'));
                            onRefreshButton2('300');
                            data.result = "结束配发计划成功";
                        }
                        //$.messager.alert('提示', data.result, 'info');
                        $.messager.show( {title: '提示', msg: data.result});
                    } else {
                        $.messager.alert('错误', data.msg, 'error');
                    }
                }
            });
        }
    });
}

//生成到仓计划
function cmdMerge() {
    $.messager.confirm('提示信息', '您确认要生成到仓计划吗?', function (data) {
        if (data) {
            var distr_task_id = $("#_ID").attr("value");
            var ord_subject_id = $("#_ORD_SUBJECT_ID").attr("value");
            $.ajax({
                url: '/Distr/CmdMerge?distr_task_id=' + distr_task_id + '&ord_subject_id=' + ord_subject_id,
                type: 'GET',
                beforeSend: function () {
                    showprogress();
                },
                complete: function () {
                    closeprogress();
                    selectDetail(distr_task_id, ord_subject_id);
                },
                error: function () {
                    $.messager.alert('错误', data.msg, 'error');
                },
                success: function (data) {
                    eval('data=' + data);
                    grid.datagrid('reload');
                    $('#_PROGRESS').combobox('setValue', convertCombobox(cbProgress, '400'));
                    onRefreshButton2('400');
                    //$.messager.alert('提示', '生成到仓计划成功!', 'info');
                }
            });
        }
    });
}

//重做到仓
function redoMerge() {
    $.messager.confirm('提示信息', '您确认要重做到仓计划吗?', function (data) {
        if (data) {
            var distr_task_id = $("#_ID").attr("value");
            var ord_subject_id = $("#_ORD_SUBJECT_ID").attr("value");
            $.ajax({
                url: '/Distr/RedoMerge?distr_task_id=' + distr_task_id + '&ord_subject_id=' + ord_subject_id,
                type: 'GET',
                beforeSend: function () {
                    showprogress();
                },
                complete: function () {
                    closeprogress();
                    selectDetail(distr_task_id, ord_subject_id);
                },
                error: function () {
                    $.messager.alert('错误', data.msg, 'error');
                },
                success: function (data) {
                    eval('data=' + data);
                    grid.datagrid('reload');
                    $('#_PROGRESS').combobox('setValue', convertCombobox(cbProgress, '300'));
                    onRefreshButton2('300');
                    //$.messager.alert('提示', '重做到仓计划成功!', 'info');
                }
            });
        }
    });
}

//结束到仓计划
function endMerge() {
    $.messager.confirm('提示信息', '您确认要结束到仓计划吗?', function (data) {
        if (data) {
            var distr_task_id = $("#_ID").attr("value");
            $.ajax({
                url: '/Distr/EndMerge?distr_task_id=' + distr_task_id,
                type: 'GET',
                beforeSend: function () {
                    showprogress();
                },
                complete: function () {
                    closeprogress();
                },
                error: function () {
                    $.messager.alert('错误', data.msg, 'error');
                },
                success: function (data) {
                    eval('data=' + data);
                    if (data.success) {
                        if (data.result == 'true') {
                            grid.datagrid('reload');
                            $('#_PROGRESS').combobox('setValue', convertCombobox(cbProgress, '500'));
                            onRefreshButton2('500');
                            data.result = "结束到仓计划成功";
                        }
                        $.messager.show({ title: '提示', msg: data.result });
                    } else {
                        $.messager.alert('错误', data.msg, 'error');
                    }
                }
            });
        }
    });
}

//少量款并期
function cmdSmall() {
    $.messager.confirm('提示信息', '您确认要少量款并期吗?', function (data) {
        if (data) {
            var distr_task_id = $("#_ID").attr("value");
            $.ajax({
                url: '/Distr/CmdSmall?distr_task_id=' + distr_task_id,
                type: 'GET',
                beforeSend: function () {
                    showprogress();
                },
                complete: function () {
                    closeprogress();
                },
                error: function () {
                    $.messager.alert('错误', data.msg, 'error');
                },
                success: function (data) {
                    eval('data=' + data);
                    grid.datagrid('reload');
                    //$('#_PROGRESS').combobox('setValue', convertCombobox(cbProgress, '200'));
                    //onRefreshButton2('200');
                    //$.messager.alert('提示', '少量款并期成功!', 'info');
                    $.messager.show({ title: '提示', msg: '少量款并期成功!' });
                }
            });
        }
    });
}

//修改参数
function updateParams() {
    var starttime = $('#_BEGIN_SUMMITED_TIME').datebox('getValue');
    var endtime = $('#_END_SUMMITED_TIME').datebox('getValue');

    if (starttime != "" && endtime != "") {
        var starttimes = starttime.split('-');
        var endtimes = endtime.split('-');
        var starttimeTemp = starttimes[0] + '/' + starttimes[1] + '/' + starttimes[2];
        var endtimesTemp = endtimes[0] + '/' + endtimes[1] + '/' + endtimes[2];

        if (Date.parse(new Date(starttimeTemp)) < Date.parse(new Date(endtimesTemp))) {
            submitParams();
        }
        else {
            $.messager.alert('提示', '开始合同时间必须小于结束合同时间!', 'warning');
        }
    }
    else {
        submitParams();
    }
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

//弹出页 订货会主题
//
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
                if (name == 'txtOrdSubjectCode') {
                    $("#txtOrdSubjectId").val(row.ID);
                    $("#txtOrdSubjectCode").searchbox("setValue", row.CODE);
                }
                else {
                    $('#fm').form('load', {
                        ORD_SUBJECT_ID: row.ID,
                        ORD_SUBJECT_NAME: row.NAME
                    });
                    $("#ORD_SUBJECT_CODE").searchbox("setValue", row.CODE);
                }
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
function DlgSearchOrdSubject() {
    ShowDlgOrdSubject('tbOrdSubject', $("#ipt_ordSubjectCode").val());
}