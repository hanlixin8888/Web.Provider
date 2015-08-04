using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IFace
{
    interface IFacePurchaseIn
    {
        List<PurchaseIn> GetPurchaseInList(int pageIndex, int pageSize, out int total, params object[] parValues);
    }
}
