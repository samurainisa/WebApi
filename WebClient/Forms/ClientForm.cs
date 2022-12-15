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
using WebClient.Data.Models;
using WebClient.Data.PostForms;
using WebClient.Data.Service;
using WebClient.Data.Transfer;

namespace WebClient.Forms
{
    public partial class ClientForm : Form
    {
        private static AuthInfo _authInfo = new AuthInfo();
        private IAdminUseCases getData = new UploadData();

        //конструктор принимающий в себя параметр для настройки tabPage в зависимости от роли пользователя

        public ClientForm()
        {
            InitializeComponent();
        }

        public ClientForm(string infoEmail, string infoRole, string token)
        {
            InitializeComponent();
            _authInfo.Email = infoEmail;
            _authInfo.Role = infoRole;
            _authInfo.access_token = token;
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblEmail.Text = _authInfo.Email;
                lblRole.Text = _authInfo.Role;

                Console.WriteLine(_authInfo.access_token);

                var clubs = await getData.GetClubs(_authInfo.access_token);
                var sports = await getData.GetSports(_authInfo.access_token);
                var sportplaces = await getData.GetSportPlaces(_authInfo.access_token);
                var trainers = await getData.GetTreners(_authInfo.access_token);
                var athletes = await getData.GetAthletes(_authInfo.access_token);
                var users = await getData.GetUsers(_authInfo.access_token);

                if (_authInfo.Role == "User")
                {
                    dataControl.TabPages.Remove(tabPage1);
                }
                else
                {
                    foreach (var user in users)
                    {
                        dataGridView6.Rows.Add(user.UserId, user.Email, user.Role, user.Password);
                    }
                }

                dataGridView2.Rows.Clear();

                foreach (var sport in sports)
                {
                    dataGridView2.Rows.Add(sport.Id, sport.Name);
                }

                dataGridView3.Rows.Clear();
                foreach (var sportplace in sportplaces)
                {
                    dataGridView3.Rows.Add(sportplace.Id, sportplace.Name, sportplace.Capacity
                        , sportplace.Address, sportplace.City, sportplace.Country, sportplace.CoverType);
                }

                dataGridView4.Rows.Clear();
                foreach (var trainer in trainers)
                {
                    dataGridView4.Rows.Add(trainer.Id, trainer.FirstName, trainer.LastName, trainer.SportId);
                }

                dataGridView5.Rows.Clear();
                foreach (var athlete in athletes)
                {
                    dataGridView5.Rows.Add(athlete.Id, athlete.FirstName, athlete.LastName, athlete.ClubId,
                        athlete.SportId
                        , athlete.TrenerId, athlete.SportPlaceId);
                }

                dataGridView1.Rows.Clear();
                foreach (var club in clubs)
                {
                    dataGridView1.Rows.Add(club.Id, club.Name);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                AuthForm authForm = new AuthForm();
                authForm.Show();
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
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new Point(0, 0));
            gfx.Dispose();
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
                    dataGridView3.Rows.Clear();
                    //выгрузить элементы в listview1

                    foreach (var sportplace in sportplePlaces)
                    {
                        dataGridView3.Rows.Add(sportplace.Id, sportplace.Name, sportplace.Capacity
                            , sportplace.Address, sportplace.City, sportplace.Country, sportplace.CoverType);
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
                    dataGridView2.Rows.Clear();
                    //выгрузить элементы в listview1

                    foreach (var sport in sports)
                    {
                        dataGridView2.Rows.Add(sport.Id, sport.Name);
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
                    dataGridView1.Rows.Clear();
                    //выгрузить элементы в listview1

                    foreach (var club in clubs)
                    {
                        dataGridView1.Rows.Add(club.Id, club.Name);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private void тренерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrenersForm trainerForm = new TrenersForm(_authInfo);
            trainerForm.Show();
        }

        private async void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    pictureBox3.Image = RotateImage(pictureBox3.Image, 36);
                    await Task.Delay(10);
                }

                Console.WriteLine(_authInfo.access_token);
                var trainers = await getData.GetTreners(_authInfo.access_token);

                if (trainers == null)
                {
                    MessageBox.Show("Токен истек, пожалуйста, авторизуйтесь заново");
                    //разлогинить и закрыть форму
                    Hide();
                    AuthForm authorizationForm = new AuthForm();
                    authorizationForm.Show();
                }
                else
                {
                    dataGridView4.Rows.Clear();
                    foreach (var trainer in trainers)
                    {
                        dataGridView4.Rows.Add(trainer.Id, trainer.FirstName, trainer.LastName, trainer.SportId);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private async void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    pictureBox5.Image = RotateImage(pictureBox5.Image, 36);
                    await Task.Delay(10);
                }

                Console.WriteLine(_authInfo.access_token);
                var athletes = await getData.GetAthletes(_authInfo.access_token);

                if (athletes == null)
                {
                    MessageBox.Show("Токен истек, пожалуйста, авторизуйтесь заново");
                    //разлогинить и закрыть форму
                    Hide();
                    AuthForm authorizationForm = new AuthForm();
                    authorizationForm.Show();
                }
                else
                {
                    dataGridView5.Rows.Clear();
                    foreach (var athlete in athletes)
                    {
                        dataGridView5.Rows.Add(athlete.Id, athlete.FirstName, athlete.LastName, athlete.ClubId,
                            athlete.SportId
                            , athlete.TrenerId, athlete.SportPlaceId);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private void спортсменToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AthleteForm athletesForm = new AthleteForm(_authInfo);
            athletesForm.Show();
        }

        private void клубToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClubsForm clubForm = new ClubsForm(_authInfo);
            clubForm.Show();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 2)
            {
                var id = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                var name = dataGridView1.Rows[e.RowIndex].Cells[1].Value;

                var club = new Club
                {
                    Id = (int)id,
                    Name = name.ToString()
                };

                var result = MessageBox.Show($"Вы действительно хотите удалить клуб {name}?", "Удаление клуба",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var deletedData = await getData.DeleteClub(club, _authInfo.access_token);
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }

            //также сделать для кнопки Edit
            if (e.RowIndex > -1 && e.ColumnIndex == 3)
            {
                try
                {
                    var id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    var name = dataGridView1.Rows[e.RowIndex].Cells[1].Value;

                    var club = new Club
                    {
                        Id = Convert.ToInt32(id),
                        Name = name.ToString()
                    };

                    var result = MessageBox.Show("Подтвердите изменение клуба?", "Изменение клуба",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await getData.EditClub(club, _authInfo.access_token);
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private async void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 2)
            {
                var id = dataGridView2.Rows[e.RowIndex].Cells[0].Value;
                var name = dataGridView2.Rows[e.RowIndex].Cells[1].Value;

                var sport = new Sport
                {
                    Id = Convert.ToInt32(id),
                    Name = name.ToString()
                };

                var result = MessageBox.Show($"Вы действительно хотите удалить вид спорта {name}?",
                    "Удаление вида спорта",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await getData.DeleteSport(sport, _authInfo.access_token);
                    dataGridView2.Rows.RemoveAt(e.RowIndex);
                }
            }

            //также сделать для кнопки Edit
            if (e.RowIndex > -1 && e.ColumnIndex == 3)
            {
                try
                {
                    var id = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    var name = dataGridView2.Rows[e.RowIndex].Cells[1].Value;

                    var sport = new Sport
                    {
                        Id = Convert.ToInt32(id),
                        Name = name.ToString()
                    };

                    var result = MessageBox.Show("Подтвердите изменение вида спорта?", "Изменение вида спорта",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await getData.EditSport(sport, _authInfo.access_token);
                        dataGridView2.Rows.RemoveAt(e.RowIndex);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}