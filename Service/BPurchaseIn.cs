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
    public class BPurchaseIn:Business.IFace.IFacePurchaseIn
    {
        /// <summary>
        /// 采购入库主从明细查询
        /// </summary>  
        public List<Model.PurchaseIn> GetPurchaseInList(int pageIndex, int pageSize, out int total, params object[] parValues)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<PurchaseIn> list = PagedDatabaseExcuteByXmlHelper.NewInstance.GetPagedObjectsByXml3<PurchaseIn>
                                                ("PurchaseIn", "GetPurchaseInInfo", pageIndex, pageSize, out total, parValues);
                return list;
            } 
        }

        //查询主表
        public List<PurchaseInMain> GetPurchaseInMain(int pageIndex, int pageSize, out int total, params object[] parValues)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<PurchaseInMain> list = PagedDatabaseExcuteByXmlHelper.NewInstance.GetPagedObjectsByXml3<PurchaseInMain>
                                                ("PurchaseIn", "GetPurchaseInMain", pageIndex, pageSize, out total, parValues);
                return list;
            }
        }


        //查询子表
        public List<PurchaseIn> GetPurchaseInDetail(string OrderNoOrGoodsCode)
        {
            using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
            {
                List<PurchaseIn> list = DatabaseExcuteByXmlHelper.NewInstance.GetObjectsByXml<PurchaseIn>
                                                ("PurchaseIn", "GetPurchaseInDetail", OrderNoOrGoodsCode);
                return list;
            }
        }


    }
}
