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
using WebApiClient.Data.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WebApiClient.Forms
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        UserUseCases register = new FetchData();
        
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