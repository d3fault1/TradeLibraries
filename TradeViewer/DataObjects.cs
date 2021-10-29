using System;
using System.Drawing;

namespace TradeViewer
{
    class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public Color IndicatorColor { get; set; }
        public Color TextColor { get; set; }
        public string Server { get; set; }
        public int ConnectionPort { get; set; }
        public int AccountNo { get; set; }
        public int Leverage { get; set; }
        public string Currency { get; set; }
        public int TimeZoneOffset { get; set; }
        public bool IsStatsShown { get; set; }
        public DateTime LastFetched { get; set; }
        public bool IsEnabled { get; set; }
    }

    class MasterObject
    {
        public string Symbol { get; set; }
        public DateTime ClosingTime { get; set; }
        public double ClosingBalance { get; set; }
        public double GrossProfit { get; set; }
        public double NetProfit { get; set; }
        public double Commission { get; set; }
        public double Swap { get; set; }
        public double GrossPnLPercent { get; set; }
        public double NetPnLPercent { get; set; }
    }

    class TradeOrder
    {
        public int AccountID { get; set; }
        public int ID { get; set; }
        public string Symbol { get; set; }
        public TradeOrderType Type { get; set; }
        public DateTime ClosingTime { get; set; }
        public double ClosingVolume { get; set; }
        public double Swap { get; set; }
        public double Commission { get; set; }
        public double GrossProfit { get; set; }
        public double NetProfit { get; set; }
    }

    class Uptime
    {
        public int AccountID { get; set; }
        public DateTime TimeStamp { get; set; }
        public int State { get; set; }
    }

    class DDThreshold
    {
        public int AccountID { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Threshold { get; set; }
    }
}
