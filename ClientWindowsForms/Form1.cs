using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public async void LoadData()
        {
            //создание клиента и выгрузка данных
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7059/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // получаем ответ
                HttpResponseMessage response = await client.GetAsync("api/Clubs");
                if (response.IsSuccessStatusCode)
                {
                    // читаем ответ
                    string content = await response.Content.ReadAsStringAsync();

                    foreach (var item in content)
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }

        }
    }
}
