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
using WebApiClient.Data;
using WebApiClient.Data.DataForms;
using WebApiClient.Data.Enums;
using WebApiClient.Data.Models;
using WebApiClient.Data.Service;
using WebApiClient.Data.Transfer;

namespace WebApiClient.Forms
{
    public partial class UserForm : Form
    {
        private UserUseCases getData = new FetchData();
        private static AuthInfo _authInfo = new AuthInfo();
        private DataUseCases getClubs = new UploadData();

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
            // label1.Text = _authInfo.access_token;
            //наполнить выпадающий список enum'ом ListTables
            var items = Enum.GetValues(typeof(Tables));
            toolStripComboBox1.Items.AddRange(items.Cast<object>().ToArray());

            try
            {
                Console.WriteLine(_authInfo.access_token);
                var clubs = await getClubs.GetClubs(_authInfo.access_token);
                var sports = await getClubs.GetClubs(_authInfo.access_token);

                if (clubs == null)
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
                    ListViewItem sportitem = new ListViewItem(club.Id.ToString());
                    sportitem.SubItems.Add()


                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
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


        private void button1_Click(object sender, EventArgs e)
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
                var clubs = await getClubs.GetClubs(_authInfo.access_token);

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
                    listView1.Items.Clear();
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