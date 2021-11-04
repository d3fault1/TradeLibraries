#define __NAMEDPIPE__

using MtApi5;
using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;

namespace MT5WrapperInterface
{
    public class MT5Wrapper
    {
#if __NAMEDPIPE__
        #region MTAPINAMEDPIPE

        #region Globals
        private MtApi5Client api;
        private int Port;

        public bool IsConnected
        {
            get
            {
                return api.ConnectionState == Mt5ConnectionState.Connected;
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
            public long ClosingTicket;
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

        uint gTransCnt = 0;
        enum ENUM_TRADE_OBJ
        {
            TRADE_OBJ_NULL = 0,       // not specified
            TRADE_OBJ_POSITION = 1,   // position
            TRADE_OBJ_ORDER = 2,      // order
            TRADE_OBJ_DEAL = 3,       // deal
            TRADE_OBJ_HIST_ORDER = 4, // historical order
        };
        #endregion

        #region Events, Delegates, Arguments and Invokers
        //Delegates
        public delegate void ConnectionProgressed(object sender, ConnectionProgressEventArgs args);
        public delegate void TradeOccurred(object sender, TransactionEventArgs args);
        public delegate void QuoteUpdateOccured(object sender, QuoteEventArgs args);

        //Events
        public event ConnectionProgressed OnConnectionProgressed;
        public event TradeOccurred OnTradeOccurrance;
        public QuoteUpdateOccured OnQuoteUpdate;

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
        private void APIOnConnectionStateChanged(object sender, Mt5ConnectionEventArgs e)
        {
            var args = new ConnectionProgressEventArgs
            {
                Progress = e.Status.ToString(),
                Message = e.ConnectionMessage
            };

            OnConnectionProgressed?.Invoke(sender, args);
        }
        private void APIOnQuoteUpdated(object sender, string symbol, double bid, double ask)
        {
            for (int i = 0; i < api.PositionsTotal(); i++)
                if (api.PositionGetSymbol(i) == symbol)
                {
                    QuoteEventArgs args = new QuoteEventArgs
                    {
                        Symbol = symbol,
                        Bid = bid,
                        Ask = ask
                    };
                    OnQuoteUpdate?.Invoke(sender, args);
                }
        }
        private void APIOnTradeTransaction(object sender, Mt5TradeTransactionEventArgs e)
        {
            OrderData[] Ords = new OrderData[0];
            TransactionEvent TE = TransactionEvent.Null;

            ENUM_TRADE_OBJ trade_obj = ENUM_TRADE_OBJ.TRADE_OBJ_NULL;               // specifies the trade object at the first pass
            ENUM_TRADE_REQUEST_ACTIONS last_action = (ENUM_TRADE_REQUEST_ACTIONS)(-1); // market operation at the first pass

            //---
            bool is_to_reset_cnt = false;
            string deal_symbol = e.Trans.Symbol;

            //--- ========== Types of transactions [START]
            switch (e.Trans.Type)
            {
                //--- 1) if it is a request
                case ENUM_TRADE_TRANSACTION_TYPE.TRADE_TRANSACTION_REQUEST:
                    {
                        //---
                        last_action = e.Request.Action;
                        string action_str;

                        //--- what is the request for?
                        switch (last_action)
                        {
                            //--- а) on market
                            case ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_DEAL:
                                {
                                    action_str = "place a market order";
                                    trade_obj = ENUM_TRADE_OBJ.TRADE_OBJ_POSITION;
                                    break;
                                }
                            //--- б) place a pending order
                            case ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_PENDING:
                                {
                                    action_str = "place a pending order";
                                    trade_obj = ENUM_TRADE_OBJ.TRADE_OBJ_ORDER;
                                    break;
                                }
                            //--- в) modify position
                            case ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_SLTP:
                                {
                                    trade_obj = ENUM_TRADE_OBJ.TRADE_OBJ_POSITION;
                                    action_str = e.Request.Symbol + ": modify the levels of Stop Loss and Take Profit";
                                    break;
                                }
                            //--- г) modify the order
                            case ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_MODIFY:
                                {
                                    action_str = "modify parameters of the pending order";
                                    trade_obj = ENUM_TRADE_OBJ.TRADE_OBJ_ORDER;
                                    break;
                                }
                            //--- д) delete the order
                            case ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_REMOVE:
                                {
                                    action_str = "delete the pending order";
                                    trade_obj = ENUM_TRADE_OBJ.TRADE_OBJ_ORDER;
                                    break;
                                }
                        }
                        break;
                    }
                //--- 2) if it is an addition of a new open order
                case ENUM_TRADE_TRANSACTION_TYPE.TRADE_TRANSACTION_ORDER_ADD:
                    {
                        //market order
                        if (trade_obj == ENUM_TRADE_OBJ.TRADE_OBJ_POSITION)
                        {
                            TE = TransactionEvent.OrderPlaced;
                        }

                        //pending order
                        else if (trade_obj == ENUM_TRADE_OBJ.TRADE_OBJ_ORDER)
                        {
                            TE = TransactionEvent.PendingPlaced;
                        }
                        break;
                    }
                //--- 3) if it is a deletion of an order from the list of open ones
                case ENUM_TRADE_TRANSACTION_TYPE.TRADE_TRANSACTION_ORDER_DELETE:
                    {
                        break;
                    }
                //--- 4) if it is an addition of a new order to the history
                case ENUM_TRADE_TRANSACTION_TYPE.TRADE_TRANSACTION_HISTORY_ADD:
                    {
                        //--- if a pending order is being processed
                        if (trade_obj == ENUM_TRADE_OBJ.TRADE_OBJ_ORDER)
                        {
                            //--- if it is the third pass
                            if (gTransCnt == 2)
                            {
                                //--- if the order was canceled, check the deals
                                DateTime now = api.TimeCurrent();

                                //--- request the history of orders and deals
                                api.HistorySelect(now.AddHours(1), now);

                                //--- attempt to find a deal for the order
                                int all_deals = api.HistoryDealsTotal();
                                //---
                                bool is_found = false;
                                for (int deal_idx = all_deals; deal_idx >= 0; deal_idx--)
                                {
                                    ulong tck = api.HistoryDealGetTicket(deal_idx);
                                    if ((ulong)api.HistoryDealGetInteger(tck, ENUM_DEAL_PROPERTY_INTEGER.DEAL_ORDER) == e.Trans.Order)
                                        is_found = true;
                                }

                                //--- if a deal was not found
                                if (!is_found)
                                {
                                    is_to_reset_cnt = true;
                                    TE = TransactionEvent.PendingCancelled;
                                    //order canceled
                                }
                            }
                            //--- if it is the fourth pass
                            if (gTransCnt == 3)
                            {
                                //order deleted
                                TE = TransactionEvent.PendingDeleted;
                                is_to_reset_cnt = true;
                            }
                        }
                        break;
                    }
                //--- 5) if it is an addition of a deal to history
                case ENUM_TRADE_TRANSACTION_TYPE.TRADE_TRANSACTION_DEAL_ADD:
                    {
                        is_to_reset_cnt = true;
                        ulong deal_ticket = e.Trans.Deal;
                        ENUM_DEAL_TYPE deal_type = e.Trans.DealType;

                        if (deal_ticket > 0)
                        {
                            DateTime now = api.TimeCurrent();

                            //--- request the history of orders and deals
                            api.HistorySelect(now.AddHours(1), now);

                            //--- select a deal by the ticket
                            if (api.HistoryDealSelect(deal_ticket))
                            {
                                //--- check the deal
                                long order_ticket = api.HistoryDealGetInteger(deal_ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_ORDER);

                                //--- parameters of the deal
                                ENUM_DEAL_ENTRY deal_entry = (ENUM_DEAL_ENTRY)api.HistoryDealGetInteger(deal_ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_ENTRY);
                                double deal_vol = 0;
                                //---
                                deal_vol = api.HistoryDealGetDouble(deal_ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_VOLUME);
                                deal_symbol = api.HistoryDealGetString(deal_ticket, ENUM_DEAL_PROPERTY_STRING.DEAL_SYMBOL);
                                if (deal_vol != 0)
                                    if (deal_symbol != "")
                                    {
                                        //--- position
                                        double pos_vol = -1;
                                        //---
                                        if (api.PositionSelectByTicket((ulong)api.HistoryDealGetInteger(deal_ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_POSITION_ID)))
                                            pos_vol = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_VOLUME);

                                        //--- if the market was entered
                                        if (deal_entry == ENUM_DEAL_ENTRY.DEAL_ENTRY_IN)
                                        {
                                            //--- 1) opening of a position
                                            if (deal_vol == pos_vol)
                                            {
                                                TE = TransactionEvent.OrderOpened;
                                            }

                                            //--- 2) addition of lots to the open position        
                                            else if (deal_vol < pos_vol)
                                            {
                                                TE = TransactionEvent.OrderOpened;
                                            }
                                            api.PositionSelectByTicket((ulong)order_ticket);
                                            var order = new OrderData
                                            {
                                                Ticket = api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TICKET),
                                                ClosingTicket = 0,
                                                Symbol = api.PositionGetString(ENUM_POSITION_PROPERTY_STRING.POSITION_SYMBOL),
                                                OpenTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME)),
                                                CloseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_UPDATE)),
                                                Lots = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_VOLUME),
                                                OpenPrice = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_OPEN),
                                                ClosePrice = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_CURRENT),
                                                Profit = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PROFIT),
                                                Type = new CultureInfo("en-US").TextInfo.ToTitleCase(((ENUM_POSITION_TYPE)api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TYPE)).ToString().Split('_')[2].ToLower()),
                                                Swap = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_SWAP),
                                                Commission = 0
                                            };
                                            Ords = new OrderData[1] { order };
                                        }

                                        //--- if the market was exited
                                        else if (deal_entry == ENUM_DEAL_ENTRY.DEAL_ENTRY_OUT)
                                        {
                                            if (deal_vol > 0.0)
                                            {
                                                //--- 1) closure of a position
                                                if (pos_vol == -1)
                                                {
                                                    TE = TransactionEvent.OrderClosed;
                                                }

                                                //--- 2) partial closure of the open position        
                                                else if (pos_vol > 0.0)
                                                {
                                                    TE = TransactionEvent.OrderClosed;
                                                }
                                                var order = new OrderData
                                                {
                                                    Ticket = api.HistoryDealGetInteger(deal_ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_POSITION_ID),
                                                    ClosingTicket = api.HistoryDealGetInteger(deal_ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_TICKET),
                                                    Symbol = api.HistoryDealGetString(deal_ticket, ENUM_DEAL_PROPERTY_STRING.DEAL_SYMBOL),
                                                    CloseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.HistoryDealGetInteger(deal_ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_TIME)),
                                                    Lots = api.HistoryDealGetDouble(deal_ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_VOLUME),
                                                    ClosePrice = api.HistoryDealGetDouble(deal_ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_PRICE),
                                                    Profit = api.HistoryDealGetDouble(deal_ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_PROFIT),
                                                    Swap = api.HistoryDealGetDouble(deal_ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_SWAP),
                                                    Commission = api.HistoryDealGetDouble(deal_ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_COMMISSION)
                                                };
                                                var type = api.HistoryDealGetInteger(deal_ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_TYPE);
                                                if (type == (long)ENUM_DEAL_TYPE.DEAL_TYPE_BUY) order.Type = "Sell";
                                                else if (type == (long)ENUM_DEAL_TYPE.DEAL_TYPE_SELL) order.Type = "Buy";
                                                api.HistorySelectByPosition(order.Ticket);
                                                var tot = api.HistoryDealsTotal();
                                                for (int i = 0; i < tot; i++)
                                                {
                                                    var tick = api.HistoryDealGetTicket(i);
                                                    var ent = api.HistoryDealGetInteger(tick, ENUM_DEAL_PROPERTY_INTEGER.DEAL_ENTRY);
                                                    if (ent != (long)ENUM_DEAL_ENTRY.DEAL_ENTRY_IN) continue;
                                                    order.OpenTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.HistoryDealGetInteger(tick, ENUM_DEAL_PROPERTY_INTEGER.DEAL_TIME));
                                                    order.OpenPrice = api.HistoryDealGetDouble(tick, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_PRICE);
                                                    break;
                                                }
                                                Ords = new OrderData[1] { order };
                                            }
                                        }

                                        //--- if position was reversed
                                        else if (deal_entry == ENUM_DEAL_ENTRY.DEAL_ENTRY_INOUT)
                                        {
                                            if (deal_vol > 0.0)
                                            {
                                                if (pos_vol > 0.0)
                                                {
                                                    TE = TransactionEvent.OrderReversed;
                                                }
                                                api.PositionSelectByTicket((ulong)order_ticket);
                                                var order = new OrderData
                                                {
                                                    Ticket = api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TICKET),
                                                    ClosingTicket = 0,
                                                    Symbol = api.PositionGetString(ENUM_POSITION_PROPERTY_STRING.POSITION_SYMBOL),
                                                    OpenTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME)),
                                                    CloseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_UPDATE)),
                                                    Lots = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_VOLUME),
                                                    OpenPrice = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_OPEN),
                                                    ClosePrice = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_CURRENT),
                                                    Profit = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PROFIT),
                                                    Type = new CultureInfo("en-US").TextInfo.ToTitleCase(((ENUM_POSITION_TYPE)api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TYPE)).ToString().Split('_')[2].ToLower()),
                                                    Swap = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_SWAP),
                                                    Commission = 0
                                                };
                                                Ords = new OrderData[1] { order };
                                            }
                                        }
                                    }

                                //--- activation of an order
                                if (trade_obj == ENUM_TRADE_OBJ.TRADE_OBJ_ORDER)
                                {
                                    TE = TransactionEvent.PendingOpened;
                                    api.PositionSelectByTicket((ulong)order_ticket);
                                    var order = new OrderData
                                    {
                                        Ticket = api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TICKET),
                                        ClosingTicket = 0,
                                        Symbol = api.PositionGetString(ENUM_POSITION_PROPERTY_STRING.POSITION_SYMBOL),
                                        OpenTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME)),
                                        CloseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_UPDATE)),
                                        Lots = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_VOLUME),
                                        OpenPrice = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_OPEN),
                                        ClosePrice = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_CURRENT),
                                        Profit = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PROFIT),
                                        Type = new CultureInfo("en-US").TextInfo.ToTitleCase(((ENUM_POSITION_TYPE)api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TYPE)).ToString().Split('_')[2].ToLower()),
                                        Swap = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_SWAP),
                                        Commission = 0
                                    };
                                    Ords = new OrderData[1] { order };
                                }
                            }
                        }

                        break;
                    }
                //--- 6) if it is a modification of a position 
                case ENUM_TRADE_TRANSACTION_TYPE.TRADE_TRANSACTION_POSITION:
                    {
                        is_to_reset_cnt = true;
                        TE = TransactionEvent.OrderModified;
                        var order_ticket = e.Trans.Position;
                        api.PositionSelectByTicket(order_ticket);
                        var order = new OrderData
                        {
                            Ticket = api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TICKET),
                            ClosingTicket = 0,
                            Symbol = api.PositionGetString(ENUM_POSITION_PROPERTY_STRING.POSITION_SYMBOL),
                            OpenTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME)),
                            CloseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_UPDATE)),
                            Lots = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_VOLUME),
                            OpenPrice = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_OPEN),
                            ClosePrice = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_CURRENT),
                            Profit = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PROFIT),
                            Type = new CultureInfo("en-US").TextInfo.ToTitleCase(((ENUM_POSITION_TYPE)api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TYPE)).ToString().Split('_')[2].ToLower()),
                            Swap = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_SWAP),
                            Commission = 0
                        };
                        Ords = new OrderData[1] { order };
                        break;
                    }
                //--- 7) if it is a modification of an open order
                case ENUM_TRADE_TRANSACTION_TYPE.TRADE_TRANSACTION_ORDER_UPDATE:
                    {

                        //--- if it was the first pass
                        if (gTransCnt == 0)
                        {
                            trade_obj = ENUM_TRADE_OBJ.TRADE_OBJ_ORDER;
                            TE = TransactionEvent.PendingCancelled;
                        }
                        //--- if it was the second pass
                        if (gTransCnt == 1)
                        {
                            //--- if it is a modification of a pending order
                            if (last_action == ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_MODIFY)
                            {
                                TE = TransactionEvent.PendingModified;
                                //--- clear counter
                                is_to_reset_cnt = true;
                            }
                            //--- if it is a deletion of a pending order
                            if (last_action == ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_REMOVE)
                            {
                                TE = TransactionEvent.PendingDeleted;
                            }
                        }
                        //--- if it was the third pass
                        if (gTransCnt == 2)
                        {
                            //placement of a pending order
                            TE = TransactionEvent.PendingPlaced;
                            //--- clear counter
                            is_to_reset_cnt = true;
                        }

                        //---
                        break;
                    }
            }
            //--- ========== Transaction types [END]

            //--- pass counter
            if (is_to_reset_cnt)
            {
                gTransCnt = 0;
                trade_obj = 0;
                last_action = (ENUM_TRADE_REQUEST_ACTIONS)(-1);

                var args = new TransactionEventArgs
                {
                    Orders = Ords,
                    Event = TE
                };

                OnTradeOccurrance?.Invoke(sender, args);
            }
            else
                gTransCnt++;
        }
        #endregion

        #region Constructor
        public MT5Wrapper()
        {
            Port = 8228;
            api = new MtApi5Client();
            api.ConnectionStateChanged += APIOnConnectionStateChanged;
            api.OnTradeTransaction += APIOnTradeTransaction;
            api.QuoteUpdated += APIOnQuoteUpdated;
        }
        public MT5Wrapper(int port)
        {
            Port = port;
            api = new MtApi5Client();
            api.ConnectionStateChanged += APIOnConnectionStateChanged;
            api.OnTradeTransaction += APIOnTradeTransaction;
            api.QuoteUpdated += APIOnQuoteUpdated;
        }
        #endregion

        #region Exported Functions
        public int Connect()
        {
            api.BeginConnect(Port);
            while (api.ConnectionState == Mt5ConnectionState.Connecting || api.ConnectionState == Mt5ConnectionState.Disconnected) Thread.Sleep(1);
            if (api.ConnectionState == Mt5ConnectionState.Connected) return 0;
            else return 4;
        }

        public int Disconnect()
        {
            api.BeginDisconnect();
            while (api.ConnectionState == Mt5ConnectionState.Connected) Thread.Sleep(1);
            if (api.ConnectionState == Mt5ConnectionState.Disconnected) return 0;
            else return 1;
        }

        public AccountInfo GetAccountInfo()
        {
            if (api.ConnectionState == Mt5ConnectionState.Connected)
            {
                AccountInfo info = new AccountInfo();
                info.BrokerName = api.AccountInfoString(ENUM_ACCOUNT_INFO_STRING.ACCOUNT_COMPANY);
                info.ServerName = api.AccountInfoString(ENUM_ACCOUNT_INFO_STRING.ACCOUNT_SERVER);
                info.AccountNumber = (ulong)api.AccountInfoInteger(ENUM_ACCOUNT_INFO_INTEGER.ACCOUNT_LOGIN);
                info.AccountName = api.AccountInfoString(ENUM_ACCOUNT_INFO_STRING.ACCOUNT_NAME);
                info.AccountCurrency = api.AccountInfoString(ENUM_ACCOUNT_INFO_STRING.ACCOUNT_CURRENCY);
                info.AccountLeverage = (ulong)api.AccountInfoInteger(ENUM_ACCOUNT_INFO_INTEGER.ACCOUNT_LEVERAGE);
                return info;
            }
            else throw new Exception("Not Connected");
        }

        public DateTime GetServerTime()
        {
            if (api.ConnectionState == Mt5ConnectionState.Connected)
            {
                return api.TimeCurrent();
            }
            else throw new Exception("Not Connected");
        }

        public double GetServerPing()
        {
            if (api.ConnectionState == Mt5ConnectionState.Connected)
            {
                var micro = api.TerminalInfoInteger(ENUM_TERMINAL_INFO_INTEGER.TERMINAL_PING_LAST);
                var ms = (double)micro / 1000;
                return ms;
            }
            else throw new Exception("Not Connected");
        }

        public double GetAccountBalance()
        {
            if (api.ConnectionState == Mt5ConnectionState.Connected)
            {
                return api.AccountInfoDouble(ENUM_ACCOUNT_INFO_DOUBLE.ACCOUNT_BALANCE);
            }
            else throw new Exception("Not Connected");
        }

        public double GetAccountEquity()
        {
            if (api.ConnectionState == Mt5ConnectionState.Connected)
            {
                return api.AccountInfoDouble(ENUM_ACCOUNT_INFO_DOUBLE.ACCOUNT_EQUITY);
            }
            else throw new Exception("Not Connected");
        }

        public OrderData[] GetOrderHistory(DateTime from, DateTime to)
        {
            if (api.ConnectionState == Mt5ConnectionState.Connected)
            {
                api.HistorySelect(from, to);
                int total = api.HistoryDealsTotal();
                List<OrderData> orders = new List<OrderData>();
                for (int i = 0; i < total; i++)
                {
                    OrderData ord = new OrderData();
                    var ticket = api.HistoryDealGetTicket(i);
                    var type = api.HistoryDealGetInteger(ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_TYPE);
                    var entry = api.HistoryDealGetInteger(ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_ENTRY);
                    if (entry != (long)ENUM_DEAL_ENTRY.DEAL_ENTRY_OUT) continue;
                    if (type == (long)ENUM_DEAL_TYPE.DEAL_TYPE_BUY) ord.Type = "SELL";
                    else if (type == (long)ENUM_DEAL_TYPE.DEAL_TYPE_SELL) ord.Type = "BUY";
                    else continue;
                    ord.Ticket = api.HistoryDealGetInteger(ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_POSITION_ID);
                    ord.ClosingTicket = api.HistoryDealGetInteger(ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_TICKET);
                    ord.Symbol = api.HistoryDealGetString(ticket, ENUM_DEAL_PROPERTY_STRING.DEAL_SYMBOL);
                    ord.Lots = api.HistoryDealGetDouble(ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_VOLUME);
                    ord.ClosePrice = api.HistoryDealGetDouble(ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_PRICE);
                    ord.Profit = api.HistoryDealGetDouble(ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_PROFIT);
                    ord.CloseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.HistoryDealGetInteger(ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_TIME));
                    ord.Swap = api.HistoryDealGetDouble(ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_SWAP);
                    ord.Commission = api.HistoryDealGetDouble(ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_COMMISSION);
                    orders.Add(ord);
                }
                for (int i = 0; i < orders.Count; i++)
                {
                    api.HistorySelectByPosition(orders[i].Ticket);
                    var count = api.HistoryDealsTotal();
                    for (int j = 0; j < count; j++)
                    {
                        var ticket = api.HistoryDealGetTicket(j);
                        var entry = api.HistoryDealGetInteger(ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_ENTRY);
                        if (entry != (long)ENUM_DEAL_ENTRY.DEAL_ENTRY_IN) continue;
                        orders[i] = new OrderData
                        {
                            Ticket = orders[i].Ticket,
                            ClosingTicket = orders[i].ClosingTicket,
                            Symbol = orders[i].Symbol,
                            Type = orders[i].Type,
                            Lots = orders[i].Lots,
                            OpenPrice = api.HistoryDealGetDouble(ticket, ENUM_DEAL_PROPERTY_DOUBLE.DEAL_PRICE),
                            ClosePrice = orders[i].ClosePrice,
                            Profit = orders[i].Profit,
                            OpenTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.HistoryDealGetInteger(ticket, ENUM_DEAL_PROPERTY_INTEGER.DEAL_TIME)),
                            CloseTime = orders[i].CloseTime,
                            Swap = orders[i].Swap,
                            Commission = orders[i].Commission
                        };
                        break;
                    }
                }
                return orders.ToArray();
            }
            else throw new Exception("Not Connected");
        }

        public OrderData[] GetPositions()
        {
            if (api.ConnectionState == Mt5ConnectionState.Connected)
            {
                int total = api.PositionsTotal();
                OrderData[] orders = new OrderData[total];
                for (int i = 0; i < total; i++)
                {
                    OrderData ord = new OrderData();
                    var ticket = api.PositionGetTicket(i);
                    api.PositionSelectByTicket(ticket);
                    ord.Ticket = (long)ticket;
                    ord.ClosingTicket = 0;
                    ord.Symbol = api.PositionGetString(ENUM_POSITION_PROPERTY_STRING.POSITION_SYMBOL);
                    ord.Lots = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_VOLUME);
                    ord.OpenPrice = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_OPEN);
                    ord.ClosePrice = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_CURRENT);
                    ord.Profit = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PROFIT);
                    ord.OpenTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME));
                    ord.CloseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_UPDATE));
                    ord.Swap = api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_SWAP);
                    ord.Commission = 0;
                    var type = api.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TYPE);
                    if (type == (long)ENUM_POSITION_TYPE.POSITION_TYPE_BUY) ord.Type = "Buy";
                    else if (type == (long)ENUM_POSITION_TYPE.POSITION_TYPE_SELL) ord.Type = "Sell";
                    orders[i] = ord;
                }
                return orders;
            }
            else throw new Exception("Not Connected");
        }

        public void ClosePositions(int mode)
        {
            switch (mode)
            {
                case 0:
                    api.PositionCloseAll();
                    break;
                case 1:
                    for (int i = 0; i < api.PositionsTotal(); i++)
                    {
                        var ticket = api.PositionGetTicket(i);
                        api.PositionSelectByTicket(ticket);
                        if (api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PROFIT) >= 0) while (!api.PositionClose(ticket)) Thread.Sleep(10);
                    }
                    break;
                case 2:
                    for (int i = 0; i < api.PositionsTotal(); i++)
                    {
                        var ticket = api.PositionGetTicket(i);
                        api.PositionSelectByTicket(ticket);
                        if (api.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PROFIT) < 0) while (!api.PositionClose(ticket)) Thread.Sleep(10);
                    }
                    break;
            }
        }
        #endregion
        #endregion
#else
        #region MTAPILIBNET
        private MT5API api;

        public struct AccountInfo
        {
            public string BrokerName;
            public string ServerName;
            public string AccountName;
            public ulong AccountNumber;
            public int AccountLeverage;
            public string AccountCurrency;
        }
        public struct OrderData
        {
            public string Symbol;
            public long Ticket;
            public DateTime Time;
            public string Type;
            public double Lots;
            public double Price;
            public double Profit;
        }
        public enum Progress
        {
            SendLogin = 0,
            SendAccountPassword = 1,
            AcceptAuthorized = 2,
            RequestTradeInfo = 3,
            Connected = 4,
            Exception = 5,
            Disconnect = 6
        }

        #region Event Arguments
        public struct ConnectionProgressEventArgs
        {
            public Progress Progress;
        }
        public struct OrderProgressEventArgs
        {

        }
        public struct OrderEventArgs
        {

        }
        public struct OrderUpdateEventArgs
        {

        }
        public struct QuoteUpdateEventArgs
        {

        }
        public struct QuoteEventArgs
        {

        }
        #endregion

        #region Events
        public delegate void ConnectionProgressed(object sender, ConnectionProgressEventArgs args);
        public delegate void OrderProgressed(object sender, OrderProgressEventArgs args);
        public delegate void OrderHistoryObtained(object sender, OrderEventArgs args);
        public delegate void OrderUpdated(object sender, OrderUpdateEventArgs args);
        public delegate void QuoteUpdated(object sender, QuoteUpdateEventArgs args);
        public delegate void QuoteHistoryObtained(object sender, QuoteEventArgs args);

        public event ConnectionProgressed OnConnectionProgressed;
        public event OrderProgressed OnOrderProgressed;
        public event OrderHistoryObtained OnOrderHistoryObtained;
        public event OrderUpdated OnOrderUpdated;
        public event QuoteUpdated OnQouteUpdated;
        public event QuoteHistoryObtained OnQouteHistoryObtained;
        #endregion

        /// <summary>
        /// Connects to a broker server with specified user ID and password
        /// </summary>
        /// <param name="server">server name</param>
        /// <param name="user">user ID</param>
        /// <param name="pass">password</param>
        /// <returns>
        /// various return code indicating sepcific errors
        /// 0 = Everything OK
        /// 1 = Servers.dat file not found
        /// 2 = Invalid Servers.dat file
        /// 3 = Specified server not found in the servers.dat
        /// 4 = Authentication or connection error
        /// </returns>
        public int Connect(string server, ulong user, string pass)
        {
            string address = "";
            if (!File.Exists(@"servers.dat")) return 1;
            try
            {
                var servers = MT5API.LoadServersDat(@"servers.dat");
                foreach (var srv in servers)
                {
                    if (srv.ServerInfoEx != null)
                        if (srv.ServerInfoEx.ServerName == server)
                            address = srv.ServerInfoEx.Address;
                }
            }
            catch (Exception e)
            {
                return 2;
            }
            if (address == "") return 3;
            var infos = address.Split(':');
            var host = infos[0];
            var port = Convert.ToInt32(infos[1]);
            try
            {
                api = new MT5API(user, pass, host, port);

                api.OnConnectProgress += APIOnConnectProgress;
                api.OnOrderProgress += APIOnOrderProgress;
                api.OnOrderUpdate += APIOnOrderUpdate;
                api.OnOrderHistory += APIOnOrderHistory;
                api.OnQuote += APIOnQuote;
                api.OnQuoteHistory += APIOnQuoteHistory;

                api.Connect();

                //foreach (var sym in api.Symbols.Infos) api.Subscribe(sym.Currency);
                api.UpdateProfits();
            }
            catch (Exception e)
            {
                return 4;
            }
            return 0;
        }

        /// <summary>
        /// Disconnects a from a connected server
        /// </summary>
        /// <returns>
        /// various return code indicating sepcific errors
        /// 0 = Succesfully disconnected
        /// 1 = No disconnection occured
        /// </returns>
        public int Disconnect()
        {
            if (api != null)
                if (api.Connected)
                {
                    //foreach (var sym in api.Symbols.Infos) api.Unsubscribe(sym.Currency);
                    api.Disconnect();
                    return 0;
                }
            return 1;
        }

        /// <summary>
        /// Gets the account information upon connecting to the server
        /// </summary>
        /// <returns>a struct containing required account infos</returns>
        public AccountInfo GetAccountInfo()
        {
            if (api != null)
                if (api.Connected)
                {
                    var info = new AccountInfo();
                    info.BrokerName = api.AccountCompanyName;
                    info.ServerName = api.ServerDetails.Key.ServerName;
                    info.AccountName = api.Account.UserName;
                    info.AccountNumber = api.User;
                    info.AccountLeverage = api.Account.Leverage;
                    info.AccountCurrency = api.AccountCurrency;
                    return info;
                }
            throw new Exception("Account not connected");
        }

        /// <summary>
        /// Gets the current server time. Refreshes with incoming qoutes. Subscription to any symbol is required
        /// </summary>
        /// <returns>the current time of the server</returns>
        public DateTime GetServerTime()
        {
            if (api != null)
                if (api.Connected)
                {
                    int n = 0;
                    if (api.Symbols.Exist("BTCUSD"))
                    {
                        while (api.GetQuote("BTCUSD") == null)
                        {
                            Thread.Sleep(5);
                            if (n >= 1000) goto forex;
                            n++;
                        }
                        return api.ServerTime;
                    }
                forex:
                    n = 0;
                    if (api.Symbols.Exist("EURUSD"))
                    {
                        while (api.GetQuote("EURUSD") == null)
                        {
                            Thread.Sleep(5);
                            if (n >= 1000) goto failure;
                                n++;
                        }
                        return api.ServerTime;
                    }
                failure:
                    throw new Exception("Could not get the server time");
                }
            throw new Exception("Account not connected");
        }

        /// <summary>
        /// Gets the account balance
        /// </summary>
        /// <returns>the account balance</returns>
        public double GetAccountBalance()
        {
            if (api != null)
                if (api.Connected)
                {
                    api.UpdateProfits();
                    return api.Account.Balance;
                }
            throw new Exception("Account not connected");
        }

        /// <summary>
        /// Gets the account equity
        /// </summary>
        /// <returns>the account equity</returns>
        public double GetAccountEquity()
        {
            if (api != null)
                if (api.Connected)
                {
                    api.UpdateProfits();
                    return api.AccountEquity;
                }
            throw new Exception("Account not connected");
        }

        /// <summary>
        /// Gets order history within given period of time
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>a list of orders representing order history</returns>
        public OrderData[] GetOrderHistory(DateTime start, DateTime end)
        {
            if (api != null)
                if (api.Connected)
                {
                    List<OrderData> list = new List<OrderData>();
                    api.UpdateProfits();
                    foreach (var ord in api.DownloadOrderHistory(start, end).Orders)
                        list.Add(new OrderData { Symbol = ord.Symbol, Ticket = ord.Ticket, Time = ord.OpenTime, Lots = ord.Lots, Price = ord.OpenPrice, Type = ord.OrderType.ToString(), Profit = ord.Profit });
                    return list.ToArray();
                }
            throw new Exception("Account not connected");
        }

        /// <summary>
        /// Gets currently opened positions
        /// </summary>
        /// <returns>list of positions opened</returns>
        public OrderData[] GetPositions()
        {
            if (api != null)
                if (api.Connected)
                {
                    List<OrderData> list = new List<OrderData>();
                    api.UpdateProfits();
                    foreach (var ord in api.GetOpenedOrders())
                        list.Add(new OrderData { Symbol = ord.Symbol, Ticket = ord.Ticket, Time = ord.OpenTime, Lots = ord.Lots, Price = ord.OpenPrice, Type = ord.OrderType.ToString(), Profit = ord.Profit });
                    return list.ToArray();
                }
            throw new Exception("Account not connected");
        }

        /// <summary>
        /// Automatically closes positions depending on the specified mode
        /// 0 = Close all positions
        /// 1 = Close winning positions
        /// 2 = Close losing positions
        /// </summary>
        /// <param name="mode"></param>
        public void ClosePositions(int mode)
        {
            if (api != null)
                if (api.Connected)
                {
                    api.UpdateProfits();
                    switch (mode)
                    {
                        case 0:
                            foreach (var ord in api.GetOpenedOrders())
                                api.OrderClose(ord.Ticket, ord.Symbol, ord.OpenPrice, ord.Lots, ord.OrderType, 0, FillPolicy.ImmediateOrCancel, ord.ExpertId, ord.Comment);
                            return;
                        case 1:
                            foreach (var ord in api.GetOpenedOrders())
                                if (ord.Profit > 0) api.OrderClose(ord.Ticket, ord.Symbol, ord.OpenPrice, ord.Lots, ord.OrderType, 0, FillPolicy.ImmediateOrCancel, ord.ExpertId, ord.Comment);
                            return;
                        case 2:
                            foreach (var ord in api.GetOpenedOrders())
                                if (ord.Profit < 0) api.OrderClose(ord.Ticket, ord.Symbol, ord.OpenPrice, ord.Lots, ord.OrderType, 0, FillPolicy.ImmediateOrCancel, ord.ExpertId, ord.Comment);
                            return;
                    }
                }
            throw new Exception("Account not connected");
        }

        #region Event Functions
        private void APIOnConnectProgress(MT5API sender, ConnectEventArgs args)
        {
            var _args = new ConnectionProgressEventArgs();
            _args.Progress = (Progress)args.Progress;
            if (args.Progress == ConnectProgress.Exception) Console.WriteLine(args.Exception.Message);
            OnConnectionProgressed?.Invoke(sender, _args);
        }
        private void APIOnOrderProgress(MT5API sender, OrderProgress progress)
        {
            sender.UpdateProfits();
            var _args = new OrderProgressEventArgs();
            OnOrderProgressed?.Invoke(sender, _args);
        }
        private void APIOnOrderHistory(MT5API sender, OrderHistoryEventArgs args)
        {
            var _args = new OrderEventArgs();
            OnOrderHistoryObtained?.Invoke(sender, _args);
        }
        private void APIOnOrderUpdate(MT5API sender, OrderUpdate update)
        {
            sender.UpdateProfits();
            var _args = new OrderUpdateEventArgs();
            OnOrderUpdated?.Invoke(sender, _args);
        }
        private void APIOnQuote(MT5API api, Quote quote)
        {
            var _args = new QuoteUpdateEventArgs();
            OnQouteUpdated?.Invoke(api, _args);
        }
        private void APIOnQuoteHistory(MT5API sender, QuoteHistoryEventArgs progress)
        {
            var _args = new QuoteEventArgs();
            OnQouteHistoryObtained?.Invoke(sender, _args);
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
