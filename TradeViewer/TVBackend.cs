using System;
using System.Linq;
using CTWrapperInterface;
using MT4WrapperInterface;
using MT5WrapperInterface;
using System.Collections.Generic;

namespace TradeViewer
{
    class TVBackend
    {
        private static readonly TVBackend Instance = new TVBackend();
        public static TVBackend GetInstance() => Instance;

        private DatabaseIO dbInterface;

        private Dictionary<int, CTWrapper> ctraderApis;
        private Dictionary<int, MT4Wrapper> mt4Apis;
        private Dictionary<int, MT5Wrapper> mt5Apis;

        public TVBackend()
        {
            dbInterface = new DatabaseIO();
            ctraderApis = new Dictionary<int, CTWrapper>();
            mt4Apis = new Dictionary<int, MT4Wrapper>();
            mt5Apis = new Dictionary<int, MT5Wrapper>();
        }

        public void Init()
        {
            Globals.AccountsList.Clear();
            ctraderApis.Clear();
            mt4Apis.Clear();
            mt5Apis.Clear();

            Globals.AccountsList.AddRange(dbInterface.LoadAllAccounts());
            foreach (var acc in Globals.AccountsList)
            {
                switch ((int)acc.Type)
                {
                    case 0: //cTrader
                        ctraderApis.Add(acc.ID, new CTWrapper(acc.ConnectionPort));
                        break;
                    case 1: //Metatrader 4
                        mt4Apis.Add(acc.ID, new MT4Wrapper(acc.ConnectionPort));
                        break;
                    case 2: //Metatrader 5
                        mt5Apis.Add(acc.ID, new MT5Wrapper(acc.ConnectionPort));
                        break;
                }
            }
        }

        public bool GetConnectionStatus(int accountID)
        {
            if (ctraderApis.ContainsKey(accountID))
            {
                return ctraderApis[accountID].IsConnected;
            }
            else if (mt4Apis.ContainsKey(accountID))
            {
                return mt4Apis[accountID].IsConnected;
            }
            else if (mt5Apis.ContainsKey(accountID))
            {
                return mt5Apis[accountID].IsConnected;
            }
            else
            {
                throw new Exception("Account Not Found");
            }
        }

        public DateTime GetServerTime(int accountID)
        {
            if (!GetConnectionStatus(accountID)) throw new Exception("Account Disconnected");
            if (ctraderApis.ContainsKey(accountID))
            {
                return ctraderApis[accountID].GetServerTime();
            }
            else if (mt4Apis.ContainsKey(accountID))
            {
                return mt4Apis[accountID].GetServerTime();
            }
            else if (mt5Apis.ContainsKey(accountID))
            {
                return mt5Apis[accountID].GetServerTime();
            }
            else
            {
                throw new Exception("Account Not Found");
            }
        }

        public double GetBalance(int accountID, DateTime date)
        {
            if (date.TimeOfDay.TotalSeconds == 0) date = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
            if (!GetConnectionStatus(accountID)) throw new Exception("Account Disconnected");
            List<TradeOrder> orders = new List<TradeOrder>();
            double balance = 0;
            if (ctraderApis.ContainsKey(accountID))
            {
                balance = ctraderApis[accountID].GetAccountBalance();
                foreach (var ord in ctraderApis[accountID].GetOrderHistory(date, DateTime.Now))
                {
                    orders.Add(new TradeOrder
                    {
                        AccountID = accountID,
                        ID = (int)ord.Ticket,
                        Symbol = ord.Symbol,
                        Type = ord.Type.ToLower() == "buy" ? TradeOrderType.Buy : TradeOrderType.Sell,
                        NetProfit = ord.Profit,
                        GrossProfit = ord.Profit - (ord.Swap + ord.Commission),
                        Swap = ord.Swap,
                        Commission = ord.Commission,
                        ClosingTime = ord.CloseTime,
                        ClosingVolume = ord.Lots
                    });
                }
            }
            else if (mt4Apis.ContainsKey(accountID))
            {
                balance = mt4Apis[accountID].GetAccountBalance();
                foreach (var ord in mt4Apis[accountID].GetOrderHistory(date, DateTime.Now))
                {
                    orders.Add(new TradeOrder
                    {
                        AccountID = accountID,
                        ID = (int)ord.Ticket,
                        Symbol = ord.Symbol,
                        Type = ord.Type.ToLower() == "buy" ? TradeOrderType.Buy : TradeOrderType.Sell,
                        NetProfit = ord.Profit,
                        GrossProfit = ord.Profit - (ord.Swap + ord.Commission),
                        Swap = ord.Swap,
                        Commission = ord.Commission,
                        ClosingTime = ord.CloseTime,
                        ClosingVolume = ord.Lots
                    });
                }
            }
            else if (mt5Apis.ContainsKey(accountID))
            {
                balance = mt5Apis[accountID].GetAccountBalance();
                foreach (var ord in mt5Apis[accountID].GetOrderHistory(date, DateTime.Now))
                {
                    orders.Add(new TradeOrder
                    {
                        AccountID = accountID,
                        ID = (int)ord.Ticket,
                        Symbol = ord.Symbol,
                        Type = ord.Type.ToLower() == "buy" ? TradeOrderType.Buy : TradeOrderType.Sell,
                        NetProfit = ord.Profit,
                        GrossProfit = ord.Profit - (ord.Swap + ord.Commission),
                        Swap = ord.Swap,
                        Commission = ord.Commission,
                        ClosingTime = ord.CloseTime,
                        ClosingVolume = ord.Lots
                    });
                }
            }
            else
            {
                throw new Exception("Account Not Found");
            }

            Globals.CachedOrdersList.AddRange(orders);
            var temp = Globals.CachedOrdersList.Distinct();
            Globals.CachedOrdersList.Clear();
            Globals.CachedOrdersList.AddRange(temp);

            foreach (var order in orders)
            {
                balance -= order.NetProfit;
            }
            return balance;
        }

        public double GetEquity(int accountID)
        {
            if (!GetConnectionStatus(accountID)) throw new Exception("Account Disconnected");
            if (ctraderApis.ContainsKey(accountID))
            {
                return ctraderApis[accountID].GetAccountEquity();
            }
            else if (mt4Apis.ContainsKey(accountID))
            {
                return mt4Apis[accountID].GetAccountEquity();
            }
            else if (mt5Apis.ContainsKey(accountID))
            {
                return mt5Apis[accountID].GetAccountEquity();
            }
            else
            {
                throw new Exception("Account Not Found");
            }
        }

        public double GetPingTime(int accountID)
        {
            if (!GetConnectionStatus(accountID)) throw new Exception("Account Disconnected");
            if (ctraderApis.ContainsKey(accountID))
            {
                return -1;
            }
            else if (mt4Apis.ContainsKey(accountID))
            {
                return mt4Apis[accountID].GetServerPing();
            }
            else if (mt5Apis.ContainsKey(accountID))
            {
                return mt5Apis[accountID].GetServerPing();
            }
            else
            {
                throw new Exception("Account Not Found");
            }
        }

        public void SetMasterArray(int accountID, DateTime date)
        {
            if (!GetConnectionStatus(accountID)) throw new Exception("Account Disconnected");
            if (ctraderApis.ContainsKey(accountID))
            {
                
            }
            else if (mt4Apis.ContainsKey(accountID))
            {
                
            }
            else if (mt5Apis.ContainsKey(accountID))
            {
                
            }
            else
            {
                throw new Exception("Account Not Found");
            }
        }

        public bool SetTimeZoneOffset(int accountID)
        {
            bool bRet = false;
            foreach (var acc in Globals.AccountsList)
            {
                if (acc.ID == accountID)
                {
                    try
                    {
                        var servertime = GetServerTime(accountID);
                        var localtime = DateTime.Now;
                        acc.TimeZoneOffset = (int)(servertime - localtime).TotalSeconds;
                        bRet = true;
                    }
                    catch(Exception e)
                    {
                        bRet = false;
                        return bRet;
                    }
                }
            }
            return bRet;
        }
    }
}
