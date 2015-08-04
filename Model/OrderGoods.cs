using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Model
{
    [DataContract]
    [MB.Orm.Mapping.Att.ModelMap("OrderGoods", "OrderGoods", new string[] { "SHEETID" })]
    [KnownType(typeof(OrderGoods))]
    public  class OrderGoods : MB.Orm.Common.BaseModel//订单商品校验
    {
        public OrderGoods()
        {
        
        }

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
        /// 发货时间
        /// </summary>
        private DateTime _RATIONDATE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("RATIONDATE", System.Data.DbType.DateTime)]
        public DateTime RATIONDATE
        {
            get { return _RATIONDATE; }
            set { _RATIONDATE = value; }
        }

        /// <summary>
        /// 商品编码
        /// </summary>
        private string _GOODSCODE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("GOODSCODE", System.Data.DbType.String)]
        public string GOODSCODE
        {
            get { return _GOODSCODE; }
            set { _GOODSCODE = value; }
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
        /// 订单数量
        /// </summary>
        private int _QTY;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("QTY", System.Data.DbType.Int32)]
        public int QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }

        /// <summary>
        /// 实发数量
        /// </summary>
        private int _REALQTY;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("REALQTY", System.Data.DbType.Int32)]
        public int REALQTY
        {
            get { return _REALQTY; }
            set { _REALQTY = value; }
        }


        /// <summary>
        /// 检验数量
        /// </summary>
        private int _CHECKQTY;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("CHECKQTY", System.Data.DbType.Int32)]
        public int CHECKQTY
        {
            get { return _CHECKQTY; }
            set { _CHECKQTY = value; }
        }

        /// <summary>
        /// 订单商品总数
        /// </summary>
        private int _GOODSCOUNT;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("GOODSCOUNT", System.Data.DbType.Int32)]
        public int GOODSCOUNT
        {
            get { return _GOODSCOUNT; }
            set { _GOODSCOUNT = value; }
        }
        [DataMember]
        public string ErrorMsg { get; set; }
    }
}
