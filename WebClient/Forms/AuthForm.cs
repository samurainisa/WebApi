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

namespace WebClient.Forms
{
    public partial class AuthForm : Form
    {
        AuthInfo _authInfo = new AuthInfo();
        private IUserUseCases login = new FetchData();

        public AuthForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            RegisterForm signUpForm = new RegisterForm();
            signUpForm.Show();
            this.Hide();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.DarkTurquoise;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                
                var username = tbUsername.Text;
                var password = tbPassword.Text;

                var info = await login.LogIn(username, password);

                if (info != null)
                {
                    if (info.Role == "Admin")
                    {
                        // AdminForm adminForm = new AdminForm();
                        // adminForm.Show();
                        // Hide();
                    }
                    else if (info.Role == "User")
                    {
                        UserForm userForm = new UserForm(info.Email, info.Role, info.access_token);
                        userForm.Show();
                        Hide();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            //при нажатии на Enter нажимается кнопка входа
            this.AcceptButton = btnLogin;
            //при нажатии кнопка анимирует
            btnLogin.MouseEnter += (s, a) => { btnLogin.ForeColor = Color.Black; };
            btnLogin.MouseLeave += (s, a) => { btnLogin.ForeColor = Color.DarkTurquoise; };

            //пока данные загружаются кнопка блокируется
            
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}