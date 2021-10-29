
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
            this.acAlias = new System.Windows.Forms.TextBox();
            this.acPort = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cntBtn = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.platf = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // acAlias
            // 
            this.acAlias.Location = new System.Drawing.Point(151, 53);
            this.acAlias.Name = "acAlias";
            this.acAlias.Size = new System.Drawing.Size(138, 20);
            this.acAlias.TabIndex = 0;
            // 
            // acPort
            // 
            this.acPort.Location = new System.Drawing.Point(151, 124);
            this.acPort.Name = "acPort";
            this.acPort.Size = new System.Drawing.Size(100, 20);
            this.acPort.TabIndex = 1;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(43, 204);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cntBtn
            // 
            this.cntBtn.Location = new System.Drawing.Point(214, 204);
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
            this.status.Location = new System.Drawing.Point(108, 252);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(107, 20);
            this.status.TabIndex = 4;
            this.status.Text = "Disconnected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Account Alias";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
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
            this.platf.Location = new System.Drawing.Point(151, 88);
            this.platf.MaxDropDownItems = 4;
            this.platf.Name = "platf";
            this.platf.Size = new System.Drawing.Size(121, 21);
            this.platf.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 292);
            this.Controls.Add(this.platf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.status);
            this.Controls.Add(this.cntBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.acPort);
            this.Controls.Add(this.acAlias);
            this.Name = "MainForm";
            this.Text = "Form1";
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
    }
}

