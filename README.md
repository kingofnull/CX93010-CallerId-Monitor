# CX93010-CallerId-Monitor

CX93010 has some problems to detecting CID but by seting Country of installation and activating reporting can fix them.

1. You must set `Country of Installation` to `B5` by `AT+GCI=B5` I got it after a three weeks of investigations (It may defer in your country it can be 00 or B4 or B5 but B5 for works for most of land lines): 

    [![enter image description here][1]][1]



2. Then enable CID reporting by `AT+VCID=1` or `AT+VCID=2` as it said in [manual][2]:
[![enter image description here][3]][3]




3. And then it works flawlessly:
[![enter image description here][4]][4]


And this is my working code based on yours:

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO.Ports;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace CIDResolver
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            SerialPort sp;
            private void Connect_click(object sender, EventArgs e)
            {
                sp = new SerialPort(textEdit1.Text);
                sp.BaudRate = 11500;
                sp.NewLine = "\r\n";
    
                sp.Open();

                sp.WriteLine("AT+GCI=B5"); // can be 00 or B4 or B5
                sp.WriteLine("AT+VCID=1");
    
                sp.DataReceived += new SerialDataReceivedEventHandler((object _s, SerialDataReceivedEventArgs _e) =>
                {
                    string newData = sp.ReadExisting();
                    consoleOut.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        consoleOut.Text += newData+ "\r\n";
                    });
                });
            }
    
    
            private void disConnectBtn_Click(object sender, EventArgs e)
            {
                sp.Close();
            }
    
            private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
            {
                sp.Close();
            }
        }
    }


  [1]: https://i.stack.imgur.com/BCWHl.png
  [2]: https://data2.manualslib.com/pdf5/115/11410/1140976-conexant/cx93010.pdf?80a0b6308045e408c52fac12cf9f7514&take=binary
  [3]: https://i.stack.imgur.com/qJ39p.png
  [4]: https://i.stack.imgur.com/2RRKt.png