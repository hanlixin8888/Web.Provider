using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    [MB.Orm.Mapping.Att.ModelMap("PurchaseInMain", "PurchaseInMain", new string[] { "SheetID" })]
    [KnownType(typeof(PurchaseMain))]
    public class PurchaseInMain:MB.Orm.Common.BaseModel
    {
        /// <summary>
        /// 采购进货单号
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
        /// 相关订单号
        /// </summary>
        private string _RefSheetID;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("RefSheetID", System.Data.DbType.String)]
        public string RefSheetID
        {
            get { return _RefSheetID; }
            set { _RefSheetID = value; }
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
        /// 结算方式
        /// </summary>
        private string _PayTypeName;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PayTypeName", System.Data.DbType.String)]
        public string PayTypeName
        {
            get { return _PayTypeName; }
            set { _PayTypeName = value; }
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
        /// 总金额
        /// </summary>
        private decimal _TotalCostValue;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("TotalCostValue", System.Data.DbType.Decimal)]
        public decimal TotalCostValue
        {
            get { return _TotalCostValue; }
            set { _TotalCostValue = value; }
        }

        /// <summary>
        /// 状态
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
        [MB.Orm.Mapping.Att.ColumnMap("Editor", System.Data.DbType.String)]
        public string Editor
        {
            get { return _Editor; }
            set { _Editor = value; }
        }

        /// <summary>
        /// 制单时间
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
        /// 备注
        /// </summary>
        private string _Note;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("Note", System.Data.DbType.String)]
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
    }
}
