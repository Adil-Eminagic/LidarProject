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

namespace SerialCommunication.Other_forms
{
   
    public partial class frmTest : Form
    {
        private LIDRController lidrController;
        public frmTest()
        {
            InitializeComponent();
            lidrController = new LIDRController("COM5");
        }
        private void StartScanButton_Click(object sender, EventArgs e)
        {
            lidrController.SendCommand("start_scan");
            byte[] rawData = Encoding.ASCII.GetBytes(lidrController.ReceiveData());
            string hexData = BitConverter.ToString(rawData);
            MessageBox.Show("Received data (hex): " + hexData);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            lidrController.Close();
        }
    }
    public class LIDRController
    {
        private SerialPort _serialPort;

        public LIDRController(string portName)
        {
            _serialPort = new SerialPort(portName, 230400);
            _serialPort.Open();
        }

        public void SendCommand(string command)
        {
            _serialPort.WriteLine(command);
        }

        public string ReceiveData()
        {
            return _serialPort.ReadLine();
        }

        public void Close()
        {
            _serialPort.Close();
        }
    }
}
