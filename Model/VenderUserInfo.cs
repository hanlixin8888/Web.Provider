using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    [MB.Orm.Mapping.Att.ModelMap("VenderUserInfo", "VenderUserInfo", new string[] { "VUSERCODE" })]
    [KnownType(typeof(VenderUserInfo))]
    public class VenderUserInfo : MB.Orm.Common.BaseModel
    {
        public VenderUserInfo()
        {

        }
        private string _VUSERCODE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("VUSERCODE", System.Data.DbType.String)]
        public string VUSERCODE
        {
            get { return _VUSERCODE; }
            set { _VUSERCODE = value; }
        }
       
        private string _USERNAME;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("USERNAME", System.Data.DbType.String)]
        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }
        private int _VENDERID;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("VENDERID", System.Data.DbType.Int32)]
        public int VENDERID
        {
            get { return _VENDERID; }
            set { _VENDERID = value; }
        }

        private string _VENDERNAME;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("VENDERNAME", System.Data.DbType.String)]
        public string VENDERNAME
        {
            get { return _VENDERNAME; }
            set { _VENDERNAME = value; }
        }

        private string _VENDERCODE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("VENDERCODE", System.Data.DbType.String)]
        public string VENDERCODE
        {
            get { return _VENDERCODE; }
            set { _VENDERCODE = value; }
        }

        [DataMember]
        public string ErrorMsg { get; set; }
    }
}
