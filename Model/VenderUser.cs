using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    [MB.Orm.Mapping.Att.ModelMap("VenderUser", "VenderUser", new string[] { "VUSERCODE" })]
    [KnownType(typeof(VenderUser))]
    public class VenderUser : MB.Orm.Common.BaseModel
    {
        public VenderUser()
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
        private string _PASSWORD;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PASSWORD", System.Data.DbType.String)]
        public string PASSWORD
        {
            get { return _PASSWORD; }
            set { _PASSWORD = value; }
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
       
        [DataMember]
        public string ErrorMsg { get; set; }
    }
}
