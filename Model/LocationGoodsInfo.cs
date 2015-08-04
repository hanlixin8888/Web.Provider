using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Model
{
    [DataContract]
    [MB.Orm.Mapping.Att.ModelMap("LMLocationGoods", "LMLocationGoods", new string[] { "LOCATIONGOODSID" })]
    [KnownType(typeof(LocationGoodsInfo))]
    public class LocationGoodsInfo : MB.Orm.Common.BaseModel
    {

        public LocationGoodsInfo()
        {
        }
        private int _LOCATIONGOODSBATCHID;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("LOCATIONGOODSBATCHID", System.Data.DbType.Int32)]
        public int LOCATIONGOODSBATCHID
        {
            get { return _LOCATIONGOODSBATCHID; }
            set { _LOCATIONGOODSBATCHID = value; }
        }

        private int _LOCATIONID;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("LOCATIONID", System.Data.DbType.Int32)]
        public int LOCATIONID
        {
            get { return _LOCATIONID; }
            set { _LOCATIONID = value; }
        }

        private string _GOODSBATCHCODE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("GOODSBATCHCODE", System.Data.DbType.String)]
        public string GOODSBATCHCODE
        {
            get { return _GOODSBATCHCODE; }
            set { _GOODSBATCHCODE = value; }
        }

        private int _WAREHOUSEID;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("WAREHOUSEID", System.Data.DbType.Int32)]
        public int WAREHOUSEID
        {
            get { return _WAREHOUSEID; }
            set { _WAREHOUSEID = value; }
        }

        private DateTime _PRODUCTIONDATE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("PRODUCTIONDATE", System.Data.DbType.DateTime)]
        public DateTime PRODUCTIONDATE
        {
            get { return _PRODUCTIONDATE; }
            set { _PRODUCTIONDATE = value; }
        }

        private DateTime _STORAGEDATE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("STORAGEDATE", System.Data.DbType.DateTime)]
        public DateTime STORAGEDATE
        {
            get { return _STORAGEDATE; }
            set { _STORAGEDATE = value; }
        }

        private string _EXPIRYDAYS;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("EXPIRYDAYS", System.Data.DbType.String)]
        public string EXPIRYDAYS
        {
            get { return _EXPIRYDAYS; }
            set { _EXPIRYDAYS = value; }
        }

        private string _STATE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("STATE", System.Data.DbType.String)]
        public string STATE
        {
            get { return _STATE; }
            set { _STATE = value; }
        }

        private string _CREATER;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("CREATER", System.Data.DbType.String)]
        public string CREATER
        {
            get { return _CREATER; }
            set { _CREATER = value; }
        }

        private DateTime _CREATEDATE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("CREATEDATE", System.Data.DbType.DateTime)]
        public DateTime CREATEDATE
        {
            get { return _CREATEDATE; }
            set { _CREATEDATE = value; }
        }

        private string _EDITOR;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("EDITOR", System.Data.DbType.String)]
        public string EDITOR
        {
            get { return _EDITOR; }
            set { _EDITOR = value; }
        }

        private DateTime _EDITDATE;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("EDITDATE", System.Data.DbType.DateTime)]
        public DateTime EDITDATE
        {
            get { return _EDITDATE; }
            set { _EDITDATE = value; }
        }

        private string _REMARK;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("REMARK", System.Data.DbType.String)]
        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }

        private string _warehousename;
        [DataMember]
        [MB.Orm.Mapping.Att.ColumnMap("warehousename", System.Data.DbType.String)]
        public string warehousename
        {
            get { return _warehousename; }
            set { _warehousename = value; }
        }
    }
}
