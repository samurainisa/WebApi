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
    public partial class SportsForm : Form
    {
        private readonly AuthInfo _authInfo;
        private DataUseCases post = new UploadData();
        public SportsForm()
        {
            InitializeComponent();
        }

        public SportsForm(AuthInfo authInfo)
        {
            InitializeComponent();
            _authInfo = authInfo;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var sport = textBox1.Text;

                var sportInfo = new Sport
                {
                    Name = sport
                };

                if (sportInfo.Name == "")
                {
                    MessageBox.Show("Пожалуйста, заполните все поля");
                }
                else
                {
                    var res = post.PostSport(sportInfo, _authInfo.access_token);
                    if (res == null)
                    {
                        MessageBox.Show("Токен истек, пожалуйста, авторизуйтесь заново");
                        Hide();
                        AuthForm authForm = new AuthForm();
                        authForm.Show();
                    }
                }
                MessageBox.Show("Вид спорта успешно добавлен");
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