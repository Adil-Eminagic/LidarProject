using Newtonsoft.Json;
using SerialCommunication.Structures;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialCommunication.Other_forms
{
    public partial class frmAPI : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public frmAPI()
        {
            InitializeComponent();
            btnFetch.Click += BtnFetchData_Click; 
        }

        private async void BtnFetchData_Click(object sender, EventArgs e)
        {
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            string url2 = "http://127.0.0.1:5000/data";
            try
            {
                Todo todo = await GetApiData(url);
                txtData.Text = $"UserId: {todo.UserId}\n" +
                               $"Id: {todo.Id}\n" +
                               $"Title: {todo.Title}\n" +
                               $"Completed: {todo.Completed}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async Task<Todo> GetApiData(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Todo todo = JsonConvert.DeserializeObject<Todo>(responseBody);
            return todo;
        }
    }
}
