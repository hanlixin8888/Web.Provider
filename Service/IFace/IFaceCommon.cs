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
    interface IFaceCommon
    {
        //[FaultContract(typeof(MB.Util.Model.WcfFaultMessage))]
        //[OperationContract]
        VenderUser LogOn(string userCode, string psw);
    }
}
