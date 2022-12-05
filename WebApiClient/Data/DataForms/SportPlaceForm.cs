using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiClient.Data.Models;
using WebApiClient.Data.Service;
using WebApiClient.Data.Transfer;
using WebApiClient.Forms;

namespace WebApiClient.Data.DataForms
{
    public partial class SportPlaceForm : Form
    {
        public SportPlaceForm()
        {
            InitializeComponent();
        }

        public SportPlaceForm(AuthInfo authInfo)
        {
            InitializeComponent();
            _authInfo = authInfo;
        }

        private DataUseCases post = new UploadData();
        private readonly AuthInfo _authInfo;

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var sportplace = textBox1.Text;
                var capacity = Convert.ToInt32(textBox2.Text);
                var address = textBox4.Text;
                var city = textBox3.Text;
                var country = textBox6.Text;
                var cover = textBox5.Text;


                var sportplaceinfo = new SportPlaces
                {
                    Name = sportplace,
                    Capacity = capacity,
                    Address = address,
                    City = city,
                    Country = country,
                    CoverType = cover
                };

                if (sportplaceinfo.Name == "")
                {
                    MessageBox.Show("Пожалуйста, заполните все поля");
                }
                else
                {
                    var res = post.PostSportPlace(sportplaceinfo, _authInfo.access_token);
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
    }
}