using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebClient.Data.Models;
using WebClient.Data.Service;
using WebClient.Data.Transfer;
using WebClient.Forms;

namespace WebClient.Data.PostForms
{
    public partial class AthleteForm : Form
    {
        private IDataUseCases post = new UploadData();
        private readonly AuthInfo _authInfo;

        public AthleteForm()
        {
            InitializeComponent();
        }

        public AthleteForm(AuthInfo authInfo)
        {
            InitializeComponent();
            _authInfo = authInfo;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                var firstnamee = textBox1.Text;
                var lastname = textBox2.Text;
                var clubname = textBox4.Text;
                var sportname = textBox3.Text;
                var trenername = textBox6.Text;
                var sportplacename = textBox5.Text;


                var athlete = new Athlete
                {
                    FirstName = firstnamee,
                    LastName = lastname,
                    ClubName = clubname,
                    SportName = sportname,
                    TrenerName = trenername,
                    SportPlaceName = sportplacename
                };

                if (athlete.FirstName == "")
                {
                    MessageBox.Show("Пожалуйста, заполните все поля");
                }
                else
                {
                    var res = post.PostAthlete(athlete, _authInfo.access_token);
                    if (res == null)
                    {
                        MessageBox.Show("Токен истек, пожалуйста, авторизуйтесь заново");
                        Hide();
                        AuthForm authForm = new AuthForm();
                        authForm.Show();
                    }
                }

                MessageBox.Show("Спортивное сооружение успешно добавлено");
                Hide();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

    }
}