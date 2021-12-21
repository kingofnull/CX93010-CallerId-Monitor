
namespace CIDResolver
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
            this.txModemComPort = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new System.Windows.Forms.Button();
            this.consoleOut = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txModemComPort
            // 
            this.txModemComPort.Location = new System.Drawing.Point(12, 9);
            this.txModemComPort.Name = "txModemComPort";
            this.txModemComPort.Size = new System.Drawing.Size(473, 20);
            this.txModemComPort.TabIndex = 0;
            this.txModemComPort.Text = "COM7";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(491, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 27);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Connect";
            this.simpleButton1.UseVisualStyleBackColor = true;
            this.simpleButton1.Click += new System.EventHandler(this.Connect_click);
            // 
            // consoleOut
            // 
            this.consoleOut.Location = new System.Drawing.Point(12, 38);
            this.consoleOut.Multiline = true;
            this.consoleOut.Name = "consoleOut";
            this.consoleOut.Size = new System.Drawing.Size(644, 358);
            this.consoleOut.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Disconnect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.disConnectBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 408);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.consoleOut);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txModemComPort);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed_1);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txModemComPort;
        private System.Windows.Forms.Button simpleButton1;
        private System.Windows.Forms.TextBox consoleOut;
        private System.Windows.Forms.Button button1;
    }
}

