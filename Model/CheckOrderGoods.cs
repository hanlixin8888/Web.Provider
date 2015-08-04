using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    [MB.Orm.Mapping.Att.ModelMap("CheckOrderGoods", "CheckOrderGoods", new string[] { "SHEETID" })]
    [KnownType(typeof(OrderGoods))]
    public class CheckOrderGoods : MB.Orm.Common.BaseModel
    {
        public CheckOrderGoods() { }

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
        private string _GOODSCODE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("GOODSCODE", System.Data.DbType.String)]
        public string GOODSCODE
        {
            get { return _GOODSCODE; }
            set { _GOODSCODE = value; }
        }

        // <summary>
        /// 检验数量
        /// </summary>
        private int _CHECKNO;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("CHECKNO", System.Data.DbType.Int32)]
        public int CHECKNO
        {
            get { return _CHECKNO; }
            set { _CHECKNO = value; }
        }
    }
}
