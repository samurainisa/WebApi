using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebClient.Data.Enums;
using WebClient.Data.Models;
using WebClient.Data.PostForms;
using WebClient.Data.Service;
using WebClient.Data.Transfer;

namespace WebClient.Forms
{
    public partial class UserForm : Form
    {
        private static AuthInfo _authInfo = new AuthInfo();
        private IDataUseCases getData = new UploadData();

        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(string infoEmail, string infoRole, string token)
        {
            InitializeComponent();
            _authInfo.Email = infoEmail;
            _authInfo.Role = infoRole;
            _authInfo.access_token = token;
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            lblEmail.Text = _authInfo.Email;
            lblRole.Text = _authInfo.Role;

            try
            {
                Console.WriteLine(_authInfo.access_token);

                var clubs = await getData.GetClubs(_authInfo.access_token);
                var sports = await getData.GetSports(_authInfo.access_token);
                var sportplaces = await getData.GetSportPlaces(_authInfo.access_token);

                if (clubs == null || sports == null || sportplaces == null)
                {
                    MessageBox.Show("Токен истек, пожалуйста, авторизуйтесь заново");
                }

                else
                {
                    listView1.Items.Clear();
                    //выгрузить элементы в listview1

                    foreach (var club in clubs)
                    {
                        ListViewItem clubitem = new ListViewItem(club.Id.ToString());

                        clubitem.SubItems.Add(club.Name);
                        listView1.Items.Add(clubitem);
                    }

                    foreach (var sport in sports)
                    {
                        ListViewItem sportitem = new ListViewItem(sport.Id.ToString());

                        sportitem.SubItems.Add(sport.Name);
                        listView2.Items.Add(sportitem);
                    }

                    foreach (var sportplace in sportplaces)
                    {
                        ListViewItem sportplaceitem = new ListViewItem(sportplace.Id.ToString());
                        sportplaceitem.SubItems.Add(sportplace.Name);
                        sportplaceitem.SubItems.Add(sportplace.Capacity.ToString());
                        sportplaceitem.SubItems.Add(sportplace.Address);
                        sportplaceitem.SubItems.Add(sportplace.City);
                        sportplaceitem.SubItems.Add(sportplace.Country);
                        sportplaceitem.SubItems.Add(sportplace.CoverType);
                        listView3.Items.Add(sportplaceitem);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private void видСпортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //модальное окно для добавления нового клуба в БД
            SportsForm sportForm = new SportsForm(_authInfo);
            sportForm.ShowDialog();
        }

        private void спортивноеСооружениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SportPlaceForm sportForm = new SportPlaceForm(_authInfo);
            sportForm.ShowDialog();
        }

        private void клубToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //модальное окно для добавления нового клуба в БД
            ClubsForm clubForm = new ClubsForm(_authInfo);
            clubForm.ShowDialog();
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void разлогинитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthForm authorizationForm = new AuthForm();
            if (MessageBox.Show("Вы уверены что хотите выйти из аккаунта?", "Выход", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                Close();
                authorizationForm.Show();
            }
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    pictureBox4.Image = RotateImage(pictureBox4.Image, 36);
                    await Task.Delay(10);
                }

                Console.WriteLine(_authInfo.access_token);
                var sportplePlaces = await getData.GetSportPlaces(_authInfo.access_token);

                if (sportplePlaces == null)
                {
                    MessageBox.Show("Токен истек, пожалуйста, авторизуйтесь заново");
                    //разлогинить и закрыть форму
                    Hide();
                    AuthForm authorizationForm = new AuthForm();
                    authorizationForm.Show();
                }
                else
                {
                    listView3.Items.Clear();
                    //выгрузить элементы в listview1


                    foreach (var sportplace in sportplePlaces)
                    {
                        ListViewItem sportplaceitem = new ListViewItem(sportplace.Id.ToString());
                        sportplaceitem.SubItems.Add(sportplace.Name);
                        sportplaceitem.SubItems.Add(sportplace.Capacity.ToString());
                        sportplaceitem.SubItems.Add(sportplace.Address);
                        sportplaceitem.SubItems.Add(sportplace.City);
                        sportplaceitem.SubItems.Add(sportplace.Country);
                        sportplaceitem.SubItems.Add(sportplace.CoverType);
                        listView3.Items.Add(sportplaceitem);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    pictureBox1.Image = RotateImage(pictureBox1.Image, 36);
                    await Task.Delay(10);
                }

                Console.WriteLine(_authInfo.access_token);
                var sports = await getData.GetSports(_authInfo.access_token);

                if (sports == null)
                {
                    MessageBox.Show("Токен истек, пожалуйста, авторизуйтесь заново");
                    //разлогинить и закрыть форму
                    Hide();
                    AuthForm authorizationForm = new AuthForm();
                    authorizationForm.Show();
                }
                else
                {
                    listView2.Items.Clear();
                    //выгрузить элементы в listview1

                    foreach (var sport in sports)
                    {
                        ListViewItem item = new ListViewItem(sport.Id.ToString());
                        item.SubItems.Add(sport.Name);
                        listView2.Items.Add(item);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    pictureBox2.Image = RotateImage(pictureBox2.Image, 36);
                    await Task.Delay(10);
                }

                Console.WriteLine(_authInfo.access_token);
                var clubs = await getData.GetClubs(_authInfo.access_token);

                if (clubs == null)
                {
                    MessageBox.Show("Токен истек, пожалуйста, авторизуйтесь заново");
                    //разлогинить и закрыть форму
                    Hide();
                    AuthForm authorizationForm = new AuthForm();
                    authorizationForm.Show();
                }
                else
                {
                    listView2.Items.Clear();
                    //выгрузить элементы в listview1

                    foreach (var club in clubs)
                    {
                        ListViewItem item = new ListViewItem(club.Id.ToString());
                        item.SubItems.Add(club.Name);
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }
    }
}