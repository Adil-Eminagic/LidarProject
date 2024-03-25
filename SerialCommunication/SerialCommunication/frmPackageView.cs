using SerialCommunication.Structures;

namespace SerialCommunication
{
    public partial class frmPackageView : Form
    {

        List<LiDARFrame> frames;
        int count = 0;
        public frmPackageView()
        {
            InitializeComponent();
        }

        public frmPackageView(List<LiDARFrame> liDARFrames)
        {
            InitializeComponent();
            frames = liDARFrames;
            txtOverall.Text = frames.Count.ToString();
            ShowPackage();
        }

        private void ShowPackage()
        {
            gridPackage.Rows.Add("something");
            for (int i = 0; i < 12; i++)
            {
                gridPoints.Rows.Add("some", "some");
            }
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            var package = frames[count];
            gridPackage.Rows.RemoveAt(0);
            for (int i = 11; i >= 0; i--)
            {
                gridPoints.Rows.RemoveAt(i);
            }
            gridPackage.Rows.Add(package.header, package.ver_len, package.speed, package.start_angle, package.end_angle,
                package.timestamp, package.crc8);
            txtPacNumber.Text = (count + 1).ToString();
            //txtPacNumber.Text = gridPoints.Rows.Count.ToString();
            for (int i = 0; i < 12; i++)
            {
                gridPoints.Rows.Add(package.points[i].distance, package.points[i].intensity);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (count < frames.Count - 1)
            {
                count++;
                UpdateGrid();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count--;
                UpdateGrid();
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            try
            {
                CreateCSV("Uglovi_Tacke.csv", true);
                MessageBox.Show("CSV file created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the CSV file: " + ex.Message);
            }
        }

        private void CreateCSV(string fileName, bool withPoints = false)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write("Header");
                    sw.Write(",");
                    sw.Write("VarLen");
                    sw.Write(",");
                    sw.Write("Speed");
                    sw.Write(",");
                    sw.Write("Start angle");
                    sw.Write(",");

                    if (withPoints)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            sw.Write($"MP{i + 1} distance");
                            sw.Write(",");
                            sw.Write($"MP{i + 1} intensity");
                            sw.Write(",");
                        }
                    }

                    sw.Write("End angle");
                    sw.Write(",");
                    sw.Write("Timestamps");
                    sw.Write(",");
                    sw.Write("Crc check");
                    sw.Write(sw.NewLine);

                    foreach (var pack in frames)
                    {
                        sw.Write(pack.header);
                        sw.Write(",");
                        sw.Write(pack.ver_len);
                        sw.Write(",");
                        sw.Write(pack.speed);
                        sw.Write(",");
                        sw.Write(pack.start_angle);
                        sw.Write(",");
                        if (withPoints)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                sw.Write(pack.points[i].distance);
                                sw.Write(",");
                                sw.Write(pack.points[i].intensity);
                                sw.Write(",");
                            }
                        }
                        sw.Write(pack.end_angle);
                        sw.Write(",");
                        sw.Write(pack.timestamp);
                        sw.Write(",");
                        sw.Write(pack.crc8);
                        sw.Write(",");
                        sw.Write(sw.NewLine);


                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating CSV file: " + ex.Message);
            }
        }

    }
}
