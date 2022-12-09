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
    public partial class TrenersForm : Form
    {
        private IDataUseCases post = new UploadData();
        private readonly AuthInfo _authInfo;

        public TrenersForm()
        {
            InitializeComponent();
        }

        public TrenersForm(AuthInfo authInfo)
        {
            InitializeComponent();
            _authInfo = authInfo;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var firstname = textBox1.Text;
                var lastname = textBox2.Text;
                var sportname = textBox3.Text;

                var trener = new Trener
                {
                    FirstName = firstname,
                    LastName = lastname,
                    sportname = sportname
                };


                if (trener.FirstName == "")
                {
                    MessageBox.Show("Пожалуйста, заполните все поля");
                }
                else
                {
                    var res = post.PostTrener(trener, _authInfo.access_token);
                    if (res == null)
                    {
                        MessageBox.Show("Токен истек, пожалуйста, авторизуйтесь заново");
                        Hide();
                        AuthForm authForm = new AuthForm();
                        authForm.Show();
                    }
                }

                MessageBox.Show("Тренер успешно добавлен");
                Hide();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private void btnLogin_MouseEnter_1(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_MouseLeave_1(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;
        }
    }
}