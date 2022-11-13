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

namespace WebApiClient.Forms
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        UserUseCases register = new FetchData();

        private async void button1_Click(object sender, EventArgs e)
        {
            var email = textBox1.Text;
            var password = textBox2.Text;

            var res = await register.Register(email, password);
            if (res == "ok")
            {
                MessageBox.Show("You have successfully registered");
                AuthForm authForm = new AuthForm();
                authForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}