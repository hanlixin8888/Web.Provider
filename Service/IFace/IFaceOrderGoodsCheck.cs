using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Model;

namespace Business.IFace
{
     [ServiceContract]
    interface IFaceOrderGoodsCheck
    {
        /// <summary>
        /// 查询订单商品
        /// </summary>
        /// <param name="OrderNoOrGoodsCode"></param>
        /// <returns></returns>
        List<OrderGoods> Query(string OrderNoOrGoodsCode);
    }
}
