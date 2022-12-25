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
    public partial class SportPlaceForm : Form
    {
        private IAdminUseCases post = new UploadData();
        private readonly AuthInfo _authInfo;

        public SportPlaceForm()
        {
            InitializeComponent();
        }

        public SportPlaceForm(AuthInfo authInfo)
        {
            InitializeComponent();
            _authInfo = authInfo;
        }


        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DarkTurquoise;
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                var sportplace = textBox1.Text;
                var capacity = Convert.ToInt32(textBox2.Text);
                var address = textBox4.Text;
                var city = textBox3.Text;
                var country = textBox6.Text;
                var cover = textBox5.Text;


                var sportplaceinfo = new SportPlaces
                {
                    Name = sportplace,
                    Capacity = capacity,
                    Address = address,
                    City = city,
                    Country = country,
                    CoverType = cover
                };

                if (sportplaceinfo.Name == "")
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

        private void SportPlaceForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}