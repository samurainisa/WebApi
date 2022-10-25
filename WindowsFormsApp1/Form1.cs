using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            Text = string.Empty;
            ControlBox = false;
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }

            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }



        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }



        //massive of sports
        public static string[] SportsStatic =
        {
            "Баскетбол", "Волейбол", "Футбол", "Хоккей", "Бейсбол", "Теннис", "Гандбол", "Бадминтон", "Бокс", "Борьба",
            "Борьба смешанная", "Водное поло", "Волейбол пляжный", "Гимнастика", "Гольф", "Дартс", "Дзюдо",
            "Дзюдо-самбо", "Единоборства", "Зимние виды спорта",
        };


        public static void CreateData<T>(string address) where T : new()
        {
            int n = SportsStatic.Length;
            Random rnd = new Random();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7059/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //create field Name
                PropertyInfo prop = typeof(T).GetProperty("Name");
                HttpResponseMessage response;

                List<T> list = new List<T>();

                for (int i = 0; i < 100; i++)
                {
                    T obj = new T();
                    prop.SetValue(obj, SportsStatic[rnd.Next(0, n)]);
                    list.Add(obj);
                    response = client.PostAsJsonAsync(address, list[i]).Result;
                }
            }
        }


        private void сгенерироватьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateData<Club>("api/Clubs");
            CreateData<Sport>("api/Sports");
        }

        private void btnClub_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormClubs(), sender);
        }

        private void btnSport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSports(), sender);
        }

        private void btnSportPlaces_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSportPlaces(), sender);
        }

        private void btnTreners_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormTreners(), sender);
        }

        private void btnAthletes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormAthletes(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close
            Application.Exit();
            
        }
    }
}