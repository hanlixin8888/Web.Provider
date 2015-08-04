using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IFace
{
    interface IFacePurchaseOut
    {
        List<PurchaseOut> GetPurchaseOutList(int pageIndex, int pageSize, out int total, params object[] parValue);
    }
}
