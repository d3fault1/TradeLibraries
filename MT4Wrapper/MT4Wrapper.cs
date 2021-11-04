#define __NAMEDPIPE__
using MtApi;
using MtApi.Monitors;
using MtApi.Monitors.Triggers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace MT4WrapperInterface
{
    public class MT4Wrapper
    {
#if __NAMEDPIPE__
        #region MTAPINAMEDPIPE

        #region Globals
        private MtApiClient api;
        private int Port;

        private TimerTradeMonitor trademon;
        private ModifiedOrdersMonitor modmon;

        public bool IsConnected
        {
            get
            {
                return api.ConnectionState == MtConnectionState.Connected;
            }
        }

        public struct AccountInfo
        {
            public string BrokerName;
            public string ServerName;
            public string AccountName;
            public ulong AccountNumber;
            public ulong AccountLeverage;
            public string AccountCurrency;
        }
        public struct OrderData
        {
            public string Symbol;
            public long Ticket;
            public DateTime OpenTime;
            public DateTime CloseTime;
            public string Type;
            public double Lots;
            public double OpenPrice;
            public double ClosePrice;
            public double Profit;
            public double Swap;
            public double Commission;
        }
        public struct MonitorData
        {
            public OrderData Order;
            public TransactionEvent Event;
        }
        #endregion

        #region Events, Delegates, Arguments and Invokers
        //Delegates
        public delegate void ConnectionProgressed(object sender, ConnectionProgressEventArgs args);
        public delegate void TradeOccurred(object sender, TransactionEventArgs args);
        public delegate void QuoteUpdateOccured(object sender, QuoteEventArgs args);

        //Events
        public event ConnectionProgressed OnConnectionProgressed;
        public event TradeOccurred OnTradeOccurrance;
        public event QuoteUpdateOccured OnQuoteUpdate;

        //Arguments
        public struct ConnectionProgressEventArgs
        {
            public string Progress;
            public string Message;
        }
        public struct TransactionEventArgs
        {
            public MonitorData[] Data;
        }
        public struct QuoteEventArgs
        {
            public string Symbol;
            public double Bid, Ask;
        }

        //Invokers
        private void APIOnConnectionStateChanged(object sender, MtConnectionEventArgs e)
        {
            var args = new ConnectionProgressEventArgs
            {
                Progress = e.Status.ToString(),
                Message = e.ConnectionMessage
            };

            if (trademon.IsMtConnected && !trademon.IsStarted) trademon.Start();
            if (!trademon.IsMtConnected && trademon.IsStarted) trademon.Stop();
            if (modmon.IsMtConnected && !modmon.IsStarted) modmon.Start();
            if (!modmon.IsMtConnected && modmon.IsStarted) trademon.Stop();

            OnConnectionProgressed?.Invoke(sender, args);
        }
        private void APIOnQuoteUpdated(object sender, string symbol, double bid, double ask)
        {
            foreach (var ord in api.GetOrders(OrderSelectSource.MODE_TRADES))
                if (ord.Symbol == symbol)
                {
                    QuoteEventArgs args = new QuoteEventArgs { Symbol = symbol, Bid = bid, Ask = ask };
                    OnQuoteUpdate?.Invoke(sender, args);
                }
        }
        private void OnAvailabilityOrdersChanged(object sender, AvailabilityOrdersEventArgs e)
        {
            List<MonitorData> data = new List<MonitorData>();
            foreach (var ord in e.Opened) data.Add(new MonitorData { Event = TransactionEvent.OrderOpened, Order = new OrderData { Ticket = ord.Ticket, Symbol = ord.Symbol, Lots = ord.Lots, OpenPrice = ord.OpenPrice, ClosePrice = ord.ClosePrice, Profit = ord.Profit, OpenTime = ord.OpenTime, CloseTime = ord.CloseTime, Type = new CultureInfo("en-US").TextInfo.ToTitleCase(ord.Operation.ToString().Split('_')[1].ToLower()), Swap = ord.Swap, Commission = ord.Commission } });
            foreach (var ord in e.Closed) data.Add(new MonitorData { Event = TransactionEvent.OrderClosed, Order = new OrderData { Ticket = ord.Ticket, Symbol = ord.Symbol, Lots = ord.Lots, OpenPrice = ord.OpenPrice, ClosePrice = ord.ClosePrice, Profit = ord.Profit, OpenTime = ord.OpenTime, CloseTime = ord.CloseTime, Type = new CultureInfo("en-US").TextInfo.ToTitleCase(ord.Operation.ToString().Split('_')[1].ToLower()), Swap = ord.Swap, Commission = ord.Commission } });
            var args = new TransactionEventArgs
            {
                Data = data.ToArray()
            };

            OnTradeOccurrance?.Invoke(sender, args);
        }
        private void OnOrdersModified(object sender, ModifiedOrdersEventArgs e)
        {
            List<MonitorData> data = new List<MonitorData>();
            foreach (var ord in e.ModifiedOrders) data.Add(new MonitorData { Event = TransactionEvent.OrderModified, Order = new OrderData { Ticket = ord.NewOrder.Ticket, Symbol = ord.NewOrder.Symbol, Lots = ord.NewOrder.Lots, OpenPrice = ord.NewOrder.OpenPrice, ClosePrice = ord.NewOrder.ClosePrice, Profit = ord.NewOrder.Profit, OpenTime = ord.NewOrder.OpenTime, CloseTime = ord.NewOrder.CloseTime, Type = new CultureInfo("en-US").TextInfo.ToTitleCase(ord.NewOrder.Operation.ToString().Split('_')[1].ToLower()), Swap = ord.NewOrder.Swap, Commission = ord.NewOrder.Commission } });
            var args = new TransactionEventArgs
            {
                Data = data.ToArray()
            };

            OnTradeOccurrance?.Invoke(sender, args);
        }
        #endregion

        #region Constructor
        public MT4Wrapper()
        {
            Port = 8222;
            api = new MtApiClient();
            trademon = new TimerTradeMonitor(api, new TimeElapsedTrigger(TimeSpan.FromSeconds(3))) { SyncTrigger = true };
            modmon = new ModifiedOrdersMonitor(api, new TimeElapsedTrigger(TimeSpan.FromSeconds(3))) { SyncTrigger = true };
            api.ConnectionStateChanged += APIOnConnectionStateChanged;
            api.QuoteUpdated += APIOnQuoteUpdated;
            trademon.AvailabilityOrdersChanged += OnAvailabilityOrdersChanged;
            modmon.OrdersModified += OnOrdersModified;
        }
        public MT4Wrapper(int port)
        {
            Port = port;
            api = new MtApiClient();
            trademon = new TimerTradeMonitor(api, new TimeElapsedTrigger(TimeSpan.FromSeconds(3))) { SyncTrigger = true };
            modmon = new ModifiedOrdersMonitor(api, new TimeElapsedTrigger(TimeSpan.FromSeconds(3))) { SyncTrigger = true };
            api.ConnectionStateChanged += APIOnConnectionStateChanged;
            api.QuoteUpdated += APIOnQuoteUpdated;
            trademon.AvailabilityOrdersChanged += OnAvailabilityOrdersChanged;
            modmon.OrdersModified += OnOrdersModified;
        }
        #endregion

        #region Exported Functions
        public int Connect()
        {
            api.BeginConnect(Port);
            while (api.ConnectionState == MtConnectionState.Disconnected || api.ConnectionState == MtConnectionState.Connecting) Thread.Sleep(1);
            if (api.ConnectionState == MtConnectionState.Connected) return 0;
            else return 4;
        }

        public int Disconnect()
        {
            api.BeginDisconnect();
            while (api.ConnectionState == MtConnectionState.Connected) Thread.Sleep(1);
            if (api.ConnectionState == MtConnectionState.Disconnected) return 0;
            else return 1;
        }

        public AccountInfo GetAccountInfo()
        {
            if (api.IsConnected())
            {
                AccountInfo info = new AccountInfo();
                info.BrokerName = api.AccountCompany();
                info.ServerName = api.AccountServer();
                info.AccountNumber = (ulong)api.AccountNumber();
                info.AccountName = api.AccountName();
                info.AccountCurrency = api.AccountCurrency();
                info.AccountLeverage = (ulong)api.AccountLeverage();
                return info;
            }
            else throw new Exception("Not Connected");
        }

        public DateTime GetServerTime()
        {
            if (api.IsConnected())
            {
                return api.TimeCurrent();
            }
            else throw new Exception("Not Connected");
        }

        public double GetServerPing()
        {
            if (api.IsConnected())
            {
                var micro = api.TerminalInfoInteger(EnumTerminalInfoInteger.TERMINAL_PING_LAST);
                var ms = (double)micro / 1000;
                return ms;
            }
            else throw new Exception("Not Connected");
        }

        public double GetAccountBalance()
        {
            if (api.IsConnected())
            {
                return api.AccountBalance();
            }
            else throw new Exception("Not Connected");
        }

        public double GetAccountEquity()
        {
            if (api.IsConnected())
            {
                return api.AccountEquity();
            }
            else throw new Exception("Not Connected");
        }

        public OrderData[] GetOrderHistory(DateTime from, DateTime to)
        {
            if (api.IsConnected())
            {
                var total = api.GetOrders(OrderSelectSource.MODE_HISTORY);
                OrderData[] orders = total.Where(ttl => (ttl.CloseTime >= from && ttl.CloseTime <= to) && (ttl.Operation == TradeOperation.OP_BUY || ttl.Operation == TradeOperation.OP_SELL)).Select(ord => new OrderData
                {
                    Ticket = ord.Ticket,
                    Symbol = ord.Symbol,
                    Lots = ord.Lots,
                    OpenPrice = ord.OpenPrice,
                    ClosePrice = ord.ClosePrice,
                    Profit = ord.Profit,
                    OpenTime = ord.OpenTime,
                    CloseTime = ord.CloseTime,
                    Type = ord.Operation.ToString().Split('_')[1],
                    Swap = ord.Swap,
                    Commission = ord.Commission
                }).ToArray();
                return orders;
            }
            else throw new Exception("Not Connected");
        }

        public OrderData[] GetPositions()
        {
            if (api.IsConnected())
            {
                var total = api.GetOrders(OrderSelectSource.MODE_TRADES);
                OrderData[] orders = total.Select(ttl => new OrderData
                {
                    Ticket = ttl.Ticket,
                    Symbol = ttl.Symbol,
                    Lots = ttl.Lots,
                    OpenPrice = ttl.OpenPrice,
                    ClosePrice = ttl.ClosePrice,
                    Profit = ttl.Profit,
                    OpenTime = ttl.OpenTime,
                    CloseTime = ttl.CloseTime,
                    Type = ttl.Operation.ToString().Split('_')[1],
                    Swap = ttl.Swap,
                    Commission = ttl.Commission
                }).ToArray();
                return orders;
            }
            else throw new Exception("Not Connected");
        }

        public void ClosePositions(int mode)
        {
            switch (mode)
            {
                case 0:
                    api.OrderCloseAll();
                    break;
                case 1:
                    foreach (var ord in api.GetOrders(OrderSelectSource.MODE_TRADES))
                    {
                        if (ord.Profit >= 0) while (!api.OrderClose(ord.Ticket, 1)) Thread.Sleep(10);
                    }
                    break;
                case 2:
                    foreach (var ord in api.GetOrders(OrderSelectSource.MODE_TRADES))
                    {
                        if (ord.Profit < 0) while (!api.OrderClose(ord.Ticket, 1)) Thread.Sleep(10);

                    }
                    break;
            }
        }
        #endregion
        #endregion
#endif
    }
    public enum TransactionEvent
    {
        Null,
        OrderPlaced,
        OrderOpened,
        OrderClosed,
        OrderModified,
        OrderReversed,
        PendingPlaced,
        PendingOpened,
        PendingClosed,
        PendingModified,
        PendingCancelled,
        PendingDeleted,
    }
}
