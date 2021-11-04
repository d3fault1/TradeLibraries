using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CTWrapperInterface;
using MT4WrapperInterface;
using MT5WrapperInterface;

namespace TradeLoggerMini
{
    class Backend
    {
        MainForm Form;

        CTWrapper ctraderapi;
        MT4Wrapper mt4api;
        MT5Wrapper mt5api;
        Config current_config;
        IO dbIO;


        public Backend(MainForm form)
        {
            Form = form;
            dbIO = new IO();
            var res = ConfigLoad();
            if (res)
            {
                form.UpdateConfig(current_config.alias, current_config.platform, current_config.port, current_config.days);
            }
        }

        private bool ConfigLoad()
        {
            current_config = dbIO.LoadConfig();
            if (current_config == null) return false;
            ctraderapi = new CTWrapper(current_config.port);
            mt4api = new MT4Wrapper(current_config.port);
            mt5api = new MT5Wrapper(current_config.port);
            ctraderapi.OnTradeOccurrance += Ctrader_OnTradeOccurrance;
            mt4api.OnTradeOccurrance += Mt4_OnTradeOccurrance;
            mt5api.OnTradeOccurrance += Mt5_OnTradeOccurrance;
            ctraderapi.OnConnectionProgressed += Ctrader_OnConnectionProgressed;
            mt4api.OnConnectionProgressed += Mt4_OnConnectionProgressed;
            mt5api.OnConnectionProgressed += Mt5_OnConnectionProgressed;
            return true;
        }

        public void ConfigUpdate(string alias, string plat, int port, int day)
        {
            current_config = new Config { alias = alias, platform = plat, port = port, days = day };
            Form.Text = "API Connector - " + current_config.alias;
            dbIO.SaveConfig(current_config);
            ctraderapi = new CTWrapper(current_config.port);
            mt4api = new MT4Wrapper(current_config.port);
            mt5api = new MT5Wrapper(current_config.port);
            ctraderapi.OnTradeOccurrance += Ctrader_OnTradeOccurrance;
            mt4api.OnTradeOccurrance += Mt4_OnTradeOccurrance;
            mt5api.OnTradeOccurrance += Mt5_OnTradeOccurrance;
            ctraderapi.OnConnectionProgressed += Ctrader_OnConnectionProgressed;
            mt4api.OnConnectionProgressed += Mt4_OnConnectionProgressed;
            mt5api.OnConnectionProgressed += Mt5_OnConnectionProgressed;
        }

        private void Mt5_OnConnectionProgressed(object sender, MT5Wrapper.ConnectionProgressEventArgs args)
        {
            var reconnect = Form.UpdateState(args.Progress);
            if (reconnect)
            {
                Thread.Sleep(5000);
                Connect();
            }
            if (args.Progress == "Connected")
            {
                setMasterArray();
            }
        }

        private void Mt4_OnConnectionProgressed(object sender, MT4Wrapper.ConnectionProgressEventArgs args)
        {
            var reconnect = Form.UpdateState(args.Progress);
            if (reconnect)
            {
                Thread.Sleep(5000);
                Connect();
            }
            if (args.Progress == "Connected")
            {
                setMasterArray();
            }
        }

        private void Ctrader_OnConnectionProgressed(object sender, CTWrapper.ConnectionProgressEventArgs args)
        {
            var reconnect = Form.UpdateState(args.Progress);
            if (reconnect)
            {
                Thread.Sleep(5000);
                Connect();
            }
            if (args.Progress == "Connected")
            {
                setMasterArray();
            }
        }

        private void Mt5_OnTradeOccurrance(object sender, MT5Wrapper.TransactionEventArgs args)
        {
            if (args.Event == MT5WrapperInterface.TransactionEvent.OrderClosed)
            {
                foreach (var ord in args.Orders)
                {
                    var bal = getBalance();
                    bal -= ord.Profit;
                    updateMasterArray(new Trade { accountAlias = current_config.alias, orderID = ord.ClosingTicket.ToString(), symbol = ord.Symbol, closingTime = ord.CloseTime, closingTimeUnix = dbIO.ToUnixTime(ord.CloseTime), netPnLPercent = Math.Round((ord.Profit / bal) * 100, 2) });
                }
            }
        }

        private void Mt4_OnTradeOccurrance(object sender, MT4Wrapper.TransactionEventArgs args)
        {
            foreach (var dat in args.Data)
            {
                if (dat.Event == MT4WrapperInterface.TransactionEvent.OrderClosed)
                {
                    var bal = getBalance();
                    bal -= dat.Order.Profit;
                    updateMasterArray(new Trade { accountAlias = current_config.alias, orderID = dat.Order.Ticket.ToString(), symbol = dat.Order.Symbol, closingTime = dat.Order.CloseTime, closingTimeUnix = dbIO.ToUnixTime(dat.Order.CloseTime), netPnLPercent = Math.Round((dat.Order.Profit / bal) * 100, 2) });
                }
            }
        }

        private void Ctrader_OnTradeOccurrance(object sender, CTWrapper.TransactionEventArgs args)
        {
            if (args.Event == CTWrapperInterface.TransactionEvent.OrderClosed)
            {
                foreach (var ord in args.Orders)
                {
                    var bal = getBalance();
                    bal -= ord.Profit;
                    updateMasterArray(new Trade { accountAlias = current_config.alias, orderID = ord.ClosingTicket.ToString(), symbol = ord.Symbol, closingTime = ord.CloseTime, closingTimeUnix = dbIO.ToUnixTime(ord.CloseTime), netPnLPercent = Math.Round((ord.Profit / bal) * 100, 2) });
                }
            }
        }

        public void Connect()
        {
            if (GetConnectionStatus()) return;
            switch (current_config.platform)
            {
                case "CTrader":
                    Task.Run(() => ctraderapi.Connect());
                    break;
                case "MT4":
                    Task.Run(() => mt4api.Connect());
                    break;
                case "MT5":
                    Task.Run(() => mt5api.Connect());
                    break;
            }
        }

        public void Disconnect()
        {
            if (!GetConnectionStatus()) return;
            switch (current_config.platform)
            {
                case "CTrader":
                    Task.Run(() => ctraderapi.Disconnect());
                    break;
                case "MT4":
                    Task.Run(() => mt4api.Disconnect());
                    break;
                case "MT5":
                    Task.Run(() => mt5api.Disconnect());
                    break;
            }
        }

        private bool GetConnectionStatus()
        {
            switch (current_config.platform)
            {
                case "CTrader":
                    return ctraderapi.IsConnected;
                case "MT4":
                    return mt4api.IsConnected;
                case "MT5":
                    return mt5api.IsConnected;
                default:
                    return false;
            }
        }

        private double getBalance()
        {
            if (!GetConnectionStatus()) return 0;
            switch (current_config.platform)
            {
                case "CTrader":
                    return ctraderapi.GetAccountBalance();
                case "MT4":
                    return mt4api.GetAccountBalance();
                case "MT5":
                    return mt5api.GetAccountBalance();
                default:
                    return 0;
            }
        }

        private void setMasterArray()
        {
            DateTime end = DateTime.Today.AddDays(1).Add(new TimeSpan(23, 59, 59));
            DateTime start = end.Date.AddDays((current_config.days * -1));
            List<Trade> trades = new List<Trade>();
            if (!GetConnectionStatus()) return;
            switch (current_config.platform)
            {
                case "CTrader":
                    trades.AddRange(ctraderapi.GetOrderHistory(start, end).Select(x => new Trade { accountAlias = current_config.alias, orderID = x.ClosingTicket.ToString(), symbol = x.Symbol, closingTime = x.CloseTime, closingTimeUnix = dbIO.ToUnixTime(x.CloseTime), netPnLPercent = x.Profit }));
                    break;
                case "MT4":
                    trades.AddRange(mt4api.GetOrderHistory(start, end).Select(x => new Trade { accountAlias = current_config.alias, orderID = x.Ticket.ToString(), symbol = x.Symbol, closingTime = x.CloseTime, closingTimeUnix = dbIO.ToUnixTime(x.CloseTime), netPnLPercent = x.Profit }));
                    break;
                case "MT5":
                    trades.AddRange(mt5api.GetOrderHistory(start, end).Select(x => new Trade { accountAlias = current_config.alias, orderID = x.ClosingTicket.ToString(), symbol = x.Symbol, closingTime = x.CloseTime, closingTimeUnix = dbIO.ToUnixTime(x.CloseTime), netPnLPercent = x.Profit }));
                    break;
            }
            var balance = getBalance();
            for (int i = trades.Count - 1; i >= 0; i--)
            {
                balance -= trades[i].netPnLPercent;
                trades[i].netPnLPercent = (trades[i].netPnLPercent / balance) * 100;
            }

            var tradesfromDB = dbIO.LoadTrades(current_config.days);
            var res = trades.Where(tr => tradesfromDB.Find(tfdb => tfdb.accountAlias == tr.accountAlias && tfdb.orderID == tr.orderID) == null).ToList();
            dbIO.SaveTrades(res);
        }

        private void updateMasterArray(Trade trade)
        {
            dbIO.SaveTrades(new List<Trade> { trade });
        }
    }
}
