using SerialCommunication.Structures;


namespace SerialCommunication.Other_forms
{
    public partial class frmDots : Form
    {
        //double[] dotsArray = new double[360];
        (int angleInDegrees, double distance)[] dots= { };

        public frmDots()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public frmDots(List<LiDARFrame> liDARs)
        {
            InitializeComponent();
            AddDots(ref dots, liDARs);
            this.WindowState = FormWindowState.Maximized;

        }

        private void AddDots(ref (int angleInDegrees, double distance)[] dots, List<LiDARFrame> liDARs)
        {
            var dotList = new List<(int, double)>(dots);

            foreach(var lidar in liDARs)
            {
                var angle = Math.Round(lidar.start_angle * 0.01,0);
                dotList.Add((lidar.start_angle, lidar.points[0].distance*0.1));
            }

            // Convert list back to array if needed
            dots = dotList.ToArray();

        }

        private void frmDots_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Define the center point for drawing
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Draw the center of the coordinate system
            int crossSize = 5;
            g.DrawLine(Pens.Red, centerX - crossSize, centerY, centerX + crossSize, centerY); // Horizontal line
            g.DrawLine(Pens.Red, centerX, centerY - crossSize, centerX, centerY + crossSize); // Vertical line

            // Define the dots' parameters
            //(double angleInDegrees, double distance)[] dots = {
            //    (45, 100),
            //    (135, 80),
            //    (225, 120),
            //    (315, 150)
            //};

            // Draw dots based on angle and distance values
            foreach (var dotParams in dots)
            {
                double angleInDegrees = dotParams.angleInDegrees;
                double distance = dotParams.distance;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
