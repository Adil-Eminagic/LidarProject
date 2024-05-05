using SerialCommunication.Helpers;
using SerialCommunication.Structures;
using System.IO.Ports;
using System.Text;


namespace SerialCommunication.Other_forms
{
    public partial class frmDrawingSpace : Form
    {

        private SerialPort _serialPort = new SerialPort();
        List<Dot> dots = new List<Dot>();
        //(int angleInDegrees, double distance)[] dots = { };


        public frmDrawingSpace()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnRead_Click(object sender, EventArgs e)
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

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string stringData = sp.ReadLine();
            byte[] byteData = Encoding.ASCII.GetBytes(stringData);
            var frames = new List<LiDARFrame>();

            Helper.ConverSingleDataRecieved(ref frames, byteData);



            if (frames.Count > 0)
            {
                AddUpdateDots(ref dots, frames);
                //update 
            }

        }

        private void AddUpdateDots(ref List<Dot> dots, List<LiDARFrame> liDARs)
        {
            foreach (var lidar in liDARs)
            {
                var angle = Math.Round(lidar.start_angle * 0.01, 0);
                var difference = Math.Round((lidar.end_angle - lidar.start_angle)*0.01,0) /11;

                for (int i = 0; i < 11; i++)
                {
                    int indexToUpdate = dots.FindIndex(dot => dot.AngleInDegrees == angle);
                    if (indexToUpdate > 0)
                        dots[indexToUpdate].Distance = lidar.points[0].distance * 0.5;
                    else
                    {
                        dots.Add(new Dot()
                        {
                            AngleInDegrees = Math.Round(lidar.start_angle * 0.01 + difference*i,0),
                            Distance = lidar.points[i].distance 
                        });
                    }
                     
                }
                
            }

            Invalidate();

        }

        //private void AddUpdateDots(ref List<Dot> dots, List<LiDARFrame> liDARs)
        //{
        //    foreach (var lidar in liDARs)
        //    {
        //        var angle = Math.Round(lidar.start_angle * 0.01, 0);
        //        int indexToUpdate = dots.FindIndex(dot => dot.AngleInDegrees == angle);
        //        if (indexToUpdate > 0)
        //            dots[indexToUpdate].Distance = lidar.points[0].distance * 0.5;
        //        else
        //            dots.Add(new Dot()
        //            {
        //                AngleInDegrees = lidar.start_angle,
        //                Distance = lidar.points[0].distance * 0.5
        //            });
        //    }

        //    Invalidate();

        //}

        private void frmDrawingSpace_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Define the center point for drawing
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Draw the center of the coordinate system
            int crossSize = 5;
            g.DrawLine(Pens.Red, centerX - crossSize, centerY, centerX + crossSize, centerY); // Horizontal line
            g.DrawLine(Pens.Red, centerX, centerY - crossSize, centerX, centerY + crossSize); // Vertical line

            //Define the dots' parameters
            //(double angleInDegrees, double distance)[] dots = {
            //    (45, 100),
            //    (135, 80),
            //    (225, 120),
            //    (315, 150)
            //};

            // Draw dots based on angle and distance values
            foreach (var dotParams in dots)
            {
                double angleInDegrees = dotParams.AngleInDegrees;
                double distance = dotParams.Distance;

                // Convert the angle to radians
                double angleInRadians = angleInDegrees * Math.PI / 180;

                // Calculate the coordinates of the dot
                int dotX = (int)(centerX + distance * Math.Cos(angleInRadians));
                int dotY = (int)(centerY - distance * Math.Sin(angleInRadians)); // Minus sign because Y-axis is inverted in graphics

                // Draw the dot (assuming a small radius)
                int dotRadius = 3;
                g.FillEllipse(Brushes.Black, dotX - dotRadius, dotY - dotRadius, 2 * dotRadius, 2 * dotRadius);
            }
        }

        private void frmDrawingSpace_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the serial port is open before attempting to close it
            if (_serialPort.IsOpen)
            {
                _serialPort.Close(); // Close the serial port
            }
        }

    }
}
