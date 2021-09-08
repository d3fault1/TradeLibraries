using System;
using System.Threading;
using System.Linq;
using Fclp;
using MT5WrapperInterface;
using MT4WrapperInterface;
using System.Diagnostics;

namespace Demo
{
    class Program
    {
        private MT4Wrapper wrapper = new MT4Wrapper();

        //private struct CredFormat
        //{
        //    public string server;
        //    public ulong user;
        //    public string pass;
        //}

        //private CredFormat creds = new CredFormat();

        static void Main(string[] args)
        {
            bool firstflag = true;
            string input = "";
            var cmd = new FluentCommandLineParser();
            cmd.Setup<string>('x').Callback(command => input = command).WithDescription("Executes a command upon opening the wrapper terminal [optional]");
            var res = cmd.Parse(args);
            if (res.AdditionalOptionsFound.ToArray().Length > 0)
            {
                Console.WriteLine($"{res.AdditionalOptionsFound.First().Key} is not recognized");
                return;
            }
            if (!res.EmptyArgs || args.Length > 1)
            {
                Console.WriteLine(">Invalid syntax");
                return;
            }

            var main = new Program();
            while (true)
            {
                if (!firstflag)
                {
                    Console.Write(">");
                    input = Console.ReadLine();
                }
                firstflag = false;
                var mode = "";
                var temp = input.Split(' ');
                mode = temp[0];
                input = "";
                if (temp.Length > 1)
                    for (int i = 1; i < temp.Length; i++)
                        input += temp[i] + " ";
                input = input.Trim();
                if (mode.ToLower() == "connect")
                {
                    //string server = "", pass = "";
                    //ulong user = 0;
                    //var parser = new FluentCommandLineParser();
                    //parser.Setup<string>("server").Callback(srv => server = srv).Required();
                    //parser.Setup<string>("accno").Callback(no => user = Convert.ToUInt64(no)).Required();
                    //parser.Setup<string>("pass").Callback(ps => pass = ps).Required();
                    //var _res = parser.Parse(input.Split(' '));
                    //if (_res.HasErrors)
                    //{
                    //    Console.WriteLine(">Invalid syntax. See help");
                    //    continue;
                    //}
                    //main.creds.server = server;
                    //main.creds.user = user;
                    //main.creds.pass = pass;

                    if (input != "")
                    {
                        if (input != "")
                        {
                            Console.WriteLine(">Invalid syntax. See help");
                        }
                    }
                    Console.WriteLine(">Connecting to the server...");
                    //main.Connect(server, user, pass);
                    main.Connect();
                    //Console.WriteLine(">Succesful");
                    Thread.Sleep(100);
                }
                else if (mode.ToLower() == "disconnect")
                {
                    if (input != "")
                    {
                        if (input != "")
                        {
                            Console.WriteLine(">Invalid syntax. See help");
                        }
                    }
                    else main.Disconnect();
                }
                else if (mode.ToLower() == "getaccinfo")
                {
                    if (input != "")
                    {
                        if (input != "")
                        {
                            Console.WriteLine(">Invalid syntax. See help");
                        }
                    }
                    else main.GetAccInfo();
                }
                else if (mode.ToLower() == "getservertime")
                {
                    if (input != "")
                    {
                        if (input != "")
                        {
                            Console.WriteLine(">Invalid syntax. See help");
                        }
                    }
                    else main.GetServerTime();
                }
                else if (mode.ToLower() == "getbalance")
                {
                    if (input != "")
                    {
                        if (input != "")
                        {
                            Console.WriteLine(">Invalid syntax. See help");
                        }
                    }
                    else main.GetBalance();
                }
                else if (mode.ToLower() == "getequity")
                {
                    if (input != "")
                    {
                        if (input != "")
                        {
                            Console.WriteLine(">Invalid syntax. See help");
                        }
                    }
                    else main.GetEquity();
                }
                else if (mode.ToLower() == "pollequity")
                {
                    if (input != "")
                    {
                        if (input != "")
                        {
                            Console.WriteLine(">Invalid syntax. See help");
                        }
                    }
                    else main.PollEquity();
                }
                else if (mode.ToLower() == "gethistory")
                {
                    string start = "", end = "";
                    var parser = new FluentCommandLineParser();
                    parser.Setup<string>("start").Callback(srv => start = srv).Required();
                    parser.Setup<string>("end").Callback(no => end = no).Required();
                    var _res = parser.Parse(input.Split(' '));
                    if (_res.HasErrors)
                    {
                        Console.WriteLine(">Invalid syntax. See help");
                        continue;
                    }
                    main.GetOrderHistory(DateTime.Parse(start), DateTime.Parse(end));
                }
                else if (mode.ToLower() == "getpositions")
                {
                    if (input != "")
                    {
                        if (input != "")
                        {
                            Console.WriteLine(">Invalid syntax. See help");
                        }
                    }
                    else main.GetPositions();
                }
                else if (mode.ToLower() == "closepositions")
                {
                    bool all = true, winners = false, losers = false;
                    var parser = new FluentCommandLineParser();
                    parser.Setup<bool>("all").Callback(srv => all = srv);
                    parser.Setup<bool>("winners").Callback(no => winners = no);
                    parser.Setup<bool>("losers").Callback(no => losers = no);
                    var _res = parser.Parse(input.Split(' '));
                    if (_res.HasErrors)
                    {
                        Console.WriteLine(">Invalid syntax. See help");
                        continue;
                    }
                    if (winners) main.ClosePositions(1);
                    else if (losers) main.ClosePositions(2);
                    else if (all) main.ClosePositions(0);
                }
                else if (mode.ToLower() == "help")
                {
                    if (input != "")
                    {
                        Console.WriteLine(">Invalid syntax. See help");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(">Usage:");
                        Console.WriteLine("\tconnect"); //  --server=ICMarketsSC-Demo --accno=50634120 --pass=fHz9QWeD
                        Console.WriteLine("\tgetaccinfo");
                        Console.WriteLine("\tgetservertime");
                        Console.WriteLine("\tgetbalance");
                        Console.WriteLine("\tgetequity");
                        Console.WriteLine("\tgethistory --start=\"2021-05-02 00:00:00\" --end=\"2021-05-02 23:59:59\"");
                        Console.WriteLine("\tgetpositions");
                        Console.WriteLine("\tclosepositions [--all, --winners, --losers]");
                    }
                }
                else if (mode.ToLower() == "exit")
                {
                    if (input != "")
                    {
                        Console.WriteLine(">Invalid syntax. See help");
                        continue;
                    }
                    else return;
                }
                else if (mode.ToLower() != "")
                {
                    Console.WriteLine("Invalid syntax. See help");
                }
            }
        }

        public Program()
        {
            wrapper.OnConnectionProgressed += ConnectionProgressed;
            wrapper.OnTradeOccurrance += TradeOccurrance;
        }

        private void QuoteUpdate(object sender, MT4Wrapper.QuoteEventArgs args)
        {
            p.StandardInput.WriteLine("echo " + wrapper.GetAccountEquity());
        }

        private void TradeOccurrance(object sender, MT4Wrapper.TransactionEventArgs args)
        {
            //Console.WriteLine(args.Event);
            //foreach (var order in args.Orders)
            //    Console.WriteLine($">Symbol: {order.Symbol}, Ticket: {order.Ticket}, Time: {order.Time}, Type: {order.Type}, Volume: {order.Lots}, Price: {order.Price}, Profit: {order.Profit}");
            foreach (var data in args.Data)
            {
                Console.WriteLine(data.Event);
                Console.WriteLine($">Symbol: {data.Order.Symbol}, Ticket: {data.Order.Ticket}, Time: {data.Order.Time}, Type: {data.Order.Type}, Volume: {data.Order.Lots}, Price: {data.Order.Price}, Profit: {data.Order.Profit}");
            }
        }

        private void ConnectionProgressed(object sender, MT4Wrapper.ConnectionProgressEventArgs args)
        {
            //if (args.Progress == "Disconnected")
            //{
            //    Console.WriteLine(">Disconnected! Attempting reconnection...");
            //    Connect();
            //    //Connect(creds.server, creds.user, creds.pass);
            //    //Console.Write(">");
            //    return;
            //}
            Console.WriteLine(">" + args.Message);

            //if (args.Progress == "Connected")
            //{
            //    //Console.WriteLine(">Updating profile data... Please wait...");
            //    Console.Write(">");
            //}
        }

        private void Connect()
        {
            //var res = wrapper.Connect(server, user, pass);
            var res = wrapper.Connect();
            switch (res)
            {
                case 0:
                    return;
                case 1:
                    Console.WriteLine(">Servers.dat file not found. Aborted!");
                    return;
                case 2:
                    Console.WriteLine(">Invalid Servers.dat file. Aborted!");
                    return;
                case 3:
                    Console.WriteLine(">Server name not found in the servers.dat file. Please make sure logged in to your account on MT5 terminal before copying the dat file. Aborted!");
                    return;
                case 4:
                    Console.WriteLine(">Authentication or connection issue. Make sure you have given correct user and pass. Also make sure you have active internet connection. Aborted!");
                    return;
            }
            Console.Write(">");
        }

        private void Disconnect()
        {
            Console.WriteLine(">Initiating disconnect...");
            wrapper.OnConnectionProgressed -= ConnectionProgressed;
            var res = wrapper.Disconnect();
            wrapper.OnConnectionProgressed += ConnectionProgressed;
            switch (res)
            {
                case 0:
                    Console.WriteLine(">Succesfully disconnected!");
                    return;
                case 1:
                    Console.WriteLine(">No disconnection occured!");
                    return;
            }
            Console.Write(">");
        }

        private void GetAccInfo()
        {
            var info = wrapper.GetAccountInfo();
            Console.WriteLine(">" + info.BrokerName);
            Console.WriteLine(">" + info.ServerName);
            Console.WriteLine(">" + info.AccountName);
            Console.WriteLine(">" + info.AccountNumber);
            Console.WriteLine(">" + info.AccountLeverage);
            Console.WriteLine(">" + info.AccountCurrency);
        }

        private void GetServerTime()
        {
            //Console.WriteLine(">Waiting for update...");
            var time = wrapper.GetServerTime();
            //Console.WriteLine(">Got server time");
            Console.WriteLine(">" + time);
        }

        private void GetBalance()
        {
            var balance = wrapper.GetAccountBalance();
            Console.WriteLine(">" + balance);
        }

        private void GetEquity()
        {
            var equity = wrapper.GetAccountEquity();
            Console.WriteLine(">" + equity);
        }
        Process p = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false
            }
        };
        private void PollEquity()
        {
            p.Start();
            p.StandardInput.AutoFlush = true;
            wrapper.OnQuoteUpdate += QuoteUpdate;
        }
        private void GetOrderHistory(DateTime start, DateTime end)
        {
            Console.WriteLine(">Fetching order history...");
            var orders = wrapper.GetOrderHistory(start, end);
            foreach (var order in orders)
                Console.WriteLine($">Symbol: {order.Symbol}, Ticket: {order.Ticket}, Time: {order.Time}, Type: {order.Type}, Volume: {order.Lots}, Price: {order.Price}, Profit: {order.Profit}");
        }

        private void GetPositions()
        {
            Console.WriteLine(">Fetching positions...");
            var orders = wrapper.GetPositions();
            foreach (var order in orders)
                Console.WriteLine($">Symbol: {order.Symbol}, Ticket: {order.Ticket}, Time: {order.Time}, Type: {order.Type}, Volume: {order.Lots}, Price: {order.Price}, Profit: {order.Profit}");
        }

        private void ClosePositions(int mode)
        {
            wrapper.ClosePositions(mode);
            Console.WriteLine(">Succesfully closed positions");
        }
    }
}
