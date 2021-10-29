using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TradeLoggerMini
{
    public partial class MainForm : Form
    {
        private Backend backend;
        public MainForm()
        {
            InitializeComponent();
            backend = new Backend(this);
            platf.SelectedIndex = 0;
        }

        public void UpdateConfig(string alias, string plat, int port)
        {
            acAlias.Text = alias;
            platf.Text = plat;
            acPort.Text = port.ToString();
            acAlias.Enabled = false;
            platf.Enabled = false;
            acPort.Enabled = false;
            saveBtn.Text = "Edit";
        }

        public bool UpdateState(string stat)
        {
            bool bRet = false;
            cntBtn.Invoke((MethodInvoker)delegate {
                if (stat == "Disconnected" || stat == "Failed")
                {
                    if (cntBtn.Text == "Disconnect")
                    {
                        status.Text = "Reconnecting";
                        status.ForeColor = Color.Yellow;
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
                saveBtn.Text = "Save";
            }
            else if (saveBtn.Text == "Save")
            {
                int r;
                if (!Int32.TryParse(acPort.Text, out r))
                {
                    MessageBox.Show("Invalid Port");
                    return;
                }
                acAlias.Enabled = false;
                platf.Enabled = false;
                acPort.Enabled = false;
                saveBtn.Text = "Edit";
                backend.UpdateConfig(acAlias.Text, platf.Text, r);
            }
        }

        private void cntBtn_Click(object sender, EventArgs e)
        {
            if (cntBtn.Text == "Connect")
            {
                backend.Connect();
                cntBtn.Text = "Disconnect";
            }
            else if (cntBtn.Text == "Disconnect")
            {
                backend.Disconnect();
                cntBtn.Text = "Connect";
            }
        }
    }
}
