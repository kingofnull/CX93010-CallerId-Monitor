using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIDResolver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        SerialPort sp;
        private void Connect_click(object sender, EventArgs e)
        {
            var modemComPort = txModemComPort.Text;

            sp = new SerialPort(modemComPort);
            sp.BaudRate = 11500;
            sp.NewLine = "\r\n";

            sp.Open();

            if (modemComPort != Properties.Settings.Default.ModemComPort)
            {
                Properties.Settings.Default["ModemComPort"] = modemComPort;
                Properties.Settings.Default.Save();
            }

            sp.WriteLine("AT+GCI=B5"); // can be 00 or B4 or B5
            sp.WriteLine("AT+VCID=1");



            sp.DataReceived += new SerialDataReceivedEventHandler((object _s, SerialDataReceivedEventArgs _e) =>
            {
                string newData = sp.ReadExisting();

                var m = Regex.Match(newData, "NMBR = (?<num>\\d+)");
                if (m.Success)
                {
                    consoleOut.Invoke((MethodInvoker)delegate
                    {
                        var num = m.Groups["num"];
                        // Running on the UI thread
                        consoleOut.Text += "NEW CID: " + num + "\r\n";
                    });
                    return;
                }

                consoleOut.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    consoleOut.Text += newData + "\r\n";
                });
            });
        }


        private void disConnectBtn_Click(object sender, EventArgs e)
        {
            sp.Close();
        }

        private void MainForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            sp.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txModemComPort.Text = Properties.Settings.Default.ModemComPort;
        }
    }
}
