using Business.IFace;
using MB.Orm.DB;
using MB.RuleBase.Common;
using Model;
using Public.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BPurchaseOut:IFacePurchaseOut
    {
        //查询退货主从
        public List<PurchaseOut> GetPurchaseOutList(int pageIndex, int pageSize, out int total, params object[] parValue)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<PurchaseOut> list = PagedDatabaseExcuteByXmlHelper.NewInstance.GetPagedObjectsByXml3<PurchaseOut>
                    ("PurchaseOut", "GetPurchaseOutInfo", pageIndex, pageSize, out total, parValue);
                return list;
            }
             
        }

        //查询主表
        public List<PurchaseOutMain> GetPurchaseInMain(int pageIndex, int pageSize, out int total, params object[] parValues)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<PurchaseOutMain> list = PagedDatabaseExcuteByXmlHelper.NewInstance.GetPagedObjectsByXml3<PurchaseOutMain>
                                                ("PurchaseOut", "GetPurchaseOutMain", pageIndex, pageSize, out total, parValues);
                return list;
            }
        }


        //查询子表
        public List<PurchaseOut> GetPurchaseInDetail(string OrderNoOrGoodsCode)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<PurchaseOut> list = DatabaseExcuteByXmlHelper.NewInstance.GetObjectsByXml<PurchaseOut>
                                                ("PurchaseOut", "GetPurchaseOutDetail", OrderNoOrGoodsCode);
                return list;
            }
        }
    }
}
