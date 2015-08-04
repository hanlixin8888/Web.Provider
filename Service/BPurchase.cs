using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MB.RuleBase.Common;
using MB.Orm.DB;
using Public.DataAccess;

namespace Business
{
    public  class BPurchase: Business.IFace.IFacePurchase
    {
        //查询主表
        public List<PurchaseMain> GetPurchaseMain(int pageIndex, int pageSize, out int total, params object[] parValues)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<PurchaseMain> list = PagedDatabaseExcuteByXmlHelper.NewInstance.GetPagedObjectsByXml3<PurchaseMain>
                                                ("purchase", "GetPurchaseMain", pageIndex, pageSize, out total, parValues);
                return list;
            }
        }


        //查询子表
        public List<Purchase> GetPurchaseDetail(string OrderNoOrGoodsCode)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<Purchase> list = DatabaseExcuteByXmlHelper.NewInstance.GetObjectsByXml<Purchase>
                                                ("purchase", "GetPurchaseDetail", OrderNoOrGoodsCode);
                return list;
            }
        }


        //查询明细
        public List<Purchase> GetPurchaseList(int pageIndex, int pageSize, out int total, params object[] parValues)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<Purchase> list = PagedDatabaseExcuteByXmlHelper.NewInstance.GetPagedObjectsByXml3<Purchase>
                                                ("purchase", "GetPurchaseInfo", pageIndex, pageSize, out total, parValues);
                return list;
            }
        }
    }
}
    