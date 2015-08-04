using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Model;
using MB.Orm.DB;
using MB.RuleBase.Common;
using System.Data.Common;

namespace Business
{
    public class OrderGoodsCheck : Business.IFace.IFaceOrderGoodsCheck
    {
        /// <summary>
        /// 根据订单号查询订单商品信息
        /// </summary>
        /// <param name="OrderNoOrGoodsCode"></param>
        /// <returns></returns>
       public List<OrderGoods> Query(string OrderNoOrGoodsCode)
       {
           using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
           {
               List<OrderGoods> OrderGoodsInfo = DatabaseExcuteByXmlHelper.NewInstance.GetObjectsByXml<OrderGoods>("CheckOrderGoods", "GetOrderGoodsInfo", OrderNoOrGoodsCode);
               //if (OrderGoodsInfo == null)
               //{
               //    OrderGoodsInfo = new OrderGoods() { ErrorMsg = "输入信息错误" };
               //}
               return OrderGoodsInfo;
           }
       }

        /// <summary>
       /// 插入订单拣货校验记录
        /// </summary>
        /// <param name="list"></param>
        /// <param name="dbtrans"></param>
        /// <returns></returns>
       public string CheckOrderGoods(List<CheckOrderGoods> list)
       {
           //using (var DbScope = new OperationDatabaseScope(new OperationDatabaseContext("NewWeb")))
           //{ 
           // //DatabaseExcuteByXmlHelper.NewInstance.ExecuteScalar<CheckOrderGoods>("CheckOrderGoods","CheckOrderGoodsInfo",list);
           //  return   DatabaseExcuteByXmlHelper.NewInstance.ExecuteNonQueryByEntity<CheckOrderGoods>(dbtrans, "CheckOrderGoods", "CheckOrderGoodsInfo", list);
           //}

            var oracle = new MB.RuleBase.BulkCopy.SimulatedOracleHelper();
            var db = MB.Orm.Persistence.DatabaseHelper.CreateDatabase();
            var cn = oracle.CreateOracleConnection(db.ConnectionString);
            System.Data.Common.DbTransaction tran = null;
            string msg = string.Empty;

            try
            {
                // 打开数据连接
                cn.Open();
                tran = cn.BeginTransaction();
                using (MB.RuleBase.BulkCopy.IDbBulkExecute bulk = MB.RuleBase.BulkCopy.DbBulkExecuteFactory.CreateDbBulkExecute(tran))
                {
                    bulk.WriteToServer("CheckOrderGoods", "CheckOrderGoodsInfo", list);
                }
                 // 提交返回
                tran.Commit();
                return msg="保存成功";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return msg;
            }
            finally
            {
                if (tran != null) tran.Dispose();
                if (cn != null) cn.Close();
                if (cn != null) cn.Dispose();
            }
       }
    }
}
