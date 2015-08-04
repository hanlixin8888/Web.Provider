using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    [MB.Orm.Mapping.Att.ModelMap("Vender", "Vender", new string[] { "VENDERID" })]
    [KnownType(typeof(Vender))]
    public class Vender : MB.Orm.Common.BaseModel
    {
        public Vender()
        {

        }

        private int _VENDERID;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("VENDERID", System.Data.DbType.Int32)]
        public int VENDERID
        {
            get { return _VENDERID; }
            set { _VENDERID = value; }
        }

        private string _VENDERCODE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("VENDERCODE", System.Data.DbType.String)]
        public string VENDERCODE
        {
            get { return _VENDERCODE; }
            set { _VENDERCODE = value; }
        }
        private string _VENDERNAME;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("VENDERNAME", System.Data.DbType.String)]
        public string VENDERNAME
        {
            get { return _VENDERNAME; }
            set { _VENDERNAME = value; }
        }
    }
}
