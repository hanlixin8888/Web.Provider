using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    [DataContract]
    [MB.Orm.Mapping.Att.ModelMap("PurchaseMain", "PurchaseMain", new string[] { "SHEETID" })]
    [KnownType(typeof(PurchaseMain))]
   public class PurchaseMain: MB.Orm.Common.BaseModel//采购订单主表
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
        /// 截止日期
        /// </summary>
        private DateTime _ExpireDate;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("ExpireDate", System.Data.DbType.DateTime)]
        public DateTime ExpireDate
        {
            get { return _ExpireDate; }
            set { _ExpireDate = value; }
        }

        // <summary>
        /// 总数量
        /// </summary>
        private int _TotalQty;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("TotalQty", System.Data.DbType.Int32)]
        public int TotalQty
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
        /// 供应商名称
        /// </summary>
        private string _VENDERNAME;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("VENDERNAME", System.Data.DbType.String)]
        public string VENDERNAME
        {
            get { return _VENDERNAME; }
            set { _VENDERNAME = value; }
        }


        /// <summary>
        ///结算方式
        /// </summary>
        private string _PAYTYPENAME;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PAYTYPENAME", System.Data.DbType.String)]
        public string PAYTYPENAME
        {
            get { return _PAYTYPENAME; }
            set { _PAYTYPENAME = value; }
        }
        
        /// <summary>
        ///采购类型
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
        ///备注
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
