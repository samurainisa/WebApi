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
    public partial class ClubsForm : Form
    {
        private IAdminUseCases post = new UploadData();
        private readonly AuthInfo _authInfo;

        public ClubsForm()
        {
            InitializeComponent();
        }

        public ClubsForm(AuthInfo authInfo)
        {
            InitializeComponent();
            _authInfo = authInfo;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var club = textBox1.Text;

                var clubInfo = new Club
                {
                    Name = club
                };

                if (clubInfo.Name == "")
                {
                    MessageBox.Show("Пожалуйста, заполните все поля");
                    return;
                }

                var res = post.PostClub(clubInfo, _authInfo.access_token);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Hide();
                AuthForm authForm = new AuthForm();
                authForm.Show();
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;
        }

    }
}