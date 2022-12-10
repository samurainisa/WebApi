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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var firstname = textBox1.Text;
                var lastname = textBox2.Text;
                var sportname = textBox3.Text;

                var trener = new TrenerDto
                {
                    FirstName = firstname,
                    LastName = lastname,
                    sportname = sportname
                };

                var result = await post.PostTrenerDto(trener, _authInfo.access_token);

                if (result != null)
                {
                    MessageBox.Show("Тренер добавлен");
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