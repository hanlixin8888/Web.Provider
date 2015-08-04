using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    [MB.Orm.Mapping.Att.ModelMap("PurchaseIn", "PurchaseIn", new string[] { "SheetID" })]
    [KnownType(typeof(PurchaseIn))]
    public class PurchaseIn:MB.Orm.Common.BaseModel
    {
        public PurchaseIn()
        {


        }
        /// <summary>
        /// 采购进货单据号
        /// </summary>
        private string _SheetID;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("SheetID", System.Data.DbType.String)]
        public string SheetID
        {
            get { return _SheetID; }
            set { _SheetID = value; }
        }

        /// <summary>
        /// 相关单据号(订货单号)
        /// </summary>
        private string _RefSheetID;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("RefSheetID", System.Data.DbType.Int32)]
        public string RefSheetID
        {
            get { return _RefSheetID; }
            set { _RefSheetID = value; }
        }

        /// <summary>
        /// 商品编码
        /// </summary>
        private string _GoodsCode;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("GoodsCode", System.Data.DbType.String)]
        public string GoodsCode
        {
            get { return _GoodsCode; }
            set { _GoodsCode = value; }
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        private string _GoodsName;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("GoodsName", System.Data.DbType.String)]
        public string GoodsName
        {
            get { return _GoodsName; }
            set { _GoodsName = value; }
        }

        /// <summary>
        /// 通知数量
        /// </summary>
        private decimal _NotifyQty;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("NotifyQty", System.Data.DbType.Decimal)]
        public decimal NotifyQty
        {
            get { return _NotifyQty; }
            set { _NotifyQty = value; }
        }

        /// <summary>
        /// 收货数量
        /// </summary>
        private decimal _Qty;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("Qty", System.Data.DbType.Decimal)]
        public decimal Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        private string _UnitName;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("UnitName",System.Data.DbType.String)]
        public string UnitName
        {
            get { return _UnitName; }
            set { _UnitName = value; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        private string _GoodsSpec;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("GoodsSpec",System.Data.DbType.String)]
        public string GoodsSpec
        {
            get { return _GoodsSpec; }
            set { _GoodsSpec = value; }
        }

        /// <summary>
        /// 进价
        /// </summary>
        private decimal _Cost;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("Cost", System.Data.DbType.Decimal)]
        public decimal Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }

        /// <summary>
        /// 成本金额
        /// </summary>
        private decimal _CostValue;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("CostValue", System.Data.DbType.Decimal)]
        public decimal CostValue
        {
            get { return _CostValue; }
            set { _CostValue = value; }
        }
         
        /// <summary>
        /// 供应商内码
        /// </summary>
        private string _VenderID;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("VenderID", System.Data.DbType.Int32)]
        public string VenderID
        {
            get { return _VenderID; }
            set { _VenderID = value; }  
        }

        /// <summary>
        /// 供应商名称
        /// </summary>
        private string _VenderName;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("VenderName", System.Data.DbType.String)]
        public string VenderName
        {
            get { return _VenderName; }
            set { _VenderName = value; }
        }

        /// <summary>
        /// 总数量
        /// </summary>
        private decimal _TotalQty;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("TotalQty", System.Data.DbType.Decimal)]
        public decimal TotalQty
        {
            get { return _TotalQty; }
            set { _TotalQty = value; }
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        private int _Flag;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("Flag", System.Data.DbType.Int32)]
        public int Flag
        {
            get { return _Flag; }
            set { _Flag = value; }
        }

        /// <summary>
        /// 制单人
        /// </summary>
        private string _Editor;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("Editor", System.Data.DbType.Int32)]
        public string Editor
        {
            get { return _Editor; }
            set { _Editor = value; }
        }
        /// <summary>
        /// 制单日期
        /// </summary>
        private DateTime _EditDate;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("EditDate", System.Data.DbType.DateTime)]
        public DateTime EditDate
        {
            get { return _EditDate; }
            set { _EditDate = value; }
        }

        /// <summary>
        /// 结算方式
        /// </summary>
        private string _PayTypeCode;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PayTypeCode",System.Data.DbType.String)]
        public string PayTypeCode
        {
          get { return _PayTypeCode; }
          set { _PayTypeCode = value; }
        }

        /// <summary>
        /// 采购类型
        /// </summary>
        private string _PurType;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PurType",System.Data.DbType.String)]
        public string PurType
        {
            get { return _PurType; }
            set { _PurType = value; }
        }
         
        /// <summary>
        /// 采购进货单备注
        /// </summary> 
        private string _Note;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("Note",System.Data.DbType.String)]
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        /// <summary>
        /// 采购进货明显商品备注
        /// </summary>
        private string _Remark;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("Remark",System.Data.DbType.String)]
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        /// <summary>
        /// 包装单位名称
        /// </summary>
        private string _PkgUnitName;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PkgUnitName", System.Data.DbType.String)]
        public string PkgUnitName
        {
            get { return _PkgUnitName; }
            set { _PkgUnitName = value; }
        }

        /// <summary>
        /// 包装层次名称
        /// </summary>
        private string _PkgClassName;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PkgClassName", System.Data.DbType.String)]
        public string PkgClassName
        {
            get { return _PkgClassName; }
            set { _PkgClassName = value; }
        }
        /// <summary>
        /// 包装数量
        /// </summary>
        private decimal _PkgNumber;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PkgNumber", System.Data.DbType.Decimal)]
        public decimal PkgNumber
        {
            get { return _PkgNumber; }
            set { _PkgNumber = value; }
        }
        /// <summary>
        /// 包装件数
        /// </summary>
        private decimal _PkgQty;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PkgQty", System.Data.DbType.Decimal)]
        public decimal PkgQty
        {
            get { return _PkgQty; }
            set { _PkgQty = value; }
        }
        /// <summary>
        /// 零数
        /// </summary>
        private decimal _BulkQty;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("BulkQty", System.Data.DbType.Decimal)]
        public decimal BulkQty
        {
            get { return _BulkQty; }
            set { _BulkQty = value; }
        }

        /// <summary>
        /// 审核时间
        /// </summary>
        private DateTime _CheckDate;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("CheckDate", System.Data.DbType.DateTime)]
        public DateTime CheckDate
        {
            get { return _CheckDate; }
            set { _CheckDate = value; }
        }

        /// <summary>
        /// 包装单价
        /// </summary>
        private decimal _PkgCost;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PkgCost", System.Data.DbType.Decimal)]
        public decimal PkgCost
        {
            get { return _PkgCost; }
            set { _PkgCost = value; }
        }

        /// <summary>
        /// 仓位名称
        /// </summary>
        private string _WarehouseName;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("WarehouseName", System.Data.DbType.String)]
        public string WarehouseName
        {
            get { return _WarehouseName; }
            set { _WarehouseName = value; }
        }

    }
}
//    --采购进货单7001			Receipt/ReceiptItem
//--DROP TABLE ReceiptItem; 
//CREATE TABLE ReceiptItem
//(
//SheetID			VARCHAR2(20)		NOT NULL,				--单据编号
//SeqNo			INTEGER			NOT NULL,				--序号
//WarehouseID		INTEGER			NOT NULL,				--仓位编码
//GoodsID			INTEGER			NOT NULL,				--商品内码
//NotifyQty		DEC(12,3)		DEFAULT 0 NOT NULL,			--通知数量
//Qty			DEC(12,3)		DEFAULT 0 NOT NULL,			--收货数量
//Cost			DEC(14,6)		DEFAULT 0 NOT NULL,			--进价
//CostTaxValue		DEC(12,2)		DEFAULT 0 NOT NULL,			--进项税额
//CostValue		DEC(12,2)		DEFAULT 0 NOT NULL,			--成本金额
//TaxRate			DEC(5,2)		NOT NULL,				--税率
//FarmProduct		INTEGER			DEFAULT 0 NOT NULL,			--农产品标志(0:否;1:是)
//Remark			VARCHAR2(255)		DEFAULT NULL				--说明
//);

//--DROP TABLE Receipt;
//CREATE TABLE Receipt
//(
//SheetID			VARCHAR2(20)		NOT NULL,				--单据编号
//EditShopID 		INTEGER 		NOT NULL,				--制单机构
//RefSheetID		VARCHAR2(20)		DEFAULT NULL,				--相关单据号(采购订货单)
//RefSheetType 		INTEGER			DEFAULT NULL,				--相关单据类型
//ExternalSheetID		VARCHAR2(20)		DEFAULT NULL,				--对外单据号
//ShopID			INTEGER 		NOT NULL,				--进货门店内码
//VenderID		INTEGER			NOT NULL,				--供应商内码
//PayTypeCode		VARCHAR2(10)		NOT NULL,				--结算方式
//PurType			INTEGER			DEFAULT 0 NOT NULL,			--采购类型(0:普通;1:总量;)
//TotalQty		DEC(12,3)		DEFAULT 0 NOT NULL,			--总数量
//TotalCostTaxValue	DEC(12,2)		DEFAULT 0 NOT NULL,			--总税额
//TotalCostValue		DEC(12,2)		DEFAULT 0 NOT NULL,			--总金额
//Flag			INTEGER			DEFAULT 0 NOT NULL,			--状态(0:编辑;20:待处理;40:在执行;96:已审核未记账;98:手工作废;99:系统作废;100:完结)
//CheckState      	INTEGER        		DEFAULT	NULL,				--审批结果状态
//CheckRemark     	VARCHAR2(255)     	DEFAULT NULL,				--审批结果描述	
//Editor			VARCHAR2(32)		NOT NULL,				--制单人
//EditDate		DATE 			DEFAULT SYSDATE NOT NULL,		--制单日期(时间为00:00:00)
//EditTime		DATE 			DEFAULT SYSDATE NOT NULL,		--制单时间
//Agent1			VARCHAR2(32)		DEFAULT NULL,				--经办人一
//Agent2			VARCHAR2(32)		DEFAULT NULL,				--经办人二
//Checker			VARCHAR2(32)		DEFAULT NULL,				--审核人
//CheckDate		DATE 			DEFAULT NULL,				--审核日期(时间为00:00:00)
//CheckTime		DATE 			DEFAULT NULL,				--审核时间
//CheckBillDate		DATE			DEFAULT NULL,				--对帐日期
//DueDate			DATE			DEFAULT NULL,				--应结日期
//SettleFlag		INTEGER			DEFAULT 0 NOT NULL,			--结算标志 0-正常,1-已选定对帐,2-已对帐,3-已选定发票登记,4-已发票登记,5-已选定结算,6-结算已审核,7-已选定付款,8-结算已审批（结算审批后即认为已付款）
//CheckBillSheetID	VARCHAR2(20)		DEFAULT NULL,				--供应商对帐单号
//InvoiceRegisterSheetID	VARCHAR2(20)		DEFAULT NULL,				--供应商发票登记单号（预留）
//SettleSheetID		VARCHAR2(20)		DEFAULT NULL,				--供应商结算单据号（预留）
//PaymentSheetID		VARCHAR2(20)		DEFAULT NULL,				--供应商付款汇总单号（预留）
//PostFlag		INTEGER			DEFAULT 0 NOT NULL,			--核算标志 0-未核算,1-已选定核算,2-已核算
//PostSheetID		VARCHAR2(20)		DEFAULT NULL,				--核算单据号
//PrintCount		INTEGER			DEFAULT 0 NOT NULL,			--打印次数
//Note			VARCHAR2(255)		DEFAULT NULL				--备注

