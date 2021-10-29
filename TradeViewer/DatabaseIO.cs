using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data.SQLite;

namespace TradeViewer
{
    class DatabaseIO //Needs to add constraints to accounts db [unique (accountNo, type)]
    {
        private string dbPath = @"Data Source=Datastore.db;Cache=Shared";
        private SQLiteConnection connection;

        public DatabaseIO()
        {
            connection = new SQLiteConnection(dbPath);
        }

        public void createTables()
        {
            connection.Open();

            var cmd = new SQLiteCommand(connection);
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS accounts(accountID INTEGER PRIMARY KEY, accountName TEXT, type TEXT, color INT, colorText INT, server TEXT, port INT, accountNo INT, leverage INT, 
                                currency TEXT, timezoneOffset INT, showStats INT, ddThreshold REAL, lastFetched INT, isEnabled INT, isArchived INT)";
            cmd.ExecuteNonQuery();

            //orders table not needed

            //cmd.CommandText = @"CREATE TABLE IF NOT EXISTS orders(accountID INTEGER PRIMARY KEY, orderID INT UNIQUE, symbol TEXT, direction TEXT, closingTime INT, closingQuantity REAL, swap REAL, commission REAL, grossProfit REAL, netProfit REAL)";
            //cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS uptime(accountID INTEGER PRIMARY KEY, timestamp INT, state INT)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS ddthreshold(accountID INTEGER PRIMARY KEY, timestamp INT, value REAL)";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        /*
        public bool SaveOrders(TradeOrder[] orders)
        {
            bool bRet = true;
            connection.Open();
            var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "INSERT INTO orders(accountID, orderID, symbol, direction, openingTime, closingTime, entryPrice, closingPrice, closingQuantity, swap, commission, grossProfit, netProfit)" +
                            " VALUES(@accountId, @orderId, @symbol, @direction, @closingTime, @closingQuantity, @swap, @commission, @grossProfit, @netProfit)";
            foreach (var order in orders)
            {
                cmd.Parameters.AddWithValue("@accountId", order.AccountID);
                cmd.Parameters.AddWithValue("@orderId", order.ID);
                cmd.Parameters.AddWithValue("@symbol", order.Symbol);
                cmd.Parameters.AddWithValue("@direction", order.Type.ToString());
                cmd.Parameters.AddWithValue("@closingTime", order.ClosingTime);
                cmd.Parameters.AddWithValue("@closingQuantity", order.ClosingVolume);
                cmd.Parameters.AddWithValue("@swap", order.Swap);
                cmd.Parameters.AddWithValue("@commission", order.Commission);
                cmd.Parameters.AddWithValue("@grossProfit", order.GrossProfit);
                cmd.Parameters.AddWithValue("@netProfit", order.NetProfit);
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    //Console.WriteLine("saveOrder throws exception: {0}", e);
                    bRet = false;
                }
            }
            connection.Close();
            return bRet;
        }
        */

        public bool SaveAccount(Account account, bool isSaved)
        {
            bool bRet = true;
            connection.Open();
            var cmd = new SQLiteCommand(connection);
            if (isSaved)
            {
                cmd.CommandText = "UPDATE accounts SET accountName=@name, type=@type, color=@color, colorText=@colorText, server=@server, port=@port, accountNo=@accountNo, leverage=@leverage, currency=@currency, timezoneOffset=@offset, " +
                                "showStats=@showStats, ddThreshold=@ddThreshold, lastFetched=@lastFetched, isEnabled=@enabled WHERE accountID=" + account.ID;
            }
            else
            {
                cmd.CommandText = "INSERT INTO accounts(accountID, accountName, type, color, colorText, server, port, accountNo, leverage, currency, timezoneOffset, showStats, ddThreshold, lastFetched, isEnabled, isArchived) " +
                                "VALUES(@id, @name, @type, @color, @colorText, @server, @port, @accountNo, @leverage, @currency, @offset, @showStats, @ddThreshold, @lastFetched, @enabled, @deleted)";
            }
            cmd.Parameters.AddWithValue("@id", account.ID);
            cmd.Parameters.AddWithValue("@name", account.Name);
            cmd.Parameters.AddWithValue("@type", account.Type.ToString().ToLower());
            cmd.Parameters.AddWithValue("@color", account.IndicatorColor.ToArgb());
            cmd.Parameters.AddWithValue("@colorText", account.TextColor.ToArgb());
            cmd.Parameters.AddWithValue("@server", account.Server);
            cmd.Parameters.AddWithValue("@port", account.ConnectionPort);
            cmd.Parameters.AddWithValue("@accountNo", account.AccountNo);
            cmd.Parameters.AddWithValue("@leverage", account.Leverage);
            cmd.Parameters.AddWithValue("@currency", account.Currency);
            cmd.Parameters.AddWithValue("@offset", account.TimeZoneOffset);
            cmd.Parameters.AddWithValue("@showStats", account.IsStatsShown);
            cmd.Parameters.AddWithValue("@ddThreshold", 0);
            cmd.Parameters.AddWithValue("@lastFetched", account.LastFetched.ToBinary());
            cmd.Parameters.AddWithValue("@enabled", account.IsEnabled);
            cmd.Parameters.AddWithValue("@deleted", false);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                bRet = false;
            }
            connection.Close();
            return bRet;
        }

        public bool DeleteAccount(int accountID)
        {
            bool bRet = true;
            connection.Open();
            var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "UPDATE accounts SET isArchived=@param WHERE accountID=" + accountID;
            cmd.Parameters.AddWithValue("@param", true);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                bRet = false;
            }
            connection.Close();
            return bRet;
        }

        public List<Account> LoadAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            connection.Open();
            string cmdText = "SELECT * FROM accounts ORDER BY accountID ASC";
            var cmd = new SQLiteCommand(cmdText, connection);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    var account = new Account
                    {
                        ID = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        IndicatorColor = Color.FromArgb(rdr.GetInt32(3)),
                        TextColor = Color.FromArgb(rdr.GetInt32(4)),
                        Server = rdr.GetString(5),
                        ConnectionPort = rdr.GetInt32(6),
                        AccountNo = rdr.GetInt32(7),
                        Leverage = rdr.GetInt32(8),
                        Currency = rdr.GetString(9),
                        TimeZoneOffset = rdr.GetInt32(10),
                        IsStatsShown = rdr.GetBoolean(11),
                        LastFetched = DateTime.FromBinary(rdr.GetInt64(12)),
                        IsEnabled = rdr.GetBoolean(13)
                    };

                    switch (rdr.GetString(2))
                    {
                        case "ctrader":
                            account.Type = AccountType.cTrader;
                            break;
                        case "mt4":
                            account.Type = AccountType.MT4;
                            break;
                        case "mt5":
                            account.Type = AccountType.MT5;
                            break;
                    }

                    accounts.Add(account);
                }
            }
            connection.Close();
            return accounts;
        }
    }
}
