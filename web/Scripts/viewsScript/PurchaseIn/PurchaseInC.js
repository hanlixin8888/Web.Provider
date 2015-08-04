var grid, cbProgress;




//初始化明细表格
function InitGrid() {
    var ord_id = $.trim($("#txtOrdSubjectCode").attr("value"));
    var goodscode = $.trim($("#txtGoodsCode").attr("value"));
    var goodsname = $.trim($("#txtGoodsName").attr("value"));
    var CheckTimeS = $('#CheckTimeS').datetimebox('getValue');
    var CheckTimeE = $('#CheckTimeE').datetimebox('getValue');
    grid = $('#tab_list').datagrid({
        name: 'tbl_data',
        url: '/PurchaseIn/Query',
        title: '采购进货单列表',
        queryParams: {
            OrderNoOrGoodsCode: ord_id,
            GoodsCode:goodscode,
            GoodsName: goodsname,
            CheckTimeS: CheckTimeS,
            CheckTimeE: CheckTimeE
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
        //pagination: true,
        //pageSize: 5,
        //pageNumber: 1,
        //pageList: [5,10, 20, 30, 40, 50],
        idField: 'GoodsID',
        columns: [[
        //{ field: 'ck', checkbox: true },
                    //{ field: 'GoodsID', title: '商品ID', hidden: true },
                    { field: 'SheetID', title: '采购进货单号', align: 'center', sortable: true },
                    { field: 'WarehouseName', title: '仓位名称', align: 'center', sortable: true },
                    { field: 'GoodsCode', title: '商品编码',  align: 'center', sortable: true },
                    { field: 'GoodsName', title: '商品名称',  align: 'center', sortable: true },
                    { field: 'GoodsSpec', title: '规格',  align: 'center', sortable: true },
                    { field: 'UnitName', title: '单位', align: 'center', sortable: true },
                    { field: 'PkgClassName', title: '包装层次', align: 'center', sortable: true },
                    { field: 'PkgUnitName', title: '包装单位', align: 'center', sortable: true },
                    { field: 'PkgNumber', title: '包装数量', align: 'center', sortable: true },
                    { field: 'PkgQty', title: '包装整件数', align: 'center', sortable: true },
                    { field: 'BulkQty', title: '零数', align: 'center', sortable: true },
                    { field: 'NotifyQty', title: '通知数量', align: 'center', sortable: true },
                    { field: 'Qty', title: '收货数量', align: 'center', sortable: true },
                    { field: 'PkgCost', title: '整件单价', align: 'center', sortable: true },
                    { field: 'Cost', title: '单价',  align: 'center', sortable: true },
                    { field: 'CostValue', title: '金额', align: 'center', sortable: true },
                    { field: 'Flag', title: '订单状态', align: 'center', sortable: true, formatter: formatflag },
                    { field: 'CheckDate', title: '下单时间',  align: 'center', sortable: true, formatter: ChangeDateFormat },
                    { field: 'Editor', title: '制单人', align: 'center', sortable: true },
                    { field: 'Remark', title: '备注',  align: 'center', sortable: true },
                    { field: 'VenderName', title: '供应商',  align: 'center', sortable: true }
                    

        ]],
        pagination: true,
        pageSize: 20,
        pageNumber: 1,
        pageList: [10, 20, 30, 40, 50],
        rownumbers: true, //行号
        onSortColumn: function (sort, order) {
            grid.datagrid('reload');
        }
    });
    //清空选择
    //grid.datagrid('clearSelections');
}

function formatflag(val) {
    if (val != null) {
        if (val == 20) {
            return "待处理";
        }
        if (val == 40) {
            return "在执行";
        }
        if (val == 100) {
            return "完结";
        }
        if (val == 90) {
            return "已审核";
        }
    }
}

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

