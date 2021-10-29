using CTApi;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CTWrapperInterface
{
    public class CTWrapper
    {
        #region Globals
        private CtApi api;
        private int Port;
        
        public bool IsConnected
        {
            get
            {
                return api.State == CtConnectionState.Connected;
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
            public OrderData[] Orders;
            public TransactionEvent Event;
        }
        public struct QuoteEventArgs
        {
            public string Symbol;
            public double Bid, Ask;
        }

        //Invokers
        private void APIOnConnectionStateChanged(object sender, ConnectionStateEventArgs e)
        {
            var args = new ConnectionProgressEventArgs
            {
                Progress = e.State.ToString(),
                Message = e.Message
            };

            OnConnectionProgressed?.Invoke(sender, args);
        }
        private void APIOnQuoteUpdated(object sender, CtQuoteEventArgs e)
        {
            var args = new QuoteEventArgs
            {
                Symbol = e.Symbol,
                Bid = e.Bid,
                Ask = e.Ask
            };

            OnQuoteUpdate?.Invoke(sender, args);
        }
        private void APIOnPositionOpen(object sender, CtOrderDataEventArgs e)
        {
            var args = new TransactionEventArgs
            {
                Event = TransactionEvent.OrderOpened,
                Orders = new OrderData[1]
            };
            var ctorder = new OrderData
            {
                Ticket = e.Ticket,
                Symbol = e.Symbol,
                Type = e.Type,
                Profit = e.Profit,
                OpenPrice = e.OpenPrice,
                ClosePrice = e.ClosePrice,
                OpenTime = e.OpenTime,
                CloseTime = e.CloseTime,
                Lots = e.Volume,
                Swap = e.Swap,
                Commission = e.Commission
            };
            args.Orders[0] = ctorder;

            OnTradeOccurrance?.Invoke(sender, args);
        }
        private void APIOnPositionModify(object sender, CtOrderDataEventArgs e)
        {
            var args = new TransactionEventArgs
            {
                Event = TransactionEvent.OrderModified,
                Orders = new OrderData[1]
            };
            var ctorder = new OrderData
            {
                Ticket = e.Ticket,
                Symbol = e.Symbol,
                Type = e.Type,
                Profit = e.Profit,
                OpenPrice = e.OpenPrice,
                ClosePrice = e.ClosePrice,
                OpenTime = e.OpenTime,
                CloseTime = e.CloseTime,
                Lots = e.Volume,
                Swap = e.Swap,
                Commission = e.Commission
            };
            args.Orders[0] = ctorder;

            OnTradeOccurrance?.Invoke(sender, args);
        }
        private void APIOnPositionClose(object sender, CtOrderDataEventArgs e)
        {
            var args = new TransactionEventArgs
            {
                Event = TransactionEvent.OrderClosed,
                Orders = new OrderData[1]
            };
            var ctorder = new OrderData
            {
                Ticket = e.Ticket,
                Symbol = e.Symbol,
                Type = e.Type,
                Profit = e.Profit,
                OpenPrice = e.OpenPrice,
                ClosePrice = e.ClosePrice,
                OpenTime = e.OpenTime,
                CloseTime = e.CloseTime,
                Lots = e.Volume,
                Swap = e.Swap,
                Commission = e.Commission
            };
            args.Orders[0] = ctorder;
            OnTradeOccurrance?.Invoke(sender, args);
        }
        #endregion

        #region Constructor
        public CTWrapper()
        {
            Port = 2529;
            api = new CtApi();
            api.ConnectionStateChanged += APIOnConnectionStateChanged;
            api.OnQuote += APIOnQuoteUpdated;
            api.OnPositionOpen += APIOnPositionOpen;
            api.OnPositionModify += APIOnPositionModify;
            api.OnPositionClose += APIOnPositionClose;
        }
        public CTWrapper(int port)
        {
            Port = port;
            api = new CtApi();
            api.ConnectionStateChanged += APIOnConnectionStateChanged;
            api.OnQuote += APIOnQuoteUpdated;
            api.OnPositionOpen += APIOnPositionOpen;
            api.OnPositionModify += APIOnPositionModify;
            api.OnPositionClose += APIOnPositionClose;
        }
        #endregion

        #region Exported Functions
        public int Connect()
        {
            api.BeginConnect(Port);
            while (api.State == CtConnectionState.Connecting || api.State == CtConnectionState.Disconnected) Thread.Sleep(1);
            if (api.State == CtConnectionState.Connected) return 0;
            else return 4;
        }

        public int Disconnect()
        {
            api.BeginDisconnect();
            while (api.State == CtConnectionState.Connected) Thread.Sleep(1);
            if (api.State == CtConnectionState.Disconnected) return 0;
            else return 1;
        }

        public AccountInfo GetAccountInfo()
        {
            if (api.State == CtConnectionState.Connected)
            {
                AccountInfo info = new AccountInfo();
                info.BrokerName = api.AccountCompany();
                info.ServerName = api.AccountServer();
                info.AccountNumber = (ulong)api.AccountNumber();
                info.AccountName = api.AccountName();
                info.AccountCurrency = api.AccountCurrency();
                info.AccountLeverage = (ulong)api.AccountLevarage();
                return info;
            }
            else throw new Exception("Not Connected");
        }

        public DateTime GetServerTime()
        {
            if (api.State == CtConnectionState.Connected)
            {
                return api.ServerTime();
            }
            else throw new Exception("Not Connected");
        }

        public double GetAccountBalance()
        {
            if (api.State == CtConnectionState.Connected)
            {
                return api.AccountBalance();
            }
            else throw new Exception("Not Connected");
        }

        public double GetAccountEquity()
        {
            if (api.State == CtConnectionState.Connected)
            {
                return api.AccountEquity();
            }
            else throw new Exception("Not Connected");
        }

        public OrderData[] GetOrderHistory(DateTime from, DateTime to)
        {
            if (api.State == CtConnectionState.Connected)
            {
                List<OrderData> retlist = new List<OrderData>();
                foreach (var order in api.AccountHistory(from, to))
                {
                    var ctorder = new OrderData
                    {
                        Ticket = order.Ticket,
                        Symbol = order.Symbol,
                        Type = order.Type,
                        Profit = order.Profit,
                        OpenPrice = order.OpenPrice,
                        ClosePrice = order.ClosePrice,
                        OpenTime = order.OpenTime,
                        CloseTime = order.CloseTime,
                        Lots = order.Volume,
                        Swap = order.Swap,
                        Commission = order.Commission
                    };
                    retlist.Add(ctorder);
                }
                return retlist.ToArray();
            }
            else throw new Exception("Not Connected");
        }

        public OrderData[] GetPositions()
        {
            if (api.State == CtConnectionState.Connected)
            {
                List<OrderData> retlist = new List<OrderData>();
                foreach (var order in api.AccountPositions())
                {
                    var ctorder = new OrderData
                    {
                        Ticket = order.Ticket,
                        Symbol = order.Symbol,
                        Type = order.Type,
                        Profit = order.Profit,
                        OpenPrice = order.OpenPrice,
                        ClosePrice = order.ClosePrice,
                        OpenTime = order.OpenTime,
                        CloseTime = order.CloseTime,
                        Lots = order.Volume,
                        Swap = order.Swap,
                        Commission = order.Commission
                    };
                    retlist.Add(ctorder);
                }
                return retlist.ToArray();
            }
            else throw new Exception("Not Connected");
        }

        public void ClosePositions(int mode)
        {
            switch (mode)
            {
                case 0:
                    api.CloseAllPositions();
                    break;
                case 1:
                    foreach (var position in api.AccountPositions())
                    {
                        if (position.Profit >= 0) api.ClosePosition(position.Ticket);
                    }
                    break;
                case 2:
                    foreach (var position in api.AccountPositions())
                    {
                        if (position.Profit < 0) api.ClosePosition(position.Ticket);
                    }
                    break;
            }
        }
        #endregion
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
