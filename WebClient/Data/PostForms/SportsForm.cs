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
    public partial class SportsForm : Form
    {
        private readonly AuthInfo _authInfo;
        private IAdminUseCases post = new UploadData();

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

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Hide();
                AuthForm authForm = new AuthForm();
                authForm.Show();

            }
        }

        private void btnLogin_MouseLeave_1(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;

        }

        private void btnLogin_MouseEnter_1(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;

        }
    }
}