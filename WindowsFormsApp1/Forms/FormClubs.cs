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
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace WindowsFormsApp1.Forms
{
    public partial class FormClubs : Form
    {
        public FormClubs()
        {
            InitializeComponent();
        }

        public static IEnumerable<Club> ValueName { get; set; }

        public FormClubs(IEnumerable<Club> Name)
        {
            InitializeComponent();
            ValueName = Name;
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

        //serialization data from listViewClub to file
        private void SarializationData(ListView listViewClub)
        {
            var clubs = new List<Club>();
            foreach (ListViewItem item in listViewClub.Items)
            {
                clubs.Add(new Club
                {
                    Name = item.Text,
                });
            }

            var serializer = new XmlSerializer(typeof(List<Club>));
            using (var stream =
                   new FileStream("C:\\Users\\Nik\\Desktop\\WebApplication2\\WindowsFormsApp1\\Datastore\\club.xml",
                       FileMode.Create))
            {
                serializer.Serialize(stream, clubs);
            }

            if (File.Exists("/Datastore/club.xml"))
            {
                MessageBox.Show("Serialization is done");
            }
        }

        //deserialization data from file to listViewClub
        private void DeserializationData(ListView listViewClub)
        {
            var serializer = new XmlSerializer(typeof(List<Club>));
            using (var stream =
                   new FileStream("C:\\Users\\Nik\\Desktop\\WebApplication2\\WindowsFormsApp1\\Datastore\\club.xml",
                       FileMode.Open))
            {
                var clubs = (List<Club>)serializer.Deserialize(stream);
                foreach (var club in clubs)
                {
                    listViewClub.Items.Add(club.Name);
                }
            }
        }

        public async void LoadData()
        {


            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7059/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                response = await client.GetAsync("api/Clubs");
            }
        }

        private void btnGetClubs_Click(object sender, EventArgs e)
        {
            ModalClubView modalClubView = new ModalClubView();
            modalClubView.ShowDialog();
            listView1.Items.Clear();

            //асинхронный цикл
            Thread thread = new Thread(() =>
            {
                foreach (var club in ValueName)
                {
                    listView1.Invoke(new Action(() => { listView1.Items.Add(club.Name); }));
                }
            });
            thread.Start();
        }
    }
}