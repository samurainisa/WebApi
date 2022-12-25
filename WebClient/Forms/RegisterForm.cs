using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebClient.Data.Service;
using WebClient.Data.Transfer;

namespace WebClient.Forms
{
    public partial class RegisterForm : Form
    {
        IUserUseCases register = new AuthorizeData();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var email = tbUsername.Text;
                var password = tbPassword.Text;

                var res = await register.Register(email, password);
                
                if (res == "Conflict")
                {
                    MessageBox.Show("Такой пользователь уже существует");
                }
                else
                {
                    MessageBox.Show("Вы успешно зарегистрировались");
                    AuthForm authForm = new AuthForm();
                    authForm.Show();
                    Hide();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            AcceptButton = btnLogin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //вернуться на форму авторизации
            AuthForm authForm = new AuthForm();
            authForm.Show();
            Hide();
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;
        }
    }
}