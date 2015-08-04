using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.RuleBase.Common;

namespace Public
{
    public class DataHelp
    {
        public static object GetObjectID(string name)
        {
            return DatabaseExcuteByXmlHelper.NewInstance.ExecuteScalar("DsAllotSmooth", "SelectID", name);
        }
    }
}
