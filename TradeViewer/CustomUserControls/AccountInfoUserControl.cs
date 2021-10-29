using System;
using System.Drawing;
using System.Windows.Forms;
using TradeViewer.Properties;

namespace TradeViewer.CustomUserControls
{
    public partial class AccountInfoUserControl : UserControl
    {
        public AccountInfoUserControl()
        {
            InitializeComponent();
        }

        public void setAccountName(string name, int color)
        {
            _accountNameLabel.Text = name;
            _colorStrip.BackColor = Color.FromArgb(color);
        }

        public void setAccountInfo(string server, int acno, int leverage, string currency)
        {
            _accountServer.Text = server;
            _accountNo.Text = acno.ToString();
            _accountLeverage.Text = leverage.ToString();
            _accountCurrency.Text = currency;
        }

        public void setServerTime(DateTime time)
        {
            _serverDate.Text = String.Format("{0:0000}-{1:00}-{2:00}", time.Year, time.Month, time.Day);
            _serverTime.Text = String.Format("{0:00}:{1:00}:{2:00}", time.Hour, time.Minute, time.Second);
        }

        public void setProfitPercent(double profitPercent)
        {
            if (profitPercent >= 0)
            {
                _pnlLabel.Text = String.Format("+ {0}%", Math.Round(profitPercent, 2));
                _pnlLabel.ForeColor = Color.Lime;
                _indicator.Image = Resources.green;
            }
            else
            {
                _pnlLabel.Text = String.Format("- {0}%", Math.Round(profitPercent, 2) * -1);
                _pnlLabel.ForeColor = Color.FromArgb(255, 89, 89);
                _indicator.Image = Resources.red;
            }
        }

        public void setProfit(double profit)
        {
            _profitLabel.Text = String.Format("{0}", Math.Round(profit, 2));
            if (profit >= 0)
                _profitLabel.ForeColor = Color.LimeGreen;
            else
                _profitLabel.ForeColor = Color.FromArgb(255, 89, 89);
        }

        public void setCurrentDD(double dd)
        {
            _dd.Text = String.Format("DD: {0}%", dd);
        }

        public void setTotalTrade(int trades)
        {
            _totalTrades.Text = trades.ToString();
        }

        public void setDDThreshold(double threshold)
        {
            _ddThreshold.Text = String.Format("{0}%", Math.Round(threshold, 2));
        }

        public void setProfitTrades(int profitTrades)
        {

        }
    }
}
