using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiClient.Data;
using WebApiClient.Data.Models;
using WebApiClient.Data.Service;

namespace WebApiClient.Forms
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        AuthInfo _authInfo = new AuthInfo();

        private UserUseCases login = new FetchData();

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SignInForm signUpForm = new SignInForm();
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


                if (info.Role == "Admin")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                    Hide();
                }
                else if (info.Role == "User")
                {
                    UserForm userForm = new UserForm(info.Email, info.Role, info.access_token);
                    userForm.Show();
                    Hide();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
        }
    }
}