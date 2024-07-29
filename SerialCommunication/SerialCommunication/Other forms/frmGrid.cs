
using Newtonsoft.Json;
using SerialCommunication.Structures;

namespace SerialCommunication.Other_forms
{
    public partial class frmGrid : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private List<List<double>> grid = new List<List<double>>();

        public frmGrid()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.panel1.Dock = DockStyle.Fill;

            this.panel1.Paint += new PaintEventHandler(this.Panel1_Paint);
        }

        private async void btnGrid_Click(object sender, EventArgs e)
        {
            string url = "http://127.0.0.1:5000/grid";
            try
            {
                grid = await GetApiData(url);
                panel1.Invalidate(); // Redraw the panel
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message} \n {ex?.InnerException}");
            }
        }

        private async Task<List<List<double>>> GetApiData(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<List<double>> dots = JsonConvert.DeserializeObject<List<List<double>>>(responseBody);
            return dots;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (grid == null || grid.Count == 0)
                return;

            Graphics g = e.Graphics;
            int rows = grid.Count;
            int cols = grid[0].Count;

            // Define the size of each cell
            int cellWidth = panel1.Width / cols;
            int cellHeight = panel1.Height / rows;

            // Adjust cell size for better performance with large grids
            if (cellWidth < 1) cellWidth = 1;
            if (cellHeight < 1) cellHeight = 1;

            // Draw the grid
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Determine the color based on the value in the array
                    Color color = grid[row][col] == 0 ? Color.White : Color.Black; // Change color as needed
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        g.FillRectangle(brush, col * cellWidth, row * cellHeight, cellWidth, cellHeight);
                    }

                    // Optionally, draw grid lines
                    g.DrawRectangle(Pens.Black, col * cellWidth, row * cellHeight, cellWidth, cellHeight);
                }
            }
        }
    }
}
