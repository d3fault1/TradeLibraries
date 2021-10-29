
namespace TradeViewer.CustomUserControls
{
    partial class AccountInfoUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._accountNameLabel = new System.Windows.Forms.Label();
            this._accountServer = new System.Windows.Forms.Label();
            this._accountNo = new System.Windows.Forms.Label();
            this._accountLeverage = new System.Windows.Forms.Label();
            this._accountCurrency = new System.Windows.Forms.Label();
            this._colorStrip = new System.Windows.Forms.Button();
            this._accountInfoPanel = new System.Windows.Forms.Panel();
            this._serverTimeGroup = new System.Windows.Forms.GroupBox();
            this._serverDate = new System.Windows.Forms.Label();
            this._serverTime = new System.Windows.Forms.Label();
            this._dailyGroup = new System.Windows.Forms.GroupBox();
            this._pnlLabel = new System.Windows.Forms.Label();
            this._dd = new System.Windows.Forms.Label();
            this._profitLabel = new System.Windows.Forms.Label();
            this._totalTrades = new System.Windows.Forms.Label();
            this._ddThreshold = new System.Windows.Forms.Label();
            this._pnlBarPanel = new System.Windows.Forms.Panel();
            this._barProfit = new System.Windows.Forms.Button();
            this._barLoss = new System.Windows.Forms.Button();
            this._profitPercent = new System.Windows.Forms.Label();
            this._lossPercent = new System.Windows.Forms.Label();
            this._profitTrade = new System.Windows.Forms.Label();
            this._lossTrade = new System.Windows.Forms.Label();
            this._indicator = new System.Windows.Forms.PictureBox();
            this._accountInfoPanel.SuspendLayout();
            this._serverTimeGroup.SuspendLayout();
            this._dailyGroup.SuspendLayout();
            this._pnlBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._indicator)).BeginInit();
            this.SuspendLayout();
            // 
            // _accountNameLabel
            // 
            this._accountNameLabel.AutoSize = true;
            this._accountNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this._accountNameLabel.ForeColor = System.Drawing.Color.White;
            this._accountNameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._accountNameLabel.Location = new System.Drawing.Point(9, 0);
            this._accountNameLabel.Name = "_accountNameLabel";
            this._accountNameLabel.Size = new System.Drawing.Size(110, 19);
            this._accountNameLabel.TabIndex = 0;
            this._accountNameLabel.Text = "Account Name";
            this._accountNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _accountServer
            // 
            this._accountServer.AutoSize = true;
            this._accountServer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this._accountServer.ForeColor = System.Drawing.Color.White;
            this._accountServer.Location = new System.Drawing.Point(3, 0);
            this._accountServer.Name = "_accountServer";
            this._accountServer.Size = new System.Drawing.Size(120, 14);
            this._accountServer.TabIndex = 1;
            this._accountServer.Text = "Server: \"Server Name\"";
            // 
            // _accountNo
            // 
            this._accountNo.AutoSize = true;
            this._accountNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this._accountNo.ForeColor = System.Drawing.Color.White;
            this._accountNo.Location = new System.Drawing.Point(3, 20);
            this._accountNo.Name = "_accountNo";
            this._accountNo.Size = new System.Drawing.Size(109, 14);
            this._accountNo.TabIndex = 2;
            this._accountNo.Text = "Account #: \"A/C No.\"";
            // 
            // _accountLeverage
            // 
            this._accountLeverage.AutoSize = true;
            this._accountLeverage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this._accountLeverage.ForeColor = System.Drawing.Color.White;
            this._accountLeverage.Location = new System.Drawing.Point(3, 41);
            this._accountLeverage.Name = "_accountLeverage";
            this._accountLeverage.Size = new System.Drawing.Size(74, 14);
            this._accountLeverage.TabIndex = 3;
            this._accountLeverage.Text = "Leverage: \"0\"";
            // 
            // _accountCurrency
            // 
            this._accountCurrency.AutoSize = true;
            this._accountCurrency.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this._accountCurrency.ForeColor = System.Drawing.Color.White;
            this._accountCurrency.Location = new System.Drawing.Point(103, 41);
            this._accountCurrency.Name = "_accountCurrency";
            this._accountCurrency.Size = new System.Drawing.Size(78, 14);
            this._accountCurrency.TabIndex = 4;
            this._accountCurrency.Text = "Currency: USD";
            // 
            // _colorStrip
            // 
            this._colorStrip.BackColor = System.Drawing.Color.LimeGreen;
            this._colorStrip.Enabled = false;
            this._colorStrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._colorStrip.Location = new System.Drawing.Point(0, 0);
            this._colorStrip.Name = "_colorStrip";
            this._colorStrip.Size = new System.Drawing.Size(8, 83);
            this._colorStrip.TabIndex = 9;
            this._colorStrip.UseVisualStyleBackColor = false;
            // 
            // _accountInfoPanel
            // 
            this._accountInfoPanel.Controls.Add(this._accountServer);
            this._accountInfoPanel.Controls.Add(this._accountNo);
            this._accountInfoPanel.Controls.Add(this._accountCurrency);
            this._accountInfoPanel.Controls.Add(this._accountLeverage);
            this._accountInfoPanel.Location = new System.Drawing.Point(13, 24);
            this._accountInfoPanel.Name = "_accountInfoPanel";
            this._accountInfoPanel.Size = new System.Drawing.Size(207, 57);
            this._accountInfoPanel.TabIndex = 10;
            // 
            // _serverTimeGroup
            // 
            this._serverTimeGroup.Controls.Add(this._serverTime);
            this._serverTimeGroup.Controls.Add(this._serverDate);
            this._serverTimeGroup.ForeColor = System.Drawing.Color.White;
            this._serverTimeGroup.Location = new System.Drawing.Point(10, 101);
            this._serverTimeGroup.Name = "_serverTimeGroup";
            this._serverTimeGroup.Size = new System.Drawing.Size(90, 58);
            this._serverTimeGroup.TabIndex = 11;
            this._serverTimeGroup.TabStop = false;
            this._serverTimeGroup.Text = "Server Time";
            // 
            // _serverDate
            // 
            this._serverDate.Location = new System.Drawing.Point(10, 18);
            this._serverDate.Name = "_serverDate";
            this._serverDate.Size = new System.Drawing.Size(74, 14);
            this._serverDate.TabIndex = 0;
            this._serverDate.Text = "YYYY-MM-DD";
            this._serverDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _serverTime
            // 
            this._serverTime.Location = new System.Drawing.Point(17, 34);
            this._serverTime.Name = "_serverTime";
            this._serverTime.Size = new System.Drawing.Size(61, 15);
            this._serverTime.TabIndex = 1;
            this._serverTime.Text = "HH:MM:SS";
            this._serverTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _dailyGroup
            // 
            this._dailyGroup.Controls.Add(this._profitLabel);
            this._dailyGroup.Controls.Add(this._dd);
            this._dailyGroup.Controls.Add(this._pnlLabel);
            this._dailyGroup.ForeColor = System.Drawing.Color.White;
            this._dailyGroup.Location = new System.Drawing.Point(106, 101);
            this._dailyGroup.Name = "_dailyGroup";
            this._dailyGroup.Size = new System.Drawing.Size(111, 58);
            this._dailyGroup.TabIndex = 12;
            this._dailyGroup.TabStop = false;
            this._dailyGroup.Text = "Daily";
            // 
            // _pnlLabel
            // 
            this._pnlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlLabel.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this._pnlLabel.ForeColor = System.Drawing.Color.Lime;
            this._pnlLabel.Location = new System.Drawing.Point(6, 8);
            this._pnlLabel.Name = "_pnlLabel";
            this._pnlLabel.Size = new System.Drawing.Size(105, 24);
            this._pnlLabel.TabIndex = 0;
            this._pnlLabel.Text = "+ 0.00%";
            this._pnlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _dd
            // 
            this._dd.Font = new System.Drawing.Font("Calibri", 8F);
            this._dd.Location = new System.Drawing.Point(0, 41);
            this._dd.Name = "_dd";
            this._dd.Size = new System.Drawing.Size(58, 13);
            this._dd.TabIndex = 1;
            this._dd.Text = "DD: 0.56%";
            // 
            // _profitLabel
            // 
            this._profitLabel.Font = new System.Drawing.Font("Calibri", 8F);
            this._profitLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this._profitLabel.Location = new System.Drawing.Point(76, 41);
            this._profitLabel.Name = "_profitLabel";
            this._profitLabel.Size = new System.Drawing.Size(35, 13);
            this._profitLabel.TabIndex = 13;
            this._profitLabel.Text = "29.56";
            this._profitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _totalTrades
            // 
            this._totalTrades.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this._totalTrades.ForeColor = System.Drawing.Color.White;
            this._totalTrades.Location = new System.Drawing.Point(13, 162);
            this._totalTrades.Name = "_totalTrades";
            this._totalTrades.Size = new System.Drawing.Size(74, 33);
            this._totalTrades.TabIndex = 13;
            this._totalTrades.Text = "Trades: 200";
            this._totalTrades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _ddThreshold
            // 
            this._ddThreshold.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this._ddThreshold.ForeColor = System.Drawing.Color.White;
            this._ddThreshold.Location = new System.Drawing.Point(96, 162);
            this._ddThreshold.Name = "_ddThreshold";
            this._ddThreshold.Size = new System.Drawing.Size(124, 33);
            this._ddThreshold.TabIndex = 14;
            this._ddThreshold.Text = "DD Threshold: 2.00%";
            this._ddThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _pnlBarPanel
            // 
            this._pnlBarPanel.Controls.Add(this._profitPercent);
            this._pnlBarPanel.Controls.Add(this._lossTrade);
            this._pnlBarPanel.Controls.Add(this._profitTrade);
            this._pnlBarPanel.Controls.Add(this._lossPercent);
            this._pnlBarPanel.Controls.Add(this._barLoss);
            this._pnlBarPanel.Controls.Add(this._barProfit);
            this._pnlBarPanel.Location = new System.Drawing.Point(7, 199);
            this._pnlBarPanel.Name = "_pnlBarPanel";
            this._pnlBarPanel.Size = new System.Drawing.Size(210, 52);
            this._pnlBarPanel.TabIndex = 15;
            // 
            // _barProfit
            // 
            this._barProfit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._barProfit.BackColor = System.Drawing.Color.Lime;
            this._barProfit.Enabled = false;
            this._barProfit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._barProfit.ForeColor = System.Drawing.SystemColors.ControlText;
            this._barProfit.Location = new System.Drawing.Point(0, 17);
            this._barProfit.Name = "_barProfit";
            this._barProfit.Size = new System.Drawing.Size(143, 19);
            this._barProfit.TabIndex = 0;
            this._barProfit.UseVisualStyleBackColor = false;
            // 
            // _barLoss
            // 
            this._barLoss.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._barLoss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this._barLoss.Enabled = false;
            this._barLoss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._barLoss.Location = new System.Drawing.Point(142, 17);
            this._barLoss.Name = "_barLoss";
            this._barLoss.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._barLoss.Size = new System.Drawing.Size(68, 19);
            this._barLoss.TabIndex = 1;
            this._barLoss.UseVisualStyleBackColor = false;
            // 
            // _profitPercent
            // 
            this._profitPercent.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this._profitPercent.ForeColor = System.Drawing.Color.White;
            this._profitPercent.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._profitPercent.Location = new System.Drawing.Point(44, 0);
            this._profitPercent.Name = "_profitPercent";
            this._profitPercent.Size = new System.Drawing.Size(35, 13);
            this._profitPercent.TabIndex = 2;
            this._profitPercent.Text = "68%";
            this._profitPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lossPercent
            // 
            this._lossPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lossPercent.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this._lossPercent.ForeColor = System.Drawing.Color.White;
            this._lossPercent.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._lossPercent.Location = new System.Drawing.Point(140, 0);
            this._lossPercent.Name = "_lossPercent";
            this._lossPercent.Size = new System.Drawing.Size(35, 13);
            this._lossPercent.TabIndex = 16;
            this._lossPercent.Text = "32%";
            this._lossPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _profitTrade
            // 
            this._profitTrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._profitTrade.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this._profitTrade.ForeColor = System.Drawing.Color.White;
            this._profitTrade.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._profitTrade.Location = new System.Drawing.Point(44, 39);
            this._profitTrade.Name = "_profitTrade";
            this._profitTrade.Size = new System.Drawing.Size(35, 13);
            this._profitTrade.TabIndex = 17;
            this._profitTrade.Text = "136";
            this._profitTrade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lossTrade
            // 
            this._lossTrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._lossTrade.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this._lossTrade.ForeColor = System.Drawing.Color.White;
            this._lossTrade.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._lossTrade.Location = new System.Drawing.Point(140, 39);
            this._lossTrade.Name = "_lossTrade";
            this._lossTrade.Size = new System.Drawing.Size(35, 13);
            this._lossTrade.TabIndex = 18;
            this._lossTrade.Text = "64";
            this._lossTrade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _indicator
            // 
            this._indicator.Image = global::TradeViewer.Properties.Resources.green;
            this._indicator.Location = new System.Drawing.Point(208, 3);
            this._indicator.Name = "_indicator";
            this._indicator.Size = new System.Drawing.Size(12, 12);
            this._indicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._indicator.TabIndex = 16;
            this._indicator.TabStop = false;
            // 
            // AccountInfoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._indicator);
            this.Controls.Add(this._pnlBarPanel);
            this.Controls.Add(this._ddThreshold);
            this.Controls.Add(this._totalTrades);
            this.Controls.Add(this._dailyGroup);
            this.Controls.Add(this._serverTimeGroup);
            this.Controls.Add(this._accountInfoPanel);
            this.Controls.Add(this._colorStrip);
            this.Controls.Add(this._accountNameLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Name = "AccountInfoUserControl";
            this.Size = new System.Drawing.Size(223, 263);
            this._accountInfoPanel.ResumeLayout(false);
            this._accountInfoPanel.PerformLayout();
            this._serverTimeGroup.ResumeLayout(false);
            this._dailyGroup.ResumeLayout(false);
            this._pnlBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._indicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _accountNameLabel;
        private System.Windows.Forms.Label _accountServer;
        private System.Windows.Forms.Label _accountNo;
        private System.Windows.Forms.Label _accountLeverage;
        private System.Windows.Forms.Label _accountCurrency;
        private System.Windows.Forms.Button _colorStrip;
        private System.Windows.Forms.Panel _accountInfoPanel;
        private System.Windows.Forms.GroupBox _serverTimeGroup;
        private System.Windows.Forms.Label _serverTime;
        private System.Windows.Forms.Label _serverDate;
        private System.Windows.Forms.GroupBox _dailyGroup;
        private System.Windows.Forms.Label _profitLabel;
        private System.Windows.Forms.Label _dd;
        private System.Windows.Forms.Label _pnlLabel;
        private System.Windows.Forms.Label _totalTrades;
        private System.Windows.Forms.Label _ddThreshold;
        private System.Windows.Forms.Panel _pnlBarPanel;
        private System.Windows.Forms.Label _profitPercent;
        private System.Windows.Forms.Label _lossTrade;
        private System.Windows.Forms.Label _profitTrade;
        private System.Windows.Forms.Label _lossPercent;
        private System.Windows.Forms.Button _barLoss;
        private System.Windows.Forms.Button _barProfit;
        private System.Windows.Forms.PictureBox _indicator;
    }
}
