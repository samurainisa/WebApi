using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ClientWindowsForms.Forms
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7059/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var email = tbLogin.Text;
                var password = tbPassword.Text;
                var confirmPassword = tbConfirmPassword.Text;


                var jsonObject = new
                {
                    email = email,
                    password = password,
                    confirmPassword = confirmPassword
                };

                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(jsonObject),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response2 = await client.PostAsync("api/Auth/verify", content);

                HttpResponseMessage response = await client.PostAsync("api/Auth/register", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("User created.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("User already exist.");
                }
                else
                {
                    MessageBox.Show("Error password or email.");
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
        }
    }
}