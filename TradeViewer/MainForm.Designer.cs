
namespace TradeViewer
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.labelChooseDate = new System.Windows.Forms.Label();
            this.labelLive = new System.Windows.Forms.Label();
            this.toggleLive = new JCS.ToggleSwitch();
            this.mainTabControl = new TradeViewer.CustomTabControl(this.components);
            this.dashboardTab = new System.Windows.Forms.TabPage();
            this.toggleNoComm = new JCS.ToggleSwitch();
            this._noCommLabel = new System.Windows.Forms.Label();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.accountTabControl = new TradeViewer.CustomTabControl(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.addAccountButton = new System.Windows.Forms.Button();
            this.accountTypeComboBox = new System.Windows.Forms.ComboBox();
            this.accountNameTextBox = new System.Windows.Forms.TextBox();
            this.logTab = new System.Windows.Forms.TabPage();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.accountsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bottomLabel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.localTimeLabel = new System.Windows.Forms.Label();
            this.logLabel = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uptI = new System.Windows.Forms.Label();
            this.dntI = new System.Windows.Forms.Label();
            this.lvdI = new System.Windows.Forms.Label();
            this.uptB = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timingBarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.licenseGroupBox = new System.Windows.Forms.GroupBox();
            this.hwIDLabel = new System.Windows.Forms.Label();
            this.acodeLabel = new System.Windows.Forms.Label();
            this.hIdLabel = new System.Windows.Forms.Label();
            this.hwIDTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.mainTabControl.SuspendLayout();
            this.dashboardTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.settingsTab.SuspendLayout();
            this.logTab.SuspendLayout();
            this.aboutTab.SuspendLayout();
            this.bottomLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timingBarChart)).BeginInit();
            this.licenseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelChooseDate
            // 
            this.labelChooseDate.AutoSize = true;
            this.labelChooseDate.ForeColor = System.Drawing.Color.White;
            this.labelChooseDate.Location = new System.Drawing.Point(5, 19);
            this.labelChooseDate.Name = "labelChooseDate";
            this.labelChooseDate.Size = new System.Drawing.Size(85, 14);
            this.labelChooseDate.TabIndex = 0;
            this.labelChooseDate.Text = "Choose a date";
            // 
            // labelLive
            // 
            this.labelLive.AutoSize = true;
            this.labelLive.ForeColor = System.Drawing.Color.White;
            this.labelLive.Location = new System.Drawing.Point(144, 19);
            this.labelLive.Name = "labelLive";
            this.labelLive.Size = new System.Drawing.Size(29, 14);
            this.labelLive.TabIndex = 1;
            this.labelLive.Text = "LIVE";
            // 
            // toggleLive
            // 
            this.toggleLive.Checked = true;
            this.toggleLive.Location = new System.Drawing.Point(180, 14);
            this.toggleLive.Name = "toggleLive";
            this.toggleLive.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleLive.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleLive.Size = new System.Drawing.Size(50, 19);
            this.toggleLive.TabIndex = 0;
            // 
            // mainTabControl
            // 
            this.mainTabControl.ActiveTabEndColor = System.Drawing.Color.SteelBlue;
            this.mainTabControl.ActiveTabStartColor = System.Drawing.Color.SteelBlue;
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.CloseButtonColor = System.Drawing.Color.SteelBlue;
            this.mainTabControl.Controls.Add(this.dashboardTab);
            this.mainTabControl.Controls.Add(this.settingsTab);
            this.mainTabControl.Controls.Add(this.logTab);
            this.mainTabControl.Controls.Add(this.aboutTab);
            this.mainTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.mainTabControl.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.mainTabControl.GradientAngle = 90;
            this.mainTabControl.ItemSize = new System.Drawing.Size(0, 25);
            this.mainTabControl.Location = new System.Drawing.Point(260, 2);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.NonActiveTabEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.mainTabControl.NonActiveTabStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.mainTabControl.Padding = new System.Drawing.Point(10, 3);
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(905, 781);
            this.mainTabControl.TabIndex = 2;
            this.mainTabControl.TextColor = System.Drawing.Color.White;
            this.mainTabControl.Transparent1 = 150;
            this.mainTabControl.Transparent2 = 150;
            // 
            // dashboardTab
            // 
            this.dashboardTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dashboardTab.Controls.Add(this.toggleNoComm);
            this.dashboardTab.Controls.Add(this._noCommLabel);
            this.dashboardTab.Controls.Add(this.mainChart);
            this.dashboardTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dashboardTab.Location = new System.Drawing.Point(1, 26);
            this.dashboardTab.Name = "dashboardTab";
            this.dashboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.dashboardTab.Size = new System.Drawing.Size(903, 755);
            this.dashboardTab.TabIndex = 0;
            this.dashboardTab.Text = "Dashboard";
            this.dashboardTab.UseVisualStyleBackColor = true;
            // 
            // toggleNoComm
            // 
            this.toggleNoComm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.toggleNoComm.Checked = true;
            this.toggleNoComm.Location = new System.Drawing.Point(79, 15);
            this.toggleNoComm.Name = "toggleNoComm";
            this.toggleNoComm.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleNoComm.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleNoComm.Size = new System.Drawing.Size(50, 19);
            this.toggleNoComm.TabIndex = 2;
            // 
            // _noCommLabel
            // 
            this._noCommLabel.AutoSize = true;
            this._noCommLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this._noCommLabel.Font = new System.Drawing.Font("Calibri", 9F);
            this._noCommLabel.ForeColor = System.Drawing.Color.White;
            this._noCommLabel.Location = new System.Drawing.Point(12, 20);
            this._noCommLabel.Name = "_noCommLabel";
            this._noCommLabel.Size = new System.Drawing.Size(61, 14);
            this._noCommLabel.TabIndex = 1;
            this._noCommLabel.Text = "No Comm.";
            // 
            // mainChart
            // 
            this.mainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Calibri", 9.75F);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LabelStyle.Interval = 3D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 3D;
            chartArea1.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisX.MajorGrid.Interval = 3D;
            chartArea1.AxisX.MajorGrid.IntervalOffset = 3D;
            chartArea1.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.None;
            chartArea1.AxisX.MaximumAutoSize = 100F;
            chartArea1.AxisX2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisX2.MajorTickMark.Enabled = false;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Calibri", 9.75F);
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.BorderWidth = 0;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 97F;
            chartArea1.InnerPlotPosition.Width = 97F;
            chartArea1.InnerPlotPosition.X = 3F;
            chartArea1.Name = "MainArea";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.mainChart.ChartAreas.Add(chartArea1);
            legend1.AutoFitMinFontSize = 12;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.BorderColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.MaximumAutoSize = 100F;
            legend1.Name = "MainLegend";
            legend1.TextWrapThreshold = 100;
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(0, 0);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(903, 756);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "Main Chart";
            // 
            // settingsTab
            // 
            this.settingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.settingsTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsTab.Controls.Add(this.accountTabControl);
            this.settingsTab.Controls.Add(this.button1);
            this.settingsTab.Controls.Add(this.addAccountButton);
            this.settingsTab.Controls.Add(this.accountTypeComboBox);
            this.settingsTab.Controls.Add(this.accountNameTextBox);
            this.settingsTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settingsTab.Location = new System.Drawing.Point(1, 26);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(903, 755);
            this.settingsTab.TabIndex = 1;
            this.settingsTab.Text = "Settings";
            // 
            // accountTabControl
            // 
            this.accountTabControl.ActiveTabEndColor = System.Drawing.Color.SteelBlue;
            this.accountTabControl.ActiveTabStartColor = System.Drawing.Color.SteelBlue;
            this.accountTabControl.CloseButtonColor = System.Drawing.Color.SteelBlue;
            this.accountTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.accountTabControl.GradientAngle = 90;
            this.accountTabControl.ItemSize = new System.Drawing.Size(100, 22);
            this.accountTabControl.Location = new System.Drawing.Point(20, 58);
            this.accountTabControl.Name = "accountTabControl";
            this.accountTabControl.NonActiveTabEndColor = System.Drawing.Color.White;
            this.accountTabControl.NonActiveTabStartColor = System.Drawing.Color.White;
            this.accountTabControl.Padding = new System.Drawing.Point(22, 4);
            this.accountTabControl.SelectedIndex = 0;
            this.accountTabControl.Size = new System.Drawing.Size(684, 313);
            this.accountTabControl.TabIndex = 4;
            this.accountTabControl.TextColor = System.Drawing.Color.White;
            this.accountTabControl.Transparent1 = 150;
            this.accountTabControl.Transparent2 = 150;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(598, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Delete Account";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // addAccountButton
            // 
            this.addAccountButton.BackColor = System.Drawing.Color.DimGray;
            this.addAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAccountButton.ForeColor = System.Drawing.Color.White;
            this.addAccountButton.Location = new System.Drawing.Point(345, 17);
            this.addAccountButton.Name = "addAccountButton";
            this.addAccountButton.Size = new System.Drawing.Size(106, 25);
            this.addAccountButton.TabIndex = 2;
            this.addAccountButton.Text = "Add Account";
            this.addAccountButton.UseVisualStyleBackColor = false;
            // 
            // accountTypeComboBox
            // 
            this.accountTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.accountTypeComboBox.DisplayMember = "cTrader";
            this.accountTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountTypeComboBox.ForeColor = System.Drawing.Color.Orange;
            this.accountTypeComboBox.FormattingEnabled = true;
            this.accountTypeComboBox.Items.AddRange(new object[] {
            "ctrader",
            "MT5"});
            this.accountTypeComboBox.Location = new System.Drawing.Point(204, 19);
            this.accountTypeComboBox.Name = "accountTypeComboBox";
            this.accountTypeComboBox.Size = new System.Drawing.Size(121, 23);
            this.accountTypeComboBox.TabIndex = 1;
            // 
            // accountNameTextBox
            // 
            this.accountNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.accountNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountNameTextBox.ForeColor = System.Drawing.Color.Orange;
            this.accountNameTextBox.Location = new System.Drawing.Point(20, 19);
            this.accountNameTextBox.Name = "accountNameTextBox";
            this.accountNameTextBox.Size = new System.Drawing.Size(167, 23);
            this.accountNameTextBox.TabIndex = 0;
            this.accountNameTextBox.Text = "Myaccount #1 (ctrader)";
            // 
            // logTab
            // 
            this.logTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.logTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTab.Controls.Add(this.timingBarChart);
            this.logTab.Controls.Add(this.button3);
            this.logTab.Controls.Add(this.button2);
            this.logTab.Controls.Add(this.uptB);
            this.logTab.Controls.Add(this.lvdI);
            this.logTab.Controls.Add(this.dntI);
            this.logTab.Controls.Add(this.uptI);
            this.logTab.Controls.Add(this.label2);
            this.logTab.Controls.Add(this.logTextBox);
            this.logTab.Controls.Add(this.logLabel);
            this.logTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.logTab.Location = new System.Drawing.Point(1, 26);
            this.logTab.Name = "logTab";
            this.logTab.Padding = new System.Windows.Forms.Padding(3);
            this.logTab.Size = new System.Drawing.Size(903, 755);
            this.logTab.TabIndex = 2;
            this.logTab.Text = "Log";
            // 
            // aboutTab
            // 
            this.aboutTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.aboutTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aboutTab.Controls.Add(this.licenseGroupBox);
            this.aboutTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.aboutTab.Location = new System.Drawing.Point(1, 26);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Padding = new System.Windows.Forms.Padding(3);
            this.aboutTab.Size = new System.Drawing.Size(903, 755);
            this.aboutTab.TabIndex = 3;
            this.aboutTab.Text = "About";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.AllowDrop = true;
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Arial", 13F);
            this.dateTimePicker.CalendarForeColor = System.Drawing.Color.White;
            this.dateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePicker.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dateTimePicker.CalendarTrailingForeColor = System.Drawing.Color.Black;
            this.dateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker.Font = new System.Drawing.Font("Arial", 13F);
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(8, 44);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(246, 27);
            this.dateTimePicker.TabIndex = 3;
            // 
            // accountsFlowPanel
            // 
            this.accountsFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.accountsFlowPanel.AutoScroll = true;
            this.accountsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.accountsFlowPanel.Location = new System.Drawing.Point(4, 77);
            this.accountsFlowPanel.Name = "accountsFlowPanel";
            this.accountsFlowPanel.Size = new System.Drawing.Size(250, 706);
            this.accountsFlowPanel.TabIndex = 4;
            this.accountsFlowPanel.WrapContents = false;
            // 
            // bottomLabel
            // 
            this.bottomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.bottomLabel.Controls.Add(this.localTimeLabel);
            this.bottomLabel.Controls.Add(this.label1);
            this.bottomLabel.Location = new System.Drawing.Point(-6, 787);
            this.bottomLabel.Name = "bottomLabel";
            this.bottomLabel.Size = new System.Drawing.Size(1170, 25);
            this.bottomLabel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "25ms, N/A";
            // 
            // localTimeLabel
            // 
            this.localTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localTimeLabel.ForeColor = System.Drawing.Color.White;
            this.localTimeLabel.Location = new System.Drawing.Point(982, 5);
            this.localTimeLabel.Name = "localTimeLabel";
            this.localTimeLabel.Size = new System.Drawing.Size(185, 14);
            this.localTimeLabel.TabIndex = 1;
            this.localTimeLabel.Text = "Local Time: 2020/10/12 14:25:23";
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.ForeColor = System.Drawing.Color.White;
            this.logLabel.Location = new System.Drawing.Point(19, 27);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(139, 15);
            this.logLabel.TabIndex = 0;
            this.logLabel.Text = "Connection / Query Logs";
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.logTextBox.ForeColor = System.Drawing.Color.White;
            this.logTextBox.Location = new System.Drawing.Point(17, 45);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(873, 354);
            this.logTextBox.TabIndex = 1;
            this.logTextBox.Text = resources.GetString("logTextBox.Text");
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Uptime Chart";
            // 
            // uptI
            // 
            this.uptI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.uptI.ForeColor = System.Drawing.Color.White;
            this.uptI.Location = new System.Drawing.Point(324, 427);
            this.uptI.Name = "uptI";
            this.uptI.Size = new System.Drawing.Size(45, 15);
            this.uptI.TabIndex = 3;
            this.uptI.Text = "Uptime";
            this.uptI.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dntI
            // 
            this.dntI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dntI.ForeColor = System.Drawing.Color.White;
            this.dntI.Location = new System.Drawing.Point(410, 427);
            this.dntI.Name = "dntI";
            this.dntI.Size = new System.Drawing.Size(61, 15);
            this.dntI.TabIndex = 4;
            this.dntI.Text = "Downtime";
            this.dntI.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lvdI
            // 
            this.lvdI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lvdI.ForeColor = System.Drawing.Color.White;
            this.lvdI.Location = new System.Drawing.Point(503, 427);
            this.lvdI.Name = "lvdI";
            this.lvdI.Size = new System.Drawing.Size(81, 15);
            this.lvdI.TabIndex = 5;
            this.lvdI.Text = "LIVE Disabled";
            this.lvdI.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uptB
            // 
            this.uptB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uptB.BackColor = System.Drawing.Color.Green;
            this.uptB.Enabled = false;
            this.uptB.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.uptB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uptB.Location = new System.Drawing.Point(300, 426);
            this.uptB.Name = "uptB";
            this.uptB.Size = new System.Drawing.Size(16, 16);
            this.uptB.TabIndex = 6;
            this.uptB.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(386, 426);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(16, 16);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.BackColor = System.Drawing.Color.DimGray;
            this.button3.Enabled = false;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(479, 426);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(16, 16);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // timingBarChart
            // 
            this.timingBarChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            textAnnotation1.AxisXName = "ChartArea1\\rX";
            textAnnotation1.ClipToChartArea = "BarChartArea";
            textAnnotation1.IsSizeAlwaysRelative = false;
            textAnnotation1.Name = "TextAnnotation";
            textAnnotation1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
            textAnnotation1.SmartLabelStyle.IsOverlappedHidden = false;
            textAnnotation1.Text = "TextAnnotation";
            textAnnotation1.YAxisName = "ChartArea1\\rY2";
            this.timingBarChart.Annotations.Add(textAnnotation1);
            this.timingBarChart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Interval = 3D;
            chartArea2.AxisX.IntervalOffset = 3D;
            chartArea2.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.MajorGrid.Interval = 3D;
            chartArea2.AxisX.MajorGrid.IntervalOffset = 3D;
            chartArea2.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea2.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.ScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            chartArea2.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            chartArea2.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chartArea2.AxisX2.ScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            chartArea2.AxisX2.ScrollBar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            chartArea2.AxisX2.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chartArea2.AxisX2.ScrollBar.IsPositionedInside = false;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Calibri", 9F);
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Interval = 0D;
            chartArea2.AxisY.MajorGrid.IntervalOffset = 3D;
            chartArea2.AxisY.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea2.AxisY.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY.ScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            chartArea2.AxisY.ScrollBar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 93F;
            chartArea2.InnerPlotPosition.Width = 98F;
            chartArea2.InnerPlotPosition.X = 1F;
            chartArea2.Name = "BarChartArea";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.timingBarChart.ChartAreas.Add(chartArea2);
            this.timingBarChart.Location = new System.Drawing.Point(17, 457);
            this.timingBarChart.Name = "timingBarChart";
            this.timingBarChart.Size = new System.Drawing.Size(873, 210);
            this.timingBarChart.TabIndex = 9;
            this.timingBarChart.Text = "timingBarChart";
            // 
            // licenseGroupBox
            // 
            this.licenseGroupBox.Controls.Add(this.textBox2);
            this.licenseGroupBox.Controls.Add(this.textBox1);
            this.licenseGroupBox.Controls.Add(this.hwIDTextBox);
            this.licenseGroupBox.Controls.Add(this.hIdLabel);
            this.licenseGroupBox.Controls.Add(this.acodeLabel);
            this.licenseGroupBox.Controls.Add(this.hwIDLabel);
            this.licenseGroupBox.ForeColor = System.Drawing.Color.White;
            this.licenseGroupBox.Location = new System.Drawing.Point(21, 24);
            this.licenseGroupBox.Name = "licenseGroupBox";
            this.licenseGroupBox.Size = new System.Drawing.Size(349, 179);
            this.licenseGroupBox.TabIndex = 0;
            this.licenseGroupBox.TabStop = false;
            this.licenseGroupBox.Text = "License";
            // 
            // hwIDLabel
            // 
            this.hwIDLabel.AutoSize = true;
            this.hwIDLabel.Location = new System.Drawing.Point(7, 27);
            this.hwIDLabel.Name = "hwIDLabel";
            this.hwIDLabel.Size = new System.Drawing.Size(76, 15);
            this.hwIDLabel.TabIndex = 0;
            this.hwIDLabel.Text = "Hardware ID";
            // 
            // acodeLabel
            // 
            this.acodeLabel.AutoSize = true;
            this.acodeLabel.Location = new System.Drawing.Point(7, 61);
            this.acodeLabel.Name = "acodeLabel";
            this.acodeLabel.Size = new System.Drawing.Size(91, 15);
            this.acodeLabel.TabIndex = 1;
            this.acodeLabel.Text = "Activation Code";
            // 
            // hIdLabel
            // 
            this.hIdLabel.AutoSize = true;
            this.hIdLabel.Location = new System.Drawing.Point(6, 93);
            this.hIdLabel.Name = "hIdLabel";
            this.hIdLabel.Size = new System.Drawing.Size(84, 15);
            this.hIdLabel.TabIndex = 2;
            this.hIdLabel.Text = "License Status";
            // 
            // hwIDTextBox
            // 
            this.hwIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.hwIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hwIDTextBox.Enabled = false;
            this.hwIDTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.hwIDTextBox.Location = new System.Drawing.Point(107, 22);
            this.hwIDTextBox.Name = "hwIDTextBox";
            this.hwIDTextBox.Size = new System.Drawing.Size(210, 23);
            this.hwIDTextBox.TabIndex = 3;
            this.hwIDTextBox.Text = "397DSFK-21389AS-BXZLJSD2";
            this.hwIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.Color.Orange;
            this.textBox1.Location = new System.Drawing.Point(107, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 23);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "SDF893LKASDF";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.textBox2.Location = new System.Drawing.Point(107, 89);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 23);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Unlicensed";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1164, 811);
            this.Controls.Add(this.bottomLabel);
            this.Controls.Add(this.accountsFlowPanel);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.toggleLive);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.labelLive);
            this.Controls.Add(this.labelChooseDate);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Name = "MainForm";
            this.Text = "Daily Metrics 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainTabControl.ResumeLayout(false);
            this.dashboardTab.ResumeLayout(false);
            this.dashboardTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.settingsTab.ResumeLayout(false);
            this.settingsTab.PerformLayout();
            this.logTab.ResumeLayout(false);
            this.logTab.PerformLayout();
            this.aboutTab.ResumeLayout(false);
            this.bottomLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timingBarChart)).EndInit();
            this.licenseGroupBox.ResumeLayout(false);
            this.licenseGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChooseDate;
        private System.Windows.Forms.Label labelLive;
        private CustomTabControl mainTabControl;
        private System.Windows.Forms.TabPage dashboardTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.TabPage logTab;
        private System.Windows.Forms.TabPage aboutTab;
        private JCS.ToggleSwitch toggleLive;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.FlowLayoutPanel accountsFlowPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private JCS.ToggleSwitch toggleNoComm;
        private System.Windows.Forms.Label _noCommLabel;
        private System.Windows.Forms.ComboBox accountTypeComboBox;
        private System.Windows.Forms.TextBox accountNameTextBox;
        private System.Windows.Forms.Button addAccountButton;
        private System.Windows.Forms.Button button1;
        private CustomTabControl accountTabControl;
        private System.Windows.Forms.Panel bottomLabel;
        private System.Windows.Forms.Label localTimeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button uptB;
        private System.Windows.Forms.Label lvdI;
        private System.Windows.Forms.Label dntI;
        private System.Windows.Forms.Label uptI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart timingBarChart;
        private System.Windows.Forms.GroupBox licenseGroupBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox hwIDTextBox;
        private System.Windows.Forms.Label hIdLabel;
        private System.Windows.Forms.Label acodeLabel;
        private System.Windows.Forms.Label hwIDLabel;
    }
}

