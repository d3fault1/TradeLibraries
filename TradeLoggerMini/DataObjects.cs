using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeLoggerMini
{
    [Serializable]
    class Config
    {
        public string platform;
        public string alias;
        public int port;
    }

    class Trade : IEquatable<Trade>
    {
        public string accountAlias;
        public string orderID;
        public long closingTimeUnix;
        public DateTime closingTime;
        public string symbol;
        public double netPnLPercent;

        public bool Equals(Trade other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return accountAlias.Equals(other.accountAlias) && orderID.Equals(other.orderID);
        }

        public override int GetHashCode()
        {
            int hashAC = accountAlias.GetHashCode();
            int hashID = orderID.GetHashCode();
            return hashAC ^ hashID;
        }

        public override string ToString()
        {
            return $"Account: {accountAlias}, ID: {orderID}, Symbol: {symbol}, Closing Time: {closingTime}, PnL: {netPnLPercent}";
        }
    }
}
