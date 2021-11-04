
namespace TradeLoggerMini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.acAlias = new System.Windows.Forms.TextBox();
            this.acPort = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cntBtn = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.platf = new System.Windows.Forms.ComboBox();
            this.acDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.reminder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // acAlias
            // 
            this.acAlias.Location = new System.Drawing.Point(135, 18);
            this.acAlias.Name = "acAlias";
            this.acAlias.Size = new System.Drawing.Size(138, 20);
            this.acAlias.TabIndex = 0;
            // 
            // acPort
            // 
            this.acPort.Location = new System.Drawing.Point(135, 78);
            this.acPort.Name = "acPort";
            this.acPort.Size = new System.Drawing.Size(138, 20);
            this.acPort.TabIndex = 1;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(27, 146);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cntBtn
            // 
            this.cntBtn.Location = new System.Drawing.Point(198, 146);
            this.cntBtn.Name = "cntBtn";
            this.cntBtn.Size = new System.Drawing.Size(75, 23);
            this.cntBtn.TabIndex = 3;
            this.cntBtn.Text = "Connect";
            this.cntBtn.UseVisualStyleBackColor = true;
            this.cntBtn.Click += new System.EventHandler(this.cntBtn_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ForeColor = System.Drawing.Color.Red;
            this.status.Location = new System.Drawing.Point(90, 203);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(107, 20);
            this.status.TabIndex = 4;
            this.status.Text = "Disconnected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Account Alias";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Platform";
            // 
            // platf
            // 
            this.platf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.platf.FormattingEnabled = true;
            this.platf.Items.AddRange(new object[] {
            "CTrader",
            "MT4",
            "MT5"});
            this.platf.Location = new System.Drawing.Point(135, 48);
            this.platf.MaxDropDownItems = 4;
            this.platf.Name = "platf";
            this.platf.Size = new System.Drawing.Size(138, 21);
            this.platf.TabIndex = 8;
            this.platf.SelectedIndexChanged += new System.EventHandler(this.platf_SelectedIndexChanged);
            // 
            // acDay
            // 
            this.acDay.Location = new System.Drawing.Point(135, 104);
            this.acDay.Name = "acDay";
            this.acDay.Size = new System.Drawing.Size(138, 20);
            this.acDay.TabIndex = 9;
            this.acDay.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Number of Days";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Minimized to system tray";
            this.notifyIcon1.BalloonTipTitle = "Info";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Not Configured";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // reminder
            // 
            this.reminder.AutoSize = true;
            this.reminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reminder.ForeColor = System.Drawing.Color.DimGray;
            this.reminder.Location = new System.Drawing.Point(38, 184);
            this.reminder.Name = "reminder";
            this.reminder.Size = new System.Drawing.Size(223, 13);
            this.reminder.TabIndex = 11;
            this.reminder.Text = "Note: Please enable all history in MT4";
            this.reminder.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 239);
            this.Controls.Add(this.reminder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.acDay);
            this.Controls.Add(this.platf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.status);
            this.Controls.Add(this.cntBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.acPort);
            this.Controls.Add(this.acAlias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "API Connector";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox acAlias;
        private System.Windows.Forms.TextBox acPort;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cntBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox platf;
        private System.Windows.Forms.TextBox acDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label reminder;
    }
}

