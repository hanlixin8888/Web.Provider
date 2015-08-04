using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    [MB.Orm.Mapping.Att.ModelMap("Purchase", "Purchase", new string[] { "SHEETID" })]
    [KnownType(typeof(Purchase))]
    public class Purchase : MB.Orm.Common.BaseModel
    {

        /// <summary>
        /// 单据号
        /// </summary>
        private string _SHEETID;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("SHEETID", System.Data.DbType.String)]
        public string SHEETID
        {
            get { return _SHEETID; }
            set { _SHEETID = value; }
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
        private string _GOODSNAME;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("GOODSNAME", System.Data.DbType.String)]
        public string GOODSNAME
        {
            get { return _GOODSNAME; }
            set { _GOODSNAME = value; }
        }

        /// <summary>
        /// 制单人
        /// </summary>
        private string _EDITOR;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("EDITOR", System.Data.DbType.String)]
        public string EDITOR
        {
            get { return _EDITOR; }
            set { _EDITOR = value; }
        }
        /// <summary>
        /// 下单时间
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
        /// 截至时间
        /// </summary>
        private DateTime _ExpireDate;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("ExpireDate", System.Data.DbType.DateTime)]
        public DateTime ExpireDate
        {
            get { return _ExpireDate; }
            set { _ExpireDate = value; }
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        private int _FLAG;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("FLAG", System.Data.DbType.Int32)]
        public int FLAG
        {
            get { return _FLAG; }
            set { _FLAG = value; }
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


        // <summary>
        /// 数量
        /// </summary>
        private int _QTY;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("QTY", System.Data.DbType.Int32)]
        public int QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }

        // <summary>
        /// 实发数量
        /// </summary>
        private int _RealQty;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("RealQty", System.Data.DbType.Int32)]
        public int RealQty
        {
            get { return _RealQty; }
            set { _RealQty = value; }
        }

        /// <summary>
        /// 单位
        /// </summary>
        private string _UnitName;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("UnitName", System.Data.DbType.String)]
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
        [MB.Orm.Mapping.Att.ColumnMap("GoodsSpec", System.Data.DbType.String)]
        public string GoodsSpec
        {
            get { return _GoodsSpec; }
            set { _GoodsSpec = value; }
        }

        /// <summary>
        /// 单价
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
        /// 总金额
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
        /// 结算方式
        /// </summary>
        private string _PayTypeCode;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PayTypeCode", System.Data.DbType.String)]
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
        [MB.Orm.Mapping.Att.ColumnMap("PurType", System.Data.DbType.String)]
        public string PurType
        {
            get { return _PurType; }
            set { _PurType = value; }
        }
        /// <summary>
        /// 采购订货商品明显备注
        /// </summary>
        private string _Remark;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("Remark", System.Data.DbType.String)]
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

    }
}
