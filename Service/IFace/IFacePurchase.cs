using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Business.IFace
{
   [ServiceContract]
    interface IFacePurchase
    {
       List<Purchase> GetPurchaseList(int pageIndex, int pageSize, out int total, params object[] parValues);
    }
}
