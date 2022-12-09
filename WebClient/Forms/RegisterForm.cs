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
        IUserUseCases register = new FetchData();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var email = tbUsername.Text;
            var password = tbPassword.Text;

            var res = await register.Register(email, password);
            if (res == "ok")
            {
                MessageBox.Show("You have successfully registered");
                AuthForm authForm = new AuthForm();
                authForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}