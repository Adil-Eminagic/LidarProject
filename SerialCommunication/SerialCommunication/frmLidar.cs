using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialCommunication
{
    public partial class frmLidar : Form
    {
        private SerialPort serialPort;
        private LiDARController lidarController;

        public frmLidar()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        private void frmLidar_Load(object sender, EventArgs e)
        {

        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort("COM5", 230400); // Replace "COM1" with your port name
            serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadLine(); // Read data from the serial port
            // Parse and process the data as per the LiDAR data structure
            // Update UI with the processed data (e.g., display in a TextBox)
            UpdateDataTextBox(data);
        }

        private void UpdateDataTextBox(string data)
        {
            if (dataTextBox.InvokeRequired)
            {
                dataTextBox.Invoke(new Action(() => UpdateDataTextBox(data)));
            }
            else
            {
                dataTextBox.AppendText(data + Environment.NewLine);
            }
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Open();
                startButton.Enabled = false;
                stopButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening serial port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }

    public class LiDARController
    {
        private SerialPort serialPort;

        public LiDARController(string portName, int baudRate)
        {
            serialPort = new SerialPort(portName, baudRate);
        }

        public void Start()
        {
            serialPort.Open();
        }

        public void Stop()
        {
            serialPort.Close();
        }
    }

}
