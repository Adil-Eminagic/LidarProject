using SerialCommunication.Helpers;
using SerialCommunication.Other_forms;
using SerialCommunication.Structures;
using System;
using System.IO.Packaging;
using System.IO.Ports;
using System.Text;

namespace SerialCommunication
{
    public partial class frmReceiveData : Form
    {
        private SerialPort _serialPort = new SerialPort();
        byte?[] framesBytes = new byte?[0];
        List<string> packages = new List<string>(); // list of received data in every turn
        List<LiDARFrame> frames = new List<LiDARFrame>(); //packages converted ti lidar frames
        int i;

        public frmReceiveData()
        {
            InitializeComponent();
            // InitializeSerialPort(); // You can initialize the serial port here if needed.
        }

        // Initialize the serial port with desired settings.
        private void InitializeSerialPort()
        {
            _serialPort.PortName = "COM5";
            _serialPort.BaudRate = 230400;
            _serialPort.DataBits = 8; // Set the number of data bits.
            _serialPort.StopBits = StopBits.One; // Set the number of stop bits.
            _serialPort.Parity = Parity.None; // Set the parity.
            _serialPort.Handshake = Handshake.None; // Set the handshake.
            _serialPort.DataReceived += DataReceivedHandler; // Subscribe to the DataReceived event.
            _serialPort.Open(); // Open the serial port.
        }

        // Event handler for when data is received from the serial port.
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadLine(); // Read the data from the serial port.
            packages.Add(data); //adding data to packages list

            //modified code
            //byte[] byteData = Encoding.ASCII.GetBytes(data);
            //List<LiDARFrame> liDARFrames = new List<LiDARFrame>();


            //Helper.ConvertToFrameOnReceived(ref byteData, ref liDARFrames);

            //var frmDots = new frmDots(liDARFrames);
            //frmDots.Show();

            //end of modified code


            // Invoke the UI update on the UI thread.
            Invoke(new Action(() =>
            {
                // Append the received data to the textbox.
                dataBox.AppendText(DateTime.Now.ToString() + " : " + data + Environment.NewLine);
            }));
        }

        // Event handler for the Read button click.
        private void btnRead_Click(object sender, EventArgs e)
        {
            InitializeSerialPort(); // Initialize the serial port.
        }

        // Clean up resources when the form is closing.
        private void frmReceiveData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_serialPort.IsOpen)
                _serialPort.Close(); // Close the serial port if it's open.
        }

        private void btnStopReading_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
        }


        private void btnConPac_Click(object sender, EventArgs e)//convert string frames into bytes
        {

            if (packages.Count > 0 && i < packages.Count) //checks if there are any items in packages list and moves true those items as long as it reaches end of list (second condition) 
            {
                int num84 = 0;
                txtBytePackage.Text = "";
                txtPackageLenght.Text = "";
                txt84.Text = "";
                byte[] data = Encoding.ASCII.GetBytes(packages[i]); //converts string data into bytes
                i++;
                for (int i = 0; i < data.Length; i++)
                {
                    txtBytePackage.AppendText(data[i] + Environment.NewLine);
                    if (data[i] == 84) //counts number of frames with header, which value is 84
                        num84++;
                }
                txtPackageLenght.Text = data.Length.ToString(); //number of bytes in single turn
                txt84.Text = num84.ToString();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            ConvertFrames();
            var frmPackages = new frmPackageView(frames);
            frmPackages.ShowDialog();
        }


        private void ConvertFrames()
        {
            for (int i = 0; i < packages.Count; i++)//convert every package item (string data)
            {
                byte[] data = Encoding.ASCII.GetBytes(packages[i]);
                ConvertSingleTurn(data);//extract frames from every data receiving turn
            }
        }



        private void ConvertSingleTurn(byte[] data)
        {
            //because frames lose on byte if they are not fully received in single turn, it only convert such frames are all in single data recieiving turn
            for (int i = 0; i < data.Length; i++)
            {
                if (data.Length > 46) // because frame consist of 47 bytes
                {
                    if (data[i] == 84 && data.Length - i > 46) //checks start of package (header) and are all bytes in same turn
                    {
                        var lidarFrame = new LiDARFrame();
                        lidarFrame.header = data[i++];//adds each byte or two bytes to each attribute in structure
                        lidarFrame.ver_len = data[i++];
                        lidarFrame.speed = (ushort)(data[i++] + data[i++] * 256);
                        lidarFrame.start_angle = (ushort)(data[i++] + data[i++] * 256);
                        lidarFrame.points = new List<LidarPoint>();

                        for (int j = 0; j < 12; j++)
                        {
                            LidarPoint lidarPoint = new LidarPoint();
                            lidarPoint.distance = (ushort)(data[i++] + data[i++] * 256);
                            lidarPoint.intensity = data[i++];
                            lidarFrame.points.Add(lidarPoint);
                        }
                        lidarFrame.end_angle = (ushort)(data[i++] + data[i++] * 256);
                        lidarFrame.timestamp = (ushort)(data[i++] + data[i++] * 256);
                        lidarFrame.crc8 = data[i];

                        //txtBytePackage.AppendText("Start angle: " + lidarFrame.start_angle + "   " + "distance: " + lidarFrame.points[0].distance + Environment.NewLine);

                        frames.Add(lidarFrame);

                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //ConvertFrames();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            ConvertFrames();
            var frmDots = new frmDots(frames);
            frmDots.Show();
        }
    }


}
