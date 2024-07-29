using Newtonsoft.Json;

using System.IO.Ports;



namespace SerialCommunication.Other_forms
{
    public partial class frmDrawingSpace : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private SerialPort _serialPort = new SerialPort();
        Dictionary<double, double> dots = new Dictionary<double, double>();
        Dictionary<double, double> pathDots = new Dictionary<double, double>();
        //Dictionary<double,double> dots = new Dictionary<double,double>();
        //List<Dot> dots = new List<Dot>();
        //(int angleInDegrees, double distance)[] dots = { };


        public frmDrawingSpace()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dots.Add(45, 75);
            btnRead.Text = "Draw space";
            btnRead.Click += btnRead_Click;
        }

        private async void btnRead_Click(object sender, EventArgs e)
        {
            pathDots.Clear();
            //string url = "http://127.0.0.1:5000/data";
            string url = "http://127.0.0.1:5000/cartesian";
            try
            {
                //string data = await GetApiData2(url);
                //List<Points> data = await GetApiData(url);
                //Dictionary<double, double> data = await GetApiData(url);
                dots = await GetApiData(url);
                Invalidate();
                //foreach (var item in data)
                //{
                //    textBox1.Text = $"Key: {item.Key}, Value: {item.Value}\t";

                //}
                //textBox1.Text = data.ToString();
                // MessageBox.Show(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message} \n {ex?.InnerException}");
            }
        }

        private async void btnPath_Click(object sender, EventArgs e)
        {
            string url = "http://127.0.0.1:5000/path";
            try
            {
                //string data = await GetApiData2(url);
                //List<Points> data = await GetApiData(url);
                //Dictionary<double, double> data = await GetApiData(url);
                pathDots = await GetApiData(url);
                Invalidate();
                //foreach (var item in data)
                //{
                //    textBox1.Text = $"Key: {item.Key}, Value: {item.Value}\t";

                //}
                //textBox1.Text = data.ToString();
                // MessageBox.Show(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message} \n {ex?.InnerException}");
            }
        }



        //private async Task<List<Points>> GetApiData(string url)
        //{
        //    HttpResponseMessage response = await client.GetAsync(url);
        //    response.EnsureSuccessStatusCode();
        //    string responseBody = await response.Content.ReadAsStringAsync();
        //    List<Points> dots = JsonConvert.DeserializeObject<List<Points>>(responseBody);
        //    return dots;
        //}
        private async Task<Dictionary<double, double>> GetApiData(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Dictionary<double, double> dots = JsonConvert.DeserializeObject<Dictionary<double, double>>(responseBody);
            return dots;
        }


       
        //private void SetSerialPort()
        //{
        //    _serialPort.PortName = "COM5";
        //    _serialPort.BaudRate = 230400;
        //    _serialPort.DataBits = 8; // Set the number of data bits.
        //    _serialPort.StopBits = StopBits.One; // Set the number of stop bits.
        //    _serialPort.Parity = Parity.None; // Set the parity.
        //    _serialPort.Handshake = Handshake.None; // Set the handshake.
        //    _serialPort.DataReceived += DataReceivedHandler; // Subscribe to the DataReceived event.
        //    _serialPort.Open(); // Open the serial port.
        //}

        //private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        //{
        //    SerialPort sp = (SerialPort)sender;
        //    string stringData = sp.ReadLine();
        //    byte[] byteData = Encoding.ASCII.GetBytes(stringData);
        //    var frames = new List<LiDARFrame>();

        //    Helper.ConverSingleDataRecieved(ref frames, byteData);



        //    if (frames.Count > 0)
        //    {
        //        AddUpdateDots(ref dots, frames);
        //        //update 
        //    }

        //}

        //private void AddUpdateDots(ref List<Dot> dots, List<LiDARFrame> liDARs)
        //{
        //    foreach (var lidar in liDARs)
        //    {
        //        var angle = Math.Round(lidar.start_angle * 0.01, 0);
        //        var difference = Math.Round((lidar.end_angle - lidar.start_angle) * 0.01, 0) / 11;

        //        for (int i = 0; i < 11; i++)
        //        {
        //            int indexToUpdate = dots.FindIndex(dot => dot.AngleInDegrees == angle);
        //            if (indexToUpdate > 0)
        //                dots[indexToUpdate].Distance = lidar.points[0].distance * 0.5;
        //            else
        //            {
        //                dots.Add(new Dot()
        //                {
        //                    AngleInDegrees = Math.Round(lidar.start_angle * 0.01 + difference * i, 0),
        //                    Distance = lidar.points[i].distance
        //                });
        //            }

        //        }

        //    }

        //    Invalidate();

        //}

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

            //dots =  GetApiData("http://127.0.0.1:5000/data");


            if (false)
            {
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
                    double angleInDegrees = dotParams.Key;
                    double distance = dotParams.Value;

                    // Convert the angle to radians
                    double angleInRadians = angleInDegrees * Math.PI / 180;

                    // Calculate the coordinates of the dot
                    int dotX = (int)(centerX + distance * Math.Cos(angleInRadians));
                    int dotY = (int)(centerY + distance * Math.Sin(angleInRadians)); // Minus sign because Y-axis is inverted in graphics

                    // Draw the dot (assuming a small radius)
                    int dotRadius = 3;
                    g.FillEllipse(Brushes.Black, dotX - dotRadius, dotY - dotRadius, 2 * dotRadius, 2 * dotRadius);
                }
            }
            else
            {
                int crossSize = 5;
                g.DrawLine(Pens.Red, centerX - crossSize, centerY, centerX + crossSize, centerY); // Horizontal line
                g.DrawLine(Pens.Red, centerX, centerY - crossSize, centerX, centerY + crossSize); // Vertical line

                // Define the dots' parameters in Cartesian coordinates (x, y)
                //(double x, double y)[] cartesianDots = {
                //    (10, 20),
                //    (30, 40),
                //    (50, 60),
                //    (70, 80)
                //};

                // Draw dots based on Cartesian coordinates (x, y)
                foreach (var dotParams in dots)
                {
                    double x = dotParams.Key;
                    double y = dotParams.Value;

                    // Calculate the coordinates of the dot
                    int dotX = (int)(centerX + x); // Adjust as necessary depending on your coordinate system
                    int dotY = (int)(centerY + y); // Minus sign because Y-axis is inverted in graphics

                    // Draw the dot (assuming a small radius)
                    int dotRadius = 3;
                    g.FillEllipse(Brushes.Black, dotX - dotRadius, dotY - dotRadius, 2 * dotRadius, 2 * dotRadius);
                }

                g.FillEllipse(Brushes.Green, 0 - 3, 0 - 3, 2 * 3, 2 * 3);

                if (pathDots.Count > 0)
                {
                    foreach (var dotParams in pathDots)
                    {
                        double x = dotParams.Key;
                        double y = dotParams.Value;

                        // Calculate the coordinates of the dot
                        int dotX = (int)(centerX + x); // Adjust as necessary depending on your coordinate system
                        int dotY = (int)(centerY + y); // Minus sign because Y-axis is inverted in graphics

                        // Draw the dot (assuming a small radius)
                        int dotRadius = 3;
                        g.FillEllipse(Brushes.Red, dotX - dotRadius, dotY - dotRadius, 2 * dotRadius, 2 * dotRadius);
                    }
                }

            }
            // Draw the center of the coordinate system

        }

       
        //private void frmDrawingSpace_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    // Check if the serial port is open before attempting to close it
        //    if (_serialPort.IsOpen)
        //    {
        //        _serialPort.Close(); // Close the serial port
        //    }
        //}

    }

    public class Points
    {
        public string Angle { get; set; }
        public double Distance { get; set; }
    }
}
