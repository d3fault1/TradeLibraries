using System;
using System.Drawing;
using System.Windows.Forms;

namespace TradeLoggerMini
{
    public partial class MainForm : Form
    {
        private Backend backend;
        public MainForm()
        {
            Application.ApplicationExit += Application_ApplicationExit;
            InitializeComponent();
            platf.SelectedIndex = 0;
            backend = new Backend(this);
        }

        public void UpdateConfig(string alias, string plat, int port, int day)
        {
            acAlias.Text = alias;
            platf.Text = plat;
            acPort.Text = port.ToString();
            acDay.Text = day.ToString();
            Text = "API Connector - " + alias;
            acAlias.Enabled = false;
            platf.Enabled = false;
            acPort.Enabled = false;
            acDay.Enabled = false;
            notifyIcon1.Text = acAlias.Text + " - " + status.Text;
            saveBtn.Text = "Edit";
        }

        public bool UpdateState(string stat)
        {
            bool bRet = false;
            cntBtn.Invoke((MethodInvoker)delegate
            {
                if (stat == "Disconnected" || stat == "Failed")
                {
                    if (cntBtn.Text == "Disconnect")
                    {
                        status.Text = "Reconnecting";
                        status.ForeColor = Color.Orange;
                        bRet = true;
                    }
                    else
                    {
                        status.Text = "Disconnected";
                        status.ForeColor = Color.Red;
                    }
                }
                else if (stat == "Connected")
                {
                    status.Text = stat;
                    status.ForeColor = Color.Green;
                }
                else if (stat == "Connecting")
                {
                    status.Text = stat;
                    status.ForeColor = Color.Gray;
                }
                if (saveBtn.Text == "Edit") notifyIcon1.Text = acAlias.Text + " - " + status.Text;
            });
            return bRet;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Edit")
            {
                acAlias.Enabled = true;
                platf.Enabled = true;
                acPort.Enabled = true;
                acDay.Enabled = true;
                saveBtn.Text = "Save";
                notifyIcon1.Text = "Not Configured";
            }
            else if (saveBtn.Text == "Save")
            {
                int r, d;
                if (acAlias.Text.Trim() == "")
                {
                    MessageBox.Show("Alias is Empty");
                    return;
                }
                if (!Int32.TryParse(acPort.Text, out r))
                {
                    MessageBox.Show("Invalid Port");
                    return;
                }
                if (!Int32.TryParse(acDay.Text, out d))
                {
                    MessageBox.Show("Invalid No. of Days");
                    return;
                }
                acAlias.Enabled = false;
                platf.Enabled = false;
                acPort.Enabled = false;
                acDay.Enabled = false;
                saveBtn.Text = "Edit";
                notifyIcon1.Text = acAlias.Text + " - " + status.Text;
                backend.ConfigUpdate(acAlias.Text, platf.Text, r, d);
            }
        }

        private void cntBtn_Click(object sender, EventArgs e)
        {
            if (cntBtn.Text == "Connect")
            {
                if (saveBtn.Text == "Save")
                {
                    MessageBox.Show("Configuration Not Saved!");
                    return;
                }
                backend.Connect();
                cntBtn.Text = "Disconnect";
            }
            else if (cntBtn.Text == "Disconnect")
            {
                backend.Disconnect();
                cntBtn.Text = "Connect";
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void platf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (platf.SelectedIndex == 1) reminder.Visible = true;
            else reminder.Visible = false;
        }
    }
}
