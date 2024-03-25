using System.IO.Ports;

namespace SerialCommunication
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
            this.Click += (o,a) => { 
                MessageBox.Show($"{o}\n{a}");
            };
        }

        int counter = 0;

        private void InitializeSerialPort()
        {
            int rate = int.Parse(txtBaudRate.Text);

            try
            {
                serialPort = new SerialPort();
                serialPort.PortName = txtPortName.Text;

                serialPort.BaudRate = rate;
                serialPort.Open();
                MessageBox.Show("Serial port is opened");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error on serial port: " + ex.Message);
            }

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close the serial port when the form is closing
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void SendDataToArduino(string data)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Write(data);
            }
            else
            {
                MessageBox.Show("Serial port is not open.");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            InitializeSerialPort();
        }

        private void btnLightOn_Click(object sender, EventArgs e)
        {
            string dataToSend = "O";
            SendDataToArduino(dataToSend);
        }

        private void btnLightOff_Click(object sender, EventArgs e)
        {
            string dataToSend = "o";
            SendDataToArduino(dataToSend);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter % 2 == 0)
                SendDataToArduino("O");
            else
                SendDataToArduino("o");
            counter++;
        }

        private void btnTimerStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btnLidar_Click(object sender, EventArgs e)
        {
            var frmLidar = new frmLidar();
            frmLidar.ShowDialog();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            var frmReceive= new frmReceiveData();
            frmReceive.ShowDialog();
        }
    }
}
