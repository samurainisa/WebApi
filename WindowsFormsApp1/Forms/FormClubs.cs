using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class FormClubs : Form
    {
        public FormClubs()
        {
            InitializeComponent();
        }

        private void LoadTheme()
        {
            foreach (Control btns in Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
        }

        private void FormClubs_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            
            LoadData();
        }

        public async void LoadData()
        {
            // using (HttpClient client = new HttpClient())
            // {
            //     client.BaseAddress = new Uri("https://localhost:7059/");
            //     client.DefaultRequestHeaders.Accept.Clear();
            //     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //
            //     HttpResponseMessage response;
            //
            //     response = await client.GetAsync("api/Sports");
            //
            //
            //     if (response.IsSuccessStatusCode)
            //     {
            //         var sports = await response.Content.ReadAsAsync<IEnumerable<Sport>>();
            //         foreach (var sport in sports)
            //         {
            //             clubUserControl1.label4.Text = sport.Name;
            //             clubUserControl1.label2.Text = sport.Name;
            //
            //         }
            //     }
            //     
            //     

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7059/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                response = await client.GetAsync("api/Clubs");

                //динамически создаем объект класса ClubUserControl  и добавляем его в панель и скроллим вертикально
                if (response.IsSuccessStatusCode)
                {
                    var clubs = await response.Content.ReadAsAsync<IEnumerable<Club>>();
                    foreach (var club in clubs)
                    {
                        ClubUserControl clubUserControl = new ClubUserControl();
                        clubUserControl.label4.Text = club.Name;
                        clubUserControl.label2.Text = club.Name;
                    }
                }

            }
        }
    }

}
