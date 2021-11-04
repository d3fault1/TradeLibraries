using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TradeLoggerMini
{
    class IO
    {
        private string dbPath = @"Data Source=minidb.db;Cache=Shared";
        private SQLiteConnection connection;

        public IO()
        {
            connection = new SQLiteConnection(dbPath);
        }

        public void createTables()
        {
            connection.Open();

            var cmd = new SQLiteCommand(connection);
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS trades(accountAlias TEXT, orderID TEXT, closingTimeUnix INT, closingTime TEXT, symbol TEXT, netPnLPercent REAL)";
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public Config LoadConfig()
        {
            if (File.Exists("config.ini"))
            {
                using (FileStream fs = File.OpenRead("config.ini"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (Config)bf.Deserialize(fs);
                }
            }
            else return null;
        }

        public void SaveConfig(Config config)
        {
            using (FileStream fs = new FileStream("config.ini", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, config);
            }
        }

        public List<Trade> LoadTrades(int days)
        {
            var trades = new List<Trade>();
            if (File.Exists("minidb.db"))
            {
                connection.Open();
                var cmd = new SQLiteCommand(connection);
                cmd.CommandText = "SELECT * FROM trades WHERE closingTimeUnix BETWEEN @start AND @end";
                var enddate = DateTime.Today.AddDays(1).Add(new TimeSpan(23, 59, 59));
                var startdate = enddate.Date.AddDays((days * -1));
                var start = ToUnixTime(startdate);
                var end = ToUnixTime(enddate);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Prepare();

                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        var trade = new Trade
                        {
                            accountAlias = rdr.GetString(0),
                            orderID = rdr.GetString(1),
                            closingTimeUnix = rdr.GetInt64(2),
                            closingTime = DateTime.Parse(rdr.GetString(3)),
                            symbol = rdr.GetString(4),
                            netPnLPercent = rdr.GetDouble(5)
                        };
                        trades.Add(trade);
                    }
                }
                connection.Close();
            }
            return trades;
        }

        public bool SaveTrades(List<Trade> trades)
        {
            if (!File.Exists("minidb.db")) createTables();
            bool bRet = true;
            connection.Open();
            var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "INSERT INTO trades(accountAlias, orderID, closingTimeUnix, closingTime, symbol, netPnLPercent) " + "VALUES(@alias, @oid, @closetimeunix, @closetime, @symbol, @pnl)";
            foreach (var trade in trades)
            {
                cmd.Parameters.AddWithValue("@alias", trade.accountAlias);
                cmd.Parameters.AddWithValue("@oid", trade.orderID);
                cmd.Parameters.AddWithValue("@closetimeunix", trade.closingTimeUnix);
                cmd.Parameters.AddWithValue("@closetime", trade.closingTime.ToString());
                cmd.Parameters.AddWithValue("@symbol", trade.symbol);
                cmd.Parameters.AddWithValue("@pnl", trade.netPnLPercent);

                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Error saving trade: " + e.Message);
                    bRet = false;
                }
            }
            connection.Close();
            return bRet;
        }

        public long ToUnixTime(DateTime time)
        {
            var localTime = new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.Millisecond, DateTimeKind.Local);
            return (long)(TimeZoneInfo.ConvertTimeToUtc(localTime) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        public DateTime FromUnixTime(double value)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value);
        }
    }
}
