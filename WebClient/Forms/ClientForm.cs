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
                        dataGridView6.Rows.Add(user.UserId, user.Email, user.Role, user.Password,user.Salt);
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
            sportForm.Show();
        }

        private void спортивноеСооружениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SportPlaceForm sportForm = new SportPlaceForm(_authInfo);
            sportForm.Show();
        }

        private void клубToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //модальное окно для добавления нового клуба в БД
            ClubsForm clubForm = new ClubsForm(_authInfo);
            clubForm.Show();
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
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private async void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 7)
            {
                var id = dataGridView3.Rows[e.RowIndex].Cells[0].Value;
                var name = dataGridView3.Rows[e.RowIndex].Cells[1].Value;
                var capacity = dataGridView3.Rows[e.RowIndex].Cells[2].Value;
                var address = dataGridView3.Rows[e.RowIndex].Cells[3].Value;
                var city = dataGridView3.Rows[e.RowIndex].Cells[4].Value;
                var country = dataGridView3.Rows[e.RowIndex].Cells[5].Value;
                var covertype = dataGridView3.Rows[e.RowIndex].Cells[6].Value;


                var sport = new SportPlaces
                {
                    Id = Convert.ToInt32(id),
                    Name = name.ToString(),
                    Capacity = Convert.ToInt32(capacity),
                    Address = address.ToString(),
                    City = city.ToString(),
                    Country = country.ToString(),
                    CoverType = covertype.ToString()
                };

                var result = MessageBox.Show($"Вы действительно хотите удалить спортивное сооружение {name}?",
                    "Удаление вида спорта",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await getData.DeleteSportPlace(sport, _authInfo.access_token);
                    dataGridView3.Rows.RemoveAt(e.RowIndex);
                }
            }

            //также сделать для кнопки Edit
            if (e.RowIndex > -1 && e.ColumnIndex == 8)
            {
                try
                {
                    var id = dataGridView3.Rows[e.RowIndex].Cells[0].Value;
                    var name = dataGridView3.Rows[e.RowIndex].Cells[1].Value;
                    var capacity = dataGridView3.Rows[e.RowIndex].Cells[2].Value;
                    var address = dataGridView3.Rows[e.RowIndex].Cells[3].Value;
                    var city = dataGridView3.Rows[e.RowIndex].Cells[4].Value;
                    var country = dataGridView3.Rows[e.RowIndex].Cells[5].Value;
                    var covertype = dataGridView3.Rows[e.RowIndex].Cells[6].Value;


                    var sport = new SportPlaces
                    {
                        Id = Convert.ToInt32(id),
                        Name = name.ToString(),
                        Capacity = Convert.ToInt32(capacity),
                        Address = address.ToString(),
                        City = city.ToString(),
                        Country = country.ToString(),
                        CoverType = covertype.ToString()
                    };

                    var result = MessageBox.Show("Подтвердите изменение спортивного сооружения?",
                        "Изменение спортивного сооружения",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await getData.EditSportPlace(sport, _authInfo.access_token);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private async void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex == 4)
                {
                    var id = dataGridView4.Rows[e.RowIndex].Cells[0].Value;
                    var firstname = dataGridView4.Rows[e.RowIndex].Cells[1].Value;
                    var lastname = dataGridView4.Rows[e.RowIndex].Cells[2].Value;
                    var sportname = dataGridView4.Rows[e.RowIndex].Cells[3].Value;

                    var trener = new Trener
                    {
                        Id = Convert.ToInt32(id),
                        FirstName = firstname.ToString(),
                        LastName = lastname.ToString(),
                        SportId = Convert.ToInt32(sportname)
                    };

                    var result = MessageBox.Show(
                        $"Вы действительно хотите удалить тренера {firstname}, + {lastname}?",
                        "Удаление вида спорта",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await getData.DeleteTrener(trener, _authInfo.access_token);
                        dataGridView4.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


            //также сделать для кнопки Edit
            if (e.RowIndex > -1 && e.ColumnIndex == 5)
            {
                try
                {
                    var id = dataGridView4.Rows[e.RowIndex].Cells[0].Value;
                    var firstname = dataGridView4.Rows[e.RowIndex].Cells[1].Value;
                    var lastname = dataGridView4.Rows[e.RowIndex].Cells[2].Value;
                    var sportname = dataGridView4.Rows[e.RowIndex].Cells[3].Value;

                    var trener = new Trener
                    {
                        Id = Convert.ToInt32(id),
                        FirstName = firstname.ToString(),
                        LastName = lastname.ToString(),
                        SportId = Convert.ToInt32(sportname)
                    };

                    var result = MessageBox.Show("Подтвердите изменение спортивного сооружения?",
                        "Изменение спортивного сооружения",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await getData.EditTrener(trener, _authInfo.access_token);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private async void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex == 7)
                {
                    var id = dataGridView5.Rows[e.RowIndex].Cells[0].Value;
                    var firstname = dataGridView5.Rows[e.RowIndex].Cells[1].Value;
                    var lastname = dataGridView5.Rows[e.RowIndex].Cells[2].Value;
                    var clubname = dataGridView5.Rows[e.RowIndex].Cells[3].Value;
                    var sportname = dataGridView5.Rows[e.RowIndex].Cells[4].Value;
                    var trener = dataGridView5.Rows[e.RowIndex].Cells[5].Value;
                    var sportplace = dataGridView5.Rows[e.RowIndex].Cells[6].Value;


                    var athlete = new Athlete
                    {
                        Id = Convert.ToInt32(id),
                        FirstName = firstname.ToString(),
                        LastName = lastname.ToString(),
                        ClubId = Convert.ToInt32(clubname),
                        SportId = Convert.ToInt32(sportname),
                        TrenerId = Convert.ToInt32(trener),
                        SportPlaceId = Convert.ToInt32(sportplace)
                    };

                    var result = MessageBox.Show(
                        $"Вы действительно хотите удалить спортсмена {firstname} {lastname}?",
                        "Удаление вида спорта",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await getData.DeleteAthlete(athlete, _authInfo.access_token);
                        dataGridView5.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


            //также сделать для кнопки Edit
            if (e.RowIndex > -1 && e.ColumnIndex == 8)
            {
                try
                {
                    var id = dataGridView5.Rows[e.RowIndex].Cells[0].Value;
                    var firstname = dataGridView5.Rows[e.RowIndex].Cells[1].Value;
                    var lastname = dataGridView5.Rows[e.RowIndex].Cells[2].Value;
                    var clubname = dataGridView5.Rows[e.RowIndex].Cells[3].Value;
                    var sportname = dataGridView5.Rows[e.RowIndex].Cells[4].Value;
                    var trener = dataGridView5.Rows[e.RowIndex].Cells[5].Value;
                    var sportplace = dataGridView5.Rows[e.RowIndex].Cells[6].Value;


                    var athlete = new Athlete
                    {
                        Id = Convert.ToInt32(id),
                        FirstName = firstname.ToString(),
                        LastName = lastname.ToString(),
                        ClubId = Convert.ToInt32(clubname),
                        SportId = Convert.ToInt32(sportname),
                        TrenerId = Convert.ToInt32(trener),
                        SportPlaceId = Convert.ToInt32(sportplace)
                    };

                    var result = MessageBox.Show("Подтвердите изменение спортсмена?",
                        "Изменение спортмена",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await getData.EditAthlete(athlete, _authInfo.access_token);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private async void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex == 5)
                {
                    var id = dataGridView6.Rows[e.RowIndex].Cells[0].Value;
                    var email = dataGridView6.Rows[e.RowIndex].Cells[1].Value;
                    var role = dataGridView6.Rows[e.RowIndex].Cells[2].Value;
                    var password = dataGridView6.Rows[e.RowIndex].Cells[3].Value;
                    var salt = dataGridView6.Rows[e.RowIndex].Cells[4].Value;

                    var user = new UserData
                    {
                        UserId = Convert.ToInt32(id),
                        Email = email.ToString(),
                        Role = role.ToString(),
                        Password = password.ToString(),
                        Salt = salt.ToString()
                    };

                    var result = MessageBox.Show(
                        $"Вы действительно хотите пользователя email:{email}, id:{id}?",
                        "Удаление пользователя",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await getData.DeleteUserLogins(user, _authInfo.access_token);
                        dataGridView6.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


            //также сделать для кнопки Edit
            if (e.RowIndex > -1 && e.ColumnIndex == 6)
            {
                try
                {
                    var id = dataGridView6.Rows[e.RowIndex].Cells[0].Value;
                    var email = dataGridView6.Rows[e.RowIndex].Cells[1].Value;
                    var role = dataGridView6.Rows[e.RowIndex].Cells[2].Value;
                    var password = dataGridView6.Rows[e.RowIndex].Cells[3].Value;
                    var salt = dataGridView6.Rows[e.RowIndex].Cells[4].Value;


                    var user = new UserData
                    {
                        UserId = Convert.ToInt32(id),
                        Email = email.ToString(),
                        Role = role.ToString(),
                        Password = password.ToString(),
                        Salt = salt.ToString()
                    };

                    var result = MessageBox.Show("Подтвердите изменение пользователя?",
                        "Изменение пользователя",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await getData.EditUserLogins(user, _authInfo.access_token);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private async void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    pictureBox6.Image = RotateImage(pictureBox6.Image, 36);
                    await Task.Delay(10);
                }

                Console.WriteLine(_authInfo.access_token);
                var users = await getData.GetUsers(_authInfo.access_token);

                if (users == null)
                {
                    MessageBox.Show("Токен истек, пожалуйста, авторизуйтесь заново");
                    Hide();
                    AuthForm authorizationForm = new AuthForm();
                    authorizationForm.Show();
                }
                else
                {
                    dataGridView6.Rows.Clear();
                    foreach (var user in users)
                    {
                        dataGridView6.Rows.Add(user.UserId, user.Email, user.Role, user.Password, user.Salt, "Delete",
                            "Edit");
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