using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeViewer
{
    static class Globals
    {
        public static List<Account> AccountsList = new List<Account>();
        public static Dictionary<int, List<MasterObject>> MasterArray = new Dictionary<int, List<MasterObject>>();
        public static List<TradeOrder> CachedOrdersList = new List<TradeOrder>();
    }
}
