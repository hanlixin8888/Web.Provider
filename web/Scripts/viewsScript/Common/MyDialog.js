//订货会主题
function ShowDlgOrdSubject(tablID, code, name) {
    $('#' + tablID).datagrid({
        url: '/ShowDialog/GetOrdSubjectList',
        queryParams: { Code: code, Name: name },
        //title: '订货主题选择',
        height: 280,
        //nowrap: true,
        rownumbers: true,
        //showFooter: true,
        idField: 'ID',
        //loadMsg: '正在加载信息...',
        pagination: true,
        singleSelect: true,
        pageList: [10, 20, 30], //{ 
        columns: [[
                    { field: 'ck', checkbox: true },
                    { field: 'ID', title: 'ID', hidden: true },
                    { field: 'CODE', title: '主题编号' },
					{ field: 'NAME', title: '主题描述', width: 150 },
                    { field: 'BRAND_ID', title: '品牌'},
                    { field: 'YEAR', title: '年份' },
                    { field: 'PRVS_VAL', title: '预配金额' }
				]]
    });
}

//分拨任务单
function ShowDlgDistrTask(tablID, code, ordSubjectCode) {
    $('#' + tablID).datagrid({
        url: '/ShowDialog/GetDistrTaskList',
        queryParams: { Code: code, SubjectCode: ordSubjectCode },
        //title: '分拨任务选择',
        height: 280,
        fitColumns: true,
        nowrap: true,
        rownumbers: true,
        showFooter: true,
        idField: 'ID',
        //loadMsg: '正在加载信息...',
        pagination: true,
        singleSelect: true,
        pageList: [10, 20, 30], //{ 
        columns: [[
                    { field: 'ck', checkbox: true, align: 'left', width: 50 },
                    { field: 'ID', title: 'ID', hidden: true },
                    { field: 'CODE', title: '分拨任务编码', width: 80, sortable: true, resizable: true },
                    { field: 'NAME', title: '分拨任务名称', width: 100, sortable: true, resizable: true },
                    { field: 'ORD_SUBJECT_ID', title: '订货会主题ID', hidden: true },
					{ field: 'ORD_SUBJECT_CODE', title: '主题编码', width: 80, sortable: true, resizable: true },
                    { field: 'ORD_SUBJECT_NAME', title: '主题名称', width: 100 }
				]]
    });
}

function ShowWareHouse(tablID, warehouseCode) {
    $('#' + tablID).datagrid({
        url: '/ShowDialog/GetWareHouseList',
        queryParams: { Code: warehouseCode },
        title: '仓库信息',
        height: 300,
        fitColumns: true,
        nowrap: true,
        rownumbers: true,
        showFooter: true,
        idField: 'CODE',
        loadMsg: '正在加载信息...',
        pagination: true,
        singleSelect: true,
        pageList: [10, 20, 30], //{ 
        columns: [[
                    { field: 'ck', checkbox: true, align: 'left', width: 50 },
					{ field: 'CODE', title: '仓库编号', width: 80, sortable: true, resizable: true },
					{ field: 'NAME', title: '仓库名称', width: 100 }
				]]
    });
}

function ShowDlgBpmsWarehouse(tablID, warehouseCode,ordSubjectCode){
     $('#' + tablID).datagrid({
         url: '/ShowDialog/GetBpmsWarehouseList',
        queryParams: { Code: warehouseCode, SubjectCode: ordSubjectCode},
        title: '订货仓库选择',
        height: 280,
        fitColumns: true,
        nowrap: true,
        rownumbers: true,
        showFooter: true,
        loadMsg: '正在加载信息...',
        pagination: true,
        singleSelect: true,
        pageList: [10, 20, 30], //{ 
        columns: [[
                    { field: 'ck', checkbox: true, align: 'left', width: 50 },
					{ field: 'WAREH_ID', title: '仓库编码', width: 80, sortable: true, resizable: true },
                    { field: 'WAREH_NAME', title: '仓库名称', width: 100 },
                    { field: 'ORD_SUBJECT_CODE', title: '订货主题编码', width: 80, sortable: true, resizable: true },
                    { field: 'ORD_SUBJECT_NAME', title: '订货主题名称', width: 100}
				]]
    });
}

function ShowDlgProdCls(tablID, subjectCode, prodClsID) {
    $('#' + tablID).datagrid({
        url: '/ShowDialog/GetBpmsProdClsList',
        queryParams: { SubjectCode: subjectCode, ProdClsID: prodClsID },
        title: '商品款选择',
        height: 280,
        fitColumns: true,
        nowrap: true,
        rownumbers: true,
        showFooter: true,
        idField: 'PROD_CLS_ID',
        loadMsg: '正在加载信息...',
        pagination: true,
        singleSelect: true,
        pageList: [10, 20, 30], //{ 
        columns: [[
                    { field: 'ck', checkbox: true, align: 'left', width: 50 },
                    { field: 'PROD_CLS_ID', title: '编码', width: 40 ,sortable: true, resizable: true},
                    { field: 'NAME', title: '名称', width: 140 },
					{ field: 'ORD_SUBJECT_CODE', title: '主题编码', width: 80 },
                    { field: 'ORD_SUBJECT_NAME', title: '主题名称', width: 80 },
				]]
    });
}

function ShowDlgMarket(tablID, subjectCode, marketID) {
    $('#' + tablID).datagrid({
        url: '/ShowDialog/GetBpmsMarketList',
        queryParams: { SubjectCode: subjectCode, MarketID: marketID },
        title: '市场选择',
        height: 300,
        fitColumns: true,
        nowrap: true,
        rownumbers: true,
        showFooter: true,
        idField: 'MARKET_ID',
        loadMsg: '正在加载信息...',
        pagination: true,
        singleSelect: true,
        pageList: [10, 20, 30], //{ 
        columns: [[
                    { field: 'ck', checkbox: true, align: 'left', width: 50 },
                    { field: 'MARKET_ID', title: '市场编码', width: 80, sortable: true, resizable: true },
                    { field: 'MARKET_NAME', title: '市场名称', width: 140 },
                    { field: 'MARKET_PRO', title: '市场性质', width: 40 },
					{ field: 'ORD_SUBJECT_CODE', title: '主题编码', width: 80 },
                    { field: 'ORD_SUBJECT_NAME', title: '主题名称', width: 80 },
				]]
    });
}

function ShowDlgProduct(tablID, subjectCode, prodClsID, prodID) {
    $('#' + tablID).datagrid({
        url: '/ShowDialog/GetBpmsProductList',
        queryParams: { SubjectCode: subjectCode, ProdClsID: prodClsID, ProdID: prodID },
        title: '商品选择',
        height: 300,
        fitColumns: true,
        nowrap: true,
        rownumbers: true,
        showFooter: true,
        idField: 'PROD_ID',
        loadMsg: '正在加载信息...',
        pagination: true,
        singleSelect: true,
        pageList: [10, 20, 30], //{ 
        columns: [[
                    { field: 'ck', checkbox: true, align: 'left', width: 50 },
                    { field: 'PROD_ID', title: '商品编码', width: 80, sortable: true, resizable: true },
                    { field: 'PROD_CLS_ID', title: '商品款', width: 40 },
                    { field: 'PROD_CLS_NAME', title: '商品名称', width: 140 },
					{ field: 'ORD_SUBJECT_CODE', title: '主题编码', width: 80 },
                    { field: 'ORD_SUBJECT_NAME', title: '主题名称', width: 80 },
				]],
        buttons: [{
            text: "确定",
            iconCls: 'icon-ok',
            handler: function () {
                DlgGetSelectedProd();
            }
        },
                {
                    text: "取消",
                    iconCls: 'icon-cancel',
                    handler: function () {
                        $("#divTistrTask").dialog("close");
                    }
                }]
    });
}

function ShowDlgRDCOrder(tablID, subjectCode, warehID) {
    $('#' + tablID).datagrid({
        url: '/ShowDialog/GetBpmsRDCOrderList',
        queryParams: { SubjectCode: subjectCode, WarehID: warehID },
        title: '市场选择',
        height: 300,
        fitColumns: true,
        nowrap: true,
        rownumbers: true,
        showFooter: true,
        idField: 'MARKET_ID',
        loadMsg: '正在加载信息...',
        pagination: true,
        singleSelect: true,
        pageList: [10, 20, 30], //{ 
        columns: [[
                    { field: 'ck', checkbox: true, align: 'left', width: 50 },
                    { field: 'WAREH_ID', title: 'RDC编码', width: 80, sortable: true, resizable: true },
                    { field: 'WAREH_NAME', title: 'RDC名称', width: 140 },
					{ field: 'ORD_SUBJECT_CODE', title: '主题编码', width: 80 },
                    { field: 'ORD_SUBJECT_NAME', title: '主题名称', width: 100 },
				]]
    });
}

function ShowDlgBpmsAgent(tablID, subjectCode, agentID) {
    $('#' + tablID).datagrid({
        url: '/ShowDialog/GetBpmsAgentList',
        queryParams: { SubjectCode: subjectCode, AgentID: agentID },
        title: '市场选择',
        height: 300,
        fitColumns: true,
        nowrap: true,
        rownumbers: true,
        showFooter: true,
        idField: 'MARKET_ID',
        loadMsg: '正在加载信息...',
        pagination: true,
        singleSelect: true,
        pageList: [10, 20, 30], //{ 
        columns: [[
                    { field: 'ck', checkbox: true, align: 'left', width: 50 },
                    { field: 'AGENT_ID', title: '代理商编码', width: 80, sortable: true, resizable: true },
                    { field: 'AGENT_NAME', title: '代理商名称', width: 140 },
					{ field: 'ORD_SUBJECT_CODE', title: '主题编码', width: 80 },
                    { field: 'ORD_SUBJECT_NAME', title: '主题名称', width: 100 },
				]]
    });
}

function ShowLoadingDlg(containerID) {
    $("#" + containerID).append('<div id="dlgLoading" style="z-index:10; position:relative;top:40%; left:40%;"><img src="Content/Images/loading.gif" /></div>');
}

function RemoveLoadingDlg() {
    $("#dlgLoading").remove();
}
